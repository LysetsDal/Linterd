// Implementation file for parser generated by fsyacc
module DPar
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open FSharp.Text.Lexing
open FSharp.Text.Parsing.ParseHelpers
# 4 "Parser/DPar.fsy"

open Absyn

let extract tup =
    (fst tup, snd tup)

let extract_last tup p = 
    (fst tup, p(snd tup))


# 17 "Parser/DPar.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | COLON
  | DOT
  | EXPOSE of (int)
  | DASH
  | COMMA
  | EQ
  | FROM of (int)
  | USER of (int)
  | INT of (int)
  | CPATH of (int * (string * string))
  | APATH of (int * (string * string))
  | ENVVAR of (int * (string * string))
  | NAME of (int * string)
  | MNTPT of (int * string)
  | WPATH of (int * string)
  | RCMD of (int * string)
  | ECMD of (int * string)
  | CSTST of (int * string)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_COLON
    | TOKEN_DOT
    | TOKEN_EXPOSE
    | TOKEN_DASH
    | TOKEN_COMMA
    | TOKEN_EQ
    | TOKEN_FROM
    | TOKEN_USER
    | TOKEN_INT
    | TOKEN_CPATH
    | TOKEN_APATH
    | TOKEN_ENVVAR
    | TOKEN_NAME
    | TOKEN_MNTPT
    | TOKEN_WPATH
    | TOKEN_RCMD
    | TOKEN_ECMD
    | TOKEN_CSTST
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
    | NONTERM_EnvVar
    | NONTERM_CPath
    | NONTERM_AddPath
    | NONTERM_Runcmd
    | NONTERM_Entrycmd
    | NONTERM_MntPt
    | NONTERM_WPath
    | NONTERM_Expose
    | NONTERM_Ports
    | NONTERM_User
    | NONTERM_Version
    | NONTERM_DottedName
    | NONTERM_DashedName

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | COLON  -> 1 
  | DOT  -> 2 
  | EXPOSE _ -> 3 
  | DASH  -> 4 
  | COMMA  -> 5 
  | EQ  -> 6 
  | FROM _ -> 7 
  | USER _ -> 8 
  | INT _ -> 9 
  | CPATH _ -> 10 
  | APATH _ -> 11 
  | ENVVAR _ -> 12 
  | NAME _ -> 13 
  | MNTPT _ -> 14 
  | WPATH _ -> 15 
  | RCMD _ -> 16 
  | ECMD _ -> 17 
  | CSTST _ -> 18 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_COLON 
  | 2 -> TOKEN_DOT 
  | 3 -> TOKEN_EXPOSE 
  | 4 -> TOKEN_DASH 
  | 5 -> TOKEN_COMMA 
  | 6 -> TOKEN_EQ 
  | 7 -> TOKEN_FROM 
  | 8 -> TOKEN_USER 
  | 9 -> TOKEN_INT 
  | 10 -> TOKEN_CPATH 
  | 11 -> TOKEN_APATH 
  | 12 -> TOKEN_ENVVAR 
  | 13 -> TOKEN_NAME 
  | 14 -> TOKEN_MNTPT 
  | 15 -> TOKEN_WPATH 
  | 16 -> TOKEN_RCMD 
  | 17 -> TOKEN_ECMD 
  | 18 -> TOKEN_CSTST 
  | 21 -> TOKEN_end_of_input
  | 19 -> TOKEN_error
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
    | 13 -> NONTERM_Instr 
    | 14 -> NONTERM_Instr 
    | 15 -> NONTERM_Instr 
    | 16 -> NONTERM_Instr 
    | 17 -> NONTERM_Instr 
    | 18 -> NONTERM_EnvVar 
    | 19 -> NONTERM_CPath 
    | 20 -> NONTERM_AddPath 
    | 21 -> NONTERM_Runcmd 
    | 22 -> NONTERM_Entrycmd 
    | 23 -> NONTERM_MntPt 
    | 24 -> NONTERM_WPath 
    | 25 -> NONTERM_Expose 
    | 26 -> NONTERM_Expose 
    | 27 -> NONTERM_Expose 
    | 28 -> NONTERM_Ports 
    | 29 -> NONTERM_Ports 
    | 30 -> NONTERM_User 
    | 31 -> NONTERM_User 
    | 32 -> NONTERM_User 
    | 33 -> NONTERM_User 
    | 34 -> NONTERM_Version 
    | 35 -> NONTERM_Version 
    | 36 -> NONTERM_Version 
    | 37 -> NONTERM_Version 
    | 38 -> NONTERM_Version 
    | 39 -> NONTERM_Version 
    | 40 -> NONTERM_Version 
    | 41 -> NONTERM_DottedName 
    | 42 -> NONTERM_DottedName 
    | 43 -> NONTERM_DashedName 
    | 44 -> NONTERM_DashedName 
    | 45 -> NONTERM_DashedName 
    | 46 -> NONTERM_DashedName 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 21 
let _fsyacc_tagOfErrorTerminal = 19

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | COLON  -> "COLON" 
  | DOT  -> "DOT" 
  | EXPOSE _ -> "EXPOSE" 
  | DASH  -> "DASH" 
  | COMMA  -> "COMMA" 
  | EQ  -> "EQ" 
  | FROM _ -> "FROM" 
  | USER _ -> "USER" 
  | INT _ -> "INT" 
  | CPATH _ -> "CPATH" 
  | APATH _ -> "APATH" 
  | ENVVAR _ -> "ENVVAR" 
  | NAME _ -> "NAME" 
  | MNTPT _ -> "MNTPT" 
  | WPATH _ -> "WPATH" 
  | RCMD _ -> "RCMD" 
  | ECMD _ -> "ECMD" 
  | CSTST _ -> "CSTST" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | COLON  -> (null : System.Object) 
  | DOT  -> (null : System.Object) 
  | EXPOSE _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | DASH  -> (null : System.Object) 
  | COMMA  -> (null : System.Object) 
  | EQ  -> (null : System.Object) 
  | FROM _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | USER _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | INT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | CPATH _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | APATH _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | ENVVAR _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | NAME _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | MNTPT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | WPATH _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | RCMD _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | ECMD _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | CSTST _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us;65535us;1us;65535us;0us;1us;1us;65535us;0us;2us;1us;65535us;0us;4us;2us;65535us;4us;5us;10us;11us;2us;65535us;4us;10us;10us;10us;2us;65535us;4us;27us;10us;27us;2us;65535us;4us;25us;10us;25us;2us;65535us;4us;26us;10us;26us;2us;65535us;4us;23us;10us;23us;2us;65535us;4us;24us;10us;24us;2us;65535us;4us;17us;10us;17us;2us;65535us;4us;22us;10us;22us;1us;65535us;18us;19us;2us;65535us;38us;39us;41us;42us;1us;65535us;20us;21us;2us;65535us;8us;9us;15us;16us;4us;65535us;48us;52us;49us;50us;56us;57us;60us;61us;4us;65535us;48us;53us;49us;51us;50us;54us;59us;62us;|]
let _fsyacc_sparseGotoTableRowOffsets = [|0us;1us;3us;5us;7us;10us;13us;16us;19us;22us;25us;28us;31us;34us;36us;39us;41us;44us;49us;|]
let _fsyacc_stateToProdIdxsTableElements = [| 1us;0us;1us;0us;1us;1us;1us;1us;2us;2us;3us;1us;3us;1us;4us;1us;4us;1us;4us;1us;4us;2us;5us;6us;1us;6us;1us;7us;1us;8us;1us;8us;1us;8us;1us;8us;1us;9us;1us;10us;1us;10us;1us;11us;1us;11us;1us;12us;1us;13us;1us;14us;1us;15us;1us;16us;1us;17us;1us;18us;1us;19us;1us;20us;1us;21us;1us;22us;1us;23us;1us;24us;3us;25us;26us;27us;1us;26us;1us;26us;1us;27us;1us;27us;2us;28us;29us;1us;29us;1us;29us;3us;30us;32us;33us;1us;31us;1us;32us;1us;33us;1us;33us;3us;34us;38us;39us;4us;35us;36us;37us;40us;2us;36us;40us;1us;37us;1us;38us;1us;39us;1us;40us;2us;41us;42us;2us;41us;42us;1us;42us;4us;43us;44us;45us;46us;2us;43us;46us;2us;44us;45us;1us;45us;1us;46us;|]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us;2us;4us;6us;8us;11us;13us;15us;17us;19us;21us;24us;26us;28us;30us;32us;34us;36us;38us;40us;42us;44us;46us;48us;50us;52us;54us;56us;58us;60us;62us;64us;66us;68us;70us;72us;76us;78us;80us;82us;84us;87us;89us;91us;95us;97us;99us;101us;103us;107us;112us;115us;117us;119us;121us;123us;126us;129us;131us;136us;139us;142us;144us;|]
let _fsyacc_action_rows = 63
let _fsyacc_actionTableElements = [|1us;32768us;7us;6us;0us;49152us;1us;32768us;0us;3us;0us;16385us;11us;16386us;3us;18us;7us;13us;8us;20us;10us;29us;11us;30us;12us;28us;13us;12us;14us;33us;15us;34us;16us;31us;17us;32us;0us;16387us;1us;32768us;13us;7us;1us;32768us;1us;8us;2us;32768us;9us;49us;13us;48us;0us;16388us;11us;16389us;3us;18us;7us;13us;8us;20us;10us;29us;11us;30us;12us;28us;13us;12us;14us;33us;15us;34us;16us;31us;17us;32us;0us;16390us;0us;16391us;1us;32768us;13us;14us;1us;32768us;1us;15us;2us;32768us;9us;49us;13us;48us;0us;16392us;0us;16393us;1us;32768us;9us;35us;0us;16394us;2us;32768us;9us;44us;13us;43us;0us;16395us;0us;16396us;0us;16397us;0us;16398us;0us;16399us;0us;16400us;0us;16401us;0us;16402us;0us;16403us;0us;16404us;0us;16405us;0us;16406us;0us;16407us;0us;16408us;2us;16409us;1us;36us;5us;38us;1us;32768us;9us;37us;0us;16410us;1us;32768us;9us;40us;0us;16411us;1us;16412us;5us;41us;1us;32768us;9us;40us;0us;16413us;2us;16414us;1us;46us;9us;45us;0us;16415us;0us;16416us;1us;32768us;9us;47us;0us;16417us;2us;16418us;2us;55us;4us;58us;2us;16419us;2us;55us;4us;58us;1us;16420us;4us;58us;0us;16421us;0us;16422us;0us;16423us;0us;16424us;1us;32768us;9us;56us;1us;16425us;2us;55us;0us;16426us;2us;32768us;9us;60us;13us;59us;1us;16427us;4us;58us;1us;16428us;2us;55us;0us;16429us;0us;16430us;|]
let _fsyacc_actionTableRowOffsets = [|0us;2us;3us;5us;6us;18us;19us;21us;23us;26us;27us;39us;40us;41us;43us;45us;48us;49us;50us;52us;53us;56us;57us;58us;59us;60us;61us;62us;63us;64us;65us;66us;67us;68us;69us;70us;73us;75us;76us;78us;79us;81us;83us;84us;87us;88us;89us;91us;92us;95us;98us;100us;101us;102us;103us;104us;106us;108us;109us;112us;114us;116us;117us;|]
let _fsyacc_reductionSymbolCounts = [|1us;2us;1us;2us;4us;1us;2us;1us;4us;1us;2us;2us;1us;1us;1us;1us;1us;1us;1us;1us;1us;1us;1us;1us;1us;1us;3us;3us;1us;3us;1us;1us;2us;3us;1us;1us;2us;2us;2us;2us;3us;2us;3us;2us;2us;3us;3us;|]
let _fsyacc_productionToNonTerminalTable = [|0us;1us;2us;2us;3us;4us;4us;5us;5us;5us;5us;5us;5us;5us;5us;5us;5us;5us;6us;7us;8us;9us;10us;11us;12us;13us;13us;13us;14us;14us;15us;15us;15us;15us;16us;16us;16us;16us;16us;16us;16us;17us;17us;18us;18us;18us;18us;|]
let _fsyacc_immediateActions = [|65535us;49152us;65535us;16385us;65535us;16387us;65535us;65535us;65535us;16388us;65535us;16390us;16391us;65535us;65535us;65535us;16392us;16393us;65535us;16394us;65535us;16395us;16396us;16397us;16398us;16399us;16400us;16401us;16402us;16403us;16404us;16405us;16406us;16407us;16408us;65535us;65535us;16410us;65535us;16411us;65535us;65535us;16413us;65535us;16415us;16416us;65535us;16417us;65535us;65535us;65535us;16421us;16422us;16423us;16424us;65535us;65535us;16426us;65535us;65535us;65535us;16429us;16430us;|]
let _fsyacc_reductions = lazy [|
# 244 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.dockerfile in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : 'gentype__startMain));
# 253 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_File in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 41 "Parser/DPar.fsy"
                                                         DFile _1 
                   )
# 41 "Parser/DPar.fsy"
                 : Absyn.dockerfile));
# 264 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_BaseImg in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 46 "Parser/DPar.fsy"
                                                         [_1]       
                   )
# 46 "Parser/DPar.fsy"
                 : 'gentype_File));
# 275 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_BaseImg in
            let _2 = parseState.GetInput(2) :?> 'gentype_Instrs in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 47 "Parser/DPar.fsy"
                                                         _1 :: _2   
                   )
# 47 "Parser/DPar.fsy"
                 : 'gentype_File));
# 287 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            let _2 = parseState.GetInput(2) :?> int * string in
            let _4 = parseState.GetInput(4) :?> 'gentype_Version in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 52 "Parser/DPar.fsy"
                                                         BaseImage(_1, snd _2, Tag _4)  
                   )
# 52 "Parser/DPar.fsy"
                 : 'gentype_BaseImg));
# 300 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_Instr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 57 "Parser/DPar.fsy"
                                                         [_1]        
                   )
# 57 "Parser/DPar.fsy"
                 : 'gentype_Instrs));
# 311 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_Instr in
            let _2 = parseState.GetInput(2) :?> 'gentype_Instrs in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 58 "Parser/DPar.fsy"
                                                         _1 :: _2    
                   )
# 58 "Parser/DPar.fsy"
                 : 'gentype_Instrs));
# 323 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 63 "Parser/DPar.fsy"
                                                         Var _1                        
                   )
# 63 "Parser/DPar.fsy"
                 : 'gentype_Instr));
# 334 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            let _2 = parseState.GetInput(2) :?> int * string in
            let _4 = parseState.GetInput(4) :?> 'gentype_Version in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 64 "Parser/DPar.fsy"
                                                         BaseImage(_1, snd _2, Tag _4) 
                   )
# 64 "Parser/DPar.fsy"
                 : 'gentype_Instr));
# 347 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_MntPt in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 65 "Parser/DPar.fsy"
                                                         Volume _1                     
                   )
# 65 "Parser/DPar.fsy"
                 : 'gentype_Instr));
# 358 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            let _2 = parseState.GetInput(2) :?> 'gentype_Expose in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 66 "Parser/DPar.fsy"
                                                         Expose (_1, _2)               
                   )
# 66 "Parser/DPar.fsy"
                 : 'gentype_Instr));
# 370 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            let _2 = parseState.GetInput(2) :?> 'gentype_User in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 67 "Parser/DPar.fsy"
                                                         User (_1, _2)                 
                   )
# 67 "Parser/DPar.fsy"
                 : 'gentype_Instr));
# 382 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_WPath in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 68 "Parser/DPar.fsy"
                                                         Workdir _1                    
                   )
# 68 "Parser/DPar.fsy"
                 : 'gentype_Instr));
# 393 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_Runcmd in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 69 "Parser/DPar.fsy"
                                                         Run _1                        
                   )
# 69 "Parser/DPar.fsy"
                 : 'gentype_Instr));
# 404 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_Entrycmd in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 70 "Parser/DPar.fsy"
                                                         EntryCmd _1                   
                   )
# 70 "Parser/DPar.fsy"
                 : 'gentype_Instr));
# 415 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_CPath in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 71 "Parser/DPar.fsy"
                                                         Copy _1                       
                   )
# 71 "Parser/DPar.fsy"
                 : 'gentype_Instr));
# 426 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_AddPath in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 72 "Parser/DPar.fsy"
                                                         Add _1                        
                   )
# 72 "Parser/DPar.fsy"
                 : 'gentype_Instr));
# 437 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_EnvVar in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 73 "Parser/DPar.fsy"
                                                         Env _1                        
                   )
# 73 "Parser/DPar.fsy"
                 : 'gentype_Instr));
# 448 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * (string * string) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 78 "Parser/DPar.fsy"
                                                         extract_last _1 (fun x -> EnvVar x)  
                   )
# 78 "Parser/DPar.fsy"
                 : 'gentype_EnvVar));
# 459 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * (string * string) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 83 "Parser/DPar.fsy"
                                                         extract_last _1 (fun x -> CPath x) 
                   )
# 83 "Parser/DPar.fsy"
                 : 'gentype_CPath));
# 470 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * (string * string) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 88 "Parser/DPar.fsy"
                                                         extract_last _1 (fun x -> APath x) 
                   )
# 88 "Parser/DPar.fsy"
                 : 'gentype_AddPath));
# 481 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 93 "Parser/DPar.fsy"
                                                         extract_last _1 (fun x -> ShellCmd x) 
                   )
# 93 "Parser/DPar.fsy"
                 : 'gentype_Runcmd));
# 492 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 98 "Parser/DPar.fsy"
                                                         extract_last _1 (fun x -> ShellCmd x) 
                   )
# 98 "Parser/DPar.fsy"
                 : 'gentype_Entrycmd));
# 503 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 104 "Parser/DPar.fsy"
                                                         extract_last _1 (fun x -> Mnt_pt x) 
                   )
# 104 "Parser/DPar.fsy"
                 : 'gentype_MntPt));
# 514 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 109 "Parser/DPar.fsy"
                                                         extract_last _1 (fun x -> WPath x) 
                   )
# 109 "Parser/DPar.fsy"
                 : 'gentype_WPath));
# 525 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 115 "Parser/DPar.fsy"
                                                         Port _1          
                   )
# 115 "Parser/DPar.fsy"
                 : 'gentype_Expose));
# 536 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            let _3 = parseState.GetInput(3) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 116 "Parser/DPar.fsy"
                                                         PortM (_1, _3)   
                   )
# 116 "Parser/DPar.fsy"
                 : 'gentype_Expose));
# 548 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            let _3 = parseState.GetInput(3) :?> 'gentype_Ports in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 117 "Parser/DPar.fsy"
                                                         Ports (_1 :: _3) 
                   )
# 117 "Parser/DPar.fsy"
                 : 'gentype_Expose));
# 560 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 122 "Parser/DPar.fsy"
                                                         [_1]     
                   )
# 122 "Parser/DPar.fsy"
                 : 'gentype_Ports));
# 571 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            let _3 = parseState.GetInput(3) :?> 'gentype_Ports in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 123 "Parser/DPar.fsy"
                                                         _1 :: _3 
                   )
# 123 "Parser/DPar.fsy"
                 : 'gentype_Ports));
# 583 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 128 "Parser/DPar.fsy"
                                                         (Some (snd _1), None)    
                   )
# 128 "Parser/DPar.fsy"
                 : 'gentype_User));
# 594 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 129 "Parser/DPar.fsy"
                                                         (None, Some _1)          
                   )
# 129 "Parser/DPar.fsy"
                 : 'gentype_User));
# 605 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * string in
            let _2 = parseState.GetInput(2) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 130 "Parser/DPar.fsy"
                                                         (Some (snd _1), Some _2) 
                   )
# 130 "Parser/DPar.fsy"
                 : 'gentype_User));
# 617 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * string in
            let _3 = parseState.GetInput(3) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 131 "Parser/DPar.fsy"
                                                         (Some (snd _1), Some _3) 
                   )
# 131 "Parser/DPar.fsy"
                 : 'gentype_User));
# 629 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 136 "Parser/DPar.fsy"
                                                         snd _1                          
                   )
# 136 "Parser/DPar.fsy"
                 : 'gentype_Version));
# 640 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 137 "Parser/DPar.fsy"
                                                         string _1                       
                   )
# 137 "Parser/DPar.fsy"
                 : 'gentype_Version));
# 651 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            let _2 = parseState.GetInput(2) :?> 'gentype_DottedName in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 138 "Parser/DPar.fsy"
                                                         string _1 + "." + _2            
                   )
# 138 "Parser/DPar.fsy"
                 : 'gentype_Version));
# 663 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            let _2 = parseState.GetInput(2) :?> 'gentype_DashedName in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 139 "Parser/DPar.fsy"
                                                         string _1 + "-" + _2            
                   )
# 139 "Parser/DPar.fsy"
                 : 'gentype_Version));
# 675 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * string in
            let _2 = parseState.GetInput(2) :?> 'gentype_DottedName in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 140 "Parser/DPar.fsy"
                                                         string (snd _1) + "." + _2      
                   )
# 140 "Parser/DPar.fsy"
                 : 'gentype_Version));
# 687 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * string in
            let _2 = parseState.GetInput(2) :?> 'gentype_DashedName in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 141 "Parser/DPar.fsy"
                                                         string (snd _1) + "-" + _2      
                   )
# 141 "Parser/DPar.fsy"
                 : 'gentype_Version));
# 699 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            let _2 = parseState.GetInput(2) :?> 'gentype_DottedName in
            let _3 = parseState.GetInput(3) :?> 'gentype_DashedName in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 142 "Parser/DPar.fsy"
                                                         string _1 + "." + _2 + "-" + _3 
                   )
# 142 "Parser/DPar.fsy"
                 : 'gentype_Version));
# 712 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 147 "Parser/DPar.fsy"
                                                         string _2               
                   )
# 147 "Parser/DPar.fsy"
                 : 'gentype_DottedName));
# 723 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> int in
            let _3 = parseState.GetInput(3) :?> 'gentype_DottedName in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 148 "Parser/DPar.fsy"
                                                         string _2 + "." + _3    
                   )
# 148 "Parser/DPar.fsy"
                 : 'gentype_DottedName));
# 735 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> int * string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 153 "Parser/DPar.fsy"
                                                         string (snd _2)            
                   )
# 153 "Parser/DPar.fsy"
                 : 'gentype_DashedName));
# 746 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 154 "Parser/DPar.fsy"
                                                         string _2                  
                   )
# 154 "Parser/DPar.fsy"
                 : 'gentype_DashedName));
# 757 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> int in
            let _3 = parseState.GetInput(3) :?> 'gentype_DottedName in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 155 "Parser/DPar.fsy"
                                                         string _2 + "." + _3       
                   )
# 155 "Parser/DPar.fsy"
                 : 'gentype_DashedName));
# 769 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> int * string in
            let _3 = parseState.GetInput(3) :?> 'gentype_DashedName in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 156 "Parser/DPar.fsy"
                                                         string (snd _2) + "-" + _3 
                   )
# 156 "Parser/DPar.fsy"
                 : 'gentype_DashedName));
|]
# 782 "Parser/DPar.fs"
let tables : FSharp.Text.Parsing.Tables<_> = 
  { reductions = _fsyacc_reductions.Value;
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
    numTerminals = 22;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = tables.Interpret(lexer, lexbuf, startState)
let Main lexer lexbuf : Absyn.dockerfile =
    engine lexer lexbuf 0 :?> _
