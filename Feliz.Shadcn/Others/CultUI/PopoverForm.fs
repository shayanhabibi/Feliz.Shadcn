[<AutoOpen>]
module Feliz.Shadcn.CultUI.PopoverForm

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
JSX.injectShadcnLib
ignore <| JSX.jsx """
import { useEffect, useRef } from "react";
import { ChevronUp, Loader } from "lucide-react"
import { AnimatePresence, motion } from "framer-motion"
"""

// --------------- PopoverForm -------------- //
type [<Erase>] IPopoverFormProp = interface end
type [<Erase>] popoverForm =
    static member inline open' ( value : bool ) : IPopoverFormProp = Interop.mkProperty "open" value
    static member inline setOpen ( handler : bool -> unit ) : IPopoverFormProp = Interop.mkProperty "setOpen" handler
    static member inline openChild ( value : ReactElement ) : IPopoverFormProp = Interop.mkProperty "openChild" value
    static member inline successChild ( value : ReactElement ) : IPopoverFormProp = Interop.mkProperty "successChild" value
    static member inline showSuccess ( value : bool ) : IPopoverFormProp = Interop.mkProperty "showSuccess" value
    static member inline width ( value : string ) : IPopoverFormProp = Interop.mkProperty "width" value
    static member inline height ( value : string ) : IPopoverFormProp = Interop.mkProperty "height" value
    static member inline showCloseButton ( value : bool ) : IPopoverFormProp = Interop.mkProperty "showCloseButton" value
    static member inline title ( value : string ) : IPopoverFormProp = Interop.mkProperty "title" value

let PopoverForm : JSX.ElementType = JSX.jsx """
({
  open,
  setOpen,
  openChild,
  showSuccess,
  successChild,
  width = "364px",
  height = "192px",
  title = "Feedback",
  showCloseButton = false
}) => {
  const ref = useRef(null)
  useClickOutside(ref, () => setOpen(false))

  return (
    (<div
      key={title}
      className="flex min-h-[300px] w-full items-center justify-center">
      <motion.button
        layoutId={`${title}-wrapper`}
        onClick={() => setOpen(true)}
        style={{ borderRadius: 8 }}
        className="flex h-9 items-center border bg-white dark:bg-[#121212] px-3 text-sm font-medium outline-none">
        <motion.span layoutId={`${title}-title`}>{title}</motion.span>
      </motion.button>
      <AnimatePresence>
        {open && (
          <motion.div
            layoutId={`${title}-wrapper`}
            className="absolute p-1 overflow-hidden bg-muted shadow-[0_0_0_1px_rgba(0,0,0,0.08),0px_1px_2px_rgba(0,0,0,0.04)] outline-none"
            ref={ref}
            style={{ borderRadius: 10, width, height }}>
            <motion.span
              aria-hidden
              className="absolute left-4 top-[17px] text-sm text-muted-foreground data-[success]:text-transparent"
              layoutId={`${title}-title`}
              data-success={showSuccess}>
              {title}
            </motion.span>

            {showCloseButton && (
              <div
                className="absolute -top-[5px] left-1/2 transform -translate-x-1/2 w-[12px] h-[26px] flex items-center justify-center z-20">
                <button
                  onClick={() => setOpen(false)}
                  className="absolute z-10 -mt-1 flex items-center justify-center w-[10px] h-[6px] text-muted-foreground hover:text-foreground focus:outline-none  rounded-full "
                  aria-label="Close">
                  <ChevronUp className="text-muted-foreground/80" />
                </button>

                <PopoverFormCutOutTopIcon />
              </div>
            )}

            <AnimatePresence mode="popLayout">
              {showSuccess ? (
                <motion.div
                  key="success"
                  initial={{ y: -32, opacity: 0, filter: "blur(4px)" }}
                  animate={{ y: 0, opacity: 1, filter: "blur(0px)" }}
                  transition={{ type: "spring", duration: 0.4, bounce: 0 }}
                  className="flex h-full flex-col items-center justify-center">
                  {successChild || <PopoverFormSuccess />}
                </motion.div>
              ) : (
                <motion.div
                  exit={{ y: 8, opacity: 0, filter: "blur(4px)" }}
                  transition={{ type: "spring", duration: 0.4, bounce: 0 }}
                  key="open-child"
                  style={{ borderRadius: 10 }}
                  className="h-full border bg-white dark:bg-[#121212] z-20 ">
                  {openChild}
                </motion.div>
              )}
            </AnimatePresence>
          </motion.div>
        )}
      </AnimatePresence>
    </div>)
  );
}
"""

// --------------- PopoverFormButton -------------- //
type [<Erase>] IPopoverFormButtonProp = interface end
type [<Erase>] popoverFormButton =
    static member inline loading ( value : bool ) : IPopoverFormButtonProp = Interop.mkProperty "loading" value
    static member inline text ( value : string ) : IPopoverFormButtonProp = Interop.mkProperty "text" value

let PopoverFormButton : JSX.ElementType = JSX.jsx """
({
  loading,
  text = "submit"
}) => {
  return (
    (<button
      type="submit"
      className="ml-auto flex h-6 w-26 items-center justify-center overflow-hidden rounded-md bg-gradient-to-b from-primary/90 to-primary px-3 text-xs font-semibold text-primary-foreground shadow-[0_0_1px_1px_rgba(255,255,255,0.08)_inset,0_1px_1.5px_0_rgba(0,0,0,0.32),0_0_0_0.5px_#1a94ff]">
      <AnimatePresence mode="popLayout" initial={false}>
        <motion.span
          key={`${loading}`}
          initial={{ opacity: 0, y: -25 }}
          animate={{ opacity: 1, y: 0 }}
          exit={{ opacity: 0, y: 25 }}
          transition={{
            type: "spring",
            duration: 0.3,
            bounce: 0,
          }}
          className="flex w-full items-center justify-center">
          {loading ? (
            <Loader className="animate-spin size-3" />
          ) : (
            <span>{text}</span>
          )}
        </motion.span>
      </AnimatePresence>
    </button>)
  );
}
"""

let private useClickOutside = JSX.jsx """
(
  ref,
  handleOnClickOutside
) => {
  useEffect(() => {
    const listener = (event) => {
      if (!ref.current || ref.current.contains(event.target)) {
        return
      }
      handleOnClickOutside(event)
    }
    document.addEventListener("mousedown", listener)
    document.addEventListener("touchstart", listener)
    return () => {
      document.removeEventListener("mousedown", listener)
      document.removeEventListener("touchstart", listener)
    };
  }, [ref, handleOnClickOutside])
}
"""

// --------------- PopoverFormSuccess -------------- //
type [<Erase>] IPopoverFormSuccessProp = interface end
type [<Erase>] popoverFormSuccess =
    static member inline title ( value : string ) : IPopoverFormSuccessProp = Interop.mkProperty "title" value
    static member inline description ( value : string ) : IPopoverFormSuccessProp = Interop.mkProperty "description" value

let PopoverFormSuccess : JSX.ElementType = JSX.jsx """
({
  title = "Success",
  description = "Thank you for your submission",
}) => {
  return (<>
    <svg
      width="32"
      height="32"
      viewBox="0 0 32 32"
      fill="none"
      xmlns="http://www.w3.org/2000/svg"
      className="-mt-1">
      <path
        d="M27.6 16C27.6 17.5234 27.3 19.0318 26.717 20.4392C26.1341 21.8465 25.2796 23.1253 24.2025 24.2025C23.1253 25.2796 21.8465 26.1341 20.4392 26.717C19.0318 27.3 17.5234 27.6 16 27.6C14.4767 27.6 12.9683 27.3 11.5609 26.717C10.1535 26.1341 8.87475 25.2796 7.79759 24.2025C6.72043 23.1253 5.86598 21.8465 5.28302 20.4392C4.70007 19.0318 4.40002 17.5234 4.40002 16C4.40002 12.9235 5.62216 9.97301 7.79759 7.79759C9.97301 5.62216 12.9235 4.40002 16 4.40002C19.0765 4.40002 22.027 5.62216 24.2025 7.79759C26.3779 9.97301 27.6 12.9235 27.6 16Z"
        fill="#2090FF"
        fillOpacity="0.16" />
      <path
        d="M12.1334 16.9667L15.0334 19.8667L19.8667 13.1M27.6 16C27.6 17.5234 27.3 19.0318 26.717 20.4392C26.1341 21.8465 25.2796 23.1253 24.2025 24.2025C23.1253 25.2796 21.8465 26.1341 20.4392 26.717C19.0318 27.3 17.5234 27.6 16 27.6C14.4767 27.6 12.9683 27.3 11.5609 26.717C10.1535 26.1341 8.87475 25.2796 7.79759 24.2025C6.72043 23.1253 5.86598 21.8465 5.28302 20.4392C4.70007 19.0318 4.40002 17.5234 4.40002 16C4.40002 12.9235 5.62216 9.97301 7.79759 7.79759C9.97301 5.62216 12.9235 4.40002 16 4.40002C19.0765 4.40002 22.027 5.62216 24.2025 7.79759C26.3779 9.97301 27.6 12.9235 27.6 16Z"
        stroke="#2090FF"
        strokeWidth="2.4"
        strokeLinecap="round"
        strokeLinejoin="round" />
    </svg>
    <h3 className="mb-1 mt-2 text-sm font-medium text-primary">{title}</h3>
    <p
      className="text-sm text-muted-foreground max-w-xs text-pretty mx-auto text-center">
      {description}
    </p>
  </>);
}
"""

// --------------- PopoverFormSeparator -------------- //
type [<Erase>] IPopoverFormSeparatorProp = interface end
type [<Erase>] popoverFormSeparator =
    static member inline width ( value : int ) : IPopoverFormSeparatorProp = Interop.mkProperty "width" value
    static member inline width ( value : string ) : IPopoverFormSeparatorProp = Interop.mkProperty "width" value
    static member inline height ( value : int ) : IPopoverFormSeparatorProp = Interop.mkProperty "height" value
    static member inline height ( value : string ) : IPopoverFormSeparatorProp = Interop.mkProperty "height" value

let PopoverFormSeparator : JSX.ElementType = JSX.jsx """
({
  width = 352,
  height = 2
}) => {
  return (
    (<svg
      className="absolute left-0 right-0 top-[-1px]"
      width={width}
      height={height}
      viewBox="0 0 352 2"
      fill="none"
      xmlns="http://www.w3.org/2000/svg">
      <path d="M0 1H352" className="stroke-border" strokeDasharray="4 4" />
    </svg>)
  );
}
"""

// --------------- PopoverFormCutOutTopIcon -------------- //
type [<Erase>] IPopoverFormCutOutTopIconProp = interface end
type [<Erase>] popoverFormCutOutTopIcon =
    static member inline height ( value : int ) : IPopoverFormCutOutTopIconProp = Interop.mkProperty "height" value
    static member inline width ( value : int ) : IPopoverFormCutOutTopIconProp = Interop.mkProperty "width" value

let PopoverFormCutOutTopIcon : JSX.ElementType = JSX.jsx """
({
  width = 44,
  height = 30
}) => {
  const aspectRatio = 6 / 12
  const calculatedHeight = width * aspectRatio
  const calculatedWidth = height / aspectRatio

  const finalWidth = Math.min(width, calculatedWidth)
  const finalHeight = Math.min(height, calculatedHeight)

  return (
    (<svg
      width={finalWidth}
      height={finalHeight}
      viewBox="0 0 6 12"
      fill="none"
      xmlns="http://www.w3.org/2000/svg"
      className="rotate-90 mt-[1px]"
      preserveAspectRatio="none">
      <g clipPath="url(#clip0_2029_22)">
        <path
          d="M0 2C0.656613 2 1.30679 2.10346 1.91341 2.30448C2.52005 2.5055 3.07124 2.80014 3.53554 3.17157C3.99982 3.54301 4.36812 3.98396 4.6194 4.46927C4.87067 4.95457 5 5.47471 5 6C5 6.52529 4.87067 7.04543 4.6194 7.53073C4.36812 8.01604 3.99982 8.45699 3.53554 8.82843C3.07124 9.19986 2.52005 9.4945 1.91341 9.69552C1.30679 9.89654 0.656613 10 0 10V6V2Z"
          className="fill-muted" />
        <path
          d="M1 12V10C2.06087 10 3.07828 9.57857 3.82843 8.82843C4.57857 8.07828 5 7.06087 5 6C5 4.93913 4.57857 3.92172 3.82843 3.17157C3.07828 2.42143 2.06087 2 1 2V0"
          className="stroke-border"
          strokeWidth={0.6}
          strokeLinejoin="round" />
      </g>
      <defs>
        <clipPath id="clip0_2029_22">
          <rect width={finalWidth} height={finalHeight} fill="white" />
        </clipPath>
      </defs>
    </svg>)
  );
}
"""

// --------------- PopoverFormCutOutLeftIcon -------------- //
type [<Erase>] IPopoverFormCutOutLeftIconProp = interface end
type [<Erase>] popoverFormCutOutLeftIcon =
    static member inline private noop : unit = ()

let PopoverFormCutOutLeftIcon : JSX.ElementType = JSX.jsx """
() => {
  return (
    (<svg
      width="6"
      height="12"
      viewBox="0 0 6 12"
      fill="none"
      xmlns="http://www.w3.org/2000/svg">
      <g clipPath="url(#clip0_2029_22)">
        <path
          d="M0 2C0.656613 2 1.30679 2.10346 1.91341 2.30448C2.52005 2.5055 3.07124 2.80014 3.53554 3.17157C3.99982 3.54301 4.36812 3.98396 4.6194 4.46927C4.87067 4.95457 5 5.47471 5 6C5 6.52529 4.87067 7.04543 4.6194 7.53073C4.36812 8.01604 3.99982 8.45699 3.53554 8.82843C3.07124 9.19986 2.52005 9.4945 1.91341 9.69552C1.30679 9.89654 0.656613 10 0 10V6V2Z"
          className="fill-muted" />
        <path
          d="M1 12V10C2.06087 10 3.07828 9.57857 3.82843 8.82843C4.57857 8.07828 5 7.06087 5 6C5 4.93913 4.57857 3.92172 3.82843 3.17157C3.07828 2.42143 2.06087 2 1 2V0"
          className="stroke-border"
          strokeWidth="1"
          strokeLinejoin="round" />
      </g>
      <defs>
        <clipPath id="clip0_2029_22">
          <rect width="6" height="12" fill="white" />
        </clipPath>
      </defs>
    </svg>)
  );
}
"""

// --------------- PopoverFormCutOutRightIcon -------------- //
type [<Erase>] IPopoverFormCutOutRightIconProp = interface end
type [<Erase>] popoverFormCutOutRightIcon =
    static member inline private noop : unit = ()

let PopoverFormCutOutRightIcon : JSX.ElementType = JSX.jsx """
() => {
  return (
    (<svg
      width="6"
      height="12"
      viewBox="0 0 6 12"
      fill="none"
      xmlns="http://www.w3.org/2000/svg">
      <g clipPath="url(#clip0_2029_22)">
        <path
          d="M0 2C0.656613 2 1.30679 2.10346 1.91341 2.30448C2.52005 2.5055 3.07124 2.80014 3.53554 3.17157C3.99982 3.54301 4.36812 3.98396 4.6194 4.46927C4.87067 4.95457 5 5.47471 5 6C5 6.52529 4.87067 7.04543 4.6194 7.53073C4.36812 8.01604 3.99982 8.45699 3.53554 8.82843C3.07124 9.19986 2.52005 9.4945 1.91341 9.69552C1.30679 9.89654 0.656613 10 0 10V6V2Z"
          className="fill-muted" />
        <path
          d="M1 12V10C2.06087 10 3.07828 9.57857 3.82843 8.82843C4.57857 8.07828 5 7.06087 5 6C5 4.93913 4.57857 3.92172 3.82843 3.17157C3.07828 2.42143 2.06087 2 1 2V0"
          className="stroke-border"
          strokeWidth="1"
          strokeLinejoin="round" />
      </g>
      <defs>
        <clipPath id="clip0_2029_22">
          <rect width="6" height="12" fill="white" />
        </clipPath>
      </defs>
    </svg>)
  );
}
"""

type [<Erase>] Shadcn =
    static member inline PopoverForm ( props : IPopoverFormProp list ) = JSX.createElement PopoverForm props
    static member inline PopoverFormButton ( props : IPopoverFormButtonProp list ) = JSX.createElement PopoverFormButton props
    static member inline PopoverFormSuccess ( props : IPopoverFormSuccessProp list ) = JSX.createElement PopoverFormSuccess props
    static member inline PopoverFormSeparator ( props : IPopoverFormSeparatorProp list ) = JSX.createElement PopoverFormSeparator props
    static member inline PopoverFormCutOutTopIcon ( props : IPopoverFormCutOutTopIconProp list ) = JSX.createElement PopoverFormCutOutTopIcon props
    static member inline PopoverFormCutOutLeftIcon ( props : IPopoverFormCutOutLeftIconProp list ) = JSX.createElement PopoverFormCutOutLeftIcon props
    static member inline PopoverFormCutOutRightIcon ( props : IPopoverFormCutOutRightIconProp list ) = JSX.createElement PopoverFormCutOutRightIcon props
    
    
