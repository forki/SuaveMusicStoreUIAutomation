module page_logon

open canopy
open canopyExtensions
open common

//url
let url = rootUrl + "/account/logon"

//selectors
let username = "input[name='Username']"
let password = "input[name='Password']"

//helpers
let login user =
  let login username' password' =
    goto url
    username << username'
    password << password'
    click "Log On"
    displayed "Log off"

  match user with
    | Admin -> login "admin" "admin"
    | Test -> login "test" "testtest"
