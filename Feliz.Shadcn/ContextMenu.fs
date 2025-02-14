﻿[<AutoOpen>]
module Feliz.Shadcn.ContextMenu

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI.Interface.NoInherit

emitJsStatement () "import * as ContextMenuPrimitive from \"@radix-ui/react-context-menu\""
JSX.injectShadcnLib

// --------------- ContextMenu -------------- //
type [<Erase>] IContextMenuProp = interface static member propsInterface : unit = () end
type [<Erase>] contextMenu = ContextMenu.root<IContextMenuProp>

let ContextMenu : JSX.ElementType = JSX.jsx "ContextMenuPrimitive.Root"

// --------------- ContextMenuTrigger -------------- //
type [<Erase>] IContextMenuTriggerProp = interface static member propsInterface : unit = () end
type [<Erase>] contextMenuTrigger = ContextMenu.trigger<IContextMenuTriggerProp>

let ContextMenuTrigger : JSX.ElementType = JSX.jsx "ContextMenuPrimitive.Trigger"
    
// --------------- ContextMenuGroup -------------- //
type [<Erase>] IContextMenuGroupProp = interface static member propsInterface : unit = () end
type [<Erase>] contextMenuGroup = ContextMenu.group<IContextMenuGroupProp>

let ContextMenuGroup : JSX.ElementType = JSX.jsx "ContextMenuPrimitive.Group"

// --------------- ContextMenuPortal -------------- //
type [<Erase>] IContextMenuPortalProp = interface static member propsInterface : unit = () end
type [<Erase>] contextMenuPortal = ContextMenu.portal<IContextMenuPortalProp>

let ContextMenuPortal : JSX.ElementType = JSX.jsx "ContextMenuPrimitive.Portal"

// --------------- ContextMenuSub -------------- //
type [<Erase>] IContextMenuSubProp = interface static member propsInterface : unit = () end
type [<Erase>] contextMenuSub = ContextMenu.sub<IContextMenuSubProp>

let ContextMenuSub : JSX.ElementType = JSX.jsx "ContextMenuPrimitive.Sub"

// --------------- ContextMenuRadioGroup -------------- //
type [<Erase>] IContextMenuRadioGroupProp = interface static member propsInterface : unit = () end
type [<Erase>] contextMenuRadioGroup = ContextMenu.radioGroup<IContextMenuRadioGroupProp>

let ContextMenuRadioGroup : JSX.ElementType = JSX.jsx "ContextMenuPrimitive.RadioGroup"

// --------------- ContextMenuSubTrigger -------------- //
type [<Erase>] IContextMenuSubTriggerProp = interface static member propsInterface : unit = () end
type [<Erase>] contextMenuSubTrigger = ContextMenu.subTrigger<IContextMenuSubTriggerProp>

open Feliz.Lucide

let ContextMenuSubTrigger : JSX.ElementType = JSX.jsx """
import {ChevronRight} from "lucide-react";
React.forwardRef(({ className, inset, children, ...props }, ref) => (
  <ContextMenuPrimitive.SubTrigger
    ref={ref}
    className={cn(
      "flex cursor-default select-none items-center rounded-sm px-2 py-1.5 text-sm outline-none focus:bg-accent focus:text-accent-foreground data-[state=open]:bg-accent data-[state=open]:text-accent-foreground",
      inset && "pl-8",
      className
    )}
    {...props}>
    {children}
    <ChevronRight className="ml-auto h-4 w-4" />
  </ContextMenuPrimitive.SubTrigger>
))
ContextMenuSubTrigger.displayName = ContextMenuPrimitive.SubTrigger.displayName
"""

// --------------- ContextMenuSubContent -------------- //
type [<Erase>] IContextMenuSubContentProp = interface static member propsInterface : unit = () end
type [<Erase>] contextMenuSubContent = ContextMenu.subContent<IContextMenuSubContentProp>

let ContextMenuSubContent : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <ContextMenuPrimitive.SubContent
    ref={ref}
    className={cn(
      "z-50 min-w-[8rem] overflow-hidden rounded-md border bg-popover p-1 text-popover-foreground shadow-lg data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0 data-[state=closed]:zoom-out-95 data-[state=open]:zoom-in-95 data-[side=bottom]:slide-in-from-top-2 data-[side=left]:slide-in-from-right-2 data-[side=right]:slide-in-from-left-2 data-[side=top]:slide-in-from-bottom-2",
      className
    )}
    {...props} />
))
ContextMenuSubContent.displayName = ContextMenuPrimitive.SubContent.displayName
"""

// --------------- ContextMenuContent -------------- //
type [<Erase>] IContextMenuContentProp = interface static member propsInterface : unit = () end
type [<Erase>] contextMenuContent = ContextMenu.content<IContextMenuContentProp>

[<JSX.Component>]
let ContextMenuContent : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <ContextMenuPrimitive.Portal>
    <ContextMenuPrimitive.Content
      ref={ref}
      className={cn(
        "z-50 min-w-[8rem] overflow-hidden rounded-md border bg-popover p-1 text-popover-foreground shadow-md data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0 data-[state=closed]:zoom-out-95 data-[state=open]:zoom-in-95 data-[side=bottom]:slide-in-from-top-2 data-[side=left]:slide-in-from-right-2 data-[side=right]:slide-in-from-left-2 data-[side=top]:slide-in-from-bottom-2",
        className
      )}
      {...props} />
  </ContextMenuPrimitive.Portal>
))
ContextMenuContent.displayName = ContextMenuPrimitive.Content.displayName
"""
    
// --------------- ContextMenuItem -------------- //
type [<Erase>] IContextMenuItemProp = interface static member propsInterface : unit = () end
type [<Erase>] contextMenuItem =
    inherit ContextMenu.item<IContextMenuItemProp>
    static member inline inset ( value : bool ) : IContextMenuItemProp = Interop.mkProperty "inset" value

[<JSX.Component>]
let ContextMenuItem : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, inset, ...props }, ref) => (
  <ContextMenuPrimitive.Item
    ref={ref}
    className={cn(
      "relative flex cursor-default select-none items-center rounded-sm px-2 py-1.5 text-sm outline-none focus:bg-accent focus:text-accent-foreground data-[disabled]:pointer-events-none data-[disabled]:opacity-50",
      inset && "pl-8",
      className
    )}
    {...props} />
))
ContextMenuItem.displayName = ContextMenuPrimitive.Item.displayName
"""
    
// --------------- ContextMenuCheckboxItem -------------- //
type [<Erase>] IContextMenuCheckboxItemProp = interface static member propsInterface : unit = () end
type [<Erase>] contextMenuCheckboxItem = ContextMenu.checkboxItem<IContextMenuCheckboxItemProp>

[<JSX.Component>]
let ContextMenuCheckboxItem : JSX.ElementType = JSX.jsx """
import { Check } from "lucide-react";
React.forwardRef(({ className, children, checked, ...props }, ref) => (
  <ContextMenuPrimitive.CheckboxItem
    ref={ref}
    className={cn(
      "relative flex cursor-default select-none items-center rounded-sm py-1.5 pl-8 pr-2 text-sm outline-none focus:bg-accent focus:text-accent-foreground data-[disabled]:pointer-events-none data-[disabled]:opacity-50",
      className
    )}
    checked={checked}
    {...props}>
    <span className="absolute left-2 flex h-3.5 w-3.5 items-center justify-center">
      <ContextMenuPrimitive.ItemIndicator>
        <Check className="h-4 w-4" />
      </ContextMenuPrimitive.ItemIndicator>
    </span>
    {children}
  </ContextMenuPrimitive.CheckboxItem>
))
ContextMenuCheckboxItem.displayName =
  ContextMenuPrimitive.CheckboxItem.displayName
"""

// --------------- ContextMenuRadioItem -------------- //
type [<Erase>] IContextMenuRadioItemProp = interface static member propsInterface : unit = () end
type [<Erase>] contextMenuRadioItem = ContextMenu.radioItem<IContextMenuRadioItemProp>

[<JSX.Component>]
let ContextMenuRadioItem : JSX.ElementType = JSX.jsx """
import { Circle } from "lucide-react";
React.forwardRef(({ className, children, ...props }, ref) => (
  <ContextMenuPrimitive.RadioItem
    ref={ref}
    className={cn(
      "relative flex cursor-default select-none items-center rounded-sm py-1.5 pl-8 pr-2 text-sm outline-none focus:bg-accent focus:text-accent-foreground data-[disabled]:pointer-events-none data-[disabled]:opacity-50",
      className
    )}
    {...props}>
    <span className="absolute left-2 flex h-3.5 w-3.5 items-center justify-center">
      <ContextMenuPrimitive.ItemIndicator>
        <Circle className="h-4 w-4 fill-current" />
      </ContextMenuPrimitive.ItemIndicator>
    </span>
    {children}
  </ContextMenuPrimitive.RadioItem>
))
ContextMenuRadioItem.displayName = ContextMenuPrimitive.RadioItem.displayName
"""

// --------------- ContextMenuLabel -------------- //
type [<Erase>] IContextMenuLabelProp = interface static member propsInterface : unit = () end
type [<Erase>] contextMenuLabel =
    inherit ContextMenu.label<IContextMenuLabelProp>
    static member inline inset ( value : bool ) : IContextMenuLabelProp = Interop.mkProperty "inset" value

[<JSX.Component>]
let ContextMenuLabel : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, inset, ...props }, ref) => (
  <ContextMenuPrimitive.Label
    ref={ref}
    className={cn(
      "px-2 py-1.5 text-sm font-semibold text-foreground",
      inset && "pl-8",
      className
    )}
    {...props} />
))
ContextMenuLabel.displayName = ContextMenuPrimitive.Label.displayName
"""

// --------------- ContextMenuSeparator -------------- //
type [<Erase>] IContextMenuSeparatorProp = interface static member propsInterface : unit = () end
type [<Erase>] contextMenuSeparator = ContextMenu.separator<IContextMenuSeparatorProp>

[<JSX.Component>]
let ContextMenuSeparator : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <ContextMenuPrimitive.Separator
    ref={ref}
    className={cn("-mx-1 my-1 h-px bg-border", className)}
    {...props} />
))
ContextMenuSeparator.displayName = ContextMenuPrimitive.Separator.displayName
"""

// --------------- ContextMenuShortcut -------------- //
type [<Erase>] IContextMenuShortcutProp = interface static member propsInterface : unit = () end

[<JSX.Component>]
let ContextMenuShortcut : JSX.ElementType = JSX.jsx """
({
  className,
  ...props
}) => {
  return (
    (<span
      className={cn("ml-auto text-xs tracking-widest text-muted-foreground", className)}
      {...props} />)
  );
}
ContextMenuShortcut.displayName = "ContextMenuShortcut"
"""

type [<Erase>] Shadcn =
    static member inline ContextMenu ( props : IContextMenuProp list ) = JSX.createElement ContextMenu props
    static member inline ContextMenu ( children : ReactElement list ) = JSX.createElementWithChildren ContextMenu children
    static member inline ContextMenuTrigger ( props : IContextMenuTriggerProp list ) = JSX.createElement ContextMenuTrigger props
    static member inline ContextMenuTrigger ( children : ReactElement list ) = JSX.createElementWithChildren ContextMenuTrigger children
    static member inline ContextMenuTrigger ( value : string ) = JSX.createElement ContextMenuTrigger [ prop.text value ]
    static member inline ContextMenuTrigger ( el : ReactElement ) = JSX.createElement ContextMenuTrigger [ contextMenuTrigger.asChild true ; props.children el ]
    static member inline ContextMenuContent ( props : IContextMenuContentProp list ) = JSX.createElement ContextMenuContent props
    static member inline ContextMenuContent ( children : ReactElement list ) = JSX.createElementWithChildren ContextMenuContent children
    static member inline ContextMenuContent ( el : ReactElement ) = JSX.createElement ContextMenuContent [ contextMenuContent.asChild true ; props.children el ]
    static member inline ContextMenuItem ( props : IContextMenuItemProp list ) = JSX.createElement ContextMenuItem props
    static member inline ContextMenuItem ( children : ReactElement list ) = JSX.createElementWithChildren ContextMenuItem children
    static member inline ContextMenuItem ( value : string ) = JSX.createElement ContextMenuItem [ prop.text value ]
    static member inline ContextMenuItem ( el : ReactElement ) = JSX.createElement ContextMenuItem [ contextMenuItem.asChild true ; props.children el ]
    static member inline ContextMenuCheckboxItem ( props : IContextMenuCheckboxItemProp list ) = JSX.createElement ContextMenuCheckboxItem props
    static member inline ContextMenuCheckboxItem ( children : ReactElement list ) = JSX.createElementWithChildren ContextMenuCheckboxItem children
    static member inline ContextMenuCheckboxItem ( value : string ) = JSX.createElement ContextMenuCheckboxItem [ prop.text value ]
    static member inline ContextMenuCheckboxItem ( el : ReactElement ) = JSX.createElement ContextMenuCheckboxItem [ contextMenuCheckboxItem.asChild true ; props.children el ]
    static member inline ContextMenuRadioItem ( props : IContextMenuRadioItemProp list ) = JSX.createElement ContextMenuRadioItem props
    static member inline ContextMenuRadioItem ( children : ReactElement list ) = JSX.createElementWithChildren ContextMenuRadioItem children
    static member inline ContextMenuRadioItem ( value : string ) = JSX.createElement ContextMenuRadioItem [ prop.text value ; prop.value value ]
    static member inline ContextMenuRadioItem ( value : string, label : string ) = JSX.createElement ContextMenuRadioItem [ prop.text label ; prop.value value ]
    static member inline ContextMenuRadioItem ( el : ReactElement ) = JSX.createElement ContextMenuRadioItem [ contextMenuRadioItem.asChild true ; props.children el ]
    static member inline ContextMenuLabel ( props : IContextMenuLabelProp list ) = JSX.createElement ContextMenuLabel props
    static member inline ContextMenuLabel ( children : ReactElement list ) = JSX.createElementWithChildren ContextMenuLabel children
    static member inline ContextMenuLabel ( value : string ) = JSX.createElement ContextMenuLabel [ prop.text value ]
    static member inline ContextMenuLabel ( el : ReactElement ) = JSX.createElement ContextMenuLabel [ contextMenuLabel.asChild true ; props.children el ]
    static member inline ContextMenuSeparator ( props : IContextMenuSeparatorProp list ) = JSX.createElement ContextMenuSeparator props
    static member inline ContextMenuSeparator () = JSX.createElement ContextMenuSeparator []
    static member inline ContextMenuSeparator ( children : ReactElement list ) = JSX.createElementWithChildren ContextMenuSeparator children
    static member inline ContextMenuShortcut ( props : IContextMenuShortcutProp list ) = JSX.createElement ContextMenuShortcut props
    static member inline ContextMenuShortcut ( children : ReactElement list ) = JSX.createElementWithChildren ContextMenuShortcut children
    static member inline ContextMenuShortcut ( value : string ) = JSX.createElement ContextMenuShortcut [ prop.text value ]
    static member inline ContextMenuGroup ( props : IContextMenuGroupProp list ) = JSX.createElement ContextMenuGroup props
    static member inline ContextMenuGroup ( children : ReactElement list ) = JSX.createElementWithChildren ContextMenuGroup children
    static member inline ContextMenuGroup ( value : string ) = JSX.createElement ContextMenuGroup [ prop.text value ]
    static member inline ContextMenuGroup ( el : ReactElement ) = JSX.createElement ContextMenuGroup [ contextMenuGroup.asChild true ; props.children el ]
    static member inline ContextMenuPortal ( props : IContextMenuPortalProp list ) = JSX.createElement ContextMenuPortal props
    static member inline ContextMenuPortal ( children : ReactElement list ) = JSX.createElementWithChildren ContextMenuPortal children
    static member inline ContextMenuSub ( props : IContextMenuSubProp list ) = JSX.createElement ContextMenuSub props
    static member inline ContextMenuSub ( children : ReactElement list ) = JSX.createElementWithChildren ContextMenuSub children
    static member inline ContextMenuSubContent ( props : IContextMenuSubContentProp list ) = JSX.createElement ContextMenuSubContent props
    static member inline ContextMenuSubContent ( children : ReactElement list ) = JSX.createElementWithChildren ContextMenuSubContent children
    static member inline ContextMenuSubContent ( el : ReactElement ) = JSX.createElement ContextMenuSubContent [ contextMenuSubContent.asChild true ; props.children el ]
    static member inline ContextMenuSubTrigger ( props : IContextMenuSubTriggerProp list ) = JSX.createElement ContextMenuSubTrigger props
    static member inline ContextMenuSubTrigger ( children : ReactElement list ) = JSX.createElementWithChildren ContextMenuSubTrigger children
    static member inline ContextMenuSubTrigger ( value : string ) = JSX.createElement ContextMenuSubTrigger [ prop.text value ]
    static member inline ContextMenuSubTrigger ( el : ReactElement ) = JSX.createElement ContextMenuSubTrigger [ contextMenuSubTrigger.asChild true ; props.children el ]
    static member inline ContextMenuRadioGroup ( props : IContextMenuRadioGroupProp list ) = JSX.createElement ContextMenuRadioGroup props
    static member inline ContextMenuRadioGroup ( children : ReactElement list ) = JSX.createElementWithChildren ContextMenuRadioGroup children
    static member inline ContextMenuRadioGroup ( value : string , children : ReactElement list ) = JSX.createElement ContextMenuRadioGroup [ prop.value value ; prop.children children ]
    static member inline ContextMenuRadioGroup ( el : ReactElement ) = JSX.createElement ContextMenuRadioGroup [ contextMenuRadioGroup.asChild true ; props.children el ]