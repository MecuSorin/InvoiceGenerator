#load @"../paket-files/include-scripts/net461/include.main.group.fsx"


open System
open Suave
open Suave.Html



let divId id = div ["id", id]
let divClass className = div [ "class", className]
let h1 = tag "h1" []
let h2 = tag "h2" []
let h3 = tag "h3" []
let aHref href = tag "a" ["href", href]
let table_ = tag "table"
let tr_ = tag "tr"
let td_ = tag "td"

let table = table_ []
let tr = tr_ []
let td = td_ []


let tdPair label value = [
    td (text label)
    td (text value)
]

let tdClass cls = td_ ["class", cls]
let trClass cls = tr_ ["class", cls]

let textRows listOfString = 
    listOfString
    |> List.collect (fun str -> [Text str; br[]])



let trWithTDPair label value = tr (tdPair label value)

let linkCSS path = link ["rel","stylesheet"; "type", "text/css"; "href", path]
