[<AutoOpen>]
module Feliz.Shadcn.Button

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz

emitJsStatement () """import { Slot } from "@radix-ui/react-slot" """

// --------------- Button -------------- //
type [<Erase>] IButtonProp = interface end
type [<Erase>] button =
    inherit prop<IButtonProp>
    static member inline asChild ( value : bool ) : IButtonProp = Interop.mkProperty "asChild" value

let buttonVariants =
    JSX.cva "inline-flex items-center justify-center gap-2 whitespace-nowrap rounded-md text-sm font-medium transition-colors focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:pointer-events-none disabled:opacity-50 [&_svg]:pointer-events-none [&_svg]:size-4 [&_svg]:shrink-0"
        {|
            variants = {|
                variant = {|
                   ``default``= "bg-primary text-primary-foreground shadow hover:bg-primary/90"
                   destructive = "bg-destructive text-destructive-foreground shadow-sm hover:bg-destructive/90"
                   outline = "border border-input bg-background shadow-sm hover:bg-accent hover:text-accent-foreground"
                   secondary = "bg-secondary text-secondary-foreground shadow-sm hover:bg-secondary/80"
                   ghost = "hover:bg-accent hover:text-accent-foreground"
                   link = "text-primary underline-offset-4 hover:underline"
                |}
                size = {|
                    ``default`` = "h-9 px-4 py-2"
                    sm = "h-8 rounded-md px-3 text-xs"
                    lg = "h-10 rounded-md px-8"
                    icon = "h-9 w-9"
                |}
               
            |}
                  
            defaultVariants = {|
                variant = "default"
                size = "default"
            |}
        |}
    
[<RequireQualifiedAccess>]
module [<Erase>] button =
    type [<Erase>] variant =
        static member inline default' : IButtonProp = Interop.mkProperty "variant" "default"
        static member inline destructive : IButtonProp = Interop.mkProperty "variant" "destructive"
        static member inline outline : IButtonProp = Interop.mkProperty "variant" "outline"
        static member inline secondary : IButtonProp = Interop.mkProperty "variant" "secondary"
        static member inline ghost : IButtonProp = Interop.mkProperty "variant" "ghost"
        static member inline link : IButtonProp = Interop.mkProperty "variant" "link"
    type [<Erase>] size =
        static member inline default' : IButtonProp = Interop.mkProperty "size" "default"
        static member inline sm : IButtonProp = Interop.mkProperty "size" "sm"
        static member inline lg : IButtonProp = Interop.mkProperty "size" "lg"
        static member inline icon : IButtonProp = Interop.mkProperty "size" "icon"

[<JSX.Component>]
let Button ( props : IButtonProp list ) : JSX.Element =
    let ref = React.useRef()
    let properties = !!props |> createObj
    emitJsStatement properties "const {className, variant, size, asChild = false, ...props} = $0"
    emitJsStatement () "const Comp = asChild ? Slot : \"button\""
    JSX.jsx $"""
    import {{ clsx }} from "clsx";
    import {{ twMerge }} from "tailwind-merge";
    
    <Comp className={{twMerge(clsx(buttonVariants({{className, variant, size}})))}}
            ref={ref}
            {{...props}}/>
    """
let RButton = Button >> JSX.toReact