namespace Feliz.RadixUI

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Interop.Extend
open Browser.Types


/// A two-state button that can be either on or off.
module [<Erase>] Toggle =
    /// import "Toggle" ""
    /// The toggle.
    type [<Erase>] root<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// The pressed state of the toggle when it is initially rendered. Use when you do not need to control its pressed state.
        static member inline defaultPressed ( value : bool ) : 'Property = Interop.mkProperty "defaultPressed" value
        /// The controlled pressed state of the toggle. Must be used in conjunction with onPressedChange.
        static member inline pressed ( value : bool ) : 'Property = Interop.mkProperty "pressed" value
        /// Event handler called when the pressed state of the toggle changes.
        static member inline onPressedChange ( value : (bool -> unit) ) : 'Property = Interop.mkProperty "onPressedChange" value
        /// Event handler called when the pressed state of the toggle changes.
        static member inline disabled ( value : bool ) : 'Property = Interop.mkProperty "disabled" value
