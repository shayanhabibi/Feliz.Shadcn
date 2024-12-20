namespace rec Feliz.Shadcn.Popover

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn
open Browser.Types


/// Displays rich content in a portal, triggered by a button.
type [<Erase>] popover =
    /// Contains all the parts of a popover.
    static member inline root (props: IReactProperty seq) = createElement (import "Popover" "@/components/ui/popover") props
    /// The button that toggles the popover. By default, the Popover.Content will position itself against the trigger.
    static member inline trigger (props: IReactProperty seq) = createElement (import "PopoverTrigger" "@/components/ui/popover") props
    /// An optional element to position the Popover.Content against. If this part is not used, the content will position alongside the Popover.Trigger.
    static member inline anchor (props: IReactProperty seq) = createElement (import "PopoverAnchor" "@/components/ui/popover") props
    /// When used, portals the content part into the body.
    static member inline portal (props: IReactProperty seq) = createElement (import "PopoverPortal" "@/components/ui/popover") props
    /// The component that pops out when the popover is open.
    static member inline content (props: IReactProperty seq) = createElement (import "PopoverContent" "@/components/ui/popover") props
    /// An optional arrow element to render alongside the popover. This can be used to help visually link the anchor with the Popover.Content. Must be rendered inside Popover.Content.
    static member inline arrow (props: IReactProperty seq) = createElement (import "PopoverArrow" "@/components/ui/popover") props
    /// The button that closes an open popover.
    static member inline close (props: IReactProperty seq) = createElement (import "PopoverClose" "@/components/ui/popover") props


/// Contains all the parts of a popover.
type [<Erase>] root =
    /// The open state of the popover when it is initially rendered. Use when you do not need to control its open state.
    static member inline defaultOpen (value: bool) = Feliz.Interop.mkAttr "defaultOpen" value
    /// The controlled open state of the popover. Must be used in conjunction with onOpenChange.
    static member inline open' (value: bool) = Feliz.Interop.mkAttr "open" value
    /// Event handler called when the open state of the popover changes.
    static member inline onOpenChange (value: (bool -> unit)) = Feliz.Interop.mkAttr "onOpenChange" value
    /// Event handler called when the open state of the popover changes.
    static member inline modal (value: bool) = Feliz.Interop.mkAttr "modal" value




/// The button that toggles the popover. By default, the Popover.Content will position itself against the trigger.
type [<Erase>] trigger =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// An optional element to position the Popover.Content against. If this part is not used, the content will position alongside the Popover.Trigger.
type [<Erase>] anchor =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// When used, portals the content part into the body.
type [<Erase>] portal =
    /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries. If used on this part, it will be inherited by Popover.Content.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value
    /// Specify a container element to portal the content into.
    static member inline container (value: HTMLElement) = Feliz.Interop.mkAttr "container" value




/// The component that pops out when the popover is open.
type [<Erase>] content =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// Event handler called when focus moves into the component after opening. It can be prevented by calling event.preventDefault.
    static member inline onOpenAutoFocus (value: (Browser.Types.Event -> unit)) = Feliz.Interop.mkAttr "onOpenAutoFocus" value
    /// Event handler called when focus moves into the component after opening. It can be prevented by calling event.preventDefault.
    static member inline onCloseAutoFocus (value: (Browser.Types.Event -> unit)) = Feliz.Interop.mkAttr "onCloseAutoFocus" value
    /// Event handler called when focus moves to the trigger after closing. It can be prevented by calling event.preventDefault.
    static member inline onEscapeKeyDown (value: (Browser.Types.KeyboardEvent -> unit)) = Feliz.Interop.mkAttr "onEscapeKeyDown" value
    /// Event handler called when the escape key is down. It can be prevented by calling event.preventDefault.
    static member inline onPointerDownOutside (value: (PointerDownOutsideEvent -> unit)) = Feliz.Interop.mkAttr "onPointerDownOutside" value
    /// Event handler called when a pointer event occurs outside the bounds of the component. It can be prevented by calling event.preventDefault.
    static member inline onFocusOutside (value: (FocusOutsideEvent -> unit)) = Feliz.Interop.mkAttr "onFocusOutside" value
    /// Event handler called when focus moves outside the bounds of the component. It can be prevented by calling event.preventDefault.
    static member inline onInteractOutside (value: (PointerDownOutsideEvent -> unit)) = Feliz.Interop.mkAttr "onInteractOutside" value
    /// Event handler called when focus moves outside the bounds of the component. It can be prevented by calling event.preventDefault.
    static member inline onInteractOutside (value: (FocusOutsideEvent -> unit)) = Feliz.Interop.mkAttr "onInteractOutside" value
    /// Event handler called when an interaction (pointer or focus event) happens outside the bounds of the component. It can be prevented by calling event.preventDefault.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value
    /// The preferred side of the anchor to render against when open. Will be reversed when collisions occur and avoidCollisions is enabled.
    static member inline sideOffset (value: int) = Feliz.Interop.mkAttr "sideOffset" value
    /// The preferred alignment against the anchor. May change when collisions occur.
    static member inline alignOffset (value: int) = Feliz.Interop.mkAttr "alignOffset" value
    /// When true, overrides the side andalign preferences to prevent collisions with boundary edges.
    static member inline avoidCollisions (value: bool) = Feliz.Interop.mkAttr "avoidCollisions" value
    /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check.
    static member inline collisionBoundary (value: ReactElement) = Feliz.Interop.mkAttr "collisionBoundary" value
    /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check.
    static member inline collisionBoundary (value: ReactElement[]) = Feliz.Interop.mkAttr "collisionBoundary" value
    /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check.
    static member inline collisionPadding (value: int) = Feliz.Interop.mkAttr "collisionPadding" value
    /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check.
    static member inline collisionPadding (value: 'T) = Feliz.Interop.mkAttr "collisionPadding" value
    /// The distance in pixels from the boundary edges where collision detection should occur. Accepts a number (same for all sides), or a partial padding object, for example: { top: 20, left: 20 }.
    static member inline arrowPadding (value: int) = Feliz.Interop.mkAttr "arrowPadding" value
    /// The sticky behavior on the align axis. "partial" will keep the content in the boundary as long as the trigger is at least partially in the boundary whilst "always" will keep the content in the boundary regardless.
    static member inline hideWhenDetached (value: bool) = Feliz.Interop.mkAttr "hideWhenDetached" value


module content =

    type [<Erase>] side =
        static member inline top = Feliz.Interop.mkAttr "side" "top"
        static member inline right = Feliz.Interop.mkAttr "side" "right"
        static member inline bottom = Feliz.Interop.mkAttr "side" "bottom"
        static member inline left = Feliz.Interop.mkAttr "side" "left"

    type [<Erase>] align =
        static member inline start = Feliz.Interop.mkAttr "align" "start"
        static member inline center = Feliz.Interop.mkAttr "align" "center"
        static member inline end' = Feliz.Interop.mkAttr "align" "end"

    type [<Erase>] sticky =
        static member inline partial = Feliz.Interop.mkAttr "sticky" "partial"
        static member inline always = Feliz.Interop.mkAttr "sticky" "always"



/// An optional arrow element to render alongside the popover. This can be used to help visually link the anchor with the Popover.Content. Must be rendered inside Popover.Content.
type [<Erase>] arrow =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// The width of the arrow in pixels.
    static member inline width (value: int) = Feliz.Interop.mkAttr "width" value
    /// The height of the arrow in pixels.
    static member inline height (value: int) = Feliz.Interop.mkAttr "height" value




/// The button that closes an open popover.
type [<Erase>] close =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value



