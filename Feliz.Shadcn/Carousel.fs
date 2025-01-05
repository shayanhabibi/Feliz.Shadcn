[<AutoOpen>]
module Feliz.Shadcn.Carousel

open Fable.Core.PyInterop
open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Microsoft.FSharp.Core

emitJsStatement () """
import useEmblaCarousel from "embla-carousel-react"
import { ArrowLeft, ArrowRight } from "lucide-react"
"""

// --------------- Carousel -------------- //
type [<Erase>] ICarouselProp = interface end
type [<Erase>] carousel =
    inherit prop<ICarouselProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let Carousel ( props : ICarouselProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties """
    const {
        orientation = "horizontal",
        opts,
        setApi,
        plugins,
        className,
        children,
        ...sprops
        } = $0;
    const {props, ...attrs} = $props;
    const [carouselRef, api] = useEmblaCarousel({
        ...opts,
        axis: orientation === "horizontal" ? "x" : "y",
    }, plugins)
    """
    let  carouselRef, api : obj * obj = emitJsExpr () "useEmblaCarousel()"
    let canScrollPrev, setCanScrollPrev = React.useState false
    let canScrollNext, setCanScrollNext = React.useState false
    
    JSX.jsx $"""
    <div></div>
    """ |> unbox