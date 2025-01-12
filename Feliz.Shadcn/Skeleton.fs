[<AutoOpen>]
module Feliz.Shadcn.Skeleton

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz

// --------------- Skeleton -------------- //
type [<Erase>] ISkeletonProp = interface end
type [<Erase>] skeleton =
    inherit prop<ISkeletonProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let Skeleton ( props : ISkeletonProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <div className={ JSX.cn [|
        "animate-pulse rounded-md bg-primary/10"
        properties?className
    |] } {{...sprops}} {{...attrs}} />
    """ |> unbox