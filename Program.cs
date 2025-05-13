namespace CybersecurityAwarenessBot
{
    class Program
    {
        /* 
        _______________________________________________________________________________________
            Summary of Main():
                The main entry point for the chatbot program.
        _______________________________________________________________________________________
        */

        static void Main(string[] args)
        {
            AsciiArtLogo.DisplayAsciiArt();
            //AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Intro"]);
            GreetUser.Execute(); // Calls the new GreetUser file
        }
    }
}


