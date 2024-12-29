# Feliz.Lucide

> [!NOTICE]
> The Lucide icon bindings are published to nuget.
> `dotnet add package Feliz.Lucide`
> or `dotnet paket add Feliz.Lucide`
> See the readme in Feliz.Lucide for usage.

# Feliz.Shadcn

In development personal bindings to Shadcn components in Feliz style.

> [!WARNING]
> Not usable as it stands.

~~For the easiest compatibility with Feliz style UX and less user installation nonsense, this library simply binds a npm library which prebundles shadcn in the new-york style called `shadcn-react`.~~

`shadcn-react` is another fail. There is a lot of functionality lost and the wrapper is a weak wrapper to use with Fable to have full utilisation of shadcn and its customisability.

The next iteration will be a wrapper for the jsx version of shadcn which is far less obfuscated than the tsx.

In saying this, the Lucide icons work fine as intended. We will remove the dependency for shadcn-react though.

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