
module Aesop.Json

open Fable.Core

type Json =
  | String of string
  | Number of float
  | Object of array<string * Json>
  | Array of array<Json>
  | Boolean of bool
  | Null

[<Import("ofString", "./json.js")>]
let private _ofString:
  (string -> Json) ->
  (float -> Json) ->
  (array<string * Json> -> Json) ->
  (array<Json> -> Json) ->
  (bool -> Json) ->
  Json ->
  (Json -> option<Json>) ->
  option<Json> ->
  (string -> option<Json>) = jsNative

let ofString: string -> option<Json> = _ofString String Number Object Array Boolean Null Some None