[<AutoOpen>]
module Feliz.Shadcn.Sidebar

open Browser
open Fable.Core.JS
open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.Lucide
open Feliz.Shadcn

emitJsStatement () "import { Slot } from \"@radix-ui/react-slot\""
let _ = (
    Tooltip,
    TooltipContent,
    TooltipProvider,
    TooltipTrigger,
    Button,
    Input,
    Separator,
    Sheet,
    SheetContent,
    Skeleton
)


module Sidebar =
    module Cookie =
        let [<Literal>] name = "sidebar:state"
        let [<Literal>] maxAge = 60 * 60 * 24 * 7
    
    let [<Literal>] width = "16rem"
    let [<Literal>] widthMobile = "18rem"
    let [<Literal>] widthIcon = "3rem"
    
    module Keyboard =
        let [<Literal>] shortcut = "b"

// let [<Literal>] sidebarCookieName = "sidebar:state"
// let [<Literal>] sidebarCookieMaxAge = 60 * 60 * 24 * 7
// let [<Literal>] sidebarWidth = "16rem"
// let [<Literal>] sidebarWidthMobile = "18rem"
// let [<Literal>] sidebarWidthIcon = "3rem"
// let [<Literal>] sidebarKeyboardShortcut = "b"

let SidebarContext: Fable.React.IContext<obj> = React.createContext(name="SidebarContext")

let useSidebar () =
    let context = React.useContext SidebarContext
    if context |> isNullOrUndefined then
        emitJsStatement () "throw new Error(\"useSidebar must be used within a SidebarProvider.\")"
    else context

// --------------- SidebarProvider -------------- //
type [<Erase>] ISidebarProviderProp = interface end
type [<Erase>] sidebarProvider =
    inherit prop<ISidebarProviderProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let SidebarProvider ( props : ISidebarProviderProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    let defaultOpen = properties?defaultOpen ??= true // default true if not set by prop
    let ( _open, _setOpen ) = React.useState( defaultOpen )
    let open' = properties?``open`` ??= _open
    let setOpen' = properties?setOpen ??= _setOpen
    let setOpen = React.useCallback( 
            fun value ->
                let openState : bool =
                    if jsTypeof value = "function" then
                        value(open')
                    else !!value:bool
                setOpen'(openState)
                document.cookie = $"{Sidebar.Cookie.name}={openState}; path=/; max-age={Sidebar.Cookie.maxAge}"
         , [| properties?setOpen , open' |])
    let toggleSidebar = React.useCallback( (fun _ -> setOpen( not )), [| setOpen |] )
    
    let state = if open' then "expanded" else "collapsed"
    let contextValue = React.useMemo(
        fun _ ->
            {|
              state=state
              ``open``=open'
              setOpen=setOpen
              toggleSidebar=toggleSidebar
              |}
        , [| state, open', setOpen, toggleSidebar |]
    )
    emitJsStatement properties "const {className, defaultOpen, open, onOpenChange, style, ...sprops} = $0; const {props, ...attrs} = $props;"
    
    JSX.jsx $"""
    <SidebarContext.Provider value={contextValue}>
        <TooltipProvider delayDuration={0}>
            <div
                style={{{{
                    "--sidebar-width": {Sidebar.width},
                    "--sidebar-width-icon": {Sidebar.widthIcon}
                    ...style
                }}}}
                className={ JSX.cn [|
                    "group/sidebar-wrapper flex min-h-svh w-full has-[[data-variant=inset]]:bg-sidebar"
                    properties?className
                |]}
                ref={ref}
                {{...sprops}} {{...attrs}}>
                {properties?children}
            </div>
        </TooltipProvider>
    </SidebarContext.Provider>
    """ |> unbox

// --------------- Sidebar -------------- //
type [<Erase>] ISidebarProp = interface end
type [<Erase>] sidebar =
    inherit prop<ISidebarProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let Sidebar ( props : ISidebarProp list ) : ReactElement =
    let context = useSidebar()
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    let side = properties?side ??= "left"
    let sideClasses =
        match side with
        | "left" -> "left-0 group-data-[collapsible=offcanvas]:left-[calc(var(--sidebar-width)*-1)]"
        | _ -> "right-0 group-data-[collapsible=offcanvas]:right-[calc(var(--sidebar-width)*-1)]"
    let variant = properties?variant ??= "sidebar"
    let variantClasses =
        match variant with
        | "floating" | "inset" ->
            "group-data-[collapsible=icon]:w-[calc(var(--sidebar-width-icon)_+_theme(spacing.4))]",
            "p-2 group-data-[collapsible=icon]:w-[calc(var(--sidebar-width-icon)_+_theme(spacing.4)_+2px)]"
        | _ ->
            "group-data-[collapsible=icon]:w-[--sidebar-width-icon]",
            "group-data-[collapsible=icon]:w-[--sidebar-width-icon] group-data-[side=left]:border-r group-data-[side=right]:border-l"
    let collapsible = properties?collapsible ??= "offcanvas"
    emitJsStatement properties "const {className, side, variant, collapsible, children, ...sprops} = $0; const {props, ...attrs} = $props;"
    match collapsible with
    | "none" ->
        JSX.jsx $"""
        <div ref={ref}
            className={ JSX.cn [|
                "flex h-full w-[--sidebar-width] flex-col bg-sidebar text-sidebar-foreground"
                properties?className
            |]} {{...sprops}} {{...attrs}}>
            {properties?children}
        </div>
        """ |> unbox
    | _ ->
        let dataCollapsible =
            match context?state with
            | "collapsed" -> collapsible
            | _ -> ""
        
        JSX.jsx $"""
        <div
            ref={ref}
            className="group peer hidden md:block text-sidebar-foreground"
            data-state={context?state}
            data-collapsible={dataCollapsible}
            data-variant={variant}
            data-side={side}>
            <div
                className={ JSX.cn [|
                    "duration-200 relative h-svh w-[--sidebar-width] bg-transparent transition-[width] ease-linear"
                    "group-data-[collapsible=offcanvas]:w-0"
                    "group-data-[side=right]:rotate-180"
                    fst variantClasses
                |] } />
            <div
                className={ JSX.cn [|
                    "duration-200 fixed inset-y-0 z-10 hidden h-svh w-[--sidebar-width] transition-[left,right,width] ease-linear md:flex"
                    sideClasses
                    snd variantClasses
                |] }
                {{...sprops}} {{...attrs}}>
                <div
                    data-sidebar="sidebar"
                    className="flex h-full w-full flex-col bg-sidebar group-data-[variant=floating]:rounded-lg group-data-[variant=floating]:border group-data-[variant=floating]:border-sidebar-border group-data-[variant=floating]:shadow"
                    >
                    {properties?children}
                </div>
            </div>
        </div>
        """ |> unbox

// --------------- SidebarTrigger -------------- //
type [<Erase>] ISidebarTriggerProp = interface end
type [<Erase>] sidebarTrigger =
    inherit prop<ISidebarTriggerProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let SidebarTrigger ( props : ISidebarTriggerProp list ) : ReactElement =
    let context = useSidebar()
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props;"
    JSX.jsx $"""
    <Button
        ref={ref}
        data-sidebar="trigger"
        variants="ghost"
        size="icon"
        className={ JSX.cn [|"h-7 w-7" ; properties?className|] }
        onClick={fun event -> properties?onClick?(event) ; context?toggleSidebar()}
        {{...sprops}} {{...attrs}} >
        { Icon.PanelLeft [] }
        <span className="sr-only">Toggle Sidebar</span>
    </Button>
    """ |> unbox

JSX.jsx "test" |> ignore