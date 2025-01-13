[<AutoOpen>]
module Feliz.Shadcn.Drawer

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI

emitJsStatement () "import { Drawer as DrawerPrimitive } from \"vaul\""
JSX.injectLib

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

let Drawer : JSX.ElementType = JSX.jsx """
({
  shouldScaleBackground = true,
  ...props
}) => (
  <DrawerPrimitive.Root shouldScaleBackground={shouldScaleBackground} {...props} />
)
Drawer.displayName = "Drawer"
"""

// --------------- DrawerTrigger -------------- //
type [<Erase>] IDrawerTriggerProp = interface end
type [<Erase>] drawerTrigger =
    inherit Dialog.trigger<IDrawerTriggerProp>
    static member inline noop : unit = ()

let DrawerTrigger : JSX.ElementType = JSX.jsx """
DrawerPrimitive.Trigger
"""

// --------------- DrawerPortal -------------- //
type [<Erase>] IDrawerPortalProp = interface end
type [<Erase>] drawerPortal =
    inherit Dialog.portal<IDrawerPortalProp>
    static member inline noop : unit = ()

let DrawerPortal : JSX.ElementType = JSX.jsx """
DrawerPrimitive.Portal
"""

// --------------- DrawerClose -------------- //
type [<Erase>] IDrawerCloseProp = interface end
type [<Erase>] drawerClose =
    inherit Dialog.close<IDrawerCloseProp>
    static member inline noop : unit = ()

let DrawerClose : JSX.ElementType = JSX.jsx """
DrawerPrimitive.Close
"""

// --------------- DrawerOverlay -------------- //
type [<Erase>] IDrawerOverlayProp = interface end
type [<Erase>] drawerOverlay =
    inherit Dialog.overlay<IDrawerOverlayProp>
    static member inline noop : unit = ()

let DrawerOverlay : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <DrawerPrimitive.Overlay
    ref={ref}
    className={cn("fixed inset-0 z-50 bg-black/80", className)}
    {...props} />
))
DrawerOverlay.displayName = DrawerPrimitive.Overlay.displayName
"""
    
// --------------- DrawerContent -------------- //
type [<Erase>] IDrawerContentProp = interface end
type [<Erase>] drawerContent =
    inherit Dialog.content<IDrawerContentProp>
    static member inline noop : unit = ()

let DrawerContent : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, children, ...props }, ref) => (
  <DrawerPortal>
    <DrawerOverlay />
    <DrawerPrimitive.Content
      ref={ref}
      className={cn(
        "fixed inset-x-0 bottom-0 z-50 mt-24 flex h-auto flex-col rounded-t-[10px] border bg-background",
        className
      )}
      {...props}>
      <div className="mx-auto mt-4 h-2 w-[100px] rounded-full bg-muted" />
      {children}
    </DrawerPrimitive.Content>
  </DrawerPortal>
))
DrawerContent.displayName = "DrawerContent"
"""

// --------------- DrawerHeader -------------- //
type [<Erase>] IDrawerHeaderProp = interface end
type [<Erase>] drawerHeader =
    inherit prop<IDrawerHeaderProp>
    static member inline noop : unit = ()

let DrawerHeader : JSX.ElementType = JSX.jsx """
({
  className,
  ...props
}) => (
  <div
    className={cn("grid gap-1.5 p-4 text-center sm:text-left", className)}
    {...props} />
)
DrawerHeader.displayName = "DrawerHeader"
"""

// --------------- DrawerFooter -------------- //
type [<Erase>] IDrawerFooterProp = interface end
type [<Erase>] drawerFooter =
    inherit prop<IDrawerFooterProp>
    static member inline noop : unit = ()

let DrawerFooter : JSX.ElementType = JSX.jsx """
({
  className,
  ...props
}) => (
  <div className={cn("mt-auto flex flex-col gap-2 p-4", className)} {...props} />
)
DrawerFooter.displayName = "DrawerFooter"
"""

// --------------- DrawerTitle -------------- //
type [<Erase>] IDrawerTitleProp = interface end
type [<Erase>] drawerTitle =
    inherit prop<IDrawerTitleProp>
    static member inline noop : unit = ()

let DrawerTitle : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <DrawerPrimitive.Title
    ref={ref}
    className={cn("text-lg font-semibold leading-none tracking-tight", className)}
    {...props} />
))
DrawerTitle.displayName = DrawerPrimitive.Title.displayName
"""

// --------------- DrawerDescription -------------- //
type [<Erase>] IDrawerDescriptionProp = interface end
type [<Erase>] drawerDescription =
    inherit prop<IDrawerDescriptionProp>
    static member inline noop : unit = ()

let DrawerDescription : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <DrawerPrimitive.Description
    ref={ref}
    className={cn("text-sm text-muted-foreground", className)}
    {...props} />
))
DrawerDescription.displayName = DrawerPrimitive.Description.displayName
"""

type [<Erase>] Shadcn =
    static member inline Drawer ( props : IDrawerProp list ) = JSX.createElement Drawer props
    static member inline Drawer ( children : ReactElement list ) = JSX.createElementWithChildren Drawer children
    static member inline DrawerPortal ( props : IDrawerPortalProp list ) = JSX.createElement DrawerPortal props
    static member inline DrawerPortal ( children : ReactElement list ) = JSX.createElementWithChildren DrawerPortal children
    static member inline DrawerOverlay ( props : IDrawerOverlayProp list ) = JSX.createElement DrawerOverlay props
    static member inline DrawerOverlay ( children : ReactElement list ) = JSX.createElementWithChildren DrawerOverlay children
    static member inline DrawerTrigger ( props : IDrawerTriggerProp list ) = JSX.createElement DrawerTrigger props
    static member inline DrawerTrigger ( children : ReactElement list ) = JSX.createElementWithChildren DrawerTrigger children
    static member inline DrawerClose ( props : IDrawerCloseProp list ) = JSX.createElement DrawerClose props
    static member inline DrawerClose ( children : ReactElement list ) = JSX.createElementWithChildren DrawerClose children
    static member inline DrawerContent ( props : IDrawerContentProp list ) = JSX.createElement DrawerContent props
    static member inline DrawerContent ( children : ReactElement list ) = JSX.createElementWithChildren DrawerContent children
    static member inline DrawerHeader ( props : IDrawerHeaderProp list ) = JSX.createElement DrawerHeader props
    static member inline DrawerHeader ( children : ReactElement list ) = JSX.createElementWithChildren DrawerHeader children
    static member inline DrawerFooter ( props : IDrawerFooterProp list ) = JSX.createElement DrawerFooter props
    static member inline DrawerFooter ( children : ReactElement list ) = JSX.createElementWithChildren DrawerFooter children
    static member inline DrawerTitle ( props : IDrawerTitleProp list ) = JSX.createElement DrawerTitle props
    static member inline DrawerTitle ( children : ReactElement list ) = JSX.createElementWithChildren DrawerTitle children
    static member inline DrawerDescription ( props : IDrawerDescriptionProp list ) = JSX.createElement DrawerDescription props
    static member inline DrawerDescription ( children : ReactElement list ) = JSX.createElementWithChildren DrawerDescription children
                            