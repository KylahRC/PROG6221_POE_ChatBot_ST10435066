namespace CybersecurityAwarenessBot
{
    public static class MainMenu
    {
        public static void Execute()
        {
            bool exit = false;

            while (!exit)
            {
                CatExpressions.DisplayCat($"What do you want to do, {GlobalVariables.userName}?", CatExpression.Curious);
                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Curious"]);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Ask a question");
                Console.WriteLine("2. Pet the cat!");
                Console.WriteLine("3. Mute/Unmute the cat");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string choice = Console.ReadLine()?.Trim();
                Console.ForegroundColor = ConsoleColor.White;

                switch (choice)
                {
                    case "1":
                        AskQuestion.Execute(); // Calls AskQuestion from its separate file
                        break;
                    case "2":
                        string petResponse = ChatbotUtilityFile.ChatbotResponses.GetRandomPetTheCatResponse();
                        CatExpressions.DisplayCat(petResponse, CatExpression.Loving);
                        AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Purr"]);
                        break;
                    case "3":
                        GlobalVariables.isMuted = !GlobalVariables.isMuted;
                        string muteMessage = GlobalVariables.isMuted ? "Oh... alright then, I'll be quiet..." : "Yay! I'm so glad you changed your mind!";
                        CatExpressions.DisplayCat(muteMessage, GlobalVariables.isMuted ? CatExpression.Sad : CatExpression.Happy);
                        if (!GlobalVariables.isMuted) AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Excited"]);
                        break;
                    case "4":
                        string goodbyeResponse = ChatbotUtilityFile.ChatbotResponses.GetRandomGoodbyeResponse();
                        CatExpressions.DisplayCat(goodbyeResponse, CatExpression.Happy);
                        AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Bye"]);
                        exit = true;
                        break;
                    default:
                        CatExpressions.DisplayCat(ChatbotUtilityFile.ChatbotResponses.GetRandomInvalidInputResponse(), CatExpression.Confused);
                        AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Sad"]);
                        break;
                }
            }
        }
    }
}

