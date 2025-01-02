module Program

open Feliz
open Browser.Dom
open Fable.Core.JsInterop
open Feliz.UseElmish
open Feliz.Lucide
open Feliz.Lucide.Lab
open Feliz.Shadcn
open Fable.Core
open Feliz.Interop.Extend

importSideEffects "./index.css"

emitJsStatement () $""" import {{Header, Trigger, Root, Item}} from "@radix-ui/react-accordion" """

[<ReactComponent>]
let TestView () =
    Html.div [
        prop.className "flex-col p-10 space-y-10"
        prop.children [
            Icon.AArrowDown []
            Icon.Ambulance [icon.size 48]
            Icon.burger []
            Icon.russianRubleSquare []
            Shadcn.accordion [
                accordion.collapsible true
                accordion.children [
                    Shadcn.accordionItem [
                        accordionItem.trigger "Test"
                        accordionItem.value "val1"
                        accordionItem.text "This is inside"
                    ]
                ]
            ]
        ]
    ]

[<JSX.Component>]
let Test (props : IReactProperty list ) =
    let properties = !!props |> createObj
    emitJsStatement properties "const {children, placeholder=\"test\", ...props} = $0"
    JSX.jsx $"""
    <>
    {{children}}
    <input {{...props}} placeholder={{placeholder}} className={JSX.cn [| "border-b" ; "bg-blue" |]}/>
    </>
"""

let view =
    RAccordion [
        prop.children [
            RAccordionItem [
                prop.value "item1"
                prop.children [
                    RAccordionTrigger [ prop.text "First item" ]
                    RAccordionContent [ prop.text "hello world!" ]
                ]
            ]
            RAccordionItem [
                prop.value "item2"
                prop.children [
                    RAccordionTrigger [ prop.text "Second item" ]
                    RAccordionContent [ prop.text "goodbye world!" ]
                ]
            ]
        ]
    ]

let root = ReactDOM.createRoot (document.getElementById "elmish-app")
root.render ( view )