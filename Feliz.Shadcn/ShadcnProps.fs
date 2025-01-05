namespace Feliz.Shadcn

open Fable.Core
open Feliz
open Feliz.Interop.Extend

// type [<Erase>] accordion =
//     inherit prop<IAccordionProp>
//     static member inline collapsible ( value : bool ) = Interop.mkProperty<IAccordionProp> "collapsible" value
//
// [<RequireQualifiedAccess>]
// module accordion =
//     type [<Erase>] type' =
//         static member single : IAccordionProp = Interop.mkProperty "type" "single"
//         static member multiple : IAccordionProp = Interop.mkProperty "type" "multiple"
//         
// type [<Erase>] accordionItem =
//     inherit prop<IAccordionItemProp>
//     static member trigger ( value : string )= Interop.mkProperty<IAccordionItemProp> "trigger" value
//     static member value ( value' : string ) = Interop.mkProperty<IAccordionItemProp> "value" value'
//     static member expandIcon ( icon : ReactElement ) = Interop.mkProperty<IAccordionItemProp> "expandIcon" (unbox icon)
//     static member expandIcon ( nodes : ReactElement list ) = Interop.mkProperty<IAccordionItemProp> "expandIcon" nodes[0] 
//     static member header ( value : ReactElement ) = Interop.mkProperty<IAccordionItemProp> "header" value