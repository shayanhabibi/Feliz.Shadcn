namespace Feliz.Lucide

open Feliz.Shadcn
open Fable.Core

type [<Erase>] icons =
    inherit FelizProps.prop<IIconProp>
    static member inline size ( value : int ) = Interop.mkProperty<IIconProp> "size" value
    static member inline color ( value : string ) = Interop.mkProperty<IIconProp> "color" value
    static member inline strokeWidth ( value : int ) = Interop.mkProperty<IIconProp> "strokeWidth" value
    static member inline absoluteStrokeWidth ( value : bool ) = Interop.mkProperty<IIconProp> "absoluteStrokeWidth" value
    