﻿[<AutoOpen>]
module Feliz.Shadcn.Separator

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI.Interface.NoInherit
JSX.injectShadcnLib
emitJsStatement () "import * as SeparatorPrimitive from \"@radix-ui/react-separator\""

// --------------- Separator -------------- //
type [<Erase>] ISeparatorProp = interface static member propsInterface : unit = () end
type [<Erase>] separator = Separator.root<ISeparatorProp>

module [<Erase>] separator =
    type [<Erase>] orientation =
        static member inline horizontal : ISeparatorProp = Interop.mkProperty "orientation" "horizontal"
        static member inline vertical : ISeparatorProp = Interop.mkProperty "orientation" "vertical"

let Separator : JSX.ElementType = JSX.jsx """
React.forwardRef((
  { className, orientation = "horizontal", decorative = true, ...props },
  ref
) => (
  <SeparatorPrimitive.Root
    ref={ref}
    decorative={decorative}
    orientation={orientation}
    className={cn(
      "shrink-0 bg-border",
      orientation === "horizontal" ? "h-[1px] w-full" : "h-full w-[1px]",
      className
    )}
    {...props} />
))
Separator.displayName = SeparatorPrimitive.Root.displayName
"""

type [<Erase>] Shadcn =
    static member inline Separator ( props : ISeparatorProp list ) = JSX.createElement Separator props
    static member inline Separator ( children : ReactElement list ) = JSX.createElementWithChildren Separator children
    static member inline Separator () = JSX.createElement Separator []
    static member inline Separator ( el : ReactElement ) = JSX.createElement Separator [ separator.asChild true ; props.children el ]
