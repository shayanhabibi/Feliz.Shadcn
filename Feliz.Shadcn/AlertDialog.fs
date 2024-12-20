namespace rec Feliz.Shadcn.AlertDialog

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn
open Browser.Types


/// A modal dialog that interrupts the user with important content and expects a response.
type [<Erase>] alertDialog =
    /// Contains all the parts of an alert dialog.
    static member inline root (props: IReactProperty seq) = createElement (import "AlertDialog" "@/components/ui/alert-dialog") props
    /// A button that opens the dialog.
    static member inline trigger (props: IReactProperty seq) = createElement (import "AlertDialogTrigger" "@/components/ui/alert-dialog") props
    /// When used, portals your overlay and content parts into the body.
    static member inline portal (props: IReactProperty seq) = createElement (import "AlertDialogPortal" "@/components/ui/alert-dialog") props
    /// A layer that covers the inert portion of the view when the dialog is open.
    static member inline overlay (props: IReactProperty seq) = createElement (import "AlertDialogOverlay" "@/components/ui/alert-dialog") props
    /// Contains content to be rendered when the dialog is open.
    static member inline content (props: IReactProperty seq) = createElement (import "AlertDialogContent" "@/components/ui/alert-dialog") props
    /// A button that closes the dialog. This button should be distinguished visually from AlertDialog.Action buttons.
    static member inline cancel (props: IReactProperty seq) = createElement (import "AlertDialogCancel" "@/components/ui/alert-dialog") props
    /// A button that closes the dialog. These buttons should be distinguished visually from the AlertDialog.Cancel button.
    static member inline action (props: IReactProperty seq) = createElement (import "AlertDialogAction" "@/components/ui/alert-dialog") props
    /// An accessible name to be announced when the dialog is opened. Alternatively, you can provide aria-label or aria-labelledby to AlertDialog.Content and exclude this component.
    static member inline title (props: IReactProperty seq) = createElement (import "AlertDialogTitle" "@/components/ui/alert-dialog") props
    /// An accessible description to be announced when the dialog is opened. Alternatively, you can provide aria-describedby to AlertDialog.Content and exclude this component.
    static member inline description (props: IReactProperty seq) = createElement (import "AlertDialogDescription" "@/components/ui/alert-dialog") props


/// Contains all the parts of an alert dialog.
type [<Erase>] root =
    /// The open state of the dialog when it is initially rendered. Use when you do not need to control its open state.
    static member inline defaultOpen (value: bool) = Feliz.Interop.mkAttr "defaultOpen" value
    /// The controlled open state of the dialog. Must be used in conjunction with onOpenChange.
    static member inline open' (value: bool) = Feliz.Interop.mkAttr "open" value
    /// Event handler called when the open state of the dialog changes.
    static member inline onOpenChange (value: (bool -> unit)) = Feliz.Interop.mkAttr "onOpenChange" value




/// A button that opens the dialog.
type [<Erase>] trigger =
    /// Event handler called when the open state of the dialog changes.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// When used, portals your overlay and content parts into the body.
type [<Erase>] portal =
    /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries. If used on this part, it will be inherited by AlertDialog.Overlay and AlertDialog.Content.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value
    /// Specify a container element to portal the content into.
    static member inline container (value: HTMLElement) = Feliz.Interop.mkAttr "container" value




/// A layer that covers the inert portion of the view when the dialog is open.
type [<Erase>] overlay =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries. It inherits from AlertDialog.Portal.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value




/// Contains content to be rendered when the dialog is open.
type [<Erase>] content =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries. It inherits from AlertDialog.Portal.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value
    /// Event handler called when focus moves to the destructive action after opening. It can be prevented by calling event.preventDefault.
    static member inline onOpenAutoFocus (value: (Browser.Types.Event -> unit)) = Feliz.Interop.mkAttr "onOpenAutoFocus" value
    /// Event handler called when focus moves to the destructive action after opening. It can be prevented by calling event.preventDefault.
    static member inline onCloseAutoFocus (value: (Browser.Types.Event -> unit)) = Feliz.Interop.mkAttr "onCloseAutoFocus" value
    /// Event handler called when focus moves to the trigger after closing. It can be prevented by calling event.preventDefault.
    static member inline onEscapeKeyDown (value: (Browser.Types.KeyboardEvent -> unit)) = Feliz.Interop.mkAttr "onEscapeKeyDown" value




/// A button that closes the dialog. This button should be distinguished visually from AlertDialog.Action buttons.
type [<Erase>] cancel =
    /// Event handler called when the escape key is down. It can be prevented by calling event.preventDefault.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// A button that closes the dialog. These buttons should be distinguished visually from the AlertDialog.Cancel button.
type [<Erase>] action =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// An accessible name to be announced when the dialog is opened. Alternatively, you can provide aria-label or aria-labelledby to AlertDialog.Content and exclude this component.
type [<Erase>] title =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// An accessible description to be announced when the dialog is opened. Alternatively, you can provide aria-describedby to AlertDialog.Content and exclude this component.
type [<Erase>] description =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value



