module Aesop.Ts2Fable
#if INTERACTIVE

#endif
open Fable.Core
open Fable.Core.JsInterop
open Aesop.JsonParser
open Fable.Import.Node
let fs: fs_types.Globals = importAll "fs"

let fileContents name =
  fs.readFileSync name
  |> string
  |> ofJsonWithTypeInfo

let json =
  match fileContents "../json.js" with
    | ofString 

