# Feliz.Lucide

> [!NOTE]
> The Lucide icon bindings are published to nuget.
> `dotnet add package Feliz.Lucide`
> or `dotnet paket add Feliz.Lucide`
> See the [readme](https://github.com/shayanhabibi/Feliz.Shadcn/blob/main/Feliz.Lucide/README.md) in Feliz.Lucide for usage.

# Feliz.Shadcn

In development personal bindings to Shadcn components in Feliz style.

> [!Note]
> Base implementation for Shadcn components has been completed and the API is satisfactory for Feliz style

> [!WARNING]
> While the components are all usable, the dependencies have not been published. The Hooks file and helpers contained in Feliz.Interop.Extend and required (along with npm depencies for shadcn components).
> 
> Barring the above, everything should work as a copy paste

The library is not necessarily intended to be package managed, but rather follows a similar logic as shadcn by providing the elements premade with nice defaults for you to change as needed. There are some dependencies which will be managed by a package, you are then free to download and use the components in whatever manner you wish.

There is a cost to this, and that is you will have to pass a flag to Fable to compile into tsx/jsx. `-e .jsx`.


You can see the test file for some musings and play with different components and apis. The `Demo` functions show latest api usage (in terms of helpers).