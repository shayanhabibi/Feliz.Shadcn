[<AutoOpen>]
module Feliz.Shadcn.Sheet

open Feliz.RadixUI.Interface
open Feliz.Lucide
open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz

JSX.injectShadcnLib


let sheetVariants = JSX.jsx """
import * as SheetPrimitive from "@radix-ui/react-dialog";
import { X } from "lucide-react";
import { cva } from "class-variance-authority";

cva(
  "fixed z-50 gap-4 bg-background p-6 shadow-lg transition ease-in-out data-[state=closed]:duration-300 data-[state=open]:duration-500 data-[state=open]:animate-in data-[state=closed]:animate-out",
  {
    variants: {
      side: {
        top: "inset-x-0 top-0 border-b data-[state=closed]:slide-out-to-top data-[state=open]:slide-in-from-top",
        bottom:
          "inset-x-0 bottom-0 border-t data-[state=closed]:slide-out-to-bottom data-[state=open]:slide-in-from-bottom",
        left: "inset-y-0 left-0 h-full w-3/4 border-r data-[state=closed]:slide-out-to-left data-[state=open]:slide-in-from-left sm:max-w-sm",
        right:
          "inset-y-0 right-0 h-full w-3/4 border-l data-[state=closed]:slide-out-to-right data-[state=open]:slide-in-from-right sm:max-w-sm",
      },
    },
    defaultVariants: {
      side: "right",
    },
  }
)"""

       

// --------------- Sheet -------------- //
type [<Erase>] ISheetProp = interface end
type [<Erase>] sheet =
    inherit Dialog.root<ISheetProp>
    static member inline noop : unit = ()

let Sheet : JSX.ElementType = JSX.jsx """
SheetPrimitive.Root
"""

// --------------- SheetTrigger -------------- //
type [<Erase>] ISheetTriggerProp = interface end
type [<Erase>] sheetTrigger =
    inherit Dialog.trigger<ISheetTriggerProp>
    static member inline noop : unit = ()

let SheetTrigger : JSX.ElementType = JSX.jsx """
SheetPrimitive.Trigger
"""

// --------------- SheetClose -------------- //
type [<Erase>] ISheetCloseProp = interface end
type [<Erase>] sheetClose =
    inherit Dialog.close<ISheetCloseProp>
    static member inline noop : unit = ()

let SheetClose : JSX.ElementType = JSX.jsx """
SheetPrimitive.Close
"""

// --------------- SheetPortal -------------- //
type [<Erase>] ISheetPortalProp = interface end
type [<Erase>] sheetPortal =
    inherit Dialog.portal<ISheetPortalProp>
    static member inline noop : unit = ()

let SheetPortal : JSX.ElementType = JSX.jsx """
SheetPrimitive.Portal
"""

// --------------- SheetOverlay -------------- //
type [<Erase>] ISheetOverlayProp = interface end
type [<Erase>] sheetOverlay =
    inherit Dialog.overlay<ISheetOverlayProp>
    static member inline noop : unit = ()

let SheetOverlay : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <SheetPrimitive.Overlay
    className={cn(
      "fixed inset-0 z-50 bg-black/80  data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0",
      className
    )}
    {...props}
    ref={ref} />
))
SheetOverlay.displayName = SheetPrimitive.Overlay.displayName
"""

// --------------- SheetContent -------------- //
type [<Erase>] ISheetContentProp = interface end
type [<Erase>] sheetContent =
    inherit Dialog.content<ISheetContentProp>
    static member inline noop : unit = ()

module [<Erase>] sheetContent =
    type [<Erase>] side =
        static member inline left : ISheetContentProp = Interop.mkProperty "side" "left"
        static member inline right : ISheetContentProp = Interop.mkProperty "side" "right"
        static member inline top : ISheetContentProp = Interop.mkProperty "side" "top"
        static member inline bottom : ISheetContentProp = Interop.mkProperty "side" "bottom"

let SheetContent : JSX.ElementType = JSX.jsx """
React.forwardRef(({ side = "right", className, children, ...props }, ref) => (
  <SheetPortal>
    <SheetOverlay />
    <SheetPrimitive.Content ref={ref} className={cn(sheetVariants({ side }), className)} {...props}>
      <SheetPrimitive.Close
        className="absolute right-4 top-4 rounded-sm opacity-70 ring-offset-background transition-opacity hover:opacity-100 focus:outline-none focus:ring-2 focus:ring-ring focus:ring-offset-2 disabled:pointer-events-none data-[state=open]:bg-secondary">
        <X className="h-4 w-4" />
        <span className="sr-only">Close</span>
      </SheetPrimitive.Close>
      {children}
    </SheetPrimitive.Content>
  </SheetPortal>
))
SheetContent.displayName = SheetPrimitive.Content.displayName
"""

// --------------- SheetHeader -------------- //
type [<Erase>] ISheetHeaderProp = interface end
type [<Erase>] sheetHeader =
    inherit prop<ISheetHeaderProp>
    static member inline noop : unit = ()

let SheetHeader : JSX.ElementType = JSX.jsx """
({
  className,
  ...props
}) => (
  <div
    className={cn("flex flex-col space-y-2 text-center sm:text-left", className)}
    {...props} />
)
SheetHeader.displayName = "SheetHeader"
"""

// --------------- SheetFooter -------------- //
type [<Erase>] ISheetFooterProp = interface end
type [<Erase>] sheetFooter =
    inherit prop<ISheetFooterProp>
    static member inline noop : unit = ()

let SheetFooter : JSX.ElementType = JSX.jsx """
({
  className,
  ...props
}) => (
  <div
    className={cn("flex flex-col-reverse sm:flex-row sm:justify-end sm:space-x-2", className)}
    {...props} />
)
SheetFooter.displayName = "SheetFooter"
"""

// --------------- SheetTitle -------------- //
type [<Erase>] ISheetTitleProp = interface end
type [<Erase>] sheetTitle =
    inherit prop<ISheetTitleProp>
    static member inline noop : unit = ()

let SheetTitle : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <SheetPrimitive.Title
    ref={ref}
    className={cn("text-lg font-semibold text-foreground", className)}
    {...props} />
))
SheetTitle.displayName = SheetPrimitive.Title.displayName
"""

// --------------- SheetDescription -------------- //
type [<Erase>] ISheetDescriptionProp = interface end
type [<Erase>] sheetDescription =
    inherit prop<ISheetDescriptionProp>
    static member inline noop : unit = ()

let SheetDescription : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <SheetPrimitive.Description
    ref={ref}
    className={cn("text-sm text-muted-foreground", className)}
    {...props} />
))
SheetDescription.displayName = SheetPrimitive.Description.displayName
"""

type [<Erase>] Shadcn =
    static member inline Sheet ( props : ISheetProp list ) = JSX.createElement Sheet props
    static member inline Sheet ( children : ReactElement list ) = JSX.createElementWithChildren Sheet children
    static member inline SheetPortal ( props : ISheetPortalProp list ) = JSX.createElement SheetPortal props
    static member inline SheetPortal ( children : ReactElement list ) = JSX.createElementWithChildren SheetPortal children
    static member inline SheetOverlay ( props : ISheetOverlayProp list ) = JSX.createElement SheetOverlay props
    static member inline SheetOverlay ( children : ReactElement list ) = JSX.createElementWithChildren SheetOverlay children
    static member inline SheetTrigger ( props : ISheetTriggerProp list ) = JSX.createElement SheetTrigger props
    static member inline SheetTrigger ( children : ReactElement list ) = JSX.createElementWithChildren SheetTrigger children
    static member inline SheetTrigger ( value : string ) = JSX.createElement SheetTrigger [ prop.text value ]
    static member inline SheetClose ( props : ISheetCloseProp list ) = JSX.createElement SheetClose props
    static member inline SheetClose ( children : ReactElement list ) = JSX.createElementWithChildren SheetClose children
    static member inline SheetContent ( props : ISheetContentProp list ) = JSX.createElement SheetContent props
    static member inline SheetContent ( children : ReactElement list ) = JSX.createElementWithChildren SheetContent children
    static member inline SheetHeader ( props : ISheetHeaderProp list ) = JSX.createElement SheetHeader props
    static member inline SheetHeader ( children : ReactElement list ) = JSX.createElementWithChildren SheetHeader children
    static member inline SheetFooter ( props : ISheetFooterProp list ) = JSX.createElement SheetFooter props
    static member inline SheetFooter ( children : ReactElement list ) = JSX.createElementWithChildren SheetFooter children
    static member inline SheetTitle ( props : ISheetTitleProp list ) = JSX.createElement SheetTitle props
    static member inline SheetTitle ( children : ReactElement list ) = JSX.createElementWithChildren SheetTitle children
    static member inline SheetTitle ( value : string ) = JSX.createElement SheetTitle [ prop.text value ]
    static member inline SheetDescription ( props : ISheetDescriptionProp list ) = JSX.createElement SheetDescription props
    static member inline SheetDescription ( children : ReactElement list ) = JSX.createElementWithChildren SheetDescription children
    static member inline SheetDescription ( value : string ) = JSX.createElement SheetDescription [ prop.text value ]
                                    
  