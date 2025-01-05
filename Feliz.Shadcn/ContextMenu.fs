[<AutoOpen>]
module Feliz.Shadcn.ContextMenu

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.RadixUI

emitJsStatement () "import * as ContextMenuPrimitive from \"@radix-ui/react-context-menu\""

// --------------- ContextMenu -------------- //
type [<Erase>] IContextMenuProp = interface end
type [<Erase>] contextMenu =
    inherit ContextMenu.root<IContextMenuProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let ContextMenu ( props : IContextMenuProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <ContextMenuPrimitive.Root {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- ContextMenuTrigger -------------- //
type [<Erase>] IContextMenuTriggerProp = interface end
type [<Erase>] contextMenuTrigger =
    inherit ContextMenu.trigger<IContextMenuTriggerProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let ContextMenuTrigger ( props : IContextMenuTriggerProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <ContextMenuPrimitive.Trigger {{...sprops}} {{...attrs}} />
    """ |> unbox
    
// --------------- ContextMenuGroup -------------- //
type [<Erase>] IContextMenuGroupProp = interface end
type [<Erase>] contextMenuGroup =
    inherit ContextMenu.group<IContextMenuGroupProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let ContextMenuGroup ( props : IContextMenuGroupProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <ContextMenuPrimitive.Group {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- ContextMenuPortal -------------- //
type [<Erase>] IContextMenuPortalProp = interface end
type [<Erase>] contextMenuPortal =
    inherit ContextMenu.portal<IContextMenuPortalProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let ContextMenuPortal ( props : IContextMenuPortalProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <ContextMenuPrimitive.Portal {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- ContextMenuSub -------------- //
type [<Erase>] IContextMenuSubProp = interface end
type [<Erase>] contextMenuSub =
    inherit ContextMenu.sub<IContextMenuSubProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let ContextMenuSub ( props : IContextMenuSubProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <ContextMenuPrimitive.Sub {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- ContextMenuRadioGroup -------------- //
type [<Erase>] IContextMenuRadioGroupProp = interface end
type [<Erase>] contextMenuRadioGroup =
    inherit ContextMenu.radioGroup<IContextMenuRadioGroupProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let ContextMenuRadioGroup ( props : IContextMenuRadioGroupProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <ContextMenuPrimitive.RadioGroup {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- ContextMenuSubTrigger -------------- //
type [<Erase>] IContextMenuSubTriggerProp = interface end
type [<Erase>] contextMenuSubTrigger =
    inherit ContextMenu.subTrigger<IContextMenuSubTriggerProp>
    static member inline noop : unit = ()

open Feliz.Lucide

[<JSX.Component>]
let ContextMenuSubTrigger ( props : IContextMenuSubTriggerProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {inset, className, children, ...sprops} = $0; const {props, ...attrs} = $props;"
    let insetClass =
        match properties?inset with
        | null -> ""
        | _ -> "pl-8"
    JSX.jsx $"""
    <ContextMenuPrimitive.SubTrigger
        ref={ref}
        className={ JSX.cn [|
            "flex cursor-default select-none items-center rounded-sm px-2 py-1.5 text-sm outline-none focus:bg-accent focus:text-accent-foreground data-[state=open]:bg-accent data-[state=open]:text-accent-foreground"
            insetClass
            properties?className
        |] }
        {{...attrs}} {{...sprops}} >
        {{children}}
        {Icon.ChevronRight [ icon.className "ml-auto h-4 w-4" ]}
    </ContextMenuPrimitive.SubTrigger>
    """ |> unbox

// --------------- ContextMenuSubContent -------------- //
type [<Erase>] IContextMenuSubContentProp = interface end
type [<Erase>] contextMenuSubContent =
    inherit ContextMenu.subContent<IContextMenuSubContentProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let ContextMenuSubContent ( props : IContextMenuSubContentProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <ContextMenuPrimitive.SubContent
        ref={ref}
        className={ JSX.cn [|
            "z-50 min-w-[8rem] overflow-hidden rounded-md border bg-popover p-1 text-popover-foreground shadow-lg data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0 data-[state=closed]:zoom-out-95 data-[state=open]:zoom-in-95 data-[side=bottom]:slide-in-from-top-2 data-[side=left]:slide-in-from-right-2 data-[side=right]:slide-in-from-left-2 data-[side=top]:slide-in-from-bottom-2"
            properties?className
        |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- ContextMenuContent -------------- //
type [<Erase>] IContextMenuContentProp = interface end
type [<Erase>] contextMenuContent =
    inherit ContextMenu.content<IContextMenuContentProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let ContextMenuContent ( props : IContextMenuContentProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <ContextMenuPrimitive.Portal>
        <ContextMenuPrimitive.Content
            ref={ref}
            className={ JSX.cn [|
                "z-50 min-w-[8rem] overflow-hidden rounded-md border bg-popover p-1 text-popover-foreground shadow-md data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0 data-[state=closed]:zoom-out-95 data-[state=open]:zoom-in-95 data-[side=bottom]:slide-in-from-top-2 data-[side=left]:slide-in-from-right-2 data-[side=right]:slide-in-from-left-2 data-[side=top]:slide-in-from-bottom-2"
                properties?className
            |] }
            {{...sprops}} {{...attrs}} />
    </ContextMenuPrimitive.Portal>
    """ |> unbox
    
// --------------- ContextMenuItem -------------- //
type [<Erase>] IContextMenuItemProp = interface end
type [<Erase>] contextMenuItem =
    inherit ContextMenu.item<IContextMenuItemProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let ContextMenuItem ( props : IContextMenuItemProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, inset, ...sprops} = $0; const {props, ...attrs} = $props;"
    let insetClass = match properties?inset with
                         | null -> ""
                         | _ -> "pl-8"
    JSX.jsx $"""
    <ContextMenuPrimitive.Item
        ref={ref}
        className={ JSX.cn [|
            "relative flex cursor-default select-none items-center rounded-sm px-2 py-1.5 text-sm outline-none focus:bg-accent focus:text-accent-foreground data-[disabled]:pointer-events-none data-[disabled]:opacity-50"
            insetClass
            properties?className
        |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox
    
// --------------- ContextMenuCheckboxItem -------------- //
type [<Erase>] IContextMenuCheckboxItemProp = interface end
type [<Erase>] contextMenuCheckboxItem =
    inherit ContextMenu.checkboxItem<IContextMenuCheckboxItemProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let ContextMenuCheckboxItem ( props : IContextMenuCheckboxItemProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, children, checked, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <ContextMenuPrimitive.CheckboxItem
        ref={ref}
        className={ JSX.cn [|
            "relative flex cursor-default select-none items-center rounded-sm py-1.5 pl-8 pr-2 text-sm outline-none focus:bg-accent focus:text-accent-foreground data-[disabled]:pointer-events-none data-[disabled]:opacity-50"
            properties?className
        |] }
        checked={{checked}}
        {{...sprops}} {{...attrs}}>
        <span className="absolute left-2 flex h-3.5 w-3.5 items-center justify-center">
            <ContextMenuPrimitive.ItemIndicator>
                {Icon.Check [ icon.className "h-4 w-4" ]}
            </ContextMenuPrimitive.ItemIndicator>
        </span>
        {properties?children}
    </ContextMenuPrimitive.CheckboxItem>
    """ |> unbox

// --------------- ContextMenuRadioItem -------------- //
type [<Erase>] IContextMenuRadioItemProp = interface end
type [<Erase>] contextMenuRadioItem =
    inherit ContextMenu.radioItem<IContextMenuRadioItemProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let ContextMenuRadioItem ( props : IContextMenuRadioItemProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, children, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <ContextMenuPrimitive.RadioItem
        ref={ref}
        className={ JSX.cn [|
            "relative flex cursor-default select-none items-center rounded-sm py-1.5 pl-8 pr-2 text-sm outline-none focus:bg-accent focus:text-accent-foreground data-[disabled]:pointer-events-none data-[disabled]:opacity-50"
            properties?className
        |] }
        {{...sprops}} {{...attrs}}>
        <span className="absolute left-2 flex h-3.5 w-3.5 items-center justify-center">
            <ContextMenuPrimitive.ItemIndicator>
                { Icon.Circle [ icon.className "h-4 w-4 filll-current" ] }
            </ContextMenuPrimitive.ItemIndicator>
        </span>
        {properties?children}
    </ContextMenuPrimitive.RadioItem>
    """ |> unbox

// --------------- ContextMenuLabel -------------- //
type [<Erase>] IContextMenuLabelProp = interface end
type [<Erase>] contextMenuLabel =
    inherit ContextMenu.label<IContextMenuLabelProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let ContextMenuLabel ( props : IContextMenuLabelProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, inset, ...sprops} = $0; const {props, ...attrs} = $props;"
    let insetClass =
        match properties?inset with
        | null -> ""
        | _ -> "pl-8"
    JSX.jsx $"""
    <ContextMenuPrimitive.Label
        ref={ref}
        className={ JSX.cn [|
            "px-2 py-1.5 text-sm font-semibold text-foreground"
            insetClass
            properties?className
        |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- ContextMenuSeparator -------------- //
type [<Erase>] IContextMenuSeparatorProp = interface end
type [<Erase>] contextMenuSeparator =
    inherit ContextMenu.separator<IContextMenuSeparatorProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let ContextMenuSeparator ( props : IContextMenuSeparatorProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <ContextMenuPrimitive.Separator
        ref={ref}
        className={ JSX.cn [|
            "-mx-1 my-1 h-px bg-border"
            properties?className
        |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- ContextMenuShortcut -------------- //
type [<Erase>] IContextMenuShortcutProp = interface end
type [<Erase>] contextMenuShortcut =
    inherit prop<IContextMenuShortcutProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let ContextMenuShortcut ( props : IContextMenuShortcutProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <span className={ JSX.cn [| "ml-auto text-xs tracking-widest text-muted-foreground" ; properties?className |] }
        {{...sprops}} {{...attrs}}/>
    """ |> unbox