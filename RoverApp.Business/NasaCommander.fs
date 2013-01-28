namespace RoverApp.Business

open System
open System.Collections.Generic
 
  
type NasaCommander = 
     
     val m_rover :  Rover

     new (rover) ={ m_rover= rover}

     member this.SendInstructions(instructionLine: string) = 

          let array = instructionLine.ToUpper().ToCharArray()

          for instruction in array  do
               match instruction with    
                   |'L'-> this.m_rover.TurnLeft 
                   |'R'-> this.m_rover.TurnRight 
                   |'M'-> this.m_rover.Move
                   | _ ->  failwith "illegal command."

          this.m_rover.CurrentPosition






  