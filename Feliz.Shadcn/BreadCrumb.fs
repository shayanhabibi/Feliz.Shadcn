[<AutoOpen>]
module Feliz.Shadcn.BreadCrumb

open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz

emitJsStatement () "import { Slot } from \"@radix-ui/react-slot\""

// --------------- Breadcrumb -------------- //
type [<Erase>] IBreadcrumbProp = interface end
type [<Erase>] breadCrumb =
    inherit prop<IBreadcrumbProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let Breadcrumb ( props : IBreadcrumbProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <nav ref={ref} aria-label="breadcrumb" {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- BreadcrumbList -------------- //
type [<Erase>] IBreadcrumbListProp = interface end
type [<Erase>] breadcrumbList =
    inherit prop<IBreadcrumbListProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let BreadcrumbList ( props : IBreadcrumbListProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <ol
        ref={ref}
        className={ JSX.cn [|
            "flex flex-wrap items-center gap-1.5 break-words text-sm text-muted-foreground sm:gap-2.5"
            properties?className
        |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox
    

// --------------- BreadcrumbItem -------------- //
type [<Erase>] IBreadcrumbItemProp = interface end
type [<Erase>] breadcrumbItem =
    inherit prop<IBreadcrumbItemProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let BreadcrumbItem ( props : IBreadcrumbItemProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <li ref={ref}
        className={ JSX.cn [|
            "inline-flex items-center gap-1.5"
            properties?className
        |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox

// --------------- BreadcrumbLink -------------- //
type [<Erase>] IBreadcrumbLinkProp = interface end
type [<Erase>] breadcrumbLink =
    inherit prop<IBreadcrumbLinkProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let BreadcrumbLink ( props : IBreadcrumbLinkProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const { asChild, className, ...sprops } = $0; const {props, ...attrs} = $props;"
    emitJsStatement () "const Comp = asChild ? Slot : \"a\""
    JSX.jsx $"""
    <Comp ref={ref}
        className={ JSX.cn [|
            "transition-colors hover:text-foreground"
            properties?className
        |] }
        {{...sprops}} {{...attrs}} />
    """ |> unbox
    
// --------------- BreadcrumbPage -------------- //
type [<Erase>] IBreadcrumbPageProp = interface end
type [<Erase>] breadcrumbPage =
    inherit prop<IBreadcrumbPageProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let BreadcrumbPage ( props : IBreadcrumbPageProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <span
        ref={ref}
        role="link"
        aria-disabled="true"
        aria-current="page"
        className={ JSX.cn [|
            "font-normal text-foreground"
            properties?className
        |] }
        {{...sprops}}
        {{...attrs}} />
    """ |> unbox

// --------------- BreadcrumbSeparator -------------- //
type [<Erase>] IBreadcrumbSeparatorProp = interface end
type [<Erase>] breadcrumbSeparator =
    inherit prop<IBreadcrumbSeparatorProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let BreadcrumbSeparator ( props : IBreadcrumbSeparatorProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {children, className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    import {{ ChevronRight, MoreHorizontal }} from "lucide-react";
    <li
        role="presentation"
        aria-hidden="true"
        className={ JSX.cn [|
            "[&>svg]:w-3.5 [&>svg]:h-3.5"
            properties?className
        |] }
        {{...sprops}} {{...attrs}}>
        {{children ?? <ChevronRight />}}
    </li>
    """ |> unbox
    
// --------------- BreadcrumbEllipsis -------------- //
type [<Erase>] IBreadcrumbEllipsisProp = interface end
type [<Erase>] breadcrumbEllipsis =
    inherit prop<IBreadcrumbEllipsisProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let BreadcrumbEllipsis ( props : IBreadcrumbEllipsisProp list ) : ReactElement =
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <span
        role="presentation"
        aria-hidden="true"
        className={ JSX.cn [|
            "flex h-9 w-9 items-center justify-center"
            properties?className
        |] }
        {{...sprops}} {{...attrs}}>
            <MoreHorizontal className="h-4 w-4" />
            <span className="sr-only">More</span>
    </span>
    """ |> unbox