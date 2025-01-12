namespace Feliz.RadixUI

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Interop.Extend
open Browser.Types


/// The provider that wraps your toasts and toast viewport. It usually wraps the application.
[<RequireQualifiedAccess>]
module [<Erase>] toastProvider =
    type [<Erase>] swipeDirection<'Property> =
        static member inline right : 'Property = Interop.mkProperty "swipeDirection" "right"
        static member inline left : 'Property = Interop.mkProperty "swipeDirection" "left"
        static member inline up : 'Property = Interop.mkProperty "swipeDirection" "up"
        static member inline down : 'Property = Interop.mkProperty "swipeDirection" "down"

/// The toast that automatically closes. It should not be held open to acquire a user response.
[<RequireQualifiedAccess>]
module [<Erase>] toastRoot =
    type [<Erase>] type'<'Property> =
        static member inline foreground : 'Property = Interop.mkProperty "type" "foreground"
        static member inline background : 'Property = Interop.mkProperty "type" "background"

/// A succinct message that is displayed temporarily.
[<RequireQualifiedAccess>]
module [<Erase>] Toast =
    /// The provider that wraps your toasts and toast viewport. It usually wraps the application.
    type [<Erase>] provider<'Property> =
        inherit prop<'Property>
        /// The time in milliseconds that should elapse before automatically closing each toast.
        static member inline duration ( value : int ) : 'Property = Interop.mkProperty "duration" value
        /// An author-localized label for each toast. Used to help screen reader users associate the interruption with a toast.
        static member inline label ( value : string ) : 'Property = Interop.mkProperty "label" value
        /// The direction of the pointer swipe that should close the toast.
        static member inline swipeThreshold ( value : int ) : 'Property = Interop.mkProperty "swipeThreshold" value

    /// The fixed area where toasts appear. Users can jump to the viewport by pressing a hotkey. It is up to you to ensure the discoverability of the hotkey for keyboard users.
    type [<Erase>] viewport<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// The keys to use as the keyboard shortcut that will move focus to the toast viewport. Use event.code value for each key from keycode.info. For meta keys, use ctrlKey, shiftKey, altKey and/or metaKey.
        static member inline hotkey ( value : string[] ) : 'Property = Interop.mkProperty "hotkey" value
        /// An author-localized label for the toast region to provide context for screen reader users when navigating page landmarks. The available `{hotkey}` placeholder will be replaced for you.
        static member inline label ( value : string ) : 'Property = Interop.mkProperty "label" value

    /// The toast that automatically closes. It should not be held open to acquire a user response.
    type [<Erase>] root<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// Control the sensitivity of the toast for accessibility purposes. For toasts that are the result of a user action, choose foreground. Toasts generated from background tasks should use background.
        static member inline duration ( value : int ) : 'Property = Interop.mkProperty "duration" value
        /// The open state of the dialog when it is initially rendered. Use when you do not need to control its open state.
        static member inline defaultOpen ( value : bool ) : 'Property = Interop.mkProperty "defaultOpen" value
        /// The controlled open state of the dialog. Must be used in conjunction with onOpenChange.
        static member inline open' ( value : bool ) : 'Property = Interop.mkProperty "open" value
        /// Event handler called when the open state of the dialog changes.
        static member inline onOpenChange ( value : (bool -> unit) ) : 'Property = Interop.mkProperty "onOpenChange" value
        /// Event handler called when the open state of the dialog changes.
        static member inline onEscapeKeyDown ( value : (Browser.Types.KeyboardEvent -> unit) ) : 'Property = Interop.mkProperty "onEscapeKeyDown" value
        /// Event handler called when the escape key is down. It can be prevented by calling event.preventDefault.
        static member inline onPause ( value : (unit -> unit) ) : 'Property = Interop.mkProperty "onPause" value
        /// Event handler called when the dismiss timer is paused. This occurs when the pointer is moved over the viewport, the viewport is focused or when the window is blurred.
        static member inline onResume ( value : (unit -> unit) ) : 'Property = Interop.mkProperty "onResume" value
        /// Event handler called when the dismiss timer is resumed. This occurs when the pointer is moved away from the viewport, the viewport is blurred or when the window is focused.
        static member inline onSwipeStart ( value : (UIEvent -> unit) ) : 'Property = Interop.mkProperty "onSwipeStart" value
        /// Event handler called when starting a swipe interaction. It can be prevented by calling event.preventDefault.
        static member inline onSwipeMove ( value : (UIEvent -> unit) ) : 'Property = Interop.mkProperty "onSwipeMove" value
        /// Event handler called during a swipe interaction. It can be prevented by calling event.preventDefault.
        static member inline onSwipeEnd ( value : (UIEvent -> unit) ) : 'Property = Interop.mkProperty "onSwipeEnd" value
        /// Event handler called at the end of a swipe interaction. It can be prevented by calling event.preventDefault.
        static member inline onSwipeCancel ( value : (UIEvent -> unit) ) : 'Property = Interop.mkProperty "onSwipeCancel" value
        /// Event handler called when a swipe interaction is cancelled. It can be prevented by calling event.preventDefault.
        static member inline forceMount ( value : bool ) : 'Property = Interop.mkProperty "forceMount" value

    /// An optional title for the toast.
    type [<Erase>] title<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// The toast message.
    type [<Erase>] description<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// A button that allows users to dismiss the toast before its duration has elapsed.
    type [<Erase>] close<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
