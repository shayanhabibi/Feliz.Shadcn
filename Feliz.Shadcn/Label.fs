﻿[<AutoOpen>]
module Feliz.Shadcn.Label

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI

emitJsStatement () "import * as LabelPrimitive from \"@radix-ui/react-label\""
JSX.injectLib
let labelVariants = JSX.jsx """
import { cva } from "class-variance-authority";
cva(
  "text-sm font-medium leading-none peer-disabled:cursor-not-allowed peer-disabled:opacity-70"
)
"""

// --------------- Label -------------- //
type [<Erase>] ILabelProp = interface end
type [<Erase>] label =
    inherit Label.root<ILabelProp>
    static member inline noop : unit = ()

let Label : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <LabelPrimitive.Root ref={ref} className={cn(labelVariants(), className)} {...props} />
))
Label.displayName = LabelPrimitive.Root.displayName
"""

type [<Erase>] Shadcn =
    static member inline Label ( props : ILabelProp list ) = JSX.createElement Label props
    static member inline Label ( children : ReactElement list ) = JSX.createElementWithChildren Label children
    
  