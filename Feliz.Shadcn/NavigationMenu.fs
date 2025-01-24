[<AutoOpen>]
module Feliz.Shadcn.NavigationMenu

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
JSX.injectShadcnLib
ignore <| JSX.jsx """
import * as NavigationMenuPrimitive from "@radix-ui/react-navigation-menu"
import { cva } from "class-variance-authority"
import { ChevronDown } from "lucide-react"
"""

let navigationMenuTriggerStyle = JSX.jsx """
cva(
  "group inline-flex h-9 w-max items-center justify-center rounded-md bg-background px-4 py-2 text-sm font-medium transition-colors hover:bg-accent hover:text-accent-foreground focus:bg-accent focus:text-accent-foreground focus:outline-none disabled:pointer-events-none disabled:opacity-50 data-[active]:bg-accent/50 data-[state=open]:bg-accent/50"
)
"""

open Feliz.RadixUI.Interface.NoInherit

// --------------- NavigationMenu -------------- //
type [<Erase>] INavigationMenuProp = interface static member propsInterface : unit = () end
type [<Erase>] navigationMenu = NavigationMenu.root<INavigationMenuProp>

let NavigationMenu : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, children, ...props }, ref) => (
  <NavigationMenuPrimitive.Root
    ref={ref}
    className={cn(
      "relative z-10 flex max-w-max flex-1 items-center justify-center",
      className
    )}
    {...props}>
    {children}
    <NavigationMenuViewport />
  </NavigationMenuPrimitive.Root>
))
NavigationMenu.displayName = NavigationMenuPrimitive.Root.displayName
"""

// --------------- NavigationMenuList -------------- //
type [<Erase>] INavigationMenuListProp = interface static member propsInterface : unit = () end
type [<Erase>] navigationMenuList = NavigationMenu.list'<INavigationMenuListProp>

let NavigationMenuList : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <NavigationMenuPrimitive.List
    ref={ref}
    className={cn(
      "group flex flex-1 list-none items-center justify-center space-x-1",
      className
    )}
    {...props} />
))
NavigationMenuList.displayName = NavigationMenuPrimitive.List.displayName

const NavigationMenuItem = NavigationMenuPrimitive.Item
"""

// --------------- NavigationMenuItem -------------- //
type [<Erase>] INavigationMenuItemProp = interface static member propsInterface : unit = () end
type [<Erase>] navigationMenuItem = NavigationMenu.item<INavigationMenuItemProp>

let NavigationMenuItem : JSX.ElementType = JSX.jsx """
NavigationMenuPrimitive.Item
"""

// --------------- NavigationMenuTrigger -------------- //
type [<Erase>] INavigationMenuTriggerProp = interface static member propsInterface : unit = () end
type [<Erase>] navigationMenuTrigger = NavigationMenu.trigger<INavigationMenuTriggerProp>

let NavigationMenuTrigger : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, children, ...props }, ref) => (
  <NavigationMenuPrimitive.Trigger
    ref={ref}
    className={cn(navigationMenuTriggerStyle(), "group", className)}
    {...props}>
    {children}{" "}
    <ChevronDown
      className="relative top-[1px] ml-1 h-3 w-3 transition duration-300 group-data-[state=open]:rotate-180"
      aria-hidden="true" />
  </NavigationMenuPrimitive.Trigger>
))
NavigationMenuTrigger.displayName = NavigationMenuPrimitive.Trigger.displayName
"""

// --------------- NavigationMenuContent -------------- //
type [<Erase>] INavigationMenuContentProp = interface static member propsInterface : unit = () end
type [<Erase>] navigationMenuContent = NavigationMenu.content<INavigationMenuContentProp>

let NavigationMenuContent : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <NavigationMenuPrimitive.Content
    ref={ref}
    className={cn(
      "left-0 top-0 w-full data-[motion^=from-]:animate-in data-[motion^=to-]:animate-out data-[motion^=from-]:fade-in data-[motion^=to-]:fade-out data-[motion=from-end]:slide-in-from-right-52 data-[motion=from-start]:slide-in-from-left-52 data-[motion=to-end]:slide-out-to-right-52 data-[motion=to-start]:slide-out-to-left-52 md:absolute md:w-auto ",
      className
    )}
    {...props} />
))
NavigationMenuContent.displayName = NavigationMenuPrimitive.Content.displayName
"""

// --------------- NavigationMenuLink -------------- //
type [<Erase>] INavigationMenuLinkProp = interface static member propsInterface : unit = () end
type [<Erase>] navigationMenuLink = NavigationMenu.link<INavigationMenuLinkProp>

let NavigationMenuLink : JSX.ElementType = JSX.jsx """
NavigationMenuPrimitive.Link
"""

// --------------- NavigationMenuViewport -------------- //
type [<Erase>] INavigationMenuViewportProp = interface static member propsInterface : unit = () end
type [<Erase>] navigationMenuViewport = NavigationMenu.viewport<INavigationMenuViewportProp>

let NavigationMenuViewport : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <div className={cn("absolute left-0 top-full flex justify-center")}>
    <NavigationMenuPrimitive.Viewport
      className={cn(
        "origin-top-center relative mt-1.5 h-[var(--radix-navigation-menu-viewport-height)] w-full overflow-hidden rounded-md border bg-popover text-popover-foreground shadow data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:zoom-out-95 data-[state=open]:zoom-in-90 md:w-[var(--radix-navigation-menu-viewport-width)]",
        className
      )}
      ref={ref}
      {...props} />
  </div>
))
NavigationMenuViewport.displayName =
  NavigationMenuPrimitive.Viewport.displayName
"""

// --------------- NavigationMenuIndicator -------------- //
type [<Erase>] INavigationMenuIndicatorProp = interface static member propsInterface : unit = () end
type [<Erase>] navigationMenuIndicator = NavigationMenu.indicator<INavigationMenuIndicatorProp>

let NavigationMenuIndicator : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <NavigationMenuPrimitive.Indicator
    ref={ref}
    className={cn(
      "top-full z-[1] flex h-1.5 items-end justify-center overflow-hidden data-[state=visible]:animate-in data-[state=hidden]:animate-out data-[state=hidden]:fade-out data-[state=visible]:fade-in",
      className
    )}
    {...props}>
    <div
      className="relative top-[60%] h-2 w-2 rotate-45 rounded-tl-sm bg-border shadow-md" />
  </NavigationMenuPrimitive.Indicator>
))
NavigationMenuIndicator.displayName =
  NavigationMenuPrimitive.Indicator.displayName
"""

type [<Erase>] Shadcn =
    static member inline NavigationMenu ( props : INavigationMenuProp list ) = JSX.createElement NavigationMenu props
    static member inline NavigationMenu ( children : ReactElement list ) = JSX.createElementWithChildren NavigationMenu children
    static member inline NavigationMenuList ( props : INavigationMenuListProp list ) = JSX.createElement NavigationMenuList props
    static member inline NavigationMenuList ( children : ReactElement list ) = JSX.createElementWithChildren NavigationMenuList children
    static member inline NavigationMenuList ( el : ReactElement ) = JSX.createElement NavigationMenuList [ navigationMenuList.asChild true ; props.children el ]
    static member inline NavigationMenuItem ( props : INavigationMenuItemProp list ) = JSX.createElement NavigationMenuItem props
    static member inline NavigationMenuItem ( children : ReactElement list ) = JSX.createElementWithChildren NavigationMenuItem children
    static member inline NavigationMenuItem ( value : string ) = JSX.createElement NavigationMenuItem [ prop.text value ]
    static member inline NavigationMenuItem ( el : ReactElement ) = JSX.createElement NavigationMenuItem [ navigationMenuItem.asChild true ; props.children el ]
    static member inline NavigationMenuContent ( props : INavigationMenuContentProp list ) = JSX.createElement NavigationMenuContent props
    static member inline NavigationMenuContent ( children : ReactElement list ) = JSX.createElementWithChildren NavigationMenuContent children
    static member inline NavigationMenuContent ( el : ReactElement ) = JSX.createElement NavigationMenuContent [ navigationMenuContent.asChild true ; props.children el ]
    static member inline NavigationMenuTrigger ( props : INavigationMenuTriggerProp list ) = JSX.createElement NavigationMenuTrigger props
    static member inline NavigationMenuTrigger ( children : ReactElement list ) = JSX.createElementWithChildren NavigationMenuTrigger children
    static member inline NavigationMenuTrigger ( value : string ) = JSX.createElement NavigationMenuTrigger [ prop.text value ]
    static member inline NavigationMenuTrigger ( el : ReactElement ) = JSX.createElement NavigationMenuTrigger [ navigationMenuTrigger.asChild true ; props.children el ]
    static member inline NavigationMenuLink ( props : INavigationMenuLinkProp list ) = JSX.createElement NavigationMenuLink props
    static member inline NavigationMenuLink ( children : ReactElement list ) = JSX.createElementWithChildren NavigationMenuLink children
    static member inline NavigationMenuLink ( el : ReactElement ) = JSX.createElement NavigationMenuLink [ navigationMenuLink.asChild true ; props.children el ]
    static member inline NavigationMenuIndicator ( props : INavigationMenuIndicatorProp list ) = JSX.createElement NavigationMenuIndicator props
    static member inline NavigationMenuIndicator ( children : ReactElement list ) = JSX.createElementWithChildren NavigationMenuIndicator children
    static member inline NavigationMenuIndicator ( el : ReactElement ) = JSX.createElement NavigationMenuIndicator [ navigationMenuIndicator.asChild true ; props.children el ]
    static member inline NavigationMenuViewport ( props : INavigationMenuViewportProp list ) = JSX.createElement NavigationMenuViewport props
    static member inline NavigationMenuViewport ( children : ReactElement list ) = JSX.createElementWithChildren NavigationMenuViewport children
    static member inline NavigationMenuViewport ( el : ReactElement ) = JSX.createElement NavigationMenuViewport [ navigationMenuViewport.asChild true ; props.children el ]
                    