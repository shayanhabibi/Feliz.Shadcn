[<AutoOpen>]
module Feliz.Shadcn.Drawer

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI

emitJsStatement () "import { Drawer as DrawerPrimitive } from \"vaul\""

// --------------- Drawer -------------- //
type [<Erase>] IDrawerProp = interface end
type [<Erase>] drawer =
    inherit Dialog.root<IDrawerProp>
    static member inline shouldScaleBackground ( value : bool ) : IDrawerProp = Interop.mkProperty "shouldScaleBackground" value
    static member inline activeSnapPoint ( value : int ) : IDrawerProp = Interop.mkProperty "activeSnapPoint" value
    static member inline activeSnapPoint ( value : string ) : IDrawerProp = Interop.mkProperty "activeSnapPoint" value
    static member inline setActiveSnapPoint ( handler : string -> unit ) : IDrawerProp = Interop.mkProperty "setActiveSnapPoint" handler
    static member inline setActiveSnapPoint ( handler : int -> unit ) : IDrawerProp = Interop.mkProperty "setActiveSnapPoint" handler
    static member inline closeThreshold ( value : int ) : IDrawerProp = Interop.mkProperty "closeThreshold" value
    static member inline noBodyStyles ( value : bool ) : IDrawerProp = Interop.mkProperty "noBodyStyles" value
    static member inline setBackgroundColourOnScale ( value : bool ) : IDrawerProp = Interop.mkProperty "setBackgroundColourOnScale" value
    static member inline scrollLockTimeout ( value : int ) : IDrawerProp = Interop.mkProperty "scrollLockTimeout" value
    static member inline fixed' ( value : bool ) : IDrawerProp = Interop.mkProperty "fixed" value
    static member inline handleOnly ( value : bool ) : IDrawerProp = Interop.mkProperty "handleOnly" value
    static member inline dismissible ( value : bool ) : IDrawerProp = Interop.mkProperty "dismissible" value
    static member inline onDrag ( handler : Browser.Types.PointerEvent * int -> unit ) : IDrawerProp = Interop.mkProperty "onDrag" handler
    static member inline onRelease ( handler : Browser.Types.PointerEvent * bool -> unit ) : IDrawerProp = Interop.mkProperty "onRelease" handler
    static member inline modal ( value : bool ) : IDrawerProp = Interop.mkProperty "modal" value
    static member inline nested ( value : bool ) : IDrawerProp = Interop.mkProperty "nested" value
    static member inline onClose ( handler : unit -> unit ) : IDrawerProp = Interop.mkProperty "onClose" handler
    static member inline disablePreventScroll ( value : bool ) : IDrawerProp = Interop.mkProperty "disablePreventScroll" value
    static member inline repositionInputs ( value : bool ) : IDrawerProp = Interop.mkProperty "repositionInputs" value
    static member inline snapToSequentialPoint ( value : bool ) : IDrawerProp = Interop.mkProperty "snapToSequentialPoint" value
    static member inline onAnimationEnd ( handler : bool -> unit ) : IDrawerProp = Interop.mkProperty "onAnimationEnd" handler
    static member inline preventScrollRestoration ( value : bool ) : IDrawerProp = Interop.mkProperty "preventScrollRestoration" value
    static member inline autoFocus ( value : bool ) : IDrawerProp = Interop.mkProperty "autoFocus" value
    static member inline snapPoints ( value : int[] ) : IDrawerProp = Interop.mkProperty "snapPoints" value
    static member inline snapPoints ( value : string[] ) : IDrawerProp = Interop.mkProperty "snapPoints" value
    static member inline fadeFromIndex ( value : int ) : IDrawerProp = Interop.mkProperty "fadeFromIndex" value
[<RequireQualifiedAccess>]
module [<Erase>] drawer =
    type [<Erase>] direction =
        static member inline top : IDrawerProp = Interop.mkProperty "direction" "top"
        static member inline bottom : IDrawerProp = Interop.mkProperty "direction" "bottom"
        static member inline left : IDrawerProp = Interop.mkProperty "direction" "left"
        static member inline right : IDrawerProp = Interop.mkProperty "direction" "right"

[<JSX.Component>]
let Drawer ( props : IDrawerProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {shouldScaleBackground=true,  ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <DrawerPrimitive.Root shouldScaleBackground{{shouldScaleBackground}} {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- DrawerTrigger -------------- //
type [<Erase>] IDrawerTriggerProp = interface end
type [<Erase>] drawerTrigger =
    inherit Dialog.trigger<IDrawerTriggerProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let DrawerTrigger ( props : IDrawerTriggerProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <DrawerPrimitive.Trigger {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- DrawerPortal -------------- //
type [<Erase>] IDrawerPortalProp = interface end
type [<Erase>] drawerPortal =
    inherit Dialog.portal<IDrawerPortalProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let DrawerPortal ( props : IDrawerPortalProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <DrawerPrimitive.Portal {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- DrawerClose -------------- //
type [<Erase>] IDrawerCloseProp = interface end
type [<Erase>] drawerClose =
    inherit Dialog.close<IDrawerCloseProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let DrawerClose ( props : IDrawerCloseProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <DrawerPrimitive.Close {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- DrawerOverlay -------------- //
type [<Erase>] IDrawerOverlayProp = interface end
type [<Erase>] drawerOverlay =
    inherit Dialog.overlay<IDrawerOverlayProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let DrawerOverlay ( props : IDrawerOverlayProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <DrawerPrimitive.Overlay
        ref={ref}
        className={ JSX.cn [|
            "fixed inset-0 z-50 bg-black/80"
            properties?className
        |] }
    """ |> unbox
    
// --------------- DrawerContent -------------- //
type [<Erase>] IDrawerContentProp = interface end
type [<Erase>] drawerContent =
    inherit Dialog.content<IDrawerContentProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let DrawerContent ( props : IDrawerContentProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, children, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <DrawerPortal>
        <DrawerOverlay />
        <DrawerPrimitive.Content
            ref={ref}
            className={ JSX.cn [|
                "fixed inset-x-0 bottom-0 z-50 mt-24 flex h-auto flex-col rounded-t-[10px] border bg-background"
                properties?className
            |] }
            {{...sprops}} {{...attrs}} >
            <div className="mx-auto mt-4 h-2 w-[100px] rounded-full bg-muted" />
            {properties?children}
        </DrawerPrimitive.Content>
    </DrawerPortal>
    """ |> unbox

// --------------- DrawerHeader -------------- //
type [<Erase>] IDrawerHeaderProp = interface end
type [<Erase>] drawerHeader =
    inherit prop<IDrawerHeaderProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let DrawerHeader ( props : IDrawerHeaderProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <div className={ JSX.cn [| "grid gap-1.5 p-4 text-center sm:text-left" ; properties?className |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- DrawerFooter -------------- //
type [<Erase>] IDrawerFooterProp = interface end
type [<Erase>] drawerFooter =
    inherit prop<IDrawerFooterProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let DrawerFooter ( props : IDrawerFooterProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <div className={ JSX.cn [|
            "mt-auto flex flex-col gap-2 p-4"
            properties?className
        |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- DrawerTitle -------------- //
type [<Erase>] IDrawerTitleProp = interface end
type [<Erase>] drawerTitle =
    inherit prop<IDrawerTitleProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let DrawerTitle ( props : IDrawerTitleProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <DrawerPrimitive.Title
        ref={ref}
        className={ JSX.cn [|
            "text-lg font-semibold leading-none tracking-tight"
            properties?className
        |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- DrawerDescription -------------- //
type [<Erase>] IDrawerDescriptionProp = interface end
type [<Erase>] drawerDescription =
    inherit prop<IDrawerDescriptionProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let DrawerDescription ( props : IDrawerDescriptionProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <DrawerPrimitive.Description
        ref={ref}
        className={JSX.cn [|
            "text-sm text-muted-foreground"
            properties?className
        |]}
        {{...sprops}} {{...attrs}} />
    """ |> unbox