namespace Feliz.Interop.Extend

open Feliz
open Fable.Core
open Fable.Core.JsInterop

type [<Erase>] JSX =
    // Interop helpers for JSX & Feliz
    static member inline toReact ( el : JSX.Element ) : ReactElement = unbox el
    static member inline toJSX ( el : ReactElement ) : JSX.Element = unbox el
    static member inline toStyle ( styles : IStyleAttribute list ) : obj = createObj ( unbox styles )
    static member inline toClass ( classes : ( string * bool ) list ) : string =
        classes
        |> List.choose ( fun ( c , b ) ->
            match c.Trim(), b with
            | "", _
            | _, false -> None
            | c, true -> Some c)
        |> String.concat " "
    [<Emit("$0 in $1")>]
    static member inline isKeyIn (key : string) (o : obj): bool = jsNative
    [<Emit("delete $1[$0]")>]
    static member inline deleteKeyFrom (key: string) (o: obj): unit = jsNative
    // Requires dependencies clsx and twmerge
    [<Import("clsx", "clsx")>]
    static member inline clsx ([<ParamList>] inputs : string []) : string = jsNative
    [<Import("twMerge","tailwind-merge")>]
    static member inline twMerge ( classes : string ) : string = jsNative
    static member inline cn ([<ParamList>] inputs : string []) : string =
        JSX.clsx inputs |> JSX.twMerge
        
        
        