﻿namespace Feliz.Lucide.Generator

open FParsec
open System

module Parsers =
    let find value skip = skipCharsTillString value skip Int32.MaxValue >>. spaces
    let findCI value skip = skipCharsTillStringCI value skip Int32.MaxValue >>. spaces
    let findValidDeclaration : Parser<_,_> = manyTill (find "declare" true >>. spaces ) ( followedBy (pstring "const") >>. pstring "const" )
    let readIdentifier : Parser<_,_> = manyCharsTill (letter <|> digit ) (anyOf ": ")

    let getNextIconDecl : Parser<_,_> = findValidDeclaration >>. spaces >>. readIdentifier
    let getDecls : Parser<_,_> = manyTill (getNextIconDecl) (notFollowedBy ( find "declare" true ))

[<AutoOpen>]
module Generator =
    // Attributable to Shmew - taken from Feliz.Generator.MaterialUI/Common.fs
    let appendApostropheToReservedKeywords =
      let reserved =
        [
          "checked"; "static"; "fixed"; "inline"; "default"; "component";
          "inherit"; "open"; "type"; "true"; "false"; "in"; "end"; "global"
        ]
        |> Set.ofList
      fun s -> if reserved.Contains s then s + "'" else s
      
    let parseIdentifiers target =
        runParserOnFile Parsers.getDecls () target (System.Text.UTF8Encoding())
        |> function
            | Success(result, _, _) -> result
            | Failure(errorMsg,_,_) -> printfn $"{errorMsg}" |> exit 1

    let renderIdentifierMember identifier =
        $"""
        static member inline {identifier} ( props : ILucideIconProp list ) = import "{identifier}" LucideIconsLab |> Interop.mkProperty<ILucideIconProp> "iconNode" |> fun iconProp -> createElement ( import "Icon" LucideIcons ) (iconProp::props)"""
        
    
    let renderDocument parsedIdentifiers =
        [
            """
namespace Feliz.Lucide

// THIS FILE IS AUTO-GENERATED

open Feliz.Interop.Extend
open Feliz.Lucide.Lucide
open Fable.Core.JsInterop
open Fable.React

[<AutoOpen; System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
module LucideLabHelpers =

    let inline reactElement (el: ReactElementType) (props: 'a) : ReactElement = import "createElement" "react"

    let inline createElement (el: ReactElementType) (props: 'ControlProperty list) : ReactElement = reactElement el (!!props |> createObj)
    
    let [<Literal>] LucideIconsLab = "@lucide/lab"
    
module Lab =
    type icon with static member inline iconNode ( value : string ) = Interop.mkProperty<ILucideIconProp> "iconNode" ( import value LucideIconsLab )
    type Icon with
        static member inline icon (props : ILucideIconProp list) = createElement ( import "Icon" LucideIcons ) props"""
            for ( identifier : string ) in parsedIdentifiers do
                renderIdentifierMember ( identifier |> appendApostropheToReservedKeywords )
        ] |> String.concat ""

open System.IO

module Program =
    [<EntryPoint>]
    let main argv =
        parseIdentifiers "../node_modules/@lucide/lab/dist/lucide-lab.d.ts"
        |> renderDocument
        |> fun render -> File.WriteAllText(@"..\Feliz.Lucide\LucideLab.fs", render)
        0