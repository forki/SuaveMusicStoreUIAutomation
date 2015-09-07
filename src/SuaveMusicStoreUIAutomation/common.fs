module common

//url
let rootUrl = "http://127.0.0.1:8083"

//types
type User =
  | Admin
  | Test

//helpers
let for' value = sprintf "[data-uia-for='%s']" value
