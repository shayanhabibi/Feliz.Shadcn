module Program

open Fable.Core.JS
open Feliz
open Browser.Dom
open Fable.Core.JsInterop
open Feliz.UseElmish
open Feliz.Lucide
open Feliz.Lucide.Lab
open Feliz.Shadcn
open Fable.Core
open Feliz.Interop.Extend
open Fable.Core.JS

importSideEffects "./index.css"

[<ReactComponent>]
let CalendarView () =
    let date, setDate = React.useState( Constructors.Date.Create() )
    Calendar [
        
        calendar.mode.single
        calendar.selected date
        calendar.onDayClick ( fun e -> !!e |> setDate )
        calendar.hideHead true
    ]

[<ReactComponent>]
let Modal () =
    AlertDialog [ alertDialog.defaultOpen true ; alertDialog.children [
        AlertDialogTrigger [ alertDialogTrigger.text "Open" ]
        AlertDialogContent [ alertDialogContent.children [
            AlertDialogHeader [ alertDialogHeader.children [
                AlertDialogTitle [ alertDialogTitle.text "Are you sure?" ]
                AlertDialogDescription [ alertDialogDescription.text "This action cannot be undone" ]
            ] ]
            AlertDialogFooter [ alertDialogFooter.children [
                AlertDialogCancel [ alertDialogCancel.text "Cancel" ]
                AlertDialogAction [ alertDialogAction.text "Continue" ]
            ] ]
        ]]
    ]]

let view =
    Html.div [
        CalendarView ()
        Modal ()
        RAccordion [
            accordion.children [
                RAccordionItem [
                    accordionItem.value "item1"
                    accordionItem.children [
                        RAccordionTrigger [ accordionTrigger.text "First item" ]
                        RAccordionContent [ accordionContent.text "hello world!" ]
                    ]
                ]
                RAccordionItem [
                    accordionItem.value "item2"
                    accordionItem.children [
                        RAccordionTrigger [ accordionTrigger.text "Second item" ]
                        RAccordionContent [ accordionContent.children [
                            RAlert [
                                alert.variant.destructive
                                alert.children [
                                    RAlertTitle [ alertTitle.text "hey" ]
                                    RAlertDescription [ alertDescription.text "you ok bro?" ]
                                ]
                            ]
                        ] ]
                    ]
                ]
            ]
    ]]

let root = ReactDOM.createRoot (document.getElementById "elmish-app")
root.render ( view )