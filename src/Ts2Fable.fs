module Aesop.Ts2Fable

open Aesop.JsonParser
open Fable.Core
open Fable.Import
open Fable.Core.JsInterop
let fs: Node.fs_types.Globals = importAll "fs"

let rec getJson (name: string) =
    match ofString (fs.readFileSync(name, "utf8") |> string) with
    | Ok(json) -> json
    | Error(e) -> raise e

let rec generateTypes j =
    match getJson "chalk.json" with 
    | Object(a) -> 
        let map = Map.ofArray a 
        match Map.find "children" map with
        | v -> generateTypes v; printfn "%A" v 
    | _ -> printfn "%A" "not supported yet"
