[<AutoOpen>]
module Feliz.Shadcn.AlertDialog

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI

emitJsStatement () "import * as AlertDialogPrimitive from \"@radix-ui/react-alert-dialog\""

JSX.injectLib
let buttonVariants = Feliz.Shadcn.Button.buttonVariants

// --------------- AlertDialog -------------- //
type [<Erase>] IAlertDialogProp = interface end
type [<Erase>] alertDialog =
    inherit Dialog.root<IAlertDialogProp>
    static member private noop = ()

let AlertDialog : JSX.ElementType = JSX.jsx """AlertDialogPrimitive.Root"""

// --------------- AlertDialogTrigger -------------- //
type [<Erase>] IAlertDialogTriggerProp = interface end
type [<Erase>] alertDialogTrigger =
    inherit Dialog.trigger<IAlertDialogTriggerProp>
    static member inline private noop = ignore

let AlertDialogTrigger : JSX.ElementType = JSX.jsx """AlertDialogPrimitive.Trigger"""
// --------------- AlertDialogPortal -------------- //
type [<Erase>] IAlertDialogPortalProp = interface end
type [<Erase>] alertDialogPortal =
    inherit Dialog.portal<IAlertDialogPortalProp>
    static member private noop = ()
    
let AlertDialogPortal : JSX.ElementType = JSX.jsx """AlertDialogPrimitive.Portal"""
type [<Erase>] IAlertDialogOverlayProp = interface end
type [<Erase>] alertDialogOverlay =
    inherit Dialog.overlay<IAlertDialogOverlayProp>
    static member private noop = ()

let AlertDialogOverlay : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <AlertDialogPrimitive.Overlay
    className={cn(
      "fixed inset-0 z-50 bg-black/80 data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0",
      className
    )}
    {...props}
    ref={ref} />
))
AlertDialogOverlay.displayName = AlertDialogPrimitive.Overlay.displayName
"""

// --------------- AlertDialogContent -------------- //
type [<Erase>] IAlertDialogContentProp = interface end
type [<Erase>] alertDialogContent =
    inherit Dialog.content<IAlertDialogContentProp>
    static member private noop = ()

let AlertDialogContent : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <AlertDialogPortal>
    <AlertDialogOverlay />
    <AlertDialogPrimitive.Content
      ref={ref}
      className={cn(
        "fixed left-[50%] top-[50%] z-50 grid w-full max-w-lg translate-x-[-50%] translate-y-[-50%] gap-4 border bg-background p-6 shadow-lg duration-200 data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0 data-[state=closed]:zoom-out-95 data-[state=open]:zoom-in-95 data-[state=closed]:slide-out-to-left-1/2 data-[state=closed]:slide-out-to-top-[48%] data-[state=open]:slide-in-from-left-1/2 data-[state=open]:slide-in-from-top-[48%] sm:rounded-lg",
        className
      )}
      {...props} />
  </AlertDialogPortal>
))
AlertDialogContent.displayName = AlertDialogPrimitive.Content.displayName
"""
// --------------- AlertDialogHeader -------------- //
type [<Erase>] IAlertDialogHeaderProp = interface end
type [<Erase>] alertDialogHeader =
    inherit prop<IAlertDialogHeaderProp>
    static member inline private noop = ignore

[<JSX.Component>]
let AlertDialogHeader : JSX.ElementType = JSX.jsx """
({
  className,
  ...props
}) => (
  <div
    className={cn("flex flex-col space-y-2 text-center sm:text-left", className)}
    {...props} />
)
AlertDialogHeader.displayName = "AlertDialogHeader"
"""

// --------------- AlertDialogFooter -------------- //
type [<Erase>] IAlertDialogFooterProp = interface end
type [<Erase>] alertDialogFooter =
    inherit prop<IAlertDialogFooterProp>
    static member inline private noop = ignore

let AlertDialogFooter : JSX.ElementType = JSX.jsx """
({
  className,
  ...props
}) => (
  <div
    className={cn("flex flex-col-reverse sm:flex-row sm:justify-end sm:space-x-2", className)}
    {...props} />
)
AlertDialogFooter.displayName = "AlertDialogFooter"
"""
// --------------- AlertDialogTitle -------------- //
type [<Erase>] IAlertDialogTitleProp = interface end
type [<Erase>] alertDialogTitle =
    inherit prop<IAlertDialogTitleProp>
    static member inline private noop = ignore

let AlertDialogTitle : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <AlertDialogPrimitive.Title ref={ref} className={cn("text-lg font-semibold", className)} {...props} />
))
AlertDialogTitle.displayName = AlertDialogPrimitive.Title.displayName
"""

// --------------- AlertDialogDescription -------------- //
type [<Erase>] IAlertDialogDescriptionProp = interface end
type [<Erase>] alertDialogDescription =
    inherit prop<IAlertDialogDescriptionProp>
    static member inline private noop = ignore

let AlertDialogDescription : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <AlertDialogPrimitive.Description
    ref={ref}
    className={cn("text-sm text-muted-foreground", className)}
    {...props} />
))
AlertDialogDescription.displayName =
  AlertDialogPrimitive.Description.displayName
"""

// --------------- AlertDialogAction -------------- //
type [<Erase>] IAlertDialogActionProp = interface end
type [<Erase>] alertDialogAction =
    inherit prop<IAlertDialogActionProp>
    static member inline private noop = ignore

let AlertDialogAction : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <AlertDialogPrimitive.Action ref={ref} className={cn(buttonVariants(), className)} {...props} />
))
AlertDialogAction.displayName = AlertDialogPrimitive.Action.displayName
"""

// --------------- AlertDialogCancel -------------- //
type [<Erase>] IAlertDialogCancelProp = interface end
type [<Erase>] alertDialogCancel =
    inherit prop<IAlertDialogCancelProp>
    static member inline private noop = ignore

let AlertDialogCancel : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <AlertDialogPrimitive.Cancel
    ref={ref}
    className={cn(buttonVariants({ variant: "outline" }), "mt-2 sm:mt-0", className)}
    {...props} />
))
AlertDialogCancel.displayName = AlertDialogPrimitive.Cancel.displayName
"""

type [<Erase>] Shadcn =
    static member inline AlertDialog ( props : IAlertDialogProp list ) = JSX.createElement AlertDialog props
    static member inline AlertDialog ( children : ReactElement list ) = JSX.createElementWithChildren AlertDialog children
    static member inline AlertDialogTrigger ( props : IAlertDialogTriggerProp list ) = JSX.createElement AlertDialogTrigger props
    static member inline AlertDialogTrigger ( children : ReactElement list ) = JSX.createElementWithChildren AlertDialogTrigger children
    static member inline AlertDialogPortal ( props : IAlertDialogPortalProp list ) = JSX.createElement AlertDialogPortal props
    static member inline AlertDialogPortal ( children : ReactElement list ) = JSX.createElementWithChildren AlertDialogPortal children
    static member inline AlertDialogOverlay ( props : IAlertDialogOverlayProp list ) = JSX.createElement AlertDialogOverlay props
    static member inline AlertDialogOverlay ( children : ReactElement list ) = JSX.createElementWithChildren AlertDialogOverlay children
    static member inline AlertDialogContent ( props : IAlertDialogContentProp list ) = JSX.createElement AlertDialogContent props
    static member inline AlertDialogContent ( children : ReactElement list ) = JSX.createElementWithChildren AlertDialogContent children
    static member inline AlertDialogHeader ( props : IAlertDialogHeaderProp list ) = JSX.createElement AlertDialogHeader props
    static member inline AlertDialogHeader ( children : ReactElement list ) = JSX.createElementWithChildren AlertDialogHeader children
    static member inline AlertDialogFooter ( props : IAlertDialogFooterProp list ) = JSX.createElement AlertDialogFooter props
    static member inline AlertDialogFooter ( children : ReactElement list ) = JSX.createElementWithChildren AlertDialogFooter children
    static member inline AlertDialogTitle ( props : IAlertDialogTitleProp list ) = JSX.createElement AlertDialogTitle props
    static member inline AlertDialogTitle ( children : ReactElement list ) = JSX.createElementWithChildren AlertDialogTitle children
    static member inline AlertDialogDescription ( props : IAlertDialogDescriptionProp list ) = JSX.createElement AlertDialogDescription props
    static member inline AlertDialogDescription ( children : ReactElement list ) = JSX.createElementWithChildren AlertDialogDescription children
    static member inline AlertDialogCancel ( props : IAlertDialogCancelProp list ) = JSX.createElement AlertDialogCancel props
    static member inline AlertDialogCancel ( children : ReactElement list ) = JSX.createElementWithChildren AlertDialogCancel children
    static member inline AlertDialogAction ( props : IAlertDialogActionProp list ) = JSX.createElement AlertDialogAction props
    static member inline AlertDialogAction ( children : ReactElement list ) = JSX.createElementWithChildren AlertDialogAction children
