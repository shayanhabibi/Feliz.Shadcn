namespace Feliz.Lucide

open Feliz.Shadcn.Interop
open Feliz.Lucide
open Fable.Core

type [<Erase>] icon =
    inherit prop<ILucideIconProp>
    static member inline size ( value : int ) = Interop.mkProperty<ILucideIconProp> "size" value
    static member inline color ( value : string ) = Interop.mkProperty<ILucideIconProp> "color" value
    static member inline strokeWidth ( value : int ) = Interop.mkProperty<ILucideIconProp> "strokeWidth" value
    static member inline absoluteStrokeWidth ( value : bool ) = Interop.mkProperty<ILucideIconProp> "absoluteStrokeWidth" value
    