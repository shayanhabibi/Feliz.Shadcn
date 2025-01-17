[<AutoOpen>]
module Feliz.Shadcn.MotionPrimitives.Disclosure

open Fable.React
open Feliz.Shadcn.Interop
open Fable.Core
open Fable.Core.JsInterop
open Feliz
JSX.injectShadcnLib
ignore <| JSX.jsx """
import { AnimatePresence, motion, MotionConfig } from 'framer-motion';
import { createContext, useContext, useState, useId, useEffect } from 'react'
"""

type [<Erase>] DisclosureVariants =
    {
        expanded : obj
        collapsed : obj // TODO - FramerMotion Variant obj type
    }

[<Global>]
[<AllowNullLiteral>]
type DisclosureContext
    [<ParamObject ; Emit("$0")>]
    (
        ``open`` : bool,
        toggle : unit -> unit,
        ?variants : DisclosureVariants
    ) =
    member val ``open`` : bool = jsNative with get,set
    member val toggle : unit -> unit = jsNative with get,set
    member val variants : DisclosureVariants option = jsNative with get,set

let private DisclosureContext : IContext<DisclosureContext> = React.createContext()

// --------------- DisclosureProvider -------------- //
type [<Erase>] IDisclosureProviderProp = interface end
type [<Erase>] disclosureProvider =
    static member inline children ( value : ReactElement ) : IDisclosureProviderProp = Interop.mkProperty "children" value
    static member inline open' ( value : bool ) : IDisclosureProviderProp = Interop.mkProperty "open" value
    static member inline onOpenChange ( handler : bool -> unit ) : IDisclosureProviderProp = Interop.mkProperty "onOpenChange" handler
    static member inline variants ( value : DisclosureVariants ) : IDisclosureProviderProp = Interop.mkProperty "variants" value

let DisclosureProvider : JSX.ElementType = JSX.jsx """
({
  children,
  open: openProp,
  onOpenChange,
  variants
}) => {
  const [internalOpenValue, setInternalOpenValue] = useState(openProp);

  useEffect(() => {
    setInternalOpenValue(openProp);
  }, [openProp]);

  const toggle = () => {
    const newOpen = !internalOpenValue;
    setInternalOpenValue(newOpen);
    if (onOpenChange) {
      onOpenChange(newOpen);
    }
  };

  return (
    (<DisclosureContext.Provider
      value={{
        open: internalOpenValue,
        toggle,
        variants,
      }}>
      {children}
    </DisclosureContext.Provider>)
  );
}
"""

let private useDisclosure = JSX.jsx """
() => {
  const context = useContext(DisclosureContext);
  if (!context) {
    throw new Error('useDisclosure must be used within a DisclosureProvider');
  }
  return context;
}"""

// --------------- Disclosure -------------- //
type [<Erase>] IDisclosureProp = interface end
type [<Erase>] disclosure =
    static member inline open' ( value : bool ) : IDisclosureProp = Interop.mkProperty "open" value
    static member inline children ( value : ReactElement ) : IDisclosureProp = Interop.mkProperty "children" value
    static member inline className ( value : string ) : IDisclosureProp = Interop.mkProperty "className" value
    static member inline transition ( value : obj ) : IDisclosureProp = Interop.mkProperty "transition" value // TODO - FramerMotion Transition type
    static member inline onOpenChange ( handler : bool -> unit ) : IDisclosureProp = Interop.mkProperty "onOpenChange" handler
    static member inline variants ( value : DisclosureVariants ) : IDisclosureProp = Interop.mkProperty "variants" value

let Disclosure : JSX.ElementType = JSX.jsx """
({
  open: openProp = false,
  onOpenChange,
  children,
  className,
  transition,
  variants
}) => {
  return (
    (<MotionConfig transition={transition}>
      <div className={className}>
        <DisclosureProvider open={openProp} onOpenChange={onOpenChange} variants={variants}>
          {React.Children.toArray(children)[0]}
          {React.Children.toArray(children)[1]}
        </DisclosureProvider>
      </div>
    </MotionConfig>)
  );
}
"""

// --------------- DisclosureTrigger -------------- //
type [<Erase>] IDisclosureTriggerProp = interface end
type [<Erase>] disclosureTrigger =
    static member inline className ( value : string ) : IDisclosureTriggerProp = Interop.mkProperty "className" value
    static member inline children ( value : ReactElement ) : IDisclosureTriggerProp = Interop.mkProperty "children" value

let DisclosureTrigger : JSX.ElementType = JSX.jsx """
({
  children,
  className
}) => {
  const { toggle, open } = useDisclosure();

  return (<>
    {React.Children.map(children, (child) => {
      return React.isValidElement(child)
        ? React.cloneElement(child, {
            onClick: toggle,
            role: 'button',
            'aria-expanded': open,
            tabIndex: 0,
            onKeyDown: (e) => {
              if (e.key === 'Enter' || e.key === ' ') {
                e.preventDefault();
                toggle();
              }
            },
            className: cn(className, (child).props.className),
            ...(child).props,
          })
        : child;
    })}
  </>);
}
"""

// --------------- DisclosureContent -------------- //
type [<Erase>] IDisclosureContentProp = interface end
type [<Erase>] disclosureContent =
    static member inline className ( value : string ) : IDisclosureContentProp = Interop.mkProperty "className" value
    static member inline children ( value : ReactElement ) : IDisclosureContentProp = Interop.mkProperty "children" value

let DisclosureContent : JSX.ElementType = JSX.jsx """
({
  children,
  className
}) => {
  const { open, variants } = useDisclosure();
  const uniqueId = useId();

  const BASE_VARIANTS = {
    expanded: {
      height: 'auto',
      opacity: 1,
    },
    collapsed: {
      height: 0,
      opacity: 0,
    },
  };

  const combinedVariants = {
    expanded: { ...BASE_VARIANTS.expanded, ...variants?.expanded },
    collapsed: { ...BASE_VARIANTS.collapsed, ...variants?.collapsed },
  };

  return (
    (<div className={cn('overflow-hidden', className)}>
      <AnimatePresence initial={false}>
        {open && (
          <motion.div
            id={uniqueId}
            initial='collapsed'
            animate='expanded'
            exit='collapsed'
            variants={combinedVariants}>
            {children}
          </motion.div>
        )}
      </AnimatePresence>
    </div>)
  );
}
"""

type [<Erase>] Shadcn =
    static member inline Disclosure ( props : IDisclosureProp list ) = JSX.createElement Disclosure props
    static member inline Disclosure ( children : ReactElement list ) = JSX.createElement Disclosure [ prop.children children[0] ]
    static member inline DisclosureProvider ( props : IDisclosureProviderProp list ) = JSX.createElement DisclosureProvider props
    static member inline DisclosureProvider ( children : ReactElement list ) = JSX.createElement DisclosureProvider [ prop.children children[0] ]
    static member inline DisclosureTrigger ( props : IDisclosureTriggerProp list ) = JSX.createElement DisclosureTrigger props
    static member inline DisclosureTrigger ( children : ReactElement list ) = JSX.createElement DisclosureTrigger [ prop.children children[0] ]
    static member inline DisclosureContent ( props : IDisclosureContentProp list ) = JSX.createElement DisclosureContent props
    static member inline DisclosureContent ( children : ReactElement list ) = JSX.createElement DisclosureContent [ prop.children children[0] ]
    