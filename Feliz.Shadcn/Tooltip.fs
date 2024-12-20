namespace rec Feliz.Shadcn.Tooltip

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn
open Browser.Types


/// A popup that displays information related to an element when the element receives keyboard focus or the mouse hovers over it.
type [<Erase>] tooltip =
    /// Wraps your app to provide global functionality to your tooltips.
    static member inline provider (props: IReactProperty seq) = createElement (import "TooltipProvider" "@/components/ui/tooltip") props
    /// Contains all the parts of a tooltip.
    static member inline root (props: IReactProperty seq) = createElement (import "Tooltip" "@/components/ui/tooltip") props
    /// The button that toggles the tooltip. By default, the Tooltip.Content will position itself against the trigger.
    static member inline trigger (props: IReactProperty seq) = createElement (import "TooltipTrigger" "@/components/ui/tooltip") props
    /// When used, portals the content part into the body.
    static member inline portal (props: IReactProperty seq) = createElement (import "TooltipPortal" "@/components/ui/tooltip") props
    /// The component that pops out when the tooltip is open.
    static member inline content (props: IReactProperty seq) = createElement (import "TooltipContent" "@/components/ui/tooltip") props
    /// An optional arrow element to render alongside the tooltip. This can be used to help visually link the trigger with the Tooltip.Content. Must be rendered inside Tooltip.Content.
    static member inline arrow (props: IReactProperty seq) = createElement (import "TooltipArrow" "@/components/ui/tooltip") props


/// Wraps your app to provide global functionality to your tooltips.
type [<Erase>] provider =
    /// The duration from when the mouse enters a tooltip trigger until the tooltip opens.
    static member inline delayDuration (value: int) = Feliz.Interop.mkAttr "delayDuration" value
    /// How much time a user has to enter another trigger without incurring a delay again.
    static member inline skipDelayDuration (value: int) = Feliz.Interop.mkAttr "skipDelayDuration" value
    /// Prevents Tooltip.Content from remaining open when hovering. Disabling this has accessibility consequences.
    static member inline disableHoverableContent (value: bool) = Feliz.Interop.mkAttr "disableHoverableContent" value




/// Contains all the parts of a tooltip.
type [<Erase>] root =
    /// The open state of the tooltip when it is initially rendered. Use when you do not need to control its open state.
    static member inline defaultOpen (value: bool) = Feliz.Interop.mkAttr "defaultOpen" value
    /// The controlled open state of the tooltip. Must be used in conjunction with onOpenChange.
    static member inline open' (value: bool) = Feliz.Interop.mkAttr "open" value
    /// Event handler called when the open state of the tooltip changes.
    static member inline onOpenChange (value: (bool -> unit)) = Feliz.Interop.mkAttr "onOpenChange" value
    /// Event handler called when the open state of the tooltip changes.
    static member inline delayDuration (value: int) = Feliz.Interop.mkAttr "delayDuration" value
    /// Prevents Tooltip.Content from remaining open when hovering. Disabling this has accessibility consequences. Inherits from Tooltip.Provider.
    static member inline disableHoverableContent (value: bool) = Feliz.Interop.mkAttr "disableHoverableContent" value




/// The button that toggles the tooltip. By default, the Tooltip.Content will position itself against the trigger.
type [<Erase>] trigger =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// When used, portals the content part into the body.
type [<Erase>] portal =
    /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries. If used on this part, it will be inherited by Tooltip.Content.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value
    /// Specify a container element to portal the content into.
    static member inline container (value: HTMLElement) = Feliz.Interop.mkAttr "container" value




/// The component that pops out when the tooltip is open.
type [<Erase>] content =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// By default, screenreaders will announce the content inside the component. If this is not descriptive enough, or you have content that cannot be announced, use aria-label as a more descriptive label.
    static member inline ariaLabel (value: string) = Feliz.Interop.mkAttr "aria-label" value
    /// Event handler called when the escape key is down. It can be prevented by calling event.preventDefault.
    static member inline onEscapeKeyDown (value: (Browser.Types.KeyboardEvent -> unit)) = Feliz.Interop.mkAttr "onEscapeKeyDown" value
    /// Event handler called when the escape key is down. It can be prevented by calling event.preventDefault.
    static member inline onPointerDownOutside (value: (PointerDownOutsideEvent -> unit)) = Feliz.Interop.mkAttr "onPointerDownOutside" value
    /// Event handler called when a pointer event occurs outside the bounds of the component. It can be prevented by calling event.preventDefault.
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



/// An optional arrow element to render alongside the tooltip. This can be used to help visually link the trigger with the Tooltip.Content. Must be rendered inside Tooltip.Content.
type [<Erase>] arrow =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// The width of the arrow in pixels.
    static member inline width (value: int) = Feliz.Interop.mkAttr "width" value
    /// The height of the arrow in pixels.
    static member inline height (value: int) = Feliz.Interop.mkAttr "height" value



