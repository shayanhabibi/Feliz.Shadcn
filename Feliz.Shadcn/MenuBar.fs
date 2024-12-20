namespace rec Feliz.Shadcn.MenuBar

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn
open Browser.Types


/// A visually persistent menu common in desktop applications that provides quick access to a consistent set of commands.
type [<Erase>] menuBar =
    /// Contains all the parts of a menubar.
    static member inline root (props: IReactProperty seq) = createElement (import "MenuBar" "@/components/ui/menubar") props
    /// A top level menu item, contains a trigger with content combination.
    static member inline menu (props: IReactProperty seq) = createElement (import "MenuBarMenu" "@/components/ui/menubar") props
    /// The button that toggles the content. By default, the Menubar.Content will position itself against the trigger.
    static member inline trigger (props: IReactProperty seq) = createElement (import "MenuBarTrigger" "@/components/ui/menubar") props
    /// When used, portals the content part into the body.
    static member inline portal (props: IReactProperty seq) = createElement (import "MenuBarPortal" "@/components/ui/menubar") props
    /// The component that pops out when a menu is open.
    static member inline content (props: IReactProperty seq) = createElement (import "MenuBarContent" "@/components/ui/menubar") props
    /// An optional arrow element to render alongside a menubar menu. This can be used to help visually link the trigger with the Menubar.Content. Must be rendered inside Menubar.Content.
    static member inline arrow (props: IReactProperty seq) = createElement (import "MenuBarArrow" "@/components/ui/menubar") props
    /// The component that contains the menubar items.
    static member inline item (props: IReactProperty seq) = createElement (import "MenuBarItem" "@/components/ui/menubar") props
    /// Used to group multiple Menubar.Items.
    static member inline group (props: IReactProperty seq) = createElement (import "MenuBarGroup" "@/components/ui/menubar") props
    /// Used to render a label. It won't be focusable using arrow keys.
    static member inline label (props: IReactProperty seq) = createElement (import "MenuBarLabel" "@/components/ui/menubar") props
    /// An item that can be controlled and rendered like a checkbox.
    static member inline checkboxItem (props: IReactProperty seq) = createElement (import "MenuBarCheckboxItem" "@/components/ui/menubar") props
    /// Used to group multiple Menubar.RadioItems.
    static member inline radioGroup (props: IReactProperty seq) = createElement (import "MenuBarRadioGroup" "@/components/ui/menubar") props
    /// An item that can be controlled and rendered like a radio.
    static member inline radioItem (props: IReactProperty seq) = createElement (import "MenuBarRadioItem" "@/components/ui/menubar") props
    /// Renders when the parent Menubar.CheckboxItem or Menubar.RadioItem is checked. You can style this element directly, or you can use it as a wrapper to put an icon into, or both.
    static member inline itemIndicator (props: IReactProperty seq) = createElement (import "MenuBarItemIndicator" "@/components/ui/menubar") props
    /// Used to visually separate items in a menubar menu.
    static member inline separator (props: IReactProperty seq) = createElement (import "MenuBarSeparator" "@/components/ui/menubar") props
    /// Contains all the parts of a submenu.
    static member inline sub (props: IReactProperty seq) = createElement (import "MenuBarSub" "@/components/ui/menubar") props
    /// An item that opens a submenu. Must be rendered inside Menubar.Sub.
    static member inline subTrigger (props: IReactProperty seq) = createElement (import "MenuBarSubTrigger" "@/components/ui/menubar") props
    /// The component that pops out when a submenu is open. Must be rendered inside Menubar.Sub.
    static member inline subContent (props: IReactProperty seq) = createElement (import "MenuBarSubContent" "@/components/ui/menubar") props


/// Contains all the parts of a menubar.
type [<Erase>] root =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// The value of the menu that should be open when initially rendered. Use when you do not need to control the value state.
    static member inline defaultValue (value: string) = Feliz.Interop.mkAttr "defaultValue" value
    /// The controlled value of the menu to open. Should be used in conjunction with onValueChange.
    static member inline value (value: string) = Feliz.Interop.mkAttr "value" value
    /// Event handler called when the value changes.
    static member inline onValueChange (value: (string -> unit)) = Feliz.Interop.mkAttr "onValueChange" value
    /// The reading direction. If omitted, inherits globally from DirectionProvider or assumes LTR (left-to-right) reading mode.
    static member inline loop (value: bool) = Feliz.Interop.mkAttr "loop" value


module root =

    type [<Erase>] dir =
        static member inline ltr = Feliz.Interop.mkAttr "dir" "ltr"
        static member inline rtl = Feliz.Interop.mkAttr "dir" "rtl"



/// A top level menu item, contains a trigger with content combination.
type [<Erase>] menu =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// A unique value that associates the item with an active value when the navigation menu is controlled. This prop is managed automatically when uncontrolled.
    static member inline value (value: string) = Feliz.Interop.mkAttr "value" value




/// The button that toggles the content. By default, the Menubar.Content will position itself against the trigger.
type [<Erase>] trigger =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// When used, portals the content part into the body.
type [<Erase>] portal =
    /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries. If used on this part, it will be inherited by Menubar.Content and Menubar.SubContent respectively.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value
    /// Specify a container element to portal the content into.
    static member inline container (value: HTMLElement) = Feliz.Interop.mkAttr "container" value




/// The component that pops out when a menu is open.
type [<Erase>] content =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// When true, keyboard navigation will loop from last item to first, and vice versa.
    static member inline loop (value: bool) = Feliz.Interop.mkAttr "loop" value
    /// Event handler called when focus moves to the trigger after closing. It can be prevented by calling event.preventDefault.
    static member inline onCloseAutoFocus (value: (Browser.Types.Event -> unit)) = Feliz.Interop.mkAttr "onCloseAutoFocus" value
    /// Event handler called when focus moves to the trigger after closing. It can be prevented by calling event.preventDefault.
    static member inline onEscapeKeyDown (value: (Browser.Types.KeyboardEvent -> unit)) = Feliz.Interop.mkAttr "onEscapeKeyDown" value
    /// Event handler called when the escape key is down. It can be prevented by calling event.preventDefault
    static member inline onPointerDownOutside (value: (PointerDownOutsideEvent -> unit)) = Feliz.Interop.mkAttr "onPointerDownOutside" value
    /// Event handler called when a pointer event occurs outside the bounds of the component. It can be prevented by calling event.preventDefault.
    static member inline onFocusOutside (value: (FocusOutsideEvent -> unit)) = Feliz.Interop.mkAttr "onFocusOutside" value
    /// Event handler called when focus moves outside the bounds of the component. It can be prevented by calling event.preventDefault.
    static member inline onInteractOutside (value: (PointerDownOutsideEvent -> unit)) = Feliz.Interop.mkAttr "onInteractOutside" value
    /// Event handler called when focus moves outside the bounds of the component. It can be prevented by calling event.preventDefault.
    static member inline onInteractOutside (value: (FocusOutsideEvent -> unit)) = Feliz.Interop.mkAttr "onInteractOutside" value
    /// Event handler called when an interaction (pointer or focus event) happens outside the bounds of the component. It can be prevented by calling event.preventDefault.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value
    /// The preferred side of the trigger to render against when open. Will be reversed when collisions occur and avoidCollisions is enabled.
    static member inline sideOffset (value: int) = Feliz.Interop.mkAttr "sideOffset" value
    /// The preferred alignment against the trigger. May change when collisions occur.
    static member inline alignOffset (value: int) = Feliz.Interop.mkAttr "alignOffset" value
    /// When true, overrides the side andalign preferences to prevent collisions with boundary edges.
    static member inline avoidCollisions (value: bool) = Feliz.Interop.mkAttr "avoidCollisions" value
    /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check.
    static member inline collisionBoundary (value: ReactElement) = Feliz.Interop.mkAttr "collisionBoundary" value
    /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check.
    static member inline collisionBoundary (value: ReactElement[]) = Feliz.Interop.mkAttr "collisionBoundary" value
    /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check.
    static member inline collisionPadding (value: int) = Feliz.Interop.mkAttr "collisionPadding" value
    /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check.
    static member inline collisionPadding (value: 'T) = Feliz.Interop.mkAttr "collisionPadding" value
    /// The distance in pixels from the boundary edges where collision detection should occur. Accepts a number (same for all sides), or a partial padding object, for example: { top: 20, left: 20 }.
    static member inline arrowPadding (value: int) = Feliz.Interop.mkAttr "arrowPadding" value
    /// The sticky behavior on the align axis. "partial" will keep the content in the boundary as long as the trigger is at least partially in the boundary whilst "always" will keep the content in the boundary regardless.
    static member inline hideWhenDetached (value: bool) = Feliz.Interop.mkAttr "hideWhenDetached" value


module content =

    type [<Erase>] side =
        static member inline top = Feliz.Interop.mkAttr "side" "top"
        static member inline right = Feliz.Interop.mkAttr "side" "right"
        static member inline bottom = Feliz.Interop.mkAttr "side" "bottom"
        static member inline left = Feliz.Interop.mkAttr "side" "left"

    type [<Erase>] align =
        static member inline start = Feliz.Interop.mkAttr "align" "start"
        static member inline center = Feliz.Interop.mkAttr "align" "center"
        static member inline end' = Feliz.Interop.mkAttr "align" "end"

    type [<Erase>] sticky =
        static member inline partial = Feliz.Interop.mkAttr "sticky" "partial"
        static member inline always = Feliz.Interop.mkAttr "sticky" "always"



/// An optional arrow element to render alongside a menubar menu. This can be used to help visually link the trigger with the Menubar.Content. Must be rendered inside Menubar.Content.
type [<Erase>] arrow =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// The width of the arrow in pixels.
    static member inline width (value: int) = Feliz.Interop.mkAttr "width" value
    /// The height of the arrow in pixels.
    static member inline height (value: int) = Feliz.Interop.mkAttr "height" value




/// The component that contains the menubar items.
type [<Erase>] item =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// When true, prevents the user from interacting with the item.
    static member inline disabled (value: bool) = Feliz.Interop.mkAttr "disabled" value
    /// Event handler called when the user selects an item (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the menubar from closing when selecting that item.
    static member inline onSelect (value: (Browser.Types.Event -> unit)) = Feliz.Interop.mkAttr "onSelect" value
    /// Event handler called when the user selects an item (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the menubar from closing when selecting that item.
    static member inline textValue (value: string) = Feliz.Interop.mkAttr "textValue" value




/// Used to group multiple Menubar.Items.
type [<Erase>] group =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// Used to render a label. It won't be focusable using arrow keys.
type [<Erase>] label =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// An item that can be controlled and rendered like a checkbox.
type [<Erase>] checkboxItem =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// The controlled checked state of the item. Must be used in conjunction with onCheckedChange.
    static member inline checked' (value: bool) = Feliz.Interop.mkAttr "checked" value
    /// The controlled checked state of the item. Must be used in conjunction with onCheckedChange.
    static member inline checked' (value: string) = Feliz.Interop.mkAttr "checked" value
    /// Event handler called when the checked state changes.
    static member inline onCheckedChange (value: (bool -> unit)) = Feliz.Interop.mkAttr "onCheckedChange" value
    /// Event handler called when the checked state changes.
    static member inline disabled (value: bool) = Feliz.Interop.mkAttr "disabled" value
    /// Event handler called when the user selects an item (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the menubar from closing when selecting that item.
    static member inline onSelect (value: (Browser.Types.Event -> unit)) = Feliz.Interop.mkAttr "onSelect" value
    /// Event handler called when the user selects an item (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the menubar from closing when selecting that item.
    static member inline textValue (value: string) = Feliz.Interop.mkAttr "textValue" value




/// Used to group multiple Menubar.RadioItems.
type [<Erase>] radioGroup =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// The value of the selected item in the group.
    static member inline value (value: string) = Feliz.Interop.mkAttr "value" value
    /// Event handler called when the value changes.
    static member inline onValueChange (value: (string -> unit)) = Feliz.Interop.mkAttr "onValueChange" value




/// An item that can be controlled and rendered like a radio.
type [<Erase>] radioItem =
    /// Event handler called when the value changes.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// The unique value of the item.
    static member inline value (value: string) = Feliz.Interop.mkAttr "value" value
    /// When true, prevents the user from interacting with the item.
    static member inline disabled (value: bool) = Feliz.Interop.mkAttr "disabled" value
    /// Event handler called when the user selects an item (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the menubar from closing when selecting that item.
    static member inline onSelect (value: (Browser.Types.Event -> unit)) = Feliz.Interop.mkAttr "onSelect" value
    /// Event handler called when the user selects an item (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the menubar from closing when selecting that item.
    static member inline textValue (value: string) = Feliz.Interop.mkAttr "textValue" value




/// Renders when the parent Menubar.CheckboxItem or Menubar.RadioItem is checked. You can style this element directly, or you can use it as a wrapper to put an icon into, or both.
type [<Erase>] itemIndicator =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value




/// Used to visually separate items in a menubar menu.
type [<Erase>] separator =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// Contains all the parts of a submenu.
type [<Erase>] sub =
    /// The open state of the submenu when it is initially rendered. Use when you do not need to control its open state.
    static member inline defaultOpen (value: bool) = Feliz.Interop.mkAttr "defaultOpen" value
    /// The controlled open state of the submenu. Must be used in conjunction with onOpenChange.
    static member inline open' (value: bool) = Feliz.Interop.mkAttr "open" value
    /// Event handler called when the open state of the submenu changes.
    static member inline onOpenChange (value: (bool -> unit)) = Feliz.Interop.mkAttr "onOpenChange" value




/// An item that opens a submenu. Must be rendered inside Menubar.Sub.
type [<Erase>] subTrigger =
    /// Event handler called when the open state of the submenu changes.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// When true, prevents the user from interacting with the item.
    static member inline disabled (value: bool) = Feliz.Interop.mkAttr "disabled" value
    /// Optional text used for typeahead purposes. By default the typeahead behavior will use the .textContent of the item. Use this when the content is complex, or you have non-textual content inside.
    static member inline textValue (value: string) = Feliz.Interop.mkAttr "textValue" value




/// The component that pops out when a submenu is open. Must be rendered inside Menubar.Sub.
type [<Erase>] subContent =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// When true, keyboard navigation will loop from last item to first, and vice versa.
    static member inline loop (value: bool) = Feliz.Interop.mkAttr "loop" value
    /// Event handler called when the escape key is down. It can be prevented by calling event.preventDefault
    static member inline onEscapeKeyDown (value: (Browser.Types.KeyboardEvent -> unit)) = Feliz.Interop.mkAttr "onEscapeKeyDown" value
    /// Event handler called when the escape key is down. It can be prevented by calling event.preventDefault
    static member inline onPointerDownOutside (value: (PointerDownOutsideEvent -> unit)) = Feliz.Interop.mkAttr "onPointerDownOutside" value
    /// Event handler called when a pointer event occurs outside the bounds of the component. It can be prevented by calling event.preventDefault.
    static member inline onFocusOutside (value: (FocusOutsideEvent -> unit)) = Feliz.Interop.mkAttr "onFocusOutside" value
    /// Event handler called when focus moves outside the bounds of the component. It can be prevented by calling event.preventDefault.
    static member inline onInteractOutside (value: (PointerDownOutsideEvent -> unit)) = Feliz.Interop.mkAttr "onInteractOutside" value
    /// Event handler called when focus moves outside the bounds of the component. It can be prevented by calling event.preventDefault.
    static member inline onInteractOutside (value: (FocusOutsideEvent -> unit)) = Feliz.Interop.mkAttr "onInteractOutside" value
    /// Event handler called when an interaction (pointer or focus event) happens outside the bounds of the component. It can be prevented by calling event.preventDefault.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value
    /// The distance in pixels from the trigger.
    static member inline sideOffset (value: int) = Feliz.Interop.mkAttr "sideOffset" value
    /// An offset in pixels from the "start" or "end" alignment options.
    static member inline alignOffset (value: int) = Feliz.Interop.mkAttr "alignOffset" value
    /// When true, overrides the side andalign preferences to prevent collisions with boundary edges.
    static member inline avoidCollisions (value: bool) = Feliz.Interop.mkAttr "avoidCollisions" value
    /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check.
    static member inline collisionBoundary (value: ReactElement) = Feliz.Interop.mkAttr "collisionBoundary" value
    /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check.
    static member inline collisionBoundary (value: ReactElement[]) = Feliz.Interop.mkAttr "collisionBoundary" value
    /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check.
    static member inline collisionPadding (value: int) = Feliz.Interop.mkAttr "collisionPadding" value
    /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check.
    static member inline collisionPadding (value: 'T) = Feliz.Interop.mkAttr "collisionPadding" value
    /// The distance in pixels from the boundary edges where collision detection should occur. Accepts a number (same for all sides), or a partial padding object, for example: { top: 20, left: 20 }.
    static member inline arrowPadding (value: int) = Feliz.Interop.mkAttr "arrowPadding" value
    /// The sticky behavior on the align axis. "partial" will keep the content in the boundary as long as the trigger is at least partially in the boundary whilst "always" will keep the content in the boundary regardless.
    static member inline hideWhenDetached (value: bool) = Feliz.Interop.mkAttr "hideWhenDetached" value


module subContent =

    type [<Erase>] sticky =
        static member inline partial = Feliz.Interop.mkAttr "sticky" "partial"
        static member inline always = Feliz.Interop.mkAttr "sticky" "always"


