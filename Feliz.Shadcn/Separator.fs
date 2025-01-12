[<AutoOpen>]
module Feliz.Shadcn.Separator

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI

emitJsStatement () "import * as SeparatorPrimitive from \"@radix-ui/react-separator\""

// --------------- Separator -------------- //
type [<Erase>] ISeparatorProp = interface end
type [<Erase>] separator =
    inherit Separator.root<ISeparatorProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let Separator ( props : ISeparatorProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, orientation=\"horizontal\", decorative=true, ...sprops} = $0; const {props, ...attrs} = $props;"
    let orientation = emitJsStatement () "{ orientation }" |> unbox<string>
    let orientationClass =
        match orientation with
        | "horizontal" -> "h-[1px] w-full"
        | _ -> "h-full w-[1px]"
        
    JSX.jsx $"""
    <SeparatorPrimitive.Root
        ref={ref}
        decorative={properties?decorative}
        orientation={properties?orientation}
        className={ JSX.cn [|
            "shrink-0 bg-border"
            orientationClass
            properties?className
        |] } {{...sprops}} {{...attrs}} />
    """ |> unbox
