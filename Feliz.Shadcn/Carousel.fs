[<AutoOpen>]
module Feliz.Shadcn.Carousel

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Microsoft.FSharp.Core

JSX.injectShadcnLib
let private imports = Shadcn.Button.Button

// --------------- Carousel -------------- //
type [<Erase>] ICarouselProp = interface static member propsInterface : unit = () end

let internal CarouselContext = JSX.jsx"React.createContext(null)"
let internal useCarousel () = ignore <| JSX.jsx """
{
  const context = React.useContext(CarouselContext)

  if (!context) {
    throw new Error("useCarousel must be used within a <Carousel />")
  }

  return context
}
"""
[<JSX.Component>]
let Carousel : JSX.ElementType = JSX.jsx """
import useEmblaCarousel from "embla-carousel-react";
import { ArrowLeft, ArrowRight } from "lucide-react";
React.forwardRef((
  {
    orientation = "horizontal",
    opts,
    setApi,
    plugins,
    className,
    children,
    ...props
  },
  ref
) => {
  const [carouselRef, api] = useEmblaCarousel({
    ...opts,
    axis: orientation === "horizontal" ? "x" : "y",
  }, plugins)
  const [canScrollPrev, setCanScrollPrev] = React.useState(false)
  const [canScrollNext, setCanScrollNext] = React.useState(false)

  const onSelect = React.useCallback((api) => {
    if (!api) {
      return
    }

    setCanScrollPrev(api.canScrollPrev())
    setCanScrollNext(api.canScrollNext())
  }, [])

  const scrollPrev = React.useCallback(() => {
    api?.scrollPrev()
  }, [api])

  const scrollNext = React.useCallback(() => {
    api?.scrollNext()
  }, [api])

  const handleKeyDown = React.useCallback((event) => {
    if (event.key === "ArrowLeft") {
      event.preventDefault()
      scrollPrev()
    } else if (event.key === "ArrowRight") {
      event.preventDefault()
      scrollNext()
    }
  }, [scrollPrev, scrollNext])

  React.useEffect(() => {
    if (!api || !setApi) {
      return
    }

    setApi(api)
  }, [api, setApi])

  React.useEffect(() => {
    if (!api) {
      return
    }

    onSelect(api)
    api.on("reInit", onSelect)
    api.on("select", onSelect)

    return () => {
      api?.off("select", onSelect)
    };
  }, [api, onSelect])

  return (
    (<CarouselContext.Provider
      value={{
        carouselRef,
        api: api,
        opts,
        orientation:
          orientation || (opts?.axis === "y" ? "vertical" : "horizontal"),
        scrollPrev,
        scrollNext,
        canScrollPrev,
        canScrollNext,
      }}>
      <div
        ref={ref}
        onKeyDownCapture={handleKeyDown}
        className={cn("relative", className)}
        role="region"
        aria-roledescription="carousel"
        {...props}>
        {children}
      </div>
    </CarouselContext.Provider>)
  );
})
Carousel.displayName = "Carousel"
"""

// --------------- CarouselContent -------------- //
type [<Erase>] ICarouselContentProp = interface static member propsInterface : unit = () end

let CarouselContent : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => {
  const { carouselRef, orientation } = useCarousel()

  return (
    (<div ref={carouselRef} className="overflow-hidden">
      <div
        ref={ref}
        className={cn(
          "flex",
          orientation === "horizontal" ? "-ml-4" : "-mt-4 flex-col",
          className
        )}
        {...props} />
    </div>)
  );
})
CarouselContent.displayName = "CarouselContent"
"""

// --------------- CarouselItem -------------- //
type [<Erase>] ICarouselItemProp = interface static member propsInterface : unit = () end

let CarouselItem : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => {
  const { orientation } = useCarousel()

  return (
    (<div
      ref={ref}
      role="group"
      aria-roledescription="slide"
      className={cn(
        "min-w-0 shrink-0 grow-0 basis-full",
        orientation === "horizontal" ? "pl-4" : "pt-4",
        className
      )}
      {...props} />)
  );
})
CarouselItem.displayName = "CarouselItem"
"""

// --------------- CarouselPrevious -------------- //
type [<Erase>] ICarouselPreviousProp = interface static member propsInterface : unit = () end

let CarouselPrevious : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, variant = "outline", size = "icon", ...props }, ref) => {
  const { orientation, scrollPrev, canScrollPrev } = useCarousel()

  return (
    (<Button
      ref={ref}
      variant={variant}
      size={size}
      className={cn("absolute  h-8 w-8 rounded-full", orientation === "horizontal"
        ? "-left-12 top-1/2 -translate-y-1/2"
        : "-top-12 left-1/2 -translate-x-1/2 rotate-90", className)}
      disabled={!canScrollPrev}
      onClick={scrollPrev}
      {...props}>
      <ArrowLeft className="h-4 w-4" />
      <span className="sr-only">Previous slide</span>
    </Button>)
  );
})
CarouselPrevious.displayName = "CarouselPrevious"
"""

// --------------- CarouselNext -------------- //
type [<Erase>] ICarouselNextProp = interface static member propsInterface : unit = () end

let CarouselNext : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, variant = "outline", size = "icon", ...props }, ref) => {
  const { orientation, scrollNext, canScrollNext } = useCarousel()

  return (
    (<Button
      ref={ref}
      variant={variant}
      size={size}
      className={cn("absolute h-8 w-8 rounded-full", orientation === "horizontal"
        ? "-right-12 top-1/2 -translate-y-1/2"
        : "-bottom-12 left-1/2 -translate-x-1/2 rotate-90", className)}
      disabled={!canScrollNext}
      onClick={scrollNext}
      {...props}>
      <ArrowRight className="h-4 w-4" />
      <span className="sr-only">Next slide</span>
    </Button>)
  );
})
CarouselNext.displayName = "CarouselNext"
"""

type [<Erase>] Shadcn =
    static member inline Carousel ( props : ICarouselProp list ) = JSX.createElement Carousel props
    static member inline Carousel ( children : ReactElement list ) = JSX.createElementWithChildren Carousel children
    static member inline CarouselContent ( props : ICarouselContentProp list ) = JSX.createElement CarouselContent props
    static member inline CarouselContent ( children : ReactElement list ) = JSX.createElementWithChildren CarouselContent children
    static member inline CarouselItem ( props : ICarouselItemProp list ) = JSX.createElement CarouselItem props
    static member inline CarouselItem ( children : ReactElement list ) = JSX.createElementWithChildren CarouselItem children
    static member inline CarouselPrevious ( props : ICarouselPreviousProp list ) = JSX.createElement CarouselPrevious props
    static member inline CarouselPrevious ( children : ReactElement list ) = JSX.createElementWithChildren CarouselPrevious children
    static member inline CarouselNext ( props : ICarouselNextProp list ) = JSX.createElement CarouselNext props
    static member inline CarouselNext ( children : ReactElement list ) = JSX.createElementWithChildren CarouselNext children