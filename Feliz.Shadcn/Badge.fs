[<AutoOpen>]
module Feliz.Shadcn.Badge

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
JSX.injectShadcnLib

let badgeVariants = JSX.jsx """
import { cva } from "class-variance-authority";
cva(
  "inline-flex items-center rounded-md border px-2.5 py-0.5 text-xs font-semibold transition-colors focus:outline-none focus:ring-2 focus:ring-ring focus:ring-offset-2",
  {
    variants: {
      variant: {
        default:
          "border-transparent bg-primary text-primary-foreground shadow hover:bg-primary/80",
        secondary:
          "border-transparent bg-secondary text-secondary-foreground hover:bg-secondary/80",
        destructive:
          "border-transparent bg-destructive text-destructive-foreground shadow hover:bg-destructive/80",
        outline: "text-foreground",
      },
    },
    defaultVariants: {
      variant: "default",
    },
  }
)"""

// --------------- Badge -------------- //
type [<Erase>] IBadgeProp = interface static member propsInterface : unit = () end
// type [<Erase>] badge = static member inline noop : unit = ()
module [<Erase>] badge =
    type [<Erase>] variant =
        static member inline default' : IBadgeProp = Interop.mkProperty "variant" "default"
        static member inline secondary : IBadgeProp = Interop.mkProperty "variant" "secondary"
        static member inline destructive : IBadgeProp = Interop.mkProperty "variant" "destructive"
        static member inline outline : IBadgeProp = Interop.mkProperty "variant" "outline"

[<JSX.Component>]
let Badge : JSX.ElementType = JSX.jsx """
({
  className,
  variant,
  ...props
}) => {
  return (<div className={cn(badgeVariants({ variant }), className)} {...props} />);
}
"""

type [<Erase>] Shadcn =
    static member inline Badge ( props : IBadgeProp list ) = JSX.createElement Badge props
    static member inline Badge ( children : ReactElement list ) = JSX.createElementWithChildren Badge children
    static member inline Badge ( value : string ) = JSX.createElement Badge [ prop.text value ]
    static member inline Badge ( variant : IBadgeProp , value : string ) = JSX.createElement Badge [ variant ; badge.text value ]
    