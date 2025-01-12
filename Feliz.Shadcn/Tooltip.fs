[<AutoOpen>]
module Feliz.Shadcn.Tooltip

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI

emitJsStatement () "import * as TooltipPrimitive from \"@radix-ui/react-tooltip\""

// --------------- TooltipProvider -------------- //
type [<Erase>] ITooltipProviderProp = interface end
type [<Erase>] tooltipProvider =
    inherit Tooltip.provider<ITooltipProviderProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let TooltipProvider ( props : ITooltipProviderProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <TooltipPrimitive.Provider {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- Tooltip -------------- //
type [<Erase>] ITooltipProp = interface end
type [<Erase>] tooltip =
    inherit Tooltip.root<ITooltipProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let Tooltip ( props : ITooltipProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <TooltipPrimitive.Root {{...attrs}} {{...sprops}} />
    """ |> unbox

// --------------- TooltipTrigger -------------- //
type [<Erase>] ITooltipTriggerProp = interface end
type [<Erase>] tooltipTrigger =
    inherit Tooltip.trigger<ITooltipTriggerProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let TooltipTrigger ( props : ITooltipTriggerProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <TooltipPrimitive.Trigger {{...attrs}} {{...sprops}} />
    """ |> unbox

// --------------- TooltipContent -------------- //
type [<Erase>] ITooltipContentProp = interface end
type [<Erase>] tooltipContent =
    inherit Tooltip.content<ITooltipContentProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let TooltipContent ( props : ITooltipContentProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, sideOffset=4, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <TooltipPrimitive.Portal>
        <TooltipPrimitive.Content
            ref={ref}
            sideOffset={{sideOffset}}
            className={ JSX.cn [|
                "z-50 overflow-hidden rounded-md bg-primary px-3 py-1.5 text-xs text-primary-foreground animate-in fade-in-0 zoom-in-95 data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=closed]:zoom-out-95 data-[side=bottom]:slide-in-from-top-2 data-[side=left]:slide-in-from-right-2 data-[side=right]:slide-in-from-left-2 data-[side=top]:slide-in-from-bottom-2"
                properties?className
            |] }
            {{...sprops}}
            {{...attrs}} />
    </TooltipPrimitive.Portal>
    """ |> unbox