[<AutoOpen>]
module Feliz.Shadcn.Avatar

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI

emitJsStatement () "import * as AvatarPrimitive from \"@radix-ui/react-avatar\""

// --------------- Avatar -------------- //
type [<Erase>] IAvatarProp = interface end
type [<Erase>] avatar =
    inherit Avatar.root<IAvatarProp>
    static member private noop : unit = ()

[<JSX.Component>]
let Avatar ( props : IAvatarProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <AvatarPrimitive.Root
        ref={ref}
        className={ JSX.cn [|
            "relative flex h-10 w-10 shrink-0 overflow-hidden rounded-full"
            properties?className
        |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox

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
    
[<JSX.Component>]
let AvatarImage ( props : IAvatarImageProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <AvatarPrimitive.Image
        ref={ref}
        className={ JSX.cn [|
            "aspect-square h-full w-full"
            properties?className
        |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- AvatarFallBack -------------- //
type [<Erase>] IAvatarFallBackProp = interface end
type [<Erase>] avatarFallBack =
    inherit Avatar.fallback<IAvatarFallBackProp>
    static member private noop = ()
    // static member inline delayMs ( value : int ) : IAvatarFallBackProp = Interop.mkProperty "delayMs" value

[<JSX.Component>]
let AvatarFallBack ( props : IAvatarFallBackProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <AvatarPrimitive.Fallback
        ref={ref}
        className={ JSX.cn [|
            "flex h-full w-full items-center justify-center rounded-full bg-muted"
            properties?className
        |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox