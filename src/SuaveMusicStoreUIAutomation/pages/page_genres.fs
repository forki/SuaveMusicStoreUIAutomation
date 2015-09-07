module page_genres

open canopy
open common

//selectors

//helpers
let validate genre albums =
  click genre
  displayed <| sprintf "Genre: %s" genre
  albums |> List.iter (fun album -> displayed album)
