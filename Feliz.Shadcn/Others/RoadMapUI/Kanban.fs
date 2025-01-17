/// A kanban board is a visual tool that helps you manage and visualize your work. It is a board with columns,
/// and each column represents a status, e.g. "Backlog", "In Progress", "Done".
[<AutoOpen>]
module Feliz.Shadcn.RoadmapUI.Kanban

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
JSX.injectShadcnLib
ignore <| JSX.jsx """
import {
  DndContext,
  rectIntersection,
  useDraggable,
  useDroppable,
} from '@dnd-kit/core'
"""
open Feliz.Shadcn
let private imports = ( Card )

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

// --------------- KanbanBoard -------------- //
type [<Erase>] IKanbanBoardProp = interface end
type [<Erase>] kanbanBoard =
    inherit prop<IKanbanBoardProp>
    static member inline id ( value : string ) : IKanbanBoardProp = Interop.mkProperty "id" value

let KanbanBoard : JSX.ElementType = JSX.jsx """
({
  id,
  children,
  className
}) => {
  const { isOver, setNodeRef } = useDroppable({ id });

  return (
    (<div
      className={cn(
        'flex h-full min-h-40 flex-col gap-2 rounded-md border bg-secondary p-2 text-xs shadow-sm outline outline-2 transition-all',
        isOver ? 'outline-primary' : 'outline-transparent',
        className
      )}
      ref={setNodeRef}>
      {children}
    </div>)
  );
}
"""

// --------------- KanbanCard -------------- //
type [<Erase>] IKanbanCardProp = interface end
type [<Erase>] kanbanCard =
    inherit prop<IKanbanCardProp>
    static member inline id ( value : string ) : IKanbanCardProp = Interop.mkProperty "id" value
    static member inline index ( value : int ) : IKanbanCardProp = Interop.mkProperty "index" value
    static member inline name ( value : string ) : IKanbanCardProp = Interop.mkProperty "name" value
    static member inline parent ( value : string ) : IKanbanCardProp = Interop.mkProperty "parent" value

let KanbanCard : JSX.ElementType = JSX.jsx """
({
  id,
  name,
  index,
  parent,
  children,
  className
}) => {
  const { attributes, listeners, setNodeRef, transform, isDragging } =
    useDraggable({
      id,
      data: { index, parent },
    });

  return (
    (<Card
      className={cn('rounded-md p-3 shadow-sm', isDragging && 'cursor-grabbing', className)}
      style={{
        transform: transform
          ? `translateX(${transform.x}px) translateY(${transform.y}px)`
          : 'none',
      }}
      {...listeners}
      {...attributes}
      ref={setNodeRef}>
      {children ?? <p className="m-0 font-medium text-sm">{name}</p>}
    </Card>)
  );
}
"""

// --------------- KanbanCards -------------- //
type [<Erase>] IKanbanCardsProp = interface end
type [<Erase>] kanbanCards =
    inherit prop<IKanbanCardsProp>
    static member inline private noop : unit = ()

let KanbanCards : JSX.ElementType = JSX.jsx """
({
  children,
  className
}) => (
  <div className={cn('flex flex-1 flex-col gap-2', className)}>{children}</div>
)
"""

// --------------- KanbanHeader -------------- //
type [<Erase>] IKanbanHeaderProp = interface end
type [<Erase>] kanbanHeader =
    inherit prop<IKanbanHeaderProp>
    static member inline color ( value : string ) : IKanbanHeaderProp = Interop.mkProperty "color" value
    static member inline name ( value : string ) : IKanbanHeaderProp = Interop.mkProperty "name" value
    static member inline status ( value : Status ) : IKanbanHeaderProp = Interop.mkProperty "status" value

let KanbanHeader : JSX.ElementType = JSX.jsx """
(props) =>
  'children' in props ? (
    props.children
  ) : (
    <div className={cn('flex shrink-0 items-center gap-2', props.className)}>
      <div className="h-2 w-2 rounded-full" style={{ backgroundColor: props.status ? props.status.color : props.color }} />
      <p className="m-0 font-semibold text-sm">{props.status ? props.status.name : props.name}</p>
    </div>
  )
"""

[<AllowNullLiteral>]
[<Global>]
type DragEndEvent
    [<ParamObject; Emit("$0")>]
    (
        id : string,
        ?over : string
    ) =
    member val id : string = jsNative with get,set
    member val over : string option = jsNative with get,set
        

// --------------- KanbanProvider -------------- //
type [<Erase>] IKanbanProviderProp = interface end
type [<Erase>] kanbanProvider =
    inherit prop<IKanbanProviderProp>
    static member inline onDragEnd ( handler : DragEndEvent -> unit ) : IKanbanProviderProp = Interop.mkProperty "onDragEnd" handler

let KanbanProvider : JSX.ElementType = JSX.jsx """
({
  children,
  onDragEnd,
  className
}) => (
  <DndContext collisionDetection={rectIntersection} onDragEnd={onDragEnd}>
    <div className={cn('grid w-full auto-cols-fr grid-flow-col gap-4', className)}>
      {children}
    </div>
  </DndContext>
)
"""

type [<Erase>] Shadcn =
    /// The <c>KanbanBoard</c> component is a container for the columns of the Kanban board.
    static member inline KanbanBoard ( props : IKanbanBoardProp list ) = JSX.createElement KanbanBoard props
    /// The <c>KanbanBoard</c> component is a container for the columns of the Kanban board.
    static member inline KanbanBoard ( children : ReactElement list ) = JSX.createElementWithChildren KanbanBoard children
    /// The <c>KanbanCard</c> component is a single card in the Kanban board.
    static member inline KanbanCard ( props : IKanbanCardProp list ) = JSX.createElement KanbanCard props
    /// The <c>KanbanCard</c> component is a single card in the Kanban board.
    static member inline KanbanCard ( children : ReactElement list ) = JSX.createElementWithChildren KanbanCard children
    /// The <c>KanbanCards</c> component is a container for the cards of the Kanban board.
    static member inline KanbanCards ( props : IKanbanCardsProp list ) = JSX.createElement KanbanCards props
    /// The <c>KanbanCards</c> component is a container for the cards of the Kanban board.
    static member inline KanbanCards ( children : ReactElement list ) = JSX.createElementWithChildren KanbanCards children
    /// The <c>KanbanHeader</c> component is a container for the column headers of the Kanban board.
    static member inline KanbanHeader ( props : IKanbanHeaderProp list ) = JSX.createElement KanbanHeader props
    /// The <c>KanbanHeader</c> component is a container for the column headers of the Kanban board.
    static member inline KanbanHeader ( children : ReactElement list ) = JSX.createElementWithChildren KanbanHeader children
    /// The <c>KanbanProvider</c> component is the root component of the Kanban board. It contains the drag-and-drop context and provides the necessary context for the other components.
    static member inline KanbanProvider ( props : IKanbanProviderProp list ) = JSX.createElement KanbanProvider props
    /// The <c>KanbanProvider</c> component is the root component of the Kanban board. It contains the drag-and-drop context and provides the necessary context for the other components.
    static member inline KanbanProvider ( children : ReactElement list ) = JSX.createElementWithChildren KanbanProvider children
                