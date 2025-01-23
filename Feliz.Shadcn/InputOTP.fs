[<AutoOpen>]
module Feliz.Shadcn.InputOTP

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
JSX.injectShadcnLib
ignore <| JSX.jsx """
import { OTPInput, OTPInputContext } from "input-otp";
import { Minus } from "lucide-react";
"""

// --------------- InputOTP -------------- //
type [<Erase>] IInputOTPProp = interface static member propsInterface : unit = () end
type [<Erase>] inputOtp =
    static member inline private containerClassName ( value : string ) : IInputOTPProp = Interop.mkProperty "containerClassName" value

let InputOTP : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, containerClassName, ...props }, ref) => (
  <OTPInput
    ref={ref}
    containerClassName={cn("flex items-center gap-2 has-[:disabled]:opacity-50", containerClassName)}
    className={cn("disabled:cursor-not-allowed", className)}
    {...props} />
))
InputOTP.displayName = "InputOTP"
"""

// --------------- InputOTPGroup -------------- //
type [<Erase>] IInputOTPGroupProp = interface static member propsInterface : unit = () end

let InputOTPGroup : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <div ref={ref} className={cn("flex items-center", className)} {...props} />
))
InputOTPGroup.displayName = "InputOTPGroup"
"""

// --------------- InputOTPSlot -------------- //
type [<Erase>] IInputOTPSlotProp = interface end
type [<Erase>] inputOtpSlot =
    static member inline index ( value : int ) : IInputOTPSlotProp = Interop.mkProperty "index" value

let InputOTPSlot : JSX.ElementType = JSX.jsx """
React.forwardRef(({ index, className, ...props }, ref) => {
  const inputOTPContext = React.useContext(OTPInputContext)
  const { char, hasFakeCaret, isActive } = inputOTPContext.slots[index]

  return (
    (<div
      ref={ref}
      className={cn(
        "relative flex h-9 w-9 items-center justify-center border-y border-r border-input text-sm shadow-sm transition-all first:rounded-l-md first:border-l last:rounded-r-md",
        isActive && "z-10 ring-1 ring-ring",
        className
      )}
      {...props}>
      {char}
      {hasFakeCaret && (
        <div
          className="pointer-events-none absolute inset-0 flex items-center justify-center">
          <div className="h-4 w-px animate-caret-blink bg-foreground duration-1000" />
        </div>
      )}
    </div>)
  );
})
InputOTPSlot.displayName = "InputOTPSlot"
"""

// --------------- InputOTPSeparator -------------- //
type [<Erase>] IInputOTPSeparatorProp = interface static member propsInterface : unit = () end

let InputOTPSeparator : JSX.ElementType = JSX.jsx """
React.forwardRef(({ ...props }, ref) => (
  <div ref={ref} role="separator" {...props}>
    <Minus />
  </div>
))
InputOTPSeparator.displayName = "InputOTPSeparator"
"""

type [<Erase>] Shadcn =
    static member inline InputOTP ( props : IInputOTPProp list ) = JSX.createElement InputOTP props
    static member inline InputOTP ( children : ReactElement list ) = JSX.createElementWithChildren InputOTP children
    static member inline InputOTPGroup ( props : IInputOTPGroupProp list ) = JSX.createElement InputOTPGroup props
    static member inline InputOTPGroup ( children : ReactElement list ) = JSX.createElementWithChildren InputOTPGroup children
    static member inline InputOTPSlot ( props : IInputOTPSlotProp list ) = JSX.createElement InputOTPSlot props
    static member inline InputOTPSlot ( children : ReactElement list ) = JSX.createElementWithChildren InputOTPSlot children
    static member inline InputOTPSeparator ( props : IInputOTPSeparatorProp list ) = JSX.createElement InputOTPSeparator props
    static member inline InputOTPSeparator ( children : ReactElement list ) = JSX.createElementWithChildren InputOTPSeparator children
            