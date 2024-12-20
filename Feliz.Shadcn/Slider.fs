namespace rec Feliz.Shadcn.Slider

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn
open Browser.Types


/// An input where the user selects a value from within a given range.
type [<Erase>] slider =
    /// Contains all the parts of a slider. It will render an input for each thumb when used within a form to ensure events propagate correctly.
    static member inline root (props: IReactProperty seq) = createElement (import "Slider" "@/components/ui/slider") props
    /// The track that contains the Slider.Range.
    static member inline track (props: IReactProperty seq) = createElement (import "SliderTrack" "@/components/ui/slider") props
    /// The range part. Must live inside Slider.Track.
    static member inline range (props: IReactProperty seq) = createElement (import "SliderRange" "@/components/ui/slider") props
    /// A draggable thumb. You can render multiple thumbs.
    static member inline thumb (props: IReactProperty seq) = createElement (import "SliderThumb" "@/components/ui/slider") props


/// Contains all the parts of a slider. It will render an input for each thumb when used within a form to ensure events propagate correctly.
type [<Erase>] root =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// The value of the slider when initially rendered. Use when you do not need to control the state of the slider.
    static member inline defaultValue (value: int[]) = Feliz.Interop.mkAttr "defaultValue" value
    /// The controlled value of the slider. Must be used in conjunction with onValueChange.
    static member inline value (value: int[]) = Feliz.Interop.mkAttr "value" value
    /// Event handler called when the value changes.
    static member inline onValueChange (value: (int[] -> unit)) = Feliz.Interop.mkAttr "onValueChange" value
    /// Event handler called when the value changes.
    static member inline onValueCommit (value: (int[] -> unit)) = Feliz.Interop.mkAttr "onValueCommit" value
    /// Event handler called when the value changes at the end of an interaction. Useful when you only need to capture a final value e.g. to update a backend service.
    static member inline name (value: string) = Feliz.Interop.mkAttr "name" value
    /// When true, prevents the user from interacting with the slider.
    static member inline disabled (value: bool) = Feliz.Interop.mkAttr "disabled" value
    /// The reading direction of the slider. If omitted, inherits globally from DirectionProvider or assumes LTR (left-to-right) reading mode.
    static member inline inverted (value: bool) = Feliz.Interop.mkAttr "inverted" value
    /// The minimum value for the range.
    static member inline min (value: int) = Feliz.Interop.mkAttr "min" value
    /// The maximum value for the range.
    static member inline max (value: int) = Feliz.Interop.mkAttr "max" value
    /// The stepping interval.
    static member inline step (value: int) = Feliz.Interop.mkAttr "step" value
    /// The minimum permitted steps between multiple thumbs.
    static member inline minStepsBetweenThumbs (value: int) = Feliz.Interop.mkAttr "minStepsBetweenThumbs" value


module root =

    type [<Erase>] orientation =
        static member inline horizontal = Feliz.Interop.mkAttr "orientation" "horizontal"
        static member inline vertical = Feliz.Interop.mkAttr "orientation" "vertical"

    type [<Erase>] dir =
        static member inline ltr = Feliz.Interop.mkAttr "dir" "ltr"
        static member inline rtl = Feliz.Interop.mkAttr "dir" "rtl"



/// The track that contains the Slider.Range.
type [<Erase>] track =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// The range part. Must live inside Slider.Track.
type [<Erase>] range =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// A draggable thumb. You can render multiple thumbs.
type [<Erase>] thumb =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value



