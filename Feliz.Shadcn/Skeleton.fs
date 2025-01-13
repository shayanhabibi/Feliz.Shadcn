[<AutoOpen>]
module Feliz.Shadcn.Skeleton

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz

JSX.injectLib

// --------------- Skeleton -------------- //
type [<Erase>] ISkeletonProp = interface end
type [<Erase>] skeleton =
    inherit prop<ISkeletonProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let Skeleton : JSX.ElementType = JSX.jsx """
({
  className,
  ...props
}) => {
  return (
    (<div
      className={cn("animate-pulse rounded-md bg-primary/10", className)}
      {...props} />)
  );
}
"""