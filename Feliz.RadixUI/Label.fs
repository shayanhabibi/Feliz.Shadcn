namespace Feliz.RadixUI

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Interop.Extend
open Browser.Types


/// Renders an accessible label associated with controls.
[<RequireQualifiedAccess>]
module [<Erase>] Label =
    /// Contains the content for the label.
    type [<Erase>] root<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// The id of the element the label is associated with.
        static member inline htmlFor ( value : string ) : 'Property = Interop.mkProperty "htmlFor" value
