namespace RoverApp.Business
          


open System
open System.Collections.Generic
 
 
type Rover = 
  
  val  mutable m_x :int
  val  mutable m_y :int
  val  mutable m_heading: Heading

  static member   GetHeading (text:string) = 
                   match text with    
                   |"N"-> Heading.North
                   |"S"-> Heading.South
                   |"E"-> Heading.East 
                   |"W"-> Heading.West 
                   | _ -> failwith "Error occured when initializing rover .."

  static member GetHeadingText (heading :Heading) = 
                   match heading with    
                   |Heading.North -> "N"
                   |Heading.South -> "S"
                   |Heading.West  -> "W"
                   |Heading.East  -> "E"
             


  new (x,y, heading) = {m_x= x; m_y=y; m_heading= heading }
  
  new (line :string)  =  
                            let array= line.Split[|' '|]
  
                            if  Array.length(array) <>3 then
                                 failwith "Error occured when initializing rover .."
  
                            { m_x = Int32.Parse(array.[0]);  m_y = Int32.Parse(array.[1]);m_heading =  Rover.GetHeading(array.[2]) }
                            
                            then 
                            ()


  member this.CurrentPosition = String.Format("{0},{1},{2}",  this.m_x, this.m_y,   Rover.GetHeadingText(this.m_heading))

 
  member this.Move = 
           match this.m_heading with    
                   | Heading.North -> this.m_y <- this.m_y+1
                   | Heading.South -> this.m_y <- this.m_y-1  
                   | Heading.West  -> this.m_x <- this.m_x-1    
                   | Heading.East  -> this.m_x <- this.m_x+1    
            
           ( )         

              
  member this.TurnLeft = 
           match this.m_heading with    
                   | Heading.North -> this.m_heading <- Heading.West
                   | Heading.South -> this.m_heading <- Heading.East 
                   | Heading.West  -> this.m_heading <- Heading.South
                   | Heading.East  -> this.m_heading <- Heading.North 
                 
           ( )            
   
           
     
  member this.TurnRight = 
           match this.m_heading with    
                   | Heading.North -> this.m_heading <- Heading.East
                   | Heading.South -> this.m_heading <- Heading.West
                   | Heading.West  -> this.m_heading <- Heading.North
                   | Heading.East  -> this.m_heading <- Heading.South 
             
           ( ) 