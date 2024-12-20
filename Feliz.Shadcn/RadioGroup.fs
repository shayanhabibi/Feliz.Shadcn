namespace rec Feliz.Shadcn.RadioGroup

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn
open Browser.Types


/// A set of checkable buttons—known as radio buttons—where no more than one of the buttons can be checked at a time.
type [<Erase>] radioGroup =
    /// Contains all the parts of a radio group.
    static member inline root (props: IReactProperty seq) = createElement (import "RadioGroup" "@/components/ui/radio-group") props
    /// An item in the group that can be checked. An input will also render when used within a form to ensure events propagate correctly.
    static member inline item (props: IReactProperty seq) = createElement (import "RadioGroupItem" "@/components/ui/radio-group") props
    /// Renders when the radio item is in a checked state. You can style this element directly, or you can use it as a wrapper to put an icon into, or both.
    static member inline indicator (props: IReactProperty seq) = createElement (import "RadioGroupIndicator" "@/components/ui/radio-group") props


/// Contains all the parts of a radio group.
type [<Erase>] root =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// The value of the radio item that should be checked when initially rendered. Use when you do not need to control the state of the radio items.
    static member inline defaultValue (value: string) = Feliz.Interop.mkAttr "defaultValue" value
    /// The controlled value of the radio item to check. Should be used in conjunction with onValueChange.
    static member inline value (value: string) = Feliz.Interop.mkAttr "value" value
    /// Event handler called when the value changes.
    static member inline onValueChange (value: (string -> unit)) = Feliz.Interop.mkAttr "onValueChange" value
    /// Event handler called when the value changes.
    static member inline disabled (value: bool) = Feliz.Interop.mkAttr "disabled" value
    /// The name of the group. Submitted with its owning form as part of a name/value pair.
    static member inline name (value: string) = Feliz.Interop.mkAttr "name" value
    /// When true, indicates that the user must check a radio item before the owning form can be submitted.
    static member inline required (value: bool) = Feliz.Interop.mkAttr "required" value
    /// The reading direction of the radio group. If omitted, inherits globally from DirectionProvider or assumes LTR (left-to-right) reading mode.
    static member inline loop (value: bool) = Feliz.Interop.mkAttr "loop" value


module root =

    type [<Erase>] orientation =
        static member inline horizontal = Feliz.Interop.mkAttr "orientation" "horizontal"
        static member inline vertical = Feliz.Interop.mkAttr "orientation" "vertical"
        static member inline undefined = Feliz.Interop.mkAttr "orientation" "undefined"

    type [<Erase>] dir =
        static member inline ltr = Feliz.Interop.mkAttr "dir" "ltr"
        static member inline rtl = Feliz.Interop.mkAttr "dir" "rtl"



/// An item in the group that can be checked. An input will also render when used within a form to ensure events propagate correctly.
type [<Erase>] item =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// The value given as data when submitted with a name.
    static member inline value (value: string) = Feliz.Interop.mkAttr "value" value
    /// When true, prevents the user from interacting with the radio item.
    static member inline disabled (value: bool) = Feliz.Interop.mkAttr "disabled" value
    /// When true, indicates that the user must check the radio item before the owning form can be submitted.
    static member inline required (value: bool) = Feliz.Interop.mkAttr "required" value




/// Renders when the radio item is in a checked state. You can style this element directly, or you can use it as a wrapper to put an icon into, or both.
type [<Erase>] indicator =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value



