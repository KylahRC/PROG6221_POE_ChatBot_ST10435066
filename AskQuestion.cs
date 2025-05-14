namespace CybersecurityAwarenessBot
{
    public static class AskQuestion
    {

        // This method controls the chatbot, allowing the user to ask about cybersecurity topics.
        public static void Execute()
        {
            bool wantsToQuit = false; // Tracks whether the user wants to exit the chatbot.
                                      // Maintain a list of previously asked topics
            List<string> askedTopics = new List<string>();
            List<string> interestedIn = new List<string>();

            while (!wantsToQuit) // Keep running until the user decides to leave.
            {

                if (interestedIn.Count > 0)
                {
                    // Dynamically format the topics list into a readable string
                    string previousTopics = interestedIn.Count == 1
                        ? interestedIn[0]
                        : string.Join(", ", interestedIn.Take(interestedIn.Count - 1)) + " and " + interestedIn.Last();

                    // Display the message dynamically
                    CatExpressions.DisplayCat($"Tell me a cybersecurity topic, {GlobalVariables.userName}, and I'll start with a tip! I remember you liked talking about {previousTopics}, meow! " +
                        $"\nYou can also type 'list' to see a list of topics I know or type 'exit' to leave.", CatExpression.Curious);

                    AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Curious"]);
                }

                else
                {
                    // Ask the user for a cybersecurity topic or let them exit.
                    CatExpressions.DisplayCat($"Tell me a cybersecurity topic {GlobalVariables.userName}, and I'll start with a tip!"
                        + $"\nYou can also type 'list' to see a list of topics I know or type 'exit' to leave.", CatExpression.Curious);
                    AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Curious"]);
                }

                string question = TextFormatter.GetUserInput("USER:").ToLower().Trim(); // Get input, lowercase it, and clean spaces.

                if (string.IsNullOrWhiteSpace(question))
                {
                    CatExpressions.DisplayCat($"I don't see a topic {GlobalVariables.userName}, I can't help if you won't tell me", CatExpression.Sad);
                    TextFormatter.SetErrorMessageText($"Error: Input cannot be left empty, please enter a topic.");
                    AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Sad"]);
                }
                else if (question == "exit") // If the user wants to leave, exit the loop.
                {
                    CatExpressions.DisplayCat("Alright! Returning to the main menu.", CatExpression.Happy);
                    wantsToQuit = true;
                    break;
                }
                else if (question == "list")
                {
                    CatExpressions.DisplayCat($"Sure thing {GlobalVariables.userName}, heres a list of topics I know a lot about", CatExpression.Happy);
                    TextFormatter.SetColorText("- Malware", GlobalVariables.MenuOptionColor);
                    TextFormatter.SetColorText("- Virus", GlobalVariables.MenuOptionColor);
                    TextFormatter.SetColorText("- Phishing", GlobalVariables.MenuOptionColor);
                    TextFormatter.SetColorText("- Safe Browsing", GlobalVariables.MenuOptionColor);
                    TextFormatter.SetColorText("- Password", GlobalVariables.MenuOptionColor);
                    AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Menu"]);


                }
                else
                {
                    string correctedKeyword = KeywordCorrector.CorrectKeyword(question); // Ensure the keyword is properly formatted.
                    string detailedResponse = ChatbotUtilityFile.ChatbotResponses.GetDetailedResponse(correctedKeyword); // Get relevant info.
                    GlobalVariables.FollowUpTopic = correctedKeyword;

                    if (!interestedIn.Contains(correctedKeyword))
                    {
                    
                        // Check if topic was asked before and prompt user to confirm
                        if (askedTopics.Contains(correctedKeyword))
                        {
                            CatExpressions.DisplayCat($"You've already asked about '{correctedKeyword}', {GlobalVariables.userName}. Do you find this topic interesting?", CatExpression.Curious);
                            AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Curious"]);
                            string userConfirmation = TextFormatter.GetUserInput("USER:").ToLower().Trim();

                            if (userConfirmation == "no")
                            {
                                CatExpressions.DisplayCat("Oh, thats ok, its not for everyone", CatExpression.Sad);
                                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Sad"]);
                            }
                            else
                            {
                                CatExpressions.DisplayCat("That's great, Ill remember that!", CatExpression.Happy);
                                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Happy"]);
                                interestedIn.Add(correctedKeyword);
                            }
                        }
                        else
                        {

                            // Add the topic to the history list and proceed
                            askedTopics.Add(correctedKeyword);
                        }
                    }


                    if (detailedResponse == "I don't have details on that yet!")
                    {
                        CatExpressions.DisplayCat("I don't know about that one yet!", CatExpression.Sad);
                        TextFormatter.SetErrorMessageText($"Error: Invalid input, please try again.");
                        AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Sad"]);
                    }
                    else
                    
                        {
                        bool continueTopic = true;

                        // Give the user a short cybersecurity tip.
                        CatExpressions.DisplayCat($"Here's a tip about {correctedKeyword} {GlobalVariables.userName}:", CatExpression.Explain);
                        TextFormatter.SetCybersecurityText(ChatbotUtilityFile.ChatbotResponses.GetRandomShortTip(correctedKeyword));
                        AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Tip"]);

                        while (continueTopic) // Stay on this topic until the user wants to move on.
                        {
                           

                            // Ask the user what they want next.
                            CatExpressions.DisplayCat($"Would you like a detailed explanation {GlobalVariables.userName}? Select an option:", CatExpression.Curious);
                            TextFormatter.SetColorText("1. Yes, explain in detail", GlobalVariables.MenuOptionColor);
                            TextFormatter.SetColorText("2. Can I have another tip?", GlobalVariables.MenuOptionColor);
                            TextFormatter.SetColorText("3. No, move to a new topic", GlobalVariables.MenuOptionColor);
                            TextFormatter.SetColorText("4. Exit to main menu", GlobalVariables.MenuOptionColor);
                            AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Menu"]);

                            string detailedChoice = TextFormatter.GetUserInput("USER:");

                                switch (detailedChoice)
                                {
                                    case "4": // User wants to exit the chatbot.
                                        CatExpressions.DisplayCat("Alright! Returning to the main menu.", CatExpression.Happy);
                                        AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Happy"]);
                                        wantsToQuit = true;
                                        continueTopic = false;
                                        break;

                                    case "3": // Move to a new topic.
                                        CatExpressions.DisplayCat("Alright! Let's talk about something new.", CatExpression.Happy);
                                        AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Happy"]);
                                        continueTopic = false;
                                        break;

                                    case "2":
                                        // Give the user a short cybersecurity tip.
                                        CatExpressions.DisplayCat($"Sure, here's another tip about {correctedKeyword} {GlobalVariables.userName}:", CatExpression.Explain);
                                        TextFormatter.SetCybersecurityText(ChatbotUtilityFile.ChatbotResponses.GetRandomShortTip(correctedKeyword));
                                        AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Tip"]);
                                        break;

                                    case "1": // Provide a detailed explanation.
                                        CatExpressions.DisplayCat($"Here’s a detailed explanation of {correctedKeyword}:", CatExpression.Explain);
                                        TextFormatter.SetCybersecurityText(detailedResponse);
                                        AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Dialog"]);

                                        // Ask how the user feels about this info.
                                        CatExpressions.DisplayCat($"How do you feel after learning more information about {correctedKeyword} {GlobalVariables.userName}?", CatExpression.Curious);
                                        AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Curious"]);
                                        string userFeelingChoice = TextFormatter.GetUserInput("USER:");
                                        string feelingResponse = ChatbotUtilityFile.ChatbotResponses.GetFeelingResponse(correctedKeyword, userFeelingChoice);

                                        // Respond to the user's feelings.
                                        if (string.IsNullOrWhiteSpace(feelingResponse))
                                        {
                                            CatExpressions.DisplayCat($"That's okay {GlobalVariables.userName}, everyone has a unique way to look at the world.", CatExpression.Happy);
                                            AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Happy"]);
                                        }
                                        else
                                        {
                                            CatExpressions.DisplayCat(feelingResponse, CatExpression.Curious);
                                            AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Curious"]);
                                        }

                                        AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Dialog"]);

                                        bool wantsFollowUp = true;

                                        while (wantsFollowUp)
                                        {
                                            CatExpressions.DisplayCat($"Do you want to ask some follow up questions {GlobalVariables.userName}?", CatExpression.Curious);
                                            TextFormatter.SetColorText("1. Yes, show me a list of follow ups", GlobalVariables.MenuOptionColor);
                                            TextFormatter.SetColorText("2. No, move to a new topic", GlobalVariables.MenuOptionColor);
                                            AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Menu"]);
                                            string askFollowUp = TextFormatter.GetUserInput("USER:");

                                            if (askFollowUp == "2")
                                            {
                                                wantsFollowUp = false;

                                                continueTopic = false;
                                            }
                                            else if (askFollowUp == "1")
                                            {

                                                bool followUpLoop = true;

                                                while (followUpLoop) // Loop until the user decides to exit.
                                                {
                                                    // Call FollowUpTopicHandler to display the relevant follow-up questions.
                                                    FollowUps.DisplayFollowUpQuestions();

                                                    // Get user selection.
                                                    string followUpChoice = TextFormatter.GetUserInput("USER:");
                                                    GlobalVariables.FollowUpAnswerKey = followUpChoice;

                                                    switch (followUpChoice)
                                                    {
                                                        case "4": // Move to a new topic.
                                                            CatExpressions.DisplayCat("Alright! Let's move on to a new topic.", CatExpression.Happy);
                                                            AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Happy"]);
                                                            followUpLoop = false;
                                                            continueTopic = false;
                                                            wantsFollowUp = false;
                                                            break;

                                                        default:
                                                            FollowUps.DisplayFollowUpAnswer();
                                                            break;


                                                    }
                                                }
                                            }
                                            else
                                            {
                                                CatExpressions.DisplayCat("Thats not one of the options silly!", CatExpression.Confused);                                            
                                                TextFormatter.SetErrorMessageText($"Error: Invalid input, please try again.");
                                                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Happy"]);
                                            }
                                        }
                                        break;

                                    default:
                                        CatExpressions.DisplayCat("Thats not one of the options silly!", CatExpression.Confused);
                                        TextFormatter.SetErrorMessageText($"Error: Invalid input, please try again.");
                                        break;
                                }
                            
                        }
                    }
                }
            }
        }
    }
}
