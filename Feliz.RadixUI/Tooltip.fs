namespace Feliz.RadixUI

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Interop.Extend
open Browser.Types


/// A popup that displays information related to an element when the element receives keyboard focus or the mouse hovers over it.
module [<Erase>] Tooltip =
    /// import "TooltipProvider" ""
    /// Wraps your app to provide global functionality to your tooltips.
    type [<Erase>] provider<'Property> =
        inherit prop<'Property>
        /// The duration from when the mouse enters a tooltip trigger until the tooltip opens.
        static member inline delayDuration ( value : int ) : 'Property = Interop.mkProperty "delayDuration" value
        /// How much time a user has to enter another trigger without incurring a delay again.
        static member inline skipDelayDuration ( value : int ) : 'Property = Interop.mkProperty "skipDelayDuration" value
        /// Prevents Tooltip.Content from remaining open when hovering. Disabling this has accessibility consequences.
        static member inline disableHoverableContent ( value : bool ) : 'Property = Interop.mkProperty "disableHoverableContent" value

    /// import "Tooltip" ""
    /// Contains all the parts of a tooltip.
    type [<Erase>] root<'Property> =
        inherit prop<'Property>
        /// The open state of the tooltip when it is initially rendered. Use when you do not need to control its open state.
        static member inline defaultOpen ( value : bool ) : 'Property = Interop.mkProperty "defaultOpen" value
        /// The controlled open state of the tooltip. Must be used in conjunction with onOpenChange.
        static member inline open' ( value : bool ) : 'Property = Interop.mkProperty "open" value
        /// Event handler called when the open state of the tooltip changes.
        static member inline onOpenChange ( value : (bool -> unit) ) : 'Property = Interop.mkProperty "onOpenChange" value
        /// Event handler called when the open state of the tooltip changes.
        static member inline delayDuration ( value : int ) : 'Property = Interop.mkProperty "delayDuration" value
        /// Prevents Tooltip.Content from remaining open when hovering. Disabling this has accessibility consequences. Inherits from Tooltip.Provider.
        static member inline disableHoverableContent ( value : bool ) : 'Property = Interop.mkProperty "disableHoverableContent" value

    /// import "TooltipTrigger" ""
    /// The button that toggles the tooltip. By default, the Tooltip.Content will position itself against the trigger.
    type [<Erase>] trigger<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// import "TooltipPortal" ""
    /// When used, portals the content part into the body.
    type [<Erase>] portal<'Property> =
        inherit prop<'Property>
        /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries. If used on this part, it will be inherited by Tooltip.Content.
        static member inline forceMount ( value : bool ) : 'Property = Interop.mkProperty "forceMount" value
        /// Specify a container element to portal the content into.
        static member inline container ( value : HTMLElement ) : 'Property = Interop.mkProperty "container" value

    /// import "TooltipContent" ""
    /// The component that pops out when the tooltip is open.
    type [<Erase>] content<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// By default, screenreaders will announce the content inside the component. If this is not descriptive enough, or you have content that cannot be announced, use aria-label as a more descriptive label.
        static member inline ariaLabel ( value : string ) : 'Property = Interop.mkProperty "aria-label" value
        /// Event handler called when the escape key is down. It can be prevented by calling event.preventDefault.
        static member inline onEscapeKeyDown ( value : (Browser.Types.KeyboardEvent -> unit) ) : 'Property = Interop.mkProperty "onEscapeKeyDown" value
        /// Event handler called when the escape key is down. It can be prevented by calling event.preventDefault.
        static member inline onPointerDownOutside ( value : (PointerEvent -> unit) ) : 'Property = Interop.mkProperty "onPointerDownOutside" value
        /// Event handler called when a pointer event occurs outside the bounds of the component. It can be prevented by calling event.preventDefault.
        static member inline forceMount ( value : bool ) : 'Property = Interop.mkProperty "forceMount" value
        /// The preferred side of the trigger to render against when open. Will be reversed when collisions occur and avoidCollisions is enabled.
        static member inline sideOffset ( value : int ) : 'Property = Interop.mkProperty "sideOffset" value
        /// The preferred alignment against the trigger. May change when collisions occur.
        static member inline alignOffset ( value : int ) : 'Property = Interop.mkProperty "alignOffset" value
        /// When true, overrides the side andalign preferences to prevent collisions with boundary edges.
        static member inline avoidCollisions ( value : bool ) : 'Property = Interop.mkProperty "avoidCollisions" value
        /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check.
        static member inline collisionBoundary ( value : ReactElement ) : 'Property = Interop.mkProperty "collisionBoundary" value
        /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check.
        static member inline collisionBoundary ( value : ReactElement[] ) : 'Property = Interop.mkProperty "collisionBoundary" value
        /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check.
        static member inline collisionPadding ( value : int ) : 'Property = Interop.mkProperty "collisionPadding" value
        /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check.
        static member inline collisionPadding ( value : 'T ) : 'Property = Interop.mkProperty "collisionPadding" value
        /// The distance in pixels from the boundary edges where collision detection should occur. Accepts a number (same for all sides), or a partial padding object, for example: { top: 20, left: 20 }.
        static member inline arrowPadding ( value : int ) : 'Property = Interop.mkProperty "arrowPadding" value
        /// The sticky behavior on the align axis. "partial" will keep the content in the boundary as long as the trigger is at least partially in the boundary whilst "always" will keep the content in the boundary regardless.
        static member inline hideWhenDetached ( value : bool ) : 'Property = Interop.mkProperty "hideWhenDetached" value

    /// import "TooltipArrow" ""
    /// An optional arrow element to render alongside the tooltip. This can be used to help visually link the trigger with the Tooltip.Content. Must be rendered inside Tooltip.Content.
    type [<Erase>] arrow<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// The width of the arrow in pixels.
        static member inline width ( value : int ) : 'Property = Interop.mkProperty "width" value
        /// The height of the arrow in pixels.
        static member inline height ( value : int ) : 'Property = Interop.mkProperty "height" value

module [<Erase>] tooltipcontent =
    type [<Erase>] side<'Property> =
        static member inline top : 'Property = Interop.mkProperty "side" "top"
        static member inline right : 'Property = Interop.mkProperty "side" "right"
        static member inline bottom : 'Property = Interop.mkProperty "side" "bottom"
        static member inline left : 'Property = Interop.mkProperty "side" "left"

    type [<Erase>] align<'Property> =
        static member inline start : 'Property = Interop.mkProperty "align" "start"
        static member inline center : 'Property = Interop.mkProperty "align" "center"
        static member inline end' : 'Property = Interop.mkProperty "align" "end"

    type [<Erase>] sticky<'Property> =
        static member inline partial : 'Property = Interop.mkProperty "sticky" "partial"
        static member inline always : 'Property = Interop.mkProperty "sticky" "always"
