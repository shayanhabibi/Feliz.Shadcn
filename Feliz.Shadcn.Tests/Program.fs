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
open Feliz.Shadcn.Interop
open Fable.Core.JS

importSideEffects "./index.css"

let private imports = (
        Sidebar,
        SidebarContent,
        SidebarGroup,
        SidebarGroupContent,
        SidebarGroupLabel,
        SidebarMenu,
        SidebarMenuButton,
        SidebarMenuItem
    )

[<ReactComponent>]
let private AppSideBar () =
    let items = [
        {|
          title = "Home"
          url = "#"
          icon = Icon.House []
        |}
        {|
            title = "Inbox"
            url = "#"
            icon = Icon.Inbox []
        |}
        {|
            title = "Calendar"
            url = "#"
            icon = Icon.Search []
        |}
        {|
            title = "Settings"
            url = "#"
            icon = Icon.Settings []
        |}
    ]
    
    Shadcn.Sidebar [
        sidebar.collapsible.icon
        sidebar.children (
        Shadcn.SidebarContent [
            Shadcn.SidebarGroup [
                Shadcn.SidebarGroupLabel "Application"
                Shadcn.SidebarGroupContent [
                    Shadcn.SidebarMenu [
                        for item in items do
                            Shadcn.SidebarMenuItem [
                            sidebarMenuItem.key item.title
                            sidebarMenuItem.children [
                                Shadcn.SidebarMenuButton [
                                sidebarMenuButton.asChild true
                                sidebarMenuButton.tooltip item.title
                                sidebarMenuButton.children
                                    ( Html.a [
                                        prop.href item.url
                                        prop.children [
                                            item.icon
                                            Html.span item.title
                                        ]
                                    ])
                                ]        
                            ]
                            ]
                    ]
                ]
            ]
            Shadcn.SidebarRail [ Html.none ]
        ])
        
    ]

[<ReactComponent>]
let private Layout ( children : ReactElement list ) =
    Shadcn.SidebarProvider [
        AppSideBar ()
        Html.main [ prop.children ( Shadcn.SidebarTrigger [ Html.text "" ]  :: children) ]
    ]

let something = Shadcn.Button [
    props.className "test"
]

let private root = ReactDOM.createRoot (document.getElementById "elmish-app")
// root.render ( Partas.Components.AppSideBar () )
root.render ( Layout [] )