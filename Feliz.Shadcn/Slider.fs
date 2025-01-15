[<AutoOpen>]
module Feliz.Shadcn.Slider

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
JSX.injectShadcnLib
ignore <| JSX.jsx """
import * as SliderPrimitive from "@radix-ui/react-slider"
"""
open Feliz.RadixUI.Interface

// --------------- Slider -------------- //
type [<Erase>] ISliderProp = interface end
type [<Erase>] slider =
    inherit Slider.root<ISliderProp>
    static member inline private noop : unit = ()

let Slider : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <SliderPrimitive.Root
    ref={ref}
    className={cn("relative flex w-full touch-none select-none items-center", className)}
    {...props}>
    <SliderPrimitive.Track
      className="relative h-1.5 w-full grow overflow-hidden rounded-full bg-primary/20">
      <SliderPrimitive.Range className="absolute h-full bg-primary" />
    </SliderPrimitive.Track>
    <SliderPrimitive.Thumb
      className="block h-4 w-4 rounded-full border border-primary/50 bg-background shadow transition-colors focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:pointer-events-none disabled:opacity-50" />
  </SliderPrimitive.Root>
))
Slider.displayName = SliderPrimitive.Root.displayName
"""

type [<Erase>] Shadcn =
    static member inline Slider ( props : ISliderProp list ) = JSX.createElement Slider props
    static member inline Slider ( children : ReactElement list ) = JSX.createElementWithChildren Slider children
