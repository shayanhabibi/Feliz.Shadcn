[<AutoOpen>]
module Feliz.Shadcn.Card

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz

JSX.injectLib

// --------------- Card -------------- //
type [<Erase>] ICardProp = interface end
type [<Erase>] card =
    inherit prop<ICardProp>
    static member inline noop : unit = ()

let Card : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <div
    ref={ref}
    className={cn("rounded-xl border bg-card text-card-foreground shadow", className)}
    {...props} />
))
Card.displayName = "Card"
"""

// --------------- CardHeader -------------- //
type [<Erase>] ICardHeaderProp = interface end
type [<Erase>] cardHeader =
    inherit prop<ICardHeaderProp>
    static member inline noop : unit = ()

let CardHeader : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <div
    ref={ref}
    className={cn("flex flex-col space-y-1.5 p-6", className)}
    {...props} />
))
CardHeader.displayName = "CardHeader"
"""

// --------------- CardTitle -------------- //
type [<Erase>] ICardTitleProp = interface end
type [<Erase>] cardTitle =
    inherit prop<ICardTitleProp>
    static member inline noop : unit = ()

let CardTitle : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <div
    ref={ref}
    className={cn("font-semibold leading-none tracking-tight", className)}
    {...props} />
))
CardTitle.displayName = "CardTitle"
"""

// --------------- CardDescription -------------- //
type [<Erase>] ICardDescriptionProp = interface end
type [<Erase>] cardDescription =
    inherit prop<ICardDescriptionProp>
    static member inline noop : unit = ()

let CardDescription : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <div
    ref={ref}
    className={cn("text-sm text-muted-foreground", className)}
    {...props} />
))
CardDescription.displayName = "CardDescription"
"""

// --------------- CardContent -------------- //
type [<Erase>] ICardContentProp = interface end
type [<Erase>] cardContent =
    inherit prop<ICardContentProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let CardContent : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <div ref={ref} className={cn("p-6 pt-0", className)} {...props} />
))
CardContent.displayName = "CardContent"
"""

// --------------- CardFooter -------------- //
type [<Erase>] ICardFooterProp = interface end
type [<Erase>] cardFooter =
    inherit prop<ICardFooterProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let CardFooter : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <div
    ref={ref}
    className={cn("flex items-center p-6 pt-0", className)}
    {...props} />
))
CardFooter.displayName = "CardFooter"
"""

type [<Erase>] Shadcn =
    static member inline Card ( props : ICardProp list ) = JSX.createElement Card props
    static member inline Card ( props : ReactElement list ) = JSX.createElementWithChildren Card props
    static member inline CardHeader ( props : ICardHeaderProp list ) = JSX.createElement CardHeader props
    static member inline CardHeader ( props : ReactElement list ) = JSX.createElementWithChildren CardHeader props
    static member inline CardFooter ( props : ICardFooterProp list ) = JSX.createElement CardFooter props
    static member inline CardFooter ( props : ReactElement list ) = JSX.createElementWithChildren CardFooter props
    static member inline CardTitle ( props : ICardTitleProp list ) = JSX.createElement CardTitle props
    static member inline CardTitle ( props : ReactElement list ) = JSX.createElementWithChildren CardTitle props
    static member inline CardDescription ( props : ICardDescriptionProp list ) = JSX.createElement CardDescription props
    static member inline CardDescription ( props : ReactElement list ) = JSX.createElementWithChildren CardDescription props
    static member inline CardContent ( props : ICardContentProp list ) = JSX.createElement CardContent props
    static member inline CardContent ( props : ReactElement list ) = JSX.createElementWithChildren CardContent props
    