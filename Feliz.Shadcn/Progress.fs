﻿[<AutoOpen>]
module Feliz.Shadcn.Progress

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz
JSX.injectLib
ignore <| JSX.jsx """
import * as ProgressPrimitive from "@radix-ui/react-progress"
"""

open Feliz.RadixUI

// --------------- Progress -------------- //
type [<Erase>] IProgressProp = interface end
type [<Erase>] progress =
    inherit Progress.root<IProgressProp>
    static member inline private noop : unit = ()

let Progress : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, value, ...props }, ref) => (
  <ProgressPrimitive.Root
    ref={ref}
    className={cn(
      "relative h-2 w-full overflow-hidden rounded-full bg-primary/20",
      className
    )}
    {...props}>
    <ProgressPrimitive.Indicator
      className="h-full w-full flex-1 bg-primary transition-all"
      style={{ transform: `translateX(-${100 - (value || 0)}%)` }} />
  </ProgressPrimitive.Root>
))
Progress.displayName = ProgressPrimitive.Root.displayName
"""

type [<Erase>] Shadcn =
    static member inline Progress ( props : IProgressProp list ) = JSX.createElement Progress props
    static member inline Progress ( children : ReactElement list ) = JSX.createElementWithChildren Progress children
    static member inline Progress ( value : int ) = JSX.createElement Progress [ prop.value value ]
