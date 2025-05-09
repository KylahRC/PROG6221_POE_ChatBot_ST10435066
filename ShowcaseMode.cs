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

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Ask a question");
                Console.WriteLine("2. Pet the cat!");
                Console.WriteLine("3. Mute/Unmute the cat");
                Console.WriteLine("4. Exit");
                Console.ForegroundColor = ConsoleColor.White;

                // Simulated menu choice: Ask a Question
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("USER: 1 (Ask a question)");
                Console.ForegroundColor = ConsoleColor.White;
                CatExpressions.DisplayCat("Give me a topic and I'll tell you more about it, or type 'keywords' to see a list of topics I'm familiar with.", CatExpression.Happy);
                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Dialog"]);

                // Simulated asking personal questions
                foreach (var question in ChatbotUtilityFile.ChatbotResponses.PersonalQuestions.Keys)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"USER: {question}");
                    Console.ForegroundColor = ConsoleColor.White;
                    string response = ChatbotUtilityFile.ChatbotResponses.GetPersonalResponse(question);
                    CatExpressions.DisplayCat(response, CatExpression.Explain);
                    AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Talk"]);
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("USER: quit");
                Console.ForegroundColor = ConsoleColor.White;

                // Mute the chatbot
                GlobalVariables.isMuted = true;
                CatExpressions.DisplayCat("Oh... alright then, I'll be quiet...", CatExpression.Sad);
                Console.WriteLine("(We are muting the cat to speed up the showcase and to show what it is like when the cat is muted.)");
                Thread.Sleep(2000);

                // Simulated asking cybersecurity questions
                foreach (var question in ChatbotUtilityFile.ChatbotResponses.CybersecurityQuestions.Keys)
                {
                    Console.WriteLine($"USER: {question}");
                    string response = ChatbotUtilityFile.ChatbotResponses.GetCybersecurityResponse(question);
                    CatExpressions.DisplayCat(response, CatExpression.Explain);
                    if (!GlobalVariables.isMuted) AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Talk"]);
                    Thread.Sleep(2000);
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("USER: quit");
                Console.ForegroundColor = ConsoleColor.White;

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
                Console.WriteLine("Please restart the program, you cannot interact with the program normally after the showcase.");

                exit = true;
            }
        }
    }
}


