﻿[<AutoOpen>]
module Feliz.Shadcn.Textarea

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
JSX.injectShadcnLib

// --------------- Textarea -------------- //
type [<Erase>] ITextareaProp = interface static member propsInterface : unit = () end

let Textarea : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => {
  return (
    (<textarea
      className={cn(
        "flex min-h-[60px] w-full rounded-md border border-input bg-transparent px-3 py-2 text-base shadow-sm placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50 md:text-sm",
        className
      )}
      ref={ref}
      {...props} />)
  );
})
Textarea.displayName = "Textarea"
"""

type [<Erase>] Shadcn =
    static member inline Textarea ( props : ITextareaProp list ) = JSX.createElement Textarea props
    static member inline Textarea ( children : ReactElement list ) = JSX.createElementWithChildren Textarea children
