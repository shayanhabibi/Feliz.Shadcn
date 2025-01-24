[<AutoOpen>]
module Feliz.Shadcn.Toggle

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
JSX.injectShadcnLib
ignore <| JSX.jsx """
import * as TogglePrimitive from "@radix-ui/react-toggle"
import { cva } from "class-variance-authority";
"""

open Feliz.RadixUI.Interface.NoInherit

let toggleVariants = JSX.jsx """
cva(
  "inline-flex items-center justify-center gap-2 rounded-md text-sm font-medium transition-colors hover:bg-muted hover:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:pointer-events-none disabled:opacity-50 data-[state=on]:bg-accent data-[state=on]:text-accent-foreground [&_svg]:pointer-events-none [&_svg]:size-4 [&_svg]:shrink-0",
  {
    variants: {
      variant: {
        default: "bg-transparent",
        outline:
          "border border-input bg-transparent shadow-sm hover:bg-accent hover:text-accent-foreground",
      },
      size: {
        default: "h-9 px-2 min-w-9",
        sm: "h-8 px-1.5 min-w-8",
        lg: "h-10 px-2.5 min-w-10",
      },
    },
    defaultVariants: {
      variant: "default",
      size: "default",
    },
  }
)
"""

// --------------- Toggle -------------- //
type [<Erase>] IToggleProp = interface static member propsInterface : unit = () end
type [<Erase>] toggle = Toggle.root<IToggleProp>

let Toggle : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, variant, size, ...props }, ref) => (
  <TogglePrimitive.Root
    ref={ref}
    className={cn(toggleVariants({ variant, size, className }))}
    {...props} />
))

Toggle.displayName = TogglePrimitive.Root.displayName
"""

type [<Erase>] Shadcn =
    static member inline Toggle ( props : IToggleProp list ) = JSX.createElement Toggle props
    static member inline Toggle ( children : ReactElement list ) = JSX.createElementWithChildren Toggle children
    static member inline Toggle ( el : ReactElement ) = JSX.createElement Toggle [ toggle.asChild true ; props.children el ]
