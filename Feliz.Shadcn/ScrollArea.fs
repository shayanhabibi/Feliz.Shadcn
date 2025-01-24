[<AutoOpen>]
module Feliz.Shadcn.ScrollArea

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
JSX.injectShadcnLib
ignore <| JSX.jsx """
import * as ScrollAreaPrimitive from "@radix-ui/react-scroll-area"
"""

open Feliz.RadixUI.Interface.NoInherit

// --------------- ScrollArea -------------- //
type [<Erase>] IScrollAreaProp = interface static member propsInterface : unit = () end
type [<Erase>] scrollArea = ScrollArea.root<IScrollAreaProp>

let ScrollArea : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, children, ...props }, ref) => (
  <ScrollAreaPrimitive.Root
    ref={ref}
    className={cn("relative overflow-hidden", className)}
    {...props}>
    <ScrollAreaPrimitive.Viewport className="h-full w-full rounded-[inherit]">
      {children}
    </ScrollAreaPrimitive.Viewport>
    <ScrollBar />
    <ScrollAreaPrimitive.Corner />
  </ScrollAreaPrimitive.Root>
))
ScrollArea.displayName = ScrollAreaPrimitive.Root.displayName
"""

// --------------- ScrollBar -------------- //
type [<Erase>] IScrollBarProp = interface static member propsInterface : unit = () end
type [<Erase>] scrollBar = ScrollArea.scrollbar<IScrollBarProp>

let ScrollBar : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, orientation = "vertical", ...props }, ref) => (
  <ScrollAreaPrimitive.ScrollAreaScrollbar
    ref={ref}
    orientation={orientation}
    className={cn(
      "flex touch-none select-none transition-colors",
      orientation === "vertical" &&
        "h-full w-2.5 border-l border-l-transparent p-[1px]",
      orientation === "horizontal" &&
        "h-2.5 flex-col border-t border-t-transparent p-[1px]",
      className
    )}
    {...props}>
    <ScrollAreaPrimitive.ScrollAreaThumb className="relative flex-1 rounded-full bg-border" />
  </ScrollAreaPrimitive.ScrollAreaScrollbar>
))
ScrollBar.displayName = ScrollAreaPrimitive.ScrollAreaScrollbar.displayName
"""

type [<Erase>] Shadcn =
    static member inline ScrollArea ( props : IScrollAreaProp list ) = JSX.createElement ScrollArea props
    static member inline ScrollArea ( children : ReactElement list ) = JSX.createElementWithChildren ScrollArea children
    static member inline ScrollArea ( el : ReactElement ) = JSX.createElement ScrollArea [ scrollArea.asChild true ; props.children el ]
    static member inline ScrollBar ( props : IScrollBarProp list ) = JSX.createElement ScrollBar props
    static member inline ScrollBar ( children : ReactElement list ) = JSX.createElementWithChildren ScrollBar children
    static member inline ScrollBar ( el : ReactElement ) = JSX.createElement ScrollBar [ scrollBar.asChild true ; props.children el ]
    