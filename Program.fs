// Learn more about F# at https://fsharp.org
// See the 'F# Tutorial' project for more help.
type BlockData = {
    block_id : int
}
type UnboundPoint = {
    relative : int*int*int 
    data : BlockData
}
type Point = {
    absolute : int*int*int
    relative : int*int*int
    data : BlockData
}

[<EntryPoint>]
let main argv =
    printfn "%A" argv
    0 // return an integer exit code
