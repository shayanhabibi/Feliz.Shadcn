[<AutoOpen>]
module Feliz.Shadcn.Command

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.Shadcn.Dialog
open Feliz.Lucide
open Feliz.style

emitJsStatement () "import { Command as CommandPrimitive } from \"cmdk\""

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
    
[<JSX.Component>]
let Command ( props : ICommandProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <CommandPrimitive
        ref={ref}
        className={ JSX.cn [|
            "flex h-full w-full flex-col overflow-hidden rounded-md bg-popover text-popover-foreground"
            properties?className
        |] }
    """ |> unbox

// --------------- CommandDialog -------------- //
type [<Erase>] ICommandDialogProp = interface end
type [<Erase>] commandDialog =
    inherit Feliz.RadixUI.Dialog.root<ICommandDialogProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let CommandDialog ( props : ICommandDialogProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {children, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <Dialog {{...sprops}} {{...attrs}}>
        <DialogContent className="overflow-hidden p-0">
            <Command
                className="[&_[cmdk-group-heading]]:px-2 [&_[cmdk-group-heading]]:font-medium [&_[cmdk-group-heading]]:text-muted-foreground [&_[cmdk-group]:not([hidden])_~[cmdk-group]]:pt-0 [&_[cmdk-group]]:px-2 [&_[cmdk-input-wrapper]_svg]:h-5 [&_[cmdk-input-wrapper]_svg]:w-5 [&_[cmdk-input]]:h-12 [&_[cmdk-item]]:px-2 [&_[cmdk-item]]:py-3 [&_[cmdk-item]_svg]:h-5 [&_[cmdk-item]_svg]:w-5"
            >
            {properties?children}
            </Command>
        </DialogContent>
    </Dialog>
    """ |> unbox

// --------------- CommandInput -------------- //
type [<Erase>] ICommandInputProp = interface end
type [<Erase>] commandInput =
    inherit prop<ICommandInputProp>
    static member inline value ( value : string ) : ICommandInputProp = Interop.mkProperty "value" value
    static member inline onValueChange ( handler : string -> unit ) : ICommandInputProp = Interop.mkProperty "onValueChange" handler

[<JSX.Component>]
let CommandInput ( props : ICommandInputProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <div className="flex items-center border-b px-3" cmd-input-wrapper="">
        { Icon.Search [ icon.className "mr-2 h-4 w-4 shrink-0 opacity-50" ]}
        <CommandPrimitive.Input
            ref={ref}
            className={ JSX.cn [|
                "flex h-10 w-full rounded-md bg-transparent py-3 text-sm outline-none placeholder:text-muted-foreground disabled:cursor-not-allowed disabled:opacity-50"
                properties?className
            |] }
            {{...sprops}} {{...attrs}} />
    </div>
    """ |> unbox

// --------------- CommandList -------------- //
type [<Erase>] ICommandListProp = interface end
type [<Erase>] commandList =
    inherit prop<ICommandListProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let CommandList ( props : ICommandListProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <CommandPrimitive.List
        ref={ref}
        className={ JSX.cn [|
            "max-h-[300px] overflow-y-auto overflow-x-hidden"
            properties?className
        |] }
        {{...attrs}} {{...sprops}} />
    """ |> unbox

// --------------- CommandEmpty -------------- //
type [<Erase>] ICommandEmptyProp = interface end
type [<Erase>] commandEmpty =
    inherit prop<ICommandEmptyProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let CommandEmpty ( props : ICommandEmptyProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <CommandPrimitive.Empty ref={ref} className="py-6 text-center text-sm" {{...sprops}} {{...attrs}} />
    """ |> unbox

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
    
[<JSX.Component>]
let CommandGroup ( props : ICommandGroupProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <CommandPrimitive.Group
        ref={ref}
        className={ JSX.cn [|
            "overflow-hidden p-1 text-foreground [&_[cmdk-group-heading]]:px-2 [&_[cmdk-group-heading]]:py-1.5 [&_[cmdk-group-heading]]:text-xs [&_[cmdk-group-heading]]:font-medium [&_[cmdk-group-heading]]:text-muted-foreground"
            properties?className
        |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- CommandSeparator -------------- //
type [<Erase>] ICommandSeparatorProp = interface end
type [<Erase>] commandSeparator =
    inherit prop<ICommandSeparatorProp>
    static member inline alwaysRender ( value : bool ) : ICommandSeparatorProp = Interop.mkProperty "alwaysRender" value

[<JSX.Component>]
let CommandSeparator ( props : ICommandSeparatorProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <CommandPrimitive.Separator ref={ref} className={ JSX.cn [| "-mx-1 h-px bg-border" ; properties?className |] } {{...sprops}} {{...attrs}} />
    """ |> unbox


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
    
[<JSX.Component>]
let CommandItem ( props : ICommandItemProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <CommandPrimitive.Item
        ref={ref}
        className={ JSX.cn [|
            "relative flex cursor-default gap-2 select-none items-center rounded-sm px-2 py-1.5 text-sm outline-none data-[disabled=true]:pointer-events-none data-[selected=true]:bg-accent data-[selected=true]:text-accent-foreground data-[disabled=true]:opacity-50 [&_svg]:pointer-events-none [&_svg]:size-4 [&_svg]:shrink-0"
            properties?className
        |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- CommandShortcut -------------- //
type [<Erase>] ICommandShortcutProp = interface end
type [<Erase>] commandShortcut =
    inherit prop<ICommandShortcutProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let CommandShortcut ( props : ICommandShortcutProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <span
        className={ JSX.cn [|
            "ml-auto text-xs tracking-widest text-muted-foreground"
            properties?className
        |] }
        {{...attrs}} {{...sprops}} />
    """ |> unbox