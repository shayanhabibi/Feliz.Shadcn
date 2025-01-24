[<AutoOpen>]
module Feliz.Shadcn.Select

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
JSX.injectShadcnLib
ignore <| JSX.jsx """
import * as SelectPrimitive from "@radix-ui/react-select"
import { Check, ChevronDown, ChevronUp } from "lucide-react"
"""

open Feliz.RadixUI.Interface.NoInherit

// --------------- Select -------------- //
type [<Erase>] ISelectProp = interface static member propsInterface : unit = () end
type [<Erase>] select = Select.root<ISelectProp>

let Select : JSX.ElementType = JSX.jsx """
SelectPrimitive.Root
"""

// --------------- SelectGroup -------------- //
type [<Erase>] ISelectGroupProp = interface static member propsInterface : unit = () end
type [<Erase>] selectGroup = Select.group<ISelectGroupProp>

let SelectGroup : JSX.ElementType = JSX.jsx """
SelectPrimitive.Group
"""

// --------------- SelectValue -------------- //
type [<Erase>] ISelectValueProp = interface static member propsInterface : unit = () end
type [<Erase>] selectValue = Select.value<ISelectValueProp>

let SelectValue : JSX.ElementType = JSX.jsx """
SelectPrimitive.Value
"""

// --------------- SelectTrigger -------------- //
type [<Erase>] ISelectTriggerProp = interface static member propsInterface : unit = () end
type [<Erase>] selectTrigger = Select.trigger<ISelectTriggerProp>

let SelectTrigger : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, children, ...props }, ref) => (
  <SelectPrimitive.Trigger
    ref={ref}
    className={cn(
      "flex h-9 w-full items-center justify-between whitespace-nowrap rounded-md border border-input bg-transparent px-3 py-2 text-sm shadow-sm ring-offset-background placeholder:text-muted-foreground focus:outline-none focus:ring-1 focus:ring-ring disabled:cursor-not-allowed disabled:opacity-50 [&>span]:line-clamp-1",
      className
    )}
    {...props}>
    {children}
    <SelectPrimitive.Icon asChild>
      <ChevronDown className="h-4 w-4 opacity-50" />
    </SelectPrimitive.Icon>
  </SelectPrimitive.Trigger>
))
SelectTrigger.displayName = SelectPrimitive.Trigger.displayName
"""

// --------------- SelectScrollUpButton -------------- //
type [<Erase>] ISelectScrollUpButtonProp = interface static member propsInterface : unit = () end
type [<Erase>] selectScrollUpButton = Select.scrollUpButton<ISelectScrollUpButtonProp>

let SelectScrollUpButton : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <SelectPrimitive.ScrollUpButton
    ref={ref}
    className={cn("flex cursor-default items-center justify-center py-1", className)}
    {...props}>
    <ChevronUp className="h-4 w-4" />
  </SelectPrimitive.ScrollUpButton>
))
SelectScrollUpButton.displayName = SelectPrimitive.ScrollUpButton.displayName
"""

// --------------- SelectScrollDownButton -------------- //
type [<Erase>] ISelectScrollDownButtonProp = interface static member propsInterface : unit = () end
type [<Erase>] selectScrollDownButton = Select.scrollDownButton<ISelectScrollDownButtonProp>

let SelectScrollDownButton : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <SelectPrimitive.ScrollDownButton
    ref={ref}
    className={cn("flex cursor-default items-center justify-center py-1", className)}
    {...props}>
    <ChevronDown className="h-4 w-4" />
  </SelectPrimitive.ScrollDownButton>
))
SelectScrollDownButton.displayName =
  SelectPrimitive.ScrollDownButton.displayName
"""

// --------------- SelectContent -------------- //
type [<Erase>] ISelectContentProp = interface static member propsInterface : unit = () end
type [<Erase>] selectContent = Select.content<ISelectContentProp>

let SelectContent : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, children, position = "popper", ...props }, ref) => (
  <SelectPrimitive.Portal>
    <SelectPrimitive.Content
      ref={ref}
      className={cn(
        "relative z-50 max-h-96 min-w-[8rem] overflow-hidden rounded-md border bg-popover text-popover-foreground shadow-md data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0 data-[state=closed]:zoom-out-95 data-[state=open]:zoom-in-95 data-[side=bottom]:slide-in-from-top-2 data-[side=left]:slide-in-from-right-2 data-[side=right]:slide-in-from-left-2 data-[side=top]:slide-in-from-bottom-2",
        position === "popper" &&
          "data-[side=bottom]:translate-y-1 data-[side=left]:-translate-x-1 data-[side=right]:translate-x-1 data-[side=top]:-translate-y-1",
        className
      )}
      position={position}
      {...props}>
      <SelectScrollUpButton />
      <SelectPrimitive.Viewport
        className={cn("p-1", position === "popper" &&
          "h-[var(--radix-select-trigger-height)] w-full min-w-[var(--radix-select-trigger-width)]")}>
        {children}
      </SelectPrimitive.Viewport>
      <SelectScrollDownButton />
    </SelectPrimitive.Content>
  </SelectPrimitive.Portal>
))
SelectContent.displayName = SelectPrimitive.Content.displayName
"""

// --------------- SelectLabel -------------- //
type [<Erase>] ISelectLabelProp = interface static member propsInterface : unit = () end
type [<Erase>] selectLabel = Select.label<ISelectLabelProp>

let SelectLabel : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <SelectPrimitive.Label
    ref={ref}
    className={cn("px-2 py-1.5 text-sm font-semibold", className)}
    {...props} />
))
SelectLabel.displayName = SelectPrimitive.Label.displayName
"""

// --------------- SelectItem -------------- //
type [<Erase>] ISelectItemProp = interface static member propsInterface : unit = () end
type [<Erase>] selectItem = Select.item<ISelectItemProp>

let SelectItem : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, children, ...props }, ref) => (
  <SelectPrimitive.Item
    ref={ref}
    className={cn(
      "relative flex w-full cursor-default select-none items-center rounded-sm py-1.5 pl-2 pr-8 text-sm outline-none focus:bg-accent focus:text-accent-foreground data-[disabled]:pointer-events-none data-[disabled]:opacity-50",
      className
    )}
    {...props}>
    <span className="absolute right-2 flex h-3.5 w-3.5 items-center justify-center">
      <SelectPrimitive.ItemIndicator>
        <Check className="h-4 w-4" />
      </SelectPrimitive.ItemIndicator>
    </span>
    <SelectPrimitive.ItemText>{children}</SelectPrimitive.ItemText>
  </SelectPrimitive.Item>
))
SelectItem.displayName = SelectPrimitive.Item.displayName
"""

// --------------- SelectSeparator -------------- //
type [<Erase>] ISelectSeparatorProp = interface static member propsInterface : unit = () end
type [<Erase>] selectSeparator = Select.separator<ISelectSeparatorProp>

let SelectSeparator : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <SelectPrimitive.Separator
    ref={ref}
    className={cn("-mx-1 my-1 h-px bg-muted", className)}
    {...props} />
))
SelectSeparator.displayName = SelectPrimitive.Separator.displayName
"""

type [<Erase>] Shadcn =
    static member inline Select ( props : ISelectProp list ) = JSX.createElement Select props
    static member inline Select ( children : ReactElement list ) = JSX.createElementWithChildren Select children
    static member inline SelectGroup ( props : ISelectGroupProp list ) = JSX.createElement SelectGroup props
    static member inline SelectGroup ( children : ReactElement list ) = JSX.createElementWithChildren SelectGroup children
    static member inline SelectGroup ( el : ReactElement ) = JSX.createElement SelectGroup [ selectGroup.asChild true ; props.children el ]
    static member inline SelectValue ( props : ISelectValueProp list ) = JSX.createElement SelectValue props
    static member inline SelectValue ( children : ReactElement list ) = JSX.createElementWithChildren SelectValue children
    static member inline SelectValue ( value : string ) = JSX.createElement SelectValue [ prop.text value ]
    static member inline SelectValue ( el : ReactElement ) = JSX.createElement SelectValue [ selectValue.asChild true ; props.children el ]
    static member inline SelectTrigger ( props : ISelectTriggerProp list ) = JSX.createElement SelectTrigger props
    static member inline SelectTrigger ( children : ReactElement list ) = JSX.createElementWithChildren SelectTrigger children
    static member inline SelectTrigger ( value : string ) = JSX.createElement SelectTrigger [ prop.text value ]
    static member inline SelectTrigger ( el : ReactElement ) = JSX.createElement SelectTrigger [ selectTrigger.asChild true ; props.children el ]
    static member inline SelectContent ( props : ISelectContentProp list ) = JSX.createElement SelectContent props
    static member inline SelectContent ( children : ReactElement list ) = JSX.createElementWithChildren SelectContent children
    static member inline SelectContent ( el : ReactElement ) = JSX.createElement SelectContent [ selectContent.asChild true ; props.children el ]
    static member inline SelectLabel ( props : ISelectLabelProp list ) = JSX.createElement SelectLabel props
    static member inline SelectLabel ( children : ReactElement list ) = JSX.createElementWithChildren SelectLabel children
    static member inline SelectLabel ( value : string ) = JSX.createElement SelectLabel [ prop.text value ]
    static member inline SelectLabel ( el : ReactElement ) = JSX.createElement SelectLabel [ selectLabel.asChild true ; props.children el ]
    static member inline SelectItem ( props : ISelectItemProp list ) = JSX.createElement SelectItem props
    static member inline SelectItem ( children : ReactElement list ) = JSX.createElementWithChildren SelectItem children
    static member inline SelectItem ( value : string ) = JSX.createElement SelectItem [ prop.text value ; prop.value value ]
    static member inline SelectItem ( value : string , text : string ) = JSX.createElement SelectItem [ prop.text text ; prop.value value ]
    static member inline SelectItem ( el : ReactElement ) = JSX.createElement SelectItem [ selectItem.asChild true ; props.children el ]
    static member inline SelectSeparator ( props : ISelectSeparatorProp list ) = JSX.createElement SelectSeparator props
    static member inline SelectSeparator ( children : ReactElement list ) = JSX.createElementWithChildren SelectSeparator children
    static member inline SelectSeparator ( ) = JSX.createElement SelectSeparator []
    static member inline SelectScrollUpButton ( props : ISelectScrollUpButtonProp list ) = JSX.createElement SelectScrollUpButton props
    static member inline SelectScrollUpButton ( children : ReactElement list ) = JSX.createElementWithChildren SelectScrollUpButton children
    static member inline SelectScrollUpButton () = JSX.createElement SelectScrollUpButton []
    static member inline SelectScrollUpButton ( value : string ) = JSX.createElement SelectScrollUpButton [ prop.text value ]
    static member inline SelectScrollUpButton ( el : ReactElement ) = JSX.createElement SelectScrollUpButton [ selectScrollUpButton.asChild true ; props.children el ]
    static member inline SelectScrollDownButton ( props : ISelectScrollDownButtonProp list ) = JSX.createElement SelectScrollDownButton props
    static member inline SelectScrollDownButton ( children : ReactElement list ) = JSX.createElementWithChildren SelectScrollDownButton children
    static member inline SelectScrollDownButton () = JSX.createElement SelectScrollDownButton []
    static member inline SelectScrollDownButton ( value : string ) = JSX.createElement SelectScrollDownButton [ prop.text value ]
    static member inline SelectScrollDownButton ( el : ReactElement ) = JSX.createElement SelectScrollDownButton [ selectScrollDownButton.asChild true ; props.children el ]