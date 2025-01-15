[<AutoOpen>]
module Feliz.Shadcn.Chart

open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz

JSX.injectShadcnLib

let private THEMES = JSX.jsx """
  {
    light: "",
    dark: ".dark"
  }
"""

let private ChartContext = JSX.jsx "React.createContext(null)"

let private useChart () = ignore <| JSX.jsx """
{
  const context = React.useContext(ChartContext)

  if (!context) {
    throw new Error("useChart must be used within a <ChartContainer />")
  }

  return context
}
"""

// --------------- ChartStyle -------------- //
type [<Erase>] IChartStyleProp = interface end
type [<Erase>] chartStyle =
    inherit prop<IChartStyleProp>
    static member inline noop : unit = ()

let ChartStyle : JSX.ElementType = JSX.jsx """
({
  id,
  config
}) => {
  const colorConfig = Object.entries(config).filter(([, config]) => config.theme || config.color)

  if (!colorConfig.length) {
    return null
  }

  return (
    (<style
      dangerouslySetInnerHTML={{
        __html: Object.entries(THEMES)
          .map(([theme, prefix]) => `
${prefix} [data-chart=${id}] {
${colorConfig
.map(([key, itemConfig]) => {
const color =
  itemConfig.theme?.[theme] ||
  itemConfig.color
return color ? `  --color-${key}: ${color};` : null
})
.join("\n")}
}
`)
          .join("\n"),
      }} />)
  );
}
"""

// --------------- ChartContainer -------------- //
type [<Erase>] IChartContainerProp = interface end
type [<Erase>] chartContainer =
    inherit prop<IChartContainerProp>
    static member inline noop : unit = ()

let ChartContainer : JSX.ElementType = JSX.jsx """
import * as RechartsPrimitive from "recharts";

React.forwardRef(({ id, className, children, config, ...props }, ref) => {
  const uniqueId = React.useId()
  const chartId = `chart-${id || uniqueId.replace(/:/g, "")}`

  return (
    (<ChartContext.Provider value={{ config }}>
      <div
        data-chart={chartId}
        ref={ref}
        className={cn(
          "flex aspect-video justify-center text-xs [&_.recharts-cartesian-axis-tick_text]:fill-muted-foreground [&_.recharts-cartesian-grid_line[stroke='#ccc']]:stroke-border/50 [&_.recharts-curve.recharts-tooltip-cursor]:stroke-border [&_.recharts-dot[stroke='#fff']]:stroke-transparent [&_.recharts-layer]:outline-none [&_.recharts-polar-grid_[stroke='#ccc']]:stroke-border [&_.recharts-radial-bar-background-sector]:fill-muted [&_.recharts-rectangle.recharts-tooltip-cursor]:fill-muted [&_.recharts-reference-line_[stroke='#ccc']]:stroke-border [&_.recharts-sector[stroke='#fff']]:stroke-transparent [&_.recharts-sector]:outline-none [&_.recharts-surface]:outline-none",
          className
        )}
        {...props}>
        <ChartStyle id={chartId} config={config} />
        <RechartsPrimitive.ResponsiveContainer>
          {children}
        </RechartsPrimitive.ResponsiveContainer>
      </div>
    </ChartContext.Provider>)
  );
})
ChartContainer.displayName = "Chart"
"""

// --------------- ChartTooltip -------------- //
type [<Erase>] IChartTooltipProp = interface end
type [<Erase>] chartTooltip =
    inherit prop<IChartTooltipProp>
    static member inline noop : unit = ()

let ChartTooltip : JSX.ElementType = JSX.jsx """
RechartsPrimitive.Tooltip
"""

// --------------- ChartTooltipContent -------------- //
type [<Erase>] IChartTooltipContentProp = interface end
type [<Erase>] chartTooltipContent =
    inherit prop<IChartTooltipContentProp>
    static member inline noop : unit = ()

let ChartTooltipContent : JSX.ElementType = JSX.jsx """
React.forwardRef((
  {
    active,
    payload,
    className,
    indicator = "dot",
    hideLabel = false,
    hideIndicator = false,
    label,
    labelFormatter,
    labelClassName,
    formatter,
    color,
    nameKey,
    labelKey,
  },
  ref
) => {
  const { config } = useChart()

  const tooltipLabel = React.useMemo(() => {
    if (hideLabel || !payload?.length) {
      return null
    }

    const [item] = payload
    const key = `${labelKey || item.dataKey || item.name || "value"}`
    const itemConfig = getPayloadConfigFromPayload(config, item, key)
    const value =
      !labelKey && typeof label === "string"
        ? config[label]?.label || label
        : itemConfig?.label

    if (labelFormatter) {
      return (
        (<div className={cn("font-medium", labelClassName)}>
          {labelFormatter(value, payload)}
        </div>)
      );
    }

    if (!value) {
      return null
    }

    return <div className={cn("font-medium", labelClassName)}>{value}</div>;
  }, [
    label,
    labelFormatter,
    payload,
    hideLabel,
    labelClassName,
    config,
    labelKey,
  ])

  if (!active || !payload?.length) {
    return null
  }

  const nestLabel = payload.length === 1 && indicator !== "dot"

  return (
    (<div
      ref={ref}
      className={cn(
        "grid min-w-[8rem] items-start gap-1.5 rounded-lg border border-border/50 bg-background px-2.5 py-1.5 text-xs shadow-xl",
        className
      )}>
      {!nestLabel ? tooltipLabel : null}
      <div className="grid gap-1.5">
        {payload.map((item, index) => {
          const key = `${nameKey || item.name || item.dataKey || "value"}`
          const itemConfig = getPayloadConfigFromPayload(config, item, key)
          const indicatorColor = color || item.payload.fill || item.color

          return (
            (<div
              key={item.dataKey}
              className={cn(
                "flex w-full flex-wrap items-stretch gap-2 [&>svg]:h-2.5 [&>svg]:w-2.5 [&>svg]:text-muted-foreground",
                indicator === "dot" && "items-center"
              )}>
              {formatter && item?.value !== undefined && item.name ? (
                formatter(item.value, item.name, item, index, item.payload)
              ) : (
                <>
                  {itemConfig?.icon ? (
                    <itemConfig.icon />
                  ) : (
                    !hideIndicator && (
                      <div
                        className={cn("shrink-0 rounded-[2px] border-[--color-border] bg-[--color-bg]", {
                          "h-2.5 w-2.5": indicator === "dot",
                          "w-1": indicator === "line",
                          "w-0 border-[1.5px] border-dashed bg-transparent":
                            indicator === "dashed",
                          "my-0.5": nestLabel && indicator === "dashed",
                        })}
                        style={
                          {
                            "--color-bg": indicatorColor,
                            "--color-border": indicatorColor
                          }
                        } />
                    )
                  )}
                  <div
                    className={cn(
                      "flex flex-1 justify-between leading-none",
                      nestLabel ? "items-end" : "items-center"
                    )}>
                    <div className="grid gap-1.5">
                      {nestLabel ? tooltipLabel : null}
                      <span className="text-muted-foreground">
                        {itemConfig?.label || item.name}
                      </span>
                    </div>
                    {item.value && (
                      <span className="font-mono font-medium tabular-nums text-foreground">
                        {item.value.toLocaleString()}
                      </span>
                    )}
                  </div>
                </>
              )}
            </div>)
          );
        })}
      </div>
    </div>)
  );
})
ChartTooltipContent.displayName = "ChartTooltip"
"""

// --------------- ChartLegend -------------- //
type [<Erase>] IChartLegendProp = interface end
type [<Erase>] chartLegend =
    inherit prop<IChartLegendProp>
    static member inline noop : unit = ()

let ChartLegend : JSX.ElementType = JSX.jsx """
RechartsPrimitive.Legend
"""

// --------------- ChartLegendContent -------------- //
type [<Erase>] IChartLegendContentProp = interface end
type [<Erase>] chartLegendContent =
    inherit prop<IChartLegendContentProp>
    static member inline noop : unit = ()

let ChartLegendContent : JSX.ElementType = JSX.jsx """
React.forwardRef((
  { className, hideIcon = false, payload, verticalAlign = "bottom", nameKey },
  ref
) => {
  const { config } = useChart()

  if (!payload?.length) {
    return null
  }

  return (
    (<div
      ref={ref}
      className={cn(
        "flex items-center justify-center gap-4",
        verticalAlign === "top" ? "pb-3" : "pt-3",
        className
      )}>
      {payload.map((item) => {
        const key = `${nameKey || item.dataKey || "value"}`
        const itemConfig = getPayloadConfigFromPayload(config, item, key)

        return (
          (<div
            key={item.value}
            className={cn(
              "flex items-center gap-1.5 [&>svg]:h-3 [&>svg]:w-3 [&>svg]:text-muted-foreground"
            )}>
            {itemConfig?.icon && !hideIcon ? (
              <itemConfig.icon />
            ) : (
              <div
                className="h-2 w-2 shrink-0 rounded-[2px]"
                style={{
                  backgroundColor: item.color,
                }} />
            )}
            {itemConfig?.label}
          </div>)
        );
      })}
    </div>)
  );
})
ChartLegendContent.displayName = "ChartLegend"
"""

let private getPayloadConfigFromPayload config payload key = ignore <| JSX.jsx """
{
  if (typeof payload !== "object" || payload === null) {
    return undefined
  }

  const payloadPayload =
    "payload" in payload &&
    typeof payload.payload === "object" &&
    payload.payload !== null
      ? payload.payload
      : undefined

  let configLabelKey = key

  if (
    key in payload &&
    typeof payload[key] === "string"
  ) {
    configLabelKey = payload[key]
  } else if (
    payloadPayload &&
    key in payloadPayload &&
    typeof payloadPayload[key] === "string"
  ) {
    configLabelKey = payloadPayload[key]
  }

  return configLabelKey in config
    ? config[configLabelKey]
    : config[key];
}
"""

type [<Erase>] Shadcn =
    static member inline ChartContainer ( props : IChartContainerProp list ) = JSX.createElement ChartContainer props
    static member inline ChartContainer ( children : ReactElement list ) = JSX.createElementWithChildren ChartContainer children
    static member inline ChartTooltip ( props : IChartTooltipProp list ) = JSX.createElement ChartTooltip props
    static member inline ChartTooltip ( children : ReactElement list ) = JSX.createElementWithChildren ChartTooltip children
    static member inline ChartTooltipContent ( props : IChartTooltipContentProp list ) = JSX.createElement ChartTooltipContent props
    static member inline ChartTooltipContent ( children : ReactElement list ) = JSX.createElementWithChildren ChartTooltipContent children
    static member inline ChartLegend ( props : IChartLegendProp list ) = JSX.createElement ChartLegend props
    static member inline ChartLegend ( children : ReactElement list ) = JSX.createElementWithChildren ChartLegend children
    static member inline ChartLegendContent ( props : IChartLegendContentProp list ) = JSX.createElement ChartLegendContent props
    static member inline ChartLegendContent ( children : ReactElement list ) = JSX.createElementWithChildren ChartLegendContent children
    static member inline ChartStyle ( props : IChartStyleProp list ) = JSX.createElement ChartStyle props
    static member inline ChartStyle ( children : ReactElement list ) = JSX.createElementWithChildren ChartStyle children