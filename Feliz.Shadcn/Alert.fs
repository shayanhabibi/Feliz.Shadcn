[<AutoOpen>]
module Feliz.Shadcn.Alert

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz

// Nil imports

// ------------- Alert -------------- //

type [<Erase>] IAlertProp = interface end
type [<Erase>] alert =
    inherit prop<IAlertProp>
    static member inline private noop = ignore

[<RequireQualifiedAccess>]
module [<Erase>] alert =
    type [<Erase>] variant =
        static member inline default' : IAlertProp = Interop.mkProperty "cvavariant" "bg-background text-foreground"
        static member inline destructive : IAlertProp = Interop.mkProperty "cvavariant" "border-destructive/50 text-destructive dark:border-destructive [&>svg]:text-destructive"

[<JSX.Component>]
let Alert ( props : IAlertProp list ) : JSX.Element =
    let ref = React.useRef()
    let properties = !!props |> createObj
    emitJsStatement properties $"""const {{className, cvavariant="bg-background text-foreground", ...props}} = $0"""
    JSX.jsx $"""
    <div ref={ref} role="alert" className={JSX.cn [|
        "relative w-full rounded-lg border px-4 py-3 text-sm [&>svg+div]:translate-y-[-3px] [&>svg]:absolute [&>svg]:left-4 [&>svg]:top-4 [&>svg]:text-foreground [&>svg~*]:pl-7"
        properties?cvavariant
        properties?className
    |]} {{...props}} />
    """
let RAlert = Alert >> JSX.toReact

// ------------ AlertTitle ----------- //
type [<Erase>] IAlertTitleProp = interface end
type [<Erase>] alertTitle =
    inherit prop<IAlertTitleProp>
    static member inline private noop = ignore

[<JSX.Component>]
let AlertTitle ( props : IAlertTitleProp list ) : JSX.Element =
    let ref = React.useRef()
    let properties = !!props |> createObj
    emitJsStatement properties "const {className, ...props} = $0"
    JSX.jsx $"""
    <h5 ref={ref}
        className={ JSX.cn [| "mb-1 font-medium leading-none tracking-tight" ; properties?className |] }
        {{...props}} />
    """
let RAlertTitle = AlertTitle >> JSX.toReact

// ------------- AlertDescription ------------- //
type [<Erase>] IAlertDescriptionProp = interface end
type [<Erase>] alertDescription =
    inherit prop<IAlertDescriptionProp>
    static member inline private noop = ignore

[<JSX.Component>]
let AlertDescription ( props : IAlertDescriptionProp list ) : JSX.Element =
    let ref = React.useRef()
    let properties = !!props |> createObj
    emitJsStatement properties "const {className, ...props} = $0"
    JSX.jsx $"""
    <div ref={ref}
        className={ JSX.cn [| "text-sm [&_p]:leading-relaxed" ; properties?className |] }
        {{...props}} />
    """
let RAlertDescription = AlertDescription >> JSX.toReact