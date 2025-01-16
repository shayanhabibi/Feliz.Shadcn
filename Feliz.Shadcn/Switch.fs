[<AutoOpen>]
module Feliz.Shadcn.Switch

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
JSX.injectShadcnLib
ignore <| JSX.jsx """
import * as SwitchPrimitives from "@radix-ui/react-switch"
"""

open Feliz.RadixUI.Interface

// --------------- Switch -------------- //
type [<Erase>] ISwitchProp = interface end
type [<Erase>] switch =
    inherit Switch.root<ISwitchProp>
    static member inline private noop : unit = ()

let Switch : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <SwitchPrimitives.Root
    className={cn(
      "peer inline-flex h-5 w-9 shrink-0 cursor-pointer items-center rounded-full border-2 border-transparent shadow-sm transition-colors focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-ring focus-visible:ring-offset-2 focus-visible:ring-offset-background disabled:cursor-not-allowed disabled:opacity-50 data-[state=checked]:bg-primary data-[state=unchecked]:bg-input",
      className
    )}
    {...props}
    ref={ref}>
    <SwitchPrimitives.Thumb
      className={cn(
        "pointer-events-none block h-4 w-4 rounded-full bg-background shadow-lg ring-0 transition-transform data-[state=checked]:translate-x-4 data-[state=unchecked]:translate-x-0"
      )} />
  </SwitchPrimitives.Root>
))
Switch.displayName = SwitchPrimitives.Root.displayName
"""

type [<Erase>] Shadcn =
    static member inline Switch ( props : ISwitchProp list ) = JSX.createElement Switch props
    static member inline Switch ( children : ReactElement list ) = JSX.createElementWithChildren Switch children
    static member inline Switch ( el : ReactElement ) = JSX.createElement Switch [ switch.asChild true ; switch.children el ]
