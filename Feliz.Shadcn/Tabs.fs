[<AutoOpen>]
module Feliz.Shadcn.Tabs

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
JSX.injectShadcnLib
ignore <| JSX.jsx """
import * as TabsPrimitive from "@radix-ui/react-tabs"
"""

open Feliz.RadixUI.Interface.NoInherit

// --------------- Tabs -------------- //
type [<Erase>] ITabsProp = interface static member propsInterface : unit = () end
type [<Erase>] tabs = Tabs.root<ITabsProp>

let Tabs : JSX.ElementType = JSX.jsx """
TabsPrimitive.Root
"""

// --------------- TabsList -------------- //
type [<Erase>] ITabsListProp = interface static member propsInterface : unit = () end
type [<Erase>] tabsList = Tabs.list'<ITabsListProp>
let TabsList : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <TabsPrimitive.List
    ref={ref}
    className={cn(
      "inline-flex h-9 items-center justify-center rounded-lg bg-muted p-1 text-muted-foreground",
      className
    )}
    {...props} />
))
TabsList.displayName = TabsPrimitive.List.displayName
"""

// --------------- TabsTrigger -------------- //
type [<Erase>] ITabsTriggerProp = interface static member propsInterface : unit = () end
type [<Erase>] tabsTrigger = Tabs.trigger<ITabsTriggerProp>

let TabsTrigger : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <TabsPrimitive.Trigger
    ref={ref}
    className={cn(
      "inline-flex items-center justify-center whitespace-nowrap rounded-md px-3 py-1 text-sm font-medium ring-offset-background transition-all focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-ring focus-visible:ring-offset-2 disabled:pointer-events-none disabled:opacity-50 data-[state=active]:bg-background data-[state=active]:text-foreground data-[state=active]:shadow",
      className
    )}
    {...props} />
))
TabsTrigger.displayName = TabsPrimitive.Trigger.displayName
"""

// --------------- TabsContent -------------- //
type [<Erase>] ITabsContentProp = interface static member propsInterface : unit = () end
type [<Erase>] tabsContent = Tabs.content<ITabsContentProp>

let TabsContent : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <TabsPrimitive.Content
    ref={ref}
    className={cn(
      "mt-2 ring-offset-background focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-ring focus-visible:ring-offset-2",
      className
    )}
    {...props} />
))
TabsContent.displayName = TabsPrimitive.Content.displayName
"""

type [<Erase>] Shadcn =
    static member inline Tabs ( props : ITabsProp list ) = JSX.createElement Tabs props
    static member inline Tabs ( children : ReactElement list ) = JSX.createElementWithChildren Tabs children
    static member inline Tabs ( el : ReactElement ) = JSX.createElement Tabs [ tabs.asChild true ; tabs.children el ]
    static member inline TabsList ( props : ITabsListProp list ) = JSX.createElement TabsList props
    static member inline TabsList ( children : ReactElement list ) = JSX.createElementWithChildren TabsList children
    static member inline TabsList ( el : ReactElement ) = JSX.createElement TabsList [ tabsList.asChild true ; tabsList.children el ]
    static member inline TabsTrigger ( props : ITabsTriggerProp list ) = JSX.createElement TabsTrigger props
    static member inline TabsTrigger ( children : ReactElement list ) = JSX.createElementWithChildren TabsTrigger children
    static member inline TabsTrigger ( el : ReactElement ) = JSX.createElement TabsTrigger [ tabsTrigger.asChild true ; tabsTrigger.children el ]
    static member inline TabsContent ( props : ITabsContentProp list ) = JSX.createElement TabsContent props
    static member inline TabsContent ( children : ReactElement list ) = JSX.createElementWithChildren TabsContent children
    static member inline TabsContent ( el : ReactElement ) = JSX.createElement TabsContent [ tabsContent.asChild true ; tabsContent.children el ]
            