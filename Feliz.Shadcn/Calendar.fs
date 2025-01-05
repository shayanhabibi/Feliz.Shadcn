[<AutoOpen>]
module Feliz.Shadcn.Calendar

open Browser.Types
open Fable.Core.JS
open Feliz.Interop.Extend
open Fable.Core
open Fable.Core.JsInterop
open Feliz

emitJsStatement () """
import { DayPicker } from "react-day-picker" 
import { ChevronLeft, ChevronRight } from "lucide-react"
"""

let buttonVariants = buttonVariants

// --------------- Calendar -------------- //
type [<Erase>] ICalendarProp = interface end
type [<Erase>] calendar =
    inherit prop<ICalendarProp>
    static member inline selected ( value : obj ) : ICalendarProp = Interop.mkProperty "selected" value
    static member inline onSelected ( handler : Browser.Types.Event -> unit ) : ICalendarProp = Interop.mkProperty "onSelected" handler
    static member inline min ( value : int ) : ICalendarProp = Interop.mkProperty "min" value
    static member inline max ( value : int ) : ICalendarProp = Interop.mkProperty "max" value
    static member inline defaultMonth ( value : Date ) : ICalendarProp = Interop.mkProperty "defaultMonth" value
    static member inline month ( value : Date ) : ICalendarProp = Interop.mkProperty "month" value
    static member inline onMonthChange ( handler : Date -> unit ) : ICalendarProp = Interop.mkProperty "onMonthChange" handler
    static member inline numberOfMonths ( value : int ) : ICalendarProp = Interop.mkProperty "numberOfMonths" value
    static member inline fromDate ( value : Date ) : ICalendarProp = Interop.mkProperty "fromDate" value
    static member inline toDate ( value : Date ) : ICalendarProp = Interop.mkProperty "toDate" value
    static member inline fromMonth ( value : Date ) : ICalendarProp = Interop.mkProperty "fromMonth" value
    static member inline toMonth ( value : Date ) : ICalendarProp = Interop.mkProperty "toMonth" value
    static member inline fromYear ( value : int ) : ICalendarProp = Interop.mkProperty "fromYear" value
    static member inline toYear ( value : int ) : ICalendarProp = Interop.mkProperty "toYear" value
    static member inline disableNavigation ( value : bool ) : ICalendarProp = Interop.mkProperty "disableNavigation" value
    static member inline pagedNavigation ( value : bool ) : ICalendarProp = Interop.mkProperty "pagedNavigation" value
    static member inline reverseMonths ( value : bool ) : ICalendarProp = Interop.mkProperty "reverseMonths" value
    static member inline fixedWeeks ( value : bool ) : ICalendarProp = Interop.mkProperty "fixedWeeks" value
    static member inline hideHead ( value : bool ) : ICalendarProp = Interop.mkProperty "hideHead" value
    static member inline showOutsideDays ( value : bool ) : ICalendarProp = Interop.mkProperty "showOutsideDays" value
    static member inline showWeekNumber ( value : bool ) : ICalendarProp = Interop.mkProperty "showWeekNumber" value
    static member inline ISOWeek ( value : bool ) : ICalendarProp = Interop.mkProperty "ISOWeek" value
    static member inline footer ( value : ReactElement ) : ICalendarProp = Interop.mkProperty "footer" value
    static member inline initialFocus ( value : bool ) : ICalendarProp = Interop.mkProperty "initialFocus" value
    // TODO implement disabled matchers and hidden matchers and selected matchers
    static member inline today ( value : Date ) : ICalendarProp = Interop.mkProperty "today" value
    // TODO Implement modifiers
    // TODO implement locale
    // TODO implement formatters
    static member inline onNextClick ( handler : Date -> unit ) : ICalendarProp = Interop.mkProperty "onNextClick" handler
    static member inline onPrevClick ( handler : Date -> unit ) : ICalendarProp = Interop.mkProperty "onPrevClick" handler
    static member inline onWeekNumberClick ( handler : WeekNumberClickEvent -> unit ) : ICalendarProp = Interop.mkProperty "onWeekNumberClick" handler
    static member inline onDayClick ( handler : DayClickEvent -> unit ) : ICalendarProp = Interop.mkProperty "onDayClick" handler
    static member inline onDayFocus ( handler : DayFocusEvent -> unit ) : ICalendarProp = Interop.mkProperty "onDayFocus" handler
    static member inline onDayBlur ( handler : DayFocusEvent -> unit ) : ICalendarProp = Interop.mkProperty "onDayBlur" handler
    static member inline onDayMouseEnter ( handler : DayMouseEvent -> unit ) : ICalendarProp = Interop.mkProperty "onDayMouseEnter" handler
    static member inline onDayMouseLeave ( handler : DayMouseEvent -> unit ) : ICalendarProp = Interop.mkProperty "onDayMouseLeave" handler
    static member inline onDayKeyDown ( handler : DayKeyEvent -> unit ) : ICalendarProp = Interop.mkProperty "onDayKeyDown" handler
    static member inline onDayKeyUp ( handler : DayKeyEvent -> unit ) : ICalendarProp = Interop.mkProperty "onDayKeyUp" handler
    static member inline onDayKeyPress ( handler : DayKeyEvent -> unit ) : ICalendarProp = Interop.mkProperty "onDayKeyPress" handler
    static member inline onDayPointerEnter ( handler : DayPointerEvent -> unit ) : ICalendarProp = Interop.mkProperty "onDayPointerEnter" handler
    static member inline onDayPointerLeave ( handler : DayPointerEvent -> unit ) : ICalendarProp = Interop.mkProperty "onDayPointerLeave" handler
    static member inline onDayTouchCancel ( handler : DayTouchEvent -> unit ) : ICalendarProp = Interop.mkProperty "onDayTouchCancel" handler
    static member inline onDayTouchEnd ( handler : DayTouchEvent -> unit ) : ICalendarProp = Interop.mkProperty "onDayTouchEnd" handler
    static member inline onDayTouchMove ( handler : DayTouchEvent -> unit ) : ICalendarProp = Interop.mkProperty "onDayTouchMove" handler
    static member inline onDayTouchStart ( handler : DayTouchEvent -> unit ) : ICalendarProp = Interop.mkProperty "onDayTouchStart" handler
    static member inline required ( value : bool ) : ICalendarProp = Interop.mkProperty "required" value
and [<Erase>] WeekNumberClickEvent = { weekNumber : int ; dates : Date list ; e : MouseEvent }
and [<Erase>] DayClickEvent = { day : Date ; activeModifiers : obj ; e : MouseEvent }
and [<Erase>] DayFocusEvent = { day : Date ; activeModifiers : obj ; e : FocusEvent }
and [<Erase>] DayMouseEvent = { day : Date ; activeModifiers : obj ; e : MouseEvent }
and [<Erase>] DayKeyEvent = { day : Date ; activeModifiers : obj ; e : KeyboardEvent }
and [<Erase>] DayPointerEvent = { day : Date ; activeModifiers : obj ; e : PointerEvent }
and [<Erase>] DayTouchEvent = { day : Date ; activeModifiers : obj ; e : TouchEvent }
// and [<Erase>] SelectRangeEvent = { range : Date }  // TODO Implement select range
    
[<RequireQualifiedAccess>]
module [<Erase>] calendar =
    type [<Erase>] mode =
        static member inline single : ICalendarProp = Interop.mkProperty "mode" "single"
        static member inline multiple : ICalendarProp = Interop.mkProperty "mode" "multiple"
        static member inline range : ICalendarProp = Interop.mkProperty "mode" "range"
        static member inline default' : ICalendarProp = Interop.mkProperty "mode" "default"
        
    type [<Erase>] captionLayout =
        static member inline dropdown : ICalendarProp = Interop.mkProperty "captionLayout" "dropdown"
        static member inline buttons : ICalendarProp = Interop.mkProperty "captionLayout" "buttons"
        static member inline dropdownButtons : ICalendarProp = Interop.mkProperty "captionLayout" "dropdown-buttons"
    type [<Erase>] weekStartsOn =
        static member inline sunday : ICalendarProp = Interop.mkProperty "weekStartsOn" 0
        static member inline monday : ICalendarProp = Interop.mkProperty "weekStartsOn" 1
        static member inline tuesday : ICalendarProp = Interop.mkProperty "weekStartsOn" 2
        static member inline wednesday : ICalendarProp = Interop.mkProperty "weekStartsOn" 3
        static member inline thursday : ICalendarProp = Interop.mkProperty "weekStartsOn" 4
        static member inline friday : ICalendarProp = Interop.mkProperty "weekStartsOn" 5
        static member inline saturday : ICalendarProp = Interop.mkProperty "weekStartsOn" 6
    type [<Erase>] firstWeekContainsDate =
        static member inline ``1`` : ICalendarProp = Interop.mkProperty "firstWeekContainsDate" 1
        static member inline ``4`` : ICalendarProp = Interop.mkProperty "firstWeekContainsDate" 4
[<JSX.Component>]
let Calendar ( props : ICalendarProp list ) : ReactElement =
    let ref = React.useRef()
    let properties = props |> JSX.mkObject
    emitJsStatement properties "const {className, showOutsideDays=true, classNames, ...sprops} = $0; const {props, ...attrs} = $props;"
    let modeClass = if properties?mode = "range" then
                      "[&:has(>.day-range-end)]:rounded-r-md [&:has(>.day-range-start)]:rounded-l-md first:[&:has([aria-selected])]:rounded-l-md last:[&:has([aria-selected])]:rounded-r-md"
                    else "[&:has([aria-selected])]:rounded-md"
    let calClassNames =
        {|
        months = "flex flex-col sm:flex-row space-y-4 sm:space-x-4 sm:space-y-0"
        month = "space-y-4"
        caption = "flex justify-center pt-1 relative items-center"
        caption_label = "text-sm font-medium"
        nav = "space-x-1 flex items-center"
        nav_button = JSX.cn [|
          (unbox buttonVariants)({| variant = "outline" |})
          "h-7 w-7 bg-transparent p-0 opacity-50 hover:opacity-100"
        |]
        nav_button_previous = "absolute left-1"
        nav_button_next = "absolute right-1"
        table = "w-full border-collapse space-y-1"
        head_row = "flex"
        head_cell =
          "text-muted-foreground rounded-md w-8 font-normal text-[0.8rem]"
        row = "flex w-full mt-2"
        cell = JSX.cn [|
          "relative p-0 text-center text-sm focus-within:relative focus-within:z-20 [&:has([aria-selected])]:bg-accent [&:has([aria-selected].day-outside)]:bg-accent/50 [&:has([aria-selected].day-range-end)]:rounded-r-md"
          modeClass
        |]
        day = JSX.cn [|
          (unbox buttonVariants)({| variant = "ghost" |})
          "h-8 w-8 p-0 font-normal aria-selected:opacity-100"
        |]
        day_range_start = "day-range-start"
        day_range_end = "day-range-end"
        day_selected =
          "bg-primary text-primary-foreground hover:bg-primary hover:text-primary-foreground focus:bg-primary focus:text-primary-foreground"
        day_today = "bg-accent text-accent-foreground"
        day_outside =
          "day-outside text-muted-foreground aria-selected:bg-accent/50 aria-selected:text-muted-foreground"
        day_disabled = "text-muted-foreground opacity-50"
        day_range_middle = "aria-selected:bg-accent aria-selected:text-accent-foreground"
        day_hidden = "invisible"
        |}
        //TODO fix the spread of the passed classNames into the object
    JSX.jsx $"""
    <DayPicker
        showOutsideDays={{showOutsideDays}}
        className={ JSX.cn [| "p-3" ; properties?className |] }
        classNames={calClassNames}
        components={{{{IconLeft : ({{className, ...props}}) => (
            <ChevronLeft className={ JSX.cn [| "h-4 w-4" ; properties?className |] } {{...props}}  />
            ),
            IconRight : ({{className, ...props}}) => (
                <ChevronRight className={ JSX.cn [| "h-4 w-4" ; properties?className |] } {{...props}} />
            )
        }}}}
        {{...sprops}} {{...attrs}}
        />
    """ |> unbox