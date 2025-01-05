[<AutoOpen>]
module Feliz.Shadcn.Card

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz

// --------------- Card -------------- //
type [<Erase>] ICardProp = interface end
type [<Erase>] card =
    inherit prop<ICardProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let Card ( props : ICardProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <div ref={ref}
        className={ JSX.cn [|
            "rounded-xl border bg-card text-card-foreground shadow"
            properties?className
        |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- CardHeader -------------- //
type [<Erase>] ICardHeaderProp = interface end
type [<Erase>] cardHeader =
    inherit prop<ICardHeaderProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let CardHeader ( props : ICardHeaderProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <div ref={ref}
        className={ JSX.cn [|
            "flex flex-col space-y-1.5 p-6"
            properties?className
        |] } />
    """ |> unbox

// --------------- CardTitle -------------- //
type [<Erase>] ICardTitleProp = interface end
type [<Erase>] cardTitle =
    inherit prop<ICardTitleProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let CardTitle ( props : ICardTitleProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <div  ref={ref}
        className={ JSX.cn [| "font-semibold leadning-none tracking-tight" ; properties?className |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- CardDescription -------------- //
type [<Erase>] ICardDescriptionProp = interface end
type [<Erase>] cardDescription =
    inherit prop<ICardDescriptionProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let CardDescription ( props : ICardDescriptionProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <div ref={ref}
        className={ JSX.cn [| "text-sm text-muted-foreground" ; properties?className |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- CardContent -------------- //
type [<Erase>] ICardContentProp = interface end
type [<Erase>] cardContent =
    inherit prop<ICardContentProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let CardContent ( props : ICardContentProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <div ref={ref} className={ JSX.cn [| "p-6 pt-0" ; properties?className |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- CardFooter -------------- //
type [<Erase>] ICardFooterProp = interface end
type [<Erase>] cardFooter =
    inherit prop<ICardFooterProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let CardFooter ( props : ICardFooterProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <div
        ref={ref}
        className={ JSX.cn [| "flex items-center p-6 pt-0" ; properties?className |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox