//namespace CybersecurityAwarenessBot
//{
//    public static class ShowcaseMode
//    {
//        public static void Execute()
//        {
//            // Step 1: Welcome message for showcase mode
//            CatExpressions.DisplayCat("Showcase started: Watch me interact!", CatExpression.Happy);
//            AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Excited"]);

//            bool exit = false;

//            while (!exit)
//            {
//                // Step 2: Main menu
//                CatExpressions.DisplayCat($"What do you want to do, {GlobalVariables.userName}?", CatExpression.Curious);
//                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Curious"]);

//                TextFormatter.SetColorText("1. Ask a question", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("2. Pet the cat!", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("3. Mute/Unmute the cat", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("4. Exit", GlobalVariables.MenuOptionColor);

//                // Step 3: First action → Mute the chatbot
//                TextFormatter.SetColorText("USER: 3 (Mute the cat)", GlobalVariables.UserInputColor);

//                GlobalVariables.isMuted = true;
//                CatExpressions.DisplayCat("Oh... alright then, I'll be quiet...", CatExpression.Sad);
//                TextFormatter.SetErrorMessageText("(Chatbot muted for fast showcase execution.)");
//                Thread.Sleep(2000);

//                // Step 4: Ask all personal questions
//                CatExpressions.DisplayCat($"What do you want to do, {GlobalVariables.userName}?", CatExpression.Curious);
//                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Curious"]);

//                TextFormatter.SetColorText("1. Ask a question", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("2. Pet the cat!", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("3. Mute/Unmute the cat", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("4. Exit", GlobalVariables.MenuOptionColor);

//                TextFormatter.SetColorText("USER: 1 (Ask a question)", GlobalVariables.UserInputColor);
//                CatExpressions.DisplayCat("Give me a topic and I'll tell you more about it, or type 'keywords' to see a list of topics I'm familiar with.", CatExpression.Happy);
//                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Dialog"]);

//                foreach (var question in ChatbotUtilityFile.ChatbotResponses.PersonalQuestions.Keys)
//                {
//                    TextFormatter.SetColorText($"USER: {question}", GlobalVariables.UserInputColor);
//                    string response = ChatbotUtilityFile.ChatbotResponses.GetPersonalResponse(question);
//                    CatExpressions.DisplayCat(response, CatExpression.Explain);
//                    if (!GlobalVariables.isMuted) AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Talk"]);
//                }

//                TextFormatter.SetColorText("USER: quit", GlobalVariables.UserInputColor);

//                // Step 5: Main menu (Again)
//                CatExpressions.DisplayCat($"What do you want to do, {GlobalVariables.userName}?", CatExpression.Curious);
//                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Curious"]);

//                TextFormatter.SetColorText("1. Ask a question", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("2. Pet the cat!", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("3. Mute/Unmute the cat", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("4. Exit", GlobalVariables.MenuOptionColor);


                
//                // Step 2: User chooses "Ask a Question" → Start malware sequence
//                TextFormatter.SetColorText("USER: 1 (Ask a question)", GlobalVariables.UserInputColor);
//                CatExpressions.DisplayCat("Tell me a cybersecurity topic, and I'll start with a tip! Or if you want to go back to the main menu, type 'exit'.", CatExpression.Happy);
//                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Dialog"]);

//                TextFormatter.SetColorText("USER: malware", GlobalVariables.UserInputColor);
//                string malwareTip = ChatbotUtilityFile.ChatbotResponses.GetRandomShortTip("malware");
//                CatExpressions.DisplayCat($"Here's a tip about malware:\n{malwareTip}", CatExpression.Explain);
//                Thread.Sleep(2000);

//                // Step 3: Ask for a detailed explanation
//                CatExpressions.DisplayCat("Would you like a detailed explanation? Select an option:", CatExpression.Curious);
//                TextFormatter.SetColorText("1. Yes, explain in detail", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("2. No, move to a new topic", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("3. Exit to main menu", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("USER: 1", GlobalVariables.UserInputColor);

//                string malwareDetails = ChatbotUtilityFile.ChatbotResponses.GetDetailedResponse("malware");
//                CatExpressions.DisplayCat($"Here's a detailed explanation of malware:\n{malwareDetails}", CatExpression.Explain);
//                Thread.Sleep(3000);

//                // Step 4: Ask how user feels about malware
//                CatExpressions.DisplayCat("How do you feel about malware?", CatExpression.Curious);
//                TextFormatter.SetColorText("USER: worried", GlobalVariables.UserInputColor);
//                string malwareFeeling = ChatbotUtilityFile.ChatbotResponses.GetFeelingResponse("malware", "worried");
//                CatExpressions.DisplayCat(malwareFeeling, CatExpression.Explain);
//                Thread.Sleep(2000);

//                // Step 5: Ask follow-up questions
//                CatExpressions.DisplayCat("Would you like to explore one of these?", CatExpression.Curious);
//                List<string> followUpOptions = ChatbotUtilityFile.ChatbotResponses.GetFollowUpQuestions("malware");
//                for (int i = 0; i < followUpOptions.Count; i++)
//                {
//                    TextFormatter.SetColorText($"{i + 1}. {followUpOptions[i]}", GlobalVariables.MenuOptionColor);
//                }
//                TextFormatter.SetColorText("USER: 1", GlobalVariables.UserInputColor);
//                string firstFollowUp = ChatbotUtilityFile.ChatbotResponses.GetFollowUpAnswer(followUpOptions[0]);
//                TextFormatter.SetCybersecurityText(firstFollowUp);
//                Thread.Sleep(2000);

//                // Step 6: Ask another follow-up or move on
//                CatExpressions.DisplayCat("Would you like to ask another follow-up question or move on?", CatExpression.Curious);
//                TextFormatter.SetColorText("1. Ask another follow-up question", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("2. Move to a new topic", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("USER: 1", GlobalVariables.UserInputColor);

//                CatExpressions.DisplayCat("Would you like to explore one of these?", CatExpression.Curious);
//                for (int i = 0; i < followUpOptions.Count; i++)
//                {
//                    TextFormatter.SetColorText($"{i + 1}. {followUpOptions[i]}", GlobalVariables.MenuOptionColor);
//                }
//                TextFormatter.SetColorText("USER: 2", GlobalVariables.UserInputColor);
//                string secondFollowUp = ChatbotUtilityFile.ChatbotResponses.GetFollowUpAnswer(followUpOptions[1]);
//                TextFormatter.SetCybersecurityText(secondFollowUp);
//                Thread.Sleep(2000);

//                // Step 7: Move to phishing test with misspelled keyword
//                TextFormatter.SetColorText("USER: Move to a new topic", GlobalVariables.UserInputColor);
//                Thread.Sleep(1000);

//                // Step 7.1: Phishing test with keyword correction
//                string incorrectKeyword = "phisihng";
//                string correctedKeyword = KeywordCorrector.CorrectKeyword(incorrectKeyword);

//                TextFormatter.SetColorText($"USER: {incorrectKeyword} (Intentional misspelling)", GlobalVariables.UserInputColor);
//                TextFormatter.SetCybersecurityText($"Corrected to: {correctedKeyword}");
//                Thread.Sleep(1000);

               
                

//                // Display brief phishing response
//                string phishingTip = ChatbotUtilityFile.ChatbotResponses.GetRandomShortTip(correctedKeyword);
//                CatExpressions.DisplayCat($"Here's a tip about phishing:\n{phishingTip}", CatExpression.Explain);
//                Thread.Sleep(2000);

//                // Step 8: Ask for a detailed phishing explanation and return to menu
//                CatExpressions.DisplayCat("Would you like a detailed explanation? Select an option:", CatExpression.Curious);
//                TextFormatter.SetColorText("1. Yes, explain in detail", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("2. No, move to a new topic", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("3. Exit to main menu", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("USER: 3", GlobalVariables.UserInputColor);

//                CatExpressions.DisplayCat("Alright! Returning to the main menu.", CatExpression.Happy);
//                Thread.Sleep(2000);

//                TextFormatter.SetColorText("USER: quit", GlobalVariables.UserInputColor);
//                CatExpressions.DisplayCat($"What do you want to do, {GlobalVariables.userName}?", CatExpression.Curious);
//                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Curious"]);

//                TextFormatter.SetColorText("1. Ask a question", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("2. Pet the cat!", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("3. Mute/Unmute the cat", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("4. Exit", GlobalVariables.MenuOptionColor);

//                // Step 7: Unmute the chatbot
//                TextFormatter.SetColorText("USER: 3 (Unmute the cat)", GlobalVariables.UserInputColor);
//                GlobalVariables.isMuted = false;
//                CatExpressions.DisplayCat("Yay! I'm so glad you changed your mind!", CatExpression.Happy);
//                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Excited"]);

//                // Step 8: Pet the cat
//                CatExpressions.DisplayCat($"What do you want to do, {GlobalVariables.userName}?", CatExpression.Curious);
//                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Curious"]);

//                TextFormatter.SetColorText("1. Ask a question", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("2. Pet the cat!", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("3. Mute/Unmute the cat", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("4. Exit", GlobalVariables.MenuOptionColor);

//                TextFormatter.SetColorText("USER: 2 (Pet the cat)", GlobalVariables.UserInputColor);
//                CatExpressions.DisplayCat(ChatbotUtilityFile.ChatbotResponses.GetRandomPetTheCatResponse(), CatExpression.Loving);
//                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Purr"]);

//                // Step 9: Exit program
//                CatExpressions.DisplayCat($"What do you want to do, {GlobalVariables.userName}?", CatExpression.Curious);
//                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Curious"]);

//                TextFormatter.SetColorText("1. Ask a question", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("2. Pet the cat!", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("3. Mute/Unmute the cat", GlobalVariables.MenuOptionColor);
//                TextFormatter.SetColorText("4. Exit", GlobalVariables.MenuOptionColor);

//                TextFormatter.SetColorText("USER: 4 (Exit)", GlobalVariables.UserInputColor);
//                CatExpressions.DisplayCat(ChatbotUtilityFile.ChatbotResponses.GetRandomGoodbyeResponse(), CatExpression.Happy);
//                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Bye"]);

//                TextFormatter.SetErrorMessageText("Please restart the program, you cannot interact with it normally after the showcase.");

//                exit = true;
//            }
//        }
//    }
//}
