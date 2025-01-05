namespace Feliz.RadixUI

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Interop.Extend
open Browser.Types


/// A control that allows the user to toggle between checked and not checked.
module [<Erase>] Switch =
    /// import "Switch" ""
    /// Contains all the parts of a switch. An input will also render when used within a form to ensure events propagate correctly.
    type [<Erase>] root<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// The state of the switch when it is initially rendered. Use when you do not need to control its state.
        static member inline defaultChecked ( value : bool ) : 'Property = Interop.mkProperty "defaultChecked" value
        /// The controlled state of the switch. Must be used in conjunction with onCheckedChange.
        static member inline checked' ( value : bool ) : 'Property = Interop.mkProperty "checked" value
        /// Event handler called when the state of the switch changes.
        static member inline onCheckedChange ( value : (bool -> unit) ) : 'Property = Interop.mkProperty "onCheckedChange" value
        /// Event handler called when the state of the switch changes.
        static member inline disabled ( value : bool ) : 'Property = Interop.mkProperty "disabled" value
        /// When true, indicates that the user must check the switch before the owning form can be submitted.
        static member inline required ( value : bool ) : 'Property = Interop.mkProperty "required" value
        /// The name of the switch. Submitted with its owning form as part of a name/value pair.
        static member inline name ( value : string ) : 'Property = Interop.mkProperty "name" value
        /// The value given as data when submitted with a name.
        static member inline value ( value : string ) : 'Property = Interop.mkProperty "value" value

    /// import "SwitchThumb" ""
    /// The thumb that is used to visually indicate whether the switch is on or off.
    type [<Erase>] thumb<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
