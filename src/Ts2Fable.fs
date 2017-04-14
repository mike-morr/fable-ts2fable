module Aesop.Ts2Fable

open Aesop.JsonParser
open Fable.Core
open Fable.Import
open Fable.Core.JsInterop
let fs: Node.fs_types.Globals = importAll "fs"
let getJson name =
  match ofString (fs.readFileSync name |> string) with
    | Ok(json) -> json
    | Error(e) -> raise e

printfn "%A" (getJson ".chalk.json")