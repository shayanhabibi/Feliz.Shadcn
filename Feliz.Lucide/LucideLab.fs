namespace Feliz.Lucide

open Feliz.Interop.Extend
open Feliz.Lucide.Lucide
open Fable.Core.JsInterop
open Fable.React

[<AutoOpen; System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
module LucideLabHelpers =

    let inline reactElement (el: ReactElementType) (props: 'a) : ReactElement = import "createElement" "react"

    let inline createElement (el: ReactElementType) (props: 'ControlProperty list) : ReactElement = reactElement el (!!props |> createObj)
    
    let [<Literal>] LucideIconsLab = "@lucide/lab"
    
module Lab =
    type Icon with static member inline icon (props : ILucideIconProp list) = createElement ( import "Icon" LucideIcons ) props
    type icon with static member inline iconNode ( value : string ) = Interop.mkProperty<ILucideIconProp> "iconNode" ( import value LucideIconsLab )