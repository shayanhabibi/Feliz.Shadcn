[<AutoOpen>]
module Feliz.Shadcn.Alert

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz

JSX.injectLib
/// Class-Variance-Authority variations object for the Alert components.
let alertVariants = JSX.jsx """
import { cva } from "class-variance-authority"
cva(
  "relative w-full rounded-lg border px-4 py-3 text-sm [&>svg+div]:translate-y-[-3px] [&>svg]:absolute [&>svg]:left-4 [&>svg]:top-4 [&>svg]:text-foreground [&>svg~*]:pl-7",
  {
    variants: {
      variant: {
        default: "bg-background text-foreground",
        destructive:
          "border-destructive/50 text-destructive dark:border-destructive [&>svg]:text-destructive",
      },
    },
    defaultVariants: {
      variant: "default",
    },
  }
)"""

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
let Alert : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, variant, ...props }, ref) => (
  <div
    ref={ref}
    role="alert"
    className={cn(alertVariants({ variant }), className)}
    {...props} />
))
Alert.displayName = "Alert"
"""

// ------------ AlertTitle ----------- //
type [<Erase>] IAlertTitleProp = interface end
type [<Erase>] alertTitle =
    inherit prop<IAlertTitleProp>
    static member inline private noop = ignore

/// The Alert Title Component
let AlertTitle : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <h5
    ref={ref}
    className={cn("mb-1 font-medium leading-none tracking-tight", className)}
    {...props} />
))
AlertTitle.displayName = "AlertTitle"
"""

// ------------- AlertDescription ------------- //
type [<Erase>] IAlertDescriptionProp = interface end
type [<Erase>] alertDescription =
    inherit prop<IAlertDescriptionProp>
    static member inline private noop = ignore

/// The Alert Description Component
let AlertDescription : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <div
    ref={ref}
    className={cn("text-sm [&_p]:leading-relaxed", className)}
    {...props} />
))
AlertDescription.displayName = "AlertDescription"
"""

type [<Erase>] Shadcn =
    static member inline Alert ( props : IAlertProp list ) = JSX.createElement Alert props
    static member inline Alert ( props : ReactElement list ) = JSX.createElementWithChildren Alert props
    static member inline AlertTitle ( props : IAlertTitleProp list ) = JSX.createElement AlertTitle props
    static member inline AlertTitle ( props : ReactElement list ) = JSX.createElementWithChildren AlertTitle props
    static member inline AlertTitle ( value : string ) = JSX.createElement AlertTitle [ prop.text value ]
    static member inline AlertDescription ( props : IAlertDescriptionProp list ) = JSX.createElement AlertDescription props
    static member inline AlertDescription ( props : ReactElement list ) = JSX.createElementWithChildren AlertDescription props
    static member inline AlertDescription ( value : string ) = JSX.createElement AlertDescription [ prop.text value ]
