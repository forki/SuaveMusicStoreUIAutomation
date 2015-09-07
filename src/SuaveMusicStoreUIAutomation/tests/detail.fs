module detail

open canopy
open canopyExtensions
open runner
open common
open page_details

let smoke () =
  context "Smoke: detail"

  once (fun _ -> goto page_root.url)

  "details has information about an album" &&& fun _ ->
    click "Rock"

    click "For Those About To Rock We Salute You"

    for' "Genre:" == "Rock"
    for' "Artist:" == "AC/DC"
    for' "Price:" == "8.99"

    displayed "For Those About To Rock We Salute You"
    displayed "Add to cart"

let all () =
  smoke ()
