// Implementation file for parser generated by fsyacc
module DPar
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open FSharp.Text.Lexing
open FSharp.Text.Parsing.ParseHelpers
# 4 "Parser/DPar.fsy"

open Absyn

let extr tup =
    (fst tup, snd tup)

let extrf tup p = 
    (p (fst tup), snd tup)

let extrl tup p = 
    (fst tup, p(snd tup))


# 20 "Parser/DPar.fs"
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
    | 33 -> NONTERM_Version 
    | 34 -> NONTERM_Version 
    | 35 -> NONTERM_Version 
    | 36 -> NONTERM_Version 
    | 37 -> NONTERM_Version 
    | 38 -> NONTERM_Version 
    | 39 -> NONTERM_Version 
    | 40 -> NONTERM_DottedName 
    | 41 -> NONTERM_DottedName 
    | 42 -> NONTERM_DashedName 
    | 43 -> NONTERM_DashedName 
    | 44 -> NONTERM_DashedName 
    | 45 -> NONTERM_DashedName 
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
let _fsyacc_gotos = [| 0us;65535us;1us;65535us;0us;1us;1us;65535us;0us;2us;1us;65535us;0us;4us;2us;65535us;4us;5us;10us;11us;2us;65535us;4us;10us;10us;10us;2us;65535us;4us;27us;10us;27us;2us;65535us;4us;25us;10us;25us;2us;65535us;4us;26us;10us;26us;2us;65535us;4us;23us;10us;23us;2us;65535us;4us;24us;10us;24us;2us;65535us;4us;17us;10us;17us;2us;65535us;4us;22us;10us;22us;1us;65535us;18us;19us;2us;65535us;38us;39us;41us;42us;1us;65535us;20us;21us;2us;65535us;8us;9us;15us;16us;4us;65535us;46us;50us;47us;48us;54us;55us;58us;59us;4us;65535us;46us;51us;47us;49us;48us;52us;57us;60us;|]
let _fsyacc_sparseGotoTableRowOffsets = [|0us;1us;3us;5us;7us;10us;13us;16us;19us;22us;25us;28us;31us;34us;36us;39us;41us;44us;49us;|]
let _fsyacc_stateToProdIdxsTableElements = [| 1us;0us;1us;0us;1us;1us;1us;1us;2us;2us;3us;1us;3us;1us;4us;1us;4us;1us;4us;1us;4us;2us;5us;6us;1us;6us;1us;7us;1us;8us;1us;8us;1us;8us;1us;8us;1us;9us;1us;10us;1us;10us;1us;11us;1us;11us;1us;12us;1us;13us;1us;14us;1us;15us;1us;16us;1us;17us;1us;18us;1us;19us;1us;20us;1us;21us;1us;22us;1us;23us;1us;24us;3us;25us;26us;27us;1us;26us;1us;26us;1us;27us;1us;27us;2us;28us;29us;1us;29us;1us;29us;2us;30us;32us;1us;31us;1us;32us;3us;33us;37us;38us;4us;34us;35us;36us;39us;2us;35us;39us;1us;36us;1us;37us;1us;38us;1us;39us;2us;40us;41us;2us;40us;41us;1us;41us;4us;42us;43us;44us;45us;2us;42us;45us;2us;43us;44us;1us;44us;1us;45us;|]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us;2us;4us;6us;8us;11us;13us;15us;17us;19us;21us;24us;26us;28us;30us;32us;34us;36us;38us;40us;42us;44us;46us;48us;50us;52us;54us;56us;58us;60us;62us;64us;66us;68us;70us;72us;76us;78us;80us;82us;84us;87us;89us;91us;94us;96us;98us;102us;107us;110us;112us;114us;116us;118us;121us;124us;126us;131us;134us;137us;139us;|]
let _fsyacc_action_rows = 61
let _fsyacc_actionTableElements = [|1us;32768us;7us;6us;0us;49152us;1us;32768us;0us;3us;0us;16385us;11us;16386us;3us;18us;7us;13us;8us;20us;10us;29us;11us;30us;12us;28us;13us;12us;14us;33us;15us;34us;16us;31us;17us;32us;0us;16387us;1us;32768us;13us;7us;1us;32768us;1us;8us;2us;32768us;9us;47us;13us;46us;0us;16388us;11us;16389us;3us;18us;7us;13us;8us;20us;10us;29us;11us;30us;12us;28us;13us;12us;14us;33us;15us;34us;16us;31us;17us;32us;0us;16390us;0us;16391us;1us;32768us;13us;14us;1us;32768us;1us;15us;2us;32768us;9us;47us;13us;46us;0us;16392us;0us;16393us;1us;32768us;9us;35us;0us;16394us;2us;32768us;9us;44us;13us;43us;0us;16395us;0us;16396us;0us;16397us;0us;16398us;0us;16399us;0us;16400us;0us;16401us;0us;16402us;0us;16403us;0us;16404us;0us;16405us;0us;16406us;0us;16407us;0us;16408us;2us;16409us;1us;36us;5us;38us;1us;32768us;9us;37us;0us;16410us;1us;32768us;9us;40us;0us;16411us;1us;16412us;5us;41us;1us;32768us;9us;40us;0us;16413us;1us;16414us;9us;45us;0us;16415us;0us;16416us;2us;16417us;2us;53us;4us;56us;2us;16418us;2us;53us;4us;56us;1us;16419us;4us;56us;0us;16420us;0us;16421us;0us;16422us;0us;16423us;1us;32768us;9us;54us;1us;16424us;2us;53us;0us;16425us;2us;32768us;9us;58us;13us;57us;1us;16426us;4us;56us;1us;16427us;2us;53us;0us;16428us;0us;16429us;|]
let _fsyacc_actionTableRowOffsets = [|0us;2us;3us;5us;6us;18us;19us;21us;23us;26us;27us;39us;40us;41us;43us;45us;48us;49us;50us;52us;53us;56us;57us;58us;59us;60us;61us;62us;63us;64us;65us;66us;67us;68us;69us;70us;73us;75us;76us;78us;79us;81us;83us;84us;86us;87us;88us;91us;94us;96us;97us;98us;99us;100us;102us;104us;105us;108us;110us;112us;113us;|]
let _fsyacc_reductionSymbolCounts = [|1us;2us;1us;2us;4us;1us;2us;1us;4us;1us;2us;2us;1us;1us;1us;1us;1us;1us;1us;1us;1us;1us;1us;1us;1us;1us;3us;3us;1us;3us;1us;1us;2us;1us;1us;2us;2us;2us;2us;3us;2us;3us;2us;2us;3us;3us;|]
let _fsyacc_productionToNonTerminalTable = [|0us;1us;2us;2us;3us;4us;4us;5us;5us;5us;5us;5us;5us;5us;5us;5us;5us;5us;6us;7us;8us;9us;10us;11us;12us;13us;13us;13us;14us;14us;15us;15us;15us;16us;16us;16us;16us;16us;16us;16us;17us;17us;18us;18us;18us;18us;|]
let _fsyacc_immediateActions = [|65535us;49152us;65535us;16385us;65535us;16387us;65535us;65535us;65535us;16388us;65535us;16390us;16391us;65535us;65535us;65535us;16392us;16393us;65535us;16394us;65535us;16395us;16396us;16397us;16398us;16399us;16400us;16401us;16402us;16403us;16404us;16405us;16406us;16407us;16408us;65535us;65535us;16410us;65535us;16411us;65535us;65535us;16413us;65535us;16415us;16416us;65535us;65535us;65535us;16420us;16421us;16422us;16423us;65535us;65535us;16425us;65535us;65535us;65535us;16428us;16429us;|]
let _fsyacc_reductions = lazy [|
# 246 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.dockerfile in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : 'gentype__startMain));
# 255 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_File in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 45 "Parser/DPar.fsy"
                                                         DFile _1 
                   )
# 45 "Parser/DPar.fsy"
                 : Absyn.dockerfile));
# 266 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_BaseImg in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 52 "Parser/DPar.fsy"
                                                         [_1]       
                   )
# 52 "Parser/DPar.fsy"
                 : 'gentype_File));
# 277 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_BaseImg in
            let _2 = parseState.GetInput(2) :?> 'gentype_Instrs in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 53 "Parser/DPar.fsy"
                                                         _1 :: _2   
                   )
# 53 "Parser/DPar.fsy"
                 : 'gentype_File));
# 289 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            let _2 = parseState.GetInput(2) :?> int * string in
            let _4 = parseState.GetInput(4) :?> 'gentype_Version in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 60 "Parser/DPar.fsy"
                                                         BaseImage(_1, snd _2, Tag _4)  
                   )
# 60 "Parser/DPar.fsy"
                 : 'gentype_BaseImg));
# 302 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_Instr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 67 "Parser/DPar.fsy"
                                                         [_1]        
                   )
# 67 "Parser/DPar.fsy"
                 : 'gentype_Instrs));
# 313 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_Instr in
            let _2 = parseState.GetInput(2) :?> 'gentype_Instrs in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 68 "Parser/DPar.fsy"
                                                         _1 :: _2    
                   )
# 68 "Parser/DPar.fsy"
                 : 'gentype_Instrs));
# 325 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 75 "Parser/DPar.fsy"
                                                         Var _1                        
                   )
# 75 "Parser/DPar.fsy"
                 : 'gentype_Instr));
# 336 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            let _2 = parseState.GetInput(2) :?> int * string in
            let _4 = parseState.GetInput(4) :?> 'gentype_Version in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 76 "Parser/DPar.fsy"
                                                         BaseImage(_1, snd _2, Tag _4) 
                   )
# 76 "Parser/DPar.fsy"
                 : 'gentype_Instr));
# 349 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_MntPt in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 77 "Parser/DPar.fsy"
                                                         Volume _1                     
                   )
# 77 "Parser/DPar.fsy"
                 : 'gentype_Instr));
# 360 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            let _2 = parseState.GetInput(2) :?> 'gentype_Expose in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 78 "Parser/DPar.fsy"
                                                         Expose (_1, _2)               
                   )
# 78 "Parser/DPar.fsy"
                 : 'gentype_Instr));
# 372 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            let _2 = parseState.GetInput(2) :?> 'gentype_User in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 79 "Parser/DPar.fsy"
                                                         User (_1, _2)                 
                   )
# 79 "Parser/DPar.fsy"
                 : 'gentype_Instr));
# 384 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_WPath in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 80 "Parser/DPar.fsy"
                                                         Workdir _1                    
                   )
# 80 "Parser/DPar.fsy"
                 : 'gentype_Instr));
# 395 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_Runcmd in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 81 "Parser/DPar.fsy"
                                                         Run _1                        
                   )
# 81 "Parser/DPar.fsy"
                 : 'gentype_Instr));
# 406 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_Entrycmd in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 82 "Parser/DPar.fsy"
                                                         EntryCmd _1                   
                   )
# 82 "Parser/DPar.fsy"
                 : 'gentype_Instr));
# 417 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_CPath in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 83 "Parser/DPar.fsy"
                                                         Copy _1                       
                   )
# 83 "Parser/DPar.fsy"
                 : 'gentype_Instr));
# 428 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_AddPath in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 84 "Parser/DPar.fsy"
                                                         Add _1                        
                   )
# 84 "Parser/DPar.fsy"
                 : 'gentype_Instr));
# 439 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_EnvVar in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 85 "Parser/DPar.fsy"
                                                         Env _1                        
                   )
# 85 "Parser/DPar.fsy"
                 : 'gentype_Instr));
# 450 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * (string * string) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 92 "Parser/DPar.fsy"
                                                         extrl _1 (fun x -> EnvVar x)  
                   )
# 92 "Parser/DPar.fsy"
                 : 'gentype_EnvVar));
# 461 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * (string * string) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 99 "Parser/DPar.fsy"
                                                         extrl _1 (fun x -> CPath x) 
                   )
# 99 "Parser/DPar.fsy"
                 : 'gentype_CPath));
# 472 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * (string * string) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 106 "Parser/DPar.fsy"
                                                         extrl _1 (fun x -> APath x) 
                   )
# 106 "Parser/DPar.fsy"
                 : 'gentype_AddPath));
# 483 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 113 "Parser/DPar.fsy"
                                                         extrl _1 (fun x -> Cmd x) 
                   )
# 113 "Parser/DPar.fsy"
                 : 'gentype_Runcmd));
# 494 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 120 "Parser/DPar.fsy"
                                                         extrl _1 (fun x -> Cmd x) 
                   )
# 120 "Parser/DPar.fsy"
                 : 'gentype_Entrycmd));
# 505 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 128 "Parser/DPar.fsy"
                                                         extrl _1 (fun x -> Mnt_pt x) 
                   )
# 128 "Parser/DPar.fsy"
                 : 'gentype_MntPt));
# 516 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 135 "Parser/DPar.fsy"
                                                         extrl _1 (fun x -> WPath x) 
                   )
# 135 "Parser/DPar.fsy"
                 : 'gentype_WPath));
# 527 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 143 "Parser/DPar.fsy"
                                                         Port _1          
                   )
# 143 "Parser/DPar.fsy"
                 : 'gentype_Expose));
# 538 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            let _3 = parseState.GetInput(3) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 144 "Parser/DPar.fsy"
                                                         PortM (_1, _3)   
                   )
# 144 "Parser/DPar.fsy"
                 : 'gentype_Expose));
# 550 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            let _3 = parseState.GetInput(3) :?> 'gentype_Ports in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 145 "Parser/DPar.fsy"
                                                         Ports (_1 :: _3) 
                   )
# 145 "Parser/DPar.fsy"
                 : 'gentype_Expose));
# 562 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 152 "Parser/DPar.fsy"
                                                         [_1]     
                   )
# 152 "Parser/DPar.fsy"
                 : 'gentype_Ports));
# 573 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            let _3 = parseState.GetInput(3) :?> 'gentype_Ports in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 153 "Parser/DPar.fsy"
                                                         _1 :: _3 
                   )
# 153 "Parser/DPar.fsy"
                 : 'gentype_Ports));
# 585 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 160 "Parser/DPar.fsy"
                                                         (Some (snd _1), None)    
                   )
# 160 "Parser/DPar.fsy"
                 : 'gentype_User));
# 596 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 161 "Parser/DPar.fsy"
                                                         (None, Some _1)          
                   )
# 161 "Parser/DPar.fsy"
                 : 'gentype_User));
# 607 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * string in
            let _2 = parseState.GetInput(2) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 162 "Parser/DPar.fsy"
                                                         (Some (snd _1), Some _2) 
                   )
# 162 "Parser/DPar.fsy"
                 : 'gentype_User));
# 619 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 169 "Parser/DPar.fsy"
                                                         snd _1                          
                   )
# 169 "Parser/DPar.fsy"
                 : 'gentype_Version));
# 630 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 170 "Parser/DPar.fsy"
                                                         string _1                       
                   )
# 170 "Parser/DPar.fsy"
                 : 'gentype_Version));
# 641 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            let _2 = parseState.GetInput(2) :?> 'gentype_DottedName in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 171 "Parser/DPar.fsy"
                                                         string _1 + "." + _2            
                   )
# 171 "Parser/DPar.fsy"
                 : 'gentype_Version));
# 653 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            let _2 = parseState.GetInput(2) :?> 'gentype_DashedName in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 172 "Parser/DPar.fsy"
                                                         string _1 + "-" + _2            
                   )
# 172 "Parser/DPar.fsy"
                 : 'gentype_Version));
# 665 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * string in
            let _2 = parseState.GetInput(2) :?> 'gentype_DottedName in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 173 "Parser/DPar.fsy"
                                                         string (snd _1) + "." + _2      
                   )
# 173 "Parser/DPar.fsy"
                 : 'gentype_Version));
# 677 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int * string in
            let _2 = parseState.GetInput(2) :?> 'gentype_DashedName in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 174 "Parser/DPar.fsy"
                                                         string (snd _1) + "-" + _2      
                   )
# 174 "Parser/DPar.fsy"
                 : 'gentype_Version));
# 689 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            let _2 = parseState.GetInput(2) :?> 'gentype_DottedName in
            let _3 = parseState.GetInput(3) :?> 'gentype_DashedName in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 175 "Parser/DPar.fsy"
                                                         string _1 + "." + _2 + "-" + _3 
                   )
# 175 "Parser/DPar.fsy"
                 : 'gentype_Version));
# 702 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 182 "Parser/DPar.fsy"
                                                         string _2               
                   )
# 182 "Parser/DPar.fsy"
                 : 'gentype_DottedName));
# 713 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> int in
            let _3 = parseState.GetInput(3) :?> 'gentype_DottedName in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 183 "Parser/DPar.fsy"
                                                         string _2 + "." + _3    
                   )
# 183 "Parser/DPar.fsy"
                 : 'gentype_DottedName));
# 725 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> int * string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 190 "Parser/DPar.fsy"
                                                         string (snd _2)            
                   )
# 190 "Parser/DPar.fsy"
                 : 'gentype_DashedName));
# 736 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 191 "Parser/DPar.fsy"
                                                         string _2                  
                   )
# 191 "Parser/DPar.fsy"
                 : 'gentype_DashedName));
# 747 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> int in
            let _3 = parseState.GetInput(3) :?> 'gentype_DottedName in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 192 "Parser/DPar.fsy"
                                                         string _2 + "." + _3       
                   )
# 192 "Parser/DPar.fsy"
                 : 'gentype_DashedName));
# 759 "Parser/DPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> int * string in
            let _3 = parseState.GetInput(3) :?> 'gentype_DashedName in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 193 "Parser/DPar.fsy"
                                                         string (snd _2) + "-" + _3 
                   )
# 193 "Parser/DPar.fsy"
                 : 'gentype_DashedName));
|]
# 772 "Parser/DPar.fs"
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
