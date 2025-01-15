[<AutoOpen>]
module Feliz.Shadcn.Sonner

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI.Interface
open Microsoft.FSharp.Core
JSX.injectShadcnLib
ignore <| JSX.jsx """
import { useTheme } from "next-themes"
import { Toaster as Sonner } from "sonner"
"""

[<AllowNullLiteral>]
[<Global>]
type ToastIcons
    [<ParamObject; Emit("$0")>]
    (
        ?success : ReactElement,
        ?info : ReactElement,
        ?warning : ReactElement,
        ?error : ReactElement,
        ?loading : ReactElement,
        ?close : ReactElement
    ) =
    member val success : ReactElement option = jsNative with get,set
    member val info : ReactElement option = jsNative with get,set
    member val warning : ReactElement option = jsNative with get,set
    member val error : ReactElement option = jsNative with get,set
    member val loading : ReactElement option = jsNative with get,set
    member val close : ReactElement option = jsNative with get,set

[<AllowNullLiteral>]
[<Global>]
type ToastClassnames
    [<ParamObject; Emit("$0")>]
    (
        ?toast : string,
        ?title : string,
        ?description : string,
        ?loader : string,
        ?closeButton : string,
        ?cancelButton : string,
        ?actionButton : string,
        ?success : string,
        ?error : string,
        ?info : string,
        ?warning : string,
        ?loading : string,
        ?``default`` : string,
        ?content : string,
        ?icon : string
    ) =
    member val close : string option = jsNative with get,set
    member val toast : string option = jsNative with get,set
    member val title : string option = jsNative with get,set
    member val description : string option = jsNative with get,set
    member val loader : string option = jsNative with get,set
    member val closeButton : string option = jsNative with get,set
    member val cancelButton : string option = jsNative with get,set
    member val actionButton : string option = jsNative with get,set
    member val success : string option = jsNative with get,set
    member val error : string option = jsNative with get,set
    member val info : string option = jsNative with get,set
    member val warning : string option = jsNative with get,set
    member val loading : string option = jsNative with get,set
    member val ``default`` : string option = jsNative with get,set
    member val content : string option = jsNative with get,set
    member val icon : string option = jsNative with get,set

// --------------- Toaster -------------- //
type [<Erase>] IToasterProp = interface end
type [<Erase>] toaster =
    inherit prop<IToasterProp>
    static member inline invert ( value : bool ) : IToasterProp = Interop.mkProperty "invert" value
    static member inline hotkey ( value : string[] ) : IToasterProp = Interop.mkProperty "hotkey" value
    static member inline richColors ( value : bool ) : IToasterProp = Interop.mkProperty "richColors" value
    static member inline expand ( value : bool ) : IToasterProp = Interop.mkProperty "expand" value
    static member inline duration ( value : int ) : IToasterProp = Interop.mkProperty "duration" value
    static member inline gap ( value : int ) : IToasterProp = Interop.mkProperty "gap" value
    static member inline visibleToasts ( value : int ) : IToasterProp = Interop.mkProperty "visibleToasts" value
    static member inline closeButton ( value : bool ) : IToasterProp = Interop.mkProperty "closeButton" value
    static member inline toastOptions ( value : obj ) : IToasterProp = Interop.mkProperty "toastOptions" value
    static member inline offset ( value : int ) : IToasterProp = Interop.mkProperty "offset" value
    static member inline offset ( value : string ) : IToasterProp = Interop.mkProperty "offset" value
    static member inline icons ( value : ToastIcons ) : IToasterProp = Interop.mkProperty "icons" value
    static member inline containerAriaLabel ( value : string ) : IToasterProp = Interop.mkProperty "containerAriaLabel" value
    static member inline pauseWhenPageIsHidden ( value : bool ) : IToasterProp = Interop.mkProperty "pauseWhenPageIsHidden" value
    static member inline cn ( handler : string list -> string ) : IToasterProp = Interop.mkProperty "cn" handler

module [<Erase>] Toaster =
    type [<Erase>] theme =
        static member inline light : IToasterProp = Interop.mkProperty "theme" "light"
        static member inline dark : IToasterProp = Interop.mkProperty "theme" "dark"
        static member inline system : IToasterProp = Interop.mkProperty "theme" "system"
    type [<Erase>] position =
        static member inline topLeft : IToasterProp = Interop.mkProperty "theme" "top-left"
        static member inline topRight : IToasterProp = Interop.mkProperty "theme" "top-right"
        static member inline bottomLeft : IToasterProp = Interop.mkProperty "theme" "bottom-left"
        static member inline bottomRight : IToasterProp = Interop.mkProperty "theme" "bottom-right"
        static member inline topCenter : IToasterProp = Interop.mkProperty "theme" "top-center"
        static member inline bottomCenter : IToasterProp = Interop.mkProperty "theme" "bottom-center"
    type [<Erase>] dir =
        static member inline rtl : IToasterProp = Interop.mkProperty "dir" "rtl"
        static member inline ltr : IToasterProp = Interop.mkProperty "dir" "ltr"
        static member inline auto : IToasterProp = Interop.mkProperty "dir" "auto"
let Toaster : JSX.ElementType = JSX.jsx """
({
  ...props
}) => {
  const { theme = "system" } = useTheme()

  return (
    (<Sonner
      theme={theme}
      className="toaster group"
      toastOptions={{
        classNames: {
          toast:
            "group toast group-[.toaster]:bg-background group-[.toaster]:text-foreground group-[.toaster]:border-border group-[.toaster]:shadow-lg",
          description: "group-[.toast]:text-muted-foreground",
          actionButton:
            "group-[.toast]:bg-primary group-[.toast]:text-primary-foreground",
          cancelButton:
            "group-[.toast]:bg-muted group-[.toast]:text-muted-foreground",
        },
      }}
      {...props} />)
  );
}
"""

[<StringEnum ; RequireQualifiedAccess>]
type [<Erase>] Type =
    | Normal
    | Action
    | Success
    | Info
    | Warning
    | Error
    | Loading
    | Default

[<StringEnum(CaseRules.KebabCase) ; RequireQualifiedAccess>]
type [<Erase>] Position =
    | TopLeft
    | TopRight
    | BottomLeft
    | BottomRight
    | TopCenter
    | BottomCenter

[<AllowNullLiteral>]
[<Global>]
type Action
    [<ParamObject; Emit("$0")>]
    (
        label : ReactElement,
        onClick : Browser.Types.MouseEvent -> unit,
        ?actionButtonStyle : obj
    ) =
    member val label : ReactElement = jsNative with get,set
    member val onClick : Browser.Types.MouseEvent -> unit = jsNative with get,set
    member val actionButtonStyle : obj option = jsNative with get,set

[<AllowNullLiteral>]
[<Global>]
type Toast
    [<ParamObject; Emit("$0")>]
    (
        ?id : string,
        ?title : string,
        ?type' : Type,
        ?icon : ReactElement,
        ?jsx : ReactElement,
        ?richColors : bool,
        ?invert : bool,
        ?closeButton : bool,
        ?dismissible : bool,
        ?description : ReactElement,
        ?duration : int,
        ?delete : bool,
        ?action : Action,
        ?cancel : Action,
        ?onDismiss : Toast -> unit,
        ?onAutoClose : Toast -> unit,
        // ?promise : PromiseT,
        ?cancelButtonStyle : obj,
        ?actionButtonStyle : obj,
        ?style : obj,
        ?unstyled : bool,
        ?className : string,
        ?classNames : ToastClassnames,
        ?descriptionClassName : string,
        ?position : Position
    ) =
    member val id : string option = jsNative with get, set
    member val action : Action option = jsNative with get, set
    member val cancel : Action option = jsNative with get, set
    member val title : string option = jsNative with get, set
    member val type' : Type option = jsNative with get, set
    member val icon : ReactElement option = jsNative with get, set
    member val jsx : ReactElement option = jsNative with get, set
    member val description : ReactElement option = jsNative with get, set
    member val richColors : bool option = jsNative with get, set
    member val invert : bool option = jsNative with get, set
    member val closeButton : bool option = jsNative with get, set
    member val dismissible : bool option = jsNative with get, set
    member val delete : bool option = jsNative with get, set
    member val unstyled : bool option = jsNative with get, set
    member val duration : int option = jsNative with get, set
    member val onDismiss : Option<Toast -> unit> = jsNative with get, set
    member val onAutoClose : Option<Toast -> unit> = jsNative with get, set
    member val cancelButtonStyle : obj option = jsNative with get, set
    member val actionButtonStyle : obj option = jsNative with get, set
    member val style : obj option = jsNative with get, set
    member val className : string option = jsNative with get, set
    member val descriptionClassName : string option = jsNative with get, set
    member val position : Position option = jsNative with get, set
    member val classNames : ToastClassnames option = jsNative with get, set
  
[<RequireQualifiedAccess>]
type [<Erase>] Sonner =
    [<Import("toast","sonner")>]
    static member toast ( text : string , data : Toast ) : string = jsNative
    [<Import("toast","sonner")>]
    static member toast ( text : string) : string = jsNative
    [<Import("toast","sonner")>]
    static member toast ( ele : ReactElement , data : Toast) : string = jsNative
    [<Import("toast","sonner")>]
    static member toast ( ele : ReactElement ) : string = jsNative

[<RequireQualifiedAccess>]
module [<Erase>] Sonner =
    [<Import("toast","sonner")>]
    type [<Erase>] toast =
        static member success ( text : string ) : string = jsNative
        static member success ( text : string , data : Toast ) : string = jsNative
        static member info ( text : string ) : string = jsNative
        static member info ( text : string , data : Toast ) : string = jsNative
        static member warning ( text : string ) : string = jsNative
        static member warning ( text : string , data : Toast ) : string = jsNative
        static member error ( text : string ) : string = jsNative
        static member error ( text : string , data : Toast ) : string = jsNative
        static member message ( text : string ) : string = jsNative
        static member message ( text : string , data : Toast ) : string = jsNative
        static member loading ( text : string ) : string = jsNative
        static member loading ( text : string , data : Toast ) : string = jsNative
        static member dismiss ( id : string ) : unit = jsNative
        static member dismiss ( id : int ) : unit = jsNative
        static member dismiss () : unit = jsNative
        
type [<Erase>] Shadcn =
    static member inline Toaster ( props : IToasterProp list ) = JSX.createElement Toaster props
    static member inline Toaster ( children : ReactElement list ) = JSX.createElementWithChildren Toaster children
    static member inline Toaster ( ) = JSX.createElement Toaster []
    
