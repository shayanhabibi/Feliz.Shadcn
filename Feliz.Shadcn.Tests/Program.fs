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
    Shadcn.Calendar [
        calendar.mode.single
        calendar.selected date
        calendar.onDayClick ( fun e -> !!e |> setDate )
        calendar.hideHead true
    ]

[<ReactComponent>]
let Modal () =
    Shadcn.AlertDialog [ alertDialog.defaultOpen true ; alertDialog.children [
        Shadcn.AlertDialogTrigger [ alertDialogTrigger.text "Open" ]
        Shadcn.AlertDialogContent [ alertDialogContent.children [
            Shadcn.AlertDialogHeader [ alertDialogHeader.children [
                Shadcn.AlertDialogTitle [ alertDialogTitle.text "Are you sure?" ]
                Shadcn.AlertDialogDescription [ alertDialogDescription.text "This action cannot be undone" ]
            ] ]
            Shadcn.AlertDialogFooter [ alertDialogFooter.children [
                Shadcn.AlertDialogCancel [ alertDialogCancel.text "Cancel" ]
                Shadcn.AlertDialogAction [ alertDialogAction.text "Continue" ]
            ] ]
        ]]
    ]]

let view =
    Html.div [
        CalendarView ()
        Modal ()
        Html.div []
        Shadcn.Accordion [
            accordion.children [
                Shadcn.AccordionItem [
                    accordionItem.value "item1"
                    accordionItem.children [
                        Shadcn.AccordionTrigger [ accordionTrigger.text "First item" ]
                        Shadcn.AccordionContent [ accordionContent.text "hello world!" ]
                    ]
                ]
                Shadcn.AccordionItem [
                    accordionItem.value "item2"
                    accordionItem.children [
                        Shadcn.AccordionTrigger [ accordionTrigger.text "Second item" ]
                        Shadcn.AccordionContent [ accordionContent.children [
                            Shadcn.Alert [
                                alert.variant.destructive
                                alert.children [
                                    Shadcn.AlertTitle [ alertTitle.text "hey" ]
                                    Shadcn.AlertDescription [ alertDescription.text "you ok bro?" ]
                                ]
                            ]
                        ] ]
                    ]
                ]
            ]
    ]]

let root = ReactDOM.createRoot (document.getElementById "elmish-app")
root.render ( view )