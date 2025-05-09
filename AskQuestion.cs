namespace CybersecurityAwarenessBot
{
    public static class AskQuestion
    {
        public static void Execute()
        {
            bool wantsToQuit = false;

            while (!wantsToQuit)
            {
                CatExpressions.DisplayCat("Give me a topic and I'll tell you more about it, or type 'quit' to go back to the main menu. You can also type " +
                    "\"keywords\" to see a list of topics I'm familiar with.", CatExpression.Happy);
                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Dialog"]);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("USER: ");
                string question = Console.ReadLine()?.ToLower()?.Trim();
                Console.ForegroundColor = ConsoleColor.White;

                if (question == "quit")
                {
                    wantsToQuit = true;
                }
                else if (string.IsNullOrWhiteSpace(question))
                {
                    CatExpressions.DisplayCat(ChatbotUtilityFile.ChatbotResponses.GetRandomInvalidInputResponse(), CatExpression.Sad);
                    AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Sad"]);
                }
                else
                {
                    string personalResponse = ChatbotUtilityFile.ChatbotResponses.GetPersonalResponse(question);
                    string cybersecurityResponse = ChatbotUtilityFile.ChatbotResponses.GetCybersecurityResponse(question);

                    if (personalResponse != null)
                    {
                        string response = question == "how are you"
                            ? ChatbotUtilityFile.ChatbotResponses.GetRandomHowAreYouResponse()
                            : personalResponse;
                        CatExpressions.DisplayCat(response, CatExpression.Explain);
                        AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Talk"]);
                    }
                    else if (cybersecurityResponse != null)
                    {
                        string funPhrase = ChatbotUtilityFile.ChatbotResponses.GetRandomFunPhrase(question);
                        CatExpressions.DisplayCat(funPhrase, CatExpression.Curious);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(cybersecurityResponse);
                        Console.ForegroundColor = ConsoleColor.White;
                        AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Talk"]);
                    }
                    else
                    {
                        CatExpressions.DisplayCat(ChatbotUtilityFile.ChatbotResponses.GetRandomInvalidInputResponse(), CatExpression.Confused);
                        AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Curious"]);
                    }
                }
            }
        }
    }
}

