[<AutoOpen>]
module Feliz.Shadcn.Collapsible

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI

JSX.injectLib

emitJsStatement () "import * as CollapsiblePrimitive from \"@radix-ui/react-collapsible\""

// --------------- Collapsible -------------- //
type [<Erase>] ICollapsibleProp = interface end
type [<Erase>] collapsible =
    inherit Collapsible.root<ICollapsibleProp>
    static member private noop = ()

let Collapsible : JSX.ElementType = JSX.jsx "CollapsiblePrimitive.Root"

// --------------- CollapsibleTrigger -------------- //
type [<Erase>] ICollapsibleTriggerProp = interface end
type [<Erase>] collapsibleTrigger =
    inherit Collapsible.trigger<ICollapsibleTriggerProp>
    static member inline forceMount ( value : bool ) : ICollapsibleTriggerProp = Interop.mkProperty "forceMount" value

[<JSX.Component>]
let CollapsibleTrigger : JSX.ElementType = JSX.jsx "CollapsiblePrimitive.CollapsibleTrigger"

// --------------- CollapsibleContent -------------- //
type [<Erase>] ICollapsibleContentProp = interface end
type [<Erase>] collapsibleContent =
    inherit Collapsible.content<ICollapsibleContentProp>
    static member inline present ( value : bool ) : ICollapsibleContentProp = Interop.mkProperty "present" value

[<JSX.Component>]
let CollapsibleContent : JSX.ElementType = JSX.jsx "CollapsiblePrimitive.CollapsibleContent"

type [<Erase>] Shadcn =
    static member inline Collapsible ( props : ICollapsibleProp list ) = JSX.createElement Collapsible props
    static member inline Collapsible ( children : ReactElement list ) = JSX.createElementWithChildren Collapsible children
    static member inline CollapsibleTrigger ( props : ICollapsibleTriggerProp list ) = JSX.createElement CollapsibleTrigger props
    static member inline CollapsibleTrigger ( children : ReactElement list ) = JSX.createElementWithChildren CollapsibleTrigger children
    static member inline CollapsibleTrigger ( value : string ) = JSX.createElement CollapsibleTrigger [ prop.text value ]
    static member inline CollapsibleContent ( props : ICollapsibleContentProp list ) = JSX.createElement CollapsibleContent props
    static member inline CollapsibleContent ( children : ReactElement list ) = JSX.createElementWithChildren CollapsibleContent children
    static member inline CollapsibleContent ( value : string ) = JSX.createElement CollapsibleContent [ prop.text value ]