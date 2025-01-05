[<AutoOpen>]
module Feliz.Shadcn.Accordion

open Feliz.RadixUI
open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.Lucide
open Browser.Types

// Including the import in the JSX interpolation is valid, but it seems to
// interfere with the template language on Jetbrains Rider so it is extracted to
// the module level to prevent polluting the template language syntax analyzers
emitJsStatement () $"""import * as AccordionPrimitive from "@radix-ui/react-accordion" """


// ---------------- Accordion ------------------ //
type [<Erase>] IAccordionProp = interface end
// Define props specific for components
type [<Erase>] accordion =
    inherit Accordion.root<IAccordionProp>
    static member inline collapsible ( value : bool ) = Interop.mkProperty<IAccordionProp> "collapsible" value
    static member inline defaultValue ( value : string ) = Interop.mkProperty<IAccordionProp> "defaultValue" value
    // string or string array depending on type of accordion
    static member inline onValueChange ( handler : string -> unit ) = Interop.mkProperty<IAccordionProp> "onValueChange" handler
    static member inline onValueChange ( handler : string list -> unit ) = Interop.mkProperty<IAccordionProp> "onValueChange" handler

[<RequireQualifiedAccess>]
module [<Erase>] accordion =
    type [<Erase>] type' =
        inherit accordionroot.type'<IAccordionProp>
        static member private noop = ()
        // static member inline single : IAccordionProp = Interop.mkProperty "type" "single"
        // static member inline multiple : IAccordionProp = Interop.mkProperty "type" "multiple"
    
    type [<Erase>] orientation =
        inherit accordionroot.orientation<IAccordionProp>
        static member private noop = ()
        // static member inline horizontal : IAccordionProp = Interop.mkProperty "orientation" "horizontal"
        // static member inline vertical : IAccordionProp = Interop.mkProperty "orientation" "vertical"
    
    type [<Erase>] dir =
        inherit accordionroot.dir<IAccordionProp>
        static member private noop = ()
        // static member inline ltr : IAccordionProp = Interop.mkProperty "dir" "ltr"
        // static member inline rtl : IAccordionProp = Interop.mkProperty "dir" "rtl"

// Define component

// The components match the same name as Shadcn
// They are defined first as JSX.Components, this means they can be used
// in following JSX templates. If you want to use the Feliz style, then you can
// prefix the element with 'R'. This simply forwards the JSX.Element to the React converter
// so that the call site doesn't need to manage the type conflicts
[<JSX.Component>]
let Accordion ( props : IAccordionProp list ) : JSX.Element =
    let ref = React.useRef()
    let properties = !!props |> createObj
    emitJsStatement properties "const {...props} = $0"
    JSX.jsx $"""
    <AccordionPrimitive.Root {{...props}} ref={ref}/>
    """
let RAccordion = Accordion >> JSX.toReact

// ---------------- AccordionItem ------------------ //
type [<Erase>] IAccordionItemProp = interface end
type [<Erase>] accordionItem =
    inherit Accordion.item<IAccordionItemProp>
    static member inline private noop = ignore
    
// The components take a list of react properties such that they are compatible with Feliz
[<JSX.Component>]
let AccordionItem ( props : IAccordionItemProp list ) : JSX.Element =
    let ref = React.useRef()
    // The properties list is marshalled into an object on runtime to
    // allow the emitJsStatement hack that follows to function cleanly
    let properties = !!props |> createObj
    // This is a hack so that we can route particular object fields to
    // particular parts of the JSX element and then utilise spread elsewhere
    // ---
    // This also permits defaults to be defined for particular fields, although
    // this is not demonstrated here. It is the exact same as JS, and is overriden
    // when the `properties` includes the field (ie the default only persists so long
    // as you do not have supply a different value in the properties list)
    emitJsStatement properties "const {className, ...props} = $0"
    // Typical JSX statement
    // Notice the `JSX.cn` helper in the className attribute.
    // It takes an array of strings and expands them into a `twMerge` and `clsx`
    // It is a direct rip of the utility Shadcn recommends but implemented in F#
    // to avoid another .js/.ts file dependency
    // Within the interpolation 'hole', we use unsafe object access to access
    // particular properties that may or may not be within the properties object.
    JSX.jsx $"""
    <AccordionPrimitive.Item
        ref={ref}
        className={ JSX.cn [| "border-b" ; properties?className |] }
        {{...props}} />
    """
// Helper to use the element in Feliz style
let RAccordionItem = AccordionItem >> JSX.toReact

// ---------------- AccordionTrigger ------------------ //
type [<Erase>] IAccordionTriggerProp = interface end
type [<Erase>] accordionTrigger =
    inherit Accordion.trigger<IAccordionTriggerProp>
    static member inline private noop = ignore

[<JSX.Component>]
let AccordionTrigger ( props : IAccordionTriggerProp list ) : JSX.Element =
    let ref = React.useRef()
    let properties = !!props |> createObj
    emitJsStatement properties "const {className, children, ...props} = $0"
    JSX.jsx $"""
    <AccordionPrimitive.Header className="flex">
        <AccordionPrimitive.Trigger
            ref={ref}
            className={JSX.cn [|
                "flex flex-1 items-center justify-between py-4 text-sm font-medium transition-all hover:underline text-left [&[data-state=open]>svg]:rotate-180"
                properties?className
                |]}
            {{...props}}>
            {{children}}
            {Icon.ChevronDown [ icon.className "h-4 w-4 shrink-0 text-muted-foreground transition-transform duration-200" ]}
        </AccordionPrimitive.Trigger>
    </AccordionPrimitive.Header>
    """
let RAccordionTrigger = AccordionTrigger >> JSX.toReact


// ---------------- AccordionContent ------------------ //
type [<Erase>] IAccordionContentProp = interface end

type [<Erase>] accordionContent =
    inherit Accordion.content<IAccordionContentProp>
    static member inline private noop = ignore

[<JSX.Component>]
let AccordionContent ( props : IAccordionContentProp list ) : JSX.Element =
    let ref = React.useRef()
    let properties = !!props |> createObj
    emitJsStatement properties "const {className, children, ...props} = $0"
    JSX.jsx $"""
    <AccordionPrimitive.Content
        ref={ref}
        className="overflow-hidden text-sm data-[state=closed]:animate-accordion-up data-[state=open]:animate-accordion-down"
        {{...props}}>
        <div className={JSX.cn [| "pb-4 pt-0" ; properties?className |] }> {{children}} </div>
    </AccordionPrimitive.Content>
    """
let RAccordionContent = AccordionContent >> JSX.toReact