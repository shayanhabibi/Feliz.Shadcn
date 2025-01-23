[<AutoOpen>]
module Feliz.Shadcn.Menubar

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
JSX.injectShadcnLib
ignore <| JSX.jsx """
import * as MenubarPrimitive from "@radix-ui/react-menubar"
import { Check, ChevronRight, Circle } from "lucide-react"
"""

open Feliz.RadixUI.Interface.NoInherit

// --------------- MenubarMenu -------------- //
type [<Erase>] IMenubarMenuProp = interface static member propsInterface : unit = () end
type [<Erase>] menubarMenu = MenuBar.menu<IMenubarMenuProp>

let MenubarMenu : JSX.ElementType = JSX.jsx """
MenubarPrimitive.Menu
"""

// --------------- MenubarGroup -------------- //
type [<Erase>] IMenubarGroupProp = interface static member propsInterface : unit = () end
type [<Erase>] menubarGroup = MenuBar.group<IMenubarGroupProp>

let MenubarGroup : JSX.ElementType = JSX.jsx """
MenubarPrimitive.Group
"""

// --------------- MenubarPortal -------------- //
type [<Erase>] IMenubarPortalProp = interface static member propsInterface : unit = () end
type [<Erase>] menubarPortal = MenuBar.portal<IMenubarPortalProp>

let MenubarPortal : JSX.ElementType = JSX.jsx """
MenubarPrimitive.Portal
"""

// --------------- MenubarSub -------------- //
type [<Erase>] IMenubarSubProp = interface static member propsInterface : unit = () end
type [<Erase>] menubarSub = MenuBar.sub<IMenubarSubProp>

let MenubarSub : JSX.ElementType = JSX.jsx """
MenubarPrimitive.Sub
"""

// --------------- MenubarRadioGroup -------------- //
type [<Erase>] IMenubarRadioGroupProp = interface static member propsInterface : unit = () end
type [<Erase>] menubarRadioGroup = MenuBar.radioGroup<IMenubarRadioGroupProp>

let MenubarRadioGroup : JSX.ElementType = JSX.jsx """
MenubarPrimitive.RadioGroup
"""

// --------------- Menubar -------------- //
type [<Erase>] IMenubarProp = interface static member propsInterface : unit = () end
type [<Erase>] menubar = MenuBar.root<IMenubarProp>

let Menubar : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <MenubarPrimitive.Root
    ref={ref}
    className={cn(
      "flex h-9 items-center space-x-1 rounded-md border bg-background p-1 shadow-sm",
      className
    )}
    {...props} />
))
Menubar.displayName = MenubarPrimitive.Root.displayName
"""

// --------------- MenubarTrigger -------------- //
type [<Erase>] IMenubarTriggerProp = interface static member propsInterface : unit = () end
type [<Erase>] menubarTrigger = MenuBar.trigger<IMenubarTriggerProp>

let MenubarTrigger : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <MenubarPrimitive.Trigger
    ref={ref}
    className={cn(
      "flex cursor-default select-none items-center rounded-sm px-3 py-1 text-sm font-medium outline-none focus:bg-accent focus:text-accent-foreground data-[state=open]:bg-accent data-[state=open]:text-accent-foreground",
      className
    )}
    {...props} />
))
MenubarTrigger.displayName = MenubarPrimitive.Trigger.displayName
"""

// --------------- MenubarSubTrigger -------------- //
type [<Erase>] IMenubarSubTriggerProp = interface static member propsInterface : unit = () end
type [<Erase>] menubarSubTrigger =
    inherit MenuBar.subTrigger<IMenubarSubTriggerProp>
    static member inline inset ( value : bool ) : IMenubarSubTriggerProp = Interop.mkProperty "inset" value

let MenubarSubTrigger : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, inset, children, ...props }, ref) => (
  <MenubarPrimitive.SubTrigger
    ref={ref}
    className={cn(
      "flex cursor-default select-none items-center rounded-sm px-2 py-1.5 text-sm outline-none focus:bg-accent focus:text-accent-foreground data-[state=open]:bg-accent data-[state=open]:text-accent-foreground",
      inset && "pl-8",
      className
    )}
    {...props}>
    {children}
    <ChevronRight className="ml-auto h-4 w-4" />
  </MenubarPrimitive.SubTrigger>
))
MenubarSubTrigger.displayName = MenubarPrimitive.SubTrigger.displayName
"""

// --------------- MenubarSubContent -------------- //
type [<Erase>] IMenubarSubContentProp = interface static member propsInterface : unit = () end
type [<Erase>] menubarSubContent = MenuBar.subContent<IMenubarSubContentProp>

let MenubarSubContent : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <MenubarPrimitive.SubContent
    ref={ref}
    className={cn(
      "z-50 min-w-[8rem] overflow-hidden rounded-md border bg-popover p-1 text-popover-foreground shadow-lg data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0 data-[state=closed]:zoom-out-95 data-[state=open]:zoom-in-95 data-[side=bottom]:slide-in-from-top-2 data-[side=left]:slide-in-from-right-2 data-[side=right]:slide-in-from-left-2 data-[side=top]:slide-in-from-bottom-2",
      className
    )}
    {...props} />
))
MenubarSubContent.displayName = MenubarPrimitive.SubContent.displayName
"""

// --------------- MenubarContent -------------- //
type [<Erase>] IMenubarContentProp = interface static member propsInterface : unit = () end
type [<Erase>] menubarContent = MenuBar.content<IMenubarContentProp>

let MenubarContent : JSX.ElementType = JSX.jsx """
React.forwardRef((
  { className, align = "start", alignOffset = -4, sideOffset = 8, ...props },
  ref
) => (
  <MenubarPrimitive.Portal>
    <MenubarPrimitive.Content
      ref={ref}
      align={align}
      alignOffset={alignOffset}
      sideOffset={sideOffset}
      className={cn(
        "z-50 min-w-[12rem] overflow-hidden rounded-md border bg-popover p-1 text-popover-foreground shadow-md data-[state=open]:animate-in data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0 data-[state=closed]:zoom-out-95 data-[state=open]:zoom-in-95 data-[side=bottom]:slide-in-from-top-2 data-[side=left]:slide-in-from-right-2 data-[side=right]:slide-in-from-left-2 data-[side=top]:slide-in-from-bottom-2",
        className
      )}
      {...props} />
  </MenubarPrimitive.Portal>
))
MenubarContent.displayName = MenubarPrimitive.Content.displayName
"""

// --------------- MenubarItem -------------- //
type [<Erase>] IMenubarItemProp = interface static member propsInterface : unit = () end
type [<Erase>] menubarItem =
    inherit MenuBar.item<IMenubarItemProp>
    static member inline inset ( value : bool ) : IMenubarItemProp = Interop.mkProperty "inset" value

let MenubarItem : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, inset, ...props }, ref) => (
  <MenubarPrimitive.Item
    ref={ref}
    className={cn(
      "relative flex cursor-default select-none items-center rounded-sm px-2 py-1.5 text-sm outline-none focus:bg-accent focus:text-accent-foreground data-[disabled]:pointer-events-none data-[disabled]:opacity-50",
      inset && "pl-8",
      className
    )}
    {...props} />
))
MenubarItem.displayName = MenubarPrimitive.Item.displayName
"""

// --------------- MenubarCheckboxItem -------------- //
type [<Erase>] IMenubarCheckboxItemProp = interface static member propsInterface : unit = () end
type [<Erase>] menubarCheckboxItem = MenuBar.checkboxItem<IMenubarCheckboxItemProp>

let MenubarCheckboxItem : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, children, checked, ...props }, ref) => (
  <MenubarPrimitive.CheckboxItem
    ref={ref}
    className={cn(
      "relative flex cursor-default select-none items-center rounded-sm py-1.5 pl-8 pr-2 text-sm outline-none focus:bg-accent focus:text-accent-foreground data-[disabled]:pointer-events-none data-[disabled]:opacity-50",
      className
    )}
    checked={checked}
    {...props}>
    <span className="absolute left-2 flex h-3.5 w-3.5 items-center justify-center">
      <MenubarPrimitive.ItemIndicator>
        <Check className="h-4 w-4" />
      </MenubarPrimitive.ItemIndicator>
    </span>
    {children}
  </MenubarPrimitive.CheckboxItem>
))
MenubarCheckboxItem.displayName = MenubarPrimitive.CheckboxItem.displayName
"""

// --------------- MenubarRadioItem -------------- //
type [<Erase>] IMenubarRadioItemProp = interface static member propsInterface : unit = () end
type [<Erase>] menubarRadioItem = MenuBar.radioItem<IMenubarRadioItemProp>

let MenubarRadioItem : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, children, ...props }, ref) => (
  <MenubarPrimitive.RadioItem
    ref={ref}
    className={cn(
      "relative flex cursor-default select-none items-center rounded-sm py-1.5 pl-8 pr-2 text-sm outline-none focus:bg-accent focus:text-accent-foreground data-[disabled]:pointer-events-none data-[disabled]:opacity-50",
      className
    )}
    {...props}>
    <span className="absolute left-2 flex h-3.5 w-3.5 items-center justify-center">
      <MenubarPrimitive.ItemIndicator>
        <Circle className="h-4 w-4 fill-current" />
      </MenubarPrimitive.ItemIndicator>
    </span>
    {children}
  </MenubarPrimitive.RadioItem>
))
MenubarRadioItem.displayName = MenubarPrimitive.RadioItem.displayName
"""

// --------------- MenubarLabel -------------- //
type [<Erase>] IMenubarLabelProp = interface static member propsInterface : unit = () end
type [<Erase>] menubarLabel =
    inherit MenuBar.label<IMenubarLabelProp>
    static member inline inset ( value : bool ) : IMenubarLabelProp = Interop.mkProperty "inset" value

let MenubarLabel : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, inset, ...props }, ref) => (
  <MenubarPrimitive.Label
    ref={ref}
    className={cn("px-2 py-1.5 text-sm font-semibold", inset && "pl-8", className)}
    {...props} />
))
MenubarLabel.displayName = MenubarPrimitive.Label.displayName
"""

// --------------- MenubarSeparator -------------- //
type [<Erase>] IMenubarSeparatorProp = interface static member propsInterface : unit = () end
type [<Erase>] menubarSeparator = MenuBar.separator<IMenubarSeparatorProp>

let MenubarSeparator : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <MenubarPrimitive.Separator
    ref={ref}
    className={cn("-mx-1 my-1 h-px bg-muted", className)}
    {...props} />
))
MenubarSeparator.displayName = MenubarPrimitive.Separator.displayName
"""

// --------------- MenubarShortcut -------------- //
type [<Erase>] IMenubarShortcutProp = interface static member propsInterface : unit = () end

let MenubarShortcut : JSX.ElementType = JSX.jsx """
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
MenubarShortcut.displayname = "MenubarShortcut"
"""

type [<Erase>] Shadcn =
    static member inline Menubar ( props : IMenubarProp list ) = JSX.createElement Menubar props
    static member inline Menubar ( children : ReactElement list ) = JSX.createElementWithChildren Menubar children
    static member inline Menubar ( el : ReactElement ) = JSX.createElement Menubar [ menubar.asChild true ; menubar.children el ]
    static member inline MenubarMenu ( props : IMenubarMenuProp list ) = JSX.createElement MenubarMenu props
    static member inline MenubarMenu ( children : ReactElement list ) = JSX.createElementWithChildren MenubarMenu children
    static member inline MenubarMenu ( el : ReactElement ) = JSX.createElement MenubarMenu [ menubarMenu.asChild true ; menubarMenu.children el ]
    static member inline MenubarTrigger ( props : IMenubarTriggerProp list ) = JSX.createElement MenubarTrigger props
    static member inline MenubarTrigger ( children : ReactElement list ) = JSX.createElementWithChildren MenubarTrigger children
    static member inline MenubarTrigger ( value : string ) = JSX.createElement MenubarTrigger [ prop.text value ]
    static member inline MenubarTrigger ( el : ReactElement ) = JSX.createElement MenubarTrigger [ menubarTrigger.asChild true ; menubarTrigger.children el ]
    static member inline MenubarContent ( props : IMenubarContentProp list ) = JSX.createElement MenubarContent props
    static member inline MenubarContent ( children : ReactElement list ) = JSX.createElementWithChildren MenubarContent children
    static member inline MenubarContent ( el : ReactElement ) = JSX.createElement MenubarContent [ menubarContent.asChild true ; menubarContent.children el ]
    static member inline MenubarItem ( props : IMenubarItemProp list ) = JSX.createElement MenubarItem props
    static member inline MenubarItem ( children : ReactElement list ) = JSX.createElementWithChildren MenubarItem children
    static member inline MenubarItem ( value : string ) = JSX.createElement MenubarItem [ prop.text value ]
    static member inline MenubarItem ( el : ReactElement ) = JSX.createElement MenubarItem [ menubarItem.asChild true ; menubarItem.children el ]
    static member inline MenubarSeparator ( props : IMenubarSeparatorProp list ) = JSX.createElement MenubarSeparator props
    static member inline MenubarSeparator ( children : ReactElement list ) = JSX.createElementWithChildren MenubarSeparator children
    static member inline MenubarSeparator () = JSX.createElement MenubarSeparator []
    static member inline MenubarLabel ( props : IMenubarLabelProp list ) = JSX.createElement MenubarLabel props
    static member inline MenubarLabel ( children : ReactElement list ) = JSX.createElementWithChildren MenubarLabel children
    static member inline MenubarLabel ( value : string ) = JSX.createElement MenubarLabel [ prop.text value ]
    static member inline MenubarLabel ( el : ReactElement ) = JSX.createElement MenubarLabel [ menubarLabel.asChild true ; menubarLabel.children el ]
    static member inline MenubarCheckboxItem ( props : IMenubarCheckboxItemProp list ) = JSX.createElement MenubarCheckboxItem props
    static member inline MenubarCheckboxItem ( children : ReactElement list ) = JSX.createElementWithChildren MenubarCheckboxItem children
    static member inline MenubarCheckboxItem ( value : string ) = JSX.createElement MenubarCheckboxItem [ prop.text value ]
    static member inline MenubarCheckboxItem ( el : ReactElement ) = JSX.createElement MenubarCheckboxItem [ menubarCheckboxItem.asChild true ; menubarCheckboxItem.children el ]
    static member inline MenubarRadioGroup ( props : IMenubarRadioGroupProp list ) = JSX.createElement MenubarRadioGroup props
    static member inline MenubarRadioGroup ( children : ReactElement list ) = JSX.createElementWithChildren MenubarRadioGroup children
    static member inline MenubarRadioGroup ( el : ReactElement ) = JSX.createElement MenubarRadioGroup [ menubarRadioGroup.asChild true ; menubarRadioGroup.children el ]
    static member inline MenubarRadioGroup ( value : string, children : ReactElement list ) = JSX.createElement MenubarRadioGroup [ prop.value value ; prop.children children]
    static member inline MenubarRadioItem ( props : IMenubarRadioItemProp list ) = JSX.createElement MenubarRadioItem props
    static member inline MenubarRadioItem ( el : ReactElement ) = JSX.createElement MenubarRadioItem [ menubarRadioItem.asChild true ; menubarRadioItem.children el ]
    static member inline MenubarRadioItem ( children : ReactElement list ) = JSX.createElementWithChildren MenubarRadioItem children
    static member inline MenubarRadioItem ( value : string ) = JSX.createElement MenubarRadioItem [ prop.text value ; prop.value value ]
    static member inline MenubarRadioItem ( value : string, text : string ) = JSX.createElement MenubarRadioItem [ prop.text text ; prop.value value]
    static member inline MenubarPortal ( props : IMenubarPortalProp list ) = JSX.createElement MenubarPortal props
    static member inline MenubarPortal ( children : ReactElement list ) = JSX.createElementWithChildren MenubarPortal children
    static member inline MenubarSubContent ( props : IMenubarSubContentProp list ) = JSX.createElement MenubarSubContent props
    static member inline MenubarSubContent ( children : ReactElement list ) = JSX.createElementWithChildren MenubarSubContent children
    static member inline MenubarSubContent ( el : ReactElement ) = JSX.createElement MenubarSubContent [ menubarSubContent.asChild true ; menubarSubContent.children el ]
    static member inline MenubarSubTrigger ( props : IMenubarSubTriggerProp list ) = JSX.createElement MenubarSubTrigger props
    static member inline MenubarSubTrigger ( children : ReactElement list ) = JSX.createElementWithChildren MenubarSubTrigger children
    static member inline MenubarSubTrigger ( value : string ) = JSX.createElement MenubarSubTrigger [ prop.text value ]
    static member inline MenubarSubTrigger ( el : ReactElement ) = JSX.createElement MenubarSubTrigger [ menubarSubTrigger.asChild true ; menubarSubTrigger.children el ]
    static member inline MenubarGroup ( props : IMenubarGroupProp list ) = JSX.createElement MenubarGroup props
    static member inline MenubarGroup ( children : ReactElement list ) = JSX.createElementWithChildren MenubarGroup children
    static member inline MenubarGroup ( el : ReactElement ) = JSX.createElement MenubarGroup [ menubarGroup.asChild true ; menubarGroup.children el ]
    static member inline MenubarSub ( props : IMenubarSubProp list ) = JSX.createElement MenubarSub props
    static member inline MenubarSub ( children : ReactElement list ) = JSX.createElementWithChildren MenubarSub children
    static member inline MenubarShortcut ( props : IMenubarShortcutProp list ) = JSX.createElement MenubarShortcut props
    static member inline MenubarShortcut ( children : ReactElement list ) = JSX.createElementWithChildren MenubarShortcut children
    static member inline MenubarShortcut ( value : string ) = JSX.createElement MenubarShortcut [ prop.text value ]
                                                            