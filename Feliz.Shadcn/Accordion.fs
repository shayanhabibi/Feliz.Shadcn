[<AutoOpen>]
module Feliz.Shadcn.Accordion

open Feliz.RadixUI.Interface
open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.Lucide
open Browser.Types

emitJsStatement () """
import * as React from "react"
import * as AccordionPrimitive from "@radix-ui/react-accordion"
import { ChevronDown } from "lucide-react"
"""

JSX.injectShadcnLib


// ---------------- Accordion ------------------ //
/// Properties for Shadcn.Accordion (root)
type [<Erase>] IAccordionProp = interface end
// Define props specific for components
/// Shadcn Accordion root properties
type [<Erase>] accordion =
    // Inherit properties from RadixUI Accordion root
    inherit Accordion.root<IAccordionProp>
    static member inline collapsible ( value : bool ) = Interop.mkProperty<IAccordionProp> "collapsible" value
    static member inline defaultValue ( value : string ) = Interop.mkProperty<IAccordionProp> "defaultValue" value
    // string or string array depending on type of accordion
    static member inline onValueChange ( handler : string -> unit ) = Interop.mkProperty<IAccordionProp> "onValueChange" handler
    static member inline onValueChange ( handler : string list -> unit ) = Interop.mkProperty<IAccordionProp> "onValueChange" handler

/// Enum properties for Shadcn Accordion (root)
[<RequireQualifiedAccess>]
module [<Erase>] accordion =
    /// Enum for whether Accordion can have multiple or a singular `open` item
    type [<Erase>] type' =
        inherit accordionRoot.type'<IAccordionProp>
        static member private noop = () // todo add docs to inherited props
    /// Orientation of Shadcn Accordion
    type [<Erase>] orientation =
        inherit accordionRoot.orientation<IAccordionProp> // TODO add docs to inherited props
        static member private noop = ()        
    /// Language direction for components of Shadcn Accordion
    type [<Erase>] dir =
        inherit accordionRoot.dir<IAccordionProp>
        static member private noop = ()

/// Root Accordion Component which wraps the other elements for the Accordion.
/// Accepts a list of properties.
let Accordion : JSX.ElementType = JSX.jsx "AccordionPrimitive.Root"

// ---------------- AccordionItem ------------------ //
type [<Erase>] IAccordionItemProp = interface end
/// Accessor for <c>IAccordionItemProp</c> -erties
type [<Erase>] accordionItem =
    inherit Accordion.item<IAccordionItemProp>
    static member inline private noop = ignore

/// The Accordion Item Component
let AccordionItem : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, ...props }, ref) => (
  <AccordionPrimitive.Item ref={ref} className={cn("border-b", className)} {...props} />
))
AccordionItem.displayName = "AccordionItem"
"""

// ---------------- AccordionTrigger ------------------ //
type [<Erase>] IAccordionTriggerProp = interface end
/// Accessor for <c>IAccordionTriggerProp</c>-erties
type [<Erase>] accordionTrigger =
    inherit Accordion.trigger<IAccordionTriggerProp>
    static member inline private noop = ignore

/// The Accordion Trigger Component
let AccordionTrigger : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, children, ...props }, ref) => (
  <AccordionPrimitive.Header className="flex">
    <AccordionPrimitive.Trigger
      ref={ref}
      className={cn(
        "flex flex-1 items-center justify-between py-4 text-sm font-medium transition-all hover:underline text-left [&[data-state=open]>svg]:rotate-180",
        className
      )}
      {...props}>
      {children}
      <ChevronDown
        className="h-4 w-4 shrink-0 text-muted-foreground transition-transform duration-200" />
    </AccordionPrimitive.Trigger>
  </AccordionPrimitive.Header>
))
AccordionTrigger.displayName = AccordionPrimitive.Trigger.displayName"""

// ---------------- AccordionContent ------------------ //
type [<Erase>] IAccordionContentProp = interface end
/// Accessor for <c>IAccordionContentProp</c>-erties
type [<Erase>] accordionContent =
    inherit Accordion.content<IAccordionContentProp>
    static member inline private noop = ignore

/// The Accordion Content Component
let AccordionContent : JSX.ElementType = JSX.jsx """
React.forwardRef(({ className, children, ...props }, ref) => (
  <AccordionPrimitive.Content
    ref={ref}
    className="overflow-hidden text-sm data-[state=closed]:animate-accordion-up data-[state=open]:animate-accordion-down"
    {...props}>
    <div className={cn("pb-4 pt-0", className)}>{children}</div>
  </AccordionPrimitive.Content>
))
AccordionContent.displayName = AccordionPrimitive.Content.displayName
"""

type [<Erase>] Shadcn =
    static member inline Accordion ( props : IAccordionProp list ) = JSX.createElement Accordion props
    static member inline Accordion ( children : ReactElement list ) = JSX.createElementWithChildren Accordion children
    static member inline Accordion ( el : ReactElement ) = JSX.createElement Accordion [ accordion.asChild true ; accordion.children el ]
    static member inline AccordionItem ( props : IAccordionItemProp list ) = JSX.createElement AccordionItem props
    static member inline AccordionItem ( children : ReactElement list ) = JSX.createElementWithChildren AccordionItem children
    static member inline AccordionItem ( el : ReactElement ) = JSX.createElement AccordionItem [ accordionItem.asChild true ; accordionItem.children el ]
    static member inline AccordionTrigger ( props : IAccordionTriggerProp list ) = JSX.createElement AccordionTrigger props
    static member inline AccordionTrigger ( children : ReactElement list ) = JSX.createElementWithChildren AccordionTrigger children
    static member inline AccordionTrigger ( el : ReactElement ) = JSX.createElement AccordionTrigger [ accordionTrigger.asChild true ; accordionTrigger.children el ]
    static member inline AccordionTrigger ( value : string ) = JSX.createElement AccordionTrigger [ prop.text value ]
    static member inline AccordionContent ( props : IAccordionContentProp list ) = JSX.createElement AccordionContent props
    static member inline AccordionContent ( value : string ) = JSX.createElement AccordionContent [ prop.text value ]
    static member inline AccordionContent ( children : ReactElement list ) = JSX.createElementWithChildren AccordionContent children
    static member inline AccordionContent ( el : ReactElement ) = JSX.createElement AccordionContent [ accordionContent.asChild true ; accordionContent.children el ]