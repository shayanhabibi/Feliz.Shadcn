/// Table views are used to display data in a tabular format.
/// They are useful for displaying large amounts of data in a structured way.
[<AutoOpen>]
module Feliz.Shadcn.RoadmapUI.Table

open Fable.React
open Feliz.Shadcn
open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
JSX.injectShadcnLib
ignore <| JSX.jsx """
import {
  flexRender,
  getCoreRowModel,
  getSortedRowModel,
  useReactTable,
} from '@tanstack/react-table';
import { ArrowDownIcon, ArrowUpIcon, ChevronsUpDownIcon } from 'lucide-react';
import { createContext, useContext } from 'react';
import { create } from 'zustand';
import { devtools } from 'zustand/middleware'
"""
open Feliz.Shadcn
let private TableBodyRaw = TableBody
let private TableCellRaw = TableCell
let private TableHeadRaw = TableHead
let private TableHeaderRaw = TableHeader
let private TableRaw = Table
let private TableRowRaw = TableRow
let private imports = (
    DropdownMenu,
    DropdownMenuContent,
    DropdownMenuItem,
    DropdownMenuTrigger,
    Button
)

type [<Erase>] TableState =
    {
        sorting : obj // TODO - SortingState from tanstack
        setSorting : obj -> unit // TODO - SortingState from tanstack
    }

let useTable : TableState = unbox <| JSX.jsx """
create()(devtools((set) => ({
  sorting: [],
  setSorting: (sorting) => set(() => ({ sorting })),
})))
"""

type [<Erase>] TableContext =
    {
        data : obj list
        columns : obj list
        table : obj
    }

let TableContext : IContext<TableContext> = unbox <| JSX.jsx """
createContext({
  data: [],
  columns: [],
  table: null,
})"""

// --------------- TableProvider -------------- //
type [<Erase>] ITableProviderProp = interface end
type [<Erase>] tableProvider =
    static member inline columns ( value : obj list ) : ITableProviderProp = Interop.mkProperty "columns" value // TODO - Tanstack ColumnDef
    static member inline data ( value : obj list ) : ITableProviderProp = Interop.mkProperty "data" value // TODO - Tanstack TData
    static member inline children ( value : ReactElement list ) : ITableProviderProp = Interop.mkProperty "children" value
    static member inline children ( value : ReactElement ) : ITableProviderProp = Interop.mkProperty "children" value
    static member inline className ( value : string ) : ITableProviderProp = Interop.mkProperty "className" value

let TableProvider : JSX.ElementType = JSX.jsx """
(
  {
    columns,
    data,
    children,
    className
  }
) => {
  const { sorting, setSorting } = useTable();
  const table = useReactTable({
    data,
    columns,
    getCoreRowModel: getCoreRowModel(),
    getSortedRowModel: getSortedRowModel(),
    onSortingChange: (updater) => {
      // @ts-expect-error updater is a function that returns a sorting object
      const newSorting = updater(sorting);

      setSorting(newSorting);
    },
    state: {
      sorting,
    },
  });

  return (
    (<TableContext.Provider
      value={{
        data,
        columns: columns,
        table: table,
      }}>
      <TableRaw className={className}>{children}</TableRaw>
    </TableContext.Provider>)
  );
}
"""

// --------------- TableHead -------------- //
type [<Erase>] ITableHeadProp = interface end
type [<Erase>] tableHead =
    static member inline header ( value : obj ) : ITableHeadProp = Interop.mkProperty "header" value // TODO - Tanstack Header type
    static member inline className ( value : string ) : ITableHeadProp = Interop.mkProperty "className" value

let TableHead : JSX.ElementType = JSX.jsx """
({
  header,
  className
}) => (
  <TableHeadRaw key={header.id} className={className}>
    {header.isPlaceholder
      ? null
      : flexRender(header.column.columnDef.header, header.getContext())}
  </TableHeadRaw>
)
"""

// --------------- TableHeaderGroup -------------- //
type [<Erase>] ITableHeaderGroupProp = interface end
type [<Erase>] tableHeaderGroup =
    static member inline headerGroup ( value : obj ) : ITableHeaderGroupProp = Interop.mkProperty "headerGroup" value //TODO - Headergroup Tanstack
    static member inline children ( value : ReactElement list ) : ITableHeaderGroupProp = Interop.mkProperty "children" value
    static member inline children ( value : ReactElement ) : ITableHeaderGroupProp = Interop.mkProperty "children" value

let TableHeaderGroup : JSX.ElementType = JSX.jsx """
({
  headerGroup,
  children
}) => (
  <TableRowRaw key={headerGroup.id}>
    {headerGroup.headers.map((header) => children({ header }))}
  </TableRowRaw>
)
"""

// --------------- TableHeader -------------- //
type [<Erase>] ITableHeaderProp = interface end
type [<Erase>] tableHeader =
    static member inline className ( value : string ) : ITableHeaderProp = Interop.mkProperty "className" value
    static member inline children ( value : JSX.ElementType ) : ITableHeaderProp = Interop.mkProperty "children" value
    static member inline children ( value : {| headerGroup : obj |} -> ReactElement ) : ITableHeaderProp = Interop.mkProperty "children" value // TODO - tanstack headerGroup type

let TableHeader : JSX.ElementType = JSX.jsx """
({
  className,
  children
}) => {
  const { table } = useContext(TableContext);

  return (
    (<TableHeaderRaw className={className}>
      {table?.getHeaderGroups().map((headerGroup) => children({ headerGroup }))}
    </TableHeaderRaw>)
  );
}
"""

// --------------- TableColumnHeader -------------- //
type [<Erase>] ITableColumnHeaderProp = interface end
type [<Erase>] tableColumnHeader =
    inherit prop<ITableColumnHeaderProp>
    static member inline column ( value : obj ) : ITableColumnHeaderProp = Interop.mkProperty "column" value // TODO - tanstack Column
    static member inline title ( value : string ) : ITableColumnHeaderProp = Interop.mkProperty "title" value

let TableColumnHeader : JSX.ElementType = JSX.jsx """
(
  {
    column,
    title,
    className
  }
) => {
  if (!column.getCanSort()) {
    return <div className={cn(className)}>{title}</div>;
  }

  return (
    (<div className={cn('flex items-center space-x-2', className)}>
      <DropdownMenu>
        <DropdownMenuTrigger asChild>
          <Button
            variant="ghost"
            size="sm"
            className="-ml-3 h-8 data-[state=open]:bg-accent">
            <span>{title}</span>
            {column.getIsSorted() === 'desc' ? (
              <ArrowDownIcon className="ml-2 h-4 w-4" />
            ) : column.getIsSorted() === 'asc' ? (
              <ArrowUpIcon className="ml-2 h-4 w-4" />
            ) : (
              <ChevronsUpDownIcon className="ml-2 h-4 w-4" />
            )}
          </Button>
        </DropdownMenuTrigger>
        <DropdownMenuContent align="start">
          <DropdownMenuItem onClick={() => column.toggleSorting(false)}>
            <ArrowUpIcon className="mr-2 h-3.5 w-3.5 text-muted-foreground/70" />
            Asc
          </DropdownMenuItem>
          <DropdownMenuItem onClick={() => column.toggleSorting(true)}>
            <ArrowDownIcon className="mr-2 h-3.5 w-3.5 text-muted-foreground/70" />
            Desc
          </DropdownMenuItem>
        </DropdownMenuContent>
      </DropdownMenu>
    </div>)
  );
}
"""

// --------------- TableCell -------------- //
type [<Erase>] ITableCellProp = interface end
type [<Erase>] tableCell =
    static member inline cell ( value : obj ) : ITableCellProp = Interop.mkProperty "cell" value // TODO - tanstack Cell type
    static member inline className ( value : string ) : ITableCellProp = Interop.mkProperty "className" value

let TableCell : JSX.ElementType = JSX.jsx """
({
  cell,
  className
}) => (
  <TableCellRaw className={className}>
    {flexRender(cell.column.columnDef.cell, cell.getContext())}
  </TableCellRaw>
)
"""

// --------------- TableRow -------------- //
type [<Erase>] ITableRowProp = interface end
type [<Erase>] tableRow =
    static member inline row ( value : obj ) : ITableRowProp = Interop.mkProperty "row" value // TODO - tanstack Row
    static member inline children ( value : JSX.ElementType ) : ITableRowProp = Interop.mkProperty "children" value
    static member inline children ( value : {| row : obj |} -> ReactElement ) : ITableRowProp = Interop.mkProperty "children" value // TODO - tanstack Row
    static member inline className ( value : string ) : ITableRowProp = Interop.mkProperty "className" value

let TableRow : JSX.ElementType = JSX.jsx """
({
  row,
  children,
  className
}) => (
  <TableRowRaw
    key={row.id}
    data-state={row.getIsSelected() && 'selected'}
    className={className}>
    {row.getVisibleCells().map((cell) => children({ cell }))}
  </TableRowRaw>
)
"""

// --------------- TableBody -------------- //
type [<Erase>] ITableBodyProp = interface end
type [<Erase>] tableBody =
    static member inline children ( value : JSX.ElementType ) : ITableBodyProp = Interop.mkProperty "children" value
    static member inline children ( value : {| row : obj |} -> ReactElement ) : ITableBodyProp = Interop.mkProperty "children" value // TODO - tanstack Row type
    static member inline className ( value : string ) : ITableBodyProp = Interop.mkProperty "className" value

let TableBody : JSX.ElementType = JSX.jsx """
({
  children,
  className
}) => {
  const { columns, table } = useContext(TableContext);
  const rows = table?.getRowModel().rows;

  return (
    (<TableBodyRaw className={className}>
      {rows?.length ? (
        rows.map((row) => children({ row }))
      ) : (
        <TableRowRaw>
          <TableCellRaw colSpan={columns.length} className="h-24 text-center">
            No results.
          </TableCellRaw>
        </TableRowRaw>
      )}
    </TableBodyRaw>)
  );
}
"""

type [<Erase>] Shadcn =
    static member inline TableColumnHeader ( props : ITableColumnHeaderProp list ) = JSX.createElement TableColumnHeader props
    static member inline TableColumnHeader ( children : ReactElement list ) = JSX.createElementWithChildren TableColumnHeader children
    /// The <c>TableProvider</c> component is the root component of the Table. It contains the context for the other components.
    static member inline TableProvider ( props : ITableProviderProp list ) = JSX.createElement TableProvider props
    /// The <c>TableProvider</c> component is the root component of the Table. It contains the context for the other components.
    static member inline TableProvider ( children : ReactElement list ) = JSX.createElementWithChildren TableProvider children
    /// The <c>TableBody</c> component is a container for the rows of the Table.
    static member inline TableBody ( props : ITableBodyProp list ) = JSX.createElement TableBody props
    /// The <c>TableBody</c> component is a container for the rows of the Table.
    static member inline TableBody ( children : ReactElement list ) = JSX.createElementWithChildren TableBody children
    /// The <c>TableCell</c> component is a single cell in the Table.
    static member inline TableCell ( props : ITableCellProp list ) = JSX.createElement TableCell props
    /// The <c>TableCell</c> component is a single cell in the Table.
    static member inline TableCell ( children : ReactElement list ) = JSX.createElementWithChildren TableCell children
    /// The <c>TableHead</c> component is a single column header in the Table.
    static member inline TableHead ( props : ITableHeadProp list ) = JSX.createElement TableHead props
    /// The <c>TableHead</c> component is a single column header in the Table.
    static member inline TableHead ( children : ReactElement list ) = JSX.createElementWithChildren TableHead children
    /// The <c>TableHeader</c> component is a container for the column headers of the Table.
    static member inline TableHeader ( props : ITableHeaderProp list ) = JSX.createElement TableHeader props
    /// The <c>TableHeader</c> component is a container for the column headers of the Table.
    static member inline TableHeader ( children : ReactElement list ) = JSX.createElementWithChildren TableHeader children
    /// The <c>TableHeaderGroup</c> component is a container for the column headers of the Table.
    static member inline TableHeaderGroup ( props : ITableHeaderGroupProp list ) = JSX.createElement TableHeaderGroup props
    /// The <c>TableHeaderGroup</c> component is a container for the column headers of the Table.
    static member inline TableHeaderGroup ( children : ReactElement list ) = JSX.createElementWithChildren TableHeaderGroup children
    /// The <c>TableRow</c> component is a single row in the Table.
    static member inline TableRow ( props : ITableRowProp list ) = JSX.createElement TableRow props
    /// The <c>TableRow</c> component is a single row in the Table.
    static member inline TableRow ( children : ReactElement list ) = JSX.createElementWithChildren TableRow children                            