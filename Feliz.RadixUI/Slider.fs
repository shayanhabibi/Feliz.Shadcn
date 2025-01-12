namespace Feliz.RadixUI

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Interop.Extend
open Browser.Types


/// Contains all the parts of a slider. It will render an input for each thumb when used within a form to ensure events propagate correctly.
[<RequireQualifiedAccess>]
module [<Erase>] sliderRoot =
    type [<Erase>] orientation<'Property> =
        static member inline horizontal : 'Property = Interop.mkProperty "orientation" "horizontal"
        static member inline vertical : 'Property = Interop.mkProperty "orientation" "vertical"

    type [<Erase>] dir<'Property> =
        static member inline ltr : 'Property = Interop.mkProperty "dir" "ltr"
        static member inline rtl : 'Property = Interop.mkProperty "dir" "rtl"

/// An input where the user selects a value from within a given range.
[<RequireQualifiedAccess>]
module [<Erase>] Slider =
    /// Contains all the parts of a slider. It will render an input for each thumb when used within a form to ensure events propagate correctly.
    type [<Erase>] root<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// The value of the slider when initially rendered. Use when you do not need to control the state of the slider.
        static member inline defaultValue ( value : int[] ) : 'Property = Interop.mkProperty "defaultValue" value
        /// The controlled value of the slider. Must be used in conjunction with onValueChange.
        static member inline value ( value : int[] ) : 'Property = Interop.mkProperty "value" value
        /// Event handler called when the value changes.
        static member inline onValueChange ( value : (int[] -> unit) ) : 'Property = Interop.mkProperty "onValueChange" value
        /// Event handler called when the value changes.
        static member inline onValueCommit ( value : (int[] -> unit) ) : 'Property = Interop.mkProperty "onValueCommit" value
        /// Event handler called when the value changes at the end of an interaction. Useful when you only need to capture a final value e.g. to update a backend service.
        static member inline name ( value : string ) : 'Property = Interop.mkProperty "name" value
        /// When true, prevents the user from interacting with the slider.
        static member inline disabled ( value : bool ) : 'Property = Interop.mkProperty "disabled" value
        /// The reading direction of the slider. If omitted, inherits globally from DirectionProvider or assumes LTR (left-to-right) reading mode.
        static member inline inverted ( value : bool ) : 'Property = Interop.mkProperty "inverted" value
        /// The minimum value for the range.
        static member inline min ( value : int ) : 'Property = Interop.mkProperty "min" value
        /// The maximum value for the range.
        static member inline max ( value : int ) : 'Property = Interop.mkProperty "max" value
        /// The stepping interval.
        static member inline step ( value : int ) : 'Property = Interop.mkProperty "step" value
        /// The minimum permitted steps between multiple thumbs.
        static member inline minStepsBetweenThumbs ( value : int ) : 'Property = Interop.mkProperty "minStepsBetweenThumbs" value
        /// The ID of the form that the slider belongs to. If omitted, the slider will be associated with a parent form if one exists.
        static member inline form ( value : string ) : 'Property = Interop.mkProperty "form" value

    /// The track that contains the Slider.Range.
    type [<Erase>] track<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// The range part. Must live inside Slider.Track.
    type [<Erase>] range<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// A draggable thumb. You can render multiple thumbs.
    type [<Erase>] thumb<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
