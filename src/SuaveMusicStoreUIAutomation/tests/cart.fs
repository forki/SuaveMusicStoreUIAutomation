module cart

open canopy
open canopyExtensions
open runner
open common
open page_cart
open page_logon

let smoke () =
  context "Smoke: cart"

  once (fun _ -> goto page_cart.url)

  "cart should default to empty" &&& fun _ ->
    displayed "Cart (0)"
    displayed "Your cart is empty"

  "adding album increments cart to 1" &&& fun _ ->
    click "Rock"
    click "For Those About To Rock We Salute You"
    click "Add to cart"

    on page_cart.url
    displayed "Cart (1)"
    displayed "Review your cart:"

    for' "Album Name" == "For Those About To Rock We Salute You"
    for' "Price" == "8.99"
    for' "Count" == "1"
    for' "Total" == "8.99"

    //add another and total increments
    click "Metal"
    click "Ace Of Spades"
    click "Add to cart"

    displayed "Cart (2)"
    for' "Total" == "17.98"

  "cart survives logging in" &&& fun _ ->
    login Test
    displayed "Cart (2)"

    goto page_cart.url
    for' "Total" == "17.98"

    click "Log off"

    login Test
    displayed "Cart (2)"

    goto page_cart.url
    for' "Total" == "17.98"

  "remove from cart" &&& fun _ ->
    click "Remove from cart"
    displayed "Cart (0)"
    reload()

    displayed "Cart (0)"

let all () =
  smoke ()
