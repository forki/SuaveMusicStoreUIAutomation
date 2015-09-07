module admin

open canopy
open canopyExtensions
open runner
open common
open page_logon
open page_admin

let smoke () =
  context "Smoke: admin"

  once (fun _ ->
        login Admin
        click "Admin")

  "create new" &&& fun _ ->
    click "Create New"

    genre << "Metal"
    artist << "Alanis Morissette"
    title << "Automation Metal Melody"
    price << "13.99"

    click "Create"

  "edit" &&& fun _ ->
    click <| edit "Automation Metal Melody"

    genre == "Metal"
    artist == "Alanis Morissette"
    title == "Automation Metal Melody"
    price == "13.99"
    price << "14.99"

    click "Save Changes"

    click <| edit "Automation Metal Melody"
    price << "14.99"
    click "Back to list"

  "delete" &&& fun _ ->
    click <| delete "Automation Metal Melody"
    displayed "Delete Confirmation"
    click "Delete"

    on page_admin.url
    notDisplayed "Automation Metal Melody"

let all () =
  smoke ()
