namespace Feliz.RadixUI

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Interop.Extend
open Browser.Types


/// The component that pops out when the popover is open.
[<RequireQualifiedAccess>]
module [<Erase>] popoverContent =
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

/// Displays rich content in a portal, triggered by a button.
[<RequireQualifiedAccess>]
module [<Erase>] Popover =
    /// Contains all the parts of a popover.
    type [<Erase>] root<'Property> =
        inherit prop<'Property>
        /// The open state of the popover when it is initially rendered. Use when you do not need to control its open state.
        static member inline defaultOpen ( value : bool ) : 'Property = Interop.mkProperty "defaultOpen" value
        /// The controlled open state of the popover. Must be used in conjunction with onOpenChange.
        static member inline open' ( value : bool ) : 'Property = Interop.mkProperty "open" value
        /// Event handler called when the open state of the popover changes.
        static member inline onOpenChange ( value : (bool -> unit) ) : 'Property = Interop.mkProperty "onOpenChange" value
        /// Event handler called when the open state of the popover changes.
        static member inline modal ( value : bool ) : 'Property = Interop.mkProperty "modal" value

    /// The button that toggles the popover. By default, the Popover.Content will position itself against the trigger.
    type [<Erase>] trigger<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// An optional element to position the Popover.Content against. If this part is not used, the content will position alongside the Popover.Trigger.
    type [<Erase>] anchor<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// When used, portals the content part into the body.
    type [<Erase>] portal<'Property> =
        inherit prop<'Property>
        /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries. If used on this part, it will be inherited by Popover.Content.
        static member inline forceMount ( value : bool ) : 'Property = Interop.mkProperty "forceMount" value
        /// Specify a container element to portal the content into.
        static member inline container ( value : HTMLElement ) : 'Property = Interop.mkProperty "container" value

    /// The component that pops out when the popover is open.
    type [<Erase>] content<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// Event handler called when focus moves into the component after opening. It can be prevented by calling event.preventDefault.
        static member inline onOpenAutoFocus ( value : (Browser.Types.Event -> unit) ) : 'Property = Interop.mkProperty "onOpenAutoFocus" value
        /// Event handler called when focus moves into the component after opening. It can be prevented by calling event.preventDefault.
        static member inline onCloseAutoFocus ( value : (Browser.Types.Event -> unit) ) : 'Property = Interop.mkProperty "onCloseAutoFocus" value
        /// Event handler called when focus moves to the trigger after closing. It can be prevented by calling event.preventDefault.
        static member inline onEscapeKeyDown ( value : (Browser.Types.KeyboardEvent -> unit) ) : 'Property = Interop.mkProperty "onEscapeKeyDown" value
        /// Event handler called when the escape key is down. It can be prevented by calling event.preventDefault.
        static member inline onPointerDownOutside ( value : (PointerEvent -> unit) ) : 'Property = Interop.mkProperty "onPointerDownOutside" value
        /// Event handler called when a pointer event occurs outside the bounds of the component. It can be prevented by calling event.preventDefault.
        static member inline onFocusOutside ( value : (FocusEvent -> unit) ) : 'Property = Interop.mkProperty "onFocusOutside" value
        /// Event handler called when focus moves outside the bounds of the component. It can be prevented by calling event.preventDefault.
        static member inline onInteractOutside ( value : (PointerEvent -> unit) ) : 'Property = Interop.mkProperty "onInteractOutside" value
        /// Event handler called when focus moves outside the bounds of the component. It can be prevented by calling event.preventDefault.
        static member inline onInteractOutside ( value : (FocusEvent -> unit) ) : 'Property = Interop.mkProperty "onInteractOutside" value
        /// Event handler called when an interaction (pointer or focus event) happens outside the bounds of the component. It can be prevented by calling event.preventDefault.
        static member inline forceMount ( value : bool ) : 'Property = Interop.mkProperty "forceMount" value
        /// The preferred side of the anchor to render against when open. Will be reversed when collisions occur and avoidCollisions is enabled.
        static member inline sideOffset ( value : int ) : 'Property = Interop.mkProperty "sideOffset" value
        /// The preferred alignment against the anchor. May change when collisions occur.
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

    /// An optional arrow element to render alongside the popover. This can be used to help visually link the anchor with the Popover.Content. Must be rendered inside Popover.Content.
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

    /// The button that closes an open popover.
    type [<Erase>] close<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
