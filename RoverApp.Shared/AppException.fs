namespace RoverApp.Shared
 
open System
open System.Text


type AppException(message :string, source :string, context :string, ex: Exception) = 
     inherit Exception()
     
           member this.UserInfo
                   with get() = message

           member this.MyException
                   with get() =  ex
      
       
           member this.GetInnerError(ex:Exception) = 
                         
                         
                           if ex = null  then ""
                            
                           else
                               let sb = new StringBuilder()

                               sb.AppendLine("Exception Message: " + ex.Message)  |> ignore
                          
                               if ex.InnerException <> null  then  
                                    sb.AppendLine("Inner Exception: " + ex.InnerException.Message) |> ignore
                              
                  
                               sb.ToString()   
                                    
            member this.DebugInfo
                   with get() =  "Source:\n" + source + "\n\nContext:\n" + context + "\n\nInner Error:\n" +  this.GetInnerError(ex)    