﻿[<AutoOpen>]
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
    