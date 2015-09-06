module program

open canopy
open runner

start firefox

url "http://www.google.com"

System.Console.ReadLine() |> ignore

quit()