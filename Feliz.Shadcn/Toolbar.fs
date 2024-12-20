namespace rec Feliz.Shadcn.Toolbar

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn
open Browser.Types


/// A container for grouping a set of controls, such as buttons, toggle groups or dropdown menus.
type [<Erase>] toolbar =
    /// Contains all the toolbar component parts.
    static member inline root (props: IReactProperty seq) = createElement (import "Toolbar" "@/components/ui/toolbar") props
    /// A button item.
    static member inline button (props: IReactProperty seq) = createElement (import "ToolbarButton" "@/components/ui/toolbar") props
    /// A link item.
    static member inline link (props: IReactProperty seq) = createElement (import "ToolbarLink" "@/components/ui/toolbar") props
    /// A set of two-state buttons that can be toggled on or off.
    static member inline toggleGroup (props: IReactProperty seq) = createElement (import "ToolbarToggleGroup" "@/components/ui/toolbar") props
    /// An item in the group.
    static member inline toggleItem (props: IReactProperty seq) = createElement (import "ToolbarToggleItem" "@/components/ui/toolbar") props
    /// Used to visually separate items in the toolbar.
    static member inline separator (props: IReactProperty seq) = createElement (import "ToolbarSeparator" "@/components/ui/toolbar") props


/// Contains all the toolbar component parts.
type [<Erase>] root =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// The reading direction of the toolbar. If omitted, inherits globally from DirectionProvider or assumes LTR (left-to-right) reading mode.
    static member inline loop (value: bool) = Feliz.Interop.mkAttr "loop" value


module root =

    type [<Erase>] orientation =
        static member inline horizontal = Feliz.Interop.mkAttr "orientation" "horizontal"
        static member inline vertical = Feliz.Interop.mkAttr "orientation" "vertical"
        static member inline undefined = Feliz.Interop.mkAttr "orientation" "undefined"

    type [<Erase>] dir =
        static member inline ltr = Feliz.Interop.mkAttr "dir" "ltr"
        static member inline rtl = Feliz.Interop.mkAttr "dir" "rtl"



/// A button item.
type [<Erase>] button =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// A link item.
type [<Erase>] link =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// A set of two-state buttons that can be toggled on or off.
type [<Erase>] toggleGroup =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// Determines whether a single or multiple items can be pressed at a time.
    static member inline value (value: string) = Feliz.Interop.mkAttr "value" value
    /// The value of the item to show as pressed when initially rendered and type is "single". Use when you do not need to control the state of the items.
    static member inline defaultValue (value: string) = Feliz.Interop.mkAttr "defaultValue" value
    /// Event handler called when the pressed state of an item changes and type is "single".
    static member inline onValueChange (value: (string -> unit)) = Feliz.Interop.mkAttr "onValueChange" value
    /// Event handler called when the pressed state of an item changes and type is "single".
    static member inline value (value: string[]) = Feliz.Interop.mkAttr "value" value
    /// The values of the items to show as pressed when initially rendered and type is "multiple". Use when you do not need to control the state of the items.
    static member inline defaultValue (value: string[]) = Feliz.Interop.mkAttr "defaultValue" value
    /// Event handler called when the pressed state of an item changes and type is "multiple".
    static member inline onValueChange (value: (string[] -> unit)) = Feliz.Interop.mkAttr "onValueChange" value
    /// Event handler called when the pressed state of an item changes and type is "multiple".
    static member inline disabled (value: bool) = Feliz.Interop.mkAttr "disabled" value


module toggleGroup =

    type [<Erase>] type' =
        static member inline single = Feliz.Interop.mkAttr "type" "single"
        static member inline multiple = Feliz.Interop.mkAttr "type" "multiple"



/// An item in the group.
type [<Erase>] toggleItem =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// A unique value for the item.
    static member inline value (value: string) = Feliz.Interop.mkAttr "value" value
    /// When true, prevents the user from interacting with the item.
    static member inline disabled (value: bool) = Feliz.Interop.mkAttr "disabled" value




/// Used to visually separate items in the toolbar.
type [<Erase>] separator =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value



