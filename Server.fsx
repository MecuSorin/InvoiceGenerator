#load @"../paket-files/include-scripts/net461/include.main.group.fsx"
#load "HtmlHelpers.fsx"
#load "GenerateInvoice.fsx"

open System
open Suave
open Suave.Authentication
open Suave.Cookie
open Suave.Filters
open Suave.Form
open Suave.Model.Binding
open Suave.Operators
open Suave.RequestErrors
open Suave.State.CookieStateStore
open Suave.Successful
open Suave.Html
open HtmlHelpers
open GenerateInvoice


let invoiceInfo = {
    Date = DateTime.Today
    Number = "003"
    Serie = "RS"
    HoursWorked = 8 * 1 
    Rate = 1
    Period = "February 2017"
    Details = [ ""]
}

let webPart =
    choose [ 
        Filters.GET >=> choose 
            [
                path "/" >=> (OK "Home")
                path "/invoice" >=> (OK (invoice invoiceInfo|> htmlToString ))
                pathRegex "(.*)\.(css|png)" >=> Files.browseHome
            ]
        RequestErrors.NOT_FOUND "Page not found."  
    ]
let invoiceUrl = defaultConfig.bindings.Head.ToString() + "/invoice"
printf "Invoice url is: %s" invoiceUrl
System.Diagnostics.Process.Start(invoiceUrl)

startWebServer { defaultConfig with homeFolder = Some __SOURCE_DIRECTORY__ } webPart
