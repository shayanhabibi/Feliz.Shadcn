namespace rec Feliz.Shadcn.Select

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn
open Browser.Types


/// Displays a list of options for the user to pick from—triggered by a button.
type [<Erase>] select =
    /// Contains all the parts of a select.
    static member inline root (props: IReactProperty seq) = createElement (import "Select" "@/components/ui/select") props
    /// The button that toggles the select. The Select.Content will position itself by aligning over the trigger.
    static member inline trigger (props: IReactProperty seq) = createElement (import "SelectTrigger" "@/components/ui/select") props
    /// The part that reflects the selected value. By default the selected item's text will be rendered. if you require more control, you can instead control the select and pass your own children. It should not be styled to ensure correct positioning. An optional placeholder prop is also available for when the select has no value.
    static member inline value (props: IReactProperty seq) = createElement (import "SelectValue" "@/components/ui/select") props
    /// A small icon often displayed next to the value as a visual affordance for the fact it can be open. By default renders ▼ but you can use your own icon via asChild or use children.
    static member inline icon (props: IReactProperty seq) = createElement (import "SelectIcon" "@/components/ui/select") props
    /// When used, portals the content part into the body.
    static member inline portal (props: IReactProperty seq) = createElement (import "SelectPortal" "@/components/ui/select") props
    /// The component that pops out when the select is open.
    static member inline content (props: IReactProperty seq) = createElement (import "SelectContent" "@/components/ui/select") props
    /// The scrolling viewport that contains all of the items.
    static member inline viewport (props: IReactProperty seq) = createElement (import "SelectViewport" "@/components/ui/select") props
    /// The component that contains the select items.
    static member inline item (props: IReactProperty seq) = createElement (import "SelectItem" "@/components/ui/select") props
    /// The textual part of the item. It should only contain the text you want to see in the trigger when that item is selected. It should not be styled to ensure correct positioning.
    static member inline itemText (props: IReactProperty seq) = createElement (import "SelectItemText" "@/components/ui/select") props
    /// Renders when the item is selected. You can style this element directly, or you can use it as a wrapper to put an icon into, or both.
    static member inline itemIndicator (props: IReactProperty seq) = createElement (import "SelectItemIndicator" "@/components/ui/select") props
    /// An optional button used as an affordance to show the viewport overflow as well as functionaly enable scrolling upwards.
    static member inline scrollUpButton (props: IReactProperty seq) = createElement (import "SelectScrollUpButton" "@/components/ui/select") props
    /// An optional button used as an affordance to show the viewport overflow as well as functionaly enable scrolling downwards.
    static member inline scrollDownButton (props: IReactProperty seq) = createElement (import "SelectScrollDownButton" "@/components/ui/select") props
    /// Used to group multiple items. use in conjunction with Select.Label to ensure good accessibility via automatic labelling.
    static member inline group (props: IReactProperty seq) = createElement (import "SelectGroup" "@/components/ui/select") props
    /// Used to render the label of a group. It won't be focusable using arrow keys.
    static member inline label (props: IReactProperty seq) = createElement (import "SelectLabel" "@/components/ui/select") props
    /// Used to visually separate items in the select.
    static member inline separator (props: IReactProperty seq) = createElement (import "SelectSeparator" "@/components/ui/select") props
    /// An optional arrow element to render alongside the content. This can be used to help visually link the trigger with the Select.Content. Must be rendered inside Select.Content. Only available when position is set to popper.
    static member inline arrow (props: IReactProperty seq) = createElement (import "SelectArrow" "@/components/ui/select") props


/// Contains all the parts of a select.
type [<Erase>] root =
    /// The value of the select when initially rendered. Use when you do not need to control the state of the select.
    static member inline defaultValue (value: string) = Feliz.Interop.mkAttr "defaultValue" value
    /// The controlled value of the select. Should be used in conjunction with onValueChange.
    static member inline value (value: string) = Feliz.Interop.mkAttr "value" value
    /// Event handler called when the value changes.
    static member inline onValueChange (value: (string -> unit)) = Feliz.Interop.mkAttr "onValueChange" value
    /// Event handler called when the value changes.
    static member inline defaultOpen (value: bool) = Feliz.Interop.mkAttr "defaultOpen" value
    /// The controlled open state of the select. Must be used in conjunction with onOpenChange.
    static member inline open' (value: bool) = Feliz.Interop.mkAttr "open" value
    /// Event handler called when the open state of the select changes.
    static member inline onOpenChange (value: (bool -> unit)) = Feliz.Interop.mkAttr "onOpenChange" value
    /// The reading direction of the select when applicable. If omitted, inherits globally from DirectionProvider or assumes LTR (left-to-right) reading mode.
    static member inline name (value: string) = Feliz.Interop.mkAttr "name" value
    /// When true, prevents the user from interacting with select.
    static member inline disabled (value: bool) = Feliz.Interop.mkAttr "disabled" value
    /// When true, indicates that the user must select a value before the owning form can be submitted.
    static member inline required (value: bool) = Feliz.Interop.mkAttr "required" value


module root =

    type [<Erase>] dir =
        static member inline ltr = Feliz.Interop.mkAttr "dir" "ltr"
        static member inline rtl = Feliz.Interop.mkAttr "dir" "rtl"



/// The button that toggles the select. The Select.Content will position itself by aligning over the trigger.
type [<Erase>] trigger =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// The part that reflects the selected value. By default the selected item's text will be rendered. if you require more control, you can instead control the select and pass your own children. It should not be styled to ensure correct positioning. An optional placeholder prop is also available for when the select has no value.
type [<Erase>] value =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// The content that will be rendered inside the Select.Value when no value or defaultValue is set.
    static member inline placeholder (value: ReactElement) = Feliz.Interop.mkAttr "placeholder" value




/// A small icon often displayed next to the value as a visual affordance for the fact it can be open. By default renders ▼ but you can use your own icon via asChild or use children.
type [<Erase>] icon =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// When used, portals the content part into the body.
type [<Erase>] portal =
    /// Specify a container element to portal the content into.
    static member inline container (value: HTMLElement) = Feliz.Interop.mkAttr "container" value




/// The component that pops out when the select is open.
type [<Erase>] content =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// Event handler called when focus moves to the trigger after closing. It can be prevented by calling event.preventDefault.
    static member inline onCloseAutoFocus (value: (Browser.Types.Event -> unit)) = Feliz.Interop.mkAttr "onCloseAutoFocus" value
    /// Event handler called when focus moves to the trigger after closing. It can be prevented by calling event.preventDefault.
    static member inline onEscapeKeyDown (value: (Browser.Types.KeyboardEvent -> unit)) = Feliz.Interop.mkAttr "onEscapeKeyDown" value
    /// Event handler called when the escape key is down. It can be prevented by calling event.preventDefault.
    static member inline onPointerDownOutside (value: (PointerDownOutsideEvent -> unit)) = Feliz.Interop.mkAttr "onPointerDownOutside" value
    /// The preferred side of the anchor to render against when open. Will be reversed when collisions occur and avoidCollisions is enabled. Only available when position is set to popper.
    static member inline sideOffset (value: int) = Feliz.Interop.mkAttr "sideOffset" value
    /// The preferred alignment against the anchor. May change when collisions occur. Only available when position is set to popper.
    static member inline alignOffset (value: int) = Feliz.Interop.mkAttr "alignOffset" value
    /// When true, overrides the side andalign preferences to prevent collisions with boundary edges. Only available when position is set to popper.
    static member inline avoidCollisions (value: bool) = Feliz.Interop.mkAttr "avoidCollisions" value
    /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check. Only available when position is set to popper.
    static member inline collisionBoundary (value: ReactElement) = Feliz.Interop.mkAttr "collisionBoundary" value
    /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check. Only available when position is set to popper.
    static member inline collisionBoundary (value: ReactElement[]) = Feliz.Interop.mkAttr "collisionBoundary" value
    /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check. Only available when position is set to popper.
    static member inline collisionPadding (value: int) = Feliz.Interop.mkAttr "collisionPadding" value
    /// The element used as the collision boundary. By default this is the viewport, though you can provide additional element(s) to be included in this check. Only available when position is set to popper.
    static member inline collisionPadding (value: 'T) = Feliz.Interop.mkAttr "collisionPadding" value
    /// The distance in pixels from the boundary edges where collision detection should occur. Accepts a number (same for all sides), or a partial padding object, for example: { top: 20, left: 20 }. Only available when position is set to popper.
    static member inline arrowPadding (value: int) = Feliz.Interop.mkAttr "arrowPadding" value
    /// The sticky behavior on the align axis. "partial" will keep the content in the boundary as long as the trigger is at least partially in the boundary whilst "always" will keep the content in the boundary regardless. Only available when position is set to popper.
    static member inline hideWhenDetached (value: bool) = Feliz.Interop.mkAttr "hideWhenDetached" value


module content =

    type [<Erase>] position =
        static member inline itemAligned = Feliz.Interop.mkAttr "position" "item-aligned"
        static member inline popper = Feliz.Interop.mkAttr "position" "popper"

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



/// The scrolling viewport that contains all of the items.
type [<Erase>] viewport =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// The component that contains the select items.
type [<Erase>] item =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// The value given as data when submitted with a name.
    static member inline value (value: string) = Feliz.Interop.mkAttr "value" value
    /// When true, prevents the user from interacting with the item.
    static member inline disabled (value: bool) = Feliz.Interop.mkAttr "disabled" value
    /// Optional text used for typeahead purposes. By default the typeahead behavior will use the .textContent of the Select.ItemText part. Use this when the content is complex, or you have non-textual content inside.
    static member inline textValue (value: string) = Feliz.Interop.mkAttr "textValue" value




/// The textual part of the item. It should only contain the text you want to see in the trigger when that item is selected. It should not be styled to ensure correct positioning.
type [<Erase>] itemText =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// Renders when the item is selected. You can style this element directly, or you can use it as a wrapper to put an icon into, or both.
type [<Erase>] itemIndicator =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// An optional button used as an affordance to show the viewport overflow as well as functionaly enable scrolling upwards.
type [<Erase>] scrollUpButton =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// An optional button used as an affordance to show the viewport overflow as well as functionaly enable scrolling downwards.
type [<Erase>] scrollDownButton =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// Used to group multiple items. use in conjunction with Select.Label to ensure good accessibility via automatic labelling.
type [<Erase>] group =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// Used to render the label of a group. It won't be focusable using arrow keys.
type [<Erase>] label =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// Used to visually separate items in the select.
type [<Erase>] separator =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// An optional arrow element to render alongside the content. This can be used to help visually link the trigger with the Select.Content. Must be rendered inside Select.Content. Only available when position is set to popper.
type [<Erase>] arrow =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// The width of the arrow in pixels.
    static member inline width (value: int) = Feliz.Interop.mkAttr "width" value
    /// The height of the arrow in pixels.
    static member inline height (value: int) = Feliz.Interop.mkAttr "height" value



