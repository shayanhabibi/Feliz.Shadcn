namespace rec Feliz.Shadcn.Toggle

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn
open Browser.Types


/// A two-state button that can be either on or off.
type [<Erase>] toggle =
    /// The toggle.
    static member inline root (props: IReactProperty seq) = createElement (import "Toggle" "@/components/ui/toggle") props


/// The toggle.
type [<Erase>] root =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// The pressed state of the toggle when it is initially rendered. Use when you do not need to control its pressed state.
    static member inline defaultPressed (value: bool) = Feliz.Interop.mkAttr "defaultPressed" value
    /// The controlled pressed state of the toggle. Must be used in conjunction with onPressedChange.
    static member inline pressed (value: bool) = Feliz.Interop.mkAttr "pressed" value
    /// Event handler called when the pressed state of the toggle changes.
    static member inline onPressedChange (value: (bool -> unit)) = Feliz.Interop.mkAttr "onPressedChange" value
    /// Event handler called when the pressed state of the toggle changes.
    static member inline disabled (value: bool) = Feliz.Interop.mkAttr "disabled" value



