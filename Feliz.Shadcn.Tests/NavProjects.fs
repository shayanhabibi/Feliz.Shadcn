module Feliz.Shadcn.Tests.NavProjects

open Feliz
open Feliz.Lucide
open Feliz.Shadcn
open Fable.Core

[<ReactComponent>]
let NavProjects ( projects : {| name : string ; url : string ; icon : ILucideIconProp list -> ReactElement |} list ) =
    let ProjectItem ( item : {| name : string ; url : string ; icon : ILucideIconProp list -> ReactElement |} ) =
        Shadcn.SidebarMenuItem [
            sidebarMenuItem.key item.name
            sidebarMenuItem.children [
                Shadcn.SidebarMenuButton [
                    sidebarMenuButton.asChild true
                    sidebarMenuButton.children [
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
                        dropdownMenuTrigger.children [
                            Shadcn.SidebarMenuAction [
                                sidebarMenuAction.showOnHover true
                                sidebarMenuAction.children [
                                    Icon.MoveHorizontal []
                                    Html.span [ prop.className "sr-only" ; prop.text "More" ]
                                ]
                            ]
                        ]
                    ]
                    Shadcn.DropdownMenuContent [
                        dropdownMenuContent.className "w-48 rounded-lg"
                        dropdownMenuContent.children [
                            for iconEl, text in [
                                Icon.Folder, "View Project"
                                Icon.Forward, "Share Project"
                                Icon.Trash2, "Delete Project"
                            ] do Shadcn.DropdownMenuItem [
                                iconEl [ icon.className "text-muted-foreground" ]
                                Html.span text
                            ]
                        ]
                    ]
                ]
            ]
        ]
    
    Shadcn.SidebarGroup [
        sidebarGroup.className "group-data-[collapsible=icon]:hidden"
        sidebarGroup.children [
            Shadcn.SidebarGroupLabel "Projects"
            Shadcn.SidebarMenu [
                for item in projects do
                    item |> ProjectItem
                Shadcn.SidebarMenuItem [
                    Shadcn.SidebarMenuButton [
                        sidebarMenuButton.className "text-sidebar-foreground/70"
                        sidebarMenuButton.children [
                            Icon.MoveHorizontal [ icon.className "text-sidebar-foreground/70" ]
                            Html.span "More"
                        ]
                    ]
                ]
            ]
        ]
    ]