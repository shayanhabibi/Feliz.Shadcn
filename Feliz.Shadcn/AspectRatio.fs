[<AutoOpen>]
module Feliz.Shadcn.AspectRatio

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI.Interface.NoInherit

emitJsStatement () "import * as AspectRatioPrimitive from \"@radix-ui/react-aspect-ratio\""

// --------------- AspectRatio -------------- //
type [<Erase>] IAspectRatioProp = interface static member propsInterface : unit = () end
type [<Erase>] aspectRatio = AspectRatio.root<IAspectRatioProp>

let AspectRatio : JSX.ElementType = JSX.jsx "AspectRatioPrimitive.Root"

type [<Erase>] Shadcn =
    static member inline AspectRatio ( props : IAspectRatioProp list ) = JSX.createElement AspectRatio props
    static member inline AspectRatio ( props : ReactElement list ) = JSX.createElementWithChildren AspectRatio props
    static member inline AspectRatio ( el : ReactElement ) = JSX.createElement AspectRatio [ aspectRatio.asChild true ; aspectRatio.children el ]