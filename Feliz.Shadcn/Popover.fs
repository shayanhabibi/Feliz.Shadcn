[<AutoOpen>]
module Feliz.Shadcn.Popover

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
JSX.injectShadcnLib
ignore <| JSX.jsx """
import * as PopoverPrimitive from "@radix-ui/react-popover"
"""

open Feliz.RadixUI.Interface

// --------------- Popover -------------- //
type [<Erase>] IPopoverProp = interface end
type [<Erase>] popover =
    inherit Popover.root<IPopoverProp>
    static member inline private noop : unit = ()

let Popover : JSX.ElementType = JSX.jsx """
PopoverPrimitive.Root
"""

// --------------- PopoverTrigger -------------- //
type [<Erase>] IPopoverTriggerProp = interface end
type [<Erase>] popoverTrigger =
    inherit Popover.trigger<IPopoverTriggerProp>
    static member inline private noop : unit = ()

let PopoverTrigger : JSX.ElementType = JSX.jsx """
PopoverPrimitive.Trigger
"""

// --------------- PopoverAnchor -------------- //
type [<Erase>] IPopoverAnchorProp = interface end
type [<Erase>] popoverAnchor =
    inherit Popover.anchor<IPopoverAnchorProp>
    static member inline private noop : unit = ()

let PopoverAnchor : JSX.ElementType = JSX.jsx """
PopoverPrimitive.Anchor
"""

// --------------- PopoverContent -------------- //
type [<Erase>] IPopoverContentProp = interface end
type [<Erase>] popoverContent =
    inherit Popover.content<IPopoverContentProp>
    static member inline private noop : unit = ()

let PopoverContent : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, align = "center", sideOffset = 4, ...props }, ref) => (
  <PopoverPrimitive.Portal>
    <PopoverPrimitive.Content
      ref={ref}
      align={align}
      sideOffset={sideOffset}
      className={cn(
        "z-50 w-72 rounded-md border bg-popover p-4 text-popover-foreground shadow-md outline-none data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0 data-[state=closed]:zoom-out-95 data-[state=open]:zoom-in-95 data-[side=bottom]:slide-in-from-top-2 data-[side=left]:slide-in-from-right-2 data-[side=right]:slide-in-from-left-2 data-[side=top]:slide-in-from-bottom-2",
        className
      )}
      {...props} />
  </PopoverPrimitive.Portal>
))
PopoverContent.displayName = PopoverPrimitive.Content.displayName
"""

type [<Erase>] Shadcn =
    static member inline Popover ( props : IPopoverProp list ) = JSX.createElement Popover props
    static member inline Popover ( children : ReactElement list ) = JSX.createElementWithChildren Popover children
    static member inline PopoverTrigger ( props : IPopoverTriggerProp list ) = JSX.createElement PopoverTrigger props
    static member inline PopoverTrigger ( children : ReactElement list ) = JSX.createElementWithChildren PopoverTrigger children
    static member inline PopoverTrigger ( value : string ) = JSX.createElement PopoverTrigger [ prop.text value ]
    static member inline PopoverTrigger ( el : ReactElement ) = JSX.createElement PopoverTrigger [ popoverTrigger.asChild true ; popoverTrigger.children el ]
    static member inline PopoverContent ( props : IPopoverContentProp list ) = JSX.createElement PopoverContent props
    static member inline PopoverContent ( children : ReactElement list ) = JSX.createElementWithChildren PopoverContent children
    static member inline PopoverContent ( el : ReactElement ) = JSX.createElement PopoverContent [ popoverContent.asChild true ; popoverContent.children el ]
    static member inline PopoverAnchor ( props : IPopoverAnchorProp list ) = JSX.createElement PopoverAnchor props
    static member inline PopoverAnchor ( children : ReactElement list ) = JSX.createElementWithChildren PopoverAnchor children
    static member inline PopoverAnchor ( el : ReactElement ) = JSX.createElement PopoverAnchor [ popoverAnchor.asChild true ; popoverAnchor.children el ]
            