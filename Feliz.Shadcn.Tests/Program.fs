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

[<JSX.Component>]
let noop =
    JSX.jsx $"""
    import {{Header, Trigger, Root, Item}} from "@radix-ui/react-accordion"
    <></>
"""
    

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
let AccordionTrigger () =
    let ref = React.useRef()
    JSX.jsx $"""
    <Header className="flex">
        <Trigger ref={ref}
                className="flex flex-1 items-center justify-between py-4 text-sm font-medium transition-all hover:underline text-left [&[data-state=open]>svg]:rotate-180">
        {Html.text "hello"}
        {Icon.ChevronDown [icon.className "h-4 w-4 shrink-0 text-muted-foreground transition-transform duration-200"]}
        </Trigger>
    </Header>
    """

[<JSX.Component>]
let Accordion () =
    let ref = React.useRef()
    JSX.jsx $"""
    <Root ref={ref}>
        <Item ref={ref} className={"border-b"}>
            {AccordionTrigger ()}
        </Item>
    </Root>
"""

[<JSX.Component>]
let Test (props : IReactProperty list ) =
    let properties = !!props |> createObj
    emitJsStatement properties "const {children, placeholder=\"test\", ...props} = $0"
    JSX.jsx $"""
    <>
    {{children}}
    <input {{...props}} placeholder={{placeholder}}/>
    </>
"""
let root = ReactDOM.createRoot (document.getElementById "elmish-app")
root.render ( Test [prop.text "Hello World" ; prop.autoFocus true ; prop.placeholder "banana" ] |> JSX.toReact)