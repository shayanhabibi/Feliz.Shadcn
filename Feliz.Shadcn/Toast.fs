namespace rec Feliz.Shadcn.Toast

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn
open Browser.Types


/// A succinct message that is displayed temporarily.
type [<Erase>] toast =
    /// The provider that wraps your toasts and toast viewport. It usually wraps the application.
    static member inline provider (props: IReactProperty seq) = createElement (import "ToastProvider" "@/components/ui/toast") props
    /// The fixed area where toasts appear. Users can jump to the viewport by pressing a hotkey. It is up to you to ensure the discoverability of the hotkey for keyboard users.
    static member inline viewport (props: IReactProperty seq) = createElement (import "ToastViewport" "@/components/ui/toast") props
    /// The toast that automatically closes. It should not be held open to acquire a user response.
    static member inline root (props: IReactProperty seq) = createElement (import "Toast" "@/components/ui/toast") props
    /// An optional title for the toast.
    static member inline title (props: IReactProperty seq) = createElement (import "ToastTitle" "@/components/ui/toast") props
    /// The toast message.
    static member inline description (props: IReactProperty seq) = createElement (import "ToastDescription" "@/components/ui/toast") props
    /// A button that allows users to dismiss the toast before its duration has elapsed.
    static member inline close (props: IReactProperty seq) = createElement (import "ToastClose" "@/components/ui/toast") props


/// The provider that wraps your toasts and toast viewport. It usually wraps the application.
type [<Erase>] provider =
    /// The time in milliseconds that should elapse before automatically closing each toast.
    static member inline duration (value: int) = Feliz.Interop.mkAttr "duration" value
    /// An author-localized label for each toast. Used to help screen reader users associate the interruption with a toast.
    static member inline label (value: string) = Feliz.Interop.mkAttr "label" value
    /// The direction of the pointer swipe that should close the toast.
    static member inline swipeThreshold (value: int) = Feliz.Interop.mkAttr "swipeThreshold" value


module provider =

    type [<Erase>] swipeDirection =
        static member inline right = Feliz.Interop.mkAttr "swipeDirection" "right"
        static member inline left = Feliz.Interop.mkAttr "swipeDirection" "left"
        static member inline up = Feliz.Interop.mkAttr "swipeDirection" "up"
        static member inline down = Feliz.Interop.mkAttr "swipeDirection" "down"



/// The fixed area where toasts appear. Users can jump to the viewport by pressing a hotkey. It is up to you to ensure the discoverability of the hotkey for keyboard users.
type [<Erase>] viewport =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// The keys to use as the keyboard shortcut that will move focus to the toast viewport. Use event.code value for each key from keycode.info. For meta keys, use ctrlKey, shiftKey, altKey and/or metaKey.
    static member inline hotkey (value: string[]) = Feliz.Interop.mkAttr "hotkey" value
    /// An author-localized label for the toast region to provide context for screen reader users when navigating page landmarks. The available `{hotkey}` placeholder will be replaced for you.
    static member inline label (value: string) = Feliz.Interop.mkAttr "label" value




/// The toast that automatically closes. It should not be held open to acquire a user response.
type [<Erase>] root =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// Control the sensitivity of the toast for accessibility purposes. For toasts that are the result of a user action, choose foreground. Toasts generated from background tasks should use background.
    static member inline duration (value: int) = Feliz.Interop.mkAttr "duration" value
    /// The open state of the dialog when it is initially rendered. Use when you do not need to control its open state.
    static member inline defaultOpen (value: bool) = Feliz.Interop.mkAttr "defaultOpen" value
    /// The controlled open state of the dialog. Must be used in conjunction with onOpenChange.
    static member inline open' (value: bool) = Feliz.Interop.mkAttr "open" value
    /// Event handler called when the open state of the dialog changes.
    static member inline onOpenChange (value: (bool -> unit)) = Feliz.Interop.mkAttr "onOpenChange" value
    /// Event handler called when the open state of the dialog changes.
    static member inline onEscapeKeyDown (value: (Browser.Types.KeyboardEvent -> unit)) = Feliz.Interop.mkAttr "onEscapeKeyDown" value
    /// Event handler called when the escape key is down. It can be prevented by calling event.preventDefault.
    static member inline onPause (value: (unit -> unit)) = Feliz.Interop.mkAttr "onPause" value
    /// Event handler called when the dismiss timer is paused. This occurs when the pointer is moved over the viewport, the viewport is focused or when the window is blurred.
    static member inline onResume (value: (unit -> unit)) = Feliz.Interop.mkAttr "onResume" value
    /// Event handler called when the dismiss timer is resumed. This occurs when the pointer is moved away from the viewport, the viewport is blurred or when the window is focused.
    static member inline onSwipeStart (value: (SwipeEvent -> unit)) = Feliz.Interop.mkAttr "onSwipeStart" value
    /// Event handler called when starting a swipe interaction. It can be prevented by calling event.preventDefault.
    static member inline onSwipeMove (value: (SwipeEvent -> unit)) = Feliz.Interop.mkAttr "onSwipeMove" value
    /// Event handler called during a swipe interaction. It can be prevented by calling event.preventDefault.
    static member inline onSwipeEnd (value: (SwipeEvent -> unit)) = Feliz.Interop.mkAttr "onSwipeEnd" value
    /// Event handler called at the end of a swipe interaction. It can be prevented by calling event.preventDefault.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value


module root =

    type [<Erase>] type' =
        static member inline foreground = Feliz.Interop.mkAttr "type" "foreground"
        static member inline background = Feliz.Interop.mkAttr "type" "background"



/// An optional title for the toast.
type [<Erase>] title =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// The toast message.
type [<Erase>] description =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// A button that allows users to dismiss the toast before its duration has elapsed.
type [<Erase>] close =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value



