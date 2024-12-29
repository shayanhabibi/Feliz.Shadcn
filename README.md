# Feliz.Lucide

> [!NOTE]
> The Lucide icon bindings are published to nuget.
> `dotnet add package Feliz.Lucide`
> or `dotnet paket add Feliz.Lucide`
> See the [readme](https://github.com/shayanhabibi/Feliz.Shadcn/blob/main/Feliz.Lucide/README.md) in Feliz.Lucide for usage.

# Feliz.Shadcn

In development personal bindings to Shadcn components in Feliz style.

> [!WARNING]
> Not usable as it stands.

~~For the easiest compatibility with Feliz style UX and less user installation nonsense, this library simply binds a npm library which prebundles shadcn in the new-york style called `shadcn-react`.~~

`shadcn-react` is another fail. There is a lot of functionality lost and the wrapper is a weak wrapper to use with Fable to have full utilisation of shadcn and its customisability.

The next iteration will be a wrapper for the jsx version of shadcn which is far less obfuscated than the tsx.

In saying this, the Lucide icons work fine as intended. We will remove the dependency for shadcn-react though.