module Program

open Feliz
open Browser.Dom
open Fable.Core.JsInterop
open Feliz.UseElmish
open Feliz.Shadcn.Accordion

importSideEffects "./index.css"

[<ReactComponent>]
let view () =
    accordion.root [
        root.collapsible true
        root.defaultValue "item-1"
        root.type'.single
        prop.classes ["h-full"]
        prop.children [
            accordion.item [
                prop.value "item-1"
                prop.children [
                    accordion.trigger [ prop.text "is it accessible?" ]
                    accordion.content [ prop.text "yes" ]
                ]
            ]
            accordion.item [
                prop.value "item-2"
                prop.children [
                    accordion.trigger [ prop.text "is it responsive?" ]
                    accordion.content [ prop.text "yes" ]
                ]
            ]
        ]
    ]

let root = ReactDOM.createRoot (document.getElementById "elmish-app")
root.render (view())