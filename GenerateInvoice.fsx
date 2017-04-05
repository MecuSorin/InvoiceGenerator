#load @"../paket-files/include-scripts/net461/include.main.group.fsx"
#load "HtmlHelpers.fsx"

open System
open Suave
open Suave.Html
open HtmlHelpers

type Invoice = {
    Date: DateTime
    Number: string
    Serie: string
    HoursWorked: int
    Rate: int
    Period: string
    Details: string list
}

let mecuSorinPFA = [ 
    Text "MECU Mihai-Sorin PFA"
    table_ ["class", "entity"] [
        trWithTDPair "CUI:" ""
        trWithTDPair "Reg. Com.:" ""
        trWithTDPair "Address:" "Romania, Jud. Valcea, Loc. Rm. Valcea"
        trWithTDPair "" ""
        trWithTDPair "Phone:" "0040-747-02-01-02"
        trWithTDPair "E-mail:" ""
//        trWithTDPair "Bank name:" "ING Bank N.V. Amsterdam, Sucursala Bucuresti"
//        trWithTDPair "SWIFT Code:" "INGBROBU"
//        trWithTDPair "IBAN Code:" ""
    ]
]

let realtyShares = [
    Text "RealtyShares, Inc., a Delaware corporation"
    table_ ["class", "entity"; "style", "float:right;"] [
        trWithTDPair "Address:" "US, San Francisco, CA 94107"
        trWithTDPair "" "501 2nd St, 7th Floor"
        trWithTDPair "Phone:" "1-855-880-6050 (toll free)"
        trWithTDPair "E-mail:" "contact@realtyshares.com"
    ]
]


let newInvoice info = 
    divClass "invoice-box" [
        table_ ["cellpadding", "0"; "cellspacing", "0"] [
            trClass "top" [
                td_ ["colspan", "2"] [
                    table [
                        tr [
                            tdClass "title" [ Text "INVOICE"]
                                //<img src="/images/logo.png" style="width:100%; max-width:300px;">
                            td [
                                table_ ["class", "invoice"] [
                                    trWithTDPair "Invoice #:" (sprintf "%s%s" info.Serie info.Number)
                                    trWithTDPair "Date:" (info.Date.ToString("MMM dd, yyyy"))
                                ]
                            ]
                        ]
                    ]
                ]
            ]
            trClass "heading" [
                td [ Text "CONSULTANT" ]
                td [ Text "BILL TO" ]
            ]
            trClass "information" [
                td_ ["colspan", "2"] [
                    table [
                        tr [
                            td mecuSorinPFA
                            td realtyShares
                        ]
                    ]
                ]
            ]
            trClass "heading" [
                td [ Text "Bank Account" ]
                td [ Text "Payment Method" ]
            ]
            trClass "details" [
                td [     
                    table_ ["class", "entity"] [
                        trWithTDPair "Bank name:" "ING Bank N.V. Amsterdam, Sucursala Bucuresti"
                        trWithTDPair "SWIFT Code:" "INGBROBU"
                        trWithTDPair "IBAN Code:" ""]
                ]
                td [ Text "Bank Transfer"]
            ]
        ]
        table_ ["cellpadding", "0"; "cellspacing", "0"; "class", "invoice-items"] [
            trClass "heading" [
                td [ Text "Item"]
                td [ Text "Quantity"]
                td [ Text "Rate"]
                td [ Text "Price"]
            ]
            trClass "item" [
                td [ Text (sprintf "Consulting services in %s" info.Period)]
                td [ Text (sprintf "%i" info.HoursWorked)]
                td [ Text (sprintf "$%i.00" info.Rate)]
                td [ Text (sprintf "$%i.00" (info.Rate * info.HoursWorked))]
            ]
            trClass "total" [
                td []
                td_ ["ColSpan", "3"] [ Text (sprintf "Total: $%i.00" (info.Rate * info.HoursWorked))]
            ]
        ]

        br []
        Text "Note: This invoice is based on the consulting agreement signed in December 09, 2016."
        br []
        br []
        br []
        
        table [
            tr [
                td [ Text "Consultant:"]
                td [ Text "Company:"]
            ]
            tr [
                td [ Text "Mecu Mihai-Sorin"]
                td [ Text "REALTYSHARES, INC., a Delaware corporation "]
            ]
        ]
        br []
        br []

    ]


let invoice (info: Invoice) =
    html [] [
        head [] [
            title [] "Mecu Mihai-Sorin"
            linkCSS "style.css"
        ]

        body [] [
            newInvoice info
        ]
    ]
