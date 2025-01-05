[<AutoOpen>]
module Feliz.Shadcn.Checkbox

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI

emitJsStatement () "import * as CheckboxPrimitive from \"@radix-ui/react-checkbox\""

// --------------- Checkbox -------------- //
// type CheckedState =
//     | True
//     | False
//     | Indeterminate
type [<Erase>] ICheckboxProp = interface end
type [<Erase>] checkbox =
    inherit Checkbox.root<ICheckboxProp>
    static member private noop = ()
    // static member inline checked' ( value : bool ) : ICheckboxProp = Interop.mkProperty "checked" value
    // static member inline defaultChecked ( value : bool ) : ICheckboxProp = Interop.mkProperty "defaultChecked" value
    // static member inline required ( value : bool ) : ICheckboxProp = Interop.mkProperty "required" value
    // static member inline onCheckedChange ( handler : bool -> unit ) : ICheckboxProp = Interop.mkProperty "onCheckedChange" handler
    
[<JSX.Component>]
let Checkbox ( props : ICheckboxProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <CheckboxPrimitive.Root
        ref={ref}
        className={ JSX.cn [|
            "peer h-4 w-4 shrink-0 rounded-sm border border-primary shadow focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50 data-[state=checked]:bg-primary data-[state=checked]:text-primary-foreground"
            properties?className
        |] }
        {{...sprops}} {{...attrs}}>
        <CheckboxPrimitive.Indicator className={ JSX.cn [| "flex items-center justify-center text-current" |] }>
            <Check className="h-4 w-4" />
        </CheckboxPrimitive.Indicator>
    </CheckboxPrimitive.Root>
    """ |> unbox
