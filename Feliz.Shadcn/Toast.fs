[<AutoOpen>]
module Feliz.Shadcn.Toast

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
JSX.injectShadcnLib
ignore <| JSX.jsx """
import * as ToastPrimitives from "@radix-ui/react-toast"
import { cva } from "class-variance-authority";
import { X } from "lucide-react"
"""

let toastVariants = JSX.jsx """
cva(
  "group pointer-events-auto relative flex w-full items-center justify-between space-x-2 overflow-hidden rounded-md border p-4 pr-6 shadow-lg transition-all data-[swipe=cancel]:translate-x-0 data-[swipe=end]:translate-x-[var(--radix-toast-swipe-end-x)] data-[swipe=move]:translate-x-[var(--radix-toast-swipe-move-x)] data-[swipe=move]:transition-none data-[state=open]:animate-in data-[state=closed]:animate-out data-[swipe=end]:animate-out data-[state=closed]:fade-out-80 data-[state=closed]:slide-out-to-right-full data-[state=open]:slide-in-from-top-full data-[state=open]:sm:slide-in-from-bottom-full",
  {
    variants: {
      variant: {
        default: "border bg-background text-foreground",
        destructive:
          "destructive group border-destructive bg-destructive text-destructive-foreground",
      },
    },
    defaultVariants: {
      variant: "default",
    },
  }
)
"""

open Feliz.RadixUI.Interface

// --------------- ToastProvider -------------- //
type [<Erase>] IToastProviderProp = interface end
type [<Erase>] toastProvider =
    inherit Toast.provider<IToastProviderProp>
    static member inline private noop : unit = ()

let ToastProvider : JSX.ElementType = JSX.jsx """
ToastPrimitives.Provider
"""

// --------------- ToastViewport -------------- //
type [<Erase>] IToastViewportProp = interface end
type [<Erase>] toastViewport =
    inherit Toast.viewport<IToastViewportProp>
    static member inline private noop : unit = ()

let ToastViewport : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <ToastPrimitives.Viewport
    ref={ref}
    className={cn(
      "fixed top-0 z-[100] flex max-h-screen w-full flex-col-reverse p-4 sm:bottom-0 sm:right-0 sm:top-auto sm:flex-col md:max-w-[420px]",
      className
    )}
    {...props} />
))
ToastViewport.displayName = ToastPrimitives.Viewport.displayName
"""

// --------------- Toast -------------- //
type [<Erase>] IToastProp = interface end
type [<Erase>] toast =
    inherit Toast.root<IToastProp>
    static member inline private noop : unit = ()

let Toast : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, variant, ...props }, ref) => {
  return (
    (<ToastPrimitives.Root
      ref={ref}
      className={cn(toastVariants({ variant }), className)}
      {...props} />)
  );
})
Toast.displayName = ToastPrimitives.Root.displayName
"""

// --------------- ToastAction -------------- //
type [<Erase>] IToastActionProp = interface end
type [<Erase>] toastAction =
    inherit prop<IToastActionProp>
    static member inline private noop : unit = ()

let ToastAction : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <ToastPrimitives.Action
    ref={ref}
    className={cn(
      "inline-flex h-8 shrink-0 items-center justify-center rounded-md border bg-transparent px-3 text-sm font-medium transition-colors hover:bg-secondary focus:outline-none focus:ring-1 focus:ring-ring disabled:pointer-events-none disabled:opacity-50 group-[.destructive]:border-muted/40 group-[.destructive]:hover:border-destructive/30 group-[.destructive]:hover:bg-destructive group-[.destructive]:hover:text-destructive-foreground group-[.destructive]:focus:ring-destructive",
      className
    )}
    {...props} />
))
ToastAction.displayName = ToastPrimitives.Action.displayName
"""

// --------------- ToastClose -------------- //
type [<Erase>] IToastCloseProp = interface end
type [<Erase>] toastClose =
    inherit Toast.close<IToastCloseProp>
    static member inline private noop : unit = ()

let ToastClose : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <ToastPrimitives.Close
    ref={ref}
    className={cn(
      "absolute right-1 top-1 rounded-md p-1 text-foreground/50 opacity-0 transition-opacity hover:text-foreground focus:opacity-100 focus:outline-none focus:ring-1 group-hover:opacity-100 group-[.destructive]:text-red-300 group-[.destructive]:hover:text-red-50 group-[.destructive]:focus:ring-red-400 group-[.destructive]:focus:ring-offset-red-600",
      className
    )}
    toast-close=""
    {...props}>
    <X className="h-4 w-4" />
  </ToastPrimitives.Close>
))
ToastClose.displayName = ToastPrimitives.Close.displayName
"""

// --------------- ToastTitle -------------- //
type [<Erase>] IToastTitleProp = interface end
type [<Erase>] toastTitle =
    inherit Toast.title<IToastTitleProp>
    static member inline private noop : unit = ()

let ToastTitle : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <ToastPrimitives.Title
    ref={ref}
    className={cn("text-sm font-semibold [&+div]:text-xs", className)}
    {...props} />
))
ToastTitle.displayName = ToastPrimitives.Title.displayName
"""

// --------------- ToastDescription -------------- //
type [<Erase>] IToastDescriptionProp = interface end
type [<Erase>] toastDescription =
    inherit Toast.description<IToastDescriptionProp>
    static member inline private noop : unit = ()

let ToastDescription : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <ToastPrimitives.Description ref={ref} className={cn("text-sm opacity-90", className)} {...props} />
))
ToastDescription.displayName = ToastPrimitives.Description.displayName
"""

type [<Erase>] Shadcn =
    static member inline ToastProvider ( props : IToastProviderProp list ) = JSX.createElement ToastProvider props
    static member inline ToastProvider ( children : ReactElement list ) = JSX.createElementWithChildren ToastProvider children
    static member inline ToastViewport ( props : IToastViewportProp list ) = JSX.createElement ToastViewport props
    static member inline ToastViewport ( children : ReactElement list ) = JSX.createElementWithChildren ToastViewport children
    static member inline ToastViewport ( el : ReactElement ) = JSX.createElement ToastViewport [ toastViewport.asChild true ; toastViewport.children el ]
    static member inline Toast ( props : IToastProp list ) = JSX.createElement Toast props
    static member inline Toast ( children : ReactElement list ) = JSX.createElementWithChildren Toast children
    static member inline Toast ( el : ReactElement ) = JSX.createElement Toast [ toast.asChild true ; toast.children el ]
    static member inline ToastTitle ( props : IToastTitleProp list ) = JSX.createElement ToastTitle props
    static member inline ToastTitle ( children : ReactElement list ) = JSX.createElementWithChildren ToastTitle children
    static member inline ToastTitle ( el : ReactElement ) = JSX.createElement ToastTitle [ toastTitle.asChild true ; toastTitle.children el ]
    static member inline ToastDescription ( props : IToastDescriptionProp list ) = JSX.createElement ToastDescription props
    static member inline ToastDescription ( children : ReactElement list ) = JSX.createElementWithChildren ToastDescription children
    static member inline ToastDescription ( el : ReactElement ) = JSX.createElement ToastDescription [ toastDescription.asChild true ; toastDescription.children el ]
    static member inline ToastClose ( props : IToastCloseProp list ) = JSX.createElement ToastClose props
    static member inline ToastClose ( children : ReactElement list ) = JSX.createElementWithChildren ToastClose children
    static member inline ToastClose ( el : ReactElement ) = JSX.createElement ToastClose [ toastClose.asChild true ; toastClose.children el ]
    static member inline ToastAction ( props : IToastActionProp list ) = JSX.createElement ToastAction props
    static member inline ToastAction ( children : ReactElement list ) = JSX.createElementWithChildren ToastAction children
                        