﻿[<AutoOpen>]
module Feliz.Shadcn.Tooltip

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI.Interface.NoInherit
JSX.injectShadcnLib
emitJsStatement () "import * as TooltipPrimitive from \"@radix-ui/react-tooltip\""

// --------------- TooltipProvider -------------- //
type [<Erase>] ITooltipProviderProp = interface static member propsInterface : unit = () end
type [<Erase>] tooltipProvider = Tooltip.provider<ITooltipProviderProp>

let TooltipProvider : JSX.ElementType = JSX.jsx """
TooltipPrimitive.Provider
"""

// --------------- Tooltip -------------- //
type [<Erase>] ITooltipProp = interface static member propsInterface : unit = () end
type [<Erase>] tooltip = Tooltip.root<ITooltipProp>

let Tooltip : JSX.ElementType = JSX.jsx """
TooltipPrimitive.Root
"""

// --------------- TooltipTrigger -------------- //
type [<Erase>] ITooltipTriggerProp = interface static member propsInterface : unit = () end
type [<Erase>] tooltipTrigger = Tooltip.trigger<ITooltipTriggerProp>

let TooltipTrigger : JSX.ElementType = JSX.jsx """
TooltipPrimitive.Trigger
"""

// --------------- TooltipContent -------------- //
type [<Erase>] ITooltipContentProp = interface static member propsInterface : unit = () end
type [<Erase>] tooltipContent = Tooltip.content<ITooltipContentProp>

let TooltipContent : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, sideOffset = 4, ...props }, ref) => (
  <TooltipPrimitive.Portal>
    <TooltipPrimitive.Content
      ref={ref}
      sideOffset={sideOffset}
      className={cn(
        "z-50 overflow-hidden rounded-md bg-primary px-3 py-1.5 text-xs text-primary-foreground animate-in fade-in-0 zoom-in-95 data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=closed]:zoom-out-95 data-[side=bottom]:slide-in-from-top-2 data-[side=left]:slide-in-from-right-2 data-[side=right]:slide-in-from-left-2 data-[side=top]:slide-in-from-bottom-2",
        className
      )}
      {...props} />
  </TooltipPrimitive.Portal>
))
TooltipContent.displayName = TooltipPrimitive.Content.displayName
"""

type [<Erase>] Shadcn =
    static member inline Tooltip ( props : ITooltipProp list ) = JSX.createElement Tooltip props
    static member inline Tooltip ( children : ReactElement list ) = JSX.createElementWithChildren Tooltip children
    static member inline TooltipTrigger ( props : ITooltipTriggerProp list ) = JSX.createElement TooltipTrigger props
    static member inline TooltipTrigger ( children : ReactElement list ) = JSX.createElementWithChildren TooltipTrigger children
    static member inline TooltipTrigger ( el : ReactElement ) = JSX.createElement TooltipTrigger [ tooltipTrigger.asChild true ; props.children el ]
    static member inline TooltipContent ( props : ITooltipContentProp list ) = JSX.createElement TooltipContent props
    static member inline TooltipContent ( children : ReactElement list ) = JSX.createElementWithChildren TooltipContent children
    static member inline TooltipContent ( el : ReactElement ) = JSX.createElement TooltipContent [ tooltipContent.asChild true ; props.children el ]
    static member inline TooltipProvider ( props : ITooltipProviderProp list ) = JSX.createElement TooltipProvider props
    static member inline TooltipProvider ( children : ReactElement list ) = JSX.createElementWithChildren TooltipProvider children
        