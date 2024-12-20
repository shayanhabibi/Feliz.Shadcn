namespace Feliz.Shadcn

open Feliz
open Fable.Core.JsInterop
open Fable.React

[<AutoOpen>]
module RadixHelpers =

    let reactElement (el: ReactElementType) (props: 'a) : ReactElement =
        import "createElement" "react"

    let createElement (el: ReactElementType) (properties: IReactProperty seq) : ReactElement =
        reactElement el (!!properties |> createObj)