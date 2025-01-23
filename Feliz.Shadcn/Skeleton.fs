[<AutoOpen>]
module Feliz.Shadcn.Skeleton

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz

JSX.injectShadcnLib

// --------------- Skeleton -------------- //
type [<Erase>] ISkeletonProp = interface static member propsInterface : unit = () end

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

type [<Erase>] Shadcn =
    static member inline Skeleton ( props : ISkeletonProp list ) = JSX.createElement Skeleton props
    static member inline Skeleton ( children : ReactElement list ) = JSX.createElementWithChildren Skeleton children
    static member inline Skeleton ( className : string ) = JSX.createElement Skeleton [ prop.className className ]
    static member inline Skeleton ( className : string list ) = JSX.createElement Skeleton [ prop.className className ]
    