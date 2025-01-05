namespace Feliz.RadixUI

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Interop.Extend
open Browser.Types

module [<Erase>] image =
    [<StringEnum>]
    type [<Erase>] status =
        | Idle
        | Loading
        | Loaded
        | Error

/// An image element with a fallback for representing the user.
module [<Erase>] Avatar =
    /// import "Avatar" ""
    /// Contains all the parts of an avatar.
    type [<Erase>] root<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value

    /// import "AvatarImage" ""
    /// The image to render. By default it will only render when it has loaded. You can use the onLoadingStatusChange handler if you need more control.
    type [<Erase>] image<'Property> =
        inherit prop<'Property>
        /// Change the default rendered element for the one passed as a child, merging their props and behavior.
        ///  
        ///  Read our Composition guide for more details.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// A callback providing information about the loading status of the image. This is useful in case you want to control more precisely what to render as the image is loading.
        static member inline onLoadingStatusChange ( value : (string -> unit) ) : 'Property = Interop.mkProperty "onLoadingStatusChange" value
        /// A callback providing information about the loading status of the image. This is useful in case you want to control more precisely what to render as the image is loading.
        static member inline onLoadingStatusChange ( value : (image.status -> unit) ) : 'Property = Interop.mkProperty "onLoadingStatusChange" value

    /// import "AvatarFallback" ""
    /// An element that renders when the image hasn't loaded. This means whilst it's loading, or if there was an error. If you notice a flash during loading, you can provide a delayMs prop to delay its rendering so it only renders for those with slower connections. For more control, use the onLoadingStatusChange handler on Avatar.Image.
    type [<Erase>] fallback<'Property> =
        inherit prop<'Property>
        /// A callback providing information about the loading status of the image. This is useful in case you want to control more precisely what to render as the image is loading.
        static member inline asChild ( value : bool ) : 'Property = Interop.mkProperty "asChild" value
        /// Useful for delaying rendering so it only appears for those with slower connections.
        static member inline delayMs ( value : int ) : 'Property = Interop.mkProperty "delayMs" value

module [<Erase>] avatarimage =
    type [<Erase>] status<'Property> =
        static member inline idle : 'Property = Interop.mkProperty "status" "idle"
        static member inline loading : 'Property = Interop.mkProperty "status" "loading"
        static member inline loaded : 'Property = Interop.mkProperty "status" "loaded"
        static member inline error : 'Property = Interop.mkProperty "status" "error"
