namespace Feliz.RadixUI

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Interop.Extend
open Browser.Types


/// A modal dialog that interrupts the user with important content and expects a response.
module [<Erase>] AlertDialog =
    /// import "AlertDialog" ""
    /// Contains all the parts of an alert dialog.
    type [<Erase>] root<'Property> =
        inherit prop<'Property>
        /// The open state of the dialog when it is initially rendered. Use when you do not need to control its open state.
        static member inline defaultOpen ( value : bool ) : 'Property = Interop.mkProperty "defaultOpen" value
        /// The controlled open state of the dialog. Must be used in conjunction with onOpenChange.
        static member inline open' ( value : bool ) : 'Property = Interop.mkProperty "open" value
        /// Event handler called when the open state of the dialog changes.
        static member inline onOpenChange ( value : (bool -> unit) ) : 'Property = Interop.mkProperty "onOpenChange" value

    /// import "AlertDialogTrigger" ""
    /// A button that opens the dialog.
    type [<Erase>] trigger<'Property> =
        inherit prop<'Property>
        /// Event handler called when the open state of the dialog changes.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// import "AlertDialogPortal" ""
    /// When used, portals your overlay and content parts into the body.
    type [<Erase>] portal<'Property> =
        inherit prop<'Property>
        /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries. If used on this part, it will be inherited by AlertDialog.Overlay and AlertDialog.Content.
        static member inline forceMount ( value : bool ) : 'Property = Interop.mkProperty "forceMount" value
        /// Specify a container element to portal the content into.
        static member inline container ( value : HTMLElement ) : 'Property = Interop.mkProperty "container" value

    /// import "AlertDialogOverlay" ""
    /// A layer that covers the inert portion of the view when the dialog is open.
    type [<Erase>] overlay<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries. It inherits from AlertDialog.Portal.
        static member inline forceMount ( value : bool ) : 'Property = Interop.mkProperty "forceMount" value

    /// import "AlertDialogContent" ""
    /// Contains content to be rendered when the dialog is open.
    type [<Erase>] content<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries. It inherits from AlertDialog.Portal.
        static member inline forceMount ( value : bool ) : 'Property = Interop.mkProperty "forceMount" value
        /// Event handler called when focus moves to the destructive action after opening. It can be prevented by calling event.preventDefault.
        static member inline onOpenAutoFocus ( value : (Browser.Types.Event -> unit) ) : 'Property = Interop.mkProperty "onOpenAutoFocus" value
        /// Event handler called when focus moves to the destructive action after opening. It can be prevented by calling event.preventDefault.
        static member inline onCloseAutoFocus ( value : (Browser.Types.Event -> unit) ) : 'Property = Interop.mkProperty "onCloseAutoFocus" value
        /// Event handler called when focus moves to the trigger after closing. It can be prevented by calling event.preventDefault.
        static member inline onEscapeKeyDown ( value : (Browser.Types.KeyboardEvent -> unit) ) : 'Property = Interop.mkProperty "onEscapeKeyDown" value

    /// import "AlertDialogCancel" ""
    /// A button that closes the dialog. This button should be distinguished visually from AlertDialog.Action buttons.
    type [<Erase>] cancel<'Property> =
        inherit prop<'Property>
        /// Event handler called when the escape key is down. It can be prevented by calling event.preventDefault.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// import "AlertDialogAction" ""
    /// A button that closes the dialog. These buttons should be distinguished visually from the AlertDialog.Cancel button.
    type [<Erase>] action<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// import "AlertDialogTitle" ""
    /// An accessible name to be announced when the dialog is opened. Alternatively, you can provide aria-label or aria-labelledby to AlertDialog.Content and exclude this component.
    type [<Erase>] title<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// import "AlertDialogDescription" ""
    /// An accessible description to be announced when the dialog is opened. Alternatively, you can provide aria-describedby to AlertDialog.Content and exclude this component.
    type [<Erase>] description<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
