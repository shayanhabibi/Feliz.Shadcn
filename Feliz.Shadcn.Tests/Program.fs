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

type ct = collapsibleTrigger

[<ReactComponent>]
let NavMain () =
    let items = [
        {|
          title="hello"
          isActive=true
          icon=Icon.Ampersands []
          items=[
              {|
                title="hi"
                url=""
                |}
          ]
          |}
    ]
    Shadcn.SidebarGroup [
        Shadcn.SidebarGroupLabel [
            sidebarGroupLabel.text "Platform"
        ]
        Shadcn.SidebarMenu [
            for item in items do
                Shadcn.Collapsible [
                    collapsible.key item.title
                    collapsible.asChild true
                    collapsible.defaultOpen item.isActive
                    collapsible.className "group/collapsible"
                    collapsible.children [
                        Shadcn.SidebarMenuItem [
                            Shadcn.CollapsibleTrigger [
                                ct.asChild true
                                ct.children [
                                    Shadcn.SidebarMenuButton [
                                        sidebarMenuButton.tooltip item.title
                                        sidebarMenuButton.children [
                                            item.icon
                                            Html.span item.title
                                            Icon.ChevronRight [ icon.className "ml-auto transition-transform duration-200 group-data-[state=open]/collapsible:rotate-90" ]
                                            
                                        ]
                                    ]
                                ]
                            ]
                            Shadcn.CollapsibleContent [
                                Shadcn.SidebarMenuSub [
                                    for item in item.items do
                                        Shadcn.SidebarMenuSubItem [
                                            sidebarMenuSubItem.key item.title
                                            sidebarMenuSubItem.children [
                                                Shadcn.SidebarMenuSubButton [
                                                    sidebarMenuSubButton.asChild true
                                                    sidebarMenuSubButton.children [
                                                        Html.a [
                                                            prop.href item.url
                                                            prop.children [
                                                                Html.span item.title
                                                            ]
                                                        ]
                                                    ]
                                                ]
                                            ]
                                        ]
                                ]
                            ]
                        ]
                    ]
                ]
        ]
    ]
    

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

[<ReactComponent>]
let CommandDemo () =
    let items = [
        [
            Icon.Calendar [], "Calendar", None
            Icon.Smile [], "Search Emoji", None
            Icon.Calculator [], "Calculator", None
        ]
        [
            Icon.User [] , "Profile", Some "Ctrl P"
            Icon.CreditCard [] , "Billing", Some "Ctrl B"
            Icon.Settings [] , "Settings", Some "Ctrl S"
        ]
    ]
    let Item ( item : ReactElement * string * Option<string> ) =
        let icon, text, shortcut = item
        Shadcn.CommandItem [
            icon
            Html.span text
            match shortcut with
            | Some value -> Shadcn.CommandShortcut [ commandShortcut.text value ]
            | None -> Html.none
        ]
    Shadcn.Command [
        command.className "rounded-lg border shadow-md md:min-w-[450px]"
        command.children [
            Shadcn.CommandInput [
                commandInput.placeholder "Type a command or search..."
            ]
            Shadcn.CommandList [
                Shadcn.CommandEmpty [ commandEmpty.text "No results found." ]
                Shadcn.CommandGroup [
                    commandGroup.heading "Suggestions"
                    commandGroup.children [
                        for item in items[0] do
                            Item item
                    ]
                ]
                Shadcn.CommandSeparator [ Html.none ]
                Shadcn.CommandGroup [
                    commandGroup.heading "Settings"
                    commandGroup.children [
                        for item in items[1] do
                            Item item
                    ]
                ]
            ]
        ]
    ]

[<ReactComponent>]
let ToastDemo () =
    Html.div [
        Shadcn.Button [
            button.text "Toast"
            button.onClick ( fun _ -> Sonner.toast.info ("testing", (new Toast(description = Html.text "test", richColors = true ))) |> ignore )
        ]
        Shadcn.Toaster [ toaster.visibleToasts 5 ; toaster.expand false ; toaster.invert true ]
    ]

let root = ReactDOM.createRoot (document.getElementById "elmish-app")
root.render ( ToastDemo () )