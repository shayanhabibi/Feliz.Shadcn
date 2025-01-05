[<AutoOpen>]
module Feliz.Shadcn.Collapsible

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI

emitJsStatement () "import * as CollapsiblePrimitive from \"@radix-ui/react-collapsible\""

// --------------- Collapsible -------------- //
type [<Erase>] ICollapsibleProp = interface end
type [<Erase>] collapsible =
    inherit Collapsible.root<ICollapsibleProp>
    static member private noop = ()
    // static member inline defaultOpen ( value : bool ) : ICollapsibleProp = Interop.mkProperty "defaultOpen" value
    // static member inline open' ( value : bool ) : ICollapsibleProp = Interop.mkProperty "open" value
    // static member inline disabled ( value : bool ) : ICollapsibleProp = Interop.mkProperty "disabled" value
    // static member inline onOpenChange ( handler : bool -> unit ) : ICollapsibleProp = Interop.mkProperty "onOpenChange" handler

[<JSX.Component>]
let Collapsible ( props : ICollapsibleProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <CollapsiblePrimitive.Root {{...sprops}} {{...attrs}}/>
    """ |> unbox

// --------------- CollapsibleTrigger -------------- //
type [<Erase>] ICollapsibleTriggerProp = interface end
type [<Erase>] collapsibleTrigger =
    inherit Collapsible.trigger<ICollapsibleTriggerProp>
    static member inline forceMount ( value : bool ) : ICollapsibleTriggerProp = Interop.mkProperty "forceMount" value

[<JSX.Component>]
let CollapsibleTrigger ( props : ICollapsibleTriggerProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    // emitJsStatement properties "const {forceMount=true , ...sprops} = $0; const {props, ...attrs} = $props;"
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <CollapsiblePrimitive.Trigger {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- CollapsibleContent -------------- //
type [<Erase>] ICollapsibleContentProp = interface end
type [<Erase>] collapsibleContent =
    inherit Collapsible.content<ICollapsibleContentProp>
    static member inline present ( value : bool ) : ICollapsibleContentProp = Interop.mkProperty "present" value

[<JSX.Component>]
let CollapsibleContent ( props : ICollapsibleContentProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <CollapsiblePrimitive.Content {{...sprops}} {{...attrs}} />
    """ |> unbox