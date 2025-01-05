namespace Feliz.RadixUI

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Interop.Extend
open Browser.Types


/// Displays an indicator showing the completion progress of a task, typically displayed as a progress bar.
module [<Erase>] Progress =
    /// import "Progress" ""
    /// Contains all of the progress parts.
    type [<Erase>] root<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// The progress value.
        static member inline value ( value : int ) : 'Property = Interop.mkProperty "value" value
        /// The maximum progress value.
        static member inline max ( value : int ) : 'Property = Interop.mkProperty "max" value
        /// A function to get the accessible label text representing the current value in a human-readable format. If not provided, the value label will be read as the numeric value as a percentage of the max value.
        static member inline getValueLabel ( value : (int -> int -> string) ) : 'Property = Interop.mkProperty "getValueLabel" value

    /// import "ProgressIndicator" ""
    /// Used to show the progress visually. It also makes progress accessible to assistive technologies.
    type [<Erase>] indicator<'Property> =
        inherit prop<'Property>
        /// A function to get the accessible label text representing the current value in a human-readable format. If not provided, the value label will be read as the numeric value as a percentage of the max value.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
