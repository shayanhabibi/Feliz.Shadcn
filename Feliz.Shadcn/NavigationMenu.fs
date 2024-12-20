namespace rec Feliz.Shadcn.NavigationMenu

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn
open Browser.Types


/// A collection of links for navigating websites.
type [<Erase>] navigationMenu =
    /// Contains all the parts of a navigation menu.
    static member inline root (props: IReactProperty seq) = createElement (import "NavigationMenu" "@/components/ui/navigation-menu") props
    /// Signifies a submenu. Use it in place of the root part when nested to create a submenu.
    static member inline sub (props: IReactProperty seq) = createElement (import "NavigationMenuSub" "@/components/ui/navigation-menu") props
    /// Contains the top level menu items.
    static member inline list' (props: IReactProperty seq) = createElement (import "NavigationMenuList" "@/components/ui/navigation-menu") props
    /// A top level menu item, contains a link or trigger with content combination.
    static member inline item (props: IReactProperty seq) = createElement (import "NavigationMenuItem" "@/components/ui/navigation-menu") props
    /// The button that toggles the content.
    static member inline trigger (props: IReactProperty seq) = createElement (import "NavigationMenuTrigger" "@/components/ui/navigation-menu") props
    /// Contains the content associated with each trigger.
    static member inline content (props: IReactProperty seq) = createElement (import "NavigationMenuContent" "@/components/ui/navigation-menu") props
    /// A navigational link.
    static member inline link (props: IReactProperty seq) = createElement (import "NavigationMenuLink" "@/components/ui/navigation-menu") props
    /// An optional indicator element that renders below the list, is used to highlight the currently active trigger.
    static member inline indicator (props: IReactProperty seq) = createElement (import "NavigationMenuIndicator" "@/components/ui/navigation-menu") props
    /// An optional viewport element that is used to render active content outside of the list.
    static member inline viewport (props: IReactProperty seq) = createElement (import "NavigationMenuViewport" "@/components/ui/navigation-menu") props


/// Contains all the parts of a navigation menu.
type [<Erase>] root =
    /// The value of the menu item that should be active when initially rendered. Use when you do not need to control the value state.
    static member inline defaultValue (value: string) = Feliz.Interop.mkAttr "defaultValue" value
    /// The controlled value of the menu item to activate. Should be used in conjunction with onValueChange.
    static member inline value (value: string) = Feliz.Interop.mkAttr "value" value
    /// Event handler called when the value changes.
    static member inline onValueChange (value: (string -> unit)) = Feliz.Interop.mkAttr "onValueChange" value
    /// Event handler called when the value changes.
    static member inline delayDuration (value: int) = Feliz.Interop.mkAttr "delayDuration" value
    /// How much time a user has to enter another trigger without incurring a delay again.
    static member inline skipDelayDuration (value: int) = Feliz.Interop.mkAttr "skipDelayDuration" value


module root =

    type [<Erase>] dir =
        static member inline ltr = Feliz.Interop.mkAttr "dir" "ltr"
        static member inline rtl = Feliz.Interop.mkAttr "dir" "rtl"

    type [<Erase>] orientation =
        static member inline horizontal = Feliz.Interop.mkAttr "orientation" "horizontal"
        static member inline vertical = Feliz.Interop.mkAttr "orientation" "vertical"



/// Signifies a submenu. Use it in place of the root part when nested to create a submenu.
type [<Erase>] sub =
    /// The orientation of the menu.
    static member inline defaultValue (value: string) = Feliz.Interop.mkAttr "defaultValue" value
    /// The controlled value of the sub menu item to activate. Should be used in conjunction with onValueChange.
    static member inline value (value: string) = Feliz.Interop.mkAttr "value" value
    /// Event handler called when the value changes.
    static member inline onValueChange (value: (string -> unit)) = Feliz.Interop.mkAttr "onValueChange" value


module sub =

    type [<Erase>] orientation =
        static member inline horizontal = Feliz.Interop.mkAttr "orientation" "horizontal"
        static member inline vertical = Feliz.Interop.mkAttr "orientation" "vertical"



/// Contains the top level menu items.
type [<Erase>] list' =
    /// The orientation of the menu.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// A top level menu item, contains a link or trigger with content combination.
type [<Erase>] item =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// A unique value that associates the item with an active value when the navigation menu is controlled. This prop is managed automatically when uncontrolled.
    static member inline value (value: string) = Feliz.Interop.mkAttr "value" value




/// The button that toggles the content.
type [<Erase>] trigger =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// Contains the content associated with each trigger.
type [<Erase>] content =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// When true, hover/focus/click interactions will be disabled on elements outside the bounds of the component. Users will need to click twice on outside elements to interact with them: Once to close the navigation menu, and again to activate the element.
    static member inline disableOutsidePointerEvents (value: bool) = Feliz.Interop.mkAttr "disableOutsidePointerEvents" value
    /// Event handler called when the escape key is down. It can be prevented by calling event.preventDefault.
    static member inline onEscapeKeyDown (value: (Browser.Types.KeyboardEvent -> unit)) = Feliz.Interop.mkAttr "onEscapeKeyDown" value
    /// Event handler called when the escape key is down. It can be prevented by calling event.preventDefault.
    static member inline onPointerDownOutside (value: (PointerDownOutsideEvent -> unit)) = Feliz.Interop.mkAttr "onPointerDownOutside" value
    /// Event handler called when a pointer event occurs outside the bounds of the component. It can be prevented by calling event.preventDefault.
    static member inline onFocusOutside (value: (FocusOutsideEvent -> unit)) = Feliz.Interop.mkAttr "onFocusOutside" value
    /// Event handler called when focus moves outside the bounds of the component. It can be prevented by calling event.preventDefault.
    static member inline onInteractOutside (value: (Browser.Types.FocusEvent -> unit)) = Feliz.Interop.mkAttr "onInteractOutside" value
    /// Event handler called when focus moves outside the bounds of the component. It can be prevented by calling event.preventDefault.
    static member inline onInteractOutside (value: (Browser.Types.MouseEvent -> unit)) = Feliz.Interop.mkAttr "onInteractOutside" value
    /// Event handler called when focus moves outside the bounds of the component. It can be prevented by calling event.preventDefault.
    static member inline onInteractOutside (value: (Browser.Types.TouchEvent -> unit)) = Feliz.Interop.mkAttr "onInteractOutside" value
    /// Event handler called when an interaction (pointer or focus event) happens outside the bounds of the component. It can be prevented by calling event.preventDefault.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value




/// A navigational link.
type [<Erase>] link =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// Used to identify the link as the currently active page.
    static member inline active (value: bool) = Feliz.Interop.mkAttr "active" value
    /// Event handler called when the user selects a link (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the navigation menu from closing when selecting that link.
    static member inline onSelect (value: (Browser.Types.Event -> unit)) = Feliz.Interop.mkAttr "onSelect" value




/// An optional indicator element that renders below the list, is used to highlight the currently active trigger.
type [<Erase>] indicator =
    /// Event handler called when the user selects a link (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the navigation menu from closing when selecting that link.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value




/// An optional viewport element that is used to render active content outside of the list.
type [<Erase>] viewport =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value



