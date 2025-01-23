[<AutoOpen>]
module Feliz.Shadcn.DropdownMenu

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI.Interface.NoInherit
JSX.injectShadcnLib
ignore <| JSX.jsx """
import * as DropdownMenuPrimitive from "@radix-ui/react-dropdown-menu";
import { Check, ChevronRight, Circle } from "lucide-react";
"""

// --------------- DropdownMenu -------------- //
type [<Erase>] IDropdownMenuProp = interface static member propsInterface : unit = () end
type [<Erase>] dropdownMenu = DropdownMenu.root<IDropdownMenuProp>

let DropdownMenu : JSX.ElementType = JSX.jsx """
DropdownMenuPrimitive.Root
"""

// --------------- DropdownMenuTrigger -------------- //
type [<Erase>] IDropdownMenuTriggerProp = interface static member propsInterface : unit = () end
type [<Erase>] dropdownMenuTrigger = DropdownMenu.trigger<IDropdownMenuTriggerProp>

let DropdownMenuTrigger : JSX.ElementType = JSX.jsx """
DropdownMenuPrimitive.Trigger
"""

// --------------- DropdownMenuGroup -------------- //
type [<Erase>] IDropdownMenuGroupProp = interface static member propsInterface : unit = () end
type [<Erase>] dropdownMenuGroup = DropdownMenu.group<IDropdownMenuGroupProp>

let DropdownMenuGroup : JSX.ElementType = JSX.jsx """
DropdownMenuPrimitive.Group
"""

// --------------- DropdownMenuPortal -------------- //
type [<Erase>] IDropdownMenuPortalProp = interface static member propsInterface : unit = () end
type [<Erase>] dropdownMenuPortal = DropdownMenu.portal<IDropdownMenuPortalProp>

let DropdownMenuPortal : JSX.ElementType = JSX.jsx """
DropdownMenuPrimitive.Portal
"""

// --------------- DropdownMenuSub -------------- //
type [<Erase>] IDropdownMenuSubProp = interface static member propsInterface : unit = () end
type [<Erase>] dropdownMenuSub = DropdownMenu.sub<IDropdownMenuSubProp>

let DropdownMenuSub : JSX.ElementType = JSX.jsx """
DropdownMenuPrimitive.Sub
"""

// --------------- DropdownMenuRadioGroup -------------- //
type [<Erase>] IDropdownMenuRadioGroupProp = interface static member propsInterface : unit = () end
type [<Erase>] dropdownMenuRadioGroup = DropdownMenu.radioGroup<IDropdownMenuRadioGroupProp>

let DropdownMenuRadioGroup : JSX.ElementType = JSX.jsx """
DropdownMenuPrimitive.RadioGroup
"""

// --------------- DropdownMenuSubTrigger -------------- //
type [<Erase>] IDropdownMenuSubTriggerProp = interface static member propsInterface : unit = () end
type [<Erase>] dropdownMenuSubTrigger =
    inherit DropdownMenu.subTrigger<IDropdownMenuSubTriggerProp>
    static member inline inset ( value : bool ) : IDropdownMenuSubTriggerProp = Interop.mkProperty "inset" value

let DropdownMenuSubTrigger : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, inset, children, ...props }, ref) => (
  <DropdownMenuPrimitive.SubTrigger
    ref={ref}
    className={cn(
      "flex cursor-default gap-2 select-none items-center rounded-sm px-2 py-1.5 text-sm outline-none focus:bg-accent data-[state=open]:bg-accent [&_svg]:pointer-events-none [&_svg]:size-4 [&_svg]:shrink-0",
      inset && "pl-8",
      className
    )}
    {...props}>
    {children}
    <ChevronRight className="ml-auto" />
  </DropdownMenuPrimitive.SubTrigger>
))
DropdownMenuSubTrigger.displayName =
  DropdownMenuPrimitive.SubTrigger.displayName
"""

// --------------- DropdownMenuSubContent -------------- //
type [<Erase>] IDropdownMenuSubContentProp = interface static member propsInterface : unit = () end
type [<Erase>] dropdownMenuSubContent = DropdownMenu.subContent<IDropdownMenuSubContentProp>

let DropdownMenuSubContent : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <DropdownMenuPrimitive.SubContent
    ref={ref}
    className={cn(
      "z-50 min-w-[8rem] overflow-hidden rounded-md border bg-popover p-1 text-popover-foreground shadow-lg data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0 data-[state=closed]:zoom-out-95 data-[state=open]:zoom-in-95 data-[side=bottom]:slide-in-from-top-2 data-[side=left]:slide-in-from-right-2 data-[side=right]:slide-in-from-left-2 data-[side=top]:slide-in-from-bottom-2",
      className
    )}
    {...props} />
))
DropdownMenuSubContent.displayName =
  DropdownMenuPrimitive.SubContent.displayName
"""

// --------------- DropdownMenuContent -------------- //
type [<Erase>] IDropdownMenuContentProp = interface static member propsInterface : unit = () end
type [<Erase>] dropdownMenuContent = DropdownMenu.content<IDropdownMenuContentProp>

let DropdownMenuContent : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, sideOffset = 4, ...props }, ref) => (
  <DropdownMenuPrimitive.Portal>
    <DropdownMenuPrimitive.Content
      ref={ref}
      sideOffset={sideOffset}
      className={cn(
        "z-50 min-w-[8rem] overflow-hidden rounded-md border bg-popover p-1 text-popover-foreground shadow-md",
        "data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0 data-[state=closed]:zoom-out-95 data-[state=open]:zoom-in-95 data-[side=bottom]:slide-in-from-top-2 data-[side=left]:slide-in-from-right-2 data-[side=right]:slide-in-from-left-2 data-[side=top]:slide-in-from-bottom-2",
        className
      )}
      {...props} />
  </DropdownMenuPrimitive.Portal>
))
DropdownMenuContent.displayName = DropdownMenuPrimitive.Content.displayName
"""

// --------------- DropdownMenuItem -------------- //
type [<Erase>] IDropdownMenuItemProp = interface static member propsInterface : unit = () end
type [<Erase>] dropdownMenuItem =
    inherit DropdownMenu.item<IDropdownMenuItemProp>
    static member inline inset ( value : bool ) : IDropdownMenuItemProp = Interop.mkProperty "inset" value

let DropdownMenuItem : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, inset, ...props }, ref) => (
  <DropdownMenuPrimitive.Item
    ref={ref}
    className={cn(
      "relative flex cursor-default select-none items-center gap-2 rounded-sm px-2 py-1.5 text-sm outline-none transition-colors focus:bg-accent focus:text-accent-foreground data-[disabled]:pointer-events-none data-[disabled]:opacity-50 [&>svg]:size-4 [&>svg]:shrink-0",
      inset && "pl-8",
      className
    )}
    {...props} />
))
DropdownMenuItem.displayName = DropdownMenuPrimitive.Item.displayName
"""

// --------------- DropdownMenuCheckboxItem -------------- //
type [<Erase>] IDropdownMenuCheckboxItemProp = interface static member propsInterface : unit = () end
type [<Erase>] dropdownMenuCheckboxItem = DropdownMenu.checkboxItem<IDropdownMenuCheckboxItemProp>

let DropdownMenuCheckboxItem : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, children, checked, ...props }, ref) => (
  <DropdownMenuPrimitive.CheckboxItem
    ref={ref}
    className={cn(
      "relative flex cursor-default select-none items-center rounded-sm py-1.5 pl-8 pr-2 text-sm outline-none transition-colors focus:bg-accent focus:text-accent-foreground data-[disabled]:pointer-events-none data-[disabled]:opacity-50",
      className
    )}
    checked={checked}
    {...props}>
    <span className="absolute left-2 flex h-3.5 w-3.5 items-center justify-center">
      <DropdownMenuPrimitive.ItemIndicator>
        <Check className="h-4 w-4" />
      </DropdownMenuPrimitive.ItemIndicator>
    </span>
    {children}
  </DropdownMenuPrimitive.CheckboxItem>
))
DropdownMenuCheckboxItem.displayName =
  DropdownMenuPrimitive.CheckboxItem.displayName
"""

// --------------- DropdownMenuRadioItem -------------- //
type [<Erase>] IDropdownMenuRadioItemProp = interface static member propsInterface : unit = () end
type [<Erase>] dropdownMenuRadioItem = DropdownMenu.radioItem<IDropdownMenuRadioItemProp>

let DropdownMenuRadioItem : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, children, ...props }, ref) => (
  <DropdownMenuPrimitive.RadioItem
    ref={ref}
    className={cn(
      "relative flex cursor-default select-none items-center rounded-sm py-1.5 pl-8 pr-2 text-sm outline-none transition-colors focus:bg-accent focus:text-accent-foreground data-[disabled]:pointer-events-none data-[disabled]:opacity-50",
      className
    )}
    {...props}>
    <span className="absolute left-2 flex h-3.5 w-3.5 items-center justify-center">
      <DropdownMenuPrimitive.ItemIndicator>
        <Circle className="h-2 w-2 fill-current" />
      </DropdownMenuPrimitive.ItemIndicator>
    </span>
    {children}
  </DropdownMenuPrimitive.RadioItem>
))
DropdownMenuRadioItem.displayName = DropdownMenuPrimitive.RadioItem.displayName
"""

// --------------- DropdownMenuLabel -------------- //
type [<Erase>] IDropdownMenuLabelProp = interface static member propsInterface : unit = () end
type [<Erase>] dropdownMenuLabel =
    inherit DropdownMenu.label<IDropdownMenuLabelProp>
    static member inline inset ( value : bool ) : IDropdownMenuLabelProp = Interop.mkProperty "inset" value

let DropdownMenuLabel : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, inset, ...props }, ref) => (
  <DropdownMenuPrimitive.Label
    ref={ref}
    className={cn("px-2 py-1.5 text-sm font-semibold", inset && "pl-8", className)}
    {...props} />
))
DropdownMenuLabel.displayName = DropdownMenuPrimitive.Label.displayName
"""

// --------------- DropdownMenuSeparator -------------- //
type [<Erase>] IDropdownMenuSeparatorProp = interface static member propsInterface : unit = () end
type [<Erase>] dropdownMenuSeparator = DropdownMenu.separator<IDropdownMenuSeparatorProp>

let DropdownMenuSeparator : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <DropdownMenuPrimitive.Separator
    ref={ref}
    className={cn("-mx-1 my-1 h-px bg-muted", className)}
    {...props} />
))
DropdownMenuSeparator.displayName = DropdownMenuPrimitive.Separator.displayName
"""

// --------------- DropdownMenuShortcut -------------- //
type [<Erase>] IDropdownMenuShortcutProp = interface static member propsInterface : unit = () end

let DropdownMenuShortcut : JSX.ElementType = JSX.jsx """
({
  className,
  ...props
}) => {
  return (
    (<span
      className={cn("ml-auto text-xs tracking-widest opacity-60", className)}
      {...props} />)
  );
}
DropdownMenuShortcut.displayName = "DropdownMenuShortcut"
"""

type [<Erase>] Shadcn =
    static member inline DropdownMenu ( props : IDropdownMenuProp list ) = JSX.createElement DropdownMenu props
    static member inline DropdownMenu ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenu children
    static member inline DropdownMenuTrigger ( props : IDropdownMenuTriggerProp list ) = JSX.createElement DropdownMenuTrigger props
    static member inline DropdownMenuTrigger ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuTrigger children
    static member inline DropdownMenuTrigger ( value : string ) = JSX.createElement DropdownMenuTrigger [ prop.text value ]
    static member inline DropdownMenuTrigger ( el : ReactElement ) = JSX.createElement DropdownMenuTrigger [ dropdownMenuTrigger.asChild true ; dropdownMenuTrigger.children el ]
    static member inline DropdownMenuContent ( props : IDropdownMenuContentProp list ) = JSX.createElement DropdownMenuContent props
    static member inline DropdownMenuContent ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuContent children
    static member inline DropdownMenuContent ( el : ReactElement ) = JSX.createElement DropdownMenuContent [ dropdownMenuContent.asChild true ; dropdownMenuContent.children el ]
    static member inline DropdownMenuItem ( props : IDropdownMenuItemProp list ) = JSX.createElement DropdownMenuItem props
    static member inline DropdownMenuItem ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuItem children
    static member inline DropdownMenuItem ( value : string ) = JSX.createElement DropdownMenuItem [ prop.text value ]
    static member inline DropdownMenuItem ( el : ReactElement ) = JSX.createElement DropdownMenuItem [ dropdownMenuItem.asChild true ; dropdownMenuItem.children el ]
    static member inline DropdownMenuCheckboxItem ( props : IDropdownMenuCheckboxItemProp list ) = JSX.createElement DropdownMenuCheckboxItem props
    static member inline DropdownMenuCheckboxItem ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuCheckboxItem children
    static member inline DropdownMenuCheckboxItem ( value : string ) = JSX.createElement DropdownMenuCheckboxItem [ prop.text value ]
    static member inline DropdownMenuCheckboxItem ( el : ReactElement ) = JSX.createElement DropdownMenuCheckboxItem [ dropdownMenuCheckboxItem.asChild true ; dropdownMenuCheckboxItem.children el ]
    static member inline DropdownMenuRadioItem ( props : IDropdownMenuRadioItemProp list ) = JSX.createElement DropdownMenuRadioItem props
    static member inline DropdownMenuRadioItem ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuRadioItem children
    static member inline DropdownMenuRadioItem ( value : string ) = JSX.createElement DropdownMenuRadioItem [ prop.text value ; prop.value value ]
    static member inline DropdownMenuRadioItem ( value : string, label : string ) = JSX.createElement DropdownMenuRadioItem [ prop.text label ; prop.value value ]
    static member inline DropdownMenuRadioItem ( el : ReactElement ) = JSX.createElement DropdownMenuRadioItem [ dropdownMenuRadioItem.asChild true ; dropdownMenuRadioItem.children el ]
    static member inline DropdownMenuLabel ( props : IDropdownMenuLabelProp list ) = JSX.createElement DropdownMenuLabel props
    static member inline DropdownMenuLabel ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuLabel children
    static member inline DropdownMenuLabel ( value : string ) = JSX.createElement DropdownMenuLabel [ prop.text value ]
    static member inline DropdownMenuLabel ( el : ReactElement ) = JSX.createElement DropdownMenuLabel [ dropdownMenuLabel.asChild true ; dropdownMenuLabel.children el ]
    static member inline DropdownMenuSeparator ( props : IDropdownMenuSeparatorProp list ) = JSX.createElement DropdownMenuSeparator props
    static member inline DropdownMenuSeparator ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuSeparator children
    static member inline DropdownMenuSeparator () = JSX.createElement DropdownMenuSeparator []
    static member inline DropdownMenuShortcut ( props : IDropdownMenuShortcutProp list ) = JSX.createElement DropdownMenuShortcut props
    static member inline DropdownMenuShortcut ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuShortcut children
    static member inline DropdownMenuShortcut ( value : string ) = JSX.createElement DropdownMenuShortcut [ prop.text value ]
    static member inline DropdownMenuGroup ( props : IDropdownMenuGroupProp list ) = JSX.createElement DropdownMenuGroup props
    static member inline DropdownMenuGroup ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuGroup children
    static member inline DropdownMenuGroup ( el : ReactElement ) = JSX.createElement DropdownMenuGroup [ dropdownMenuGroup.asChild true ; dropdownMenuGroup.children el ]
    static member inline DropdownMenuPortal ( props : IDropdownMenuPortalProp list ) = JSX.createElement DropdownMenuPortal props
    static member inline DropdownMenuPortal ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuPortal children
    static member inline DropdownMenuSub ( props : IDropdownMenuSubProp list ) = JSX.createElement DropdownMenuSub props
    static member inline DropdownMenuSub ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuSub children
    static member inline DropdownMenuSubContent ( props : IDropdownMenuSubContentProp list ) = JSX.createElement DropdownMenuSubContent props
    static member inline DropdownMenuSubContent ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuSubContent children
    static member inline DropdownMenuSubContent ( el : ReactElement ) = JSX.createElement DropdownMenuSubContent [ dropdownMenuSubContent.asChild true ; dropdownMenuSubContent.children el ]
    static member inline DropdownMenuSubTrigger ( props : IDropdownMenuSubTriggerProp list ) = JSX.createElement DropdownMenuSubTrigger props
    static member inline DropdownMenuSubTrigger ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuSubTrigger children
    static member inline DropdownMenuSubTrigger ( value : string ) = JSX.createElement DropdownMenuSubTrigger [ prop.text value ]
    static member inline DropdownMenuSubTrigger ( el : ReactElement ) = JSX.createElement DropdownMenuSubTrigger [ dropdownMenuSubTrigger.asChild true ; dropdownMenuSubTrigger.children el ]
    static member inline DropdownMenuRadioGroup ( props : IDropdownMenuRadioGroupProp list ) = JSX.createElement DropdownMenuRadioGroup props
    static member inline DropdownMenuRadioGroup ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuRadioGroup children
    static member inline DropdownMenuRadioGroup ( value : string , children : ReactElement list ) = JSX.createElement DropdownMenuRadioGroup [ prop.value value ; prop.children children ]
    static member inline DropdownMenuRadioGroup ( el : ReactElement ) = JSX.createElement DropdownMenuRadioGroup [ dropdownMenuRadioGroup.asChild true ; dropdownMenuRadioGroup.children el ]
                                                        