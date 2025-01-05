[<AutoOpen>]
module Feliz.Shadcn.Badge

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz

let badgeVariants =
    JSX.cva "inline-flex items-center rounded-md border px-2.5 py-0.5 text-xs font-semibold transition-colors focus:outline-none focus:ring-2 focus:ring-ring focus:ring-offset-2"
        {|
            variants = {|
                    variant = {|
                            ``default`` = "border-transparent bg-primary text-primary-foreground shadow hover:bg-primary/80"
                            secondary = "border-transparent bg-secondary text-secondary-foreground hover:bg-secondary/80"
                            destructive = "border-transparent bg-destructive text-destructive-foreground shadow hover:bg-destructive/80"
                            outline = "text-foreground"
                    |}         
            |}
            defaultVariants = {|
                    variant = "default"
            |}
        |}

// --------------- Badge -------------- //
type [<Erase>] IBadgeProp = interface end
type [<Erase>] badge =
    inherit prop<IBadgeProp>
    static member inline noop : unit = ()
module [<Erase>] badge =
    type [<Erase>] variant =
        static member inline default' : IBadgeProp = Interop.mkProperty "variant" "default"
        static member inline secondary : IBadgeProp = Interop.mkProperty "variant" "secondary"
        static member inline destructive : IBadgeProp = Interop.mkProperty "variant" "destructive"
        static member inline outline : IBadgeProp = Interop.mkProperty "variant" "outline"

[<JSX.Component>]
let Badge ( props : IBadgeProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, variant, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <div className={ JSX.cn [| (unbox badgeVariants)(properties?variant) ; properties?className |] } {{...sprops}} {{...attrs}} />
    """ |> unbox