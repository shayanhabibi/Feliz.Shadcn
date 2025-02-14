namespace Feliz.RadixUI.Interface
// AUTOGENERATED FILE
open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn.Interop
open Browser.Types


/// Contains all the parts of an accordion.
[<RequireQualifiedAccess>]
module [<Erase>] accordionRoot =
    type [<Erase>] type'<'Property> =
        static member inline single : 'Property = Interop.mkProperty "type" "single"
        static member inline multiple : 'Property = Interop.mkProperty "type" "multiple"

    type [<Erase>] dir<'Property> =
        static member inline ltr : 'Property = Interop.mkProperty "dir" "ltr"
        static member inline rtl : 'Property = Interop.mkProperty "dir" "rtl"

    type [<Erase>] orientation<'Property> =
        static member inline horizontal : 'Property = Interop.mkProperty "orientation" "horizontal"
        static member inline vertical : 'Property = Interop.mkProperty "orientation" "vertical"

/// A vertically stacked set of interactive headings that each reveal an associated section of content.
[<RequireQualifiedAccess>]
module [<Erase>] Accordion =
    /// Contains all the parts of an accordion.
    type [<Erase>] root<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// Determines whether one or multiple items can be opened at the same time.
        static member inline value ( value : string ) : 'Property = Interop.mkProperty "value" value
        /// The value of the item to expand when initially rendered and type is "single". Use when you do not need to control the state of the items.
        static member inline defaultValue ( value : string ) : 'Property = Interop.mkProperty "defaultValue" value
        /// Event handler called when the expanded state of an item changes and type is "single".
        static member inline onValueChange ( value : (string -> unit) ) : 'Property = Interop.mkProperty "onValueChange" value
        /// Event handler called when the expanded state of an item changes and type is "single".
        static member inline value ( value : string[] ) : 'Property = Interop.mkProperty "value" value
        /// The value of the item to expand when initially rendered when type is "multiple". Use when you do not need to control the state of the items.
        static member inline defaultValue ( value : string[] ) : 'Property = Interop.mkProperty "defaultValue" value
        /// Event handler called when the expanded state of an item changes and type is "multiple".
        static member inline onValueChange ( value : (string[] -> unit) ) : 'Property = Interop.mkProperty "onValueChange" value
        /// Event handler called when the expanded state of an item changes and type is "multiple".
        static member inline collapsible ( value : bool ) : 'Property = Interop.mkProperty "collapsible" value
        /// When true, prevents the user from interacting with the accordion and all its items.
        static member inline disabled ( value : bool ) : 'Property = Interop.mkProperty "disabled" value

    /// Contains all the parts of a collapsible section.
    type [<Erase>] item<'Property> =
        inherit prop<'Property>
        /// The orientation of the accordion.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// When true, prevents the user from interacting with the item.
        static member inline disabled ( value : bool ) : 'Property = Interop.mkProperty "disabled" value
        /// A unique value for the item.
        static member inline value ( value : string ) : 'Property = Interop.mkProperty "value" value

    /// Wraps an Accordion.Trigger. Use the asChild prop to update it to the appropriate heading level for your page.
    type [<Erase>] header<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// Toggles the collapsed state of its associated item. It should be nested inside of an Accordion.Header.
    type [<Erase>] trigger<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// Contains the collapsible content for an item.
    type [<Erase>] content<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries.
        static member inline forceMount ( value : bool ) : 'Property = Interop.mkProperty "forceMount" value
