//namespace CybersecurityAwarenessBot
//{
//    public static class ShowcaseMode
//    {
//        public static void Execute()
//        {
//            // Step 1: Welcome message for showcase mode
//            CatExpressions.DisplayCat("Showcase started: Watch me interact!", CatExpression.Happy);
//            AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Excited"]);

//            bool exit = false; // Flag to track whether to exit the showcase mode
//            while (!exit)
//            {
//                // Step 2: Main menu (First interaction)
//                CatExpressions.DisplayCat($"What do you want to do, {GlobalVariables.userName}?", CatExpression.Curious);
//                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Curious"]);

//                Console.ForegroundColor = ConsoleColor.Blue;
//                Console.WriteLine("1. Ask a question");
//                Console.WriteLine("2. Pet the cat!");
//                Console.WriteLine("3. Mute/Unmute the cat");
//                Console.WriteLine("4. Exit");
//                Console.ForegroundColor = ConsoleColor.White;

//                // Step 3: First action → Mute the cat
//                Console.ForegroundColor = ConsoleColor.Cyan;
//                Console.WriteLine("USER: 3 (Mute the cat)"); // Simulated mute input
//                Console.ForegroundColor = ConsoleColor.White;

//                GlobalVariables.isMuted = true;
//                CatExpressions.DisplayCat("Oh... alright then, I'll be quiet...", CatExpression.Sad);
//                Console.WriteLine("(We are muting the cat to speed up the showcase and show what it’s like when muted.)");
//                Thread.Sleep(2000);

//                // Step 4: Simulate asking ALL personal questions
//                Console.ForegroundColor = ConsoleColor.Cyan;
//                Console.WriteLine("USER: 1 (Ask a question)");
//                Console.ForegroundColor = ConsoleColor.White;
//                CatExpressions.DisplayCat("Give me a topic and I'll tell you more about it, or type 'keywords' to see a list of topics I'm familiar with.", CatExpression.Happy);
//                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Dialog"]);

//                foreach (var question in ChatbotUtilityFile.ChatbotResponses.PersonalQuestions.Keys)
//                {
//                    Console.ForegroundColor = ConsoleColor.Cyan;
//                    Console.WriteLine($"USER: {question}"); // Simulated user input
//                    Console.ForegroundColor = ConsoleColor.White;
//                    string response = ChatbotUtilityFile.ChatbotResponses.GetPersonalResponse(question);
//                    CatExpressions.DisplayCat(response, CatExpression.Explain);
//                    if (!GlobalVariables.isMuted) AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Talk"]);
//                }

//                // Simulated "quit" input to return to main menu
//                Console.ForegroundColor = ConsoleColor.Cyan;
//                Console.WriteLine("USER: quit");
//                Console.ForegroundColor = ConsoleColor.White;

//                // Step 5: Main menu (Again)
//                CatExpressions.DisplayCat($"What do you want to do, {GlobalVariables.userName}?", CatExpression.Curious);
//                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Curious"]);

//                Console.ForegroundColor = ConsoleColor.Blue;
//                Console.WriteLine("1. Ask a question");
//                Console.WriteLine("2. Pet the cat!");
//                Console.WriteLine("3. Mute/Unmute the cat");
//                Console.WriteLine("4. Exit");
//                Console.ForegroundColor = ConsoleColor.Cyan;
//                Console.WriteLine("USER: 1 (Ask a question)");
//                Console.ForegroundColor = ConsoleColor.White;

//                // Step 6: Simulate asking ALL cybersecurity questions
//                foreach (var question in ChatbotUtilityFile.ChatbotResponses.CybersecurityQuestions.Keys)
//                {
//                    Console.ForegroundColor = ConsoleColor.Cyan;
//                    Console.WriteLine($"USER: {question}");
//                    Console.ForegroundColor = ConsoleColor.White;
//                    string response = ChatbotUtilityFile.ChatbotResponses.GetCybersecurityResponse(question);
//                    CatExpressions.DisplayCat(response, CatExpression.Explain);
//                    if (!GlobalVariables.isMuted) AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Talk"]);
//                    Thread.Sleep(2000);
//                }

//                // Simulated "quit" input to return to main menu
//                Console.ForegroundColor = ConsoleColor.Cyan;
//                Console.WriteLine("USER: quit");
//                Console.ForegroundColor = ConsoleColor.White;

//                // Step 7: Main menu (Again)
//                CatExpressions.DisplayCat($"What do you want to do, {GlobalVariables.userName}?", CatExpression.Curious);
//                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Curious"]);
//                Console.ForegroundColor = ConsoleColor.Blue;
//                Console.WriteLine("1. Ask a question");
//                Console.WriteLine("2. Pet the cat!");
//                Console.WriteLine("3. Mute/Unmute the cat");
//                Console.WriteLine("4. Exit");
//                Console.ForegroundColor = ConsoleColor.Cyan;
//                Console.WriteLine("USER: 3 (Unmute the cat)");
//                Console.ForegroundColor = ConsoleColor.White;

//                // Step 8: UNMUTE the cat
//                GlobalVariables.isMuted = false;
//                CatExpressions.DisplayCat("Yay! I'm so glad you changed your mind!", CatExpression.Happy);
//                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Excited"]);

//                // Step 9: Pet the cat
//                Console.ForegroundColor = ConsoleColor.Cyan;
//                Console.WriteLine("USER: 2 (Pet the cat)");
//                Console.ForegroundColor = ConsoleColor.White;
//                CatExpressions.DisplayCat(ChatbotUtilityFile.ChatbotResponses.GetRandomPetTheCatResponse(), CatExpression.Loving);
//                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Purr"]);

//                // Step 10: Exit program
//                Console.ForegroundColor = ConsoleColor.Cyan;
//                Console.WriteLine("USER: 4 (Exit)");
//                Console.ForegroundColor = ConsoleColor.White;
//                CatExpressions.DisplayCat(ChatbotUtilityFile.ChatbotResponses.GetRandomGoodbyeResponse(), CatExpression.Happy);
//                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Bye"]);

//                Console.WriteLine("Please restart the program, you cannot interact with the program normally after the showcase.");
//                exit = true;
//            }
//        }
//    }
//}
