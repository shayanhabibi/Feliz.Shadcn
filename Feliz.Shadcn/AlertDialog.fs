[<AutoOpen>]
module Feliz.Shadcn.AlertDialog

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI

emitJsStatement () "import * as AlertDialogPrimitive from \"@radix-ui/react-alert-dialog\""

let buttonVariants = Feliz.Shadcn.Button.buttonVariants
// Alternative if you want styling different to your button variants, the same definition:
// let buttonVariants =
//     JSX.cva "inline-flex items-center justify-center gap-2 whitespace-nowrap rounded-md text-sm font-medium transition-colors focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:pointer-events-none disabled:opacity-50 [&_svg]:pointer-events-none [&_svg]:size-4 [&_svg]:shrink-0"
//         {|
//             variants = {|
//                 variant = {|
//                    ``default``= "bg-primary text-primary-foreground shadow hover:bg-primary/90"
//                    destructive = "bg-destructive text-destructive-foreground shadow-sm hover:bg-destructive/90"
//                    outline = "border border-input bg-background shadow-sm hover:bg-accent hover:text-accent-foreground"
//                    secondary = "bg-secondary text-secondary-foreground shadow-sm hover:bg-secondary/80"
//                    ghost = "hover:bg-accent hover:text-accent-foreground"
//                    link = "text-primary underline-offset-4 hover:underline"
//                 |}
//                 size = {|
//                     ``default`` = "h-9 px-4 py-2"
//                     sm = "h-8 rounded-md px-3 text-xs"
//                     lg = "h-10 rounded-md px-8"
//                     icon = "h-9 w-9"
//                 |}
//                
//             |}
//                   
//             defaultVariants = {|
//                 variant = "default"
//                 size = "default"
//             |}
//         |}


// --------------- AlertDialog -------------- //
type [<Erase>] IAlertDialogProp = interface end
type [<Erase>] alertDialog =
    inherit Dialog.root<IAlertDialogProp>
    static member private noop = ()
    // static member inline open' ( value : bool ) : IAlertDialogProp = Interop.mkProperty "open" value
    // static member inline defaultOpen ( value : bool ) : IAlertDialogProp = Interop.mkProperty "defaultOpen" value
    // static member inline modal ( value : bool ) : IAlertDialogProp = Interop.mkProperty "modal" value
    // static member inline onOpenChange ( handler : bool -> unit ) : IAlertDialogProp = Interop.mkProperty "onOpenChange" handler

[<JSX.Component>]
let AlertDialog ( props : IAlertDialogProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <AlertDialogPrimitive.Root {{...sprops}} {{...attrs}}/>
    """ |> unbox

// --------------- AlertDialogTrigger -------------- //
type [<Erase>] IAlertDialogTriggerProp = interface end
type [<Erase>] alertDialogTrigger =
    inherit Dialog.trigger<IAlertDialogTriggerProp>
    static member inline private noop = ignore

[<JSX.Component>]
let AlertDialogTrigger ( props : IAlertDialogTriggerProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props"
    JSX.jsx $"""
    <AlertDialogPrimitive.Trigger {{...sprops}} {{...attrs}} ref={ref}/>
    """ |> unbox

// --------------- AlertDialogPortal -------------- //
type [<Erase>] IAlertDialogPortalProp = interface end
type [<Erase>] alertDialogPortal =
    inherit Dialog.portal<IAlertDialogPortalProp>
    static member private noop = ()
    // static member inline container ( value : 'a ) : IAlertDialogPortalProp = Interop.mkProperty "container" value
    // static member inline forceMount ( value : bool ) : IAlertDialogPortalProp = Interop.mkProperty "forceMount" value
    
[<JSX.Component>]
let AlertDialogPortal ( props : IAlertDialogPortalProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0"
    JSX.jsx $"""
    <AlertDialogPrimitive.Portal {{...$props}} {{...sprops}}/>
    """ |> unbox

// --------------- AlertDialogOverlay -------------- //
type [<Erase>] IAlertDialogOverlayProp = interface end
type [<Erase>] alertDialogOverlay =
    inherit Dialog.overlay<IAlertDialogOverlayProp>
    static member private noop = ()
    // static member inline forceMount ( value : bool ) : IAlertDialogOverlayProp = Interop.mkProperty "forceMount" value

[<JSX.Component>]
let AlertDialogOverlay ( props : IAlertDialogOverlayProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0 ; const { props , ...attrs } = $props"
    JSX.jsx $"""
    <AlertDialogPrimitive.Overlay
        className={JSX.cn [|
            "fixed inset-0 z-50 bg-black/80 data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0"
            properties?className
        |] }
        ref={ref}
        {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- AlertDialogContent -------------- //
type [<Erase>] IAlertDialogContentProp = interface end
type [<Erase>] alertDialogContent =
    inherit Dialog.content<IAlertDialogContentProp>
    static member private noop = ()
    // static member inline forceMount ( value : bool ) : IAlertDialogContentProp = Interop.mkProperty "forceMount" value
    // static member inline trapFocus ( value : bool ) : IAlertDialogContentProp = Interop.mkProperty "trapFocus" value
    // static member inline onOpenAutoFocus ( handler : Browser.Types.Event -> unit ) : IAlertDialogContentProp = Interop.mkProperty "onOpenAutoFocus" handler
    // static member inline onCloseAutoFocus ( handler : Browser.Types.Event -> unit ) : IAlertDialogContentProp = Interop.mkProperty "onCloseAutoFocus" handler

[<JSX.Component>]
let AlertDialogContent ( props : IAlertDialogContentProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0"
    JSX.jsx $"""
    <AlertDialogPortal>
        <AlertDialogOverlay />
        <AlertDialogPrimitive.Content
            ref={ref}
            className={ JSX.cn [|
                "fixed left-[50%] top-[50%] z-50 grid w-full max-w-lg translate-x-[-50%] translate-y-[-50%] gap-4 border bg-background p-6 shadow-lg duration-200 data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0 data-[state=closed]:zoom-out-95 data-[state=open]:zoom-in-95 data-[state=closed]:slide-out-to-left-1/2 data-[state=closed]:slide-out-to-top-[48%] data-[state=open]:slide-in-from-left-1/2 data-[state=open]:slide-in-from-top-[48%] sm:rounded-lg"
                properties?className
            |] }
            {{...sprops}} />
    </AlertDialogPortal>
    """ |> unbox

// --------------- AlertDialogHeader -------------- //
type [<Erase>] IAlertDialogHeaderProp = interface end
type [<Erase>] alertDialogHeader =
    inherit prop<IAlertDialogHeaderProp>
    static member inline private noop = ignore

[<JSX.Component>]
let AlertDialogHeader ( props : IAlertDialogHeaderProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0"
    JSX.jsx $"""
    <div className={ JSX.cn [| "flex flex-col space-y-2 text-center sm:text-left" ; properties?className |] }
        {{...sprops}}/>
    """ |> unbox

// --------------- AlertDialogFooter -------------- //
type [<Erase>] IAlertDialogFooterProp = interface end
type [<Erase>] alertDialogFooter =
    inherit prop<IAlertDialogFooterProp>
    static member inline private noop = ignore

[<JSX.Component>]
let AlertDialogFooter ( props : IAlertDialogFooterProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0"
    JSX.jsx $"""
    <div
        className={ JSX.cn [|
            "flex flex-col-reverse sm:flex-row sm:justify-end sm:space-x-2"
            properties?className
        |] }
        {{...sprops}} />
    """ |> unbox

// --------------- AlertDialogTitle -------------- //
type [<Erase>] IAlertDialogTitleProp = interface end
type [<Erase>] alertDialogTitle =
    inherit prop<IAlertDialogTitleProp>
    static member inline private noop = ignore

[<JSX.Component>]
let AlertDialogTitle ( props : IAlertDialogTitleProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0"
    JSX.jsx $"""
    <AlertDialogPrimitive.Title ref={ref} className={ JSX.cn [| "text-lg font-semibold" ; properties?className |] } {{...sprops}}/>
    """ |> unbox

// --------------- AlertDialogDescription -------------- //
type [<Erase>] IAlertDialogDescriptionProp = interface end
type [<Erase>] alertDialogDescription =
    inherit prop<IAlertDialogDescriptionProp>
    static member inline private noop = ignore

[<JSX.Component>]
let AlertDialogDescription ( props : IAlertDialogDescriptionProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0"
    JSX.jsx $"""
    <AlertDialogPrimitive.Description
        ref={ref}
        className={ JSX.cn [| "text-sm text-muted-foreground" ; properties?className |] }
        {{...sprops}} />
    """ |> unbox

// --------------- AlertDialogAction -------------- //
type [<Erase>] IAlertDialogActionProp = interface end
type [<Erase>] alertDialogAction =
    inherit prop<IAlertDialogActionProp>
    static member inline private noop = ignore

[<JSX.Component>]
let AlertDialogAction ( props : IAlertDialogActionProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0"
    JSX.jsx $"""
    <AlertDialogPrimitive.Action
        ref={ref}
        className={ JSX.cn [| (unbox buttonVariants)() ; properties?className |] }
        {{...sprops}} />
    """ |> unbox

// --------------- AlertDialogCancel -------------- //
type [<Erase>] IAlertDialogCancelProp = interface end
type [<Erase>] alertDialogCancel =
    inherit prop<IAlertDialogCancelProp>
    static member inline private noop = ignore

[<JSX.Component>]
let AlertDialogCancel ( props : IAlertDialogCancelProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0"
    JSX.jsx $"""
    <AlertDialogPrimitive.Cancel
        ref={ref}
        className={ JSX.cn [|
            (unbox buttonVariants)({|variant="outline"|}) ; "mt-2 sm:mt-0" ; properties?className
        |] }
        {{...sprops}} />
    """ |> unbox