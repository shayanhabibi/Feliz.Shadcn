# Feliz.Shadcn.Interop

This folder contains all the files you would have to include into your project to use the shadcn components out of the box.

> [!NOTE]
> To simplify changes until the API is stabilised, the namespaces are kept as their original implementations when the different parts were individual packages.

## JSX.Interop

Various helpers I was utilising a lot contained in a single type for Shadcn component implementations.

One such helper used in almost every Shadcn component file is `JSX.injectShadcnLib`.

This includes the `cn()` helper used in Shadcn.

Its definition is very simple:

```fsharp
    [<Emit("""
    import * as React from "react";
    import { clsx } from "clsx";
    import { twMerge } from "tailwind-merge";
    function cn(...inputs) {
      return twMerge(clsx(inputs));
    }
    """)>]        
    static member inline injectShadcnLib : unit = jsNative
```

## Shadcn.Hooks

Shadcn utilises a couple hooks such as 'isMobile'. These are implemented by Shadcn.Hooks.

## Shadcn Bridge

This contains the Feliz properties in a constrained compatible format.

These properties are applied with a constraint by the type `props`.

### `props`

The usual pattern for implementing a component on my side is to add an interface type that properties utilise to constrain a components creation to its specific valid properties.

Previously, I would inherit all the Feliz properties. This polluted the types members with the feliz properties. When trying to `.` through the different properties, there was no way to see which were specifically implemented by the component.

I wanted to use `prop` from feliz, but still utilise the strong typing to reject this in cases where those properties are not valid (ie the component does not capture other properties and spread them within the attributes).

My method of achieving this is to have the `props` type, which is just a shorthand type reference to the constraint compatible `prop<'Property>`. The `props` type is constrained, so that only property interfaces which implement a specific static member will be valid targets. In these cases, the props generic type will be inferred by the compiler so you don't have to add the type annotation.

Here's the `props` implementation:

```fsharp
type [<Erase>] props<'T when 'T: (
        static member propsInterface : unit
    )> = prop<'T>
```

Now when creating a component property interface type, we can make a binary choice as whether to allow interfacing with the feliz properties:

```fsharp
// This does not interface with html properties
// you can only use the defined ones in popoverFormCutOutTopIcon
// Otherwise you will get compiler type errors
type [<Erase>] IPopoverFormCutOutTopIconProp = interface end
type [<Erase>] popoverFormCutOutTopIcon =
    static member inline height ( value : int ) : IPopoverFormCutOutTopIconProp = Interop.mkProperty "height" value
    static member inline width ( value : int ) : IPopoverFormCutOutTopIconProp = Interop.mkProperty "width" value

// This interfaces with html properties
// You can use the properties defined in listProvider
// You can also use props
type [<Erase>] IListProviderProp = interface static member propsInterface : unit = () end
type [<Erase>] listProvider =
    static member inline onDragEnd ( handler : DragEndEvent -> unit ) : IListProviderProp = Interop.mkProperty "onDragEnd" handler

type [<Erase>] Shadcn =
    static member inline ListProvider ( props : IListProviderProp list ) = JSX.createElement ListProvider props
    static member inline PopoverFormCutOutTopIcon ( props : IPopoverFormCutOutTopIconProp list ) = JSX.createElement PopoverFormCutOutTopIcon props

let ele = Shadcn.PopoverFormCutOutTopIcon [
    props.className "m-5" // Invalid, compiler error
    popoverFormCutOutTopIcon.height 5 // valid
]

let ele2 = Shadcn.ListProvider [
    props.className "m-5"
    // ^ Valid, type is automatically inferred to
    // be IListProviderProp
    prop.className "m-5"
    // ^ Invalid, although we have the prop<'Property>
    // type in our Feliz bridge, this collides
    // with the standard prop type definition
    // in Feliz.
    // This also wouldn't allow us to invalidate
    // this usage in particular circumstances
    listProvider.onDragEnd ( fun _ -> ... )
    // ^ Valid
]
```

This means that for every component that is defined, you can `.` through the camelCase name of the component to see its custom properties. You can then try to utilise any `props` properties, and be immediately informed by the compiler whether they are valid or not.

### `svgs`

This is a similar implementation as `props` as the replacement for `svg` properties.

The type is constrained to `'T when 'T: (static member svgsInterface : unit)`. This is used by the Lucide icons.

## Generated files

RadixUI Interface and Lucide icon bindings are generated. It's highly recommended not to change these files, as this allows any updates to the bindings to be simple to patch. You can always create an extension file which adds your extensions to the types. Open that module and you will have access to your extensions on the base types.

# RadixUI.Interface

>[!WARNING]
> These are generated bindings.

This is a binding set to allow derivative components to inherit and interface with the properties. There are two types, the default which inherits all the html properties from feliz, and the `NoInherit` namespace suffix ones which do not.

# Lucide

> [!WARNING]
> These are generated bindings.

Contains generated Lucide icon bindings. It also includes bindings to Lucide Lab icons.

These are compatible with `svgs` properties.