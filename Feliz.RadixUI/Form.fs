namespace Feliz.RadixUI

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Interop.Extend
open Browser.Types


/// Collect information from your users using validation rules.
module [<Erase>] Form =
    /// import "Form" ""
    /// Contains all the parts of a form.
    type [<Erase>] root<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// Event handler called when the form is submitted or reset and the server errors need to be cleared.
        static member inline onClearServerErrors ( value : (unit -> unit) ) : 'Property = Interop.mkProperty "onClearServerErrors" value

    /// import "FormField" ""
    /// The wrapper for a field. It handles id/name and label accessibility automatically.
    type [<Erase>] field<'Property> =
        inherit prop<'Property>
        /// Event handler called when the form is submitted or reset and the server errors need to be cleared.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// The name of the field that will be passed down to the control and used to match with validation messages.
        static member inline name ( value : string ) : 'Property = Interop.mkProperty "name" value
        /// Use this prop to mark the field as invalid on the server.
        static member inline serverInvalid ( value : bool ) : 'Property = Interop.mkProperty "serverInvalid" value

    /// import "FormLabel" ""
    /// A label element which is automatically wired when nested inside a Field part.
    type [<Erase>] label<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// import "FormControl" ""
    /// A control element (by default an input) which is automatically wired when nested inside a Field part.
    type [<Erase>] control<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// import "FormValidityState" ""
    /// Use this render-prop component to access a given field’s validity state in render (see ValidityState on
    /// 
    /// MDN
    /// 
    /// ). A field's validity is available automatically when nested inside a Field part, otherwise you must pass a name prop to associate it.
    type [<Erase>] validityState<'Property> =
        inherit prop<'Property>
        /// A render function that receives the validity state of the field.
        static member inline children ( value : (ValidityState -> ReactElement) ) : 'Property = Interop.mkProperty "children" value
        /// A render function that receives the validity state of the field.
        static member inline name ( value : string ) : 'Property = Interop.mkProperty "name" value

    /// import "FormSubmit" ""
    /// The submit button.
    type [<Erase>] submit<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
