[<AutoOpen>]
module Feliz.Shadcn.Resizeable

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
JSX.injectShadcnLib
ignore <| JSX.jsx """
import { GripVertical } from "lucide-react"
import * as ResizablePrimitive from "react-resizable-panels"
"""

// --------------- ResizeablePanelGroup -------------- //
type [<Erase>] IResizeablePanelGroupProp = interface static member propsInterface : unit = () end

let ResizeablePanelGroup : JSX.ElementType = JSX.jsx """
({
  className,
  ...props
}) => (
  <ResizablePrimitive.PanelGroup
    className={cn(
      "flex h-full w-full data-[panel-group-direction=vertical]:flex-col",
      className
    )}
    {...props} />
)
"""

// --------------- ResizeablePanel -------------- //
type [<Erase>] IResizeablePanelProp = interface static member propsInterface : unit = () end

let ResizeablePanel : JSX.ElementType = JSX.jsx """
ResizablePrimitive.Panel
"""

// --------------- ResizeableHandle -------------- //
type [<Erase>] IResizeableHandleProp = interface static member propsInterface : unit = () end
type [<Erase>] resizeableHandle =
    static member inline withHandle ( value : bool ) : IResizeableHandleProp = Interop.mkProperty "withHandle" value

let ResizeableHandle : JSX.ElementType = JSX.jsx """
({
  withHandle,
  className,
  ...props
}) => (
  <ResizablePrimitive.PanelResizeHandle
    className={cn(
      "relative flex w-px items-center justify-center bg-border after:absolute after:inset-y-0 after:left-1/2 after:w-1 after:-translate-x-1/2 focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring focus-visible:ring-offset-1 data-[panel-group-direction=vertical]:h-px data-[panel-group-direction=vertical]:w-full data-[panel-group-direction=vertical]:after:left-0 data-[panel-group-direction=vertical]:after:h-1 data-[panel-group-direction=vertical]:after:w-full data-[panel-group-direction=vertical]:after:-translate-y-1/2 data-[panel-group-direction=vertical]:after:translate-x-0 [&[data-panel-group-direction=vertical]>div]:rotate-90",
      className
    )}
    {...props}>
    {withHandle && (
      <div
        className="z-10 flex h-4 w-3 items-center justify-center rounded-sm border bg-border">
        <GripVertical className="h-2.5 w-2.5" />
      </div>
    )}
  </ResizablePrimitive.PanelResizeHandle>
)
"""

type [<Erase>] Shadcn =
    static member inline ResizeablePanelGroup ( props : IResizeablePanelGroupProp list ) = JSX.createElement ResizeablePanelGroup props
    static member inline ResizeablePanelGroup ( children : ReactElement list ) = JSX.createElementWithChildren ResizeablePanelGroup children
    static member inline ResizeablePanel ( props : IResizeablePanelProp list ) = JSX.createElement ResizeablePanel props
    static member inline ResizeablePanel ( children : ReactElement list ) = JSX.createElementWithChildren ResizeablePanel children
    static member inline ResizeableHandle ( props : IResizeableHandleProp list ) = JSX.createElement ResizeableHandle props
    static member inline ResizeableHandle ( children : ReactElement list ) = JSX.createElementWithChildren ResizeableHandle children
    static member inline ResizeableHandle () = JSX.createElement ResizeableHandle []