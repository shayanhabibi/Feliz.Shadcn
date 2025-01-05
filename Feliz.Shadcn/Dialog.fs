[<AutoOpen>]
module Feliz.Shadcn.Dialog

open Browser.Types
open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI

emitJsStatement () "import * as DialogPrimitive from \"@radix-ui/react-dialog\""

// --------------- Dialog -------------- //
type [<Erase>] IDialogProp = interface end
type [<Erase>] dialog =
    inherit Dialog.root<IDialogProp>
    static member inline open' ( value : bool ) : IDialogProp = Interop.mkProperty "open" value
    static member inline defaultOpen ( value : bool ) : IDialogProp = Interop.mkProperty "defaultOpen" value
    static member inline onOpenChange ( handler : bool -> unit ) : IDialogProp = Interop.mkProperty "onOpenChange" handler
    static member inline modal ( value : bool ) : IDialogProp = Interop.mkProperty "modal" value

[<JSX.Component>]
let Dialog ( props : IDialogProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <DialogPrimitive.Root {{...sprops}} {{...attrs}}/>
    """ |> unbox

// --------------- DialogTrigger -------------- //
type [<Erase>] IDialogTriggerProp = interface end
type [<Erase>] dialogTrigger =
    inherit Dialog.trigger<IDialogTriggerProp>
    static member noop = ()

[<JSX.Component>]
let DialogTrigger ( props : IDialogTriggerProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <DialogPrimitive.Trigger {{...sprops}} {{...attrs}} />
    """ |> unbox
    
// --------------- DialogPortal -------------- //
type [<Erase>] IDialogPortalProp = interface end
type [<Erase>] dialogPortal =
    inherit Dialog.portal<IDialogPortalProp>
    static member private noop = ()
    // static member inline container ( value : HTMLElement ) : IDialogPortalProp = Interop.mkProperty "container" value
    // static member inline forceMount ( value : bool ) : IDialogPortalProp = Interop.mkProperty "forceMount" value

[<JSX.Component>]
let DialogPortal ( props : IDialogPortalProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <DialogPrimitive.Portal {{...sprops}} {{...attrs}} />
    """ |> unbox
    
// --------------- DialogClose -------------- //
type [<Erase>] IDialogCloseProp = interface end
type [<Erase>] dialogClose =
    inherit Dialog.close<IDialogCloseProp>
    static member private noop : unit = ()

[<JSX.Component>]
let DialogClose ( props : IDialogCloseProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <DialogPrimitive.Close {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- DialogOverlay -------------- //
type [<Erase>] IDialogOverlayProp = interface end
type [<Erase>] dialogOverlay =
    inherit Dialog.overlay<IDialogOverlayProp>
    static member private noop = ()
    // static member inline forceMount ( value : bool ) : IDialogOverlayProp = Interop.mkProperty "forceMount" value

[<JSX.Component>]
let DialogOverlay ( props : IDialogOverlayProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <DialogPrimitive.Overlay
        ref={ref}
        className={ JSX.cn [|
            "fixed inset-0 z-50 bg-black/80  data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0"
            properties?className
        |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox
    
// --------------- DialogContent -------------- //
type [<Erase>] IDialogContentProp = interface end
type [<Erase>] dialogContent =
    inherit Dialog.content<IDialogContentProp>
    static member private noop = ()
    // static member inline forceMount ( value : bool ) : IDialogContentProp = Interop.mkProperty "forceMount" value

open Feliz.Lucide

[<JSX.Component>]
let DialogContent ( props : IDialogContentProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, children, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <DialogPortal>
        <DialogOverlay />
        <DialogPrimitive.Content
            ref={ref}
            className={ JSX.cn [|
                "fixed left-[50%] top-[50%] z-50 grid w-full max-w-lg translate-x-[-50%] translate-y-[-50%] gap-4 border bg-background p-6 shadow-lg duration-200 data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0 data-[state=closed]:zoom-out-95 data-[state=open]:zoom-in-95 data-[state=closed]:slide-out-to-left-1/2 data-[state=closed]:slide-out-to-top-[48%] data-[state=open]:slide-in-from-left-1/2 data-[state=open]:slide-in-from-top-[48%] sm:rounded-lg"
                properties?className
            |] }
            {{...sprops}} {{...attrs}}>
            {properties?children}
            <DialogPrimitive.Close
                className={JSX.cn[|
                    "absolute right-4 top-4 rounded-sm opacity-70 ring-offset-background transition-opacity hover:opacity-100 focus:outline-none focus:ring-2 focus:ring-ring focus:ring-offset-2 disabled:pointer-events-none data-[state=open]:bg-accent data-[state=open]:text-muted-foreground"
                |]}>
                {Icon.X [icon.className "h-4 w-4"]}
                <span className="sr-only">Close</span>
            </DialogPrimitive.Close>
        </DialogPrimitive.Content>
    </DialogPortal>
    """ |> unbox

// --------------- DialogHeader -------------- //
type [<Erase>] IDialogHeaderProp = interface end
type [<Erase>] dialogHeader =
    inherit prop<IDialogHeaderProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let DialogHeader ( props : IDialogHeaderProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <div
        className={ JSX.cn [|
            "flex flex-col space-y-1.5 text-center sm:text-left"
            properties?className
        |] } {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- DialogFooter -------------- //
type [<Erase>] IDialogFooterProp = interface end
type [<Erase>] dialogFooter =
    inherit prop<IDialogFooterProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let DialogFooter ( props : IDialogFooterProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <div
        className={ JSX.cn [|
            "flex flex-col-reverse sm:flex-row sm:justify-end sm:space-x-2"
            properties?className
        |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- DialogTitle -------------- //
type [<Erase>] IDialogTitleProp = interface end
type [<Erase>] dialogTitle =
    inherit prop<IDialogTitleProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let DialogTitle ( props : IDialogTitleProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <DialogPrimitive.Title
        ref={ref}
        className={ JSX.cn [|
            "text-lg font-semibold leading-none tracking-tight"
            properties?className
        |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- DialogDescription -------------- //
type [<Erase>] IDialogDescriptionProp = interface end
type [<Erase>] dialogDescription =
    inherit prop<IDialogDescriptionProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let DialogDescription ( props : IDialogDescriptionProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <DialogPrimitive.Description
        ref={ref}
        className={ JSX.cn [|
            "text-sm text-muted-foreground"
            properties?className
        |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox