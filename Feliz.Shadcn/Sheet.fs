[<AutoOpen>]
module Feliz.Shadcn.Sheet

open Feliz.RadixUI
open Feliz.Lucide
open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz

emitJsStatement () "import * as SheetPrimitive from \"@radix-ui/react-dialog\""

let sheetVariants =
    JSX.cva "fixed z-50 gap-4 bg-background p-6 shadow-lg transition ease-in-out data-[state=closed]:duration-300 data-[state=open]:duration-500 data-[state=open]:animate-in data-[state=closed]:animate-out"
        {|
            variants = {|
                side = {|
                    top = "inset-x-0 top-0 border-b data-[state=closed]:slide-out-to-top data-[state=open]:slide-in-from-top"
                    bottom = "inset-x-0 bottom-0 border-t data-[state=closed]:slide-out-to-bottom data-[state=open]:slide-in-from-bottom"
                    left = "inset-y-0 left-0 h-full w-3/4 border-r data-[state=closed]:slide-out-to-left data-[state=open]:slide-in-from-left sm:max-w-sm"
                    right = "inset-y-0 right-0 h-full w-3/4 border-l data-[state=closed]:slide-out-to-right data-[state=open]:slide-in-from-right sm:max-w-sm"
                |}
                
            |}
            
            defaultVariants = {|
                side = "right"
            |}
        |}
       

// --------------- Sheet -------------- //
type [<Erase>] ISheetProp = interface end
type [<Erase>] sheet =
    inherit Dialog.root<ISheetProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let Sheet ( props : ISheetProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <SheetPrimitive.Root {{...attrs}} {{...sprops}}/>
    """ |> unbox

// --------------- SheetTrigger -------------- //
type [<Erase>] ISheetTriggerProp = interface end
type [<Erase>] sheetTrigger =
    inherit Dialog.trigger<ISheetTriggerProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let SheetTrigger ( props : ISheetTriggerProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <SheetPrimitive.Trigger {{...attrs}} {{...sprops}}/>
    """ |> unbox

// --------------- SheetClose -------------- //
type [<Erase>] ISheetCloseProp = interface end
type [<Erase>] sheetClose =
    inherit Dialog.close<ISheetCloseProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let SheetClose ( props : ISheetCloseProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <SheetPrimitive.Close {{...attrs}} {{...sprops}}/>
    """ |> unbox

// --------------- SheetPortal -------------- //
type [<Erase>] ISheetPortalProp = interface end
type [<Erase>] sheetPortal =
    inherit Dialog.portal<ISheetPortalProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let SheetPortal ( props : ISheetPortalProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <SheetPrimitive.Portal {{...attrs}} {{...sprops}} />
    """ |> unbox

// --------------- SheetOverlay -------------- //
type [<Erase>] ISheetOverlayProp = interface end
type [<Erase>] sheetOverlay =
    inherit Dialog.overlay<ISheetOverlayProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let SheetOverlay ( props : ISheetOverlayProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <SheetPrimitive.Overlay
        className={ JSX.cn [|
            "fixed inset-0 z-50 bg-black/80  data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0"
            properties?className
        |] }
        {{...sprops}} {{...attrs}}
        ref={ref} />
    """ |> unbox

// --------------- SheetContent -------------- //
type [<Erase>] ISheetContentProp = interface end
type [<Erase>] sheetContent =
    inherit Dialog.content<ISheetContentProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let SheetContent ( props : ISheetContentProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, side=\"right\", ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <SheetPortal>
        <SheetOverlay />
        <SheetPrimitive.Content
            ref={ref}
            className={ JSX.cn [|
                (unbox sheetVariants)(properties?side)
                properties?className
            |] }
            {{...sprops}} {{...attrs}}>
            <SheetPrimitive.Close className="absolute right-4 top-4 rounded-sm opacity-70 ring-offset-background transition-opacity hover:opacity-100 focus:outline-none focus:ring-2 focus:ring-ring focus:ring-offset-2 disabled:pointer-events-none data-[state=open]:bg-secondary">
                { Icon.X [ icon.className "h-4 w-4" ] }
                <span className="sr-only">Close</span>
            </SheetPrimitive.Close>
            {properties?children}
        </SheetPrimitive.Content>
    </SheetPortal>
    """ |> unbox

// --------------- SheetHeader -------------- //
type [<Erase>] ISheetHeaderProp = interface end
type [<Erase>] sheetHeader =
    inherit prop<ISheetHeaderProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let SheetHeader ( props : ISheetHeaderProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <div className={ JSX.cn [|
            "flex flex-col space-y-2 text-center sm:text-left"
            properties?className
        |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- SheetFooter -------------- //
type [<Erase>] ISheetFooterProp = interface end
type [<Erase>] sheetFooter =
    inherit prop<ISheetFooterProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let SheetFooter ( props : ISheetFooterProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <div className={ JSX.cn [|
        "flex flex-col-reverse sm:flex-row sm:justify-end sm:space-x-2"
        properties?className
    |] } {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- SheetTitle -------------- //
type [<Erase>] ISheetTitleProp = interface end
type [<Erase>] sheetTitle =
    inherit prop<ISheetTitleProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let SheetTitle ( props : ISheetTitleProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <SheetPrimitive.Title
        ref={ref}
        className={ JSX.cn [|
            "text-lg font-semibold text-foreground"
            properties?className
        |] } {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- SheetDescription -------------- //
type [<Erase>] ISheetDescriptionProp = interface end
type [<Erase>] sheetDescription =
    inherit prop<ISheetDescriptionProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let SheetDescription ( props : ISheetDescriptionProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <SheetPrimitive.Description
        ref={ref}
        className={ JSX.cn [|
            "text-sm text-muted-foreground"
            properties?className
        |] } {{...sprops}} {{...attrs}} />
    """ |> unbox