module genres

open canopy
open canopyExtensions
open runner
open common
open page_genres

let smoke () =
  context "Smoke: genres"

  once (fun _ -> goto page_root.url)

  "rock" &&& fun _ ->
    validate "Rock" ["For Those About To Rock We Salute You"; "Let There Be Rock"]

  "jazz" &&& fun _ ->
    validate "Jazz" ["The Best Of Billy Cobham"; "Quiet Songs"]

  "metal" &&& fun _ ->
    validate "Metal" ["Ace Of Spades"; "Motley Crue Greatest Hits"]

  "alternative" &&& fun _ ->
    validate "Alternative" ["Cake: B-Sides and Rarities"; "Temple of the Dog"]

  "disco" &&& fun _ ->
    validate "Disco" ["Le Freak"; "MacArthur Park Suite"]

  "blues" &&& fun _ ->
    validate "Blues" ["In Step"; "The Cream Of Clapton"]

  "latin" &&& fun _ ->
    validate "Latin" ["Barulhinho Bom"; "Olodum"]

  "reggae" &&& fun _ ->
    validate "Reggae" ["UB40 The Best Of - Volume Two UK"; "Acústico MTV Live"]

  "pop" &&& fun _ ->
    validate "Pop" ["Axé Bahia 2001"; "Frank"]

  "classical" &&& fun _ ->
    validate "Classical" ["The Best of Beethoven"; "Bach: Goldberg Variations"]

let all () =
  smoke ()
