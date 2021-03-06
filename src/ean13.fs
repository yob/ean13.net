module EAN13

open System

let sum (acc : int) (i : int) = acc + i

// If passed a 12 character string, calculates and returns a single
// character string containing an appropriate check digit. Returns
// Null otherwise
let calc_check_digit (code : string) =
    if code.Length <> 12 then
        null
    else
        let counter = [ 0; 1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11 ]
        let multipliers = [ 1; 3; 1; 3; 1; 3; 1; 3; 1; 3; 1; 3 ]
        let numbers = code.ToCharArray() |> Array.toList |> List.map( fun c -> int(c) - 48)
        let sum_num =
            counter
            |> List.map ( fun (i :int) -> numbers.[i] * multipliers.[i] )
            |> List.fold sum 0
        let mod_num = sum_num % 10
        if mod_num = 0 then
            Convert.ToString(mod_num)
        else
            Convert.ToString(10 - mod_num)

// take a 12 character string and add an ean13 check digit to it.
// Returns a 13 character string if passed a 12 character string,
// otherwise returns the original value unchanged
let complete (code : string) =
    if code.Length <> 12 then
        code
    else
        code + calc_check_digit(code)

// returns true if passed a 13 character string that is a valid EAN13, otherwise
// returns false
//
let valid (code : string) =
    if code.Length = 13 && code = complete(code.Substring(0,12)) then
        true
    else
        false

// returns true if the provided EAN13 is valid and from bookland
//
let bookland(code : string) =
    if valid(code) && ( code.Substring(0,3) = "978" || code.Substring(0,3) = "979" ) then
        true
    else
        false

// convert the provided EAN13 to a UPC if possible. Returns null if there is no
// way to complete the conversion
let to_upc(code : string) =
    if valid(code) && code.Substring(0,1) = "0" then
        code.Substring(1,12)
    else
        null
