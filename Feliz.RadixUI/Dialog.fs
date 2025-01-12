namespace Feliz.RadixUI

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Interop.Extend
open Browser.Types


/// A window overlaid on either the primary window or another dialog window, rendering the content underneath inert.
[<RequireQualifiedAccess>]
module [<Erase>] Dialog =
    /// Contains all the parts of a dialog.
    type [<Erase>] root<'Property> =
        inherit prop<'Property>
        /// The open state of the dialog when it is initially rendered. Use when you do not need to control its open state.
        static member inline defaultOpen ( value : bool ) : 'Property = Interop.mkProperty "defaultOpen" value
        /// The controlled open state of the dialog. Must be used in conjunction with onOpenChange.
        static member inline open' ( value : bool ) : 'Property = Interop.mkProperty "open" value
        /// Event handler called when the open state of the dialog changes.
        static member inline onOpenChange ( value : (bool -> unit) ) : 'Property = Interop.mkProperty "onOpenChange" value
        /// Event handler called when the open state of the dialog changes.
        static member inline modal ( value : bool ) : 'Property = Interop.mkProperty "modal" value

    /// The button that opens the dialog.
    type [<Erase>] trigger<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// When used, portals your overlay and content parts into the body.
    type [<Erase>] portal<'Property> =
        inherit prop<'Property>
        /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries. If used on this part, it will be inherited by Dialog.Overlay and Dialog.Content.
        static member inline forceMount ( value : bool ) : 'Property = Interop.mkProperty "forceMount" value
        /// Specify a container element to portal the content into.
        static member inline container ( value : HTMLElement ) : 'Property = Interop.mkProperty "container" value

    /// A layer that covers the inert portion of the view when the dialog is open.
    type [<Erase>] overlay<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries. It inherits from Dialog.Portal.
        static member inline forceMount ( value : bool ) : 'Property = Interop.mkProperty "forceMount" value

    /// Contains content to be rendered in the open dialog.
    type [<Erase>] content<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries. It inherits from Dialog.Portal.
        static member inline forceMount ( value : bool ) : 'Property = Interop.mkProperty "forceMount" value
        /// Event handler called when focus moves into the component after opening. It can be prevented by calling event.preventDefault.
        static member inline onOpenAutoFocus ( value : (Browser.Types.Event -> unit) ) : 'Property = Interop.mkProperty "onOpenAutoFocus" value
        /// Event handler called when focus moves into the component after opening. It can be prevented by calling event.preventDefault.
        static member inline onCloseAutoFocus ( value : (Browser.Types.Event -> unit) ) : 'Property = Interop.mkProperty "onCloseAutoFocus" value
        /// Event handler called when focus moves to the trigger after closing. It can be prevented by calling event.preventDefault.
        static member inline onEscapeKeyDown ( value : (Browser.Types.KeyboardEvent -> unit) ) : 'Property = Interop.mkProperty "onEscapeKeyDown" value
        /// Event handler called when the escape key is down. It can be prevented by calling event.preventDefault.
        static member inline onPointerDownOutside ( value : (PointerEvent -> unit) ) : 'Property = Interop.mkProperty "onPointerDownOutside" value
        /// Event handler called when a pointer event occurs outside the bounds of the component. It can be prevented by calling event.preventDefault.
        static member inline onInteractOutside ( value : (Browser.Types.FocusEvent -> unit) ) : 'Property = Interop.mkProperty "onInteractOutside" value
        /// Event handler called when a pointer event occurs outside the bounds of the component. It can be prevented by calling event.preventDefault.
        static member inline onInteractOutside ( value : (Browser.Types.MouseEvent -> unit) ) : 'Property = Interop.mkProperty "onInteractOutside" value
        /// Event handler called when a pointer event occurs outside the bounds of the component. It can be prevented by calling event.preventDefault.
        static member inline onInteractOutside ( value : (Browser.Types.TouchEvent -> unit) ) : 'Property = Interop.mkProperty "onInteractOutside" value

    /// The button that closes the dialog.
    type [<Erase>] close<'Property> =
        inherit prop<'Property>
        /// Event handler called when an interaction (pointer or focus event) happens outside the bounds of the component. It can be prevented by calling event.preventDefault.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
