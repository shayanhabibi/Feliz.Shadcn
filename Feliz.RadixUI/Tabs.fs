namespace Feliz.RadixUI

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Interop.Extend
open Browser.Types


/// A set of layered sections of content—known as tab panels—that are displayed one at a time.
module [<Erase>] Tabs =
    /// import "Tabs" ""
    /// Contains all the tabs component parts.
    type [<Erase>] root<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// The value of the tab that should be active when initially rendered. Use when you do not need to control the state of the tabs.
        static member inline defaultValue ( value : string ) : 'Property = Interop.mkProperty "defaultValue" value
        /// The controlled value of the tab to activate. Should be used in conjunction with onValueChange.
        static member inline value ( value : string ) : 'Property = Interop.mkProperty "value" value
        /// Event handler called when the value changes.
        static member inline onValueChange ( value : (string -> unit) ) : 'Property = Interop.mkProperty "onValueChange" value

    /// import "TabsList" ""
    /// Contains the triggers that are aligned along the edge of the active content.
    type [<Erase>] list'<'Property> =
        inherit prop<'Property>
        /// When automatic, tabs are activated when receiving focus. When manual, tabs are activated when clicked.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// When true, keyboard navigation will loop from last tab to first, and vice versa.
        static member inline loop ( value : bool ) : 'Property = Interop.mkProperty "loop" value

    /// import "TabsTrigger" ""
    /// The button that activates its associated content.
    type [<Erase>] trigger<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// A unique value that associates the trigger with a content.
        static member inline value ( value : string ) : 'Property = Interop.mkProperty "value" value
        /// When true, prevents the user from interacting with the tab.
        static member inline disabled ( value : bool ) : 'Property = Interop.mkProperty "disabled" value

    /// import "TabsContent" ""
    /// Contains the content associated with each trigger.
    type [<Erase>] content<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// A unique value that associates the content with a trigger.
        static member inline value ( value : string ) : 'Property = Interop.mkProperty "value" value
        /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries.
        static member inline forceMount ( value : bool ) : 'Property = Interop.mkProperty "forceMount" value

module [<Erase>] tabsroot =
    type [<Erase>] orientation<'Property> =
        static member inline horizontal : 'Property = Interop.mkProperty "orientation" "horizontal"
        static member inline vertical : 'Property = Interop.mkProperty "orientation" "vertical"
        static member inline undefined : 'Property = Interop.mkProperty "orientation" "undefined"

    type [<Erase>] dir<'Property> =
        static member inline ltr : 'Property = Interop.mkProperty "dir" "ltr"
        static member inline rtl : 'Property = Interop.mkProperty "dir" "rtl"

    type [<Erase>] activationMode<'Property> =
        static member inline automatic : 'Property = Interop.mkProperty "activationMode" "automatic"
        static member inline manual : 'Property = Interop.mkProperty "activationMode" "manual"
