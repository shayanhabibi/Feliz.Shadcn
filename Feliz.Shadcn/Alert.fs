[<AutoOpen>]
module Feliz.Shadcn.Alert

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz

/// Class-Variance-Authority variations object for the Alert components.
let alertVariants =
    JSX.cva "bg-background text-foreground"
        {| 
            variants = {|
                variant = {|
                        ``default``="bg-background text-foreground"
                        destructive="border-destructive/50 text-destructive dark:border-destructive [&>svg]:text destructive"
                    |}
            |}
        
            defaultVariants = {|
                variant="default"
            |}
         |}

// ------------- Alert -------------- //

type [<Erase>] IAlertProp = interface end
type [<Erase>] alert =
    inherit prop<IAlertProp>
    static member inline private noop = ignore

[<RequireQualifiedAccess>]
module [<Erase>] alert =
    type [<Erase>] variant =
        static member inline default' : IAlertProp = Interop.mkProperty "variant" "default"
        static member inline destructive : IAlertProp = Interop.mkProperty "variant" "destructive"

/// The Alert Root Component.
[<JSX.Component>]
let Alert ( props : IAlertProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = !!props |> JSX.mkObject
    emitJsStatement properties $"""const {{className, variant="default", ...sprops}} = $0; const {{props, ...attrs}} = $props"""
    JSX.jsx $"""
    <div ref={ref} role="alert" className={JSX.cn [|
        (unbox alertVariants)({|variant=properties?variant|})
        properties?className
    |]} {{...sprops}} {{...attrs}} />
    """ |> unbox

// ------------ AlertTitle ----------- //
type [<Erase>] IAlertTitleProp = interface end
type [<Erase>] alertTitle =
    inherit prop<IAlertTitleProp>
    static member inline private noop = ignore

/// The Alert Title Component
[<JSX.Component>]
let AlertTitle ( props : IAlertTitleProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = !!props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props"
    JSX.jsx $"""
    <h5 ref={ref}
        className={ JSX.cn [| "mb-1 font-medium leading-none tracking-tight" ; properties?className |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox

// ------------- AlertDescription ------------- //
type [<Erase>] IAlertDescriptionProp = interface end
type [<Erase>] alertDescription =
    inherit prop<IAlertDescriptionProp>
    static member inline private noop = ignore

/// The Alert Description Component
[<JSX.Component>]
let AlertDescription ( props : IAlertDescriptionProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = !!props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props"
    JSX.jsx $"""
    <div ref={ref}
        className={ JSX.cn [| "text-sm [&_p]:leading-relaxed" ; properties?className |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox