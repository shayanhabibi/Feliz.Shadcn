namespace rec Feliz.Shadcn.Tabs

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn
open Browser.Types


/// A set of layered sections of content—known as tab panels—that are displayed one at a time.
type [<Erase>] tabs =
    /// Contains all the tabs component parts.
    static member inline root (props: IReactProperty seq) = createElement (import "Tabs" "@/components/ui/tabs") props
    /// Contains the triggers that are aligned along the edge of the active content.
    static member inline list' (props: IReactProperty seq) = createElement (import "TabsList" "@/components/ui/tabs") props
    /// The button that activates its associated content.
    static member inline trigger (props: IReactProperty seq) = createElement (import "TabsTrigger" "@/components/ui/tabs") props
    /// Contains the content associated with each trigger.
    static member inline content (props: IReactProperty seq) = createElement (import "TabsContent" "@/components/ui/tabs") props


/// Contains all the tabs component parts.
type [<Erase>] root =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// The value of the tab that should be active when initially rendered. Use when you do not need to control the state of the tabs.
    static member inline defaultValue (value: string) = Feliz.Interop.mkAttr "defaultValue" value
    /// The controlled value of the tab to activate. Should be used in conjunction with onValueChange.
    static member inline value (value: string) = Feliz.Interop.mkAttr "value" value
    /// Event handler called when the value changes.
    static member inline onValueChange (value: (string -> unit)) = Feliz.Interop.mkAttr "onValueChange" value


module root =

    type [<Erase>] orientation =
        static member inline horizontal = Feliz.Interop.mkAttr "orientation" "horizontal"
        static member inline vertical = Feliz.Interop.mkAttr "orientation" "vertical"
        static member inline undefined = Feliz.Interop.mkAttr "orientation" "undefined"

    type [<Erase>] dir =
        static member inline ltr = Feliz.Interop.mkAttr "dir" "ltr"
        static member inline rtl = Feliz.Interop.mkAttr "dir" "rtl"

    type [<Erase>] activationMode =
        static member inline automatic = Feliz.Interop.mkAttr "activationMode" "automatic"
        static member inline manual = Feliz.Interop.mkAttr "activationMode" "manual"



/// Contains the triggers that are aligned along the edge of the active content.
type [<Erase>] list' =
    /// When automatic, tabs are activated when receiving focus. When manual, tabs are activated when clicked.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// When true, keyboard navigation will loop from last tab to first, and vice versa.
    static member inline loop (value: bool) = Feliz.Interop.mkAttr "loop" value




/// The button that activates its associated content.
type [<Erase>] trigger =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// A unique value that associates the trigger with a content.
    static member inline value (value: string) = Feliz.Interop.mkAttr "value" value
    /// When true, prevents the user from interacting with the tab.
    static member inline disabled (value: bool) = Feliz.Interop.mkAttr "disabled" value




/// Contains the content associated with each trigger.
type [<Erase>] content =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// A unique value that associates the content with a trigger.
    static member inline value (value: string) = Feliz.Interop.mkAttr "value" value
    /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value



