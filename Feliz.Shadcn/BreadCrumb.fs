[<AutoOpen>]
module Feliz.Shadcn.BreadCrumb

open Feliz.Shadcn.Interop
open Fable.Core
open Feliz

JSX.injectShadcnLib

// --------------- Breadcrumb -------------- //
type [<Erase>] IBreadcrumbProp = interface static member propsInterface : unit = () end

let Breadcrumb : JSX.ElementType = JSX.jsx """
React.forwardRef(
  ({ ...props }, ref) => <nav ref={ref} aria-label="breadcrumb" {...props} />
)
Breadcrumb.displayName = "Breadcrumb"
"""

// --------------- BreadcrumbList -------------- //
type [<Erase>] IBreadcrumbListProp = interface static member propsInterface : unit = () end

let BreadcrumbList : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <ol
    ref={ref}
    className={cn(
      "flex flex-wrap items-center gap-1.5 break-words text-sm text-muted-foreground sm:gap-2.5",
      className
    )}
    {...props} />
))
BreadcrumbList.displayName = "BreadcrumbList"
"""
    

// --------------- BreadcrumbItem -------------- //
type [<Erase>] IBreadcrumbItemProp = interface static member propsInterface : unit = () end

let BreadcrumbItem : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <li
    ref={ref}
    className={cn("inline-flex items-center gap-1.5", className)}
    {...props} />
))
BreadcrumbItem.displayName = "BreadcrumbItem"
"""

// --------------- BreadcrumbLink -------------- //
type [<Erase>] IBreadcrumbLinkProp = interface static member propsInterface : unit = () end

[<JSX.Component>]
let BreadcrumbLink : JSX.ElementType = JSX.jsx """
import { Slot } from "@radix-ui/react-slot";

React.forwardRef(({ asChild, className, ...props }, ref) => {
  const Comp = asChild ? Slot : "a"

  return (
    (<Comp
      ref={ref}
      className={cn("transition-colors hover:text-foreground", className)}
      {...props} />)
  );
})
BreadcrumbLink.displayName = "BreadcrumbLink"
"""
    
// --------------- BreadcrumbPage -------------- //
type [<Erase>] IBreadcrumbPageProp = interface static member propsInterface : unit = () end

let BreadcrumbPage : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <span
    ref={ref}
    role="link"
    aria-disabled="true"
    aria-current="page"
    className={cn("font-normal text-foreground", className)}
    {...props} />
))
BreadcrumbPage.displayName = "BreadcrumbPage"
"""

// --------------- BreadcrumbSeparator -------------- //
type [<Erase>] IBreadcrumbSeparatorProp = interface static member propsInterface : unit = () end

let BreadcrumbSeparator : JSX.ElementType = JSX.jsx """
import { ChevronRight } from "lucide-react";
({
  children,
  className,
  ...props
}) => (
  <li
    role="presentation"
    aria-hidden="true"
    className={cn("[&>svg]:w-3.5 [&>svg]:h-3.5", className)}
    {...props}>
    {children ?? <ChevronRight />}
  </li>
)
BreadcrumbSeparator.displayName = "BreadcrumbSeparator"
"""
    
// --------------- BreadcrumbEllipsis -------------- //
type [<Erase>] IBreadcrumbEllipsisProp = interface static member propsInterface : unit = () end

let BreadcrumbEllipsis : JSX.ElementType = JSX.jsx """
import { MoreHorizontal } from "lucide-react";
({
  className,
  ...props
}) => (
  <span
    role="presentation"
    aria-hidden="true"
    className={cn("flex h-9 w-9 items-center justify-center", className)}
    {...props}>
    <MoreHorizontal className="h-4 w-4" />
    <span className="sr-only">More</span>
  </span>
)
BreadcrumbEllipsis.displayName = "BreadcrumbEllipsis"
"""

type [<Erase>] Shadcn =
    static member inline Breadcrumb ( props : IBreadcrumbProp list ) = JSX.createElement Breadcrumb props
    static member inline Breadcrumb ( props : ReactElement list ) = JSX.createElementWithChildren Breadcrumb props
    static member inline BreadcrumbList ( props : IBreadcrumbListProp list ) = JSX.createElement BreadcrumbList props
    static member inline BreadcrumbList ( props : ReactElement list ) = JSX.createElementWithChildren BreadcrumbList props
    static member inline BreadcrumbItem ( props : IBreadcrumbItemProp list ) = JSX.createElement BreadcrumbItem props
    static member inline BreadcrumbItem ( props : ReactElement list ) = JSX.createElementWithChildren BreadcrumbItem props
    static member inline BreadcrumbLink ( props : IBreadcrumbLinkProp list ) = JSX.createElement BreadcrumbLink props
    static member inline BreadcrumbLink ( props : ReactElement list ) = JSX.createElementWithChildren BreadcrumbLink props
    static member inline BreadcrumbLink ( value : string ) = JSX.createElement BreadcrumbLink [ prop.text value ]
    static member inline BreadcrumbLink ( link : string, value : string ) = JSX.createElement BreadcrumbLink [ prop.href link ; prop.text value ]
    static member inline BreadcrumbPage ( props : IBreadcrumbPageProp list ) = JSX.createElement BreadcrumbPage props
    static member inline BreadcrumbPage ( props : ReactElement list ) = JSX.createElementWithChildren BreadcrumbPage props
    static member inline BreadcrumbPage ( value : string ) = JSX.createElement BreadcrumbPage [ prop.text value ]
    static member inline BreadcrumbSeparator ( props : IBreadcrumbSeparatorProp list ) = JSX.createElement BreadcrumbSeparator props
    static member inline BreadcrumbSeparator ( props : ReactElement list ) = JSX.createElementWithChildren BreadcrumbSeparator props
    static member inline BreadcrumbSeparator () = JSX.createElement BreadcrumbSeparator []
    static member inline BreadcrumbEllipsis ( props : IBreadcrumbEllipsisProp list ) = JSX.createElement BreadcrumbEllipsis props
    static member inline BreadcrumbEllipsis ( props : ReactElement list ) = JSX.createElementWithChildren BreadcrumbEllipsis props
    static member inline BreadcrumbEllipsis () = JSX.createElement BreadcrumbEllipsis []