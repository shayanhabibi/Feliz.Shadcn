namespace rec Feliz.Shadcn.HoverCard

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn
open Browser.Types


/// For sighted users to preview content available behind a link.
type [<Erase>] hoverCard =
    /// Contains all the parts of a hover card.
    static member inline root (props: IReactProperty seq) = createElement (import "HoverCard" "@/components/ui/hover-card") props
    /// The link that opens the hover card when hovered.
    static member inline trigger (props: IReactProperty seq) = createElement (import "HoverCardTrigger" "@/components/ui/hover-card") props
    /// When used, portals the content part into the body.
    static member inline portal (props: IReactProperty seq) = createElement (import "HoverCardPortal" "@/components/ui/hover-card") props
    /// The component that pops out when the hover card is open.
    static member inline content (props: IReactProperty seq) = createElement (import "HoverCardContent" "@/components/ui/hover-card") props
    /// An optional arrow element to render alongside the hover card. This can be used to help visually link the trigger with the HoverCard.Content. Must be rendered inside HoverCard.Content.
    static member inline arrow (props: IReactProperty seq) = createElement (import "HoverCardArrow" "@/components/ui/hover-card") props


/// Contains all the parts of a hover card.
type [<Erase>] root =
    /// The open state of the hover card when it is initially rendered. Use when you do not need to control its open state.
    static member inline defaultOpen (value: bool) = Feliz.Interop.mkAttr "defaultOpen" value
    /// The controlled open state of the hover card. Must be used in conjunction with onOpenChange.
    static member inline open' (value: bool) = Feliz.Interop.mkAttr "open" value
    /// Event handler called when the open state of the hover card changes.
    static member inline onOpenChange (value: (bool -> unit)) = Feliz.Interop.mkAttr "onOpenChange" value
    /// Event handler called when the open state of the hover card changes.
    static member inline openDelay (value: int) = Feliz.Interop.mkAttr "openDelay" value
    /// The duration from when the mouse leaves the trigger or content until the hover card closes.
    static member inline closeDelay (value: int) = Feliz.Interop.mkAttr "closeDelay" value




/// The link that opens the hover card when hovered.
type [<Erase>] trigger =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// When used, portals the content part into the body.
type [<Erase>] portal =
    /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries. If used on this part, it will be inherited by HoverCard.Content.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value
    /// Specify a container element to portal the content into.
    static member inline container (value: HTMLElement) = Feliz.Interop.mkAttr "container" value




/// The component that pops out when the hover card is open.
type [<Erase>] content =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries. It inherits from HoverCard.Portal.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value
    /// The preferred side of the trigger to render against when open. Will be reversed when collisions occur and avoidCollisions is enabled.
    static member inline sideOffset (value: int) = Feliz.Interop.mkAttr "sideOffset" value
    /// The preferred alignment against the trigger. May change when collisions occur.
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



/// An optional arrow element to render alongside the hover card. This can be used to help visually link the trigger with the HoverCard.Content. Must be rendered inside HoverCard.Content.
type [<Erase>] arrow =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// The width of the arrow in pixels.
    static member inline width (value: int) = Feliz.Interop.mkAttr "width" value
    /// The height of the arrow in pixels.
    static member inline height (value: int) = Feliz.Interop.mkAttr "height" value



