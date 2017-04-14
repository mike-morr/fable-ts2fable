module Aesop.JsonParser

open Fable.Core

type JsonType =
    | String of string
    | Number of float
    | Object of array<string * JsonType>
    | Array of array<JsonType>
    | Boolean of bool
    | Null

    
// TODO implement this in F# rather than the FFI
[<Import("ofString", "./Json.js")>]
let private _ofString:
    (string -> JsonType) ->
    (float -> JsonType) ->
    (array<string * JsonType> -> JsonType) ->
    (array<JsonType> -> JsonType) ->
    (bool -> JsonType) ->
    JsonType ->
    (JsonType -> Result<JsonType, System.Exception>) ->
    (System.Exception -> Result<JsonType, System.Exception>) ->
    (string -> Result<JsonType, System.Exception>) = jsNative

let ofString: string -> Result<JsonType, System.Exception> = _ofString String Number Object Array Boolean Null Ok Error