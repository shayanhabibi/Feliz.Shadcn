# Feliz.Shadcn

In development personal bindings to Shadcn components in Feliz style.

> [!WARNING]
> Not usable as it stands.

For the easiest compatibility with Feliz style UX and less user installation nonsense, this library simply binds a npm library which prebundles shadcn in the new-york style called `shadcn-react`.

## Installation

WIP, currently ensure you follow the installation instructions for npm module `shadcn-react`. There is no publication of this library yet, but you can use the source code in your own projects so long as you have the modules and dependencies.

# Feliz.Lucide

The icons for Lucide are available via

```fs
open Feliz.Lucide
open Feliz

let AmbulanceIcon = Lucide.bundleIcons.Ambulance
[<ReactComponent>]
let TestView () =
    Html.div [
        prop.children [
            AmbulanceIcon [ icons.size 48 ]
            
        ]
    ]
```