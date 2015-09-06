module root

open canopy
open canopyExtensions
open runner
open common
open page_root

let smoke () =

  once (fun _ -> goto page_root.url)

  "header" &&& fun _ ->
    displayed "F# Suave Music Store"

  "title is correct" &&& fun _ ->
    title() === "Suave Music Store"

  "all categories present" &&& fun _ ->
    categories *=*
    [
      "Rock"
      "Jazz"
      "Metal"
      "Alternative"
      "Disco"
      "Blues"
      "Latin"
      "Reggae"
      "Pop"
      "Classical"
    ]

  "fresh off the grill" &&& fun _ ->
    freshOffTheGrill *=*
    [
      "Ace Of Spades"
      "For Those About To Rock We Salute You"
    ]

  "logon link displayed" &&& fun _ ->
    displayed "Log on"

  "links" &&& fun _ ->
    links *=*
    [
      "Home"
      "Store"
      "Cart (0)"
      "Admin"
    ]

let all () =
  smoke ()
