namespace Feliz.RadixUI.Interface.NoInherit
// AUTOGENERATED FILE - these files do not inherit feliz properties at base
open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn.Interop
open Browser.Types


/// Contains all the parts of a context menu.
[<RequireQualifiedAccess>]
module [<Erase>] contextMenuRoot =
    type [<Erase>] dir<'Property> =
        static member inline ltr : 'Property = Interop.mkProperty "dir" "ltr"
        static member inline rtl : 'Property = Interop.mkProperty "dir" "rtl"

/// The component that pops out in an open context menu.
[<RequireQualifiedAccess>]
module [<Erase>] contextMenuContent =
    type [<Erase>] sticky<'Property> =
        static member inline partial : 'Property = Interop.mkProperty "sticky" "partial"
        static member inline always : 'Property = Interop.mkProperty "sticky" "always"

/// The component that pops out when a submenu is open. Must be rendered inside ContextMenu.Sub.
[<RequireQualifiedAccess>]
module [<Erase>] contextMenuSubContent =
    type [<Erase>] sticky<'Property> =
        static member inline partial : 'Property = Interop.mkProperty "sticky" "partial"
        static member inline always : 'Property = Interop.mkProperty "sticky" "always"

/// Displays a menu located at the pointer, triggered by a right click or a long press.
[<RequireQualifiedAccess>]
module [<Erase>] ContextMenu =
    /// Contains all the parts of a context menu.
    type [<Erase>] root<'Property> =
        /// The reading direction of submenus when applicable. If omitted, inherits globally from DirectionProvider or assumes LTR (left-to-right) reading mode.
        static member inline onOpenChange ( value : (bool -> unit) ) : 'Property = Interop.mkProperty "onOpenChange" value
        /// Event handler called when the open state of the context menu changes.
        static member inline modal ( value : bool ) : 'Property = Interop.mkProperty "modal" value

    /// The area that opens the context menu. Wrap it around the target you want the context menu to open from when right-clicking (or using the relevant keyboard shortcuts).
    type [<Erase>] trigger<'Property> =
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// When true, the context menu won't open when right-clicking. Note that this will also restore the native context menu.
        static member inline disabled ( value : bool ) : 'Property = Interop.mkProperty "disabled" value

    /// When used, portals the content part into the body.
    type [<Erase>] portal<'Property> =
        /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries. If used on this part, it will be inherited by ContextMenu.Content and ContextMenu.SubContent respectively.
        static member inline forceMount ( value : bool ) : 'Property = Interop.mkProperty "forceMount" value
        /// Specify a container element to portal the content into.
        static member inline container ( value : HTMLElement ) : 'Property = Interop.mkProperty "container" value

    /// The component that pops out in an open context menu.
    type [<Erase>] content<'Property> =
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// When true, keyboard navigation will loop from last item to first, and vice versa.
        static member inline loop ( value : bool ) : 'Property = Interop.mkProperty "loop" value
        /// Event handler called when focus moves back after closing. It can be prevented by calling event.preventDefault.
        static member inline onCloseAutoFocus ( value : (Browser.Types.Event -> unit) ) : 'Property = Interop.mkProperty "onCloseAutoFocus" value
        /// Event handler called when focus moves back after closing. It can be prevented by calling event.preventDefault.
        static member inline onEscapeKeyDown ( value : (Browser.Types.KeyboardEvent -> unit) ) : 'Property = Interop.mkProperty "onEscapeKeyDown" value
        /// Event handler called when the escape key is down. It can be prevented by calling event.preventDefault.
        static member inline onPointerDownOutside ( value : (PointerEvent -> unit) ) : 'Property = Interop.mkProperty "onPointerDownOutside" value
        /// Event handler called when a pointer event occurs outside the bounds of the component. It can be prevented by calling event.preventDefault.
        static member inline onFocusOutside ( value : (FocusEvent -> unit) ) : 'Property = Interop.mkProperty "onFocusOutside" value
        /// Event handler called when focus moves outside the bounds of the component. It can be prevented by calling event.preventDefault.
        static member inline onInteractOutside ( value : (PointerEvent -> unit) ) : 'Property = Interop.mkProperty "onInteractOutside" value
        /// Event handler called when focus moves outside the bounds of the component. It can be prevented by calling event.preventDefault.
        static member inline onInteractOutside ( value : (FocusEvent -> unit) ) : 'Property = Interop.mkProperty "onInteractOutside" value
        /// Event handler called when an interaction (pointer or focus event) happens outside the bounds of the component. It can be prevented by calling event.preventDefault.
        static member inline forceMount ( value : bool ) : 'Property = Interop.mkProperty "forceMount" value
        /// The vertical distance in pixels from the anchor.
        static member inline alignOffset ( value : int ) : 'Property = Interop.mkProperty "alignOffset" value
        /// When true, overrides the side andalign preferences to prevent collisions with boundary edges.
        static member inline avoidCollisions ( value : bool ) : 'Property = Interop.mkProperty "avoidCollisions" value
        /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check.
        static member inline collisionBoundary ( value : ReactElement ) : 'Property = Interop.mkProperty "collisionBoundary" value
        /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check.
        static member inline collisionBoundary ( value : ReactElement[] ) : 'Property = Interop.mkProperty "collisionBoundary" value
        /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check.
        static member inline collisionPadding ( value : int ) : 'Property = Interop.mkProperty "collisionPadding" value
        /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check.
        static member inline collisionPadding ( value : 'T ) : 'Property = Interop.mkProperty "collisionPadding" value
        /// The sticky behavior on the align axis. "partial" will keep the content in the boundary as long as the trigger is at least partially in the boundary whilst "always" will keep the content in the boundary regardless.
        static member inline hideWhenDetached ( value : bool ) : 'Property = Interop.mkProperty "hideWhenDetached" value

    /// An optional arrow element to render alongside a submenu. This can be used to help visually link the trigger item with the ContextMenu.Content. Must be rendered inside ContextMenu.Content.
    type [<Erase>] arrow<'Property> =
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// The width of the arrow in pixels.
        static member inline width ( value : int ) : 'Property = Interop.mkProperty "width" value
        /// The height of the arrow in pixels.
        static member inline height ( value : int ) : 'Property = Interop.mkProperty "height" value

    /// The component that contains the context menu items.
    type [<Erase>] item<'Property> =
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// When true, prevents the user from interacting with the item.
        static member inline disabled ( value : bool ) : 'Property = Interop.mkProperty "disabled" value
        /// Event handler called when the user selects an item (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the context menu from closing when selecting that item.
        static member inline onSelect ( value : (Browser.Types.Event -> unit) ) : 'Property = Interop.mkProperty "onSelect" value
        /// Event handler called when the user selects an item (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the context menu from closing when selecting that item.
        static member inline textValue ( value : string ) : 'Property = Interop.mkProperty "textValue" value

    /// Used to group multiple ContextMenu.Items.
    type [<Erase>] group<'Property> =
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// Used to render a label. It won't be focusable using arrow keys.
    type [<Erase>] label<'Property> =
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// An item that can be controlled and rendered like a checkbox.
    type [<Erase>] checkboxItem<'Property> =
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// The controlled checked state of the item. Must be used in conjunction with onCheckedChange.
        static member inline checked' ( value : bool ) : 'Property = Interop.mkProperty "checked" value
        /// The controlled checked state of the item. Must be used in conjunction with onCheckedChange.
        static member inline checked' ( value : string ) : 'Property = Interop.mkProperty "checked" value
        /// Event handler called when the checked state changes.
        static member inline onCheckedChange ( value : (bool -> unit) ) : 'Property = Interop.mkProperty "onCheckedChange" value
        /// Event handler called when the checked state changes.
        static member inline disabled ( value : bool ) : 'Property = Interop.mkProperty "disabled" value
        /// Event handler called when the user selects an item (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the context menu from closing when selecting that item.
        static member inline onSelect ( value : (Browser.Types.Event -> unit) ) : 'Property = Interop.mkProperty "onSelect" value
        /// Event handler called when the user selects an item (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the context menu from closing when selecting that item.
        static member inline textValue ( value : string ) : 'Property = Interop.mkProperty "textValue" value

    /// Used to group multiple ContextMenu.RadioItems.
    type [<Erase>] radioGroup<'Property> =
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// The value of the selected item in the group.
        static member inline value ( value : string ) : 'Property = Interop.mkProperty "value" value
        /// Event handler called when the value changes.
        static member inline onValueChange ( value : (string -> unit) ) : 'Property = Interop.mkProperty "onValueChange" value

    /// An item that can be controlled and rendered like a radio.
    type [<Erase>] radioItem<'Property> =
        /// Event handler called when the value changes.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// The unique value of the item.
        static member inline value ( value : string ) : 'Property = Interop.mkProperty "value" value
        /// When true, prevents the user from interacting with the item.
        static member inline disabled ( value : bool ) : 'Property = Interop.mkProperty "disabled" value
        /// Event handler called when the user selects an item (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the context menu from closing when selecting that item.
        static member inline onSelect ( value : (Browser.Types.Event -> unit) ) : 'Property = Interop.mkProperty "onSelect" value
        /// Event handler called when the user selects an item (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the context menu from closing when selecting that item.
        static member inline textValue ( value : string ) : 'Property = Interop.mkProperty "textValue" value

    /// Renders when the parent ContextMenu.CheckboxItem or ContextMenu.RadioItem is checked. You can style this element directly, or you can use it as a wrapper to put an icon into, or both.
    type [<Erase>] itemIndicator<'Property> =
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries.
        static member inline forceMount ( value : bool ) : 'Property = Interop.mkProperty "forceMount" value

    /// Used to visually separate items in the context menu.
    type [<Erase>] separator<'Property> =
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// Contains all the parts of a submenu.
    type [<Erase>] sub<'Property> =
        /// The open state of the submenu when it is initially rendered. Use when you do not need to control its open state.
        static member inline defaultOpen ( value : bool ) : 'Property = Interop.mkProperty "defaultOpen" value
        /// The controlled open state of the submenu. Must be used in conjunction with onOpenChange.
        static member inline open' ( value : bool ) : 'Property = Interop.mkProperty "open" value
        /// Event handler called when the open state of the submenu changes.
        static member inline onOpenChange ( value : (bool -> unit) ) : 'Property = Interop.mkProperty "onOpenChange" value

    /// An item that opens a submenu. Must be rendered inside ContextMenu.Sub.
    type [<Erase>] subTrigger<'Property> =
        /// Event handler called when the open state of the submenu changes.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// When true, prevents the user from interacting with the item.
        static member inline disabled ( value : bool ) : 'Property = Interop.mkProperty "disabled" value
        /// Optional text used for typeahead purposes. By default the typeahead behavior will use the .textContent of the item. Use this when the content is complex, or you have non-textual content inside.
        static member inline textValue ( value : string ) : 'Property = Interop.mkProperty "textValue" value

    /// The component that pops out when a submenu is open. Must be rendered inside ContextMenu.Sub.
    type [<Erase>] subContent<'Property> =
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// When true, keyboard navigation will loop from last item to first, and vice versa.
        static member inline loop ( value : bool ) : 'Property = Interop.mkProperty "loop" value
        /// Event handler called when the escape key is down. It can be prevented by calling event.preventDefault
        static member inline onEscapeKeyDown ( value : (Browser.Types.KeyboardEvent -> unit) ) : 'Property = Interop.mkProperty "onEscapeKeyDown" value
        /// Event handler called when the escape key is down. It can be prevented by calling event.preventDefault
        static member inline onPointerDownOutside ( value : (PointerEvent -> unit) ) : 'Property = Interop.mkProperty "onPointerDownOutside" value
        /// Event handler called when a pointer event occurs outside the bounds of the component. It can be prevented by calling event.preventDefault.
        static member inline onFocusOutside ( value : (FocusEvent -> unit) ) : 'Property = Interop.mkProperty "onFocusOutside" value
        /// Event handler called when focus moves outside the bounds of the component. It can be prevented by calling event.preventDefault.
        static member inline onInteractOutside ( value : (PointerEvent -> unit) ) : 'Property = Interop.mkProperty "onInteractOutside" value
        /// Event handler called when focus moves outside the bounds of the component. It can be prevented by calling event.preventDefault.
        static member inline onInteractOutside ( value : (FocusEvent -> unit) ) : 'Property = Interop.mkProperty "onInteractOutside" value
        /// Event handler called when an interaction (pointer or focus event) happens outside the bounds of the component. It can be prevented by calling event.preventDefault.
        static member inline forceMount ( value : bool ) : 'Property = Interop.mkProperty "forceMount" value
        /// The distance in pixels from the trigger.
        static member inline sideOffset ( value : int ) : 'Property = Interop.mkProperty "sideOffset" value
        /// An offset in pixels from the "start" or "end" alignment options.
        static member inline alignOffset ( value : int ) : 'Property = Interop.mkProperty "alignOffset" value
        /// When true, overrides the side andalign preferences to prevent collisions with boundary edges.
        static member inline avoidCollisions ( value : bool ) : 'Property = Interop.mkProperty "avoidCollisions" value
        /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check.
        static member inline collisionBoundary ( value : ReactElement ) : 'Property = Interop.mkProperty "collisionBoundary" value
        /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check.
        static member inline collisionBoundary ( value : ReactElement[] ) : 'Property = Interop.mkProperty "collisionBoundary" value
        /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check.
        static member inline collisionPadding ( value : int ) : 'Property = Interop.mkProperty "collisionPadding" value
        /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check.
        static member inline collisionPadding ( value : 'T ) : 'Property = Interop.mkProperty "collisionPadding" value
        /// The distance in pixels from the boundary edges where collision detection should occur. Accepts a number (same for all sides), or a partial padding object, for example: { top: 20, left: 20 }.
        static member inline arrowPadding ( value : int ) : 'Property = Interop.mkProperty "arrowPadding" value
        /// The sticky behavior on the align axis. "partial" will keep the content in the boundary as long as the trigger is at least partially in the boundary whilst "always" will keep the content in the boundary regardless.
        static member inline hideWhenDetached ( value : bool ) : 'Property = Interop.mkProperty "hideWhenDetached" value
