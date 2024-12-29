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

The lab icons can be used as directed by the `lucide-react` using the `Icon` generic element with the `iconNode` attribute set to the name of the icon you wish to use.

This pattern has been pregenerated for all the lab icons and are available by accessing `Icon` with pascalCasing.

See below:

```fsharp
open Feliz.Lucide
open Feliz.Lucide.Lab 

[<ReactComponent>]
let TestView () =
    Html.div [
        Icon.icon [ icon.iconNode "burger" ] // old syntax
        Icon.burger [] // new syntax
    ]
    
let root = ReactDOM.createRoot (document.getElementById "elmish-app")
root.render (TestView ())
```

> You must include both the Feliz.Lucide and Feliz.Lucide.Lab modules to use the lab icons. This is due to the `lucide-react` `Icon` element and property `iconNode` being added as overloads to our `Icon` type in Feliz.Lucide.

The old syntax should be used if the bindings have not been updated to the latest version of `@lucide/lab` and is missing some icons.

The bindings can be updated from the source using the included generator.