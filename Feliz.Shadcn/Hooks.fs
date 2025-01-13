module Feliz.Shadcn.Hooks

open Fable.Core

let private MOBILE_BREAKPOINT = 768

let useIsMobile () = JSX.jsx """
import * as React from "react";

{
  const [isMobile, setIsMobile] = React.useState(undefined)

  React.useEffect(() => {
    const mql = window.matchMedia(`(max-width: ${MOBILE_BREAKPOINT - 1}px)`)
    const onChange = () => {
      setIsMobile(window.innerWidth < MOBILE_BREAKPOINT)
    }
    mql.addEventListener("change", onChange)
    setIsMobile(window.innerWidth < MOBILE_BREAKPOINT)
    return () => mql.removeEventListener("change", onChange);
  }, [])

  return !!isMobile
}"""

(*
        use-toast.js
*)

let private TOAST_LIMIT = 1
let private TOAST_REMOVE_DELAY = 1_000_000
let private actionTypes = {|
      ADD_TOAST = "ADD_TOAST"                          
      UPDATE_TOAST = "UPDATE_TOAST"                          
      DISMISS_TOAST = "DISMISS_TOAST"                          
      REMOVE_TOAST = "REMOVE_TOAST"                          
  |}

let mutable private count = 0

let genId () = ignore <| JSX.jsx """{
  count = (count + 1) % Number.MAX_SAFE_INTEGER
  return count.toString();
}"""

let private toastTimeouts = JSX.jsx "new Map()"

let private addToRemoveQueue = JSX.jsx """
(toastId) => {
  if (toastTimeouts.has(toastId)) {
    return
  }

  const timeout = setTimeout(() => {
    toastTimeouts.delete(toastId)
    dispatch({
      type: "REMOVE_TOAST",
      toastId: toastId,
    })
  }, TOAST_REMOVE_DELAY)

  toastTimeouts.set(toastId, timeout)
}
"""

let reducer = JSX.jsx """
(state, action) => {
  switch (action.type) {
    case "ADD_TOAST":
      return {
        ...state,
        toasts: [action.toast, ...state.toasts].slice(0, TOAST_LIMIT),
      };

    case "UPDATE_TOAST":
      return {
        ...state,
        toasts: state.toasts.map((t) =>
          t.id === action.toast.id ? { ...t, ...action.toast } : t),
      };

    case "DISMISS_TOAST": {
      const { toastId } = action

      // ! Side effects ! - This could be extracted into a dismissToast() action,
      // but I'll keep it here for simplicity
      if (toastId) {
        addToRemoveQueue(toastId)
      } else {
        state.toasts.forEach((toast) => {
          addToRemoveQueue(toast.id)
        })
      }

      return {
        ...state,
        toasts: state.toasts.map((t) =>
          t.id === toastId || toastId === undefined
            ? {
                ...t,
                open: false,
              }
            : t),
      };
    }
    case "REMOVE_TOAST":
      if (action.toastId === undefined) {
        return {
          ...state,
          toasts: [],
        }
      }
      return {
        ...state,
        toasts: state.toasts.filter((t) => t.id !== action.toastId),
      };
  }
}
"""

let private listeners = JSX.jsx "[]"
let mutable private memoryState : {| toasts : obj list |} = {| toasts = [] |}

let dispatch action = ignore <| JSX.jsx """
{
  memoryState = reducer(memoryState, action)
  listeners.forEach((listener) => {
    listener(memoryState)
  })
}
"""

let toast : JSX.ElementType = JSX.jsx """
({
  ...props
}) => {
  const id = genId()

  const update = (props) =>
    dispatch({
      type: "UPDATE_TOAST",
      toast: { ...props, id },
    })
  const dismiss = () => dispatch({ type: "DISMISS_TOAST", toastId: id })

  dispatch({
    type: "ADD_TOAST",
    toast: {
      ...props,
      id,
      open: true,
      onOpenChange: (open) => {
        if (!open) dismiss()
      },
    },
  })

  return {
    id: id,
    dismiss,
    update,
  }
}
"""

let useToast () = ignore <| JSX.jsx """
{
  const [state, setState] = React.useState(memoryState)

  React.useEffect(() => {
    listeners.push(setState)
    return () => {
      const index = listeners.indexOf(setState)
      if (index > -1) {
        listeners.splice(index, 1)
      }
    };
  }, [state])

  return {
    ...state,
    toast,
    dismiss: (toastId) => dispatch({ type: "DISMISS_TOAST", toastId }),
  };
}
"""