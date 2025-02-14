﻿[<AutoOpen>]
module Feliz.Shadcn.RadioGroup

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
JSX.injectShadcnLib
ignore <| JSX.jsx """
import * as RadioGroupPrimitive from "@radix-ui/react-radio-group"
import { Circle } from "lucide-react"
"""

open Feliz.RadixUI.Interface.NoInherit

// --------------- RadioGroup -------------- //
type [<Erase>] IRadioGroupProp = interface static member propsInterface : unit = () end
type [<Erase>] radioGroup = RadioGroup.root<IRadioGroupProp>

let RadioGroup : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => {
  return (<RadioGroupPrimitive.Root className={cn("grid gap-2", className)} {...props} ref={ref} />);
})
RadioGroup.displayName = RadioGroupPrimitive.Root.displayName
"""

// --------------- RadioGroupItem -------------- //
type [<Erase>] IRadioGroupItemProp = interface static member propsInterface : unit = () end
type [<Erase>] radioGroupItem = RadioGroup.item<IRadioGroupItemProp>
let RadioGroupItem : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => {
  return (
    (<RadioGroupPrimitive.Item
      ref={ref}
      className={cn(
        "aspect-square h-4 w-4 rounded-full border border-primary text-primary shadow focus:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50",
        className
      )}
      {...props}>
      <RadioGroupPrimitive.Indicator className="flex items-center justify-center">
        <Circle className="h-3.5 w-3.5 fill-primary" />
      </RadioGroupPrimitive.Indicator>
    </RadioGroupPrimitive.Item>)
  );
})
RadioGroupItem.displayName = RadioGroupPrimitive.Item.displayName
"""

type [<Erase>] Shadcn =
    static member inline RadioGroup ( props : IRadioGroupProp list ) = JSX.createElement RadioGroup props
    static member inline RadioGroup ( children : ReactElement list ) = JSX.createElementWithChildren RadioGroup children
    static member inline RadioGroup ( el : ReactElement ) = JSX.createElement RadioGroup [ radioGroup.asChild true ; props.children el ]
    static member inline RadioGroupItem ( props : IRadioGroupItemProp list ) = JSX.createElement RadioGroupItem props
    static member inline RadioGroupItem ( children : ReactElement list ) = JSX.createElementWithChildren RadioGroupItem children
    static member inline RadioGroupItem ( value : string , children : ReactElement list ) = JSX.createElement RadioGroupItem [ prop.value value ; prop.children children ]
    static member inline RadioGroupItem ( value : string ) = JSX.createElement RadioGroupItem [ prop.text value ; prop.value value ]
    static member inline RadioGroupItem ( value : string, label : string ) = JSX.createElement RadioGroupItem [ prop.text label ; prop.value value ]
    static member inline RadioGroupItem ( el : ReactElement ) = JSX.createElement RadioGroupItem [ radioGroupItem.asChild true ; props.children el ]
    