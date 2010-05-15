(*
Mega Hello World:
Take two command line parameters and then print
them along with the current time to the console.
*)
open System

let ean13_valid (code : string) =
    if code.Length = 13 then
        true
    else
        false

[<EntryPoint>]
let main (args : string[]) =
    if args.Length <> 1 then
        failwith "Error: Expected arguments <code>"
    let code = args.[0]
    let valid = ean13_valid(code)
    printfn "%s is %b" code valid
    // Program exit code
    0
