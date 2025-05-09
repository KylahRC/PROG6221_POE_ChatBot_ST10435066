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

                TextFormatter.SetColorText("1. Ask a question", GlobalVariables.MenuOptionColor);
                TextFormatter.SetColorText("2. Pet the cat!", GlobalVariables.MenuOptionColor);
                TextFormatter.SetColorText("3. Mute/Unmute the cat", GlobalVariables.MenuOptionColor);
                TextFormatter.SetColorText("4. Exit", GlobalVariables.MenuOptionColor);

                string choice = TextFormatter.GetUserInput("Choose an option:");

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

