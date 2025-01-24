[<AutoOpen>]
module Feliz.Shadcn.Label

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI.Interface.NoInherit

emitJsStatement () "import * as LabelPrimitive from \"@radix-ui/react-label\""
JSX.injectShadcnLib
let labelVariants = JSX.jsx """
import { cva } from "class-variance-authority";
cva(
  "text-sm font-medium leading-none peer-disabled:cursor-not-allowed peer-disabled:opacity-70"
)
"""

// --------------- Label -------------- //
type [<Erase>] ILabelProp = interface static member propsInterface : unit = () end
type [<Erase>] label = Label.root<ILabelProp>

let Label : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <LabelPrimitive.Root ref={ref} className={cn(labelVariants(), className)} {...props} />
))
Label.displayName = LabelPrimitive.Root.displayName
"""

type [<Erase>] Shadcn =
    static member inline Label ( props : ILabelProp list ) = JSX.createElement Label props
    static member inline Label ( children : ReactElement list ) = JSX.createElementWithChildren Label children
    static member inline Label ( value : string ) = JSX.createElement Label [ prop.text value ]
    static member inline Label ( el : ReactElement ) = JSX.createElement Label [ label.asChild true ; props.children el ]
    
  