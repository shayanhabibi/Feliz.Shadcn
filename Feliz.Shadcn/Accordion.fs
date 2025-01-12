[<AutoOpen>]
module Feliz.Shadcn.Accordion

open Feliz.RadixUI
open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.Lucide
open Browser.Types

emitJsStatement () $"""import * as AccordionPrimitive from "@radix-ui/react-accordion" """


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

[<RequireQualifiedAccess>]
/// Enum properties for Shadcn Accordion (root)
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
[<JSX.Component>]
let Accordion ( props : IAccordionProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = !!props |> JSX.mkObject
    emitJsStatement properties "const {...sprops} = $0; const {props, ...attrs} = $props"
    JSX.jsx $"""
    <AccordionPrimitive.Root {{...props}} {{...attrs}} ref={ref}/>
    """ |> unbox

// ---------------- AccordionItem ------------------ //
type [<Erase>] IAccordionItemProp = interface end
/// Accessor for <c>IAccordionItemProp</c> -erties
type [<Erase>] accordionItem =
    inherit Accordion.item<IAccordionItemProp>
    static member inline private noop = ignore

/// The Accordion Item Component
[<JSX.Component>]
let AccordionItem ( props : IAccordionItemProp list ) : ReactElement =
    let ref = React.useRef()    
    let properties = !!props |> JSX.mkObject
    emitJsStatement properties "const {className, ...sprops} = $0; const {props, ...attrs} = $props"
    JSX.jsx $"""
    <AccordionPrimitive.Item
        ref={ref}
        className={ JSX.cn [| "border-b" ; properties?className |] }
        {{...props}} {{...attrs}} />
    """ |> unbox

// ---------------- AccordionTrigger ------------------ //
type [<Erase>] IAccordionTriggerProp = interface end
/// Accessor for <c>IAccordionTriggerProp</c>-erties
type [<Erase>] accordionTrigger =
    inherit Accordion.trigger<IAccordionTriggerProp>
    static member inline private noop = ignore

/// The Accordion Trigger Component
// todo add more docs
[<JSX.Component>]
let AccordionTrigger ( props : IAccordionTriggerProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = !!props |> JSX.mkObject
    emitJsStatement properties "const {className, children, ...sprops} = $0; const {props, ...attrs} = $props"
    JSX.jsx $"""
    <AccordionPrimitive.Header className="flex">
        <AccordionPrimitive.Trigger
            ref={ref}
            className={JSX.cn [|
                "flex flex-1 items-center justify-between py-4 text-sm font-medium transition-all hover:underline text-left [&[data-state=open]>svg]:rotate-180"
                properties?className
                |]}
            {{...props}} {{...attrs}}>
            {{children}}
            {Icon.ChevronDown [ icon.className "h-4 w-4 shrink-0 text-muted-foreground transition-transform duration-200" ]}
        </AccordionPrimitive.Trigger>
    </AccordionPrimitive.Header>
    """ |> unbox

// ---------------- AccordionContent ------------------ //
type [<Erase>] IAccordionContentProp = interface end
/// Accessor for <c>IAccordionContentProp</c>-erties
type [<Erase>] accordionContent =
    inherit Accordion.content<IAccordionContentProp>
    static member inline private noop = ignore

/// The Accordion Content Component
[<JSX.Component>]
let AccordionContent ( props : IAccordionContentProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = !!props |> JSX.mkObject
    emitJsStatement properties "const {className, children, ...sprops} = $0; const {props, ...attrs} = $props"
    JSX.jsx $"""
    <AccordionPrimitive.Content
        ref={ref}
        className="overflow-hidden text-sm data-[state=closed]:animate-accordion-up data-[state=open]:animate-accordion-down"
        {{...attrs}} {{...props}}>
        <div className={JSX.cn [| "pb-4 pt-0" ; properties?className |] }> {{children}} </div>
    </AccordionPrimitive.Content>
    """ |> unbox