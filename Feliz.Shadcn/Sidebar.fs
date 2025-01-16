[<AutoOpen>]
module Feliz.Shadcn.Sidebar

open Browser
open Fable.Core.JS
open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.Lucide
open Feliz.Shadcn
JSX.injectShadcnLib
ignore <| JSX.jsx """
import { Slot } from "@radix-ui/react-slot";
import { cva } from "class-variance-authority";
import { PanelLeft } from "lucide-react";
"""
let imports = (
    Tooltip,
    TooltipContent,
    TooltipProvider,
    TooltipTrigger,
    Button,
    Input,
    Separator,
    Sheet,
    SheetContent,
    Skeleton,
    Hooks.useIsMobile
)

[<StringEnum>]
type [<Erase>] SidebarState =
    | Expanded
    | Collapsed
type [<Erase>] SidebarContext = {
    state : SidebarState
    ``open`` : bool
    setOpen : bool -> unit
    openMobile : bool
    setOpenMobile : bool -> unit
    toggleSidebar : unit -> unit
}
let private SidebarContext = React.createContext<SidebarContext>()

let private SIDEBAR_COOKIE_NAME = "sidebar:state"
let private SIDEBAR_COOKIE_MAX_AGE = 60 * 60 * 24 * 7
let private SIDEBAR_WIDTH = "16rem"
let private SIDEBAR_WIDTH_MOBILE = "18rem"
let private SIDEBAR_WIDTH_ICON = "3rem"
let private SIDEBAR_KEYBOARD_SHORTCUT = "b"
let useSidebar () = ignore <| JSX.jsx """
{
  const context = React.useContext(SidebarContext)
  if (!context) {
    throw new Error("useSidebar must be used within a SidebarProvider.")
  }

  return context
}
"""

let sidebarMenuButtonVariants = JSX.jsx """
cva(
  "peer/menu-button flex w-full items-center gap-2 overflow-hidden rounded-md p-2 text-left text-sm outline-none ring-sidebar-ring transition-[width,height,padding] hover:bg-sidebar-accent hover:text-sidebar-accent-foreground focus-visible:ring-2 active:bg-sidebar-accent active:text-sidebar-accent-foreground disabled:pointer-events-none disabled:opacity-50 group-has-[[data-sidebar=menu-action]]/menu-item:pr-8 aria-disabled:pointer-events-none aria-disabled:opacity-50 data-[active=true]:bg-sidebar-accent data-[active=true]:font-medium data-[active=true]:text-sidebar-accent-foreground data-[state=open]:hover:bg-sidebar-accent data-[state=open]:hover:text-sidebar-accent-foreground group-data-[collapsible=icon]:!size-8 group-data-[collapsible=icon]:!p-2 [&>span:last-child]:truncate [&>svg]:size-4 [&>svg]:shrink-0",
  {
    variants: {
      variant: {
        default: "hover:bg-sidebar-accent hover:text-sidebar-accent-foreground",
        outline:
          "bg-background shadow-[0_0_0_1px_hsl(var(--sidebar-border))] hover:bg-sidebar-accent hover:text-sidebar-accent-foreground hover:shadow-[0_0_0_1px_hsl(var(--sidebar-accent))]",
      },
      size: {
        default: "h-8 text-sm",
        sm: "h-7 text-xs",
        lg: "h-12 text-sm group-data-[collapsible=icon]:!p-0",
      },
    },
    defaultVariants: {
      variant: "default",
      size: "default",
    },
  }
)
"""

// --------------- SidebarProvider -------------- //
type [<Erase>] ISidebarProviderProp = interface end
type [<Erase>] sidebarProvider =
    inherit prop<ISidebarProviderProp>
    static member inline defaultOpen ( value : bool ) : ISidebarProviderProp = Interop.mkProperty "defaultOpen" value
    static member inline open' ( value : bool ) : ISidebarProviderProp = Interop.mkProperty "open" value
    static member inline onOpenChange ( handler : bool -> unit ) : ISidebarProviderProp = Interop.mkProperty "onOpenChange" handler
    
[<JSX.Component>]
let SidebarProvider : JSX.ElementType = JSX.jsx """
React.forwardRef((
  {
    defaultOpen = true,
    open: openProp,
    onOpenChange: setOpenProp,
    className,
    style,
    children,
    ...props
  },
  ref
) => {
  const isMobile = useIsMobile()
  const [openMobile, setOpenMobile] = React.useState(false)

  // This is the internal state of the sidebar.
  // We use openProp and setOpenProp for control from outside the component.
  const [_open, _setOpen] = React.useState(defaultOpen)
  const open = openProp ?? _open
  const setOpen = React.useCallback((value) => {
    const openState = typeof value === "function" ? value(open) : value
    if (setOpenProp) {
      setOpenProp(openState)
    } else {
      _setOpen(openState)
    }

    // This sets the cookie to keep the sidebar state.
    document.cookie = `${SIDEBAR_COOKIE_NAME}=${openState}; path=/; max-age=${SIDEBAR_COOKIE_MAX_AGE}`
  }, [setOpenProp, open])

  // Helper to toggle the sidebar.
  const toggleSidebar = React.useCallback(() => {
    return isMobile
      ? setOpenMobile((open) => !open)
      : setOpen((open) => !open);
  }, [isMobile, setOpen, setOpenMobile])

  // Adds a keyboard shortcut to toggle the sidebar.
  React.useEffect(() => {
    const handleKeyDown = (event) => {
      if (
        event.key === SIDEBAR_KEYBOARD_SHORTCUT &&
        (event.metaKey || event.ctrlKey)
      ) {
        event.preventDefault()
        toggleSidebar()
      }
    }

    window.addEventListener("keydown", handleKeyDown)
    return () => window.removeEventListener("keydown", handleKeyDown);
  }, [toggleSidebar])

  // We add a state so that we can do data-state="expanded" or "collapsed".
  // This makes it easier to style the sidebar with Tailwind classes.
  const state = open ? "expanded" : "collapsed"

  const contextValue = React.useMemo(() => ({
    state,
    open,
    setOpen,
    isMobile,
    openMobile,
    setOpenMobile,
    toggleSidebar,
  }), [state, open, setOpen, isMobile, openMobile, setOpenMobile, toggleSidebar])

  return (
    (<SidebarContext.Provider value={contextValue}>
      <TooltipProvider delayDuration={0}>
        <div
          style={
            {
              "--sidebar-width": SIDEBAR_WIDTH,
              "--sidebar-width-icon": SIDEBAR_WIDTH_ICON,
              ...style
            }
          }
          className={cn(
            "group/sidebar-wrapper flex min-h-svh w-full has-[[data-variant=inset]]:bg-sidebar",
            className
          )}
          ref={ref}
          {...props}>
          {children}
        </div>
      </TooltipProvider>
    </SidebarContext.Provider>)
  );
})
SidebarProvider.displayName = "SidebarProvider"
"""

// --------------- Sidebar -------------- //
type [<Erase>] ISidebarProp = interface end
type [<Erase>] sidebar =
    inherit prop<ISidebarProp>
    static member inline private noop = ()

module [<Erase>] sidebar =
    type [<Erase>] side =
        static member inline left : ISidebarProp = Interop.mkProperty "side" "left"
        static member inline right : ISidebarProp = Interop.mkProperty "side" "right"
    type [<Erase>] variant =
        static member inline sidebar : ISidebarProp = Interop.mkProperty "variant" "sidebar"
        static member inline floating : ISidebarProp = Interop.mkProperty "variant" "floating"
        static member inline inset : ISidebarProp = Interop.mkProperty "variant" "inset"
        static member inline default' : ISidebarProp = Interop.mkProperty "variant" "sidebar"
    type [<Erase>] collapsible =
        static member inline default' : ISidebarProp = Interop.mkProperty "collapsible" "offcanvas"
        static member inline offCanvas : ISidebarProp = Interop.mkProperty "collapsible" "offcanvas"
        static member inline icon : ISidebarProp = Interop.mkProperty "collapsible" "icon"
        static member inline none : ISidebarProp = Interop.mkProperty "collapsible" "none"

[<JSX.Component>]
let Sidebar : JSX.ElementType = JSX.jsx """
React.forwardRef((
  {
    side = "left",
    variant = "sidebar",
    collapsible = "offcanvas",
    className,
    children,
    ...props
  },
  ref
) => {
  const { isMobile, state, openMobile, setOpenMobile } = useSidebar()

  if (collapsible === "none") {
    return (
      (<div
        className={cn(
          "flex h-full w-[--sidebar-width] flex-col bg-sidebar text-sidebar-foreground",
          className
        )}
        ref={ref}
        {...props}>
        {children}
      </div>)
    );
  }

  if (isMobile) {
    return (
      (<Sheet open={openMobile} onOpenChange={setOpenMobile} {...props}>
        <SheetContent
          data-sidebar="sidebar"
          data-mobile="true"
          className="w-[--sidebar-width] bg-sidebar p-0 text-sidebar-foreground [&>button]:hidden"
          style={
            {
              "--sidebar-width": SIDEBAR_WIDTH_MOBILE
            }
          }
          side={side}>
          <div className="flex h-full w-full flex-col">{children}</div>
        </SheetContent>
      </Sheet>)
    );
  }

  return (
    (<div
      ref={ref}
      className="group peer hidden md:block text-sidebar-foreground"
      data-state={state}
      data-collapsible={state === "collapsed" ? collapsible : ""}
      data-variant={variant}
      data-side={side}>
      {/* This is what handles the sidebar gap on desktop */}
      <div
        className={cn(
          "duration-200 relative h-svh w-[--sidebar-width] bg-transparent transition-[width] ease-linear",
          "group-data-[collapsible=offcanvas]:w-0",
          "group-data-[side=right]:rotate-180",
          variant === "floating" || variant === "inset"
            ? "group-data-[collapsible=icon]:w-[calc(var(--sidebar-width-icon)_+_theme(spacing.4))]"
            : "group-data-[collapsible=icon]:w-[--sidebar-width-icon]"
        )} />
      <div
        className={cn(
          "duration-200 fixed inset-y-0 z-10 hidden h-svh w-[--sidebar-width] transition-[left,right,width] ease-linear md:flex",
          side === "left"
            ? "left-0 group-data-[collapsible=offcanvas]:left-[calc(var(--sidebar-width)*-1)]"
            : "right-0 group-data-[collapsible=offcanvas]:right-[calc(var(--sidebar-width)*-1)]",
          // Adjust the padding for floating and inset variants.
          variant === "floating" || variant === "inset"
            ? "p-2 group-data-[collapsible=icon]:w-[calc(var(--sidebar-width-icon)_+_theme(spacing.4)_+2px)]"
            : "group-data-[collapsible=icon]:w-[--sidebar-width-icon] group-data-[side=left]:border-r group-data-[side=right]:border-l",
          className
        )}
        {...props}>
        <div
          data-sidebar="sidebar"
          className="flex h-full w-full flex-col bg-sidebar group-data-[variant=floating]:rounded-lg group-data-[variant=floating]:border group-data-[variant=floating]:border-sidebar-border group-data-[variant=floating]:shadow">
          {children}
        </div>
      </div>
    </div>)
  );
})
Sidebar.displayName = "Sidebar"
"""

// --------------- SidebarTrigger -------------- //
type [<Erase>] ISidebarTriggerProp = interface end
type [<Erase>] sidebarTrigger =
    inherit prop<ISidebarTriggerProp>
    static member inline noop : unit = ()

[<JSX.Component>]
let SidebarTrigger : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, onClick, ...props }, ref) => {
  const { toggleSidebar } = useSidebar()

  return (
    (<Button
      ref={ref}
      data-sidebar="trigger"
      variant="ghost"
      size="icon"
      className={cn("h-7 w-7", className)}
      onClick={(event) => {
        onClick?.(event)
        toggleSidebar()
      }}
      {...props}>
      <PanelLeft />
      <span className="sr-only">Toggle Sidebar</span>
    </Button>)
  );
})
SidebarTrigger.displayName = "SidebarTrigger"
"""

// --------------- SidebarRail -------------- //
type [<Erase>] ISidebarRailProp = interface end
type [<Erase>] sidebarRail =
    inherit prop<ISidebarRailProp>
    static member inline private noop : unit = ()

let SidebarRail : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => {
  const { toggleSidebar } = useSidebar()

  return (
    (<button
      ref={ref}
      data-sidebar="rail"
      aria-label="Toggle Sidebar"
      tabIndex={-1}
      onClick={toggleSidebar}
      title="Toggle Sidebar"
      className={cn(
        "absolute inset-y-0 z-20 hidden w-4 -translate-x-1/2 transition-all ease-linear after:absolute after:inset-y-0 after:left-1/2 after:w-[2px] hover:after:bg-sidebar-border group-data-[side=left]:-right-4 group-data-[side=right]:left-0 sm:flex",
        "[[data-side=left]_&]:cursor-w-resize [[data-side=right]_&]:cursor-e-resize",
        "[[data-side=left][data-state=collapsed]_&]:cursor-e-resize [[data-side=right][data-state=collapsed]_&]:cursor-w-resize",
        "group-data-[collapsible=offcanvas]:translate-x-0 group-data-[collapsible=offcanvas]:after:left-full group-data-[collapsible=offcanvas]:hover:bg-sidebar",
        "[[data-side=left][data-collapsible=offcanvas]_&]:-right-2",
        "[[data-side=right][data-collapsible=offcanvas]_&]:-left-2",
        className
      )}
      {...props} />)
  );
})
SidebarRail.displayName = "SidebarRail"
"""

// --------------- SidebarInset -------------- //
type [<Erase>] ISidebarInsetProp = interface end
type [<Erase>] sidebarInset =
    inherit prop<ISidebarInsetProp>
    static member inline private noop : unit = ()

let SidebarInset : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => {
  return (
    (<main
      ref={ref}
      className={cn(
        "relative flex min-h-svh flex-1 flex-col bg-background",
        "peer-data-[variant=inset]:min-h-[calc(100svh-theme(spacing.4))] md:peer-data-[variant=inset]:m-2 md:peer-data-[state=collapsed]:peer-data-[variant=inset]:ml-2 md:peer-data-[variant=inset]:ml-0 md:peer-data-[variant=inset]:rounded-xl md:peer-data-[variant=inset]:shadow",
        className
      )}
      {...props} />)
  );
})
SidebarInset.displayName = "SidebarInset"
"""

// --------------- SidebarInput -------------- //
type [<Erase>] ISidebarInputProp = interface end
type [<Erase>] sidebarInput =
    inherit prop<ISidebarInputProp>
    static member inline private noop : unit = ()

let SidebarInput : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => {
  return (
    (<Input
      ref={ref}
      data-sidebar="input"
      className={cn(
        "h-8 w-full bg-background shadow-none focus-visible:ring-2 focus-visible:ring-sidebar-ring",
        className
      )}
      {...props} />)
  );
})
SidebarInput.displayName = "SidebarInput"
"""

// --------------- SidebarHeader -------------- //
type [<Erase>] ISidebarHeaderProp = interface end
type [<Erase>] sidebarHeader =
    inherit prop<ISidebarHeaderProp>
    static member inline private noop : unit = ()

let SidebarHeader : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => {
  return (
    (<div
      ref={ref}
      data-sidebar="header"
      className={cn("flex flex-col gap-2 p-2", className)}
      {...props} />)
  );
})
SidebarHeader.displayName = "SidebarHeader"
"""

// --------------- SidebarFooter -------------- //
type [<Erase>] ISidebarFooterProp = interface end
type [<Erase>] sidebarFooter =
    inherit prop<ISidebarFooterProp>
    static member inline private noop : unit = ()

let SidebarFooter : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => {
  return (
    (<div
      ref={ref}
      data-sidebar="footer"
      className={cn("flex flex-col gap-2 p-2", className)}
      {...props} />)
  );
})
SidebarFooter.displayName = "SidebarFooter"
"""

// --------------- SidebarSeparator -------------- //
type [<Erase>] ISidebarSeparatorProp = interface end
type [<Erase>] sidebarSeparator =
    inherit prop<ISidebarSeparatorProp>
    static member inline private noop : unit = ()

let SidebarSeparator : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => {
  return (
    (<Separator
      ref={ref}
      data-sidebar="separator"
      className={cn("mx-2 w-auto bg-sidebar-border", className)}
      {...props} />)
  );
})
SidebarSeparator.displayName = "SidebarSeparator"
"""

// --------------- SidebarContent -------------- //
type [<Erase>] ISidebarContentProp = interface end
type [<Erase>] sidebarContent =
    inherit prop<ISidebarContentProp>
    static member inline private noop : unit = ()

let SidebarContent : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => {
  return (
    (<div
      ref={ref}
      data-sidebar="content"
      className={cn(
        "flex min-h-0 flex-1 flex-col gap-2 overflow-y-auto overflow-x-hidden group-data-[collapsible=icon]:overflow-hidden",
        className
      )}
      {...props} />)
  );
})
SidebarContent.displayName = "SidebarContent"
"""

// --------------- SidebarGroup -------------- //
type [<Erase>] ISidebarGroupProp = interface end
type [<Erase>] sidebarGroup =
    inherit prop<ISidebarGroupProp>
    static member inline private noop : unit = ()

let SidebarGroup : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => {
  return (
    (<div
      ref={ref}
      data-sidebar="group"
      className={cn("relative flex w-full min-w-0 flex-col p-2", className)}
      {...props} />)
  );
})
SidebarGroup.displayName = "SidebarGroup"
"""

// --------------- SidebarGroupLabel -------------- //
type [<Erase>] ISidebarGroupLabelProp = interface end
type [<Erase>] sidebarGroupLabel =
    inherit prop<ISidebarGroupLabelProp>
    static member inline asChild ( value : bool ) : ISidebarGroupLabelProp = Interop.mkProperty "asChild" value

let SidebarGroupLabel : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, asChild = false, ...props }, ref) => {
  const Comp = asChild ? Slot : "div"

  return (
    (<Comp
      ref={ref}
      data-sidebar="group-label"
      className={cn(
        "duration-200 flex h-8 shrink-0 items-center rounded-md px-2 text-xs font-medium text-sidebar-foreground/70 outline-none ring-sidebar-ring transition-[margin,opa] ease-linear focus-visible:ring-2 [&>svg]:size-4 [&>svg]:shrink-0",
        "group-data-[collapsible=icon]:-mt-8 group-data-[collapsible=icon]:opacity-0",
        className
      )}
      {...props} />)
  );
})
SidebarGroupLabel.displayName = "SidebarGroupLabel"
"""

// --------------- SidebarGroupAction -------------- //
type [<Erase>] ISidebarGroupActionProp = interface end
type [<Erase>] sidebarGroupAction =
    inherit prop<ISidebarGroupActionProp>
    static member inline asChild ( value : bool ) : ISidebarGroupActionProp = Interop.mkProperty "asChild" value
    
let SidebarGroupAction : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, asChild = false, ...props }, ref) => {
  const Comp = asChild ? Slot : "button"

  return (
    (<Comp
      ref={ref}
      data-sidebar="group-action"
      className={cn(
        "absolute right-3 top-3.5 flex aspect-square w-5 items-center justify-center rounded-md p-0 text-sidebar-foreground outline-none ring-sidebar-ring transition-transform hover:bg-sidebar-accent hover:text-sidebar-accent-foreground focus-visible:ring-2 [&>svg]:size-4 [&>svg]:shrink-0",
        // Increases the hit area of the button on mobile.
        "after:absolute after:-inset-2 after:md:hidden",
        "group-data-[collapsible=icon]:hidden",
        className
      )}
      {...props} />)
  );
})
SidebarGroupAction.displayName = "SidebarGroupAction"
"""

// --------------- SidebarGroupContent -------------- //
type [<Erase>] ISidebarGroupContentProp = interface end
type [<Erase>] sidebarGroupContent =
    inherit prop<ISidebarGroupContentProp>
    static member inline private noop : unit = ()

let SidebarGroupContent : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <div
    ref={ref}
    data-sidebar="group-content"
    className={cn("w-full text-sm", className)}
    {...props} />
))
SidebarGroupContent.displayName = "SidebarGroupContent"
"""

// --------------- SidebarMenu -------------- //
type [<Erase>] ISidebarMenuProp = interface end
type [<Erase>] sidebarMenu =
    inherit prop<ISidebarMenuProp>
    static member inline private noop : unit = ()

let SidebarMenu : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <ul
    ref={ref}
    data-sidebar="menu"
    className={cn("flex w-full min-w-0 flex-col gap-1", className)}
    {...props} />
))
SidebarMenu.displayName = "SidebarMenu"
"""

// --------------- SidebarMenuItem -------------- //
type [<Erase>] ISidebarMenuItemProp = interface end
type [<Erase>] sidebarMenuItem =
    inherit prop<ISidebarMenuItemProp>
    static member inline private noop : unit = ()

let SidebarMenuItem : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <li
    ref={ref}
    data-sidebar="menu-item"
    className={cn("group/menu-item relative", className)}
    {...props} />
))
SidebarMenuItem.displayName = "SidebarMenuItem"
"""

// --------------- SidebarMenuButton -------------- //
type [<Erase>] ISidebarMenuButtonProp = interface end
type [<Erase>] sidebarMenuButton =
    inherit prop<ISidebarMenuButtonProp>
    static member inline asChild ( value : bool ) : ISidebarMenuButtonProp = Interop.mkProperty "asChild" value
    static member inline isActive ( value : bool ) : ISidebarMenuButtonProp = Interop.mkProperty "isActive" value
    static member inline tooltip ( value : string ) : ISidebarMenuButtonProp = Interop.mkProperty "tooltip" value
module [<Erase>] sidebarMenuButton =
    type [<Erase>] variant =
        static member inline default' : ISidebarMenuButtonProp = Interop.mkProperty "variant" "default"
        static member inline outline : ISidebarMenuButtonProp = Interop.mkProperty "variant" "outline"
    type [<Erase>] size =
        static member inline default' : ISidebarMenuButtonProp = Interop.mkProperty "size" "default"
        static member inline sm : ISidebarMenuButtonProp = Interop.mkProperty "size" "sm"
        static member inline lg : ISidebarMenuButtonProp = Interop.mkProperty "size" "lg"

let SidebarMenuButton : JSX.ElementType = JSX.jsx """
React.forwardRef((
  {
    asChild = false,
    isActive = false,
    variant = "default",
    size = "default",
    tooltip,
    className,
    ...props
  },
  ref
) => {
  const Comp = asChild ? Slot : "button"
  const { isMobile, state } = useSidebar()

  const button = (
    <Comp
      ref={ref}
      data-sidebar="menu-button"
      data-size={size}
      data-active={isActive}
      className={cn(sidebarMenuButtonVariants({ variant, size }), className)}
      {...props} />
  )

  if (!tooltip) {
    return button
  }

  if (typeof tooltip === "string") {
    tooltip = {
      children: tooltip,
    }
  }

  return (
    (<Tooltip>
      <TooltipTrigger asChild>{button}</TooltipTrigger>
      <TooltipContent
        side="right"
        align="center"
        hidden={state !== "collapsed" || isMobile}
        {...tooltip} />
    </Tooltip>)
  );
})
SidebarMenuButton.displayName = "SidebarMenuButton"
"""

// --------------- SidebarMenuAction -------------- //
type [<Erase>] ISidebarMenuActionProp = interface end
type [<Erase>] sidebarMenuAction =
    inherit prop<ISidebarMenuActionProp>
    static member inline asChild ( value : bool ) : ISidebarMenuActionProp = Interop.mkProperty "asChild" value
    static member inline showOnHover ( value : bool ) : ISidebarMenuActionProp = Interop.mkProperty "showOnHover" value

let SidebarMenuAction : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, asChild = false, showOnHover = false, ...props }, ref) => {
  const Comp = asChild ? Slot : "button"

  return (
    (<Comp
      ref={ref}
      data-sidebar="menu-action"
      className={cn(
        "absolute right-1 top-1.5 flex aspect-square w-5 items-center justify-center rounded-md p-0 text-sidebar-foreground outline-none ring-sidebar-ring transition-transform hover:bg-sidebar-accent hover:text-sidebar-accent-foreground focus-visible:ring-2 peer-hover/menu-button:text-sidebar-accent-foreground [&>svg]:size-4 [&>svg]:shrink-0",
        // Increases the hit area of the button on mobile.
        "after:absolute after:-inset-2 after:md:hidden",
        "peer-data-[size=sm]/menu-button:top-1",
        "peer-data-[size=default]/menu-button:top-1.5",
        "peer-data-[size=lg]/menu-button:top-2.5",
        "group-data-[collapsible=icon]:hidden",
        showOnHover &&
          "group-focus-within/menu-item:opacity-100 group-hover/menu-item:opacity-100 data-[state=open]:opacity-100 peer-data-[active=true]/menu-button:text-sidebar-accent-foreground md:opacity-0",
        className
      )}
      {...props} />)
  );
})
SidebarMenuAction.displayName = "SidebarMenuAction"
"""

// --------------- SidebarMenuBadge -------------- //
type [<Erase>] ISidebarMenuBadgeProp = interface end
type [<Erase>] sidebarMenuBadge =
    inherit prop<ISidebarMenuBadgeProp>
    static member inline private noop : unit = ()

let SidebarMenuBadge : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <div
    ref={ref}
    data-sidebar="menu-badge"
    className={cn(
      "absolute right-1 flex h-5 min-w-5 items-center justify-center rounded-md px-1 text-xs font-medium tabular-nums text-sidebar-foreground select-none pointer-events-none",
      "peer-hover/menu-button:text-sidebar-accent-foreground peer-data-[active=true]/menu-button:text-sidebar-accent-foreground",
      "peer-data-[size=sm]/menu-button:top-1",
      "peer-data-[size=default]/menu-button:top-1.5",
      "peer-data-[size=lg]/menu-button:top-2.5",
      "group-data-[collapsible=icon]:hidden",
      className
    )}
    {...props} />
))
SidebarMenuBadge.displayName = "SidebarMenuBadge"
"""

// --------------- SidebarMenuSkeleton -------------- //
type [<Erase>] ISidebarMenuSkeletonProp = interface end
type [<Erase>] sidebarMenuSkeleton =
    inherit prop<ISidebarMenuSkeletonProp>
    static member inline showIcon ( value : bool ) : ISidebarMenuSkeletonProp = Interop.mkProperty "showIcon" value

let SidebarMenuSkeleton : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, showIcon = false, ...props }, ref) => {
  // Random width between 50 to 90%.
  const width = React.useMemo(() => {
    return `${Math.floor(Math.random() * 40) + 50}%`;
  }, [])

  return (
    (<div
      ref={ref}
      data-sidebar="menu-skeleton"
      className={cn("rounded-md h-8 flex gap-2 px-2 items-center", className)}
      {...props}>
      {showIcon && (
        <Skeleton className="size-4 rounded-md" data-sidebar="menu-skeleton-icon" />
      )}
      <Skeleton
        className="h-4 flex-1 max-w-[--skeleton-width]"
        data-sidebar="menu-skeleton-text"
        style={
          {
            "--skeleton-width": width
          }
        } />
    </div>)
  );
})
SidebarMenuSkeleton.displayName = "SidebarMenuSkeleton"
"""

// --------------- SidebarMenuSub -------------- //
type [<Erase>] ISidebarMenuSubProp = interface end
type [<Erase>] sidebarMenuSub =
    inherit prop<ISidebarMenuSubProp>
    static member inline private noop : unit = ()

let SidebarMenuSub : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <ul
    ref={ref}
    data-sidebar="menu-sub"
    className={cn(
      "mx-3.5 flex min-w-0 translate-x-px flex-col gap-1 border-l border-sidebar-border px-2.5 py-0.5",
      "group-data-[collapsible=icon]:hidden",
      className
    )}
    {...props} />
))
SidebarMenuSub.displayName = "SidebarMenuSub"
"""

// --------------- SidebarMenuSubItem -------------- //
type [<Erase>] ISidebarMenuSubItemProp = interface end
type [<Erase>] sidebarMenuSubItem =
    inherit prop<ISidebarMenuSubItemProp>
    static member inline private noop : unit = ()

let SidebarMenuSubItem : JSX.ElementType = JSX.jsx """
React.forwardRef(({ ...props }, ref) => <li ref={ref} {...props} />)
SidebarMenuSubItem.displayName = "SidebarMenuSubItem"
"""

// --------------- SidebarMenuSubButton -------------- //
type [<Erase>] ISidebarMenuSubButtonProp = interface end
type [<Erase>] sidebarMenuSubButton =
    inherit prop<ISidebarMenuSubButtonProp>
    static member inline asChild ( value : bool ) : ISidebarMenuSubButtonProp = Interop.mkProperty "asChild" value
    static member inline isActive ( value : bool ) : ISidebarMenuSubButtonProp = Interop.mkProperty "isActive" value
module [<Erase>] sidebarMenuSubButton =
    type [<Erase>] size =
        static member inline sm : ISidebarMenuSubButtonProp = Interop.mkProperty "size" "sm"
        static member inline md : ISidebarMenuSubButtonProp = Interop.mkProperty "size" "md"
    
let SidebarMenuSubButton : JSX.ElementType = JSX.jsx """
React.forwardRef(
  ({ asChild = false, size = "md", isActive, className, ...props }, ref) => {
    const Comp = asChild ? Slot : "a"

    return (
      (<Comp
        ref={ref}
        data-sidebar="menu-sub-button"
        data-size={size}
        data-active={isActive}
        className={cn(
          "flex h-7 min-w-0 -translate-x-px items-center gap-2 overflow-hidden rounded-md px-2 text-sidebar-foreground outline-none ring-sidebar-ring hover:bg-sidebar-accent hover:text-sidebar-accent-foreground focus-visible:ring-2 active:bg-sidebar-accent active:text-sidebar-accent-foreground disabled:pointer-events-none disabled:opacity-50 aria-disabled:pointer-events-none aria-disabled:opacity-50 [&>span:last-child]:truncate [&>svg]:size-4 [&>svg]:shrink-0 [&>svg]:text-sidebar-accent-foreground",
          "data-[active=true]:bg-sidebar-accent data-[active=true]:text-sidebar-accent-foreground",
          size === "sm" && "text-xs",
          size === "md" && "text-sm",
          "group-data-[collapsible=icon]:hidden",
          className
        )}
        {...props} />)
    );
  }
)
SidebarMenuSubButton.displayName = "SidebarMenuSubButton"
"""

type [<Erase>] Shadcn =
    static member inline Sidebar ( props : ISidebarProp list ) = JSX.createElement Sidebar props
    static member inline Sidebar ( children : ReactElement list ) = JSX.createElementWithChildren Sidebar children
    static member inline SidebarContent ( props : ISidebarContentProp list ) = JSX.createElement SidebarContent props
    static member inline SidebarContent ( children : ReactElement list ) = JSX.createElementWithChildren SidebarContent children
    static member inline SidebarFooter ( props : ISidebarFooterProp list ) = JSX.createElement SidebarFooter props
    static member inline SidebarFooter ( children : ReactElement list ) = JSX.createElementWithChildren SidebarFooter children
    static member inline SidebarGroup ( props : ISidebarGroupProp list ) = JSX.createElement SidebarGroup props
    static member inline SidebarGroup ( children : ReactElement list ) = JSX.createElementWithChildren SidebarGroup children
    static member inline SidebarGroupAction ( props : ISidebarGroupActionProp list ) = JSX.createElement SidebarGroupAction props
    static member inline SidebarGroupAction ( children : ReactElement list ) = JSX.createElementWithChildren SidebarGroupAction children
    static member inline SidebarGroupAction ( el : ReactElement ) = JSX.createElement SidebarGroupAction [ sidebarGroupLabel.asChild true ; sidebarGroupLabel.children el ]
    static member inline SidebarGroupContent ( props : ISidebarGroupContentProp list ) = JSX.createElement SidebarGroupContent props
    static member inline SidebarGroupContent ( children : ReactElement list ) = JSX.createElementWithChildren SidebarGroupContent children
    static member inline SidebarGroupLabel ( props : ISidebarGroupLabelProp list ) = JSX.createElement SidebarGroupLabel props
    static member inline SidebarGroupLabel ( children : ReactElement list ) = JSX.createElementWithChildren SidebarGroupLabel children
    static member inline SidebarGroupLabel ( label : string ) = JSX.createElement SidebarGroupLabel [ prop.text label ]
    static member inline SidebarGroupLabel ( el : ReactElement ) = JSX.createElement SidebarGroupLabel [ sidebarGroupLabel.asChild true ; sidebarGroupLabel.children el ]
    static member inline SidebarHeader ( props : ISidebarHeaderProp list ) = JSX.createElement SidebarHeader props
    static member inline SidebarHeader ( children : ReactElement list ) = JSX.createElementWithChildren SidebarHeader children
    static member inline SidebarInput ( props : ISidebarInputProp list ) = JSX.createElement SidebarInput props
    static member inline SidebarInput ( children : ReactElement list ) = JSX.createElementWithChildren SidebarInput children
    static member inline SidebarInset ( props : ISidebarInsetProp list ) = JSX.createElement SidebarInset props
    static member inline SidebarInset ( children : ReactElement list ) = JSX.createElementWithChildren SidebarInset children
    static member inline SidebarMenu ( props : ISidebarMenuProp list ) = JSX.createElement SidebarMenu props
    static member inline SidebarMenu ( children : ReactElement list ) = JSX.createElementWithChildren SidebarMenu children
    static member inline SidebarMenuAction ( props : ISidebarMenuActionProp list ) = JSX.createElement SidebarMenuAction props
    static member inline SidebarMenuAction ( children : ReactElement list ) = JSX.createElementWithChildren SidebarMenuAction children
    static member inline SidebarMenuAction ( el : ReactElement ) = JSX.createElement SidebarMenuAction [ sidebarGroupLabel.asChild true ; sidebarGroupLabel.children el ]
    static member inline SidebarMenuBadge ( props : ISidebarMenuBadgeProp list ) = JSX.createElement SidebarMenuBadge props
    static member inline SidebarMenuBadge ( children : ReactElement list ) = JSX.createElementWithChildren SidebarMenuBadge children
    static member inline SidebarMenuButton ( props : ISidebarMenuButtonProp list ) = JSX.createElement SidebarMenuButton props
    static member inline SidebarMenuButton ( children : ReactElement list ) = JSX.createElementWithChildren SidebarMenuButton children
    static member inline SidebarMenuButton ( el : ReactElement ) = JSX.createElement SidebarMenuButton [ sidebarGroupLabel.asChild true ; sidebarGroupLabel.children el ]
    static member inline SidebarMenuItem ( props : ISidebarMenuItemProp list ) = JSX.createElement SidebarMenuItem props
    static member inline SidebarMenuItem ( children : ReactElement list ) = JSX.createElementWithChildren SidebarMenuItem children
    static member inline SidebarMenuSkeleton ( props : ISidebarMenuSkeletonProp list ) = JSX.createElement SidebarMenuSkeleton props
    static member inline SidebarMenuSkeleton ( children : ReactElement list ) = JSX.createElementWithChildren SidebarMenuSkeleton children
    static member inline SidebarMenuSub ( props : ISidebarMenuSubProp list ) = JSX.createElement SidebarMenuSub props
    static member inline SidebarMenuSub ( children : ReactElement list ) = JSX.createElementWithChildren SidebarMenuSub children
    static member inline SidebarMenuSubButton ( props : ISidebarMenuSubButtonProp list ) = JSX.createElement SidebarMenuSubButton props
    static member inline SidebarMenuSubButton ( children : ReactElement list ) = JSX.createElementWithChildren SidebarMenuSubButton children
    static member inline SidebarMenuSubButton ( el : ReactElement ) = JSX.createElement SidebarMenuSubButton [ sidebarGroupLabel.asChild true ; sidebarGroupLabel.children el ]
    static member inline SidebarMenuSubItem ( props : ISidebarMenuSubItemProp list ) = JSX.createElement SidebarMenuSubItem props
    static member inline SidebarMenuSubItem ( children : ReactElement list ) = JSX.createElementWithChildren SidebarMenuSubItem children
    static member inline SidebarProvider ( props : ISidebarProviderProp list ) = JSX.createElement SidebarProvider props
    static member inline SidebarProvider ( children : ReactElement list ) = JSX.createElementWithChildren SidebarProvider children
    static member inline SidebarRail ( props : ISidebarRailProp list ) = JSX.createElement SidebarRail props
    static member inline SidebarRail ( children : ReactElement list ) = JSX.createElementWithChildren SidebarRail children
    static member inline SidebarSeparator ( props : ISidebarSeparatorProp list ) = JSX.createElement SidebarSeparator props
    static member inline SidebarSeparator ( children : ReactElement list ) = JSX.createElementWithChildren SidebarSeparator children
    static member inline SidebarTrigger ( props : ISidebarTriggerProp list ) = JSX.createElement SidebarTrigger props
    static member inline SidebarTrigger ( children : ReactElement list ) = JSX.createElementWithChildren SidebarTrigger children                                                                                        