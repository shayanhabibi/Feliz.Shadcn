module Feliz.Shadcn.Toaster

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.Shadcn.Hooks
JSX.injectShadcnLib
let imports = (
    useToast,
    Toast,
    ToastClose,
    ToastDescription,
    ToastProvider,
    ToastTitle,
    ToastViewport
    )

let Toaster ()  = ignore <| JSX.jsx """
  const { toasts } = useToast()

  return (
    (<ToastProvider>
      {toasts.map(function ({ id, title, description, action, ...props }) {
        return (
          (<Toast key={id} {...props}>
            <div className="grid gap-1">
              {title && <ToastTitle>{title}</ToastTitle>}
              {description && (
                <ToastDescription>{description}</ToastDescription>
              )}
            </div>
            {action}
            <ToastClose />
          </Toast>)
        );
      })}
      <ToastViewport />
    </ToastProvider>)
  );

"""

[<RequireQualifiedAccess>]
module [<Erase>] Shadcn =
    type [<Erase>] toaster =
        // Provide an anonymous record or object with an
        // id, title, description, action, and any other props
        [<Emit("Toaster($0)")>]
        static member inline toast ( object : 'T ) : obj = jsNative

let v = Shadcn.toaster.toast {| id=0 |}