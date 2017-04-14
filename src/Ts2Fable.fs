module Aesop.Ts2Fable

open Aesop.JsonParser
open Fable.Core
open Fable.Import.Node

let getJson name =
  match ofString (fs.readFileSync name |> string) with
    | Ok(json) -> json
    | Error(e) -> raise e

printfn "%A" (getJson "../foo.json")