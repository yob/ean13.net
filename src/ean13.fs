(*
Mega Hello World:
Take two command line parameters and then print
them along with the current time to the console.
*)
open System

[<EntryPoint>]
let main (args : string[]) =
    if args.Length <> 1 then
        failwith "Error: Expected arguments <code>"
    let code = args.[0]
    let timeOfDay = DateTime.Now.ToString("hh:mm tt")
    printfn "%s at %s" code timeOfDay
    // Program exit code
    0
