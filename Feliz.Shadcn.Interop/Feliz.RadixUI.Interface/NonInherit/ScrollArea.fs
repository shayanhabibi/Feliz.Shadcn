namespace Feliz.RadixUI.Interface.NoInherit
// AUTOGENERATED FILE - these files do not inherit feliz properties at base
open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn.Interop
open Browser.Types


/// Contains all the parts of a scroll area.
[<RequireQualifiedAccess>]
module [<Erase>] scrollAreaRoot =
    type [<Erase>] type'<'Property> =
        static member inline auto : 'Property = Interop.mkProperty "type" "auto"
        static member inline always : 'Property = Interop.mkProperty "type" "always"
        static member inline scroll : 'Property = Interop.mkProperty "type" "scroll"
        static member inline hover : 'Property = Interop.mkProperty "type" "hover"

    type [<Erase>] dir<'Property> =
        static member inline ltr : 'Property = Interop.mkProperty "dir" "ltr"
        static member inline rtl : 'Property = Interop.mkProperty "dir" "rtl"

/// The vertical scrollbar. Add a second Scrollbar with an orientation prop to enable horizontal scrolling.
[<RequireQualifiedAccess>]
module [<Erase>] scrollAreaScrollbar =
    type [<Erase>] orientation<'Property> =
        static member inline horizontal : 'Property = Interop.mkProperty "orientation" "horizontal"
        static member inline vertical : 'Property = Interop.mkProperty "orientation" "vertical"

/// Augments native scroll functionality for custom, cross-browser styling.
[<RequireQualifiedAccess>]
module [<Erase>] ScrollArea =
    /// Contains all the parts of a scroll area.
    type [<Erase>] root<'Property> =
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// Describes the nature of scrollbar visibility, similar to how the scrollbar preferences in MacOS control visibility of native scrollbars.
        ///  
        ///  "auto" means that scrollbars are visible when content is overflowing on the corresponding orientation.
        ///  "always" means that scrollbars are always visible regardless of whether the content is overflowing.
        ///  "scroll" means that scrollbars are visible when the user is scrolling along its corresponding orientation.
        ///  "hover" when the user is scrolling along its corresponding orientation and when the user is hovering over the scroll area.
        static member inline scrollHideDelay ( value : int ) : 'Property = Interop.mkProperty "scrollHideDelay" value
        /// The reading direction of the scroll area. If omitted, inherits globally from DirectionProvider or assumes LTR (left-to-right) reading mode.
        static member inline nonce ( value : string ) : 'Property = Interop.mkProperty "nonce" value

    /// The viewport area of the scroll area.
    type [<Erase>] viewport<'Property> =
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// The vertical scrollbar. Add a second Scrollbar with an orientation prop to enable horizontal scrolling.
    type [<Erase>] scrollbar<'Property> =
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries.
        static member inline forceMount ( value : bool ) : 'Property = Interop.mkProperty "forceMount" value

    /// The thumb to be used in ScrollArea.Scrollbar.
    type [<Erase>] thumb<'Property> =
        /// The orientation of the scrollbar
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// The corner where both vertical and horizontal scrollbars meet.
    type [<Erase>] corner<'Property> =
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
