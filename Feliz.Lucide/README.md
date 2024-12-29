# Feliz.Lucide

Lucide icon bindings in feliz style!

Includes compatibility with `@lucide/lab`.

## Usage

With `lucide-react`

> run `npm add lucide-react`

```fsharp
open Feliz.Lucide

[<ReactComponent>]
let TestView () =
    Html.div [
        Icon.AArrowDown [] // Requires a prop list parameter; pass empty list prn
        Icon.Ambulance [ icon.size 48 ] // Props are prefixed `icon`
    ]
    
let root = ReactDOM.createRoot (document.getElementById "elmish-app")
root.render (TestView ())
```
---

With `@lucide/lab`

> run `npm add @lucide/lab`


```fsharp
open Feliz.Lucide
open Feliz.Lucide.Lab 

[<ReactComponent>]
let TestView () =
    Html.div [
        Icon.icon [ icon.iconNode "burger" ]
    ]
    
let root = ReactDOM.createRoot (document.getElementById "elmish-app")
root.render (TestView ())
```

> You must include both the Feliz.Lucide and Feliz.Lucide.Lab modules to use the lab icons. This is due to the `lucide-react` `Icon` element and property `iconNode` being added as overloads to our `Icon` type in Feliz.Lucide.

# Future Direction

Once I have time to automate the generation of the icons, I'll include direct bindings to the lab icons rather than passing a string to a property which can cause massive exceptions when the import is unsuccesful.