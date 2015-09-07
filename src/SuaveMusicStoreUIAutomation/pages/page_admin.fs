module page_admin

open canopy
open common

//urls
let url = rootUrl + "/admin/manage"

//selectors
let genre = "select[name='GenreId']"
let artist = "select[name='ArtistId']"
let title = "input[name='Title']"
let price = "input[name='Price']"
let edit album = sprintf "//td[text()='%s']/..//a[text()='Edit']" album
let delete album = sprintf "//td[text()='%s']/..//a[text()='Delete']" album

//helpers
