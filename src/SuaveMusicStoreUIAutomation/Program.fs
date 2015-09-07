module program

open canopy
open runner
open types

canopy.configuration.autoPinBrowserRightOnLaunch <- false
canopy.configuration.compareTimeout <- 2.0
canopy.configuration.elementTimeout <- 2.0
canopy.configuration.pageTimeout <- 2.0

start firefox

//setup tests
root.all()
genres.all()
detail.all()

run()

System.Console.ReadLine() |> ignore

quit()
