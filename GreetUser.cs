namespace CybersecurityAwarenessBot
{
    public static class GreetUser
    {
        public static void Execute()
        {
            string greeting = ChatbotUtilityFile.ChatbotResponses.GetRandomGreeting();
            CatExpressions.DisplayCat(greeting, CatExpression.Happy);
            AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Excited"]); // Using AudioHelper

            bool gaveName = false;

            while (!gaveName)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("USER: ");
                GlobalVariables.userName = Console.ReadLine()?.Trim(); // Store globally
                Console.ForegroundColor = ConsoleColor.White;

                if (string.IsNullOrWhiteSpace(GlobalVariables.userName))
                {
                    string noNameResponse = ChatbotUtilityFile.ChatbotResponses.GetRandomNoNameResponse();
                    CatExpressions.DisplayCat(noNameResponse, CatExpression.Sad);
                    AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Sad"]);
                }
                else if (GlobalVariables.userName.ToLower() == "testingtesting123")
                {
                    CatExpressions.DisplayCat("Entering showcase mode...", CatExpression.Happy);
                    AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Excited"]);
                    ShowcaseMode.Execute();
                }
                else
                {
                    CatExpressions.DisplayCat($"Nice to meet you, {GlobalVariables.userName}! Let's get started!", CatExpression.Happy);
                    AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Excited"]);
                    gaveName = true;
                }
            }

            MainMenu.Execute(); // Call MainMenu from separate file
        }
    }
}

    


