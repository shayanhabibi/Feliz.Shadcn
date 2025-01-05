# Shadcn Recipes

Components might be passed hidden attributes in their implementations. These might require spreading on use which isn't captured inherently by Fable because all the parameters of our functions are passed through to a an object for field access by the parameter name.

```fsharp
let Component ( argi : 'a ) = ... // all usage of argi would be transpiled
                                  // to `$props.argi` in JS
```

On the flip side, the creation of an object from this field to be accessible on the JS side would fail if our argument is something like an empty list.

```fsharp
let Component ( props : 'a list) =
    ...
    let properties = !!props |> createObj // can fail
    ...
    let properties =
        match props with
        | [] -> createEmpty // will still fail because if the field is empty
                            // then js will fail to run isEmpty on the field
        | _ -> !!props |> createObj
    ...
    let properties =
        match unbox props with
        | null -> createEmpty // works
        | _ -> !!props |> createObj
```

When buildings JSX, there might be fields we want to redistribute. This can be done by hand with emitJsStatement and is the best method I've found so far. It is important that the above step is taken before trying to unpack the field

```fsharp
let Component ( props : 'a list ) =
    ...
    let properties =
        match unbox props with
        | null -> createEmpty
        | _ -> !!props |> createObj
    // captures all properties in our parameter, but unpacks className
    // Ensure the capture field is not named the same as our parameter
    emitJsStatement properties = "const { className , ...sprops } = $0"
    // The above could potentially miss hidden attributes passed to the component
    // The above assumes that ALL of the properties are contained within the
    // parameter field `props` (in this case, it reflects the name of the parameter).
    // We can capture any such hidden arguments/attributes by unpacking the name of
    // our argument from the transpiled argument container which is $props
    emitJsStatement () = "const { props, ...attrs } = $props" // would fail if
                                            // our capture field above was same name
                                            // as this field
    ...
// for example, if we have our component defined with the following
let Component ( argument : 'a list ) ( potato : 'b list ) =
    ...
    // Then we would want to unpack the arguments to spread any other attrs
    emitJsStatement () = " const { argument, potato, ...attrs } = $props "
```