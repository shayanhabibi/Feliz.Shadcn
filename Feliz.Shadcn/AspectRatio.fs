[<AutoOpen>]
module Feliz.Shadcn.AspectRatio

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI

emitJsStatement () "import * as AspectRatioPrimitive from \"@radix-ui/react-aspect-ratio\""

// --------------- AspectRatio -------------- //
type [<Erase>] IAspectRatioProp = interface end
type [<Erase>] aspectRatio =
    inherit AspectRatio.root<IAspectRatioProp>
    static member private noop = ()
    // static member inline ratio ( value : float ) : IAspectRatioProp = Interop.mkProperty "ratio" value

[<JSX.Component>]
let AspectRatio ( props : IAspectRatioProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <AspectRatioPrimmitive.Root {{...sprops}} {{...attrs}} />
    """ |> unbox
