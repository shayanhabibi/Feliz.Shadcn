namespace Feliz.RadixUI

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Interop.Extend
open Browser.Types


/// A control that allows the user to toggle between checked and not checked.
[<RequireQualifiedAccess>]
module [<Erase>] Checkbox =
    /// Contains all the parts of a checkbox. An input will also render when used within a form to ensure events propagate correctly.
    type [<Erase>] root<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// The checked state of the checkbox when it is initially rendered. Use when you do not need to control its checked state.
        static member inline defaultChecked ( value : bool ) : 'Property = Interop.mkProperty "defaultChecked" value
        /// The checked state of the checkbox when it is initially rendered. Use when you do not need to control its checked state.
        static member inline defaultChecked ( value : string ) : 'Property = Interop.mkProperty "defaultChecked" value
        /// The controlled checked state of the checkbox. Must be used in conjunction with onCheckedChange.
        static member inline checked' ( value : bool ) : 'Property = Interop.mkProperty "checked" value
        /// The controlled checked state of the checkbox. Must be used in conjunction with onCheckedChange.
        static member inline checked' ( value : string ) : 'Property = Interop.mkProperty "checked" value
        /// Event handler called when the checked state of the checkbox changes.
        static member inline onCheckedChange ( value : (bool -> unit) ) : 'Property = Interop.mkProperty "onCheckedChange" value
        /// Event handler called when the checked state of the checkbox changes.
        static member inline onCheckedChange ( value : (string -> unit) ) : 'Property = Interop.mkProperty "onCheckedChange" value
        /// Event handler called when the checked state of the checkbox changes.
        static member inline disabled ( value : bool ) : 'Property = Interop.mkProperty "disabled" value
        /// When true, indicates that the user must check the checkbox before the owning form can be submitted.
        static member inline required ( value : bool ) : 'Property = Interop.mkProperty "required" value
        /// The name of the checkbox. Submitted with its owning form as part of a name/value pair.
        static member inline name ( value : string ) : 'Property = Interop.mkProperty "name" value
        /// The value given as data when submitted with a name.
        static member inline value ( value : string ) : 'Property = Interop.mkProperty "value" value

    /// Renders when the checkbox is in a checked or indeterminate state. You can style this element directly, or you can use it as a wrapper to put an icon into, or both.
    type [<Erase>] indicator<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries.
        static member inline forceMount ( value : bool ) : 'Property = Interop.mkProperty "forceMount" value
