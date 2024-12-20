namespace rec Feliz.Shadcn.ScrollArea

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn
open Browser.Types


/// Augments native scroll functionality for custom, cross-browser styling.
type [<Erase>] scrollArea =
    /// Contains all the parts of a scroll area.
    static member inline root (props: IReactProperty seq) = createElement (import "ScrollArea" "@/components/ui/scroll-area") props
    /// The viewport area of the scroll area.
    static member inline viewport (props: IReactProperty seq) = createElement (import "ScrollAreaViewport" "@/components/ui/scroll-area") props
    /// The vertical scrollbar. Add a second Scrollbar with an orientation prop to enable horizontal scrolling.
    static member inline scrollbar (props: IReactProperty seq) = createElement (import "ScrollAreaScrollbar" "@/components/ui/scroll-area") props
    /// The thumb to be used in ScrollArea.Scrollbar.
    static member inline thumb (props: IReactProperty seq) = createElement (import "ScrollAreaThumb" "@/components/ui/scroll-area") props
    /// The corner where both vertical and horizontal scrollbars meet.
    static member inline corner (props: IReactProperty seq) = createElement (import "ScrollAreaCorner" "@/components/ui/scroll-area") props


/// Contains all the parts of a scroll area.
type [<Erase>] root =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// Describes the nature of scrollbar visibility, similar to how the scrollbar preferences in MacOS control visibility of native scrollbars.  "auto" means that scrollbars are visible when content is overflowing on the corresponding orientation. "always" means that scrollbars are always visible regardless of whether the content is overflowing. "scroll" means that scrollbars are visible when the user is scrolling along its corresponding orientation. "hover" when the user is scrolling along its corresponding orientation and when the user is hovering over the scroll area.
    static member inline scrollHideDelay (value: int) = Feliz.Interop.mkAttr "scrollHideDelay" value


module root =

    type [<Erase>] type' =
        static member inline auto = Feliz.Interop.mkAttr "type" "auto"
        static member inline always = Feliz.Interop.mkAttr "type" "always"
        static member inline scroll = Feliz.Interop.mkAttr "type" "scroll"
        static member inline hover = Feliz.Interop.mkAttr "type" "hover"

    type [<Erase>] dir =
        static member inline ltr = Feliz.Interop.mkAttr "dir" "ltr"
        static member inline rtl = Feliz.Interop.mkAttr "dir" "rtl"



/// The viewport area of the scroll area.
type [<Erase>] viewport =
    /// The reading direction of the scroll area. If omitted, inherits globally from DirectionProvider or assumes LTR (left-to-right) reading mode.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// The vertical scrollbar. Add a second Scrollbar with an orientation prop to enable horizontal scrolling.
type [<Erase>] scrollbar =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value


module scrollbar =

    type [<Erase>] orientation =
        static member inline horizontal = Feliz.Interop.mkAttr "orientation" "horizontal"
        static member inline vertical = Feliz.Interop.mkAttr "orientation" "vertical"



/// The thumb to be used in ScrollArea.Scrollbar.
type [<Erase>] thumb =
    /// The orientation of the scrollbar
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// The corner where both vertical and horizontal scrollbars meet.
type [<Erase>] corner =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value



