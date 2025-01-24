/// The calendar view displays features on a grid calendar. Specifically it shows the end date of each feature, and groups features by day.
[<AutoOpen>]
module Feliz.Shadcn.RoadmapUI.Calendar
// Features are grouped by day
// Features are color-coded by their status
// Features are truncated if there are too many to fit in the grid cell
// Selectable date range
// Pagination of dates
// Internationalization through locale prop

open Fable.React
open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz

JSX.injectShadcnLib

ignore <| JSX.jsx """
import { getDay, getDaysInMonth, isSameDay } from 'date-fns';
import { ChevronLeftIcon, ChevronRightIcon } from 'lucide-react';
import { Check, ChevronsUpDown } from 'lucide-react';
import { createContext, useContext, useState } from 'react';
import { create } from 'zustand';
import { devtools } from 'zustand/middleware';
"""

open Feliz.Shadcn

let private imports = (
    Button,
    Command,
    CommandEmpty,
    CommandGroup,
    CommandInput,
    CommandItem,
    CommandList,
    Popover,
    PopoverContent,
    PopoverTrigger
)

type [<Erase>] UseCalendar =
    {
        month : int
        year : int
        setMonth : int -> unit
        SetYear : int -> unit
    }

let useCalendar : unit -> UseCalendar = unbox <| JSX.jsx """
create()(devtools((set) => ({
  month: new Date().getMonth(),
  year: new Date().getFullYear(),
  setMonth: (month) => set(() => ({ month })),
  setYear: (year) => set(() => ({ year })),
})));
"""

type [<Erase>] CalendarContext =
    {
        local : string
        startDay : int
    }

let private CalendarContext : IContext<CalendarContext> = unbox <| JSX.jsx "createContext({local:'en-US',startDay=0})"

let monthsForLocale = ignore <| JSX.jsx """
(
  localeName,
  monthFormat = 'long'
) => {
  const format = new Intl.DateTimeFormat(localeName, { month: monthFormat })
    .format;

  return [...new Array(12).keys()].map((m) =>
    format(new Date(Date.UTC(2021, m % 12))));
}
"""

let daysForLocale = ignore <| JSX.jsx """
(locale, startDay) => {
  const weekdays = [];
  const baseDate = new Date(2024, 0, startDay);

  for (let i = 0; i < 7; i++) {
    weekdays.push(new Intl.DateTimeFormat(locale, { weekday: 'short' }).format(baseDate));
    baseDate.setDate(baseDate.getDate() + 1);
  }

  return weekdays;
}"""

// --------------- Combobox -------------- //
type [<Erase>] IComboboxProp = interface static member propsInterface : unit = () end
type [<Erase>] combobox =
    static member inline value ( value : string ) : IComboboxProp = Interop.mkProperty "value" value
    static member inline setValue ( handler : string -> unit ) : IComboboxProp = Interop.mkProperty "setValue" handler
    static member inline data ( value : {| value : string ; label : string |}[] ) : IComboboxProp = Interop.mkProperty "data" value
    static member inline labels ( value : {| button : string ; empty : string ; search : string |} ) : IComboboxProp = Interop.mkProperty "labels" value

let Combobox : JSX.ElementType = JSX.jsx """
({
  value,
  setValue,
  data,
  labels,
  className
}) => {
  const [open, setOpen] = useState(false);

  return (
    (<Popover open={open} onOpenChange={setOpen}>
      <PopoverTrigger asChild>
        <Button
          variant="outline"
          aria-expanded={open}
          className={cn('w-40 justify-between capitalize', className)}>
          {value
            ? data.find((item) => item.value === value)?.label
            : labels.button}
          <ChevronsUpDown className="ml-2 h-4 w-4 shrink-0 opacity-50" />
        </Button>
      </PopoverTrigger>
      <PopoverContent className="w-40 p-0">
        <Command
          filter={(value, search) => {
            const label = data.find((item) => item.value === value)?.label;

            return label?.toLowerCase().includes(search.toLowerCase()) ? 1 : 0;
          }}>
          <CommandInput placeholder={labels.search} />
          <CommandList>
            <CommandEmpty>{labels.empty}</CommandEmpty>
            <CommandGroup>
              {data.map((item) => (
                <CommandItem
                  key={item.value}
                  value={item.value}
                  onSelect={(currentValue) => {
                    setValue(currentValue === value ? '' : currentValue);
                    setOpen(false);
                  }}
                  className="capitalize">
                  <Check
                    className={cn('mr-2 h-4 w-4', value === item.value ? 'opacity-100' : 'opacity-0')} />
                  {item.label}
                </CommandItem>
              ))}
            </CommandGroup>
          </CommandList>
        </Command>
      </PopoverContent>
    </Popover>)
  );
}
"""

let private OutOfBoundsDay = ignore <| JSX.jsx """({
  day
}) => (
  <div
    className="relative h-full w-full bg-secondary p-1 text-muted-foreground text-xs">
    {day}
  </div>
)"""

type [<Erase>] Status =
    {
        id : string
        name : string
        color : string
    }

type [<Erase>] Feature =
    {
        id : string
        name : string
        startAt : JS.Date
        endAt : JS.Date
        status : Status
    }

// --------------- CalendarBody -------------- //
type [<Erase>] ICalendarBodyProp = interface static member propsInterface : unit = () end
type [<Erase>] calendarBody =
    static member inline features ( value : Feature list ) : ICalendarBodyProp = Interop.mkProperty "features" value
    static member inline children ( props : Feature -> ReactElement ) : ICalendarBodyProp = Interop.mkProperty "children" props

let CalendarBody : JSX.ElementType = JSX.jsx """
({
  features,
  children
}) => {
  const { month, year } = useCalendar();
  const { startDay } = useContext(CalendarContext);
  const daysInMonth = getDaysInMonth(new Date(year, month, 1));
  const firstDay = (getDay(new Date(year, month, 1)) - startDay + 7) % 7;
  const days = [];

  const prevMonth = month === 0 ? 11 : month - 1;
  const prevMonthYear = month === 0 ? year - 1 : year;
  const prevMonthDays = getDaysInMonth(new Date(prevMonthYear, prevMonth, 1));
  const prevMonthDaysArray = Array.from({ length: prevMonthDays }, (_, i) => i + 1);

  for (let i = 0; i < firstDay; i++) {
    const day = prevMonthDaysArray[prevMonthDays - firstDay + i];

    if (day) {
      days.push(<OutOfBoundsDay key={`prev-${i}`} day={day} />);
    }
  }

  for (let day = 1; day <= daysInMonth; day++) {
    const featuresForDay = features.filter((feature) => {
      return isSameDay(new Date(feature.endAt), new Date(year, month, day));
    });

    days.push(<div
      key={day}
      className="relative flex h-full w-full flex-col gap-1 p-1 text-muted-foreground text-xs">
      {day}
      <div>
        {featuresForDay.slice(0, 3).map((feature) => children({ feature }))}
      </div>
      {featuresForDay.length > 3 && (
        <span className="block text-muted-foreground text-xs">
          +{featuresForDay.length - 3} more
        </span>
      )}
    </div>);
  }

  const nextMonth = month === 11 ? 0 : month + 1;
  const nextMonthYear = month === 11 ? year + 1 : year;
  const nextMonthDays = getDaysInMonth(new Date(nextMonthYear, nextMonth, 1));
  const nextMonthDaysArray = Array.from({ length: nextMonthDays }, (_, i) => i + 1);

  const remainingDays = 7 - ((firstDay + daysInMonth) % 7);
  if (remainingDays < 7) {
    for (let i = 0; i < remainingDays; i++) {
      const day = nextMonthDaysArray[i];

      if (day) {
        days.push(<OutOfBoundsDay key={`next-${i}`} day={day} />);
      }
    }
  }

  return (
    (<div className="grid flex-grow grid-cols-7">
      {days.map((day, index) => (
        <div
          key={index}
          className={cn(
            'relative aspect-square overflow-hidden border-t border-r',
            index % 7 === 6 && 'border-r-0'
          )}>
          {day}
        </div>
      ))}
    </div>)
  );
}
"""

// --------------- CalendarDatePicker -------------- //
type [<Erase>] ICalendarDatePickerProp = interface static member propsInterface : unit = () end

let CalendarDatePicker : JSX.ElementType = JSX.jsx """
({
  className,
  children
}) => (
  <div className={cn('flex items-center gap-1', className)}>{children}</div>
)
"""

// --------------- CalendarMonthPicker -------------- //
type [<Erase>] ICalendarMonthPickerProp = interface static member propsInterface : unit = () end

let CalendarMonthPicker : JSX.ElementType = JSX.jsx """
({
  className
}) => {
  const { month, setMonth } = useCalendar();
  const { locale } = useContext(CalendarContext);

  return (
    (<Combobox
      className={className}
      value={month.toString()}
      setValue={(value) =>
        setMonth(Number.parseInt(value))
      }
      data={monthsForLocale(locale).map((month, index) => ({
        value: index.toString(),
        label: month,
      }))}
      labels={{
        button: 'Select month',
        empty: 'No month found',
        search: 'Search month',
      }} />)
  );
}
"""

// --------------- CalendarYearPicker -------------- //
type [<Erase>] ICalendarYearPickerProp = interface static member propsInterface : unit = () end
type [<Erase>] calendarYearPicker =
    static member inline start ( value : int ) : ICalendarYearPickerProp = Interop.mkProperty "start" value
    static member inline end' ( value : int ) : ICalendarYearPickerProp = Interop.mkProperty "end" value

let CalendarYearPicker : JSX.ElementType = JSX.jsx """
({
  className,
  start,
  end
}) => {
  const { year, setYear } = useCalendar();

  return (
    (<Combobox
      className={className}
      value={year.toString()}
      setValue={(value) => setYear(Number.parseInt(value))}
      data={Array.from({ length: end - start + 1 }, (_, i) => ({
        value: (start + i).toString(),
        label: (start + i).toString(),
      }))}
      labels={{
        button: 'Select year',
        empty: 'No year found',
        search: 'Search year',
      }} />)
  );
}
"""

// --------------- CalendarDatePagination -------------- //
type [<Erase>] ICalendarDatePaginationProp = interface static member propsInterface : unit = () end

let CalendarDatePagination : JSX.ElementType = JSX.jsx """
({
  className
}) => {
  const { month, year, setMonth, setYear } = useCalendar();

  const handlePreviousMonth = () => {
    if (month === 0) {
      setMonth(11);
      setYear(year - 1);
    } else {
      setMonth((month - 1));
    }
  };

  const handleNextMonth = () => {
    if (month === 11) {
      setMonth(0);
      setYear(year + 1);
    } else {
      setMonth((month + 1));
    }
  };

  return (
    (<div className={cn('flex items-center gap-2', className)}>
      <Button onClick={() => handlePreviousMonth()} variant="ghost" size="icon">
        <ChevronLeftIcon size={16} />
      </Button>
      <Button onClick={() => handleNextMonth()} variant="ghost" size="icon">
        <ChevronRightIcon size={16} />
      </Button>
    </div>)
  );
}
"""

// --------------- CalendarDate -------------- //
type [<Erase>] ICalendarDateProp = interface static member propsInterface : unit = () end

let CalendarDate : JSX.ElementType = JSX.jsx """
({
  children
}) => (
  <div className="flex items-center justify-between p-3">{children}</div>
)
"""

// --------------- CalendarHeader -------------- //
type [<Erase>] ICalendarHeaderProp = interface static member propsInterface : unit = () end

let CalendarHeader : JSX.ElementType = JSX.jsx """
({
  className
}) => {
  const { locale, startDay } = useContext(CalendarContext);

  return (
    (<div className={cn('grid flex-grow grid-cols-7', className)}>
      {daysForLocale(locale, startDay).map((day) => (
        <div key={day} className="p-3 text-right text-muted-foreground text-xs">
          {day}
        </div>
      ))}
    </div>)
  );
}
"""

// --------------- CalendarItem -------------- //
type [<Erase>] ICalendarItemProp = interface static member propsInterface : unit = () end

let CalendarItem : JSX.ElementType = JSX.jsx """
({
  feature,
  className
}) => (
  <div className={cn('flex items-center gap-2', className)} key={feature.id}>
    <div
      className="h-2 w-2 shrink-0 rounded-full"
      style={{
        backgroundColor: feature.status.color,
      }} />
    <span className="truncate">{feature.name}</span>
  </div>
)
"""

// --------------- CalendarProvider -------------- //
type [<Erase>] ICalendarProviderProp = interface static member propsInterface : unit = () end
type [<Erase>] calendarProvider =
    static member inline locale ( value : string ) : ICalendarProviderProp = Interop.mkProperty "locale" value
    static member inline startDay ( value : int ) : ICalendarProviderProp = Interop.mkProperty "startDay" value

let CalendarProvider : JSX.ElementType = JSX.jsx """
({
  locale = 'en-US',
  startDay = 0,
  children,
  className
}) => (
  <CalendarContext.Provider value={{ locale, startDay }}>
    <div className={cn('relative flex flex-col', className)}>{children}</div>
  </CalendarContext.Provider>
)
"""

type [<Erase>] Shadcn =
    /// The <c>CalendarBody</c> component is used to display the body of the calendar.
    static member inline CalendarBody ( props : ICalendarBodyProp list ) = JSX.createElement CalendarBody props
    /// The <c>CalendarBody</c> component is used to display the body of the calendar.
    static member inline CalendarBody ( children : ReactElement list ) = JSX.createElementWithChildren CalendarBody children
    /// The <c>CalendarDate</c> component is used to display the date of the calendar.
    static member inline CalendarDate ( props : ICalendarDateProp list ) = JSX.createElement CalendarDate props
    /// The <c>CalendarDate</c> component is used to display the date of the calendar.
    static member inline CalendarDate ( children : ReactElement list ) = JSX.createElementWithChildren CalendarDate children
    /// The <c>CalendarDatePagination</c> component is used to display the pagination of the calendar.
    static member inline CalendarDatePagination ( props : ICalendarDatePaginationProp list ) = JSX.createElement CalendarDatePagination props
    /// The <c>CalendarDatePagination</c> component is used to display the pagination of the calendar.
    static member inline CalendarDatePagination ( children : ReactElement list ) = JSX.createElementWithChildren CalendarDatePagination children
    /// The <c>CalendarDatePicker</c> component is used to contain the date picker of the calendar.
    static member inline CalendarDatePicker ( props : ICalendarDatePickerProp list ) = JSX.createElement CalendarDatePicker props
    /// The <c>CalendarDatePicker</c> component is used to contain the date picker of the calendar.
    static member inline CalendarDatePicker ( children : ReactElement list ) = JSX.createElementWithChildren CalendarDatePicker children
    /// The <c>CalendarHeader</c> component is used to display the header of the calendar.
    static member inline CalendarHeader ( props : ICalendarHeaderProp list ) = JSX.createElement CalendarHeader props
    /// The <c>CalendarHeader</c> component is used to display the header of the calendar.
    static member inline CalendarHeader ( children : ReactElement list ) = JSX.createElementWithChildren CalendarHeader children
    /// The <c>CalendarItem</c> component is used to display a single item in the calendar.
    static member inline CalendarItem ( props : ICalendarItemProp list ) = JSX.createElement CalendarItem props
    /// The <c>CalendarItem</c> component is used to display a single item in the calendar.
    static member inline CalendarItem ( children : ReactElement list ) = JSX.createElementWithChildren CalendarItem children
    /// The <c>CalendarMonthPicker</c> component is used to display the month picker of the calendar.
    static member inline CalendarMonthPicker ( props : ICalendarMonthPickerProp list ) = JSX.createElement CalendarMonthPicker props
    /// The <c>CalendarMonthPicker</c> component is used to display the month picker of the calendar.
    static member inline CalendarMonthPicker ( children : ReactElement list ) = JSX.createElementWithChildren CalendarMonthPicker children
    /// The <c>CalendarProvider</c> component is used to provide the features to the calendar.
    static member inline CalendarProvider ( props : ICalendarProviderProp list ) = JSX.createElement CalendarProvider props
    /// The <c>CalendarProvider</c> component is used to provide the features to the calendar.
    static member inline CalendarProvider ( children : ReactElement list ) = JSX.createElementWithChildren CalendarProvider children
    /// The <c>CalendarYearPicker</c> component is used to display the year picker of the calendar.
    static member inline CalendarYearPicker ( props : ICalendarYearPickerProp list ) = JSX.createElement CalendarYearPicker props
    /// The <c>CalendarYearPicker</c> component is used to display the year picker of the calendar.
    static member inline CalendarYearPicker ( children : ReactElement list ) = JSX.createElementWithChildren CalendarYearPicker children
    static member inline Combobox ( props : IComboboxProp list ) = JSX.createElement Combobox props
    static member inline Combobox ( children : ReactElement list ) = JSX.createElementWithChildren Combobox children                                    