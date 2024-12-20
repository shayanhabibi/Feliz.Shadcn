namespace rec Feliz.Shadcn.Collapsible

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn
open Browser.Types


/// An interactive component which expands/collapses a panel.
type [<Erase>] collapsible =
    /// Contains all the parts of a collapsible.
    static member inline root (props: IReactProperty seq) = createElement (import "Collapsible" "@/components/ui/collapsible") props
    /// The button that toggles the collapsible.
    static member inline trigger (props: IReactProperty seq) = createElement (import "CollapsibleTrigger" "@/components/ui/collapsible") props
    /// The component that contains the collapsible content.
    static member inline content (props: IReactProperty seq) = createElement (import "CollapsibleContent" "@/components/ui/collapsible") props


/// Contains all the parts of a collapsible.
type [<Erase>] root =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// The open state of the collapsible when it is initially rendered. Use when you do not need to control its open state.
    static member inline defaultOpen (value: bool) = Feliz.Interop.mkAttr "defaultOpen" value
    /// The controlled open state of the collapsible. Must be used in conjunction with onOpenChange.
    static member inline open' (value: bool) = Feliz.Interop.mkAttr "open" value
    /// Event handler called when the open state of the collapsible changes.
    static member inline onOpenChange (value: (bool -> unit)) = Feliz.Interop.mkAttr "onOpenChange" value
    /// Event handler called when the open state of the collapsible changes.
    static member inline disabled (value: bool) = Feliz.Interop.mkAttr "disabled" value




/// The button that toggles the collapsible.
type [<Erase>] trigger =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// The component that contains the collapsible content.
type [<Erase>] content =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value



