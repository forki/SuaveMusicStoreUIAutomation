module root

open canopy
open canopyExtensions
open runner
open common
open page_root

let smoke () =

  before (fun _ -> goto page_root.url)

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

  "" &&& fun _ ->
    ()

  "" &&& fun _ ->
    ()

  "" &&& fun _ ->
    ()

  "" &&& fun _ ->
    ()


let all () =
  smoke ()
