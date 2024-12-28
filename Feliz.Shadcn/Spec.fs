namespace Feliz.Shadcn

open Fable.React
open Fable.Core
open Fable.Core.JsInterop

type [<Erase>] IAccordionProp = interface end
type [<Erase>] IAccordionItemProp = interface end

type [<Erase>] IAlertProp = interface end

type [<Erase>] IAspectRatioProp = interface end

type [<Erase>] IAvatarProp = interface end

type [<Erase>] IBadgeProp = interface end

type [<Erase>] IBreadcrumbProp = interface end
type [<Erase>] IBreadcrumbItemProp = interface end

type [<Erase>] IButtonProp = interface end

type [<Erase>] ICalendarProp = interface end

type [<Erase>] ICardProp = interface end

type [<Erase>] ICarouselProp = interface end
type [<Erase>] ICarouselItemProp = interface end

// type [<Erase>] IChartProp = interface end
// type [<Erase>] IBarChartProp = interface end
// type [<Erase>] ICartesianGridProp = interface end
// type [<Erase>] IXaxisProp = interface end
// type [<Erase>] ITooltip = interface end

type [<Erase>] ICheckboxProp = interface end
type [<Erase>] ICheckboxGroupProp = interface end

type [<Erase>] ICollapsibleProp = interface end
type [<Erase>] ICollapsibleTriggerProp = interface end
type [<Erase>] ICollapsibleContentProp = interface end

type [<Erase>] ICommandProp = interface end
type [<Erase>] ICommandInputProp = interface end
type [<Erase>] ICommandListProp = interface end
type [<Erase>] ICommandGroupProp = interface end
type [<Erase>] ICommandSeparator = interface end
type [<Erase>] ICommandItemProp = interface end

type [<Erase>] IContextMenuProp = interface end
type [<Erase>] IContextMenuTriggerProp = interface end
type [<Erase>] IContextMenuContentProp = interface end
type [<Erase>] IContextMenuItemProp = interface end
type [<Erase>] IContextMenuShortcutProp = interface end
type [<Erase>] IContextMenuSubProp = interface end
type [<Erase>] IContextMenuSubTrigger = interface end
type [<Erase>] IContextMenuSubContent = interface end
type [<Erase>] IContextMenuSeparatorProp = interface end
type [<Erase>] IContextMenuCheckboxItemProp = interface end
type [<Erase>] IContextMenuRadioGroupProp = interface end
type [<Erase>] IContextMenuRadioItemProp = interface end
type [<Erase>] IContextMenuLabelProp = interface end

type [<Erase>] ISingleDatePickerProp = interface end
type [<Erase>] IMultipleDatePickerProp = interface end
type [<Erase>] IDateRangePickerProp = interface end
type [<Erase>] IClearableDatePickerProp = interface end

type [<Erase>] IDialogProp = interface end

type [<Erase>] IDrawerProp = interface end

type [<Erase>] IDropdownProp = interface end
type [<Erase>] IDropdownLabelProp = interface end
type [<Erase>] IDropdownSeparatorProp = interface end
type [<Erase>] IDropdownGroupProp = interface end
type [<Erase>] IDropdownItemProp = interface end
type [<Erase>] IDropdownSubProp = interface end

type [<Erase>] IHoverCardProp = interface end

type [<Erase>] IInputProp = interface end

type [<Erase>] IInputOTPProp = interface end
type [<Erase>] IInputOTPGroupProp = interface end
type [<Erase>] IInputOTPSlotProp = interface end
type [<Erase>] IInputOTPSeparatorProp = interface end

type [<Erase>] ILabelProp = interface end

type [<Erase>] IMenubarProp = interface end
type [<Erase>] IMenubarMenuProp = interface end
type [<Erase>] IMenubarItemProp = interface end
type [<Erase>] IMenubarSeparatorProp = interface end
type [<Erase>] IMenubarSubProp = interface end
type [<Erase>] IMenubarCheckboxItemProp = interface end
type [<Erase>] IMenubarRadioGroupProp = interface end
type [<Erase>] IMenubarRadioItemProp = interface end

type [<Erase>] IPaginationProp = interface end

type [<Erase>] IPopoverProp = interface end

type [<Erase>] IProgressProp = interface end

type [<Erase>] IRadioGroupProp = interface end
type [<Erase>] IRadioProp = interface end

type [<Erase>] IResizablePanelGroupProp = interface end
type [<Erase>] IResizablePanelProp = interface end
type [<Erase>] IResizableHandleProp = interface end

type [<Erase>] IIconProp = interface end
    
[<AutoOpen; System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
module Spec =
    let inline reactElement ( el : ReactElementType ) ( props : 'a ) : ReactElement = import "create" "react"
    let inline createElement ( el : ReactElementType ) ( props : 'ControlProperty list ) : ReactElement = reactElement el ( !!props |> createObj )
    
    let [<Literal>] LucideIcons = "shadcn-react/icons"
    let [<Literal>] ShadcnReact = "shadcn-react"
    let [<Literal>] ShadcnUI = "shadcn-react/ui"

[<RequireQualifiedAccess>]
type Interop =
    static member inline mkProperty<'ControlProperty> (key:string) (value:obj) : 'ControlProperty = unbox (key, value)
