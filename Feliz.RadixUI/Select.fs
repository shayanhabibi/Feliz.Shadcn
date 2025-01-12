namespace Feliz.RadixUI

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Interop.Extend
open Browser.Types


/// Contains all the parts of a select.
[<RequireQualifiedAccess>]
module [<Erase>] selectRoot =
    type [<Erase>] dir<'Property> =
        static member inline ltr : 'Property = Interop.mkProperty "dir" "ltr"
        static member inline rtl : 'Property = Interop.mkProperty "dir" "rtl"

/// The component that pops out when the select is open.
[<RequireQualifiedAccess>]
module [<Erase>] selectContent =
    type [<Erase>] position<'Property> =
        static member inline itemAligned : 'Property = Interop.mkProperty "position" "item-aligned"
        static member inline popper : 'Property = Interop.mkProperty "position" "popper"

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

/// Displays a list of options for the user to pick from—triggered by a button.
[<RequireQualifiedAccess>]
module [<Erase>] Select =
    /// Contains all the parts of a select.
    type [<Erase>] root<'Property> =
        inherit prop<'Property>
        /// The value of the select when initially rendered. Use when you do not need to control the state of the select.
        static member inline defaultValue ( value : string ) : 'Property = Interop.mkProperty "defaultValue" value
        /// The controlled value of the select. Should be used in conjunction with onValueChange.
        static member inline value ( value : string ) : 'Property = Interop.mkProperty "value" value
        /// Event handler called when the value changes.
        static member inline onValueChange ( value : (string -> unit) ) : 'Property = Interop.mkProperty "onValueChange" value
        /// Event handler called when the value changes.
        static member inline defaultOpen ( value : bool ) : 'Property = Interop.mkProperty "defaultOpen" value
        /// The controlled open state of the select. Must be used in conjunction with onOpenChange.
        static member inline open' ( value : bool ) : 'Property = Interop.mkProperty "open" value
        /// Event handler called when the open state of the select changes.
        static member inline onOpenChange ( value : (bool -> unit) ) : 'Property = Interop.mkProperty "onOpenChange" value
        /// The reading direction of the select when applicable. If omitted, inherits globally from DirectionProvider or assumes LTR (left-to-right) reading mode.
        static member inline name ( value : string ) : 'Property = Interop.mkProperty "name" value
        /// When true, prevents the user from interacting with select.
        static member inline disabled ( value : bool ) : 'Property = Interop.mkProperty "disabled" value
        /// When true, indicates that the user must select a value before the owning form can be submitted.
        static member inline required ( value : bool ) : 'Property = Interop.mkProperty "required" value

    /// The button that toggles the select. The Select.Content will position itself by aligning over the trigger.
    type [<Erase>] trigger<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// The part that reflects the selected value. By default the selected item's text will be rendered. if you require more control, you can instead control the select and pass your own children. It should not be styled to ensure correct positioning. An optional placeholder prop is also available for when the select has no value.
    type [<Erase>] value<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// The content that will be rendered inside the Select.Value when no value or defaultValue is set.
        static member inline placeholder ( value : ReactElement ) : 'Property = Interop.mkProperty "placeholder" value

    /// A small icon often displayed next to the value as a visual affordance for the fact it can be open. By default renders ▼ but you can use your own icon via asChild or use children.
    type [<Erase>] icon<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// When used, portals the content part into the body.
    type [<Erase>] portal<'Property> =
        inherit prop<'Property>
        /// Specify a container element to portal the content into.
        static member inline container ( value : HTMLElement ) : 'Property = Interop.mkProperty "container" value

    /// The component that pops out when the select is open.
    type [<Erase>] content<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// Event handler called when focus moves to the trigger after closing. It can be prevented by calling event.preventDefault.
        static member inline onCloseAutoFocus ( value : (Browser.Types.Event -> unit) ) : 'Property = Interop.mkProperty "onCloseAutoFocus" value
        /// Event handler called when focus moves to the trigger after closing. It can be prevented by calling event.preventDefault.
        static member inline onEscapeKeyDown ( value : (Browser.Types.KeyboardEvent -> unit) ) : 'Property = Interop.mkProperty "onEscapeKeyDown" value
        /// Event handler called when the escape key is down. It can be prevented by calling event.preventDefault.
        static member inline onPointerDownOutside ( value : (PointerEvent -> unit) ) : 'Property = Interop.mkProperty "onPointerDownOutside" value
        /// The preferred side of the anchor to render against when open. Will be reversed when collisions occur and avoidCollisions is enabled. Only available when position is set to popper.
        static member inline sideOffset ( value : int ) : 'Property = Interop.mkProperty "sideOffset" value
        /// The preferred alignment against the anchor. May change when collisions occur. Only available when position is set to popper.
        static member inline alignOffset ( value : int ) : 'Property = Interop.mkProperty "alignOffset" value
        /// When true, overrides the side andalign preferences to prevent collisions with boundary edges. Only available when position is set to popper.
        static member inline avoidCollisions ( value : bool ) : 'Property = Interop.mkProperty "avoidCollisions" value
        /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check. Only available when position is set to popper.
        static member inline collisionBoundary ( value : ReactElement ) : 'Property = Interop.mkProperty "collisionBoundary" value
        /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check. Only available when position is set to popper.
        static member inline collisionBoundary ( value : ReactElement[] ) : 'Property = Interop.mkProperty "collisionBoundary" value
        /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check. Only available when position is set to popper.
        static member inline collisionPadding ( value : int ) : 'Property = Interop.mkProperty "collisionPadding" value
        /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check. Only available when position is set to popper.
        static member inline collisionPadding ( value : 'T ) : 'Property = Interop.mkProperty "collisionPadding" value
        /// The distance in pixels from the boundary edges where collision detection should occur. Accepts a number (same for all sides), or a partial padding object, for example: { top: 20, left: 20 }. Only available when position is set to popper.
        static member inline arrowPadding ( value : int ) : 'Property = Interop.mkProperty "arrowPadding" value
        /// The sticky behavior on the align axis. "partial" will keep the content in the boundary as long as the trigger is at least partially in the boundary whilst "always" will keep the content in the boundary regardless. Only available when position is set to popper.
        static member inline hideWhenDetached ( value : bool ) : 'Property = Interop.mkProperty "hideWhenDetached" value

    /// The scrolling viewport that contains all of the items.
    type [<Erase>] viewport<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// The component that contains the select items.
    type [<Erase>] item<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// The value given as data when submitted with a name.
        static member inline value ( value : string ) : 'Property = Interop.mkProperty "value" value
        /// When true, prevents the user from interacting with the item.
        static member inline disabled ( value : bool ) : 'Property = Interop.mkProperty "disabled" value
        /// Optional text used for typeahead purposes. By default the typeahead behavior will use the .textContent of the Select.ItemText part. Use this when the content is complex, or you have non-textual content inside.
        static member inline textValue ( value : string ) : 'Property = Interop.mkProperty "textValue" value

    /// The textual part of the item. It should only contain the text you want to see in the trigger when that item is selected. It should not be styled to ensure correct positioning.
    type [<Erase>] itemText<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// Renders when the item is selected. You can style this element directly, or you can use it as a wrapper to put an icon into, or both.
    type [<Erase>] itemIndicator<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// An optional button used as an affordance to show the viewport overflow as well as functionaly enable scrolling upwards.
    type [<Erase>] scrollUpButton<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// An optional button used as an affordance to show the viewport overflow as well as functionaly enable scrolling downwards.
    type [<Erase>] scrollDownButton<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// Used to group multiple items. use in conjunction with Select.Label to ensure good accessibility via automatic labelling.
    type [<Erase>] group<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// Used to render the label of a group. It won't be focusable using arrow keys.
    type [<Erase>] label<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// Used to visually separate items in the select.
    type [<Erase>] separator<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// An optional arrow element to render alongside the content. This can be used to help visually link the trigger with the Select.Content. Must be rendered inside Select.Content. Only available when position is set to popper.
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
