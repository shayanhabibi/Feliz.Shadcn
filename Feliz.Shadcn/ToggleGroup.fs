[<AutoOpen>]
module Feliz.Shadcn.ToggleGroup

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
JSX.injectShadcnLib
ignore <| JSX.jsx """
import * as ToggleGroupPrimitive from "@radix-ui/react-toggle-group"
"""
let _ = toggleVariants

open Feliz.RadixUI.Interface.NoInherit

let private ToggleGroupContext = JSX.jsx """
React.createContext({
  size: "default",
  variant: "default",
})
"""

// --------------- ToggleGroup -------------- //
type [<Erase>] IToggleGroupProp = interface static member propsInterface : unit = () end
type [<Erase>] toggleGroup = ToggleGroup.root<IToggleGroupProp>

let ToggleGroup : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, variant, size, children, ...props }, ref) => (
  <ToggleGroupPrimitive.Root
    ref={ref}
    className={cn("flex items-center justify-center gap-1", className)}
    {...props}>
    <ToggleGroupContext.Provider value={{ variant, size }}>
      {children}
    </ToggleGroupContext.Provider>
  </ToggleGroupPrimitive.Root>
))
ToggleGroup.displayName = ToggleGroupPrimitive.Root.displayName
"""

// --------------- ToggleGroupItem -------------- //
type [<Erase>] IToggleGroupItemProp = interface static member propsInterface : unit = () end
type [<Erase>] toggleGroupItem = ToggleGroup.item<IToggleGroupItemProp>

let ToggleGroupItem : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, children, variant, size, ...props }, ref) => {
  const context = React.useContext(ToggleGroupContext)

  return (
    (<ToggleGroupPrimitive.Item
      ref={ref}
      className={cn(toggleVariants({
        variant: context.variant || variant,
        size: context.size || size,
      }), className)}
      {...props}>
      {children}
    </ToggleGroupPrimitive.Item>)
  );
})

ToggleGroupItem.displayName = ToggleGroupPrimitive.Item.displayName
"""

type [<Erase>] Shadcn =
    static member inline ToggleGroup ( props : IToggleGroupProp list ) = JSX.createElement ToggleGroup props
    static member inline ToggleGroup ( children : ReactElement list ) = JSX.createElementWithChildren ToggleGroup children
    static member inline ToggleGroup ( el : ReactElement ) = JSX.createElement ToggleGroup [ toggleGroup.asChild true ; toggleGroup.children el ]
    static member inline ToggleGroupItem ( props : IToggleGroupItemProp list ) = JSX.createElement ToggleGroupItem props
    static member inline ToggleGroupItem ( children : ReactElement list ) = JSX.createElementWithChildren ToggleGroupItem children
    static member inline ToggleGroupItem ( el : ReactElement ) = JSX.createElement ToggleGroupItem [ toggleGroupItem.asChild true ; toggleGroupItem.children el ]
    