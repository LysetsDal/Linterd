module Rules.MiscWarning

open System.Runtime.CompilerServices

[<IsReadOnly; Struct>]
type MiscWarn =
    {
      Code: string
      Problem: string
      Msg: string
    }
