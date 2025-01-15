[<AutoOpen>]
module Feliz.Shadcn.AspectRatio

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI.Interface

emitJsStatement () "import * as AspectRatioPrimitive from \"@radix-ui/react-aspect-ratio\""

// --------------- AspectRatio -------------- //
type [<Erase>] IAspectRatioProp = interface end
type [<Erase>] aspectRatio =
    inherit AspectRatio.root<IAspectRatioProp>
    static member private noop = ()
    // static member inline ratio ( value : float ) : IAspectRatioProp = Interop.mkProperty "ratio" value

let AspectRatio : JSX.ElementType = JSX.jsx "AspectRatioPrimitive.Root"

type [<Erase>] Shadcn =
    static member inline AspectRatio ( props : IAspectRatioProp list ) = JSX.createElement AspectRatio props
    static member inline AspectRatio ( props : ReactElement list ) = JSX.createElementWithChildren AspectRatio props