module Rules.Bash.SHB102

open Rules.ShellWarn

let shb102 : binWarn = {
    Code = "SHB102"
    Bin = "shutdown"
    Msg = "Running shutdown inside a containers is nonsensical."
}
    