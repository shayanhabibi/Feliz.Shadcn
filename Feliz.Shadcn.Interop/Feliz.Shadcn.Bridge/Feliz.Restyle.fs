namespace Feliz.Shadcn.Interop

open Fable.Core

// This allows us to constrain general props from being used in some components
/// Special access token which uses the compiler to determine if you can use general props
/// and also allows us to <c>.</c> through the special defined properties of our components.
///
/// By preventing the name collision with Feliz <c>prop</c>, the compiler can infer the generic
/// type and produce the correct result.
type [<Erase>] props<'T when 'T : (static member propsInterface : unit)> = prop<'T>