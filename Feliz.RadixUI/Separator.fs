namespace Feliz.RadixUI

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Interop.Extend
open Browser.Types


/// The separator.
[<RequireQualifiedAccess>]
module [<Erase>] separatorRoot =
    type [<Erase>] orientation<'Property> =
        static member inline horizontal : 'Property = Interop.mkProperty "orientation" "horizontal"
        static member inline vertical : 'Property = Interop.mkProperty "orientation" "vertical"

/// Visually or semantically separates content.
[<RequireQualifiedAccess>]
module [<Erase>] Separator =
    /// The separator.
    type [<Erase>] root<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// The orientation of the separator.
        static member inline decorative ( value : bool ) : 'Property = Interop.mkProperty "decorative" value
