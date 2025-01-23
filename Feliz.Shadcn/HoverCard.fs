[<AutoOpen>]
module Feliz.Shadcn.HoverCard

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI.Interface.NoInherit
JSX.injectShadcnLib
ignore <| JSX.jsx """
import * as HoverCardPrimitive from "@radix-ui/react-hover-card"
"""

// --------------- HoverCard -------------- //
type [<Erase>] IHoverCardProp = interface static member propsInterface : unit = () end
type [<Erase>] hoverCard = HoverCard.root<IHoverCardProp>

let HoverCard : JSX.ElementType = JSX.jsx """
HoverCardPrimitive.Root
"""

// --------------- HoverCardTrigger -------------- //
type [<Erase>] IHoverCardTriggerProp = interface static member propsInterface : unit = () end
type [<Erase>] hoverCardTrigger = HoverCard.trigger<IHoverCardTriggerProp>

let HoverCardTrigger : JSX.ElementType = JSX.jsx """
HoverCardPrimitive.Trigger
"""

// --------------- HoverCardContent -------------- //
type [<Erase>] IHoverCardContentProp = interface static member propsInterface : unit = () end
type [<Erase>] hoverCardContent = HoverCard.content<IHoverCardContentProp>

let HoverCardContent : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, align = "center", sideOffset = 4, ...props }, ref) => (
  <HoverCardPrimitive.Content
    ref={ref}
    align={align}
    sideOffset={sideOffset}
    className={cn(
      "z-50 w-64 rounded-md border bg-popover p-4 text-popover-foreground shadow-md outline-none data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0 data-[state=closed]:zoom-out-95 data-[state=open]:zoom-in-95 data-[side=bottom]:slide-in-from-top-2 data-[side=left]:slide-in-from-right-2 data-[side=right]:slide-in-from-left-2 data-[side=top]:slide-in-from-bottom-2",
      className
    )}
    {...props} />
))
HoverCardContent.displayName = HoverCardPrimitive.Content.displayName
"""

type [<Erase>] Shadcn =
    static member inline HoverCard ( props : IHoverCardProp list ) = JSX.createElement HoverCard props
    static member inline HoverCard ( children : ReactElement list ) = JSX.createElementWithChildren HoverCard children
    static member inline HoverCardTrigger ( props : IHoverCardTriggerProp list ) = JSX.createElement HoverCardTrigger props
    static member inline HoverCardTrigger ( children : ReactElement list ) = JSX.createElementWithChildren HoverCardTrigger children
    static member inline HoverCardTrigger ( value : string ) = JSX.createElement HoverCardTrigger [ prop.text value ]
    static member inline HoverCardTrigger ( el : ReactElement ) = JSX.createElement HoverCardTrigger [ hoverCardTrigger.asChild true ; hoverCardTrigger.children el ]
    static member inline HoverCardContent ( props : IHoverCardContentProp list ) = JSX.createElement HoverCardContent props
    static member inline HoverCardContent ( children : ReactElement list ) = JSX.createElementWithChildren HoverCardContent children
    static member inline HoverCardContent ( value : string ) = JSX.createElement HoverCardContent [ prop.text value ]
    static member inline HoverCardContent ( el : ReactElement ) = JSX.createElement HoverCardContent [ hoverCardContent.asChild true ; hoverCardContent.children el ]
        