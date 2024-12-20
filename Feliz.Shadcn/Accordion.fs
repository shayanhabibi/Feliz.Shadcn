namespace rec Feliz.Shadcn.Accordion

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn
open Browser.Types


/// A vertically stacked set of interactive headings that each reveal an associated section of content.
type [<Erase>] accordion =
    /// Contains all the parts of an accordion.
    static member inline root (props: IReactProperty seq) = createElement (import "Accordion" "@/components/ui/accordion") props
    /// Contains all the parts of a collapsible section.
    static member inline item (props: IReactProperty seq) = createElement (import "AccordionItem" "@/components/ui/accordion") props
    /// Wraps an Accordion.Trigger. Use the asChild prop to update it to the appropriate heading level for your page.
    static member inline header (props: IReactProperty seq) = createElement (import "AccordionHeader" "@/components/ui/accordion") props
    /// Toggles the collapsed state of its associated item. It should be nested inside of an Accordion.Header.
    static member inline trigger (props: IReactProperty seq) = createElement (import "AccordionTrigger" "@/components/ui/accordion") props
    /// Contains the collapsible content for an item.
    static member inline content (props: IReactProperty seq) = createElement (import "AccordionContent" "@/components/ui/accordion") props


/// Contains all the parts of an accordion.
type [<Erase>] root =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// Determines whether one or multiple items can be opened at the same time.
    static member inline value (value: string) = Feliz.Interop.mkAttr "value" value
    /// The value of the item to expand when initially rendered and type is "single". Use when you do not need to control the state of the items.
    static member inline defaultValue (value: string) = Feliz.Interop.mkAttr "defaultValue" value
    /// Event handler called when the expanded state of an item changes and type is "single".
    static member inline onValueChange (value: (string -> unit)) = Feliz.Interop.mkAttr "onValueChange" value
    /// Event handler called when the expanded state of an item changes and type is "single".
    static member inline value (value: string[]) = Feliz.Interop.mkAttr "value" value
    /// The value of the item to expand when initially rendered when type is "multiple". Use when you do not need to control the state of the items.
    static member inline defaultValue (value: string[]) = Feliz.Interop.mkAttr "defaultValue" value
    /// Event handler called when the expanded state of an item changes and type is "multiple".
    static member inline onValueChange (value: (string[] -> unit)) = Feliz.Interop.mkAttr "onValueChange" value
    /// Event handler called when the expanded state of an item changes and type is "multiple".
    static member inline collapsible (value: bool) = Feliz.Interop.mkAttr "collapsible" value
    /// When true, prevents the user from interacting with the accordion and all its items.
    static member inline disabled (value: bool) = Feliz.Interop.mkAttr "disabled" value


module root =

    type [<Erase>] type' =
        static member inline single = Feliz.Interop.mkAttr "type" "single"
        static member inline multiple = Feliz.Interop.mkAttr "type" "multiple"

    type [<Erase>] dir =
        static member inline ltr = Feliz.Interop.mkAttr "dir" "ltr"
        static member inline rtl = Feliz.Interop.mkAttr "dir" "rtl"

    type [<Erase>] orientation =
        static member inline horizontal = Feliz.Interop.mkAttr "orientation" "horizontal"
        static member inline vertical = Feliz.Interop.mkAttr "orientation" "vertical"



/// Contains all the parts of a collapsible section.
type [<Erase>] item =
    /// The orientation of the accordion.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// When true, prevents the user from interacting with the item.
    static member inline disabled (value: bool) = Feliz.Interop.mkAttr "disabled" value
    /// A unique value for the item.
    static member inline value (value: string) = Feliz.Interop.mkAttr "value" value




/// Wraps an Accordion.Trigger. Use the asChild prop to update it to the appropriate heading level for your page.
type [<Erase>] header =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// Toggles the collapsed state of its associated item. It should be nested inside of an Accordion.Header.
type [<Erase>] trigger =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// Contains the collapsible content for an item.
type [<Erase>] content =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value



