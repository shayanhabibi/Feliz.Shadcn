module Program

open Feliz
open Browser.Dom
open Fable.Core.JsInterop
open Feliz.UseElmish
importSideEffects "./index.css"

open Feliz.Shadcn.Accordion
[<ReactComponent>]
let Accordion () =
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

open Feliz.Shadcn.Avatar
[<ReactComponent>]
let Avatar () =
    avatar.root [
        prop.children [
            avatar.image [ prop.src "https://github.com/shadcn.png" ]
            avatar.fallback [ prop.text "SH" ]
        ]
    ]

open Feliz.Shadcn.Checkbox
[<ReactComponent>]
let Checkbox () =
    let (label,setLabel) = React.useState("Unchecked")
    Html.div [
        checkbox.root [
            root.onCheckedChange ( fun checkedVal -> if checkedVal then setLabel "Checked" else setLabel "Unchecked" )
        ]
        Html.text label
    ]

open Feliz.Shadcn.Collapsible
[<ReactComponent>]
let Collapsible () =
    collapsible.root [
        prop.children [
            collapsible.trigger [
                prop.text "Can I use this in my project?"
            ]
            collapsible.content [
                prop.text "Yes. Free to use for personal and commercial projects."
            ]
        ]
    ]

open Feliz.Shadcn.Label
[<ReactComponent>]
let Label () =
    label.root [
        prop.text "I'm some label bro"
    ]

open Feliz.Shadcn.Dialog
[<ReactComponent>]
let Dialog () =
    Html.div [ dialog.root [
        prop.children [
            dialog.trigger [ prop.text "Open" ]
            dialog.content [
                prop.children [
                    Html.h1 "IMPLEMENT DIALOG TITLE AND CONTENT PARTS"
                    Label ()
                ]
            ]
        ]
    ] ]

open Feliz.Shadcn.Popover
[<ReactComponent>]
let Popover () =
    let (open',setOpen) = React.useState false
    popover.root [
        root.open' open'
        prop.children [
            popover.trigger [
                prop.children [
                    checkbox.root [ root.onCheckedChange setOpen ]
                ]
            ]
            popover.content [
                prop.children [
                    label.root [
                        prop.text "I'm in a popover yooo"
                    ]
                ]
            ]
        ]
    ]

[<ReactComponent>]
let TestView () =
    Html.div [
        prop.className "flex-col p-10 space-y-10"
        prop.children [
            Accordion ()
            Avatar ()
            Checkbox ()
            Collapsible ()
            Dialog ()
            Popover ()
        ]
    ]
    
let root = ReactDOM.createRoot (document.getElementById "elmish-app")
root.render (TestView ())