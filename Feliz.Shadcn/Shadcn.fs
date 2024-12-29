namespace Feliz.Shadcn

open Fable.React
open Fable.Core
open Fable.Core.JsInterop
open Feliz

[<AutoOpen; System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
module ShadcnHelpers =
    let inline reactElement (el: ReactElementType) (props: 'a) : ReactElement = import "createElement" "react"
    let inline createElement (el: ReactElementType) (props: 'ControlProperty list) : ReactElement = reactElement el (!!props |> createObj)
    let [<Literal>] ShadcnReact = "shadcn-react"

type [<Erase>] Shadcn =
    static member inline accordion ( props : IAccordionProp list ) = createElement ( import "Accordion" ShadcnReact ) props
    static member inline accordion ( children : ReactElement list ) = Interop.reactElementWithChildren ( import "Accordion" ShadcnReact ) children
    static member inline accordionItem ( props : IAccordionItemProp list ) = createElement ( import "Accordion.Item" ShadcnReact ) props
