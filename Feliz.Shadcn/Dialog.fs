﻿[<AutoOpen>]
module Feliz.Shadcn.Dialog

open Browser.Types
open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI.Interface.NoInherit

emitJsStatement () "import * as DialogPrimitive from \"@radix-ui/react-dialog\""

JSX.injectShadcnLib

// --------------- Dialog -------------- //
type [<Erase>] IDialogProp = interface static member propsInterface : unit = () end
type [<Erase>] dialog =
    inherit Dialog.root<IDialogProp>
    static member inline open' ( value : bool ) : IDialogProp = Interop.mkProperty "open" value
    static member inline defaultOpen ( value : bool ) : IDialogProp = Interop.mkProperty "defaultOpen" value
    static member inline onOpenChange ( handler : bool -> unit ) : IDialogProp = Interop.mkProperty "onOpenChange" handler
    static member inline modal ( value : bool ) : IDialogProp = Interop.mkProperty "modal" value

let Dialog : JSX.ElementType = JSX.jsx "DialogPrimitive.Root"

// --------------- DialogTrigger -------------- //
type [<Erase>] IDialogTriggerProp = interface static member propsInterface : unit = () end
type [<Erase>] dialogTrigger = Dialog.trigger<IDialogTriggerProp>

let DialogTrigger : JSX.ElementType = JSX.jsx "DialogPrimitive.Trigger"
    
// --------------- DialogPortal -------------- //
type [<Erase>] IDialogPortalProp = interface static member propsInterface : unit = () end
type [<Erase>] dialogPortal = Dialog.portal<IDialogPortalProp>

let DialogPortal : JSX.ElementType = JSX.jsx "DialogPrimitive.Portal"
    
// --------------- DialogClose -------------- //
type [<Erase>] IDialogCloseProp = interface static member propsInterface : unit = () end
type [<Erase>] dialogClose = Dialog.close<IDialogCloseProp>

let DialogClose : JSX.ElementType = JSX.jsx "DialogPrimitive.Close"

// --------------- DialogOverlay -------------- //
type [<Erase>] IDialogOverlayProp = interface static member propsInterface : unit = () end
type [<Erase>] dialogOverlay = Dialog.overlay<IDialogOverlayProp>

let DialogOverlay : JSX.ElementType =  JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <DialogPrimitive.Overlay
    ref={ref}
    className={cn(
      "fixed inset-0 z-50 bg-black/80  data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0",
      className
    )}
    {...props} />
))
DialogOverlay.displayName = DialogPrimitive.Overlay.displayName
"""
    
// --------------- DialogContent -------------- //
type [<Erase>] IDialogContentProp = interface static member propsInterface : unit = () end
type [<Erase>] dialogContent = Dialog.content<IDialogContentProp>

[<JSX.Component>]
let DialogContent : JSX.ElementType = JSX.jsx """
import { X } from "lucide-react";
import * as DialogPrimitive from "@radix-ui/react-dialog";
React.forwardRef(({ className, children, ...props }, ref) => (
  <DialogPortal>
    <DialogOverlay />
    <DialogPrimitive.Content
      ref={ref}
      className={cn(
        "fixed left-[50%] top-[50%] z-50 grid w-full max-w-lg translate-x-[-50%] translate-y-[-50%] gap-4 border bg-background p-6 shadow-lg duration-200 data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0 data-[state=closed]:zoom-out-95 data-[state=open]:zoom-in-95 data-[state=closed]:slide-out-to-left-1/2 data-[state=closed]:slide-out-to-top-[48%] data-[state=open]:slide-in-from-left-1/2 data-[state=open]:slide-in-from-top-[48%] sm:rounded-lg",
        className
      )}
      {...props}>
      {children}
      <DialogPrimitive.Close
        className="absolute right-4 top-4 rounded-sm opacity-70 ring-offset-background transition-opacity hover:opacity-100 focus:outline-none focus:ring-2 focus:ring-ring focus:ring-offset-2 disabled:pointer-events-none data-[state=open]:bg-accent data-[state=open]:text-muted-foreground">
        <X className="h-4 w-4" />
        <span className="sr-only">Close</span>
      </DialogPrimitive.Close>
    </DialogPrimitive.Content>
  </DialogPortal>
))
DialogContent.displayName = DialogPrimitive.Content.displayName
"""

// --------------- DialogHeader -------------- //
type [<Erase>] IDialogHeaderProp = interface static member propsInterface : unit = () end

let DialogHeader : JSX.ElementType = JSX.jsx """
({
  className,
  ...props
}) => (
  <div
    className={cn("flex flex-col space-y-1.5 text-center sm:text-left", className)}
    {...props} />
)
DialogHeader.displayName = "DialogHeader"
"""

// --------------- DialogFooter -------------- //
type [<Erase>] IDialogFooterProp = interface static member propsInterface : unit = () end

let DialogFooter : JSX.ElementType = JSX.jsx """
({
  className,
  ...props
}) => (
  <div
    className={cn("flex flex-col-reverse sm:flex-row sm:justify-end sm:space-x-2", className)}
    {...props} />
)
DialogFooter.displayName = "DialogFooter"
"""

// --------------- DialogTitle -------------- //
type [<Erase>] IDialogTitleProp = interface static member propsInterface : unit = () end

let DialogTitle : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <DialogPrimitive.Title
    ref={ref}
    className={cn("text-lg font-semibold leading-none tracking-tight", className)}
    {...props} />
))
DialogTitle.displayName = DialogPrimitive.Title.displayName
"""

// --------------- DialogDescription -------------- //
type [<Erase>] IDialogDescriptionProp = interface static member propsInterface : unit = () end

let DialogDescription : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <DialogPrimitive.Description
    ref={ref}
    className={cn("text-sm text-muted-foreground", className)}
    {...props} />
))
DialogDescription.displayName = DialogPrimitive.Description.displayName
"""

type [<Erase>] Shadcn =
    static member inline Dialog ( props : IDialogProp list ) = JSX.createElement Dialog props
    static member inline Dialog ( children : ReactElement list ) = JSX.createElementWithChildren Dialog children
    static member inline DialogTrigger ( props : IDialogTriggerProp list ) = JSX.createElement DialogTrigger props
    static member inline DialogTrigger ( children : ReactElement list ) = JSX.createElementWithChildren DialogTrigger children
    static member inline DialogTrigger ( el : ReactElement ) = JSX.createElement DialogTrigger [ dialogTrigger.asChild true ; props.children el ]
    static member inline DialogPortal ( props : IDialogPortalProp list ) = JSX.createElement DialogPortal props
    static member inline DialogPortal ( children : ReactElement list ) = JSX.createElementWithChildren DialogPortal children
    static member inline DialogClose ( props : IDialogCloseProp list ) = JSX.createElement DialogClose props
    static member inline DialogClose ( children : ReactElement list ) = JSX.createElementWithChildren DialogClose children
    static member inline DialogClose ( value : string ) = JSX.createElement DialogClose [ prop.text value ]
    static member inline DialogClose ( el : ReactElement ) = JSX.createElement DialogClose [ dialogClose.asChild true ; props.children el ]
    static member inline DialogOverlay ( props : IDialogOverlayProp list ) = JSX.createElement DialogOverlay props
    static member inline DialogOverlay ( children : ReactElement list ) = JSX.createElementWithChildren DialogOverlay children
    static member inline DialogOverlay ( el : ReactElement ) = JSX.createElement DialogOverlay [ dialogOverlay.asChild true ; props.children el ]
    static member inline DialogContent ( props : IDialogContentProp list ) = JSX.createElement DialogContent props
    static member inline DialogContent ( children : ReactElement list ) = JSX.createElementWithChildren DialogContent children
    static member inline DialogContent ( el : ReactElement ) = JSX.createElement DialogContent [ dialogContent.asChild true ; props.children el ]
    static member inline DialogHeader ( props : IDialogHeaderProp list ) = JSX.createElement DialogHeader props
    static member inline DialogHeader ( children : ReactElement list ) = JSX.createElementWithChildren DialogHeader children
    static member inline DialogFooter ( props : IDialogFooterProp list ) = JSX.createElement DialogFooter props
    static member inline DialogFooter ( children : ReactElement list ) = JSX.createElementWithChildren DialogFooter children
    static member inline DialogTitle ( props : IDialogTitleProp list ) = JSX.createElement DialogTitle props
    static member inline DialogTitle ( children : ReactElement list ) = JSX.createElementWithChildren DialogTitle children
    static member inline DialogTitle ( value : string ) = JSX.createElement DialogTitle [ prop.text value ]
    static member inline DialogDescription ( props : IDialogDescriptionProp list ) = JSX.createElement DialogDescription props
    static member inline DialogDescription ( children : ReactElement list ) = JSX.createElementWithChildren DialogDescription children
    static member inline DialogDescription ( value : string ) = JSX.createElement DialogDescription [ prop.text value ]
