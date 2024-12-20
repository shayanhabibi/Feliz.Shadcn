namespace rec Feliz.Shadcn.Dialog

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn
open Browser.Types


/// A window overlaid on either the primary window or another dialog window, rendering the content underneath inert.
type [<Erase>] dialog =
    /// Contains all the parts of a dialog.
    static member inline root (props: IReactProperty seq) = createElement (import "Dialog" "@/components/ui/dialog") props
    /// The button that opens the dialog.
    static member inline trigger (props: IReactProperty seq) = createElement (import "DialogTrigger" "@/components/ui/dialog") props
    /// When used, portals your overlay and content parts into the body.
    static member inline portal (props: IReactProperty seq) = createElement (import "DialogPortal" "@/components/ui/dialog") props
    /// A layer that covers the inert portion of the view when the dialog is open.
    static member inline overlay (props: IReactProperty seq) = createElement (import "DialogOverlay" "@/components/ui/dialog") props
    /// Contains content to be rendered in the open dialog.
    static member inline content (props: IReactProperty seq) = createElement (import "DialogContent" "@/components/ui/dialog") props
    /// The button that closes the dialog.
    static member inline close (props: IReactProperty seq) = createElement (import "DialogClose" "@/components/ui/dialog") props


/// Contains all the parts of a dialog.
type [<Erase>] root =
    /// The open state of the dialog when it is initially rendered. Use when you do not need to control its open state.
    static member inline defaultOpen (value: bool) = Feliz.Interop.mkAttr "defaultOpen" value
    /// The controlled open state of the dialog. Must be used in conjunction with onOpenChange.
    static member inline open' (value: bool) = Feliz.Interop.mkAttr "open" value
    /// Event handler called when the open state of the dialog changes.
    static member inline onOpenChange (value: (bool -> unit)) = Feliz.Interop.mkAttr "onOpenChange" value
    /// Event handler called when the open state of the dialog changes.
    static member inline modal (value: bool) = Feliz.Interop.mkAttr "modal" value




/// The button that opens the dialog.
type [<Erase>] trigger =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// When used, portals your overlay and content parts into the body.
type [<Erase>] portal =
    /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries. If used on this part, it will be inherited by Dialog.Overlay and Dialog.Content.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value
    /// Specify a container element to portal the content into.
    static member inline container (value: HTMLElement) = Feliz.Interop.mkAttr "container" value




/// A layer that covers the inert portion of the view when the dialog is open.
type [<Erase>] overlay =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries. It inherits from Dialog.Portal.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value




/// Contains content to be rendered in the open dialog.
type [<Erase>] content =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// Used to force mounting when more control is needed. Useful when controlling animation with React animation libraries. It inherits from Dialog.Portal.
    static member inline forceMount (value: bool) = Feliz.Interop.mkAttr "forceMount" value
    /// Event handler called when focus moves into the component after opening. It can be prevented by calling event.preventDefault.
    static member inline onOpenAutoFocus (value: (Browser.Types.Event -> unit)) = Feliz.Interop.mkAttr "onOpenAutoFocus" value
    /// Event handler called when focus moves into the component after opening. It can be prevented by calling event.preventDefault.
    static member inline onCloseAutoFocus (value: (Browser.Types.Event -> unit)) = Feliz.Interop.mkAttr "onCloseAutoFocus" value
    /// Event handler called when focus moves to the trigger after closing. It can be prevented by calling event.preventDefault.
    static member inline onEscapeKeyDown (value: (Browser.Types.KeyboardEvent -> unit)) = Feliz.Interop.mkAttr "onEscapeKeyDown" value
    /// Event handler called when the escape key is down. It can be prevented by calling event.preventDefault.
    static member inline onPointerDownOutside (value: (PointerDownOutsideEvent -> unit)) = Feliz.Interop.mkAttr "onPointerDownOutside" value
    /// Event handler called when a pointer event occurs outside the bounds of the component. It can be prevented by calling event.preventDefault.
    static member inline onInteractOutside (value: (Browser.Types.FocusEvent -> unit)) = Feliz.Interop.mkAttr "onInteractOutside" value
    /// Event handler called when a pointer event occurs outside the bounds of the component. It can be prevented by calling event.preventDefault.
    static member inline onInteractOutside (value: (Browser.Types.MouseEvent -> unit)) = Feliz.Interop.mkAttr "onInteractOutside" value
    /// Event handler called when a pointer event occurs outside the bounds of the component. It can be prevented by calling event.preventDefault.
    static member inline onInteractOutside (value: (Browser.Types.TouchEvent -> unit)) = Feliz.Interop.mkAttr "onInteractOutside" value




/// The button that closes the dialog.
type [<Erase>] close =
    /// Event handler called when an interaction (pointer or focus event) happens outside the bounds of the component. It can be prevented by calling event.preventDefault.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value



