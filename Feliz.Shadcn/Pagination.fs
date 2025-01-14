[<AutoOpen>]
module Feliz.Shadcn.Pagination

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz
JSX.injectLib
ignore <| JSX.jsx """
import { ChevronLeft, ChevronRight, MoreHorizontal } from "lucide-react"
"""

let _ = buttonVariants

// --------------- Pagination -------------- //
type [<Erase>] IPaginationProp = interface end
type [<Erase>] pagination =
    inherit prop<IPaginationProp>
    static member inline private noop : unit = ()

let Pagination : JSX.ElementType = JSX.jsx """
({
  className,
  ...props
}) => (
  <nav
    role="navigation"
    aria-label="pagination"
    className={cn("mx-auto flex w-full justify-center", className)}
    {...props} />
)
Pagination.displayName = "Pagination"
"""

// --------------- PaginationContent -------------- //
type [<Erase>] IPaginationContentProp = interface end
type [<Erase>] paginationContent =
    inherit prop<IPaginationContentProp>
    static member inline private noop : unit = ()

let PaginationContent : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <ul
    ref={ref}
    className={cn("flex flex-row items-center gap-1", className)}
    {...props} />
))
PaginationContent.displayName = "PaginationContent"
"""

// --------------- PaginationItem -------------- //
type [<Erase>] IPaginationItemProp = interface end
type [<Erase>] paginationItem =
    inherit prop<IPaginationItemProp>
    static member inline private noop : unit = ()

let PaginationItem : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <li ref={ref} className={cn("", className)} {...props} />
))
PaginationItem.displayName = "PaginationItem"
"""
        
// --------------- PaginationLink -------------- //
type [<Erase>] IPaginationLinkProp = interface end
type [<Erase>] paginationLink =
    inherit prop<IPaginationLinkProp>
    static member inline isActive ( value : bool ) : IPaginationLinkProp = Interop.mkProperty "isActive" value

[<RequireQualifiedAccess>]
module [<Erase>] paginationLink =
    type [<Erase>] variant =
        static member inline default' : IPaginationLinkProp = Interop.mkProperty "variant" "default"
        static member inline destructive : IPaginationLinkProp = Interop.mkProperty "variant" "destructive"
        static member inline outline : IPaginationLinkProp = Interop.mkProperty "variant" "outline"
        static member inline secondary : IPaginationLinkProp = Interop.mkProperty "variant" "secondary"
        static member inline ghost : IPaginationLinkProp = Interop.mkProperty "variant" "ghost"
        static member inline link : IPaginationLinkProp = Interop.mkProperty "variant" "link"
    type [<Erase>] size =
        static member inline default' : IPaginationLinkProp = Interop.mkProperty "size" "default"
        static member inline sm : IPaginationLinkProp = Interop.mkProperty "size" "sm"
        static member inline lg : IPaginationLinkProp = Interop.mkProperty "size" "lg"
        static member inline icon : IPaginationLinkProp = Interop.mkProperty "size" "icon"
        
let PaginationLink : JSX.ElementType = JSX.jsx """
({
  className,
  isActive,
  size = "icon",
  ...props
}) => (
  <a
    aria-current={isActive ? "page" : undefined}
    className={cn(buttonVariants({
      variant: isActive ? "outline" : "ghost",
      size,
    }), className)}
    {...props} />
)
PaginationLink.displayName = "PaginationLink"
"""

// --------------- PaginationPrevious -------------- //
type [<Erase>] IPaginationPreviousProp = interface end
type [<Erase>] paginationPrevious =
    inherit prop<IPaginationPreviousProp>
    static member inline private noop : unit = ()

let PaginationPrevious : JSX.ElementType = JSX.jsx """
({
  className,
  ...props
}) => (
  <PaginationLink
    aria-label="Go to previous page"
    size="default"
    className={cn("gap-1 pl-2.5", className)}
    {...props}>
    <ChevronLeft className="h-4 w-4" />
    <span>Previous</span>
  </PaginationLink>
)
PaginationPrevious.displayName = "PaginationPrevious"
"""

// --------------- PaginationNext -------------- //
type [<Erase>] IPaginationNextProp = interface end
type [<Erase>] paginationNext =
    inherit prop<IPaginationNextProp>
    static member inline private noop : unit = ()

let PaginationNext : JSX.ElementType = JSX.jsx """
({
  className,
  ...props
}) => (
  <PaginationLink
    aria-label="Go to next page"
    size="default"
    className={cn("gap-1 pr-2.5", className)}
    {...props}>
    <span>Next</span>
    <ChevronRight className="h-4 w-4" />
  </PaginationLink>
)
PaginationNext.displayName = "PaginationNext"
"""

// --------------- PaginationEllipsis -------------- //
type [<Erase>] IPaginationEllipsisProp = interface end
type [<Erase>] paginationEllipsis =
    inherit prop<IPaginationEllipsisProp>
    static member inline private noop : unit = ()

let PaginationEllipsis : JSX.ElementType = JSX.jsx """
({
  className,
  ...props
}) => (
  <span
    aria-hidden
    className={cn("flex h-9 w-9 items-center justify-center", className)}
    {...props}>
    <MoreHorizontal className="h-4 w-4" />
    <span className="sr-only">More pages</span>
  </span>
)
PaginationEllipsis.displayName = "PaginationEllipsis"
"""

type [<Erase>] Shadcn =
    static member inline Pagination ( props : IPaginationProp list ) = JSX.createElement Pagination props
    static member inline Pagination ( children : ReactElement list ) = JSX.createElementWithChildren Pagination children
    static member inline PaginationContent ( props : IPaginationContentProp list ) = JSX.createElement PaginationContent props
    static member inline PaginationContent ( children : ReactElement list ) = JSX.createElementWithChildren PaginationContent children
    static member inline PaginationLink ( props : IPaginationLinkProp list ) = JSX.createElement PaginationLink props
    static member inline PaginationLink ( children : ReactElement list ) = JSX.createElementWithChildren PaginationLink children
    static member inline PaginationLink ( value : string ) = JSX.createElement PaginationLink [ prop.href value ; prop.text value ]
    static member inline PaginationLink ( href : string , value : string ) = JSX.createElement PaginationLink [ prop.text value ; prop.href href]
    static member inline PaginationItem ( props : IPaginationItemProp list ) = JSX.createElement PaginationItem props
    static member inline PaginationItem ( children : ReactElement list ) = JSX.createElementWithChildren PaginationItem children
    static member inline PaginationPrevious ( props : IPaginationPreviousProp list ) = JSX.createElement PaginationPrevious props
    static member inline PaginationPrevious ( children : ReactElement list ) = JSX.createElementWithChildren PaginationPrevious children
    static member inline PaginationNext ( props : IPaginationNextProp list ) = JSX.createElement PaginationNext props
    static member inline PaginationNext ( children : ReactElement list ) = JSX.createElementWithChildren PaginationNext children
    static member inline PaginationEllipsis ( props : IPaginationEllipsisProp list ) = JSX.createElement PaginationEllipsis props
    static member inline PaginationEllipsis ( children : ReactElement list ) = JSX.createElementWithChildren PaginationEllipsis children
    static member inline PaginationEllipsis () = JSX.createElement PaginationEllipsis []
                        