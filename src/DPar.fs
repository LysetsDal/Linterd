// Implementation file for parser generated by fsyacc
module DPar
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open FSharp.Text.Lexing
open FSharp.Text.Parsing.ParseHelpers
# 1 "DPar.fsy"

open Absyn

# 10 "DPar.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | COLON
  | DOT
  | LBRACK
  | RBRACK
  | EXPOSE
  | FSLASH
  | DASH
  | FROM
  | WORKDIR
  | USER
  | INT of (int)
  | NAME of (string)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_COLON
    | TOKEN_DOT
    | TOKEN_LBRACK
    | TOKEN_RBRACK
    | TOKEN_EXPOSE
    | TOKEN_FSLASH
    | TOKEN_DASH
    | TOKEN_FROM
    | TOKEN_WORKDIR
    | TOKEN_USER
    | TOKEN_INT
    | TOKEN_NAME
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startMain
    | NONTERM_Main
    | NONTERM_File
    | NONTERM_BaseImg
    | NONTERM_Instrs
    | NONTERM_Instr
    | NONTERM_User
    | NONTERM_Version
    | NONTERM_MinorVersion
    | NONTERM_DashedName
    | NONTERM_Path
    | NONTERM_Dirs

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | COLON  -> 1 
  | DOT  -> 2 
  | LBRACK  -> 3 
  | RBRACK  -> 4 
  | EXPOSE  -> 5 
  | FSLASH  -> 6 
  | DASH  -> 7 
  | FROM  -> 8 
  | WORKDIR  -> 9 
  | USER  -> 10 
  | INT _ -> 11 
  | NAME _ -> 12 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_COLON 
  | 2 -> TOKEN_DOT 
  | 3 -> TOKEN_LBRACK 
  | 4 -> TOKEN_RBRACK 
  | 5 -> TOKEN_EXPOSE 
  | 6 -> TOKEN_FSLASH 
  | 7 -> TOKEN_DASH 
  | 8 -> TOKEN_FROM 
  | 9 -> TOKEN_WORKDIR 
  | 10 -> TOKEN_USER 
  | 11 -> TOKEN_INT 
  | 12 -> TOKEN_NAME 
  | 15 -> TOKEN_end_of_input
  | 13 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startMain 
    | 1 -> NONTERM_Main 
    | 2 -> NONTERM_File 
    | 3 -> NONTERM_File 
    | 4 -> NONTERM_BaseImg 
    | 5 -> NONTERM_Instrs 
    | 6 -> NONTERM_Instrs 
    | 7 -> NONTERM_Instr 
    | 8 -> NONTERM_Instr 
    | 9 -> NONTERM_Instr 
    | 10 -> NONTERM_Instr 
    | 11 -> NONTERM_Instr 
    | 12 -> NONTERM_Instr 
    | 13 -> NONTERM_User 
    | 14 -> NONTERM_User 
    | 15 -> NONTERM_Version 
    | 16 -> NONTERM_Version 
    | 17 -> NONTERM_Version 
    | 18 -> NONTERM_Version 
    | 19 -> NONTERM_Version 
    | 20 -> NONTERM_MinorVersion 
    | 21 -> NONTERM_MinorVersion 
    | 22 -> NONTERM_DashedName 
    | 23 -> NONTERM_DashedName 
    | 24 -> NONTERM_DashedName 
    | 25 -> NONTERM_DashedName 
    | 26 -> NONTERM_Path 
    | 27 -> NONTERM_Dirs 
    | 28 -> NONTERM_Dirs 
    | 29 -> NONTERM_Dirs 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 15 
let _fsyacc_tagOfErrorTerminal = 13

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | COLON  -> "COLON" 
  | DOT  -> "DOT" 
  | LBRACK  -> "LBRACK" 
  | RBRACK  -> "RBRACK" 
  | EXPOSE  -> "EXPOSE" 
  | FSLASH  -> "FSLASH" 
  | DASH  -> "DASH" 
  | FROM  -> "FROM" 
  | WORKDIR  -> "WORKDIR" 
  | USER  -> "USER" 
  | INT _ -> "INT" 
  | NAME _ -> "NAME" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | COLON  -> (null : System.Object) 
  | DOT  -> (null : System.Object) 
  | LBRACK  -> (null : System.Object) 
  | RBRACK  -> (null : System.Object) 
  | EXPOSE  -> (null : System.Object) 
  | FSLASH  -> (null : System.Object) 
  | DASH  -> (null : System.Object) 
  | FROM  -> (null : System.Object) 
  | WORKDIR  -> (null : System.Object) 
  | USER  -> (null : System.Object) 
  | INT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | NAME _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 1us; 65535us; 0us; 2us; 1us; 65535us; 0us; 4us; 2us; 65535us; 4us; 5us; 10us; 11us; 2us; 65535us; 4us; 10us; 10us; 10us; 1us; 65535us; 23us; 24us; 1us; 65535us; 8us; 9us; 3us; 65535us; 28us; 29us; 33us; 34us; 37us; 38us; 3us; 65535us; 28us; 30us; 29us; 31us; 36us; 39us; 1us; 65535us; 17us; 18us; 2us; 65535us; 17us; 40us; 43us; 44us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; 5us; 7us; 10us; 13us; 15us; 17us; 21us; 25us; 27us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 1us; 1us; 1us; 1us; 2us; 2us; 3us; 1us; 3us; 1us; 4us; 1us; 4us; 1us; 4us; 1us; 4us; 2us; 5us; 6us; 1us; 6us; 1us; 7us; 1us; 8us; 1us; 8us; 1us; 8us; 1us; 8us; 1us; 9us; 1us; 9us; 2us; 10us; 11us; 2us; 10us; 11us; 1us; 11us; 1us; 11us; 1us; 12us; 1us; 12us; 2us; 13us; 14us; 1us; 14us; 1us; 15us; 4us; 16us; 17us; 18us; 19us; 2us; 17us; 19us; 1us; 18us; 1us; 19us; 2us; 20us; 21us; 2us; 20us; 21us; 1us; 21us; 4us; 22us; 23us; 24us; 25us; 2us; 22us; 25us; 2us; 23us; 24us; 1us; 24us; 1us; 25us; 1us; 26us; 4us; 27us; 28us; 28us; 29us; 3us; 27us; 28us; 29us; 3us; 27us; 28us; 29us; 1us; 29us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 6us; 8us; 11us; 13us; 15us; 17us; 19us; 21us; 24us; 26us; 28us; 30us; 32us; 34us; 36us; 38us; 40us; 43us; 46us; 48us; 50us; 52us; 54us; 57us; 59us; 61us; 66us; 69us; 71us; 73us; 76us; 79us; 81us; 86us; 89us; 92us; 94us; 96us; 98us; 103us; 107us; 111us; |]
let _fsyacc_action_rows = 45
let _fsyacc_actionTableElements = [|1us; 32768us; 8us; 6us; 0us; 49152us; 1us; 32768us; 0us; 3us; 0us; 16385us; 5us; 16386us; 5us; 19us; 8us; 13us; 9us; 17us; 10us; 23us; 12us; 12us; 0us; 16387us; 1us; 32768us; 12us; 7us; 1us; 32768us; 1us; 8us; 2us; 32768us; 11us; 28us; 12us; 27us; 0us; 16388us; 5us; 16389us; 5us; 19us; 8us; 13us; 9us; 17us; 10us; 23us; 12us; 12us; 0us; 16390us; 0us; 16391us; 1us; 32768us; 12us; 14us; 1us; 32768us; 1us; 15us; 1us; 32768us; 12us; 16us; 0us; 16392us; 1us; 32768us; 6us; 42us; 0us; 16393us; 1us; 32768us; 11us; 20us; 1us; 16394us; 1us; 21us; 1us; 32768us; 11us; 22us; 0us; 16395us; 1us; 32768us; 12us; 25us; 0us; 16396us; 1us; 16397us; 11us; 26us; 0us; 16398us; 0us; 16399us; 2us; 16400us; 2us; 32us; 7us; 35us; 1us; 16401us; 7us; 35us; 0us; 16402us; 0us; 16403us; 1us; 32768us; 11us; 33us; 1us; 16404us; 2us; 32us; 0us; 16405us; 2us; 32768us; 11us; 37us; 12us; 36us; 1us; 16406us; 7us; 35us; 1us; 16407us; 2us; 32us; 0us; 16408us; 0us; 16409us; 0us; 16410us; 1us; 16412us; 12us; 43us; 1us; 32768us; 12us; 43us; 1us; 16411us; 6us; 41us; 0us; 16413us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 2us; 3us; 5us; 6us; 12us; 13us; 15us; 17us; 20us; 21us; 27us; 28us; 29us; 31us; 33us; 35us; 36us; 38us; 39us; 41us; 43us; 45us; 46us; 48us; 49us; 51us; 52us; 53us; 56us; 58us; 59us; 60us; 62us; 64us; 65us; 68us; 70us; 72us; 73us; 74us; 75us; 77us; 79us; 81us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 2us; 1us; 2us; 4us; 1us; 2us; 1us; 4us; 2us; 2us; 4us; 2us; 1us; 2us; 1us; 1us; 2us; 2us; 3us; 2us; 3us; 2us; 2us; 3us; 3us; 1us; 2us; 3us; 3us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 2us; 2us; 3us; 4us; 4us; 5us; 5us; 5us; 5us; 5us; 5us; 6us; 6us; 7us; 7us; 7us; 7us; 7us; 8us; 8us; 9us; 9us; 9us; 9us; 10us; 11us; 11us; 11us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 65535us; 16385us; 65535us; 16387us; 65535us; 65535us; 65535us; 16388us; 65535us; 16390us; 16391us; 65535us; 65535us; 65535us; 16392us; 65535us; 16393us; 65535us; 65535us; 65535us; 16395us; 65535us; 16396us; 65535us; 16398us; 16399us; 65535us; 65535us; 16402us; 16403us; 65535us; 65535us; 16405us; 65535us; 65535us; 65535us; 16408us; 16409us; 16410us; 65535us; 65535us; 65535us; 16413us; |]
let _fsyacc_reductions ()  =    [| 
# 177 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.dockerfile)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startMain));
# 186 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'File)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 29 "DPar.fsy"
                                                         DFile _1 
                   )
# 29 "DPar.fsy"
                 : Absyn.dockerfile));
# 197 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'BaseImg)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 34 "DPar.fsy"
                                                         [_1]      
                   )
# 34 "DPar.fsy"
                 : 'File));
# 208 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'BaseImg)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Instrs)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 35 "DPar.fsy"
                                                         _1 :: _2  
                   )
# 35 "DPar.fsy"
                 : 'File));
# 220 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : 'Version)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 39 "DPar.fsy"
                                                         BaseImage(_2, Tag _4) 
                   )
# 39 "DPar.fsy"
                 : 'BaseImg));
# 232 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Instr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 43 "DPar.fsy"
                                                         [_1]        
                   )
# 43 "DPar.fsy"
                 : 'Instrs));
# 243 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Instr)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Instrs)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 44 "DPar.fsy"
                                                         _1 :: _2    
                   )
# 44 "DPar.fsy"
                 : 'Instrs));
# 255 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 48 "DPar.fsy"
                                                         Var(_1)                   
                   )
# 48 "DPar.fsy"
                 : 'Instr));
# 266 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 49 "DPar.fsy"
                                                         BaseImage(_2, Tag(_4))    
                   )
# 49 "DPar.fsy"
                 : 'Instr));
# 278 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Path)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 50 "DPar.fsy"
                                                         Workdir(_2)               
                   )
# 50 "DPar.fsy"
                 : 'Instr));
# 289 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 51 "DPar.fsy"
                                                         Expose(_2)                
                   )
# 51 "DPar.fsy"
                 : 'Instr));
# 300 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 52 "DPar.fsy"
                                                         Expose2(_2, _4)           
                   )
# 52 "DPar.fsy"
                 : 'Instr));
# 312 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'User)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 53 "DPar.fsy"
                                                         User(_2)                  
                   )
# 53 "DPar.fsy"
                 : 'Instr));
# 323 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 58 "DPar.fsy"
                                                         (_1, None)                
                   )
# 58 "DPar.fsy"
                 : 'User));
# 334 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 59 "DPar.fsy"
                                                         (_1, Some(_2))            
                   )
# 59 "DPar.fsy"
                 : 'User));
# 346 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 63 "DPar.fsy"
                                                         _1                              
                   )
# 63 "DPar.fsy"
                 : 'Version));
# 357 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 64 "DPar.fsy"
                                                         string _1                       
                   )
# 64 "DPar.fsy"
                 : 'Version));
# 368 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'MinorVersion)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 65 "DPar.fsy"
                                                         string _1 + "." + _2            
                   )
# 65 "DPar.fsy"
                 : 'Version));
# 380 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'DashedName)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 66 "DPar.fsy"
                                                         string _1 + "-" + _2            
                   )
# 66 "DPar.fsy"
                 : 'Version));
# 392 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'MinorVersion)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'DashedName)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 67 "DPar.fsy"
                                                         string _1 + "." + _2 + "-" + _3 
                   )
# 67 "DPar.fsy"
                 : 'Version));
# 405 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 72 "DPar.fsy"
                                                         string _2             
                   )
# 72 "DPar.fsy"
                 : 'MinorVersion));
# 416 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'MinorVersion)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 73 "DPar.fsy"
                                                         string _2 + "." + _3  
                   )
# 73 "DPar.fsy"
                 : 'MinorVersion));
# 428 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 78 "DPar.fsy"
                                                         string _2               
                   )
# 78 "DPar.fsy"
                 : 'DashedName));
# 439 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 79 "DPar.fsy"
                                                         string _2               
                   )
# 79 "DPar.fsy"
                 : 'DashedName));
# 450 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'MinorVersion)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 80 "DPar.fsy"
                                                         string _2 + "." + _3    
                   )
# 80 "DPar.fsy"
                 : 'DashedName));
# 462 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'DashedName)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 81 "DPar.fsy"
                                                         string _2 + "-" + _3    
                   )
# 81 "DPar.fsy"
                 : 'DashedName));
# 474 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Dirs)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 86 "DPar.fsy"
                                                          Dirs(_1) 
                   )
# 86 "DPar.fsy"
                 : 'Path));
# 485 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 90 "DPar.fsy"
                                                          [(Dir _2)]      
                   )
# 90 "DPar.fsy"
                 : 'Dirs));
# 496 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 91 "DPar.fsy"
                                                          [(Dir _2)]      
                   )
# 91 "DPar.fsy"
                 : 'Dirs));
# 507 "DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'Dirs)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 92 "DPar.fsy"
                                                          Dir _2 :: _3    
                   )
# 92 "DPar.fsy"
                 : 'Dirs));
|]
# 520 "DPar.fs"
let tables () : FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 16;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = (tables ()).Interpret(lexer, lexbuf, startState)
let Main lexer lexbuf : Absyn.dockerfile =
    Microsoft.FSharp.Core.Operators.unbox ((tables ()).Interpret(lexer, lexbuf, 0))
