[<AutoOpen>]
module Feliz.Shadcn.Avatar

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI

emitJsStatement () "import * as AvatarPrimitive from \"@radix-ui/react-avatar\""
JSX.injectLib

// --------------- Avatar -------------- //
type [<Erase>] IAvatarProp = interface end
type [<Erase>] avatar =
    inherit Avatar.root<IAvatarProp>
    static member private noop : unit = ()

let Avatar : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <AvatarPrimitive.Root
    ref={ref}
    className={cn("relative flex h-10 w-10 shrink-0 overflow-hidden rounded-full", className)}
    {...props} />
))
Avatar.displayName = AvatarPrimitive.Root.displayName
"""

// --------------- AvatarImage -------------- //
type [<Erase>] IAvatarImageProp = interface end

[<StringEnum>]
type [<Erase>] ImageLoadingStatus =
    | Idle
    | Loading
    | Loaded
    | Error

type [<Erase>] avatarImage =
    inherit Avatar.image<IAvatarImageProp>
    static member inline onLoadingStatusChange ( handler : ImageLoadingStatus -> unit ) : IAvatarImageProp = Interop.mkProperty "onLoadingStatusChange" handler
    
let AvatarImage : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <AvatarPrimitive.Image
    ref={ref}
    className={cn("aspect-square h-full w-full", className)}
    {...props} />
))
AvatarImage.displayName = AvatarPrimitive.Image.displayName
"""

// --------------- AvatarFallBack -------------- //
type [<Erase>] IAvatarFallbackProp = interface end
type [<Erase>] avatarFallback =
    inherit Avatar.fallback<IAvatarFallbackProp>
    static member private noop = ()
    // static member inline delayMs ( value : int ) : IAvatarFallBackProp = Interop.mkProperty "delayMs" value

let AvatarFallback : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <AvatarPrimitive.Fallback
    ref={ref}
    className={cn(
      "flex h-full w-full items-center justify-center rounded-full bg-muted",
      className
    )}
    {...props} />
))
AvatarFallback.displayName = AvatarPrimitive.Fallback.displayName
"""

type [<Erase>] Shadcn =
    static member inline Avatar ( props : IAvatarProp list ) = JSX.createElement Avatar props
    static member inline Avatar ( props : ReactElement list ) = JSX.createElementWithChildren Avatar props
    static member inline AvatarImage ( props : IAvatarImageProp list ) = JSX.createElement AvatarImage props
    static member inline AvatarImage ( props : ReactElement list ) = JSX.createElementWithChildren AvatarImage props
    static member inline AvatarFallback ( props : IAvatarFallbackProp list ) = JSX.createElement AvatarFallback props
    static member inline AvatarFallback ( props : ReactElement list ) = JSX.createElementWithChildren AvatarFallback props
    static member inline AvatarFallback ( value : string ) = JSX.createElement AvatarFallback [ prop.text value ]
    
