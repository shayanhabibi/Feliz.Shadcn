namespace Feliz.RadixUI

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Interop.Extend
open Browser.Types


/// Contains all the parts of a navigation menu.
[<RequireQualifiedAccess>]
module [<Erase>] navigationMenuRoot =
    type [<Erase>] dir<'Property> =
        static member inline ltr : 'Property = Interop.mkProperty "dir" "ltr"
        static member inline rtl : 'Property = Interop.mkProperty "dir" "rtl"

    type [<Erase>] orientation<'Property> =
        static member inline horizontal : 'Property = Interop.mkProperty "orientation" "horizontal"
        static member inline vertical : 'Property = Interop.mkProperty "orientation" "vertical"

/// Signifies a submenu. Use it in place of the root part when nested to create a submenu.
[<RequireQualifiedAccess>]
module [<Erase>] navigationMenuSub =
    type [<Erase>] orientation<'Property> =
        static member inline horizontal : 'Property = Interop.mkProperty "orientation" "horizontal"
        static member inline vertical : 'Property = Interop.mkProperty "orientation" "vertical"

/// A collection of links for navigating websites.
[<RequireQualifiedAccess>]
module [<Erase>] NavigationMenu =
    /// Contains all the parts of a navigation menu.
    type [<Erase>] root<'Property> =
        inherit prop<'Property>
        /// The value of the menu item that should be active when initially rendered. Use when you do not need to control the value state.
        static member inline defaultValue ( value : string ) : 'Property = Interop.mkProperty "defaultValue" value
        /// The controlled value of the menu item to activate. Should be used in conjunction with onValueChange.
        static member inline value ( value : string ) : 'Property = Interop.mkProperty "value" value
        /// Event handler called when the value changes.
        static member inline onValueChange ( value : (string -> unit) ) : 'Property = Interop.mkProperty "onValueChange" value
        /// Event handler called when the value changes.
        static member inline delayDuration ( value : int ) : 'Property = Interop.mkProperty "delayDuration" value
        /// How much time a user has to enter another trigger without incurring a delay again.
        static member inline skipDelayDuration ( value : int ) : 'Property = Interop.mkProperty "skipDelayDuration" value

    /// Signifies a submenu. Use it in place of the root part when nested to create a submenu.
    type [<Erase>] sub<'Property> =
        inherit prop<'Property>
        /// The orientation of the menu.
        static member inline defaultValue ( value : string ) : 'Property = Interop.mkProperty "defaultValue" value
        /// The controlled value of the sub menu item to activate. Should be used in conjunction with onValueChange.
        static member inline value ( value : string ) : 'Property = Interop.mkProperty "value" value
        /// Event handler called when the value changes.
        static member inline onValueChange ( value : (string -> unit) ) : 'Property = Interop.mkProperty "onValueChange" value

    /// Contains the top level menu items.
    type [<Erase>] list'<'Property> =
        inherit prop<'Property>
        /// The orientation of the menu.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// A top level menu item, contains a link or trigger with content combination.
    type [<Erase>] item<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// A unique value that associates the item with an active value when the navigation menu is controlled. This prop is managed automatically when uncontrolled.
        static member inline value ( value : string ) : 'Property = Interop.mkProperty "value" value

    /// The button that toggles the content.
    type [<Erase>] trigger<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// Contains the content associated with each trigger.
    type [<Erase>] content<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// Event handler called when the escape key is down. It can be prevented by calling event.preventDefault.
        static member inline onEscapeKeyDown ( value : (Browser.Types.KeyboardEvent -> unit) ) : 'Property = Interop.mkProperty "onEscapeKeyDown" value
        /// Event handler called when the escape key is down. It can be prevented by calling event.preventDefault.
        static member inline onPointerDownOutside ( value : (PointerEvent -> unit) ) : 'Property = Interop.mkProperty "onPointerDownOutside" value
        /// Event handler called when a pointer event occurs outside the bounds of the component. It can be prevented by calling event.preventDefault.
        static member inline onFocusOutside ( value : (FocusEvent -> unit) ) : 'Property = Interop.mkProperty "onFocusOutside" value
        /// Event handler called when focus moves outside the bounds of the component. It can be prevented by calling event.preventDefault.
        static member inline onInteractOutside ( value : (Browser.Types.FocusEvent -> unit) ) : 'Property = Interop.mkProperty "onInteractOutside" value
        /// Event handler called when focus moves outside the bounds of the component. It can be prevented by calling event.preventDefault.
        static member inline onInteractOutside ( value : (Browser.Types.MouseEvent -> unit) ) : 'Property = Interop.mkProperty "onInteractOutside" value
        /// Event handler called when focus moves outside the bounds of the component. It can be prevented by calling event.preventDefault.
        static member inline onInteractOutside ( value : (Browser.Types.TouchEvent -> unit) ) : 'Property = Interop.mkProperty "onInteractOutside" value
        /// Event handler called when an interaction (pointer or focus event) happens outside the bounds of the component. It can be prevented by calling event.preventDefault.
        static member inline forceMount ( value : bool ) : 'Property = Interop.mkProperty "forceMount" value

    /// A navigational link.
    type [<Erase>] link<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// Used to identify the link as the currently active page.
        static member inline active ( value : bool ) : 'Property = Interop.mkProperty "active" value
        /// Event handler called when the user selects a link (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the navigation menu from closing when selecting that link.
        static member inline onSelect ( value : (Browser.Types.Event -> unit) ) : 'Property = Interop.mkProperty "onSelect" value

    /// An optional indicator element that renders below the list, is used to highlight the currently active trigger.
    type [<Erase>] indicator<'Property> =
        inherit prop<'Property>
        /// Event handler called when the user selects a link (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the navigation menu from closing when selecting that link.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries.
        static member inline forceMount ( value : bool ) : 'Property = Interop.mkProperty "forceMount" value

    /// An optional viewport element that is used to render active content outside of the list.
    type [<Erase>] viewport<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries.
        static member inline forceMount ( value : bool ) : 'Property = Interop.mkProperty "forceMount" value
