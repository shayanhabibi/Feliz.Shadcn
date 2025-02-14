namespace Feliz.RadixUI.Interface.NoInherit
// AUTOGENERATED FILE - these files do not inherit feliz properties at base
open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn.Interop
open Browser.Types


/// Contains all the parts of a radio group.
[<RequireQualifiedAccess>]
module [<Erase>] radioGroupRoot =
    type [<Erase>] orientation<'Property> =
        static member inline horizontal : 'Property = Interop.mkProperty "orientation" "horizontal"
        static member inline vertical : 'Property = Interop.mkProperty "orientation" "vertical"
        static member inline undefined : 'Property = Interop.mkProperty "orientation" "undefined"

    type [<Erase>] dir<'Property> =
        static member inline ltr : 'Property = Interop.mkProperty "dir" "ltr"
        static member inline rtl : 'Property = Interop.mkProperty "dir" "rtl"

/// A set of checkable buttons—known as radio buttons—where no more than one of the buttons can be checked at a time.
[<RequireQualifiedAccess>]
module [<Erase>] RadioGroup =
    /// Contains all the parts of a radio group.
    type [<Erase>] root<'Property> =
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// The value of the radio item that should be checked when initially rendered. Use when you do not need to control the state of the radio items.
        static member inline defaultValue ( value : string ) : 'Property = Interop.mkProperty "defaultValue" value
        /// The controlled value of the radio item to check. Should be used in conjunction with onValueChange.
        static member inline value ( value : string ) : 'Property = Interop.mkProperty "value" value
        /// Event handler called when the value changes.
        static member inline onValueChange ( value : (string -> unit) ) : 'Property = Interop.mkProperty "onValueChange" value
        /// Event handler called when the value changes.
        static member inline disabled ( value : bool ) : 'Property = Interop.mkProperty "disabled" value
        /// The name of the group. Submitted with its owning form as part of a name/value pair.
        static member inline name ( value : string ) : 'Property = Interop.mkProperty "name" value
        /// When true, indicates that the user must check a radio item before the owning form can be submitted.
        static member inline required ( value : bool ) : 'Property = Interop.mkProperty "required" value
        /// The reading direction of the radio group. If omitted, inherits globally from DirectionProvider or assumes LTR (left-to-right) reading mode.
        static member inline loop ( value : bool ) : 'Property = Interop.mkProperty "loop" value

    /// An item in the group that can be checked. An input will also render when used within a form to ensure events propagate correctly.
    type [<Erase>] item<'Property> =
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// The value given as data when submitted with a name.
        static member inline value ( value : string ) : 'Property = Interop.mkProperty "value" value
        /// When true, prevents the user from interacting with the radio item.
        static member inline disabled ( value : bool ) : 'Property = Interop.mkProperty "disabled" value
        /// When true, indicates that the user must check the radio item before the owning form can be submitted.
        static member inline required ( value : bool ) : 'Property = Interop.mkProperty "required" value

    /// Renders when the radio item is in a checked state. You can style this element directly, or you can use it as a wrapper to put an icon into, or both.
    type [<Erase>] indicator<'Property> =
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries.
        static member inline forceMount ( value : bool ) : 'Property = Interop.mkProperty "forceMount" value
