namespace rec Feliz.Shadcn.Form

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn
open Browser.Types


/// Collect information from your users using validation rules.
type [<Erase>] form =
    /// Contains all the parts of a form.
    static member inline root (props: IReactProperty seq) = createElement (import "Form" "@/components/ui/form") props
    /// The wrapper for a field. It handles id/name and label accessibility automatically.
    static member inline field (props: IReactProperty seq) = createElement (import "FormField" "@/components/ui/form") props
    /// A label element which is automatically wired when nested inside a Field part.
    static member inline label (props: IReactProperty seq) = createElement (import "FormLabel" "@/components/ui/form") props
    /// A control element (by default an input) which is automatically wired when nested inside a Field part.
    static member inline control (props: IReactProperty seq) = createElement (import "FormControl" "@/components/ui/form") props
    /// Use this render-prop component to access a given field’s validity state in render (see ValidityState on MDN). A field's validity is available automatically when nested inside a Field part, otherwise you must pass a name prop to associate it.
    static member inline validityState (props: IReactProperty seq) = createElement (import "FormValidityState" "@/components/ui/form") props
    /// The submit button.
    static member inline submit (props: IReactProperty seq) = createElement (import "FormSubmit" "@/components/ui/form") props


/// Contains all the parts of a form.
type [<Erase>] root =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// Event handler called when the form is submitted or reset and the server errors need to be cleared.
    static member inline onClearServerErrors (value: (unit -> unit)) = Feliz.Interop.mkAttr "onClearServerErrors" value




/// The wrapper for a field. It handles id/name and label accessibility automatically.
type [<Erase>] field =
    /// Event handler called when the form is submitted or reset and the server errors need to be cleared.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// The name of the field that will be passed down to the control and used to match with validation messages.
    static member inline name (value: string) = Feliz.Interop.mkAttr "name" value
    /// Use this prop to mark the field as invalid on the server.
    static member inline serverInvalid (value: bool) = Feliz.Interop.mkAttr "serverInvalid" value




/// A label element which is automatically wired when nested inside a Field part.
type [<Erase>] label =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// A control element (by default an input) which is automatically wired when nested inside a Field part.
type [<Erase>] control =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// Use this render-prop component to access a given field’s validity state in render (see ValidityState on MDN). A field's validity is available automatically when nested inside a Field part, otherwise you must pass a name prop to associate it.
type [<Erase>] validityState =
    /// A render function that receives the validity state of the field.
    static member inline children (value: (ValidityState -> ReactElement)) = Feliz.Interop.mkAttr "children" value
    /// A render function that receives the validity state of the field.
    static member inline name (value: string) = Feliz.Interop.mkAttr "name" value




/// The submit button.
type [<Erase>] submit =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value



