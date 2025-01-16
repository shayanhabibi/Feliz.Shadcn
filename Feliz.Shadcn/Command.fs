[<AutoOpen>]
module Feliz.Shadcn.Command

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.Shadcn.Dialog
open Feliz.Lucide
open Feliz.style
ignore <| JSX.jsx """
import { Command as CommandPrimitive } from "cmdk";
import { Search } from "lucide-react";
"""
JSX.injectShadcnLib
let (_, _) = Shadcn.Dialog.Dialog, Shadcn.Dialog.DialogContent

// --------------- Command -------------- //
type [<Erase>] ICommandProp = interface end
type [<Erase>] command =
    inherit prop<ICommandProp>
    static member inline value ( value : string ) : ICommandProp = Interop.mkProperty "value" value
    static member inline onValueChange ( handler : string -> unit ) : ICommandProp = Interop.mkProperty "onValueChange" handler
    /// Provide a custom <c>filter</c> function that is called to rank each item. Note that values will be trimmed.
    /// eg: <c>fun (value, search) -> if search = value then 1 else 0</c>
    /// A third argument, keywords, can also be provided to the filter function. Keywords act as aliases for the item value, and can also affect the rank of the item. Keywords are trimmed.
    /// eg: <c> fun (value, search, keywords) -> keywords |> String.concat " " |> (+) $"{value} " |> function | search -> 1 | _ -> 0</c>
    static member inline filter ( handler : string * string -> unit ) : ICommandProp = Interop.mkProperty "filter" handler
    /// Provide a custom <c>filter</c> function that is called to rank each item. Note that values will be trimmed.
    /// eg: <c>fun (value, search) -> if search = value then 1 else 0</c>
    /// A third argument, keywords, can also be provided to the filter function. Keywords act as aliases for the item value, and can also affect the rank of the item. Keywords are trimmed.
    /// eg: <c> fun (value, search, keywords) -> keywords |> String.concat " " |> (+) $"{value} " |> function | search -> 1 | _ -> 0</c>
    static member inline filter ( handler : string * string * string list -> unit ) : ICommandProp = Interop.mkProperty "filter" handler
    static member inline loop : ICommandProp = Interop.mkProperty "loop" true
    
let Command : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <CommandPrimitive
    ref={ref}
    className={cn(
      "flex h-full w-full flex-col overflow-hidden rounded-md bg-popover text-popover-foreground",
      className
    )}
    {...props} />
))
Command.displayName = CommandPrimitive.displayName
"""

// --------------- CommandDialog -------------- //
type [<Erase>] ICommandDialogProp = interface end
type [<Erase>] commandDialog =
    inherit Feliz.RadixUI.Interface.Dialog.root<ICommandDialogProp>
    static member inline noop : unit = ()

let CommandDialog : JSX.ElementType = JSX.jsx """
({
  children,
  ...props
}) => {
  return (
    (<Dialog {...props}>
      <DialogContent className="overflow-hidden p-0">
        <Command
          className="[&_[cmdk-group-heading]]:px-2 [&_[cmdk-group-heading]]:font-medium [&_[cmdk-group-heading]]:text-muted-foreground [&_[cmdk-group]:not([hidden])_~[cmdk-group]]:pt-0 [&_[cmdk-group]]:px-2 [&_[cmdk-input-wrapper]_svg]:h-5 [&_[cmdk-input-wrapper]_svg]:w-5 [&_[cmdk-input]]:h-12 [&_[cmdk-item]]:px-2 [&_[cmdk-item]]:py-3 [&_[cmdk-item]_svg]:h-5 [&_[cmdk-item]_svg]:w-5">
          {children}
        </Command>
      </DialogContent>
    </Dialog>)
  );
}
"""

// --------------- CommandInput -------------- //
type [<Erase>] ICommandInputProp = interface end
type [<Erase>] commandInput =
    inherit prop<ICommandInputProp>
    static member inline value ( value : string ) : ICommandInputProp = Interop.mkProperty "value" value
    static member inline onValueChange ( handler : string -> unit ) : ICommandInputProp = Interop.mkProperty "onValueChange" handler

let CommandInput : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <div className="flex items-center border-b px-3" cmdk-input-wrapper="">
    <Search className="mr-2 h-4 w-4 shrink-0 opacity-50" />
    <CommandPrimitive.Input
      ref={ref}
      className={cn(
        "flex h-10 w-full rounded-md bg-transparent py-3 text-sm outline-none placeholder:text-muted-foreground disabled:cursor-not-allowed disabled:opacity-50",
        className
      )}
      {...props} />
  </div>
))

CommandInput.displayName = CommandPrimitive.Input.displayName
"""

// --------------- CommandList -------------- //
type [<Erase>] ICommandListProp = interface end
type [<Erase>] commandList =
    inherit prop<ICommandListProp>
    static member inline noop : unit = ()

let CommandList : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <CommandPrimitive.List
    ref={ref}
    className={cn("max-h-[300px] overflow-y-auto overflow-x-hidden", className)}
    {...props} />
))

CommandList.displayName = CommandPrimitive.List.displayName
"""

// --------------- CommandEmpty -------------- //
type [<Erase>] ICommandEmptyProp = interface end
type [<Erase>] commandEmpty =
    inherit prop<ICommandEmptyProp>
    static member inline noop : unit = ()

let CommandEmpty : JSX.ElementType = JSX.jsx """
React.forwardRef((props, ref) => (
  <CommandPrimitive.Empty ref={ref} className="py-6 text-center text-sm" {...props} />
))

CommandEmpty.displayName = CommandPrimitive.Empty.displayName
"""

// --------------- CommandGroup -------------- //
type [<Erase>] ICommandGroupProp = interface end
type [<Erase>] commandGroup =
    inherit prop<ICommandGroupProp>
    /// Groups will not unmount from the DOM, rather the <c>hidden</c> attribute is applied to hide it from view. This may be relevant for styling.
    static member inline hidden ( value : bool ) : ICommandGroupProp = Interop.mkProperty "hidden" value
    /// Group items together with the given heading
    static member inline heading ( value : string ) : ICommandGroupProp = Interop.mkProperty "heading" value
    /// Can force a group to always render regardless of filtering by passing the <c>forceMount</c> prop
    static member inline forceMount ( value : bool ) : ICommandGroupProp = Interop.mkProperty "forceMount" value
    
let CommandGroup : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <CommandPrimitive.Group
    ref={ref}
    className={cn(
      "overflow-hidden p-1 text-foreground [&_[cmdk-group-heading]]:px-2 [&_[cmdk-group-heading]]:py-1.5 [&_[cmdk-group-heading]]:text-xs [&_[cmdk-group-heading]]:font-medium [&_[cmdk-group-heading]]:text-muted-foreground",
      className
    )}
    {...props} />
))

CommandGroup.displayName = CommandPrimitive.Group.displayName
"""

// --------------- CommandSeparator -------------- //
type [<Erase>] ICommandSeparatorProp = interface end
type [<Erase>] commandSeparator =
    inherit prop<ICommandSeparatorProp>
    static member inline alwaysRender ( value : bool ) : ICommandSeparatorProp = Interop.mkProperty "alwaysRender" value

let CommandSeparator : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <CommandPrimitive.Separator ref={ref} className={cn("-mx-1 h-px bg-border", className)} {...props} />
))
CommandSeparator.displayName = CommandPrimitive.Separator.displayName
"""


// --------------- CommandItem -------------- //
type [<Erase>] ICommandItemProp = interface end
type [<Erase>] commandItem =
    inherit prop<ICommandItemProp>
    static member inline disabled ( value : bool ) : ICommandItemProp = Interop.mkProperty "disabled" value
    static member inline selected ( value : bool ) : ICommandItemProp = Interop.mkProperty "selected" value
    static member inline onSelect ( handler : string -> unit ) : ICommandItemProp = Interop.mkProperty "onSelect" handler
    /// The value can be declared explicitly or inferred from text content
    static member inline value ( value : string ) : ICommandItemProp = Interop.mkProperty "value" value
    /// Keywords are trimmed and can help with filtering (see <c>filter</c> for Command)
    static member inline keywords ( value : string list ) : ICommandItemProp = Interop.mkProperty "keywords" value
    /// Can force item to always render regardless of filtering using <c>forceMount</c>
    static member inline forceMount ( value : bool ) : ICommandItemProp = Interop.mkProperty "forceMount" value
    
let CommandItem : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <CommandPrimitive.Item
    ref={ref}
    className={cn(
      "relative flex cursor-default gap-2 select-none items-center rounded-sm px-2 py-1.5 text-sm outline-none data-[disabled=true]:pointer-events-none data-[selected=true]:bg-accent data-[selected=true]:text-accent-foreground data-[disabled=true]:opacity-50 [&_svg]:pointer-events-none [&_svg]:size-4 [&_svg]:shrink-0",
      className
    )}
    {...props} />
))

CommandItem.displayName = CommandPrimitive.Item.displayName
"""

// --------------- CommandShortcut -------------- //
type [<Erase>] ICommandShortcutProp = interface end
type [<Erase>] commandShortcut =
    inherit prop<ICommandShortcutProp>
    static member inline noop : unit = ()

let CommandShortcut : JSX.ElementType = JSX.jsx """
({
  className,
  ...props
}) => {
  return (
    (<span
      className={cn("ml-auto text-xs tracking-widest text-muted-foreground", className)}
      {...props} />)
  );
}
CommandShortcut.displayName = "CommandShortcut"
"""

type [<Erase>] Shadcn =
    static member inline Command ( props : ICommandProp list ) = JSX.createElement Command props
    static member inline Command ( children : ReactElement list ) = JSX.createElementWithChildren Command children
    static member inline CommandDialog ( props : ICommandDialogProp list ) = JSX.createElement CommandDialog props
    static member inline CommandDialog ( children : ReactElement list ) = JSX.createElementWithChildren CommandDialog children
    static member inline CommandInput ( props : ICommandInputProp list ) = JSX.createElement CommandInput props
    static member inline CommandInput ( children : ReactElement list ) = JSX.createElementWithChildren CommandInput children
    static member inline CommandInput ( placeholder : string ) = JSX.createElement CommandInput [ prop.placeholder placeholder ]
    static member inline CommandList ( props : ICommandListProp list ) = JSX.createElement CommandList props
    static member inline CommandList ( children : ReactElement list ) = JSX.createElementWithChildren CommandList children
    static member inline CommandEmpty ( props : ICommandEmptyProp list ) = JSX.createElement CommandEmpty props
    static member inline CommandEmpty ( children : ReactElement list ) = JSX.createElementWithChildren CommandEmpty children
    static member inline CommandEmpty ( value : string ) = JSX.createElement CommandEmpty [ prop.text value ]
    static member inline CommandGroup ( props : ICommandGroupProp list ) = JSX.createElement CommandGroup props
    static member inline CommandGroup ( children : ReactElement list ) = JSX.createElementWithChildren CommandGroup children
    static member inline CommandGroup ( heading : string , children : ReactElement list) = JSX.createElement CommandGroup [ commandGroup.heading heading ; commandGroup.children children ]
    static member inline CommandGroup ( value : string ) = JSX.createElement CommandGroup [ commandGroup.heading value ]
    static member inline CommandItem ( props : ICommandItemProp list ) = JSX.createElement CommandItem props
    static member inline CommandItem ( children : ReactElement list ) = JSX.createElementWithChildren CommandItem children
    static member inline CommandItem ( value : string ) = JSX.createElement CommandItem [ prop.text value ]
    static member inline CommandShortcut ( props : ICommandShortcutProp list ) = JSX.createElement CommandShortcut props
    static member inline CommandShortcut ( children : ReactElement list ) = JSX.createElementWithChildren CommandShortcut children
    static member inline CommandShortcut ( value : string ) = JSX.createElement CommandShortcut [ prop.text value ]
    static member inline CommandSeparator ( props : ICommandSeparatorProp list ) = JSX.createElement CommandSeparator props
    static member inline CommandSeparator ( children : ReactElement list ) = JSX.createElementWithChildren CommandSeparator children
    static member inline CommandSeparator () = JSX.createElement CommandSeparator []
    