[<AutoOpen>]
module Feliz.Shadcn.Label

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI

emitJsStatement () "import * as LabelPrimitive from \"@radix-ui/react-label\""

let labelVariants =
    JSX.cva "text-sm font-medium leading-none peer-disabled:cursor-not-allowed peer-disabled:opacity-70"
        {||}

// --------------- Label -------------- //
type [<Erase>] ILabelProp = interface end
type [<Erase>] label =
    inherit Label.root<ILabelProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let Label ( props : ILabelProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <LabelPrimitive.Root ref={ref}
        className={ JSX.cn [|
            (unbox labelVariants)()
            properties?className
        |] }
        {{...attrs}} {{...sprops}} />
    """ |> unbox