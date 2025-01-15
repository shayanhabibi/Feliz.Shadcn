[<AutoOpen>]
module Feliz.Shadcn.Form

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz

JSX.injectShadcnLib
ignore <| JSX.jsx """
import { Slot } from "@radix-ui/react-slot"
import { Controller, FormProvider, useFormContext } from "react-hook-form"
"""
let _ = Shadcn.Label.Label

    
// --------------- Form -------------- //
type [<Erase>] IFormProp = interface end
type [<Erase>] form =
    inherit prop<IFormProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let Form : JSX.ElementType = JSX.jsx """
FormProvider
"""

// --------------- FormField -------------- //
type [<Erase>] IFormFieldProp = interface end
type [<Erase>] formField =
    inherit prop<IFormFieldProp>
    static member inline noop : unit = ()

let private FormFieldContext = JSX.jsx "React.createContext({})"

[<JSX.Component>]
let FormField : JSX.ElementType = JSX.jsx """
(
  {
    ...props
  }
) => {
  return (
    (<FormFieldContext.Provider value={{ name: props.name }}>
      <Controller {...props} />
    </FormFieldContext.Provider>)
  );
}
"""

let useFormField : unit -> obj = unbox <| JSX.jsx """
() => {
  const fieldContext = React.useContext(FormFieldContext)
  const itemContext = React.useContext(FormItemContext)
  const { getFieldState, formState } = useFormContext()

  const fieldState = getFieldState(fieldContext.name, formState)

  if (!fieldContext) {
    throw new Error("useFormField should be used within <FormField>")
  }

  const { id } = itemContext

  return {
    id,
    name: fieldContext.name,
    formItemId: `${id}-form-item`,
    formDescriptionId: `${id}-form-item-description`,
    formMessageId: `${id}-form-item-message`,
    ...fieldState,
  }
}
"""

let private FormItemContext = JSX.jsx "React.createContext({})"

// --------------- FormItem -------------- //
type [<Erase>] IFormItemProp = interface end
type [<Erase>] formItem =
    inherit prop<IFormItemProp>
    static member inline noop : unit = ()

let FormItem : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => {
  const id = React.useId()

  return (
    (<FormItemContext.Provider value={{ id }}>
      <div ref={ref} className={cn("space-y-2", className)} {...props} />
    </FormItemContext.Provider>)
  );
})
FormItem.displayName = "FormItem"
"""

// --------------- FormLabel -------------- //
type [<Erase>] IFormLabelProp = interface end
type [<Erase>] formLabel =
    inherit prop<IFormLabelProp>
    static member inline noop : unit = ()

let FormLabel : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => {
  const { error, formItemId } = useFormField()

  return (
    (<Label
      ref={ref}
      className={cn(error && "text-destructive", className)}
      htmlFor={formItemId}
      {...props} />)
  );
})
FormLabel.displayName = "FormLabel"
"""

// --------------- FormControl -------------- //
type [<Erase>] IFormControlProp = interface end
type [<Erase>] formControl =
    inherit prop<IFormControlProp>
    static member inline noop : unit = ()

let FormControl : JSX.ElementType = JSX.jsx """
React.forwardRef(({ ...props }, ref) => {
  const { error, formItemId, formDescriptionId, formMessageId } = useFormField()

  return (
    (<Slot
      ref={ref}
      id={formItemId}
      aria-describedby={
        !error
          ? `${formDescriptionId}`
          : `${formDescriptionId} ${formMessageId}`
      }
      aria-invalid={!!error}
      {...props} />)
  );
})
FormControl.displayName = "FormControl"
"""

// --------------- FormDescription -------------- //
type [<Erase>] IFormDescriptionProp = interface end
type [<Erase>] formDescription =
    inherit prop<IFormDescriptionProp>
    static member inline noop : unit = ()

let FormDescription : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => {
  const { formDescriptionId } = useFormField()

  return (
    (<p
      ref={ref}
      id={formDescriptionId}
      className={cn("text-[0.8rem] text-muted-foreground", className)}
      {...props} />)
  );
})
FormDescription.displayName = "FormDescription"
"""

// --------------- FormMessage -------------- //
type [<Erase>] IFormMessageProp = interface end
type [<Erase>] formMessage =
    inherit prop<IFormMessageProp>
    static member inline noop : unit = ()

let FormMessage : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, children, ...props }, ref) => {
  const { error, formMessageId } = useFormField()
  const body = error ? String(error?.message) : children

  if (!body) {
    return null
  }

  return (
    (<p
      ref={ref}
      id={formMessageId}
      className={cn("text-[0.8rem] font-medium text-destructive", className)}
      {...props}>
      {body}
    </p>)
  );
})
FormMessage.displayName = "FormMessage"
"""

type [<Erase>] Shadcn =
    static member inline Form ( props : IFormProp list ) = JSX.createElement Form props
    static member inline Form ( children : ReactElement list ) = JSX.createElementWithChildren Form children
    static member inline FormItem ( props : IFormItemProp list ) = JSX.createElement FormItem props
    static member inline FormItem ( children : ReactElement list ) = JSX.createElementWithChildren FormItem children
    static member inline FormLabel ( props : IFormLabelProp list ) = JSX.createElement FormLabel props
    static member inline FormLabel ( children : ReactElement list ) = JSX.createElementWithChildren FormLabel children
    static member inline FormControl ( props : IFormControlProp list ) = JSX.createElement FormControl props
    static member inline FormControl ( children : ReactElement list ) = JSX.createElementWithChildren FormControl children
    static member inline FormDescription ( props : IFormDescriptionProp list ) = JSX.createElement FormDescription props
    static member inline FormDescription ( children : ReactElement list ) = JSX.createElementWithChildren FormDescription children
    static member inline FormMessage ( props : IFormMessageProp list ) = JSX.createElement FormMessage props
    static member inline FormMessage ( children : ReactElement list ) = JSX.createElementWithChildren FormMessage children
    static member inline FormField ( props : IFormFieldProp list ) = JSX.createElement FormField props
    static member inline FormField ( children : ReactElement list ) = JSX.createElementWithChildren FormField children
                        
  