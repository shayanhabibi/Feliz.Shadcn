namespace Feliz.Lucide

open Fable.Core

type [<Erase>] ILucideIconProp = interface static member svgsInterface : unit = () end
    
[<AutoOpen; System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
module Spec =
    let [<Literal>] LucideIcons = "lucide-react"