# Feliz.Lucide

> [!NOTE]
> The Lucide icon bindings are published to nuget.
> `dotnet add package Feliz.Lucide`
> or `dotnet paket add Feliz.Lucide`
> See the [readme](https://github.com/shayanhabibi/Feliz.Shadcn/blob/main/Feliz.Lucide/README.md) in Feliz.Lucide for usage.

# Feliz.Shadcn

In development personal bindings to Shadcn components in Feliz style.

The library is not necessarily intended to be package managed, but rather follows a similar logic as shadcn by providing the elements premade with nice defaults for you to change as needed. There are some dependencies which will be managed by a package, you are then free to download and use the components in whatever manner you wish.

There is a cost to this, and that is you will have to pass a flag to Fable to compile into tsx/jsx. `-e .jsx`.

# Install

There is no install. Copy paste the contents to use them out the box. All you need to do is make sure you have the dependencies.

This is handled with a helper package:

```
dotnet add package Feliz.Shadcn.Interop
// or using paket
paket add Feliz.Shadcn.Interop
```

For the best experience, use Femto to avoid having to download the npm packages yourself individually.

```
femto install Feliz.Shadcn.Interop
```

# Tailwind Config

> [!WARNING]
> Shadcn takes advantage of tailwind config and variables
> to allow a more coherent theme for your design.

The variables associated with each component must be referenced
from Shadcn docs.

For reference, my current tailwind.config.js file looks like this:

```
/** @type {import('tailwindcss').Config} */
module.exports = {
    mode: "jit",
    content: [
        "./index.html",
        "./**/*.{fs,js,ts,jsx,tsx}",
        "../Feliz.Shadcn/**/*.{fs,js,ts,jsx,tsx}"
    ],
    theme: {
        extend: {
            keyframes: {
                "accordion-down": {
                    from: { height: "0" },
                    to: { height: "var(--radix-accordion-content-height)" },
                },
                "accordion-up": {
                    from: { height: "var(--radix-accordion-content-height)" },
                    to: { height: "0" },
                },
                shine: {
                    "0%": { backgroundPosition: "200% 0" },
                    "25%": { backgroundPosition: "-200% 0" },
                    "100%": { backgroundPosition: "-200% 0" },
                },
            },
            animation: {
                "accordion-down": "accordion-down 0.2s ease-out",
                "accordion-up": "accordion-up 0.2s ease-out",
                shine: "shine 3s ease-out infinite",
            },
            colors: {
                border: "hsl(var(--border))",
                input: "hsl(var(--input))",
                ring: "hsl(var(--ring))",
                background: "hsl(var(--background))",
                foreground: "hsl(var(--foreground))",
                primary: {
                    DEFAULT: "hsl(var(--primary))",
                    foreground: "hsl(var(--primary-foreground))",
                },
                secondary: {
                    DEFAULT: "hsl(var(--secondary))",
                    foreground: "hsl(var(--secondary-foreground))",
                },
                destructive: {
                    DEFAULT: "hsl(var(--destructive))",
                    foreground: "hsl(var(--destructive-foreground))",
                },
                muted: {
                    DEFAULT: "hsl(var(--muted))",
                    foreground: "hsl(var(--muted-foreground))",
                },
                accent: {
                    DEFAULT: "hsl(var(--accent))",
                    foreground: "hsl(var(--accent-foreground))",
                },
                popover: {
                    DEFAULT: "hsl(var(--popover))",
                    foreground: "hsl(var(--popover-foreground))",
                },
                card: {
                    DEFAULT: "hsl(var(--card))",
                    foreground: "hsl(var(--card-foreground))",
                },
                sidebar: {
                    DEFAULT: 'hsl(var(--sidebar-background))',
                    foreground: 'hsl(var(--sidebar-foreground))',
                    primary: 'hsl(var(--sidebar-primary))',
                    'primary-foreground': 'hsl(var(--sidebar-primary-foreground))',
                    accent: 'hsl(var(--sidebar-accent))',
                    'accent-foreground': 'hsl(var(--sidebar-accent-foreground))',
                    border: 'hsl(var(--sidebar-border))',
                    ring: 'hsl(var(--sidebar-ring))',
                },
            },
            borderRadius: {
                lg: `var(--radius)`,
                md: `calc(var(--radius) - 2px)`,
                sm: "calc(var(--radius) - 4px)",
            },
        },
    },
    plugins: [require("tailwindcss-animate")],
}
```

And my global css file like this:

```
@tailwind base;
@tailwind components;
@tailwind utilities;

@layer base {
    :root {
        --background: 0 0% 100%;
        --foreground: 222.2 47.4% 11.2%;
        --muted: 210 40% 96.1%;
        --muted-foreground: 215.4 16.3% 46.9%;
        --popover: 0 0% 100%;
        --popover-foreground: 222.2 47.4% 11.2%;
        --border: 214.3 31.8% 91.4%;
        --input: 214.3 31.8% 91.4%;
        --card: 0 0% 100%;
        --card-foreground: 222.2 47.4% 11.2%;
        --primary: 222.2 47.4% 11.2%;
        --primary-foreground: 210 40% 98%;
        --secondary: 210 40% 96.1%;
        --secondary-foreground: 222.2 47.4% 11.2%;
        --accent: 210 40% 96.1%;
        --accent-foreground: 222.2 47.4% 11.2%;
        --destructive: 0 100% 50%;
        --destructive-foreground: 210 40% 98%;
        --ring: 215 20.2% 65.1%;
        --radius: 0.5rem;
    }

    .dark {
        --background: 224 71% 4%;
        --foreground: 213 31% 91%;
        --muted: 223 47% 11%;
        --muted-foreground: 215.4 16.3% 56.9%;
        --accent: 216 34% 17%;
        --accent-foreground: 210 40% 98%;
        --popover: 224 71% 4%;
        --popover-foreground: 215 20.2% 65.1%;
        --border: 216 34% 17%;
        --input: 216 34% 17%;
        --card: 224 71% 4%;
        --card-foreground: 213 31% 91%;
        --primary: 210 40% 98%;
        --primary-foreground: 222.2 47.4% 1.2%;
        --secondary: 222.2 47.4% 11.2%;
        --secondary-foreground: 210 40% 98%;
        --destructive: 0 63% 31%;
        --destructive-foreground: 210 40% 98%;
        --ring: 216 34% 17%;
    }
}

@layer base {
    * {
        @apply border-border;
    }
    body {
        @apply font-sans antialiased bg-background text-foreground;
    }
}

@layer base {
    :root {
        --sidebar-background: 0 0% 98%;
        --sidebar-foreground: 240 5.3% 26.1%;
        --sidebar-primary: 240 5.9% 10%;
        --sidebar-primary-foreground: 0 0% 98%;
        --sidebar-accent: 240 4.8% 95.9%;
        --sidebar-accent-foreground: 240 5.9% 10%;
        --sidebar-border: 220 13% 91%;
        --sidebar-ring: 217.2 91.2% 59.8%;
    }

    .dark {
        --sidebar-background: 240 5.9% 10%;
        --sidebar-foreground: 240 4.8% 95.9%;
        --sidebar-primary: 224.3 76.3% 48%;
        --sidebar-primary-foreground: 0 0% 100%;
        --sidebar-accent: 240 3.7% 15.9%;
        --sidebar-accent-foreground: 240 4.8% 95.9%;
        --sidebar-border: 240 3.7% 15.9%;
        --sidebar-ring: 217.2 91.2% 59.8%;
    }
}
```

# Components

The Button component documents the component patterns:

```fsharp
[<AutoOpen>]
module Feliz.Shadcn.Button

open Feliz.Interop.Extend
open Fable.Core
open Feliz

JSX.injectLib

// --------------- Button -------------- //
/// Shadcn Button prop interface type
type [<Erase>] IButtonProp = interface end
/// Accessor for button properties
type [<Erase>] button =
    // Inherit Feliz base properties
    inherit prop<IButtonProp>
    // Definitions for library defined properties
    static member inline asChild ( value : bool ) : IButtonProp = Interop.mkProperty "asChild" value

/// Button variants as a `Class-Variance-Authority` object.
/// You can modify existing variants or add your own.
/// After adding your own variants, it's suggested to create a variant enum prop. Follow the examples in the `button.variant` type.
let buttonVariants = JSX.jsx """
import { cva } from "class-variance-authority";
cva(
  "inline-flex items-center justify-center gap-2 whitespace-nowrap rounded-md text-sm font-medium transition-colors focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:pointer-events-none disabled:opacity-50 [&_svg]:pointer-events-none [&_svg]:size-4 [&_svg]:shrink-0",
  {
    variants: {
      variant: {
        default:
          "bg-primary text-primary-foreground shadow hover:bg-primary/90",
        destructive:
          "bg-destructive text-destructive-foreground shadow-sm hover:bg-destructive/90",
        outline:
          "border border-input bg-background shadow-sm hover:bg-accent hover:text-accent-foreground",
        secondary:
          "bg-secondary text-secondary-foreground shadow-sm hover:bg-secondary/80",
        ghost: "hover:bg-accent hover:text-accent-foreground",
        link: "text-primary underline-offset-4 hover:underline",
      },
      size: {
        default: "h-9 px-4 py-2",
        sm: "h-8 rounded-md px-3 text-xs",
        lg: "h-10 rounded-md px-8",
        icon: "h-9 w-9",
      },
    },
    defaultVariants: {
      variant: "default",
      size: "default",
    },
  }
)
"""

/// Accessor for button enums.
[<RequireQualifiedAccess>]
module [<Erase>] button =
    /// ButtonVariant enumerators
    type [<Erase>] variant =
        static member inline default' : IButtonProp = Interop.mkProperty "variant" "default"
        static member inline destructive : IButtonProp = Interop.mkProperty "variant" "destructive"
        static member inline outline : IButtonProp = Interop.mkProperty "variant" "outline"
        static member inline secondary : IButtonProp = Interop.mkProperty "variant" "secondary"
        static member inline ghost : IButtonProp = Interop.mkProperty "variant" "ghost"
        static member inline link : IButtonProp = Interop.mkProperty "variant" "link"
    /// ButtonVariant enumerators
    type [<Erase>] size =
        static member inline default' : IButtonProp = Interop.mkProperty "size" "default"
        static member inline sm : IButtonProp = Interop.mkProperty "size" "sm"
        static member inline lg : IButtonProp = Interop.mkProperty "size" "lg"
        static member inline icon : IButtonProp = Interop.mkProperty "size" "icon"

/// The Button JSX Element definition
/// To use this is in your own JSX, you would have to ensure Fable imports the type using a dummy binding
/// <code>
/// let _ = Button
/// </code>
/// To use in Feliz style, access via `Shadcn`.
/// <code>
/// Shadcn.Button [
///   // add props
/// ]
/// </code>
let Button : JSX.ElementType = JSX.jsx """
import { Slot } from "@radix-ui/react-slot";
React.forwardRef(({ className, variant, size, asChild = false, ...props }, ref) => {
  const Comp = asChild ? Slot : "button"
  return (
    (<Comp
      className={cn(buttonVariants({ variant, size, className }))}
      ref={ref}
      {...props} />)
  );
})
Button.displayName = "Button"
"""

type [<Erase>] Shadcn =
  static member inline Button ( props : IButtonProp list ) = JSX.createElement Button props
  static member inline Button ( children : ReactElement list ) = JSX.createElementWithChildren Button children
  static member inline Button ( value : string ) = JSX.createElement Button [ button.text value ]
  static member inline Button ( el : ReactElement ) = JSX.createElement Button [ button.asChild true ; button.children [ el ] ]
```