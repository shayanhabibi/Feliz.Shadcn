module Feliz.RadixUI

open OpenQA.Selenium
open OpenQA.Selenium.Chrome
open OpenQA.Selenium.Support.UI
open System
open AngleSharp

type SubComponentParts = { Name: string; Description: string; PropsTables: IWebElement list }

type PropData = { Name: string; Required: bool; Description: string; PropType: string; PropTypeValue: string }

type Prop = { Name: string; Required: bool; Description: string; ParamOverloads: string list }

type EnumCase = { Name: string; Value: string }

type Enum = { Name: string; Cases: EnumCase list }

type SubComponentData = { Name: string; Description: string; PropData: PropData list; EnumData: PropData list }

type SubComponent = { Name: string; Description: string; Props: Prop list; Enums: Enum list }

type RadixComponentData = { Name: string; Description: string; ImportCommand: string; SubComponentData: SubComponentData list }

type RadixComponent = { Name: string; Description: string; NpmPackage: string; SubComponents: SubComponent list }


module Utils =
    let prefix (prefix: string) s = prefix + s
    let indent spacesPerLevel numLevels = prefix (String.replicate (numLevels * spacesPerLevel) " ")
    let indent4 = indent 2 2
    let newline = "\n"
    let lowerFirst s = if s = "" then s else s.Substring(0, 1).ToLower() + s.Substring 1
    let replace (oldValue: string) (newValue: string) (s: string) = s.Replace(oldValue, newValue)
    let removeSpaces = replace " " ""

    let appendApostropheToReservedKeywords (name: string) =
        let reserved = // F# reserved keywords
            [
                "checked"; "static"; "fixed"; "inline"; "default"; "component";
                "inherit"; "open"; "type"; "true"; "false"; "in"; "end"; "global";
                "list"; "as"; "base"; "begin"; "class"; "bool"; "int"; "member"; "lazy"
            ]
            |> Set.ofList

        if reserved.Contains name then sprintf "%s'" name else name

    let kebabCaseToCamelCase (s: string) =
        let pieces = s.Split("-")

        if pieces.Length > 1 then
            pieces
            |> Array.iteri (fun i piece ->
                if i > 0 then
                    pieces.[i] <-
                        piece.Substring(0, 1).ToUpper()
                        + piece.Substring(1))

            pieces |> String.concat ""
        else
            s


module Parser =

    let (|ParseFunction|_|) = function
        | "() => void" -> Some [ "(unit -> unit)" ]
        | "(checked: boolean) => void" -> Some [ "(bool -> unit)" ]
        | "(event: Event) => void" -> Some [ "(Browser.Types.Event -> unit)" ]
        | "(event: FocusOutsideEvent) => void" -> Some [ "(FocusEvent -> unit)" ]
        | "(event: KeyboardEvent) => void" -> Some [ "(Browser.Types.KeyboardEvent -> unit)" ]
        | "(event: PointerDownOutsideEvent | FocusOutsideEvent) => void" -> Some [
            "(PointerEvent -> unit)"
            "(FocusEvent -> unit)"
            ]
        | "(event: PointerDownOutsideEvent) => void" -> Some [ "(PointerEvent -> unit)" ]
        | "(event: React.FocusEvent | MouseEvent | TouchEvent) => void" -> Some [
            "(Browser.Types.FocusEvent -> unit)"
            "(Browser.Types.MouseEvent -> unit)"
            "(Browser.Types.TouchEvent -> unit)"
            ]
        | "(event: SwipeEvent) => void" -> Some [ "(UIEvent -> unit)" ]
        | "(open: boolean) => void" -> Some [ "(bool -> unit)" ]
        | "(pressed: boolean) => void" -> Some [ "(bool -> unit)" ]
        | """(status: "idle" | "loading" | "loaded" | "error") => void""" -> Some [
            "(string -> unit)"
            "(image.status -> unit)"
            ]
        | "(validity: ValidityState | undefined) => React.ReactNode" -> Some [ "(ValidityState -> ReactElement)" ]
        | "(value: number, max: number) => string" -> Some [ "(int -> int -> string)" ]
        | "(value: string) => void" -> Some [ "(string -> unit)" ]
        | "(value: string[]) => void" -> Some [ "(string[] -> unit)"]
        | "onValueChange?(value: number[]): void" -> Some [ "(int[] -> unit)" ]
        | "onValueCommit?(value: number[]): void" -> Some [ "(int[] -> unit)" ]
        | "(checked: boolean | 'indeterminate') => void" -> Some [
            "(bool -> unit)"
            "(string -> unit)"
            ]
        | other -> None

    let (|ParseSingleType|_|) = function
        | "number | null" -> Some [ "int" ]
        | "number" -> Some [ "int" ]
        | "number[]" -> Some [ "int[]" ]
        | "ReactNode" -> Some [ "ReactElement" ]
        | "string[]" -> Some [ "string[]" ]
        | "boolean" -> Some [ "bool" ]
        | "HTMLElement" as s -> Some [ s ]
        | other -> None

    let (|ParseEnum|) = function
        | """ "auto" | "always" | "scroll" | "hover" """ ->  [
            "type", ["auto" ; "always" ; "scroll" ; "hover"]
            ]
        | """ "automatic" | "manual" """ ->  [
            "activationMode", ["automatic" ; "manual"]
            ]
        | """ "foreground" | "background" """ ->  [
            "type", ["foreground" ; "background"]
            ]
        | """ "horizontal" | "vertical" """ ->  [
            "orientation", ["horizontal" ; "vertical"]
            ]
        | """ "horizontal" | "vertical" | undefined """ ->  [
            "orientation", ["horizontal" ; "vertical"]
            ]
        | """ "item-aligned" | "popper" """ ->  [
            "position", ["item-aligned" ; "popper"]
            ]
        | """ "ltr" | "rtl" """ ->  [
            "dir", ["ltr" ; "rtl"]
            ]
        | """ "partial" | "always" """ ->  [
            "sticky", ["partial" ; "always"]
            ]
        | """ "right" | "left" | "up" | "down" """ ->  [
            "swipeDirection", ["right" ; "left" ; "up" ; "down"]
            ]
        | """ "single" | "multiple" """ ->  [
            "type", ["single" ; "multiple"]
            ]
        | """ "start" | "center" | "end" """ ->  [
            "align", ["start" ; "center" ; "end"]
            ]
        | """ "top" | "right" | "bottom" | "left" """ ->  [
            "side", ["top" ; "right" ; "bottom" ; "left"]
            ]
        | other -> printfn "Unknown enum: %s" other; []

    let (|ParseMultiType|_|) = function
        | "boolean | 'indeterminate'" -> Some [
            "bool"
            "string" 
            ]
        | "number | Padding" -> Some [
            "int"
            "Padding"
            ]
        | "Element | null | Array<Element | null>" -> Some [
            "ReactElement"
            "ReactElement[]"
            ]
        | "number | Partial<Record<Side, number>>" -> Some [
            "int"
            "'T"
            ]
        | other -> None

    let getParamOverloads = function
        | ParseFunction s -> s
        | ParseSingleType s -> s
        | ParseMultiType s -> s
        | other -> [other]


module SeleniumHelpers =

    let safeFindElement by (element: ISearchContext) =
        try Some (element.FindElement(by))
        with | :? NoSuchElementException -> None

    let waitForElement condition (driver: IWebDriver) timeoutSeconds =
        let wait = WebDriverWait(driver, TimeSpan.FromSeconds(float timeoutSeconds))
        wait.Until(condition)

    let elementIsVisible (by: By) (driver: IWebDriver) =
        let wait = WebDriverWait(driver, TimeSpan.FromSeconds(20.0))
        wait.Until(fun drv ->
            let element = drv.FindElement(by)
            element.Displayed)

    let invisibilityOfElementLocated(by: By) =
        fun (driver: IWebDriver) ->
            try
                let element = driver.FindElement(by)
                not element.Displayed
            with
            | :? NoSuchElementException -> true
            | :? StaleElementReferenceException -> true


module RadixComponentScraping =
    open SeleniumHelpers

    let getApiReferenceElements driver =
        let startElem = safeFindElement (By.XPath("//h2[@id='api-reference']")) driver |> Option.get
        let js = driver :> IJavaScriptExecutor
        let mutable elems = []
        let mutable current = js.ExecuteScript("return arguments[0].nextElementSibling;", startElem) :?> IWebElement
        while (current <> null) &&  (current.TagName.ToLower() <> "h2") do
            elems <- current :: elems
            current <- js.ExecuteScript("return arguments[0].nextElementSibling;", current) :?> IWebElement
        List.rev elems

    let groupElements (elements: IWebElement list) =
        let rec loop acc currentGroup (elements: IWebElement list) =
            match elements with
            | [] -> List.rev (currentGroup :: acc)
            | h3 :: p :: div :: rest when h3.TagName = "h3" && p.TagName = "p" && div.GetAttribute("class") = "rt-Box rt-r-my-4" ->
                let currentGroup: SubComponentParts =
                    { Name = h3.Text; Description = p.Text; PropsTables = [div] }
                loop (currentGroup :: acc) currentGroup rest

            | _ :: rest -> loop acc currentGroup rest

        loop [] { Name = ""; Description = ""; PropsTables = [] } elements

    let getMainComponentName (driver: IWebDriver) =
        SeleniumHelpers.safeFindElement (By.XPath("//h1")) driver
        |> Option.map (fun e -> e.Text)
        |> Option.defaultValue ""

    let getMainComponentDescription (driver: IWebDriver) =
        driver
        |> safeFindElement (By.XPath("//*[@id=\"__next\"]/div/div[2]/div[2]/section/div[1]/p[1]"))
        |> Option.map (fun e -> e.Text)
        |> Option.defaultValue ""

    let getImportCommand (driver: IWebDriver) =
        driver
        |> safeFindElement (By.XPath("//*[@id=\"__next\"]/div/div[2]/div[2]/section/div[1]/div[5]/pre/code/div"))
        |> Option.map (fun e -> e.Text)
        |> Option.defaultValue ""

    let getSubComponentParts = getApiReferenceElements >> groupElements

    let processSubComponentPropTable driver (parts: SubComponentParts) =
        parts.PropsTables
        |> List.head
        |> fun e ->
            let rows =  e.FindElements(By.CssSelector("tr.rt-TableRow")) |> Seq.toList

            rows
            |> List.skip 1 // skip header
            |> List.map (fun r ->
                let propNameSection = r.FindElement(By.CssSelector("th.rt-TableCell.rt-TableRowHeaderCell"))
                let propTypeSection = r.FindElement(By.CssSelector("td.rt-TableCell"))

                let propName = propNameSection.FindElement(By.TagName("code")).Text

                let propDescriptionButton = propNameSection.FindElement(By.TagName("button"))
                if propDescriptionButton.Displayed && propDescriptionButton.Enabled then
                    propDescriptionButton.Click()

                waitForElement (elementIsVisible(By.CssSelector("div > div.radix-themes.rt-PopperContent.rt-PopoverContent.radix-themes-custom-fonts.rt-r-size-2"))) driver 20 |> ignore

                let propNameDescription = driver.FindElement(By.CssSelector("div > div.radix-themes.rt-PopperContent.rt-PopoverContent.radix-themes-custom-fonts.rt-r-size-2")).Text

                let propTypeDescriptionButton = propNameSection.FindElement(By.TagName("button"))
                if propTypeDescriptionButton.Displayed && propTypeDescriptionButton.Enabled then
                    propTypeDescriptionButton.Click()

                waitForElement (invisibilityOfElementLocated(By.CssSelector("div > div.radix-themes.rt-PopperContent.rt-PopoverContent.radix-themes-custom-fonts.rt-r-size-2"))) driver 20 |> ignore

                let propType = propTypeSection.FindElement(By.TagName("code")).Text

                let propTypeValue =
                    match propType with
                    | "function" | "enum" | "Padding" | "Boundary" | "number | Padding" ->
                        let descriptionbutton = propTypeSection.FindElement(By.TagName("button"))
                        if descriptionbutton.Displayed && descriptionbutton.Enabled then
                            descriptionbutton.Click()

                        waitForElement (elementIsVisible(By.CssSelector("div > div.radix-themes.rt-PopperContent.rt-PopoverContent div > code"))) driver 20 |> ignore

                        let value = driver.FindElement(By.CssSelector("div > div.radix-themes.rt-PopperContent.rt-PopoverContent div > code")).Text

                        let descriptionbutton = propNameSection.FindElement(By.TagName("button"))
                        if descriptionbutton.Displayed && descriptionbutton.Enabled then
                            descriptionbutton.Click()

                        waitForElement (invisibilityOfElementLocated(By.CssSelector("div > div.radix-themes.rt-PopperContent.rt-PopoverContent div > code"))) driver 20 |> ignore

                        value
                    | other -> other

                {
                    Name = propName.Replace("*", "")
                    Required = propName.EndsWith("*")
                    Description = propNameDescription.Replace(Utils.newline, " ")
                    PropType = propType
                    PropTypeValue = propTypeValue
                }
            )

    let getSubComponentData driver (processedSubComponents: Collections.Generic.HashSet<string>)  (parts: SubComponentParts) =
        if processedSubComponents.Contains(parts.Name) then
            printfn "Skipping already processed subcomponent: %s" parts.Name
            None
        else
            printfn "Processing subcomponent: %s" parts.Name
            processedSubComponents.Add(parts.Name) |> ignore

            let allPropData = processSubComponentPropTable driver parts

            let propData = allPropData |> List.filter (fun p -> p.PropType <> "enum")

            let enumData = allPropData |> List.filter (fun p -> p.PropType = "enum" || (p.PropType = "function" && p.PropTypeValue.Contains "(status:"))

            Some {
                Name = parts.Name
                Description = parts.Description
                PropData = propData
                EnumData = enumData
            }

    let getRadixComponent (driver: WebDriver) url =
        driver.Url <- url
        let processedSubComponents = Collections.Generic.HashSet<string>()
        {
            Name = getMainComponentName driver
            Description = getMainComponentDescription driver
            ImportCommand = getImportCommand driver |> fun s -> s.Replace("npm install ", "")
            SubComponentData = getSubComponentParts driver |> List.choose (getSubComponentData driver processedSubComponents)
        }


module RadixComponentData =

    let private getValidComponentUrls () = 
        async {
            let url = "https://www.radix-ui.com/primitives/docs/components/accordion"
            let className = "DocsNav_DocsNavItem__VrHf6"
            let baseUri = new Uri(url)
            let config = Configuration.Default.WithDefaultLoader()
            let! document = Async.AwaitTask (BrowsingContext.New(config).OpenAsync(url))
            let elements = document.QuerySelectorAll($"a.{className}")

            let invalidUrls =
                [
                    "https://www.radix-ui.com/primitives/docs/utilities/accessible-icon"
                    "https://www.radix-ui.com/primitives/docs/utilities/direction-provider"
                    "https://www.radix-ui.com/primitives/docs/utilities/portal"
                    "https://www.radix-ui.com/primitives/docs/utilities/slot"
                    "https://www.radix-ui.com/primitives/docs/utilities/id-provider"
                    "https://www.radix-ui.com/primitives/docs/utilities/announce"
                    "https://www.radix-ui.com/primitives/docs/utilities/visually-hidden"
                    "https://www.radix-ui.com/primitives/docs/utilities/polymorphic"
                    "https://www.radix-ui.com/primitives/docs/overview/introduction"
                    "https://www.radix-ui.com/primitives/docs/overview/getting-started"
                    "https://www.radix-ui.com/primitives/docs/overview/accessibility"
                    "https://www.radix-ui.com/primitives/docs/overview/releases"
                    "https://www.radix-ui.com/primitives/docs/guides/styling"
                    "https://www.radix-ui.com/primitives/docs/guides/animation"
                    "https://www.radix-ui.com/primitives/docs/guides/composition"
                    "https://www.radix-ui.com/primitives/docs/guides/server-side-rendering"
                ]

            return
                elements
                |> Seq.choose (fun element ->
                    match element.GetAttribute("href") with
                    | null ->
                        printfn "Element does not have a href attribute."
                        None
                    | href when element.QuerySelector("span[data-accent-color='yellow']") <> null ->
                        printfn "Skipping deprecated component."
                        None
                    | href ->
                        let absoluteUri = new Uri(baseUri, href)
                        Some absoluteUri.AbsoluteUri)
                |> Seq.filter (fun url -> not (invalidUrls |> Seq.contains url))
                |> Seq.toList
        }

    let refresh () =
        async {
            let! validUrls =  getValidComponentUrls ()

            let options = ChromeOptions()
            options.AddArgument("--headless")

            use driver = new ChromeDriver(options)

            let radixComponents =
                validUrls
                |> List.map (fun (url: string) ->
                    printfn "%A" url
                    let n = url.Split('/').[6]
                    printfn "Processing %s" n
                    let comp = RadixComponentScraping.getRadixComponent driver url
                    System.IO.File.WriteAllText($"components_json/{n}.json", Newtonsoft.Json.JsonConvert.SerializeObject(comp))
                    comp
                )

            driver.Quit()
        }

    let loadComponentsFromJson (path: string) =
        System.IO.Directory.GetFiles(path, "*.json")
        |> Array.map (fun file ->
            let json = System.IO.File.ReadAllText(file)
            Newtonsoft.Json.JsonConvert.DeserializeObject<RadixComponentData>(json)
        )
        |> Array.toList


module Render =
    open Utils

    let mkEnums enumData =
        enumData
        |> List.map (fun e ->
            e.PropTypeValue
            |> fun enumStr ->
                let cleanEnumStr = if enumStr.Contains "(status:" then enumStr.Replace("(status: ", "").Replace(") => void", "") else enumStr // handle special case
                let cases =
                    cleanEnumStr.Split('|')
                    |> Array.map (fun str -> str.Trim())
                    |> Array.toList
                let name = if enumStr.Contains("(status:") then "status" else e.Name
                {   Name = name
                    Cases = cases |> List.map (fun c -> { Name = c; Value = c })
                }
            )

    let mkProps (propData: PropData list) = 
        propData
        |> List.map (fun p ->
            {   Name = p.Name
                Required = p.Required
                Description = p.Description
                ParamOverloads = Parser.getParamOverloads p.PropTypeValue
            }
        )

    let mkRadixComponent (radixComponentData: RadixComponentData) =
        {
            Name = radixComponentData.Name
            Description = radixComponentData.Description
            NpmPackage = radixComponentData.ImportCommand
            SubComponents =
                radixComponentData.SubComponentData
                |> List.map (fun subComponentData ->
                    {
                        Name = subComponentData.Name
                        Description = subComponentData.Description
                        Props = mkProps subComponentData.PropData
                        Enums = mkEnums subComponentData.EnumData
                    }
                )
        }

    let renderComponent radixComponent =
        [
            $"/// {radixComponent.Description}"
            $"type [<Erase>] {radixComponent.Name |> removeSpaces |> lowerFirst |> appendApostropheToReservedKeywords} ="
            for subComponent in radixComponent.SubComponents do
                let importName = if subComponent.Name = "Root" then radixComponent.Name else radixComponent.Name+subComponent.Name
                $"/// {subComponent.Description}" |> indent4
                $"static member inline {subComponent.Name |> lowerFirst |> appendApostropheToReservedKeywords} (props: IReactProperty seq) = createElement (import \"{importName |> removeSpaces}\" \"{radixComponent.NpmPackage}\") props" |> indent4
            ""
            ""
        ]
        |> String.concat newline
    
    let renderComponentInterface radixComponent =
        [
            for description in radixComponent.Description.Split([|'\n' ; '\r'|]) do $"/// {description}"
            $"module [<Erase>] {radixComponent.Name |> removeSpaces |> appendApostropheToReservedKeywords} ="
            for subComponent in radixComponent.SubComponents do
                let importName = if subComponent.Name = "Root" then radixComponent.Name else radixComponent.Name+subComponent.Name
                $"/// import \"{importName |> removeSpaces}\" \"{radixComponent.NpmPackage}\"" |> indent4
                for description in subComponent.Description.Split([|'\n' ; '\r'|]) do
                    $"/// {description}" |> indent4
                $"type [<Erase>] {subComponent.Name |> lowerFirst |> appendApostropheToReservedKeywords}<'Property> =" |> indent4
                "inherit prop<'Property>" |> indent4 |> indent4
                for prop in subComponent.Props do
                    for overload in prop.ParamOverloads do
                        for description in prop.Description.Split([|'\n' ; '\r'|]) do
                            $"/// {description}" |> indent4 |> indent4
                        $"static member inline {prop.Name |> kebabCaseToCamelCase |> appendApostropheToReservedKeywords} ( value : {overload} ) : 'Property = Interop.mkProperty \"{prop.Name}\" value" |> indent4 |> indent4
                ""
            for subComponent in radixComponent.SubComponents do
                if subComponent.Enums.IsEmpty |> not then
                    $"module [<Erase>] {radixComponent.Name |> removeSpaces |> lowerFirst}{subComponent.Name |> removeSpaces |> lowerFirst} ="
                    for enum in subComponent.Enums do
                        $"type [<Erase>] {enum.Name |> removeSpaces |> lowerFirst |> appendApostropheToReservedKeywords}<'Property> =" |> indent4
                        for case in enum.Cases do
                            $"static member inline {case.Name |> fun s -> s.Trim('\"') |> kebabCaseToCamelCase |> removeSpaces |> lowerFirst |> appendApostropheToReservedKeywords} : 'Property = Interop.mkProperty \"{enum.Name}\" \"{(case.Value.Trim('\"'))}\"" |> indent4 |> indent4
                        ""
        ] |> String.concat newline
                        

    let renderComponentProps radixComponent =
        [
            for subComponent in radixComponent.SubComponents do
                $"/// {subComponent.Description}"
                $"type [<Erase>] {subComponent.Name |> removeSpaces |> lowerFirst |> appendApostropheToReservedKeywords} ="
                for prop in subComponent.Props do
                    for overload in prop.ParamOverloads do
                        $"/// {prop.Description}" |> indent4
                        $"static member inline {prop.Name |> kebabCaseToCamelCase |> appendApostropheToReservedKeywords} (value: {overload}) = Feliz.Interop.mkAttr \"{prop.Name}\" value" |> indent4
                ""
                ""
                if subComponent.Enums.IsEmpty |> not then
                    $"module {subComponent.Name |> removeSpaces |> lowerFirst |> appendApostropheToReservedKeywords} ="
                    ""
                    for enum in subComponent.Enums do
                        $"type [<Erase>] {enum.Name |> removeSpaces |> lowerFirst |> appendApostropheToReservedKeywords} =" |> indent4
                        for case in enum.Cases do
                            $"static member inline {case.Name |> fun s -> s.Trim('\"') |> kebabCaseToCamelCase |> removeSpaces |> lowerFirst |> appendApostropheToReservedKeywords} = Feliz.Interop.mkAttr \"{enum.Name}\" \"{(case.Value.Trim('\"'))}\"" |> indent4 |> indent4
                        ""
                ""
                ""
        ]
        |> String.concat newline

    let renderComponentPage radixComponent =
        System.IO.File.WriteAllText($"../Feliz.RadixUI/{radixComponent.Name |> removeSpaces}.fs",
            [
                $"namespace Feliz.Shadcn.{radixComponent.Name |> removeSpaces}"
                ""
                "open Feliz"
                "open Fable.Core"
                "open Fable.Core.JsInterop"
                "open Feliz.Shadcn"
                "open Browser.Types"
                ""
                ""
                renderComponent radixComponent
                renderComponentProps radixComponent
            ] |> String.concat newline)

    let renderComponentInterfacePage radixComponent =
        System.IO.File.WriteAllText($"../Feliz.RadixUI/{radixComponent.Name |> removeSpaces}.fs",
            [
                $"namespace Feliz.RadixUI"
                ""
                "open Feliz"
                "open Fable.Core"
                "open Fable.Core.JsInterop"
                "open Feliz.Interop.Extend"
                "open Browser.Types"
                ""
                ""
                // "[<RequireQualifiedAccess>]"
                // "type [<Erase>] Interop ="
                // "// Interop helpers for Component restricted properties" |> indent4
                // "static member inline mkProperty<'ControlProperty> (key:string) (value:obj) : 'ControlProperty = unbox (key, value)" |> indent4
                // ""
                renderComponentInterface radixComponent
            ] |> String.concat newline)

[<EntryPoint>]
let main args =
    async {
        if args.Length > 0 && args[0] = "--refresh" then
        // if true then
            return! RadixComponentData.refresh()

        let componentData = RadixComponentData.loadComponentsFromJson "components_json"

        componentData
        |> List.map Render.mkRadixComponent
        // |> List.map Render.renderComponentPage
        |> List.map Render.renderComponentInterfacePage
        |> ignore

        return 0
    }
    |> Async.RunSynchronously
