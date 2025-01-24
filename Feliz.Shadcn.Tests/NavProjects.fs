module Feliz.Shadcn.Tests.NavProjects

open Feliz
open Feliz.Shadcn.Interop
open Feliz.Lucide
open Feliz.Shadcn
open Fable.Core

[<ReactComponent>]
let NavProjects ( projects : {| name : string ; url : string ; icon : ILucideIconProp list -> ReactElement |} list ) =
    let ProjectItem ( item : {| name : string ; url : string ; icon : ILucideIconProp list -> ReactElement |} ) =
        Shadcn.SidebarMenuItem [
            sidebarMenuItem.key item.name
            props.children [
                Shadcn.SidebarMenuButton [
                    sidebarMenuButton.asChild true
                    props.children [
                        Html.a [
                            prop.href item.url
                            prop.children [
                                item.icon []
                                Html.span item.name
                            ]
                        ]
                    ]
                ]
                
                Shadcn.DropdownMenu [
                    Shadcn.DropdownMenuTrigger [
                        dropdownMenuTrigger.asChild true
                        props.children [
                            Shadcn.SidebarMenuAction [
                                sidebarMenuAction.showOnHover true
                                props.children [
                                    Icon.MoveHorizontal []
                                    Html.span [ prop.className "sr-only" ; prop.text "More" ]
                                ]
                            ]
                        ]
                    ]
                    Shadcn.DropdownMenuContent [
                        props.className "w-48 rounded-lg"
                        props.children [
                            for iconEl, text in [
                                Icon.Folder, "View Project"
                                Icon.Forward, "Share Project"
                                Icon.Trash2, "Delete Project"
                            ] do Shadcn.DropdownMenuItem [
                                iconEl [ unbox(svg.className "text-muted-foreground") ]
                                Html.span text
                            ]
                        ]
                    ]
                ]
            ]
        ]
    
    Shadcn.SidebarGroup [
        props.className "group-data-[collapsible=icon]:hidden"
        props.children [
            Shadcn.SidebarGroupLabel "Projects"
            Shadcn.SidebarMenu [
                for item in projects do
                    item |> ProjectItem
                Shadcn.SidebarMenuItem [
                    Shadcn.SidebarMenuButton [
                        props.className "text-sidebar-foreground/70"
                        props.children [
                            Icon.MoveHorizontal [ unbox (svg.className "text-sidebar-foreground/70") ]
                            Html.span "More"
                        ]
                    ]
                ]
            ]
        ]
    ]