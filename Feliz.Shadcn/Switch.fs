namespace rec Feliz.Shadcn.Switch

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn
open Browser.Types


/// A control that allows the user to toggle between checked and not checked.
type [<Erase>] switch =
    /// Contains all the parts of a switch. An input will also render when used within a form to ensure events propagate correctly.
    static member inline root (props: IReactProperty seq) = createElement (import "Switch" "@/components/ui/switch") props
    /// The thumb that is used to visually indicate whether the switch is on or off.
    static member inline thumb (props: IReactProperty seq) = createElement (import "SwitchThumb" "@/components/ui/switch") props


/// Contains all the parts of a switch. An input will also render when used within a form to ensure events propagate correctly.
type [<Erase>] root =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// The state of the switch when it is initially rendered. Use when you do not need to control its state.
    static member inline defaultChecked (value: bool) = Feliz.Interop.mkAttr "defaultChecked" value
    /// The controlled state of the switch. Must be used in conjunction with onCheckedChange.
    static member inline checked' (value: bool) = Feliz.Interop.mkAttr "checked" value
    /// Event handler called when the state of the switch changes.
    static member inline onCheckedChange (value: (bool -> unit)) = Feliz.Interop.mkAttr "onCheckedChange" value
    /// Event handler called when the state of the switch changes.
    static member inline disabled (value: bool) = Feliz.Interop.mkAttr "disabled" value
    /// When true, indicates that the user must check the switch before the owning form can be submitted.
    static member inline required (value: bool) = Feliz.Interop.mkAttr "required" value
    /// The name of the switch. Submitted with its owning form as part of a name/value pair.
    static member inline name (value: string) = Feliz.Interop.mkAttr "name" value
    /// The value given as data when submitted with a name.
    static member inline value (value: string) = Feliz.Interop.mkAttr "value" value




/// The thumb that is used to visually indicate whether the switch is on or off.
type [<Erase>] thumb =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value



