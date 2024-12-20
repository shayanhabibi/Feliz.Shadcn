namespace rec Feliz.Shadcn.ContextMenu

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn
open Browser.Types


/// Displays a menu located at the pointer, triggered by a right-click or a long-press.
type [<Erase>] contextMenu =
    /// Contains all the parts of a context menu.
    static member inline root (props: IReactProperty seq) = createElement (import "ContextMenu" "@/components/ui/context-menu") props
    /// The area that opens the context menu. Wrap it around the target you want the context menu to open from when right-clicking (or using the relevant keyboard shortcuts).
    static member inline trigger (props: IReactProperty seq) = createElement (import "ContextMenuTrigger" "@/components/ui/context-menu") props
    /// When used, portals the content part into the body.
    static member inline portal (props: IReactProperty seq) = createElement (import "ContextMenuPortal" "@/components/ui/context-menu") props
    /// The component that pops out in an open context menu.
    static member inline content (props: IReactProperty seq) = createElement (import "ContextMenuContent" "@/components/ui/context-menu") props
    /// An optional arrow element to render alongside a submenu. This can be used to help visually link the trigger item with the ContextMenu.Content. Must be rendered inside ContextMenu.Content.
    static member inline arrow (props: IReactProperty seq) = createElement (import "ContextMenuArrow" "@/components/ui/context-menu") props
    /// The component that contains the context menu items.
    static member inline item (props: IReactProperty seq) = createElement (import "ContextMenuItem" "@/components/ui/context-menu") props
    /// Used to group multiple ContextMenu.Items.
    static member inline group (props: IReactProperty seq) = createElement (import "ContextMenuGroup" "@/components/ui/context-menu") props
    /// Used to render a label. It won't be focusable using arrow keys.
    static member inline label (props: IReactProperty seq) = createElement (import "ContextMenuLabel" "@/components/ui/context-menu") props
    /// An item that can be controlled and rendered like a checkbox.
    static member inline checkboxItem (props: IReactProperty seq) = createElement (import "ContextMenuCheckboxItem" "@/components/ui/context-menu") props
    /// Used to group multiple ContextMenu.RadioItems.
    static member inline radioGroup (props: IReactProperty seq) = createElement (import "ContextMenuRadioGroup" "@/components/ui/context-menu") props
    /// An item that can be controlled and rendered like a radio.
    static member inline radioItem (props: IReactProperty seq) = createElement (import "ContextMenuRadioItem" "@/components/ui/context-menu") props
    /// Renders when the parent ContextMenu.CheckboxItem or ContextMenu.RadioItem is checked. You can style this element directly, or you can use it as a wrapper to put an icon into, or both.
    static member inline itemIndicator (props: IReactProperty seq) = createElement (import "ContextMenuItemIndicator" "@/components/ui/context-menu") props
    /// Used to visually separate items in the context menu.
    static member inline separator (props: IReactProperty seq) = createElement (import "ContextMenuSeparator" "@/components/ui/context-menu") props
    /// Contains all the parts of a submenu.
    static member inline sub (props: IReactProperty seq) = createElement (import "ContextMenuSub" "@/components/ui/context-menu") props
    /// An item that opens a submenu. Must be rendered inside ContextMenu.Sub.
    static member inline subTrigger (props: IReactProperty seq) = createElement (import "ContextMenuSubTrigger" "@/components/ui/context-menu") props
    /// The component that pops out when a submenu is open. Must be rendered inside ContextMenu.Sub.
    static member inline subContent (props: IReactProperty seq) = createElement (import "ContextMenuSubContent" "@/components/ui/context-menu") props


/// Contains all the parts of a context menu.
type [<Erase>] root =
    /// The reading direction of submenus when applicable. If omitted, inherits globally from DirectionProvider or assumes LTR (left-to-right) reading mode.
    static member inline onOpenChange (value: (bool -> unit)) = Feliz.Interop.mkAttr "onOpenChange" value
    /// Event handler called when the open state of the context menu changes.
    static member inline modal (value: bool) = Feliz.Interop.mkAttr "modal" value


module root =

    type [<Erase>] dir =
        static member inline ltr = Feliz.Interop.mkAttr "dir" "ltr"
        static member inline rtl = Feliz.Interop.mkAttr "dir" "rtl"



/// The area that opens the context menu. Wrap it around the target you want the context menu to open from when right-clicking (or using the relevant keyboard shortcuts).
type [<Erase>] trigger =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// When true, the context menu won't open when right-clicking. Note that this will also restore the native context menu.
    static member inline disabled (value: bool) = Feliz.Interop.mkAttr "disabled" value




/// When used, portals the content part into the body.
type [<Erase>] portal =
    /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries. If used on this part, it will be inherited by ContextMenu.Content and ContextMenu.SubContent respectively.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value
    /// Specify a container element to portal the content into.
    static member inline container (value: HTMLElement) = Feliz.Interop.mkAttr "container" value




/// The component that pops out in an open context menu.
type [<Erase>] content =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// When true, keyboard navigation will loop from last item to first, and vice versa.
    static member inline loop (value: bool) = Feliz.Interop.mkAttr "loop" value
    /// Event handler called when focus moves back after closing. It can be prevented by calling event.preventDefault.
    static member inline onCloseAutoFocus (value: (Browser.Types.Event -> unit)) = Feliz.Interop.mkAttr "onCloseAutoFocus" value
    /// Event handler called when focus moves back after closing. It can be prevented by calling event.preventDefault.
    static member inline onEscapeKeyDown (value: (Browser.Types.KeyboardEvent -> unit)) = Feliz.Interop.mkAttr "onEscapeKeyDown" value
    /// Event handler called when the escape key is down. It can be prevented by calling event.preventDefault.
    static member inline onPointerDownOutside (value: (PointerDownOutsideEvent -> unit)) = Feliz.Interop.mkAttr "onPointerDownOutside" value
    /// Event handler called when a pointer event occurs outside the bounds of the component. It can be prevented by calling event.preventDefault.
    static member inline onFocusOutside (value: (FocusOutsideEvent -> unit)) = Feliz.Interop.mkAttr "onFocusOutside" value
    /// Event handler called when focus moves outside the bounds of the component. It can be prevented by calling event.preventDefault.
    static member inline onInteractOutside (value: (PointerDownOutsideEvent -> unit)) = Feliz.Interop.mkAttr "onInteractOutside" value
    /// Event handler called when focus moves outside the bounds of the component. It can be prevented by calling event.preventDefault.
    static member inline onInteractOutside (value: (FocusOutsideEvent -> unit)) = Feliz.Interop.mkAttr "onInteractOutside" value
    /// Event handler called when an interaction (pointer or focus event) happens outside the bounds of the component. It can be prevented by calling event.preventDefault.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value
    /// The vertical distance in pixels from the anchor.
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
    /// The sticky behavior on the align axis. "partial" will keep the content in the boundary as long as the trigger is at least partially in the boundary whilst "always" will keep the content in the boundary regardless.
    static member inline hideWhenDetached (value: bool) = Feliz.Interop.mkAttr "hideWhenDetached" value


module content =

    type [<Erase>] sticky =
        static member inline partial = Feliz.Interop.mkAttr "sticky" "partial"
        static member inline always = Feliz.Interop.mkAttr "sticky" "always"



/// An optional arrow element to render alongside a submenu. This can be used to help visually link the trigger item with the ContextMenu.Content. Must be rendered inside ContextMenu.Content.
type [<Erase>] arrow =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// The width of the arrow in pixels.
    static member inline width (value: int) = Feliz.Interop.mkAttr "width" value
    /// The height of the arrow in pixels.
    static member inline height (value: int) = Feliz.Interop.mkAttr "height" value




/// The component that contains the context menu items.
type [<Erase>] item =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// When true, prevents the user from interacting with the item.
    static member inline disabled (value: bool) = Feliz.Interop.mkAttr "disabled" value
    /// Event handler called when the user selects an item (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the context menu from closing when selecting that item.
    static member inline onSelect (value: (Browser.Types.Event -> unit)) = Feliz.Interop.mkAttr "onSelect" value
    /// Event handler called when the user selects an item (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the context menu from closing when selecting that item.
    static member inline textValue (value: string) = Feliz.Interop.mkAttr "textValue" value




/// Used to group multiple ContextMenu.Items.
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
    /// Event handler called when the user selects an item (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the context menu from closing when selecting that item.
    static member inline onSelect (value: (Browser.Types.Event -> unit)) = Feliz.Interop.mkAttr "onSelect" value
    /// Event handler called when the user selects an item (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the context menu from closing when selecting that item.
    static member inline textValue (value: string) = Feliz.Interop.mkAttr "textValue" value




/// Used to group multiple ContextMenu.RadioItems.
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
    /// Event handler called when the user selects an item (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the context menu from closing when selecting that item.
    static member inline onSelect (value: (Browser.Types.Event -> unit)) = Feliz.Interop.mkAttr "onSelect" value
    /// Event handler called when the user selects an item (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the context menu from closing when selecting that item.
    static member inline textValue (value: string) = Feliz.Interop.mkAttr "textValue" value




/// Renders when the parent ContextMenu.CheckboxItem or ContextMenu.RadioItem is checked. You can style this element directly, or you can use it as a wrapper to put an icon into, or both.
type [<Erase>] itemIndicator =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value




/// Used to visually separate items in the context menu.
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




/// An item that opens a submenu. Must be rendered inside ContextMenu.Sub.
type [<Erase>] subTrigger =
    /// Event handler called when the open state of the submenu changes.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// When true, prevents the user from interacting with the item.
    static member inline disabled (value: bool) = Feliz.Interop.mkAttr "disabled" value
    /// Optional text used for typeahead purposes. By default the typeahead behavior will use the .textContent of the item. Use this when the content is complex, or you have non-textual content inside.
    static member inline textValue (value: string) = Feliz.Interop.mkAttr "textValue" value




/// The component that pops out when a submenu is open. Must be rendered inside ContextMenu.Sub.
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


