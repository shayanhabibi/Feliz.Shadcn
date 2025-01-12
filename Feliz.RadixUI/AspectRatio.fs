namespace Feliz.RadixUI

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Interop.Extend
open Browser.Types


/// Displays content within a desired ratio.
[<RequireQualifiedAccess>]
module [<Erase>] AspectRatio =
    /// Contains the content you want to constrain to a given ratio.
    type [<Erase>] root<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// The desired ratio
        static member inline ratio ( value : int ) : 'Property = Interop.mkProperty "ratio" value
