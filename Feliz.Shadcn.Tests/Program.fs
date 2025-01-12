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
        Accordion [
            accordion.children [
                AccordionItem [
                    accordionItem.value "item1"
                    accordionItem.children [
                        AccordionTrigger [ accordionTrigger.text "First item" ]
                        AccordionContent [ accordionContent.text "hello world!" ]
                    ]
                ]
                AccordionItem [
                    accordionItem.value "item2"
                    accordionItem.children [
                        AccordionTrigger [ accordionTrigger.text "Second item" ]
                        AccordionContent [ accordionContent.children [
                            Alert [
                                alert.variant.destructive
                                alert.children [
                                    AlertTitle [ alertTitle.text "hey" ]
                                    AlertDescription [ alertDescription.text "you ok bro?" ]
                                ]
                            ]
                        ] ]
                    ]
                ]
            ]
    ]]

let root = ReactDOM.createRoot (document.getElementById "elmish-app")
root.render ( view )