namespace Feliz.Interop.Extend

open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<RequireQualifiedAccess>]
type [<Erase>] JSX =
    static member inline reactElement (el: JSX.ElementType) (props: 'a) : ReactElement = import "createElement" "react"
    static member inline createElement (el: JSX.ElementType) (props: 'ControlProperty list) : ReactElement = JSX.reactElement el (!!props |> createObj)
    static member inline createElementWithChildren (el: JSX.ElementType) (children : ReactElement list) : ReactElement = Interop.reactElementWithChildren !!el children
    // Interop helpers for JSX & Feliz
    /// Converts a JSX.Element into a ReactElement
    static member inline toReact ( el : JSX.Element ) : ReactElement = unbox el
    /// Converts a ReactElement into a JSX.Element
    static member inline toJSX ( el : ReactElement ) : JSX.Element = unbox el
    /// Converts a list of Feliz compatible style properties into a JSX.Element compatible object
    static member inline toStyle ( styles : IStyleAttribute list ) : obj = createObj ( unbox styles )
    /// Given a list of tuple classes and switches, returns the sum of their parts if the switch is true
    static member inline toClass ( classes : ( string * bool ) list ) : string =
        classes
        |> List.choose ( fun ( c , b ) ->
            match c.Trim(), b with
            | "", _
            | _, false -> None
            | c, true -> Some c)
        |> String.concat " "
    /// JS - checks if obj has key
    [<Emit("$0 in $1")>]
    static member inline isKeyIn (key : string) (o : obj): bool = jsNative
    /// JS - removes key from obj
    [<Emit("delete $1[$0]")>]
    static member inline deleteKeyFrom (key: string) (o: obj): unit = jsNative
    
    /// Binding to 'clsx'. Requires 'npm clsx' dependency.
    [<Import("clsx", "clsx")>]
    static member inline clsx ([<ParamList>] inputs : string []) : string = jsNative
    /// Binding to 'twMerge'. Requires 'npm tailwind-merge' dependency
    [<Import("twMerge","tailwind-merge")>]
    static member inline twMerge ( classes : string ) : string = jsNative
    /// Shortcut/Common pattern alias. Pipes inputs to clsx and then twMerge.
    static member inline cn ([<ParamList>] inputs : string []) : string =
        JSX.clsx inputs |> JSX.twMerge
    /// Defines a class-variance object. See the docs for npm 'class-variance-authority' for usage.
    /// Requires the base class to be applied to all variants, followed with an anonymous record
    /// depicting the schema as per the CVA docs.
    /// Call site should unbox the definition before providing args eg: `(unbox variants)({|variant="shadow"|})
    [<Import("cva", "class-variance-authority")>]
    static member inline cva ( initial : string ) ( config : 'a ) : string = jsNative
    /// Takes a list argument and determines whether to make an empty object or is able to marshall into an object
    /// in a JS compatible manner.
    static member inline mkObject ( fields : 'a list ) : obj =
        match unbox fields with
        | null -> createEmpty
        | _ -> !!fields |> createObj
    /// Injects helper functions
    [<Emit("""
    import * as React from "react";
    import { clsx } from "clsx";
    import { twMerge } from "tailwind-merge";
    function cn(...inputs) {
      return twMerge(clsx(inputs));
    }
    """)>]        
    static member inline injectLib : unit = jsNative
    