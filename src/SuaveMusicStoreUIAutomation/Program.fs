module program

open canopy
open runner
open types
open configuration
open reporters

compareTimeout <- 2.0
elementTimeout <- 2.0
pageTimeout <- 2.0

start firefox
pin FullScreen

//setup tests
root.all()
genres.all()
detail.all()
cart.all()
admin.all()

run()

System.Console.ReadLine() |> ignore

quit()
