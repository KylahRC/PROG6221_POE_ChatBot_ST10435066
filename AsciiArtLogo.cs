using CybersecurityAwarenessBot;

namespace CybersecurityAwarenessBot
{
    public static class AsciiArtLogo
    {
        #region Setup and Initialization

        /*
        ________________________________________________________________________ 
            Summary of DisplayAsciiArt():
                Displays the ASCII art logo for the chatbot in green text.
        ________________________________________________________________________
        */

        public static void DisplayAsciiArt() //displays the logo
        {
            //assigns the art to a string
            string asciiArt = @" 
                              ___           ___     
                  ___        /\  \         /\  \    
                 /\  \      /::\  \       /::\  \   
                 \:\  \    /:/\:\  \     /:/\ \  \  
                 /::\__\  /:/  \:\  \   _\:\~\ \  \ 
              __/:/\/__/ /:/__/ \:\__\ /\ \:\ \ \__\
             /\/:/  /    \:\  \  \/__/ \:\ \:\ \/__/
             \::/__/      \:\  \        \:\ \:\__\  
              \:\__\       \:\  \        \:\/:/  /  
               \/__/        \:\__\        \::/  /   
                             \/__/         \/__/    
              Irvine        Cyber        Security
                        
                ";
            Console.ForegroundColor = ConsoleColor.Green; //changes the font colour
            Console.WriteLine(asciiArt); //outputs the logo string
            Console.ForegroundColor = ConsoleColor.White;
        }

        #endregion //end the region

        /*==================================================================================================*/
    }
}
