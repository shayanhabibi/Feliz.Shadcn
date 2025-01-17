/// List views are a great way to show a list of tasks grouped by status and ranked by priority.
[<AutoOpen>]
module Feliz.Shadcn.RoadmapUI.List

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
JSX.injectShadcnLib
ignore <| JSX.jsx """
import { DndContext, rectIntersection, useDraggable, useDroppable } from '@dnd-kit/core';
import { restrictToVerticalAxis } from '@dnd-kit/modifiers';
"""

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

// --------------- ListItems -------------- //
type [<Erase>] IListItemsProp = interface end
type [<Erase>] listItems =
    inherit prop<IListItemsProp>
    static member inline private noop : unit = ()

let ListItems : JSX.ElementType = JSX.jsx """
({
  children,
  className
}) => (
  <div className={cn('flex flex-1 flex-col gap-2 p-3', className)}>
    {children}
  </div>
)
"""

// --------------- ListHeader -------------- //
type [<Erase>] IListHeaderProp = interface end
type [<Erase>] listHeader =
    inherit prop<IListHeaderProp>
    static member inline name ( value : string ) : IListHeaderProp = Interop.mkProperty "name" value
    static member inline color ( value : string ) : IListHeaderProp = Interop.mkProperty "color" value

let ListHeader : JSX.ElementType = JSX.jsx """
(props) =>
  'children' in props ? (
    props.children
  ) : (
    <div
      className={cn('flex shrink-0 items-center gap-2 bg-foreground/5 p-3', props.className)}>
      <div className="h-2 w-2 rounded-full" style={{ backgroundColor: props.color }} />
      <p className="m-0 font-semibold text-sm">{props.name}</p>
    </div>
  )
"""

// --------------- ListGroup -------------- //
type [<Erase>] IListGroupProp = interface end
type [<Erase>] listGroup =
    inherit prop<IListGroupProp>
    static member inline id ( value : string ) : IListGroupProp = Interop.mkProperty "id" value
    
let ListGroup : JSX.ElementType = JSX.jsx """
({
  id,
  children,
  className
}) => {
  const { setNodeRef, isOver } = useDroppable({ id });

  return (
    (<div
      className={cn('bg-secondary transition-colors', isOver && 'bg-foreground/10', className)}
      ref={setNodeRef}>
      {children}
    </div>)
  );
}
"""

// --------------- ListItem -------------- //
type [<Erase>] IListItemProp = interface end
type [<Erase>] listItem =
    inherit prop<IListItemProp>
    static member inline id ( value : string ) : IListItemProp = Interop.mkProperty "id" value
    static member inline name ( value : string ) : IListItemProp = Interop.mkProperty "name" value

let ListItem : JSX.ElementType = JSX.jsx """
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
    (<div
      className={cn(
        'flex cursor-grab items-center gap-2 rounded-md border bg-background p-2 shadow-sm',
        isDragging && 'cursor-grabbing',
        className
      )}
      style={{
        transform: transform
          ? `translateX(${transform.x}px) translateY(${transform.y}px)`
          : 'none',
      }}
      {...listeners}
      {...attributes}
      ref={setNodeRef}>
      {children ?? <p className="m-0 font-medium text-sm">{name}</p>}
    </div>)
  );
}
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
    
// --------------- ListProvider -------------- //
type [<Erase>] IListProviderProp = interface end
type [<Erase>] listProvider =
    inherit prop<IListProviderProp>
    static member inline onDragEnd ( handler : DragEndEvent -> unit ) : IListProviderProp = Interop.mkProperty "onDragEnd" handler

let ListProvider : JSX.ElementType = JSX.jsx """
({
  children,
  onDragEnd,
  className
}) => (
  <DndContext
    collisionDetection={rectIntersection}
    onDragEnd={onDragEnd}
    modifiers={[restrictToVerticalAxis]}>
    <div className={cn('flex flex-col', className)}>{children}</div>
  </DndContext>
)
"""

type [<Erase>] Shadcn =
    /// The <c>ListGroup</c> component is used to display a group of items.
    static member inline ListGroup ( props : IListGroupProp list ) = JSX.createElement ListGroup props
    /// The <c>ListGroup</c> component is used to display a group of items.
    static member inline ListGroup ( children : ReactElement list ) = JSX.createElementWithChildren ListGroup children
    /// The <c>ListHeader</c> component is used to display the header of a group.
    static member inline ListHeader ( props : IListHeaderProp list ) = JSX.createElement ListHeader props
    /// The <c>ListHeader</c> component is used to display the header of a group.
    static member inline ListHeader ( children : ReactElement list ) = JSX.createElementWithChildren ListHeader children
    /// The <c>ListItem</c> component is used to display an item.
    static member inline ListItem ( props : IListItemProp list ) = JSX.createElement ListItem props
    /// The <c>ListItem</c> component is used to display an item.
    static member inline ListItem ( children : ReactElement list ) = JSX.createElementWithChildren ListItem children
    /// The <c>ListItems</c> component is used to display the items of a group.
    static member inline ListItems ( props : IListItemsProp list ) = JSX.createElement ListItems props
    /// The <c>ListItems</c> component is used to display the items of a group.
    static member inline ListItems ( children : ReactElement list ) = JSX.createElementWithChildren ListItems children
    /// The <c>ListProvider</c> component is used to provide the features to the list.
    static member inline ListProvider ( props : IListProviderProp list ) = JSX.createElement ListProvider props
    /// The <c>ListProvider</c> component is used to provide the features to the list.
    static member inline ListProvider ( children : ReactElement list ) = JSX.createElementWithChildren ListProvider children
                