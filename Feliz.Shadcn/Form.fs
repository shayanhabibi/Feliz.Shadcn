[<AutoOpen>]
module Feliz.Shadcn.Form

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz

emitJsStatement () """
import { Slot } from "@radix-ui/react-slot"
import { Controller, FormProvider, useFormContext } from "react-hook-form"
"""
    
// --------------- Form -------------- //
type [<Erase>] IFormProp = interface end
type [<Erase>] form =
    inherit prop<IFormProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let Form ( props : IFormProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <FormProvider {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- FormField -------------- //
type [<Erase>] IFormFieldProp = interface end
type [<Erase>] formField =
    inherit prop<IFormFieldProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let FormField ( props : IFormFieldProp list ) : ReactElement =
    let FormFieldContext = React.createContext(name="FormFieldContext")
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <FormFieldContext.Provider value={ {| name = properties?name |} }>
        <Controller {{...sprops}} {{...attrs}} />
    </FormFieldContext.Provider>
    """ |> unbox