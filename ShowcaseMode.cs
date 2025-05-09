namespace CybersecurityAwarenessBot
{
    public static class ShowcaseMode
    {
        public static void Execute()
        {
            // Welcome message for showcase mode
            CatExpressions.DisplayCat("Showcase started: Watch me interact!", CatExpression.Happy);
            AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Excited"]);

            bool exit = false;
            while (!exit)
            {
                CatExpressions.DisplayCat($"What do you want to do, {GlobalVariables.userName}?", CatExpression.Curious);
                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Curious"]);

                // Display menu options with centralized color formatting
                TextFormatter.SetColorText("1. Ask a question", GlobalVariables.MenuOptionColor);
                TextFormatter.SetColorText("2. Pet the cat!", GlobalVariables.MenuOptionColor);
                TextFormatter.SetColorText("3. Mute/Unmute the cat", GlobalVariables.MenuOptionColor);
                TextFormatter.SetColorText("4. Exit", GlobalVariables.MenuOptionColor);

                // Get user input with color formatting
                string choice = TextFormatter.GetUserInput("USER:");

                CatExpressions.DisplayCat("Give me a topic and I'll tell you more about it, or type 'keywords' to see a list of topics I'm familiar with.", CatExpression.Happy);
                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Dialog"]);

                // Simulated asking personal questions
                foreach (var question in ChatbotUtilityFile.ChatbotResponses.PersonalQuestions.Keys)
                {
                    TextFormatter.SetColorText($"USER: {question}", GlobalVariables.UserInputColor);
                    string response = ChatbotUtilityFile.ChatbotResponses.GetPersonalResponse(question);
                    CatExpressions.DisplayCat(response, CatExpression.Explain);
                    AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Talk"]);
                }

                TextFormatter.SetColorText("USER: quit", GlobalVariables.UserInputColor);

                // Mute the chatbot
                GlobalVariables.isMuted = true;
                CatExpressions.DisplayCat("Oh... alright then, I'll be quiet...", CatExpression.Sad);
                TextFormatter.SetColorText("(We are muting the cat to speed up the showcase and to show what it is like when the cat is muted.)", GlobalVariables.MenuOptionColor);
                Thread.Sleep(2000);

                // Simulated asking cybersecurity questions
                foreach (var question in ChatbotUtilityFile.ChatbotResponses.CybersecurityQuestions.Keys)
                {
                    TextFormatter.SetColorText($"USER: {question}", GlobalVariables.UserInputColor);
                    string response = ChatbotUtilityFile.ChatbotResponses.GetCybersecurityResponse(question);
                    CatExpressions.DisplayCat(response, CatExpression.Explain);
                    if (!GlobalVariables.isMuted) AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Talk"]);
                    Thread.Sleep(2000);
                }

                TextFormatter.SetColorText("USER: quit", GlobalVariables.UserInputColor);

                // Unmute the chatbot
                GlobalVariables.isMuted = false;
                CatExpressions.DisplayCat("Yay! I'm so glad you changed your mind!", CatExpression.Happy);
                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Excited"]);

                // Pet the cat interaction
                CatExpressions.DisplayCat(ChatbotUtilityFile.ChatbotResponses.GetRandomPetTheCatResponse(), CatExpression.Loving);
                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Purr"]);

                // Exit showcase mode
                CatExpressions.DisplayCat(ChatbotUtilityFile.ChatbotResponses.GetRandomGoodbyeResponse(), CatExpression.Happy);
                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Bye"]);
                TextFormatter.SetColorText("Please restart the program, you cannot interact with the program normally after the showcase.", GlobalVariables.MenuOptionColor);

                exit = true;

            }
        }
    }
}


