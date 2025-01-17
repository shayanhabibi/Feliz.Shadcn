/// The Gantt chart is a powerful tool for visualizing project schedules and tracking the progress of tasks.
/// It provides a clear, hierarchical view of tasks, allowing you to easily identify manage project timelines.
[<AutoOpen>]
module Feliz.Shadcn.RoadmapUI.Gantt

open Fable.React
open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
JSX.injectShadcnLib
ignore <| JSX.jsx """
import {
  DndContext,
  MouseSensor,
  useDraggable,
  useSensor,
} from '@dnd-kit/core';
import { restrictToHorizontalAxis } from '@dnd-kit/modifiers';
import { useMouse, useThrottle, useWindowScroll } from '@uidotdev/usehooks';
import { formatDate, getDate } from 'date-fns';
import { formatDistance, isSameDay } from 'date-fns';
import { format } from 'date-fns';
import {
  addDays,
  addMonths,
  differenceInDays,
  differenceInHours,
  differenceInMonths,
  endOfDay,
  endOfMonth,
  getDaysInMonth,
  startOfDay,
  startOfMonth,
} from 'date-fns';
import throttle from 'lodash.throttle';
import { PlusIcon, TrashIcon } from 'lucide-react';
import {
  createContext,
  useCallback,
  useContext,
  useEffect,
  useId,
  useRef,
  useState,
} from 'react';
import { create } from 'zustand';
import { devtools } from 'zustand/middleware';
"""

open Feliz.Shadcn

let private imports = (
    ContextMenu,
    ContextMenuContent,
    ContextMenuItem,
    ContextMenuTrigger,
    Card
)

type [<Erase>] GanttState =
    {
        dragging : bool
        setDragging : bool -> unit
        resizing : bool
        setResizing : bool -> unit
        scrollX : int
        setScrollX : int -> unit
    }

let useGantt () : GanttState = unbox <| JSX.jsx """
create()(devtools((set) => ({
  dragging: false,
  setDragging: (dragging) => set(() => ({ dragging })),
  resizing: false,
  setResizing: (resizing) => set(() => ({ resizing })),
  scrollX: 0,
  setScrollX: (scrollX) => set(() => ({ scrollX })),
})))
"""

type [<Erase>] GanttStatus =
    {
        id : string
        name : string
        color : string
    }

type [<Erase>] GanttFeature =
    {
        id : string
        name : string
        startAt : JS.Date
        endAt : JS.Date
        status : GanttStatus
    }

type [<Erase>] GanttMarker =
    {
        id : string
        date : JS.Date
        label : string
    }

[<StringEnum>]
type [<Erase>] Range =
    | Daily
    | Monthly
    | Quarterly

type [<Erase>] TimelineData =
    {
        years : int
        quarters : {| months : {| days : int |} list |} list
    }

type [<Erase>] GanttContext =
    {
        zoom : int
        range : Range
        columnWidth : int
        sidebarWidth : int
        headerHeight : int
        rowHeight : int
        onAddItem : JS.Date -> unit
        placeholderLength : int
        timelineData : TimelineData
        ref : IRefValue<Browser.Types.HTMLElement>
    }
    
let private getsDaysIn = JSX.jsx """
(range) => {
  // For when range is daily
  let fn = (_date) => 1;

  if (range === 'monthly' || range === 'quarterly') {
    fn = getDaysInMonth;
  }

  return fn;
}
"""

let private getDifferenceIn = JSX.jsx """
(range) => {
  let fn = differenceInDays;

  if (range === 'monthly' || range === 'quarterly') {
    fn = differenceInMonths;
  }
  return fn;
}"""

let private getInnerDifferenceIn = JSX.jsx """
(range) => {
  let fn = differenceInHours;

  if (range === 'monthly' || range === 'quarterly') {
    fn = differenceInDays;
  }

  return fn;
}"""

let private getStartOf = JSX.jsx """
(range) => {
  let fn = startOfDay;

  if (range === 'monthly' || range === 'quarterly') {
    fn = startOfMonth;
  }

  return fn;
}
"""

let private getEndOf = JSX.jsx """
(range) => {
  let fn = endOfDay;

  if (range === 'monthly' || range === 'quarterly') {
    fn = endOfMonth;
  }

  return fn;
}"""

let private getAddRange = JSX.jsx """
(range) => {
  let fn = addDays;

  if (range === 'monthly' || range === 'quarterly') {
    fn = addMonths;
  }

  return fn;
}"""

let private getDateByMousePosition = JSX.jsx """
(context, mouseX) => {
  const timelineStartDate = new Date(context.timelineData[0].year, 0, 1);
  const columnWidth = (context.columnWidth * context.zoom) / 100;
  const offset = Math.floor(mouseX / columnWidth);
  const daysIn = getsDaysIn(context.range);
  const addRange = getAddRange(context.range);
  const month = addRange(timelineStartDate, offset);
  const daysInMonth = daysIn(month);
  const pixelsPerDay = Math.round(columnWidth / daysInMonth);
  const dayOffset = Math.floor((mouseX % columnWidth) / pixelsPerDay);
  const actualDate = addDays(month, dayOffset);

  return actualDate;
}"""

let private createInitialTimelineData = JSX.jsx """
(today) => {
  const data = [];

  data.push(
    { year: today.getFullYear() - 1, quarters: new Array(4).fill(null) },
    { year: today.getFullYear(), quarters: new Array(4).fill(null) },
    { year: today.getFullYear() + 1, quarters: new Array(4).fill(null) }
  );

  for (const yearObj of data) {
    yearObj.quarters = new Array(4).fill(null).map((_, quarterIndex) => ({
      months: new Array(3).fill(null).map((_, monthIndex) => {
        const month = quarterIndex * 3 + monthIndex;
        return {
          days: getDaysInMonth(new Date(yearObj.year, month, 1)),
        };
      }),
    }));
  }

  return data;
}
"""

let private getOffset = JSX.jsx """
(
  date,
  timelineStartDate,
  context
) => {
  const parsedColumnWidth = (context.columnWidth * context.zoom) / 100;
  const differenceIn = getDifferenceIn(context.range);
  const startOf = getStartOf(context.range);
  const fullColumns = differenceIn(startOf(date), timelineStartDate);

  if (context.range === 'daily') {
    return parsedColumnWidth * fullColumns;
  }

  const partialColumns = date.getDate();
  const daysInMonth = getDaysInMonth(date);
  const pixelsPerDay = parsedColumnWidth / daysInMonth;

  return fullColumns * parsedColumnWidth + partialColumns * pixelsPerDay;
}"""

let private getWidth = JSX.jsx """
(
  startAt,
  endAt,
  context
) => {
  const parsedColumnWidth = (context.columnWidth * context.zoom) / 100;

  if (!endAt) {
    return parsedColumnWidth * 2;
  }

  const differenceIn = getDifferenceIn(context.range);

  if (context.range === 'daily') {
    const delta = differenceIn(endAt, startAt);

    return parsedColumnWidth * (delta ? delta : 1);
  }

  const daysInStartMonth = getDaysInMonth(startAt);
  const pixelsPerDayInStartMonth = parsedColumnWidth / daysInStartMonth;

  if (isSameDay(startAt, endAt)) {
    return pixelsPerDayInStartMonth;
  }

  const innerDifferenceIn = getInnerDifferenceIn(context.range);
  const startOf = getStartOf(context.range);

  if (isSameDay(startOf(startAt), startOf(endAt))) {
    return innerDifferenceIn(endAt, startAt) * pixelsPerDayInStartMonth;
  }

  const startRangeOffset = daysInStartMonth - getDate(startAt);
  const endRangeOffset = getDate(endAt);
  const fullRangeOffset = differenceIn(startOf(endAt), startOf(startAt));
  const daysInEndMonth = getDaysInMonth(endAt);
  const pixelsPerDayInEndMonth = parsedColumnWidth / daysInEndMonth;

  return (
    (fullRangeOffset - 1) * parsedColumnWidth +
    startRangeOffset * pixelsPerDayInStartMonth +
    endRangeOffset * pixelsPerDayInEndMonth
  );
}
"""

let private calculateInnerOffset = JSX.jsx """
(
  date,
  range,
  columnWidth
) => {
  const startOf = getStartOf(range);
  const endOf = getEndOf(range);
  const differenceIn = getInnerDifferenceIn(range);
  const startOfRange = startOf(date);
  const endOfRange = endOf(date);
  const totalRangeDays = differenceIn(endOfRange, startOfRange);
  const dayOfMonth = date.getDate();

  return (dayOfMonth / totalRangeDays) * columnWidth;
}
"""

let private GanttContext : IContext<GanttContext> = unbox <| JSX.jsx """
createContext({
  zoom: 100,
  range: 'monthly',
  columnWidth: 50,
  headerHeight: 60,
  sidebarWidth: 300,
  rowHeight: 36,
  onAddItem: undefined,
  placeholderLength: 2,
  timelineData: [],
  ref: null,
})
"""

// --------------- GanttContentHeader -------------- //
type [<Erase>] IGanttContentHeaderProp = interface end
type [<Erase>] ganttContentHeader =
    inherit prop<IGanttContentHeaderProp>
    static member inline title ( value : string ) : IGanttContentHeaderProp = Interop.mkProperty "title" value
    static member inline renderHeaderItem ( handler : int -> unit ) : IGanttContentHeaderProp = Interop.mkProperty "renderHeaderItem" handler
    static member inline columns ( value : int ) : IGanttContentHeaderProp = Interop.mkProperty "columns" value

let GanttContentHeader : JSX.ElementType = JSX.jsx """
({
  title,
  columns,
  renderHeaderItem,
}) => {
  const id = useId();

  return (
    (<div
      className="sticky top-0 z-20 grid w-full shrink-0 bg-backdrop/90 backdrop-blur-sm"
      style={{ height: 'var(--gantt-header-height)' }}>
      <div>
        <div
          className="sticky inline-flex whitespace-nowrap px-3 py-2 text-muted-foreground text-xs"
          style={{
            left: 'var(--gantt-sidebar-width)',
          }}>
          <p>{title}</p>
        </div>
      </div>
      <div
        className="grid w-full"
        style={{
          gridTemplateColumns: `repeat(${columns}, var(--gantt-column-width))`,
        }}>
        {Array.from({ length: columns }).map((_, index) => (
          <div
            key={`${id}-${index}`}
            className="shrink-0 border-border/50 border-b py-1 text-center text-xs">
            {renderHeaderItem(index)}
          </div>
        ))}
      </div>
    </div>)
  );
}
"""

let private DailyHeader = JSX.jsx """
() => {
  const gantt = useContext(GanttContext);

  return gantt.timelineData.map((year) =>
    year.quarters
      .flatMap((quarter) => quarter.months)
      .map((month, index) => (
        <div className="relative flex flex-col" key={`${year.year}-${index}`}>
          <GanttContentHeader
            title={format(new Date(year.year, index, 1), 'MMMM yyyy')}
            columns={month.days}
            renderHeaderItem={(item) => (
              <div className="flex items-center justify-center gap-1">
                <p>
                  {format(addDays(new Date(year.year, index, 1), item), 'd')}
                </p>
                <p className="text-muted-foreground">
                  {format(addDays(new Date(year.year, index, 1), item), 'EEEEE')}
                </p>
              </div>
            )} />
          <GanttColumns
            columns={month.days}
            isColumnSecondary={(item) =>
              [0, 6].includes(addDays(new Date(year.year, index, 1), item).getDay())
            } />
        </div>
      )));
}
"""

let private MonthlyHeader = JSX.jsx """
() => {
  const gantt = useContext(GanttContext);

  return gantt.timelineData.map((year) => (
    <div className="relative flex flex-col" key={year.year}>
      <GanttContentHeader
        title={`${year.year}`}
        columns={year.quarters.flatMap((quarter) => quarter.months).length}
        renderHeaderItem={(item) => (
          <p>{format(new Date(year.year, item, 1), 'MMM')}</p>
        )} />
      <GanttColumns columns={year.quarters.flatMap((quarter) => quarter.months).length} />
    </div>
  ));
}
"""

let private QuarterlyHeader = JSX.jsx """
() => {
  const gantt = useContext(GanttContext);

  return gantt.timelineData.map((year) =>
    year.quarters.map((quarter, quarterIndex) => (
      <div className="relative flex flex-col" key={`${year.year}-${quarterIndex}`}>
        <GanttContentHeader
          title={`Q${quarterIndex + 1} ${year.year}`}
          columns={quarter.months.length}
          renderHeaderItem={(item) => (
            <p>
              {format(new Date(year.year, quarterIndex * 3 + item, 1), 'MMM')}
            </p>
          )} />
        <GanttColumns columns={quarter.months.length} />
      </div>
    )));
}
"""

let private headers = {|
                        daily = DailyHeader
                        monthly = MonthlyHeader
                        quarterly = QuarterlyHeader
                        |}

// --------------- GanttHeader -------------- //
type [<Erase>] IGanttHeaderProp = interface end
type [<Erase>] ganttHeader =
    inherit prop<IGanttHeaderProp>
    static member inline private noop : unit = ()

let GanttHeader : JSX.ElementType = JSX.jsx """
({ className }) => {
  const gantt = useContext(GanttContext);
  const Header = headers[gantt.range];

  return (
    (<div
      className={cn('-space-x-px flex h-full w-max divide-x divide-border/50', className)}>
      <Header />
    </div>)
  );
}
"""

// --------------- GanttSidebarItem -------------- //
type [<Erase>] IGanttSidebarItemProp = interface end
type [<Erase>] ganttSidebarItem =
    inherit prop<IGanttSidebarItemProp>
    static member inline feature ( value : GanttFeature ) : IGanttSidebarItemProp = Interop.mkProperty "feature" value
    static member inline onSelectItem ( handler : string -> unit ) : IGanttSidebarItemProp = Interop.mkProperty "onSelectItem" handler

let GanttSidebarItem : JSX.ElementType = JSX.jsx """
({
  feature,
  onSelectItem,
  className,
}) => {
  const tempEndAt =
    feature.endAt && isSameDay(feature.startAt, feature.endAt)
      ? addDays(feature.endAt, 1)
      : feature.endAt;
  const duration = tempEndAt
    ? formatDistance(feature.startAt, tempEndAt)
    : `${formatDistance(feature.startAt, new Date())} so far`;

  const handleClick = (event) => {
    if (event.target === event.currentTarget) {
      onSelectItem(feature.id);
    }
  };

  const handleKeyDown = (event) => {
    if (event.key === 'Enter') {
      onSelectItem(feature.id);
    }
  };

  return (
    (<div
      // biome-ignore lint/a11y/useSemanticElements: <explanation>
      role="button"
      onClick={handleClick}
      onKeyDown={handleKeyDown}
      tabIndex={0}
      key={feature.id}
      className={cn('relative flex items-center gap-2.5 p-2.5 text-xs', className)}
      style={{
        height: 'var(--gantt-row-height)',
      }}>
      {/* <Checkbox onCheckedChange={handleCheck} className="shrink-0" /> */}
      <div
        className="pointer-events-none h-2 w-2 shrink-0 rounded-full"
        style={{
          backgroundColor: feature.status.color,
        }} />
      <p className="pointer-events-none flex-1 truncate text-left font-medium">
        {feature.name}
      </p>
      <p className="pointer-events-none text-muted-foreground">{duration}</p>
    </div>)
  );
}
"""

// --------------- GanttSidebarHeader -------------- //
type [<Erase>] IGanttSidebarHeaderProp = interface end
type [<Erase>] ganttSidebarHeader =
    inherit prop<IGanttSidebarHeaderProp>
    static member inline private noop : unit = ()

let GanttSidebarHeader : JSX.ElementType = JSX.jsx """
() => (
  <div
    className="sticky top-0 z-10 flex shrink-0 items-end justify-between gap-2.5 border-border/50 border-b bg-backdrop/90 p-2.5 font-medium text-muted-foreground text-xs backdrop-blur-sm"
    style={{ height: 'var(--gantt-header-height)' }}>
    {/* <Checkbox className="shrink-0" /> */}
    <p className="flex-1 truncate text-left">Issues</p>
    <p className="shrink-0">Duration</p>
  </div>
)
"""

// --------------- GanttSidebarGroup -------------- //
type [<Erase>] IGanttSidebarGroupProp = interface end
type [<Erase>] ganttSidebarGroup =
    inherit prop<IGanttSidebarGroupProp>
    static member inline name ( value : string ) : IGanttSidebarGroupProp = Interop.mkProperty "name" value

let GanttSidebarGroup : JSX.ElementType = JSX.jsx """
({
  children,
  name,
  className,
}) => (
  <div className={className}>
    <p
      style={{ height: 'var(--gantt-row-height)' }}
      className="w-full truncate p-2.5 text-left font-medium text-muted-foreground text-xs">
      {name}
    </p>
    <div className="divide-y divide-border/50">{children}</div>
  </div>
)
"""

// --------------- GanttSidebar -------------- //
type [<Erase>] IGanttSidebarProp = interface end
type [<Erase>] ganttSidebar =
    inherit prop<IGanttSidebarProp>
    static member inline private noop : unit = ()

let GanttSidebar : JSX.ElementType = JSX.jsx """
({
  children,
  className,
}) => (
  <div
    data-roadmap-ui="gantt-sidebar"
    className={cn(
      'sticky left-0 z-30 h-max min-h-full overflow-clip border-border/50 border-r bg-background/90 backdrop-blur-md',
      className
    )}>
    <GanttSidebarHeader />
    <div className="space-y-4">{children}</div>
  </div>
)
"""

// --------------- GanttAddFeatureHelper -------------- //
type [<Erase>] IGanttAddFeatureHelperProp = interface end
type [<Erase>] ganttAddFeatureHelper =
    inherit prop<IGanttAddFeatureHelperProp>
    static member inline top ( value : int ) : IGanttAddFeatureHelperProp = Interop.mkProperty "top" value

let GanttAddFeatureHelper : JSX.ElementType = JSX.jsx """
({
  top,
  className,
}) => {
  const { scrollX } = useGantt();
  const gantt = useContext(GanttContext);
  const [mousePosition, mouseRef] = useMouse();

  const handleClick = () => {
    const ganttRect = gantt.ref?.current?.getBoundingClientRect();
    const x =
      mousePosition.x - (ganttRect?.left ?? 0) + scrollX - gantt.sidebarWidth;
    const currentDate = getDateByMousePosition(gantt, x);

    gantt.onAddItem?.(currentDate);
  };

  return (
    (<div
      className={cn('absolute top-0 w-full px-0.5', className)}
      style={{
        marginTop: -gantt.rowHeight / 2,
        transform: `translateY(${top}px)`,
      }}
      ref={mouseRef}>
      <button
        onClick={handleClick}
        type="button"
        className="flex h-full w-full items-center justify-center rounded-md border border-dashed p-2">
        <PlusIcon
          size={16}
          className="pointer-events-none select-none text-muted-foreground" />
      </button>
    </div>)
  );
}
"""

// --------------- GanttColumn -------------- //
type [<Erase>] IGanttColumnProp = interface end
type [<Erase>] ganttColumn =
    inherit prop<IGanttColumnProp>
    static member inline index ( value : int ) : IGanttColumnProp = Interop.mkProperty "index" value
    static member inline isColumnSecondary ( handler : int -> bool ) : IGanttColumnProp = Interop.mkProperty "isColumnSecondary" handler

let GanttColumn : JSX.ElementType = JSX.jsx """
({
  index,
  isColumnSecondary,
}) => {
  const gantt = useContext(GanttContext);
  const { dragging } = useGantt();
  const [mousePosition, mouseRef] = useMouse();
  const [hovering, setHovering] = useState(false);
  const [windowScroll] = useWindowScroll();

  const handleMouseEnter = () => setHovering(true);
  const handleMouseLeave = () => setHovering(false);

  const top = useThrottle(mousePosition.y -
    (mouseRef.current?.getBoundingClientRect().y ?? 0) -
    (windowScroll.y ?? 0), 10);

  return (
    // biome-ignore lint/nursery/noStaticElementInteractions: <explanation>
    (<div
      className={cn(
        'group relative h-full overflow-hidden',
        isColumnSecondary?.(index) ? 'bg-secondary' : ''
      )}
      ref={mouseRef}
      onMouseEnter={handleMouseEnter}
      onMouseLeave={handleMouseLeave}>
      {!dragging && hovering && gantt.onAddItem ? (
        <GanttAddFeatureHelper top={top} />
      ) : null}
    </div>)
  );
}
"""

// --------------- GanttColumns -------------- //
type [<Erase>] IGanttColumnsProp = interface end
type [<Erase>] ganttColumns =
    inherit prop<IGanttColumnsProp>
    static member inline index ( value : int ) : IGanttColumnsProp = Interop.mkProperty "index" value
    static member inline isColumnSecondary ( handler : int -> bool ) : IGanttColumnsProp = Interop.mkProperty "isColumnSecondary" handler

let GanttColumns : JSX.ElementType = JSX.jsx """
({
  columns,
  isColumnSecondary,
}) => {
  const id = useId();

  return (
    (<div
      className="divide grid h-full w-full divide-x divide-border/50"
      style={{
        gridTemplateColumns: `repeat(${columns}, var(--gantt-column-width))`,
      }}>
      {Array.from({ length: columns }).map((_, index) => (
        <GanttColumn
          key={`${id}-${index}`}
          index={index}
          isColumnSecondary={isColumnSecondary} />
      ))}
    </div>)
  );
}
"""

// --------------- GanttCreateMarkerTrigger -------------- //
type [<Erase>] IGanttCreateMarkerTriggerProp = interface end
type [<Erase>] ganttCreateMarkerTrigger =
    inherit prop<IGanttCreateMarkerTriggerProp>
    static member inline onCreateMarker ( handler : JS.Date -> unit ) : IGanttCreateMarkerTriggerProp = Interop.mkProperty "onCreateMarker" handler

let GanttCreateMarkerTrigger : JSX.ElementType = JSX.jsx """
({
  onCreateMarker,
  className,
}) => {
  const gantt = useContext(GanttContext);
  const [mousePosition, mouseRef] = useMouse();
  const [windowScroll] = useWindowScroll();
  const x = useThrottle(mousePosition.x -
    (mouseRef.current?.getBoundingClientRect().x ?? 0) -
    (windowScroll.x ?? 0), 10);

  const date = getDateByMousePosition(gantt, x);

  const handleClick = () => onCreateMarker(date);

  return (
    (<div
      className={cn(
        'group pointer-events-none absolute top-0 left-0 h-full w-full select-none overflow-visible',
        className
      )}
      ref={mouseRef}>
      <div
        className="-ml-2 pointer-events-auto sticky top-6 z-20 flex w-4 flex-col items-center justify-center gap-1 overflow-visible opacity-0 group-hover:opacity-100"
        style={{ transform: `translateX(${x}px)` }}>
        <button
          type="button"
          className="z-50 inline-flex h-4 w-4 items-center justify-center rounded-full bg-card"
          onClick={handleClick}>
          <PlusIcon size={12} className="text-muted-foreground" />
        </button>
        <div
          className="whitespace-nowrap rounded-full border border-border/50 bg-background/90 px-2 py-1 text-foreground text-xs backdrop-blur-lg">
          {formatDate(date, 'MMM dd, yyyy')}
        </div>
      </div>
    </div>)
  );
}
"""

// --------------- GanttFeatureDragHelper -------------- //
type [<Erase>] IGanttFeatureDragHelperProp = interface end
type [<Erase>] ganttFeatureDragHelper =
    inherit prop<IGanttFeatureDragHelperProp>
    static member inline featureId ( value : string ) : IGanttFeatureDragHelperProp = Interop.mkProperty "featureId" value
    static member inline date ( value : JS.Date ) : IGanttFeatureDragHelperProp = Interop.mkProperty "date" value
    
[<RequireQualifiedAccess>]
module [<Erase>] ganttFeatureDragHelper =
    type [<Erase>] direction =
        static member inline left : IGanttFeatureDragHelperProp = Interop.mkProperty "direction" "left"
        static member inline right : IGanttFeatureDragHelperProp = Interop.mkProperty "direction" "right"

let GanttFeatureDragHelper : JSX.ElementType = JSX.jsx """
({
  direction,
  featureId,
  date,
}) => {
  const { setDragging } = useGantt();
  const { attributes, listeners, setNodeRef } = useDraggable({
    id: `feature-drag-helper-${featureId}`,
  });

  const isPressed = Boolean(attributes['aria-pressed']);

  useEffect(() => setDragging(isPressed), [isPressed, setDragging]);

  return (
    (<div
      className={cn(
        'group -translate-y-1/2 !cursor-col-resize absolute top-1/2 z-[3] h-full w-6 rounded-md outline-none',
        direction === 'left' ? '-left-2.5' : '-right-2.5'
      )}
      ref={setNodeRef}
      {...attributes}
      {...listeners}>
      <div
        className={cn(
          '-translate-y-1/2 absolute top-1/2 h-[80%] w-1 rounded-sm bg-muted-foreground opacity-0 transition-all',
          direction === 'left' ? 'left-2.5' : 'right-2.5',
          direction === 'left' ? 'group-hover:left-0' : 'group-hover:right-0',
          isPressed && (direction === 'left' ? 'left-0' : 'right-0'),
          'group-hover:opacity-100',
          isPressed && 'opacity-100'
        )} />
      {date && (
        <div
          className={cn(
            '-translate-x-1/2 absolute top-10 hidden whitespace-nowrap rounded-lg border border-border/50 bg-background/90 px-2 py-1 text-foreground text-xs backdrop-blur-lg group-hover:block',
            isPressed && 'block'
          )}>
          {format(date, 'MMM dd, yyyy')}
        </div>
      )}
    </div>)
  );
}
"""

// --------------- GanttFeatureItemCard -------------- //
type [<Erase>] IGanttFeatureItemCardProp = interface end
type [<Erase>] ganttFeatureItemCard =
    inherit prop<IGanttFeatureItemCardProp>
    static member inline id ( value : string ) : IGanttFeatureItemCardProp = Interop.mkProperty "id" value
    static member inline name ( value : string ) : IGanttFeatureItemCardProp = Interop.mkProperty "name" value
    static member inline color ( value : string ) : IGanttFeatureItemCardProp = Interop.mkProperty "color" value


let GanttFeatureItemCard : JSX.ElementType = JSX.jsx """
({
  id,
  children,
}) => {
  const { setDragging } = useGantt();
  const { attributes, listeners, setNodeRef } = useDraggable({ id });
  const isPressed = Boolean(attributes['aria-pressed']);

  useEffect(() => setDragging(isPressed), [isPressed, setDragging]);

  return (
    (<Card className="h-full w-full rounded-md bg-background p-2 text-xs shadow-sm">
      <div
        className={cn(
          'flex h-full w-full items-center justify-between gap-2 text-left',
          isPressed && 'cursor-grabbing'
        )}
        {...attributes}
        {...listeners}
        ref={setNodeRef}>
        {children}
      </div>
    </Card>)
  );
}
"""

// --------------- GanttFeatureItem -------------- //
type [<Erase>] IGanttFeatureItemProp = interface end
type [<Erase>] ganttFeatureItem =
    inherit prop<IGanttFeatureItemProp>
    static member inline onMove ( handler : string * JS.Date * JS.Date -> unit ) : IGanttFeatureItemProp = Interop.mkProperty "onMove" handler
    static member inline id ( value : string ) : IGanttFeatureItemProp = Interop.mkProperty "id" value
    static member inline name ( value : string ) : IGanttFeatureItemProp = Interop.mkProperty "name" value
    static member inline color ( value : string ) : IGanttFeatureItemProp = Interop.mkProperty "color" value

let GanttFeatureItem : JSX.ElementType = JSX.jsx """
({
  onMove,
  children,
  className,
  ...feature
}) => {
  const { scrollX } = useGantt();
  const gantt = useContext(GanttContext);
  const timelineStartDate = new Date(gantt.timelineData.at(0)?.year ?? 0, 0, 1);
  const [startAt, setStartAt] = useState(feature.startAt);
  const [endAt, setEndAt] = useState(feature.endAt);
  const width = getWidth(startAt, endAt, gantt);
  const offset = getOffset(startAt, timelineStartDate, gantt);
  const addRange = getAddRange(gantt.range);
  const [mousePosition] = useMouse();

  const [previousMouseX, setPreviousMouseX] = useState(0);
  const [previousStartAt, setPreviousStartAt] = useState(startAt);
  const [previousEndAt, setPreviousEndAt] = useState(endAt);

  const mouseSensor = useSensor(MouseSensor, {
    activationConstraint: {
      distance: 10,
    },
  });

  const handleItemDragStart = () => {
    setPreviousMouseX(mousePosition.x);
    setPreviousStartAt(startAt);
    setPreviousEndAt(endAt);
  };

  const handleItemDragMove = () => {
    const currentDate = getDateByMousePosition(gantt, mousePosition.x);
    const originalDate = getDateByMousePosition(gantt, previousMouseX);
    const delta =
      gantt.range === 'daily'
        ? getDifferenceIn(gantt.range)(currentDate, originalDate)
        : getInnerDifferenceIn(gantt.range)(currentDate, originalDate);
    const newStartDate = addDays(previousStartAt, delta);
    const newEndDate = previousEndAt ? addDays(previousEndAt, delta) : null;

    setStartAt(newStartDate);
    setEndAt(newEndDate);
  };

  const onDragEnd = () => onMove?.(feature.id, startAt, endAt);
  const handleLeftDragMove = () => {
    const ganttRect = gantt.ref?.current?.getBoundingClientRect();
    const x =
      mousePosition.x - (ganttRect?.left ?? 0) + scrollX - gantt.sidebarWidth;
    const newStartAt = getDateByMousePosition(gantt, x);

    setStartAt(newStartAt);
  };
  const handleRightDragMove = () => {
    const ganttRect = gantt.ref?.current?.getBoundingClientRect();
    const x =
      mousePosition.x - (ganttRect?.left ?? 0) + scrollX - gantt.sidebarWidth;
    const newEndAt = getDateByMousePosition(gantt, x);

    setEndAt(newEndAt);
  };

  return (
    (<div
      className={cn('relative flex w-max min-w-full py-0.5', className)}
      style={{ height: 'var(--gantt-row-height)' }}>
      <div
        className="pointer-events-auto absolute top-0.5"
        style={{
          height: 'calc(var(--gantt-row-height) - 4px)',
          width: Math.round(width),
          left: Math.round(offset),
        }}>
        {onMove && (
          <DndContext
            sensors={[mouseSensor]}
            modifiers={[restrictToHorizontalAxis]}
            onDragMove={handleLeftDragMove}
            onDragEnd={onDragEnd}>
            <GanttFeatureDragHelper direction="left" featureId={feature.id} date={startAt} />
          </DndContext>
        )}
        <DndContext
          sensors={[mouseSensor]}
          modifiers={[restrictToHorizontalAxis]}
          onDragStart={handleItemDragStart}
          onDragMove={handleItemDragMove}
          onDragEnd={onDragEnd}>
          <GanttFeatureItemCard id={feature.id}>
            {children ?? (
              <p className="flex-1 truncate text-xs">{feature.name}</p>
            )}
          </GanttFeatureItemCard>
        </DndContext>
        {onMove && (
          <DndContext
            sensors={[mouseSensor]}
            modifiers={[restrictToHorizontalAxis]}
            onDragMove={handleRightDragMove}
            onDragEnd={onDragEnd}>
            <GanttFeatureDragHelper
              direction="right"
              featureId={feature.id}
              date={endAt ?? addRange(startAt, 2)} />
          </DndContext>
        )}
      </div>
    </div>)
  );
}
"""

// --------------- GanttFeatureListGroup -------------- //
type [<Erase>] IGanttFeatureListGroupProp = interface end
type [<Erase>] ganttFeatureListGroup =
    inherit prop<IGanttFeatureListGroupProp>
    static member inline private noop : unit = ()

let GanttFeatureListGroup : JSX.ElementType = JSX.jsx """
({
  children,
  className,
}) => (
  <div className={className} style={{ paddingTop: 'var(--gantt-row-height)' }}>
    {children}
  </div>
)
"""

// --------------- GanttFeatureList -------------- //
type [<Erase>] IGanttFeatureListProp = interface end
type [<Erase>] ganttFeatureList =
    inherit prop<IGanttFeatureListProp>
    static member inline private noop : unit = ()

let GanttFeatureList : JSX.ElementType = JSX.jsx """
({
  className,
  children,
}) => (
  <div
    className={cn('absolute top-0 left-0 h-full w-max space-y-4', className)}
    style={{ marginTop: 'var(--gantt-header-height)' }}>
    {children}
  </div>
)
"""

// --------------- GanttMarker -------------- //
type [<Erase>] IGanttMarkerProp = interface end
type [<Erase>] ganttMarker =
    inherit prop<IGanttMarkerProp>
    static member inline onRemove ( handler : string -> unit ) : IGanttMarkerProp = Interop.mkProperty "onRemove" handler
    static member inline id ( value : string ) : IGanttMarkerProp = Interop.mkProperty "id" value
    static member inline date ( value : JS.Date ) : IGanttMarkerProp = Interop.mkProperty "date" value
    static member inline label ( value : string ) : IGanttMarkerProp = Interop.mkProperty "label" value
    
let GanttMarker : JSX.ElementType = JSX.jsx """
({ label, date, id, onRemove, className }) => {
  const gantt = useContext(GanttContext);
  const differenceIn = getDifferenceIn(gantt.range);
  const timelineStartDate = new Date(gantt.timelineData.at(0)?.year ?? 0, 0, 1);
  const offset = differenceIn(date, timelineStartDate);
  const innerOffset = calculateInnerOffset(date, gantt.range, (gantt.columnWidth * gantt.zoom) / 100);
  const handleRemove = () => onRemove?.(id);

  return (
    (<div
      className="pointer-events-none absolute top-0 left-0 z-20 flex h-full select-none flex-col items-center justify-center overflow-visible"
      style={{
        width: 0,
        transform: `translateX(calc(var(--gantt-column-width) * ${offset} + ${innerOffset}px))`,
      }}>
      <ContextMenu>
        <ContextMenuTrigger asChild>
          <div
            className={cn(
              'group pointer-events-auto sticky top-0 flex select-auto flex-col flex-nowrap items-center justify-center whitespace-nowrap rounded-b-md bg-card px-2 py-1 text-foreground text-xs',
              className
            )}>
            {label}
            <span
              className="max-h-[0] overflow-hidden opacity-80 transition-all group-hover:max-h-[2rem]">
              {formatDate(date, 'MMM dd, yyyy')}
            </span>
          </div>
        </ContextMenuTrigger>
        <ContextMenuContent>
          {onRemove ? (
            <ContextMenuItem
              className="flex items-center gap-2 text-destructive"
              onClick={handleRemove}>
              <TrashIcon size={16} />
              Remove marker
            </ContextMenuItem>
          ) : null}
        </ContextMenuContent>
      </ContextMenu>
      <div className={cn('h-full w-px bg-card', className)} />
    </div>)
  );
}
"""

// --------------- GanttProvider -------------- //
type [<Erase>] IGanttProviderProp = interface end
type [<Erase>] ganttProvider =
    inherit prop<IGanttProviderProp>
    static member inline range ( value : Range ) : IGanttProviderProp = Interop.mkProperty "range" value
    static member inline zoom ( value : int ) : IGanttProviderProp = Interop.mkProperty "zoom" value
    static member inline onAddItem ( handler : JS.Date -> unit ) : IGanttProviderProp = Interop.mkProperty "onAddItem" handler

let GanttProvider : JSX.ElementType = JSX.jsx """
({
  zoom = 100,
  range = 'monthly',
  onAddItem,
  children,
  className,
}) => {
  const scrollRef = useRef(null);
  const [timelineData, setTimelineData] = useState(createInitialTimelineData(new Date()));
  const { setScrollX } = useGantt();
  const sidebarElement = scrollRef.current?.querySelector('[data-roadmap-ui="gantt-sidebar"]');

  const headerHeight = 60;
  const sidebarWidth = sidebarElement ? 300 : 0;
  const rowHeight = 36;
  let columnWidth = 50;

  if (range === 'monthly') {
    columnWidth = 150;
  } else if (range === 'quarterly') {
    columnWidth = 100;
  }

  const cssVariables = {
    '--gantt-zoom': `${zoom}`,
    '--gantt-column-width': `${(zoom / 100) * columnWidth}px`,
    '--gantt-header-height': `${headerHeight}px`,
    '--gantt-row-height': `${rowHeight}px`,
    '--gantt-sidebar-width': `${sidebarWidth}px`
  };

  // biome-ignore lint/correctness/useExhaustiveDependencies: Re-render when props change
  useEffect(() => {
    if (scrollRef.current) {
      scrollRef.current.scrollLeft =
        scrollRef.current.scrollWidth / 2 - scrollRef.current.clientWidth / 2;
      setScrollX(scrollRef.current.scrollLeft);
    }
  }, [range, zoom, setScrollX]);

  // biome-ignore lint/correctness/useExhaustiveDependencies: "Throttled"
  const handleScroll = useCallback(throttle(() => {
    if (!scrollRef.current) {
      return;
    }

    const { scrollLeft, scrollWidth, clientWidth } = scrollRef.current;
    setScrollX(scrollLeft);

    if (scrollLeft === 0) {
      // Extend timelineData to the past
      const firstYear = timelineData[0]?.year;

      if (!firstYear) {
        return;
      }

      const newTimelineData = [...timelineData];
      newTimelineData.unshift({
        year: firstYear - 1,
        quarters: new Array(4).fill(null).map((_, quarterIndex) => ({
          months: new Array(3).fill(null).map((_, monthIndex) => {
            const month = quarterIndex * 3 + monthIndex;
            return {
              days: getDaysInMonth(new Date(firstYear, month, 1)),
            };
          }),
        })),
      });

      setTimelineData(newTimelineData);

      // Scroll a bit forward so it's not at the very start
      scrollRef.current.scrollLeft = scrollRef.current.clientWidth;
      setScrollX(scrollRef.current.scrollLeft);
    } else if (scrollLeft + clientWidth >= scrollWidth) {
      // Extend timelineData to the future
      const lastYear = timelineData.at(-1)?.year;

      if (!lastYear) {
        return;
      }

      const newTimelineData = [...timelineData];
      newTimelineData.push({
        year: lastYear + 1,
        quarters: new Array(4).fill(null).map((_, quarterIndex) => ({
          months: new Array(3).fill(null).map((_, monthIndex) => {
            const month = quarterIndex * 3 + monthIndex;
            return {
              days: getDaysInMonth(new Date(lastYear, month, 1)),
            };
          }),
        })),
      });

      setTimelineData(newTimelineData);

      // Scroll a bit back so it's not at the very end
      scrollRef.current.scrollLeft =
        scrollRef.current.scrollWidth - scrollRef.current.clientWidth;
      setScrollX(scrollRef.current.scrollLeft);
    }
  }, 100), [timelineData, setScrollX]);

  useEffect(() => {
    if (scrollRef.current) {
      scrollRef.current.addEventListener('scroll', handleScroll);
    }

    return () => {
      if (scrollRef.current) {
        scrollRef.current.removeEventListener('scroll', handleScroll);
      }
    };
  }, [handleScroll]);

  return (
    (<GanttContext.Provider
      value={{
        zoom,
        range,
        headerHeight,
        columnWidth,
        sidebarWidth,
        rowHeight,
        onAddItem,
        timelineData,
        placeholderLength: 2,
        ref: scrollRef,
      }}>
      <div
        className={cn(
          'gantt relative grid h-full w-full flex-none select-none overflow-auto rounded-sm bg-secondary',
          range,
          className
        )}
        style={{
          ...cssVariables,
          gridTemplateColumns: 'var(--gantt-sidebar-width) 1fr',
        }}
        ref={scrollRef}>
        {children}
      </div>
    </GanttContext.Provider>)
  );
}
"""

// --------------- GanttTimeline -------------- //
type [<Erase>] IGanttTimelineProp = interface end
type [<Erase>] ganttTimeline =
    inherit prop<IGanttTimelineProp>
    static member inline private noop : unit = ()

let GanttTimeline : JSX.ElementType = JSX.jsx """
({
  children,
  className,
}) => (
  <div
    className={cn('relative flex h-full w-max flex-none overflow-clip', className)}>
    {children}
  </div>
)
"""

// --------------- GanttToday -------------- //
type [<Erase>] IGanttTodayProp = interface end
type [<Erase>] ganttToday =
    inherit prop<IGanttTodayProp>
    static member inline private noop : unit = ()

let GanttToday : JSX.ElementType = JSX.jsx """
({ className }) => {
  const label = 'Today';
  const date = new Date();
  const gantt = useContext(GanttContext);
  const differenceIn = getDifferenceIn(gantt.range);
  const timelineStartDate = new Date(gantt.timelineData.at(0)?.year ?? 0, 0, 1);
  const offset = differenceIn(date, timelineStartDate);
  const innerOffset = calculateInnerOffset(date, gantt.range, (gantt.columnWidth * gantt.zoom) / 100);

  return (
    (<div
      className="pointer-events-none absolute top-0 left-0 z-20 flex h-full select-none flex-col items-center justify-center overflow-visible"
      style={{
        width: 0,
        transform: `translateX(calc(var(--gantt-column-width) * ${offset} + ${innerOffset}px))`,
      }}>
      <div
        className={cn(
          'group pointer-events-auto sticky top-0 flex select-auto flex-col flex-nowrap items-center justify-center whitespace-nowrap rounded-b-md bg-card px-2 py-1 text-foreground text-xs',
          className
        )}>
        {label}
        <span
          className="max-h-[0] overflow-hidden opacity-80 transition-all group-hover:max-h-[2rem]">
          {formatDate(date, 'MMM dd, yyyy')}
        </span>
      </div>
      <div className={cn('h-full w-px bg-card', className)} />
    </div>)
  );
}
"""

type [<Erase>] Shadcn =
    static member inline GanttAddFeatureHelper ( props : IGanttAddFeatureHelperProp list ) = JSX.createElement GanttAddFeatureHelper props
    static member inline GanttAddFeatureHelper ( children : ReactElement list ) = JSX.createElementWithChildren GanttAddFeatureHelper children
    static member inline GanttColumn ( props : IGanttColumnProp list ) = JSX.createElement GanttColumn props
    static member inline GanttColumn ( children : ReactElement list ) = JSX.createElementWithChildren GanttColumn children
    static member inline GanttColumns ( props : IGanttColumnsProp list ) = JSX.createElement GanttColumns props
    static member inline GanttColumns ( children : ReactElement list ) = JSX.createElementWithChildren GanttColumns children
    static member inline GanttContentHeader ( props : IGanttContentHeaderProp list ) = JSX.createElement GanttContentHeader props
    static member inline GanttContentHeader ( children : ReactElement list ) = JSX.createElementWithChildren GanttContentHeader children
    /// The <c>GanttCreateMarkerTrigger</c> component is a button that triggers the creation of a new marker.
    static member inline GanttCreateMarkerTrigger ( props : IGanttCreateMarkerTriggerProp list ) = JSX.createElement GanttCreateMarkerTrigger props
    /// The <c>GanttCreateMarkerTrigger</c> component is a button that triggers the creation of a new marker.
    static member inline GanttCreateMarkerTrigger ( children : ReactElement list ) = JSX.createElementWithChildren GanttCreateMarkerTrigger children
    static member inline GanttFeatureDragHelper ( props : IGanttFeatureDragHelperProp list ) = JSX.createElement GanttFeatureDragHelper props
    static member inline GanttFeatureDragHelper ( children : ReactElement list ) = JSX.createElementWithChildren GanttFeatureDragHelper children
    /// The <c>GanttFeatureItem</c> component is a single feature in the Gantt chart.
    static member inline GanttFeatureItem ( props : IGanttFeatureItemProp list ) = JSX.createElement GanttFeatureItem props
    /// The <c>GanttFeatureItem</c> component is a single feature in the Gantt chart.
    static member inline GanttFeatureItem ( children : ReactElement list ) = JSX.createElementWithChildren GanttFeatureItem children
    static member inline GanttFeatureItemCard ( props : IGanttFeatureItemCardProp list ) = JSX.createElement GanttFeatureItemCard props
    static member inline GanttFeatureItemCard ( children : ReactElement list ) = JSX.createElementWithChildren GanttFeatureItemCard children
    /// The <c>GanttFeatureList</c> component is a container for the features in the Gantt chart.
    static member inline GanttFeatureList ( props : IGanttFeatureListProp list ) = JSX.createElement GanttFeatureList props
    /// The <c>GanttFeatureList</c> component is a container for the features in the Gantt chart.
    static member inline GanttFeatureList ( children : ReactElement list ) = JSX.createElementWithChildren GanttFeatureList children
    /// The <c>GanttFeatureListGroup</c> component is a container for a group of features in the Gantt chart.
    static member inline GanttFeatureListGroup ( props : IGanttFeatureListGroupProp list ) = JSX.createElement GanttFeatureListGroup props
    /// The <c>GanttFeatureListGroup</c> component is a container for a group of features in the Gantt chart.
    static member inline GanttFeatureListGroup ( children : ReactElement list ) = JSX.createElementWithChildren GanttFeatureListGroup children
    /// The <c>GanttHeader</c> component is the header of the Gantt chart.
    static member inline GanttHeader ( props : IGanttHeaderProp list ) = JSX.createElement GanttHeader props
    /// The <c>GanttHeader</c> component is the header of the Gantt chart.
    static member inline GanttHeader ( children : ReactElement list ) = JSX.createElementWithChildren GanttHeader children
    /// The <c>GanttMarker</c> component is a single marker in the Gantt chart.
    static member inline GanttMarker ( props : IGanttMarkerProp list ) = JSX.createElement GanttMarker props
    /// The <c>GanttMarker</c> component is a single marker in the Gantt chart.
    static member inline GanttMarker ( children : ReactElement list ) = JSX.createElementWithChildren GanttMarker children
    /// The <c>GanttProvider</c> component is the root component of the Gantt chart. It contains the drag-and-drop context and provides the necessary context for the other components.
    static member inline GanttProvider ( props : IGanttProviderProp list ) = JSX.createElement GanttProvider props
    /// The <c>GanttProvider</c> component is the root component of the Gantt chart. It contains the drag-and-drop context and provides the necessary context for the other components.
    static member inline GanttProvider ( children : ReactElement list ) = JSX.createElementWithChildren GanttProvider children
    /// The <c>GanttSidebar</c> component is a container for the sidebar in the Gantt chart.
    static member inline GanttSidebar ( props : IGanttSidebarProp list ) = JSX.createElement GanttSidebar props
    /// The <c>GanttSidebar</c> component is a container for the sidebar in the Gantt chart.
    static member inline GanttSidebar ( children : ReactElement list ) = JSX.createElementWithChildren GanttSidebar children
    /// The <c>GanttSidebarGroup</c> component is a container for a group of items in the sidebar.
    static member inline GanttSidebarGroup ( props : IGanttSidebarGroupProp list ) = JSX.createElement GanttSidebarGroup props
    /// The <c>GanttSidebarGroup</c> component is a container for a group of items in the sidebar.
    static member inline GanttSidebarGroup ( children : ReactElement list ) = JSX.createElementWithChildren GanttSidebarGroup children
    static member inline GanttSidebarHeader ( props : IGanttSidebarHeaderProp list ) = JSX.createElement GanttSidebarHeader props
    static member inline GanttSidebarHeader ( children : ReactElement list ) = JSX.createElementWithChildren GanttSidebarHeader children
    /// The <c>GanttSidebarItem</c> component is a single item in the sidebar.
    static member inline GanttSidebarItem ( props : IGanttSidebarItemProp list ) = JSX.createElement GanttSidebarItem props
    /// The <c>GanttSidebarItem</c> component is a single item in the sidebar.
    static member inline GanttSidebarItem ( children : ReactElement list ) = JSX.createElementWithChildren GanttSidebarItem children
    /// The <c>GanttTimeline</c> component is a container for the timeline in the Gantt chart.
    static member inline GanttTimeline ( props : IGanttTimelineProp list ) = JSX.createElement GanttTimeline props
    /// The <c>GanttTimeline</c> component is a container for the timeline in the Gantt chart.
    static member inline GanttTimeline ( children : ReactElement list ) = JSX.createElementWithChildren GanttTimeline children
    static member inline GanttToday ( props : IGanttTodayProp list ) = JSX.createElement GanttToday props
    static member inline GanttToday ( children : ReactElement list ) = JSX.createElementWithChildren GanttToday children
                                                                        