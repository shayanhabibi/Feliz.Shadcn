namespace rec Feliz.Shadcn.Avatar

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Shadcn
open Browser.Types


/// An image element with a fallback for representing the user.
type [<Erase>] avatar =
    /// Contains all the parts of an avatar.
    static member inline root (props: IReactProperty seq) = createElement (import "Avatar" "@/components/ui/avatar") props
    /// The image to render. By default it will only render when it has loaded. You can use the onLoadingStatusChange handler if you need more control.
    static member inline image (props: IReactProperty seq) = createElement (import "AvatarImage" "@/components/ui/avatar") props
    /// An element that renders when the image hasn't loaded. This means whilst it's loading, or if there was an error. If you notice a flash during loading, you can provide a delayMs prop to delay its rendering so it only renders for those with slower connections. For more control, use the onLoadingStatusChange handler on Avatar.Image.
    static member inline fallback (props: IReactProperty seq) = createElement (import "AvatarFallback" "@/components/ui/avatar") props


/// Contains all the parts of an avatar.
type [<Erase>] root =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value




/// The image to render. By default it will only render when it has loaded. You can use the onLoadingStatusChange handler if you need more control.
type [<Erase>] image =
    /// Change the default rendered element for the one passed as a child, merging their props and behavior.  Read our Composition guide for more details.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// A callback providing information about the loading status of the image. This is useful in case you want to control more precisely what to render as the image is loading.
    static member inline onLoadingStatusChange (value: (string -> unit)) = Feliz.Interop.mkAttr "onLoadingStatusChange" value
    /// A callback providing information about the loading status of the image. This is useful in case you want to control more precisely what to render as the image is loading.
    static member inline onLoadingStatusChange (value: (image.status -> unit)) = Feliz.Interop.mkAttr "onLoadingStatusChange" value


module image =

    type [<Erase>] status =
        static member inline idle = Feliz.Interop.mkAttr "status" "idle"
        static member inline loading = Feliz.Interop.mkAttr "status" "loading"
        static member inline loaded = Feliz.Interop.mkAttr "status" "loaded"
        static member inline error = Feliz.Interop.mkAttr "status" "error"



/// An element that renders when the image hasn't loaded. This means whilst it's loading, or if there was an error. If you notice a flash during loading, you can provide a delayMs prop to delay its rendering so it only renders for those with slower connections. For more control, use the onLoadingStatusChange handler on Avatar.Image.
type [<Erase>] fallback =
    /// A callback providing information about the loading status of the image. This is useful in case you want to control more precisely what to render as the image is loading.
    static member inline asChild (value: bool) = Feliz.Interop.mkAttr "asChild" value
    /// Useful for delaying rendering so it only appears for those with slower connections.
    static member inline delayMs (value: int) = Feliz.Interop.mkAttr "delayMs" value



