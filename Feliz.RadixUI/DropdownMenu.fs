namespace Feliz.RadixUI

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Interop.Extend
open Browser.Types


/// Displays a menu to the user—such as a set of actions or functions—triggered by a button.
module [<Erase>] DropdownMenu =
    /// import "DropdownMenu" ""
    /// Contains all the parts of a dropdown menu.
    type [<Erase>] root<'Property> =
        inherit prop<'Property>
        /// The open state of the dropdown menu when it is initially rendered. Use when you do not need to control its open state.
        static member inline defaultOpen ( value : bool ) : 'Property = Interop.mkProperty "defaultOpen" value
        /// The controlled open state of the dropdown menu. Must be used in conjunction with onOpenChange.
        static member inline open' ( value : bool ) : 'Property = Interop.mkProperty "open" value
        /// Event handler called when the open state of the dropdown menu changes.
        static member inline onOpenChange ( value : (bool -> unit) ) : 'Property = Interop.mkProperty "onOpenChange" value
        /// Event handler called when the open state of the dropdown menu changes.
        static member inline modal ( value : bool ) : 'Property = Interop.mkProperty "modal" value

    /// import "DropdownMenuTrigger" ""
    /// The button that toggles the dropdown menu. By default, the DropdownMenu.Content will position itself against the trigger.
    type [<Erase>] trigger<'Property> =
        inherit prop<'Property>
        /// The reading direction of submenus when applicable. If omitted, inherits globally from DirectionProvider or assumes LTR (left-to-right) reading mode.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// import "DropdownMenuPortal" ""
    /// When used, portals the content part into the body.
    type [<Erase>] portal<'Property> =
        inherit prop<'Property>
        /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries. If used on this part, it will be inherited by DropdownMenu.Content and DropdownMenu.SubContent respectively.
        static member inline forceMount ( value : bool ) : 'Property = Interop.mkProperty "forceMount" value
        /// Specify a container element to portal the content into.
        static member inline container ( value : HTMLElement ) : 'Property = Interop.mkProperty "container" value

    /// import "DropdownMenuContent" ""
    /// The component that pops out when the dropdown menu is open.
    type [<Erase>] content<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// When true, keyboard navigation will loop from last item to first, and vice versa.
        static member inline loop ( value : bool ) : 'Property = Interop.mkProperty "loop" value
        /// Event handler called when focus moves to the trigger after closing. It can be prevented by calling event.preventDefault.
        static member inline onCloseAutoFocus ( value : (Browser.Types.Event -> unit) ) : 'Property = Interop.mkProperty "onCloseAutoFocus" value
        /// Event handler called when focus moves to the trigger after closing. It can be prevented by calling event.preventDefault.
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
        /// The preferred side of the trigger to render against when open. Will be reversed when collisions occur and avoidCollisions is enabled.
        static member inline sideOffset ( value : int ) : 'Property = Interop.mkProperty "sideOffset" value
        /// The preferred alignment against the trigger. May change when collisions occur.
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

    /// import "DropdownMenuArrow" ""
    /// An optional arrow element to render alongside the dropdown menu. This can be used to help visually link the trigger with the DropdownMenu.Content. Must be rendered inside DropdownMenu.Content.
    type [<Erase>] arrow<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// The width of the arrow in pixels.
        static member inline width ( value : int ) : 'Property = Interop.mkProperty "width" value
        /// The height of the arrow in pixels.
        static member inline height ( value : int ) : 'Property = Interop.mkProperty "height" value

    /// import "DropdownMenuItem" ""
    /// The component that contains the dropdown menu items.
    type [<Erase>] item<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// When true, prevents the user from interacting with the item.
        static member inline disabled ( value : bool ) : 'Property = Interop.mkProperty "disabled" value
        /// Event handler called when the user selects an item (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the dropdown menu from closing when selecting that item.
        static member inline onSelect ( value : (Browser.Types.Event -> unit) ) : 'Property = Interop.mkProperty "onSelect" value
        /// Event handler called when the user selects an item (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the dropdown menu from closing when selecting that item.
        static member inline textValue ( value : string ) : 'Property = Interop.mkProperty "textValue" value

    /// import "DropdownMenuGroup" ""
    /// Used to group multiple DropdownMenu.Items.
    type [<Erase>] group<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// import "DropdownMenuLabel" ""
    /// Used to render a label. It won't be focusable using arrow keys.
    type [<Erase>] label<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// import "DropdownMenuCheckboxItem" ""
    /// An item that can be controlled and rendered like a checkbox.
    type [<Erase>] checkboxItem<'Property> =
        inherit prop<'Property>
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
        /// Event handler called when the user selects an item (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the dropdown menu from closing when selecting that item.
        static member inline onSelect ( value : (Browser.Types.Event -> unit) ) : 'Property = Interop.mkProperty "onSelect" value
        /// Event handler called when the user selects an item (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the dropdown menu from closing when selecting that item.
        static member inline textValue ( value : string ) : 'Property = Interop.mkProperty "textValue" value

    /// import "DropdownMenuRadioGroup" ""
    /// Used to group multiple DropdownMenu.RadioItems.
    type [<Erase>] radioGroup<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// The value of the selected item in the group.
        static member inline value ( value : string ) : 'Property = Interop.mkProperty "value" value
        /// Event handler called when the value changes.
        static member inline onValueChange ( value : (string -> unit) ) : 'Property = Interop.mkProperty "onValueChange" value

    /// import "DropdownMenuRadioItem" ""
    /// An item that can be controlled and rendered like a radio.
    type [<Erase>] radioItem<'Property> =
        inherit prop<'Property>
        /// Event handler called when the value changes.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// The unique value of the item.
        static member inline value ( value : string ) : 'Property = Interop.mkProperty "value" value
        /// When true, prevents the user from interacting with the item.
        static member inline disabled ( value : bool ) : 'Property = Interop.mkProperty "disabled" value
        /// Event handler called when the user selects an item (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the dropdown menu from closing when selecting that item.
        static member inline onSelect ( value : (Browser.Types.Event -> unit) ) : 'Property = Interop.mkProperty "onSelect" value
        /// Event handler called when the user selects an item (via mouse or keyboard). Calling event.preventDefault in this handler will prevent the dropdown menu from closing when selecting that item.
        static member inline textValue ( value : string ) : 'Property = Interop.mkProperty "textValue" value

    /// import "DropdownMenuItemIndicator" ""
    /// Renders when the parent DropdownMenu.CheckboxItem or DropdownMenu.RadioItem is checked. You can style this element directly, or you can use it as a wrapper to put an icon into, or both.
    type [<Erase>] itemIndicator<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries.
        static member inline forceMount ( value : bool ) : 'Property = Interop.mkProperty "forceMount" value

    /// import "DropdownMenuSeparator" ""
    /// Used to visually separate items in the dropdown menu.
    type [<Erase>] separator<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// import "DropdownMenuSub" ""
    /// Contains all the parts of a submenu.
    type [<Erase>] sub<'Property> =
        inherit prop<'Property>
        /// The open state of the submenu when it is initially rendered. Use when you do not need to control its open state.
        static member inline defaultOpen ( value : bool ) : 'Property = Interop.mkProperty "defaultOpen" value
        /// The controlled open state of the submenu. Must be used in conjunction with onOpenChange.
        static member inline open' ( value : bool ) : 'Property = Interop.mkProperty "open" value
        /// Event handler called when the open state of the submenu changes.
        static member inline onOpenChange ( value : (bool -> unit) ) : 'Property = Interop.mkProperty "onOpenChange" value

    /// import "DropdownMenuSubTrigger" ""
    /// An item that opens a submenu. Must be rendered inside DropdownMenu.Sub.
    type [<Erase>] subTrigger<'Property> =
        inherit prop<'Property>
        /// Event handler called when the open state of the submenu changes.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// When true, prevents the user from interacting with the item.
        static member inline disabled ( value : bool ) : 'Property = Interop.mkProperty "disabled" value
        /// Optional text used for typeahead purposes. By default the typeahead behavior will use the .textContent of the item. Use this when the content is complex, or you have non-textual content inside.
        static member inline textValue ( value : string ) : 'Property = Interop.mkProperty "textValue" value

    /// import "DropdownMenuSubContent" ""
    /// The component that pops out when a submenu is open. Must be rendered inside DropdownMenu.Sub.
    type [<Erase>] subContent<'Property> =
        inherit prop<'Property>
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

module [<Erase>] dropdownMenuroot =
    type [<Erase>] dir<'Property> =
        static member inline ltr : 'Property = Interop.mkProperty "dir" "ltr"
        static member inline rtl : 'Property = Interop.mkProperty "dir" "rtl"

module [<Erase>] dropdownMenucontent =
    type [<Erase>] side<'Property> =
        static member inline top : 'Property = Interop.mkProperty "side" "top"
        static member inline right : 'Property = Interop.mkProperty "side" "right"
        static member inline bottom : 'Property = Interop.mkProperty "side" "bottom"
        static member inline left : 'Property = Interop.mkProperty "side" "left"

    type [<Erase>] align<'Property> =
        static member inline start : 'Property = Interop.mkProperty "align" "start"
        static member inline center : 'Property = Interop.mkProperty "align" "center"
        static member inline end' : 'Property = Interop.mkProperty "align" "end"

    type [<Erase>] sticky<'Property> =
        static member inline partial : 'Property = Interop.mkProperty "sticky" "partial"
        static member inline always : 'Property = Interop.mkProperty "sticky" "always"

module [<Erase>] dropdownMenusubContent =
    type [<Erase>] sticky<'Property> =
        static member inline partial : 'Property = Interop.mkProperty "sticky" "partial"
        static member inline always : 'Property = Interop.mkProperty "sticky" "always"
