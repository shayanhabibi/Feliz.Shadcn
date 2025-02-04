<div id="top"></div>

<br />

<div align="center">
  <a href="https://ui.shadcn.com/" target="_blank">
    <img src="https://avatars.githubusercontent.com/u/139895814?s=48&v=4" height="24px" style="border-radius:8px;"/>
  </a>

  <h3 align="center">Feliz.Shadcn</h3>
  <p align="center">
    <kbd>Shadcn Components ported for F# Fable Feliz Style</kbd>
  </p>
</div>

---

In development personal bindings to Shadcn components in Feliz style.

> The library is not necessarily intended to be package managed, but rather follows a similar logic as shadcn by providing the elements premade with nice defaults for you to change as needed. There are some dependencies which will be managed by a package, you are then free to download and use the components in whatever manner you wish.

## Something Wrong?

While I continue to develop and iterate over components in a private repo, there is not much motivation to spend any time porting those changes to this repo since there's no consumers at the moment.

If you are interested in using any components, let me know and I'll adjust priorities accordingly.

## Attributions

> Internal Libraries and Code has been directly pulled from work by [Francisco Montanez](https://github.com/Francisco-Montanez) in generating [RadixUI interfaces](https://github.com/Francisco-Montanez/Feliz.RadixUI); [Zaid Ajaj](https://github.com/Zaid-Ajaj)
> in defining properties for svgs and props, and [Andrew Sutton](https://github.com/sydsutton) in multiple patterns of implementation derivative of [FS.FluentUI](https://github.com/sydsutton/FS.FluentUI).
>
> Please let me know if I have missed anything or anyone.

## Setup

### Fable Config

Using the components requires transpilation to `.jsx` files instead of the standard `.js`.

Pass `-e .fs.jsx` to Fable when transpiling, cleaning, or doing other actions that default to a particular file suffix [as per Fable docs](https://fable.io/docs/getting-started/cli.html)

### Tailwind Config

<details>
  <summary>Check the Shadcn Docs for the config variables that are needed for different components. An example of the current tailwind config in use is here
  </summary>
  <p>
      
```js
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

  </p>
<p align="right">(<a href="#top">back to top</a>)</p>
</details>

<details>
    <summary>
        Tailwindcss 4?
    </summary>
<p>

Since this repo and my own private projects are so new, there is a perfect opportunity to implement everything in tailwindcss 4 to future proof instead of delaying this until things have developed more fully.

This has already been succesfully done on my private project.

This will be incorporated here in a pull soon™.

</p>
</details>

### Global CSS

<details>
    <summary>
        Similar to the Tailwind config, there are styles that will need to be added whenever directed by Shadcn docs. An example of a global css containing necessary editions is here
    </summary>
    <p>

```css
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
<p align="right">(<a href="#top">back to top</a>)</p>        
    </p>
</details>


## Install

<details>
    <summary>
        There is no install. Just implement the glue code and then you're free to copy paste the contents to use them out the box. All you need to do is make sure you have the dependencies.
    </summary>
    <p>
    
For everything to work out of the box, all the glue is included in the `Feliz.Shadcn.Interop` project. Copy and paste all the files within into your project.

Keep them in a separate folder and try to keep your own changes to separate extension files to make things easier if you want to patch changes on.

Don't edit the generated files (which have a annotation at the top of the file) unless your a masochist. These are files that are easily regenerated to update to the latest npm versions. It's ideal to just copy paste the generated files and overwrite old ones.
    
    </p>

</details>

# Feliz.Lucide

<details>
    <summary>
        Within the glue code and the Feliz.Lucide project file in this repo are generated bindings for Lucide.
    </summary>
    <p>
        A pull has been made for Glutinum.Feliz.Lucide to utilise the generator to automatically keep the bindings up to date, this will then be available as a nuget package.
    </p>
</details>

All the icons are accessible via the namespace `Feliz.Lucide`.

To utilise Lab icons, open the `Feliz.Lucide.Lab` module to include the `Icon` extensions.

All icons are then usable as static members of the `Icon` type.

Lab icons keep their camelCase naming. Standard icons are Pascal Cased.

The specific lucide properties are accessible via members of the `icon` type. You can use any svg properties via `svgs`.

# Feliz.RadixUI.Interface

These generated files implement bindings for RadixUI primitive properties.
