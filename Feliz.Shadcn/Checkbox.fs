namespace rec Feliz.Shadcn.Checkbox

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn
open Browser.Types


/// A control that allows the user to toggle between checked and not checked.
type [<Erase>] checkbox =
    /// Contains all the parts of a checkbox. An input will also render when used within a form to ensure events propagate correctly.
    static member inline root (props: IReactProperty seq) = createElement (import "Checkbox" "@/components/ui/checkbox") props
    /// Renders when the checkbox is in a checked or indeterminate state. You can style this element directly, or you can use it as a wrapper to put an icon into, or both.
    static member inline indicator (props: IReactProperty seq) = createElement (import "CheckboxIndicator" "@/components/ui/checkbox") props


/// Contains all the parts of a checkbox. An input will also render when used within a form to ensure events propagate correctly.
type [<Erase>] root =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// The checked state of the checkbox when it is initially rendered. Use when you do not need to control its checked state.
    static member inline defaultChecked (value: bool) = Feliz.Interop.mkAttr "defaultChecked" value
    /// The controlled checked state of the checkbox. Must be used in conjunction with onCheckedChange.
    static member inline checked' (value: bool) = Feliz.Interop.mkAttr "checked" value
    /// Event handler called when the checked state of the checkbox changes.
    static member inline onCheckedChange (value: (bool -> unit)) = Feliz.Interop.mkAttr "onCheckedChange" value
    /// Event handler called when the checked state of the checkbox changes.
    static member inline onCheckedChange (value: (string -> unit)) = Feliz.Interop.mkAttr "onCheckedChange" value
    /// Event handler called when the checked state of the checkbox changes.
    static member inline disabled (value: bool) = Feliz.Interop.mkAttr "disabled" value
    /// When true, indicates that the user must check the checkbox before the owning form can be submitted.
    static member inline required (value: bool) = Feliz.Interop.mkAttr "required" value
    /// The name of the checkbox. Submitted with its owning form as part of a name/value pair.
    static member inline name (value: string) = Feliz.Interop.mkAttr "name" value
    /// The value given as data when submitted with a name.
    static member inline value (value: string) = Feliz.Interop.mkAttr "value" value




/// Renders when the checkbox is in a checked or indeterminate state. You can style this element directly, or you can use it as a wrapper to put an icon into, or both.
type [<Erase>] indicator =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value



