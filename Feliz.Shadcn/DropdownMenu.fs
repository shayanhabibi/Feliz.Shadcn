[<AutoOpen>]
module Feliz.Shadcn.DropdownMenu

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI
JSX.injectLib
ignore <| JSX.jsx """
import * as DropdownMenuPrimitive from "@radix-ui/react-dropdown-menu";
import { Check, ChevronRight, Circle } from "lucide-react";
"""

// --------------- DropdownMenu -------------- //
type [<Erase>] IDropdownMenuProp = interface end
type [<Erase>] dropdownMenu =
    inherit DropdownMenu.root<IDropdownMenuProp>
    static member inline private noop : unit = ()

let DropdownMenu : JSX.ElementType = JSX.jsx """
DropdownMenuPrimitive.Root
"""

// --------------- DropdownMenuTrigger -------------- //
type [<Erase>] IDropdownMenuTriggerProp = interface end
type [<Erase>] dropdownMenuTrigger =
    inherit DropdownMenu.trigger<IDropdownMenuTriggerProp>
    static member inline private noop : unit = ()

let DropdownMenuTrigger : JSX.ElementType = JSX.jsx """
DropdownMenuPrimitive.Trigger
"""

// --------------- DropdownMenuGroup -------------- //
type [<Erase>] IDropdownMenuGroupProp = interface end
type [<Erase>] dropdownMenuGroup =
    inherit DropdownMenu.group<IDropdownMenuGroupProp>
    static member inline private noop : unit = ()

let DropdownMenuGroup : JSX.ElementType = JSX.jsx """
DropdownMenuPrimitive.Group
"""

// --------------- DropdownMenuPortal -------------- //
type [<Erase>] IDropdownMenuPortalProp = interface end
type [<Erase>] dropdownMenuPortal =
    inherit DropdownMenu.portal<IDropdownMenuPortalProp>
    static member inline private noop : unit = ()

let DropdownMenuPortal : JSX.ElementType = JSX.jsx """
DropdownMenuPrimitive.Portal
"""

// --------------- DropdownMenuSub -------------- //
type [<Erase>] IDropdownMenuSubProp = interface end
type [<Erase>] dropdownMenuSub =
    inherit DropdownMenu.sub<IDropdownMenuSubProp>
    static member inline private noop : unit = ()

let DropdownMenuSub : JSX.ElementType = JSX.jsx """
DropdownMenuPrimitive.Sub
"""

// --------------- DropdownMenuRadioGroup -------------- //
type [<Erase>] IDropdownMenuRadioGroupProp = interface end
type [<Erase>] dropdownMenuRadioGroup =
    inherit DropdownMenu.radioGroup<IDropdownMenuRadioGroupProp>
    static member inline private noop : unit = ()

let DropdownMenuRadioGroup : JSX.ElementType = JSX.jsx """
DropdownMenuPrimitive.RadioGroup
"""

// --------------- DropdownMenuSubTrigger -------------- //
type [<Erase>] IDropdownMenuSubTriggerProp = interface end
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
type [<Erase>] IDropdownMenuSubContentProp = interface end
type [<Erase>] dropdownMenuSubContent =
    inherit DropdownMenu.subContent<IDropdownMenuSubContentProp>
    static member inline private noop : unit = ()

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
type [<Erase>] IDropdownMenuContentProp = interface end
type [<Erase>] dropdownMenuContent =
    inherit DropdownMenu.content<IDropdownMenuContentProp>
    static member inline private noop : unit = ()

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
type [<Erase>] IDropdownMenuItemProp = interface end
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
type [<Erase>] IDropdownMenuCheckboxItemProp = interface end
type [<Erase>] dropdownMenuCheckboxItem =
    inherit DropdownMenu.checkboxItem<IDropdownMenuCheckboxItemProp>
    static member inline private noop : unit = ()

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
type [<Erase>] IDropdownMenuRadioItemProp = interface end
type [<Erase>] dropdownMenuRadioItem =
    inherit DropdownMenu.radioItem<IDropdownMenuRadioItemProp>
    static member inline private noop : unit = ()

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
type [<Erase>] IDropdownMenuLabelProp = interface end
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
type [<Erase>] IDropdownMenuSeparatorProp = interface end
type [<Erase>] dropdownMenuSeparator =
    inherit DropdownMenu.separator<IDropdownMenuSeparatorProp>
    static member inline private noop : unit = ()

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
type [<Erase>] IDropdownMenuShortcutProp = interface end
type [<Erase>] dropdownMenuShortcut =
    inherit prop<IDropdownMenuShortcutProp>
    static member inline private noop : unit = ()

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
    static member inline DropdownMenuContent ( props : IDropdownMenuContentProp list ) = JSX.createElement DropdownMenuContent props
    static member inline DropdownMenuContent ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuContent children
    static member inline DropdownMenuItem ( props : IDropdownMenuItemProp list ) = JSX.createElement DropdownMenuItem props
    static member inline DropdownMenuItem ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuItem children
    static member inline DropdownMenuItem ( value : string ) = JSX.createElement DropdownMenuItem [ prop.text value ]
    static member inline DropdownMenuCheckboxItem ( props : IDropdownMenuCheckboxItemProp list ) = JSX.createElement DropdownMenuCheckboxItem props
    static member inline DropdownMenuCheckboxItem ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuCheckboxItem children
    static member inline DropdownMenuCheckboxItem ( value : string ) = JSX.createElement DropdownMenuCheckboxItem [ prop.text value ]
    static member inline DropdownMenuRadioItem ( props : IDropdownMenuRadioItemProp list ) = JSX.createElement DropdownMenuRadioItem props
    static member inline DropdownMenuRadioItem ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuRadioItem children
    static member inline DropdownMenuRadioItem ( value : string ) = JSX.createElement DropdownMenuRadioItem [ prop.text value ; prop.value value ]
    static member inline DropdownMenuRadioItem ( value : string, label : string ) = JSX.createElement DropdownMenuRadioItem [ prop.text label ; prop.value value ]
    static member inline DropdownMenuLabel ( props : IDropdownMenuLabelProp list ) = JSX.createElement DropdownMenuLabel props
    static member inline DropdownMenuLabel ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuLabel children
    static member inline DropdownMenuLabel ( value : string ) = JSX.createElement DropdownMenuLabel [ prop.text value ]
    static member inline DropdownMenuSeparator ( props : IDropdownMenuSeparatorProp list ) = JSX.createElement DropdownMenuSeparator props
    static member inline DropdownMenuSeparator ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuSeparator children
    static member inline DropdownMenuSeparator () = JSX.createElement DropdownMenuSeparator []
    static member inline DropdownMenuShortcut ( props : IDropdownMenuShortcutProp list ) = JSX.createElement DropdownMenuShortcut props
    static member inline DropdownMenuShortcut ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuShortcut children
    static member inline DropdownMenuShortcut ( value : string ) = JSX.createElement DropdownMenuShortcut [ prop.text value ]
    static member inline DropdownMenuGroup ( props : IDropdownMenuGroupProp list ) = JSX.createElement DropdownMenuGroup props
    static member inline DropdownMenuGroup ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuGroup children
    static member inline DropdownMenuPortal ( props : IDropdownMenuPortalProp list ) = JSX.createElement DropdownMenuPortal props
    static member inline DropdownMenuPortal ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuPortal children
    static member inline DropdownMenuSub ( props : IDropdownMenuSubProp list ) = JSX.createElement DropdownMenuSub props
    static member inline DropdownMenuSub ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuSub children
    static member inline DropdownMenuSubContent ( props : IDropdownMenuSubContentProp list ) = JSX.createElement DropdownMenuSubContent props
    static member inline DropdownMenuSubContent ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuSubContent children
    static member inline DropdownMenuSubTrigger ( props : IDropdownMenuSubTriggerProp list ) = JSX.createElement DropdownMenuSubTrigger props
    static member inline DropdownMenuSubTrigger ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuSubTrigger children
    static member inline DropdownMenuSubTrigger ( value : string ) = JSX.createElement DropdownMenuSubTrigger [ prop.text value ]
    static member inline DropdownMenuRadioGroup ( props : IDropdownMenuRadioGroupProp list ) = JSX.createElement DropdownMenuRadioGroup props
    static member inline DropdownMenuRadioGroup ( children : ReactElement list ) = JSX.createElementWithChildren DropdownMenuRadioGroup children
    static member inline DropdownMenuRadioGroup ( value : string , children : ReactElement list ) = JSX.createElement DropdownMenuRadioGroup [ prop.value value ; prop.children children ]
                                                        