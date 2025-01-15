[<AutoOpen>]
module Feliz.Shadcn.Button

open Feliz.Interop.Extend
open Fable.Core
open Feliz

JSX.injectLib

// --------------- Button -------------- //
/// Shadcn Button prop interface type
type [<Erase>] IButtonProp = interface end
/// Accessor for button properties
type [<Erase>] button =
    // Inherit Feliz base properties
    inherit prop<IButtonProp>
    // Definitions for library defined properties
    static member inline asChild ( value : bool ) : IButtonProp = Interop.mkProperty "asChild" value

/// Button variants as a `Class-Variance-Authority` object.
/// You can modify existing variants or add your own.
/// After adding your own variants, it's suggested to create a variant enum prop. Follow the examples in the `button.variant` type.
let buttonVariants = JSX.jsx """
import { cva } from "class-variance-authority";
cva(
  "inline-flex items-center justify-center gap-2 whitespace-nowrap rounded-md text-sm font-medium transition-colors focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:pointer-events-none disabled:opacity-50 [&_svg]:pointer-events-none [&_svg]:size-4 [&_svg]:shrink-0",
  {
    variants: {
      variant: {
        default:
          "bg-primary text-primary-foreground shadow hover:bg-primary/90",
        destructive:
          "bg-destructive text-destructive-foreground shadow-sm hover:bg-destructive/90",
        outline:
          "border border-input bg-background shadow-sm hover:bg-accent hover:text-accent-foreground",
        secondary:
          "bg-secondary text-secondary-foreground shadow-sm hover:bg-secondary/80",
        ghost: "hover:bg-accent hover:text-accent-foreground",
        link: "text-primary underline-offset-4 hover:underline",
      },
      size: {
        default: "h-9 px-4 py-2",
        sm: "h-8 rounded-md px-3 text-xs",
        lg: "h-10 rounded-md px-8",
        icon: "h-9 w-9",
      },
    },
    defaultVariants: {
      variant: "default",
      size: "default",
    },
  }
)
"""

/// Accessor for button enums.
[<RequireQualifiedAccess>]
module [<Erase>] button =
    /// ButtonVariant enumerators
    type [<Erase>] variant =
        static member inline default' : IButtonProp = Interop.mkProperty "variant" "default"
        static member inline destructive : IButtonProp = Interop.mkProperty "variant" "destructive"
        static member inline outline : IButtonProp = Interop.mkProperty "variant" "outline"
        static member inline secondary : IButtonProp = Interop.mkProperty "variant" "secondary"
        static member inline ghost : IButtonProp = Interop.mkProperty "variant" "ghost"
        static member inline link : IButtonProp = Interop.mkProperty "variant" "link"
    /// ButtonVariant enumerators
    type [<Erase>] size =
        static member inline default' : IButtonProp = Interop.mkProperty "size" "default"
        static member inline sm : IButtonProp = Interop.mkProperty "size" "sm"
        static member inline lg : IButtonProp = Interop.mkProperty "size" "lg"
        static member inline icon : IButtonProp = Interop.mkProperty "size" "icon"

/// The Button JSX Element definition
/// To use this is in your own JSX, you would have to ensure Fable imports the type using a dummy binding
/// <code>
/// let _ = Button
/// </code>
/// To use in Feliz style, access via `Shadcn`.
/// <code>
/// Shadcn.Button [
///   // add props
/// ]
/// </code>
let Button : JSX.ElementType = JSX.jsx """
import { Slot } from "@radix-ui/react-slot";
React.forwardRef(({ className, variant, size, asChild = false, ...props }, ref) => {
  const Comp = asChild ? Slot : "button"
  return (
    (<Comp
      className={cn(buttonVariants({ variant, size, className }))}
      ref={ref}
      {...props} />)
  );
})
Button.displayName = "Button"
"""

type [<Erase>] Shadcn =
  static member inline Button ( props : IButtonProp list ) = JSX.createElement Button props
  static member inline Button ( children : ReactElement list ) = JSX.createElementWithChildren Button children
  static member inline Button ( value : string ) = JSX.createElement Button [ button.text value ]
  static member inline Button ( el : ReactElement ) = JSX.createElement Button [ button.asChild true ; button.children [ el ] ]