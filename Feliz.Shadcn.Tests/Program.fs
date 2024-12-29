module Program

open Feliz
open Browser.Dom
open Fable.Core.JsInterop
open Feliz.UseElmish
open Feliz.Lucide
open Feliz.Lucide.Lab
open Feliz.Shadcn

importSideEffects "./index.css"
importSideEffects "shadcn-react/style.css"


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
    
let root = ReactDOM.createRoot (document.getElementById "elmish-app")
root.render (TestView ())