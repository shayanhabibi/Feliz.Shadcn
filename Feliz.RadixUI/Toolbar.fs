namespace Feliz.RadixUI

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Interop.Extend
open Browser.Types


/// Contains all the toolbar component parts.
[<RequireQualifiedAccess>]
module [<Erase>] toolbarRoot =
    type [<Erase>] orientation<'Property> =
        static member inline horizontal : 'Property = Interop.mkProperty "orientation" "horizontal"
        static member inline vertical : 'Property = Interop.mkProperty "orientation" "vertical"
        static member inline undefined : 'Property = Interop.mkProperty "orientation" "undefined"

    type [<Erase>] dir<'Property> =
        static member inline ltr : 'Property = Interop.mkProperty "dir" "ltr"
        static member inline rtl : 'Property = Interop.mkProperty "dir" "rtl"

/// A set of two-state buttons that can be toggled on or off.
[<RequireQualifiedAccess>]
module [<Erase>] toolbarToggleGroup =
    type [<Erase>] type'<'Property> =
        static member inline single : 'Property = Interop.mkProperty "type" "single"
        static member inline multiple : 'Property = Interop.mkProperty "type" "multiple"

/// A container for grouping a set of controls, such as buttons, toggle groups or dropdown menus.
[<RequireQualifiedAccess>]
module [<Erase>] Toolbar =
    /// Contains all the toolbar component parts.
    type [<Erase>] root<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// The reading direction of the toolbar. If omitted, inherits globally from DirectionProvider or assumes LTR (left-to-right) reading mode.
        static member inline loop ( value : bool ) : 'Property = Interop.mkProperty "loop" value

    /// A button item.
    type [<Erase>] button<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// A link item.
    type [<Erase>] link<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// A set of two-state buttons that can be toggled on or off.
    type [<Erase>] toggleGroup<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// Determines whether a single or multiple items can be pressed at a time.
        static member inline value ( value : string ) : 'Property = Interop.mkProperty "value" value
        /// The value of the item to show as pressed when initially rendered and type is "single". Use when you do not need to control the state of the items.
        static member inline defaultValue ( value : string ) : 'Property = Interop.mkProperty "defaultValue" value
        /// Event handler called when the pressed state of an item changes and type is "single".
        static member inline onValueChange ( value : (string -> unit) ) : 'Property = Interop.mkProperty "onValueChange" value
        /// Event handler called when the pressed state of an item changes and type is "single".
        static member inline value ( value : string[] ) : 'Property = Interop.mkProperty "value" value
        /// The values of the items to show as pressed when initially rendered and type is "multiple". Use when you do not need to control the state of the items.
        static member inline defaultValue ( value : string[] ) : 'Property = Interop.mkProperty "defaultValue" value
        /// Event handler called when the pressed state of an item changes and type is "multiple".
        static member inline onValueChange ( value : (string[] -> unit) ) : 'Property = Interop.mkProperty "onValueChange" value
        /// Event handler called when the pressed state of an item changes and type is "multiple".
        static member inline disabled ( value : bool ) : 'Property = Interop.mkProperty "disabled" value

    /// An item in the group.
    type [<Erase>] toggleItem<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// A unique value for the item.
        static member inline value ( value : string ) : 'Property = Interop.mkProperty "value" value
        /// When true, prevents the user from interacting with the item.
        static member inline disabled ( value : bool ) : 'Property = Interop.mkProperty "disabled" value

    /// Used to visually separate items in the toolbar.
    type [<Erase>] separator<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
