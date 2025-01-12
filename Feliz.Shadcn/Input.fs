[<AutoOpen>]
module Feliz.Shadcn.Input

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz

// --------------- Input -------------- //
type [<Erase>] IInputProp = interface end
type [<Erase>] input =
    inherit prop<IInputProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let Input ( props : IInputProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, type, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <input type={{type}}
        className={ JSX.cn [|
            "flex h-9 w-full rounded-md border border-input bg-transparent px-3 py-1 text-base shadow-sm transition-colors file:border-0 file:bg-transparent file:text-sm file:font-medium file:text-foreground placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50 md:text-sm"
            properties?className
        |] }
        ref={ref}
        {{...sprops}} {{...attrs}} />
    """ |> unbox