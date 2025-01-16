[<AutoOpen>]
module Feliz.Shadcn.Checkbox

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI.Interface

emitJsStatement () "import * as CheckboxPrimitive from \"@radix-ui/react-checkbox\""
JSX.injectShadcnLib

type [<Erase>] ICheckboxProp = interface end
type [<Erase>] checkbox =
    inherit Checkbox.root<ICheckboxProp>
    static member private noop = ()

let Checkbox : JSX.ElementType = JSX.jsx """
import { Check } from "lucide-react";
React.forwardRef(({ className, ...props }, ref) => (
  <CheckboxPrimitive.Root
    ref={ref}
    className={cn(
      "peer h-4 w-4 shrink-0 rounded-sm border border-primary shadow focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50 data-[state=checked]:bg-primary data-[state=checked]:text-primary-foreground",
      className
    )}
    {...props}>
    <CheckboxPrimitive.Indicator className={cn("flex items-center justify-center text-current")}>
      <Check className="h-4 w-4" />
    </CheckboxPrimitive.Indicator>
  </CheckboxPrimitive.Root>
))
Checkbox.displayName = CheckboxPrimitive.Root.displayName
"""

type [<Erase>] Shadcn =
    static member inline Checkbox ( props : ICheckboxProp list ) = JSX.createElement Checkbox props
    static member inline Checkbox ( children : ReactElement list ) = JSX.createElementWithChildren Checkbox children
    static member inline Checkbox ( value : string ) = JSX.createElement Checkbox [ prop.id value ]
    static member inline Checkbox ( el : ReactElement ) = JSX.createElement Checkbox [ checkbox.asChild true ; checkbox.children el ]
  