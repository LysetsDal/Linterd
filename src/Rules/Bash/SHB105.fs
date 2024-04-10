module Rules.Bash.SHB105

open Rules.ShellWarn

let shb105 : binWarn = {
    ErrorCode = "SHB105"
    Binary = "ifconfig"
    ErrorMsg = "ifconfig is used to display information about the network interfaces.
Running it inside a container might not be meningful. In --priviledged mode it
can also leak information from the host machine. Try useing 'docker network ls'
or 'docker network inspect' instead."
}