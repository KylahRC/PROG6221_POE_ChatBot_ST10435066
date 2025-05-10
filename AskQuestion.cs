namespace CybersecurityAwarenessBot
{
    public static class AskQuestion
    {
        // This method controls the entire chatbot questioning system.
        // The program loops until the user either learns enough cybersecurity or gets tired of talking to Cyercat.
        public static void Execute()
        {
            bool wantsToQuit = false; // Tracks whether the user wants to quit the questioning process.

            while (!wantsToQuit) // This loop keeps running until the user decides they've had enough.
            {
                // Welcoming the user with an introduction message.
                // If they don't want to talk about cybersecurity, they can type 'exit' to escape.
                CatExpressions.DisplayCat("Tell me a cybersecurity topic, and I'll start with a tip! Or if you want to go back to the main menu, type 'exit'", CatExpression.Curious);
                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Curious"]);

                // Getting user input, making it lowercase, and trimming unnecessary spaces to avoid having to error handle that.
                string question = TextFormatter.GetUserInput("USER:").ToLower().Trim();

                // If the user wants out, we let them go.
                if (question == "exit")
                {
                    CatExpressions.DisplayCat("Alright! Returning to the main menu.", CatExpression.Happy);
                    wantsToQuit = true; // Set flag to exit the program loop.
                    break; // We out this loop.
                }

                // Cleaning up the user's input to make sure it's properly formatted before searching for responses.
                string correctedKeyword = KeywordCorrector.CorrectKeyword(question);

                // Checking if the chatbot actually knows anything about the topic the user entered.
                string detailedResponse = ChatbotUtilityFile.ChatbotResponses.GetDetailedResponse(correctedKeyword);

                if (detailedResponse != "I don't have details on that yet!") // If we have something to say, proceed.
                {
                    bool continueTopic = true; // Keeps the user focused in the current topic.

                    while (continueTopic) // Loop while the user wants to keep talking.
                    {
                        // Step 1: The bot gives a short tip automatically.
                        // Whether the user wanted one or not, they're getting cybersecurity wisdom.
                        CatExpressions.DisplayCat($"Here's a tip about {correctedKeyword}:", CatExpression.Explain);
                        TextFormatter.SetCybersecurityText(ChatbotUtilityFile.ChatbotResponses.GetRandomShortTip(correctedKeyword));
                        AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Talk"]);

                        // Step 2: Offer a choice of more details, a new topic, or escape to the main menu.
                        CatExpressions.DisplayCat("Would you like a detailed explanation? Select an option:", CatExpression.Curious);
                        TextFormatter.SetColorText("1. Yes, explain in detail", GlobalVariables.MenuOptionColor);
                        TextFormatter.SetColorText("2. No, move to a new topic", GlobalVariables.MenuOptionColor);
                        TextFormatter.SetColorText("3. Exit to main menu", GlobalVariables.MenuOptionColor);

                        string detailedChoice = TextFormatter.GetUserInput("USER:");

                        if (detailedChoice == "3") // User has had enough, time to exit.
                        {
                            CatExpressions.DisplayCat("Alright! Returning to the main menu.", CatExpression.Happy);
                            wantsToQuit = true;
                            break; // Escape the loop.
                        }
                        else if (detailedChoice == "1") // User actually wants more cybersecurity knowledge.
                        {
                            // Step 3: Provide a detailed explanation.
                            CatExpressions.DisplayCat($"Here’s a detailed explanation of {correctedKeyword}:", CatExpression.Explain);
                            TextFormatter.SetCybersecurityText(detailedResponse);
                            AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Talk"]);

                            // Step 4: Ask how the user feels about this life-changing cybersecurity revelation.
                            CatExpressions.DisplayCat($"How do you feel about {correctedKeyword}?", CatExpression.Curious);
                            string userFeelingChoice = TextFormatter.GetUserInput("USER:");

                            // Step 5: Validate the user's feelings using predefined responses.
                            string feelingResponse = ChatbotUtilityFile.ChatbotResponses.GetFeelingResponse(correctedKeyword, userFeelingChoice);

                            // If the response doesn't exist in the dictionary, provide a backup response.
                            if (string.IsNullOrWhiteSpace(feelingResponse) || feelingResponse == "")
                            {
                                CatExpressions.DisplayCat("That's okay, everyone has a unique way to look at the world.", CatExpression.Curious);
                            }
                            else
                            {
                                CatExpressions.DisplayCat(feelingResponse, CatExpression.Curious);
                                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Talk"]);
                            }


                            // Step 6: Offer follow-up questions, because cybersecurity is never-ending.
                            List<string> followUpQuestions = ChatbotUtilityFile.ChatbotResponses.GetFollowUpQuestions(correctedKeyword);

                            // Ensure that follow-up questions exist before proceeding.
                            if (followUpQuestions.Count > 0)
                            {
                                bool followUpLoop = true;

                                while (followUpLoop) // Keep looping until the user actively decides to exit.
                                {
                                    CatExpressions.DisplayCat("Would you like to explore one of these?", CatExpression.Curious);

                                    int questionNumber = 1;
                                    Dictionary<string, string> followUpMap = new Dictionary<string, string>();

                                    // Present each follow-up question as a numbered option.
                                    foreach (string followUp in followUpQuestions)
                                    {
                                        TextFormatter.SetColorText($"{questionNumber}. {followUp}", GlobalVariables.MenuOptionColor);
                                        followUpMap[questionNumber.ToString()] = followUp;
                                        questionNumber++;
                                    }

                                    // Provide an option to exit directly instead of trapping users in an endless loop.
                                    TextFormatter.SetColorText($"{questionNumber}. Move to a new topic", GlobalVariables.MenuOptionColor);
                                    followUpMap[questionNumber.ToString()] = "Move to a new topic";

                                    string followUpChoice = TextFormatter.GetUserInput("USER:");

                                    if (followUpMap.ContainsKey(followUpChoice) && followUpMap[followUpChoice] != "Move to a new topic")
                                    {
                                        // Step 7: Fetch and display the answer to the selected follow-up question.
                                        string selectedQuestion = followUpMap[followUpChoice];
                                        string followUpResponse = ChatbotUtilityFile.ChatbotResponses.GetFollowUpAnswer(selectedQuestion);

                                        TextFormatter.SetCybersecurityText(followUpResponse);
                                        AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Talk"]);

                                        // Instead of forcing another loop, reconfirm with the user whether they want another follow-up question.
                                        CatExpressions.DisplayCat("Would you like to ask another follow-up question or move on?", CatExpression.Curious);
                                        TextFormatter.SetColorText("1. Ask another follow-up question", GlobalVariables.MenuOptionColor);
                                        TextFormatter.SetColorText("2. Move to a new topic", GlobalVariables.MenuOptionColor);

                                        string nextChoice = TextFormatter.GetUserInput("USER:");

                                        if (nextChoice == "2")
                                        {
                                            followUpLoop = false;
                                            continueTopic = false;
                                        }
                                    }
                                    else if (followUpMap.ContainsKey(followUpChoice) && followUpMap[followUpChoice] == "Move to a new topic")
                                    {
                                        // User wants to exit—break out of the loop.
                                        CatExpressions.DisplayCat("Alright! Let's move on to a new topic.", CatExpression.Happy);
                                        followUpLoop = false;
                                        continueTopic = false;
                                    }
                                    else
                                    {
                                        // Invalid input handling—prompt them to choose a valid number.
                                        CatExpressions.DisplayCat("Oops! Please enter a valid number from the list.", CatExpression.Confused);
                                        TextFormatter.SetErrorMessageText("Invalid choice. Please select an option from the list.");
                                    }
                                }
                            }
                        }
                    }
                }

            }
        }
    }
}