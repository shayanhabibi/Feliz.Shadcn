module Program

open Feliz
open Browser.Dom
open Fable.Core.JsInterop
open Feliz.UseElmish
open Feliz.Lucide

importSideEffects "./index.css"
importSideEffects "shadcn-react/style.css"


[<ReactComponent>]
let TestView () =
    Html.div [
        prop.className "flex-col p-10 space-y-10"
        prop.children [
            Lucide.bundleIcons.AArrowDown []
            Lucide.bundleIcons.Ambulance [icons.size 48]
            
        ]
    ]
    
let root = ReactDOM.createRoot (document.getElementById "elmish-app")
root.render (TestView ())