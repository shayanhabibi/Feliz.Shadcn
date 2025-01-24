[<AutoOpen>]
module Feliz.Shadcn.Table

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
JSX.injectShadcnLib

// --------------- Table -------------- //
type [<Erase>] ITableProp = interface static member propsInterface : unit = () end

let Table : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <div className="relative w-full overflow-auto">
    <table
      ref={ref}
      className={cn("w-full caption-bottom text-sm", className)}
      {...props} />
  </div>
))
Table.displayName = "Table"
"""

// --------------- TableHeader -------------- //
type [<Erase>] ITableHeaderProp = interface static member propsInterface : unit = () end

let TableHeader : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <thead ref={ref} className={cn("[&_tr]:border-b", className)} {...props} />
))
TableHeader.displayName = "TableHeader"
"""

// --------------- TableBody -------------- //
type [<Erase>] ITableBodyProp = interface static member propsInterface : unit = () end

let TableBody : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <tbody
    ref={ref}
    className={cn("[&_tr:last-child]:border-0", className)}
    {...props} />
))
TableBody.displayName = "TableBody"
"""

// --------------- TableFooter -------------- //
type [<Erase>] ITableFooterProp = interface static member propsInterface : unit = () end

let TableFooter : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <tfoot
    ref={ref}
    className={cn("border-t bg-muted/50 font-medium [&>tr]:last:border-b-0", className)}
    {...props} />
))
TableFooter.displayName = "TableFooter"
"""

// --------------- TableRow -------------- //
type [<Erase>] ITableRowProp = interface static member propsInterface : unit = () end

let TableRow : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <tr
    ref={ref}
    className={cn(
      "border-b transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted",
      className
    )}
    {...props} />
))
TableRow.displayName = "TableRow"
"""

// --------------- TableHead -------------- //
type [<Erase>] ITableHeadProp = interface static member propsInterface : unit = () end

let TableHead : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <th
    ref={ref}
    className={cn(
      "h-10 px-2 text-left align-middle font-medium text-muted-foreground [&:has([role=checkbox])]:pr-0 [&>[role=checkbox]]:translate-y-[2px]",
      className
    )}
    {...props} />
))
TableHead.displayName = "TableHead"
"""

// --------------- TableCell -------------- //
type [<Erase>] ITableCellProp = interface static member propsInterface : unit = () end

let TableCell : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <td
    ref={ref}
    className={cn(
      "p-2 align-middle [&:has([role=checkbox])]:pr-0 [&>[role=checkbox]]:translate-y-[2px]",
      className
    )}
    {...props} />
))
TableCell.displayName = "TableCell"
"""

// --------------- TableCaption -------------- //
type [<Erase>] ITableCaptionProp = interface static member propsInterface : unit = () end

let TableCaption : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <caption
    ref={ref}
    className={cn("mt-4 text-sm text-muted-foreground", className)}
    {...props} />
))
TableCaption.displayName = "TableCaption"
"""

type [<Erase>] Shadcn =
    static member inline Table ( props : ITableProp list ) = JSX.createElement Table props
    static member inline Table ( children : ReactElement list ) = JSX.createElementWithChildren Table children
    static member inline TableHeader ( props : ITableHeaderProp list ) = JSX.createElement TableHeader props
    static member inline TableHeader ( children : ReactElement list ) = JSX.createElementWithChildren TableHeader children
    static member inline TableBody ( props : ITableBodyProp list ) = JSX.createElement TableBody props
    static member inline TableBody ( children : ReactElement list ) = JSX.createElementWithChildren TableBody children
    static member inline TableFooter ( props : ITableFooterProp list ) = JSX.createElement TableFooter props
    static member inline TableFooter ( children : ReactElement list ) = JSX.createElementWithChildren TableFooter children
    static member inline TableHead ( props : ITableHeadProp list ) = JSX.createElement TableHead props
    static member inline TableHead ( children : ReactElement list ) = JSX.createElementWithChildren TableHead children
    static member inline TableRow ( props : ITableRowProp list ) = JSX.createElement TableRow props
    static member inline TableRow ( children : ReactElement list ) = JSX.createElementWithChildren TableRow children
    static member inline TableCell ( props : ITableCellProp list ) = JSX.createElement TableCell props
    static member inline TableCell ( children : ReactElement list ) = JSX.createElementWithChildren TableCell children
    static member inline TableCaption ( props : ITableCaptionProp list ) = JSX.createElement TableCaption props
    static member inline TableCaption ( children : ReactElement list ) = JSX.createElementWithChildren TableCaption children
                            