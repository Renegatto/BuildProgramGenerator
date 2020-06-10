// Learn more about F# at https://fsharp.org
// See the 'F# Tutorial' project for more help.
module BuildProgramGenerator
type RelativeDirection =
    |Up
    |Down
    |Right
    |Left
    |Front
    |Back

type Point = Point of int*int*int

type BlockData =
    {
        block_id : int
    }
type Block = 
    {
        absolute    : Point
        data        : BlockData
    }
type UnboundBlock = 
    {
        relative : Point 
        data : BlockData
    }
type BoundBlock = 
    {
        absolute : Point
        relative : Point
        data : BlockData
    }
type Environment = UnboundBlock list
type Model       = BoundBlock   list


type Instruction =
    |Move   of RelativeDirection
    |Place  of RelativeDirection * block_id:int
    |Dig    of RelativeDirection
type TurtleState =
    {
        model       : Model
        position    : Point
    }
type WorldState =
    {
        environment : Environment
        model       : Model
        position    : Point
    }
type Generator      = Model -> Point -> Instruction list
type Simulation     = WorldState -> Instruction list -> Environment seq -> WorldState 
type Interpreter    = Instruction list -> Environment seq -> WorldState 
// todo: type Interpreter    = Instruction list -> Environment state -> WorldState
let interpret (instruction:Instruction) (state:WorldState): WorldState =
    match instruction with
    |Move   dir     -> move state dir
    |Place  (dir,id)  -> place state dir id
    |Dig    dir     -> dig state dir
    |> fun result -> 
        match result with
        |Success state
        |Fail (instruction,state)

[<EntryPoint>]
let main argv =
    printfn "%A" argv
    0 // return an integer exit code
