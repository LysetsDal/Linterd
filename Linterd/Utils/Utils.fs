// ================================================
//        UTILITY FUNCTIONS FOR LIMNTERD 
// ================================================

module Utils

// Trim multiple following spaces into one space
let trimWhitespace str =
    let rec aux str acc =
        match str with
        | [] -> List.rev acc
        | ' ' :: (' ' :: _ as tail) -> aux tail acc
        | ' ' :: rest -> aux rest (' ' :: acc)
        | char :: rest -> aux rest (char :: acc)
    aux (List.ofSeq str) []
    |> List.ofSeq
    |> List.map string
    |> String.concat ""

let reconstructToString (lst: string list) =
    (String.concat " " lst).Trim()

let reconstructToShellCmd (lst: string list) =
    (String.concat " && " lst).Trim()
    

// Used to split a string (envVar) at the '=' (equal)
open System.Text.RegularExpressions
let splitEnvVar input =
    let pattern = @"(?<!\\)=" // match un-escaped '=' sign
    Regex.Split(input, pattern)
    |> List.ofArray


// Used to split a string (path) at the ' ' (spaces)
let splitAtSpaces input =
    let pattern = @"(?<!\\) " // Match spaces not preceded by a backslash
    Regex.Split(input, pattern)
    |> List.ofArray

// Split list of strings at spaces
let splitListAtSpaces (input: string list) : string list list =
    List.fold (fun acc x -> splitAtSpaces x :: acc) [] input

// Split at delimiter(s)
let splitCmdAt (delim: string[]) (cmd: string) =
    List.ofArray (cmd.Split(delim, System.StringSplitOptions.RemoveEmptyEntries))


// Split a string with standard shell delimiters
// Used to split a multiline or '&& separate'
// shellcommand into single shellcommands
let split (cmd: string)  =
    let delims = [|"&&"; ";"; "<<"; ">>"|]
    splitCmdAt delims cmd
    |> List.map (fun (x:string) -> x.Trim(' '))


let splitList (input: string list) =
    let first_split = List.map (fun (s:string) -> s.Trim('[', ']')) input
    List.rev (splitListAtSpaces first_split)
        

// Construct a tuple of the first two elements of a list 
let returnPair lst = 
    match lst with
    | [] -> failwith "UTILS @ returnPair: Empty list provided (needs two)"
    | [_] -> failwith "UTILS @ returnPair: Only one path provided (needs two)"
    | x :: y :: _ -> (x, y)


// Return a Path (Copy-path) (from, to) from a string 
let stringToPath str =
    splitAtSpaces str
    |> returnPair


// Return a Key-Value pair (Key, Val) from a string
let stringToEnvPair str =
    splitEnvVar str
    |> returnPair
    

// Checks if a string is null or whitespace
let isNullOrWhiteSpace (str: string) =
    str = null || str.Trim() = ""


// Gat a command by a prefix (returns a list of mathces)
let getCmdByPrefix (lst: string list) (prefix: string) =    
    let rec aux (lst: string list) acc =
        match lst with
        | [] -> acc
        | x :: rest ->
            match x.StartsWith prefix with
            | true ->  aux rest (x :: acc)
            | _ ->  aux rest acc
    aux (List.rev lst) []
