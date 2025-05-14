using System.Text.RegularExpressions;

namespace CybersecurityAwarenessBot
{
    public static class GreetUser
    {
        // This method handles the chatbot’s greeting sequence.
        // Its job? Say hi, get the user's name, and avoid awkward silence.
        public static void Execute()
        {
            // Step 1: Get a random greeting response from the chatbot's predefined messages.
            // Because nobody likes a boring bot that always says "Hello."
            string greeting = ChatbotUtilityFile.ChatbotResponses.GetRandomGreeting();
            CatExpressions.DisplayCat(greeting, CatExpression.Curious); // Display the greeting alongside a cat face.
            AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Greeting"]); // Play an audio clip to make the greeting more lively.

            bool gaveName = false; // Keeps track of whether the user has given a name.

            while (!gaveName) // This loop forces the user to give a name before moving forward.
            {
                // Step 2: Ask for the user’s name.
                // If they type nonsense, they get stuck with that as their name, not the bots fault they think they're funny.
                GlobalVariables.userName = TextFormatter.GetUserInput("USER:"); // Prompt user for input.

                if (string.IsNullOrWhiteSpace(GlobalVariables.userName)) // If the user refuses to cooperate...
                {
                    // Step 3: If they enter an empty string or just spaces, they get passive-aggressively encouraged to try again.
                    string noNameResponse = ChatbotUtilityFile.ChatbotResponses.GetRandomNoNameResponse();
                    CatExpressions.DisplayCat(noNameResponse, CatExpression.Sad); // Display sad cat face because we're disappointed.
                    AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Sad"]); // Play a sad sound to emphasize our disappointment.
                    TextFormatter.SetErrorMessageText("Please enter a username to continue");
                }
                //else if (GlobalVariables.userName.ToLower() == "testingtesting123") // Secret input for entering Showcase Mode.
                //{
                //    // Step 4: Special case where the user activates showcase mode.

                //    CatExpressions.DisplayCat("Entering showcase mode...", CatExpression.Happy);
                //    AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Excited"]);
                //    ShowcaseMode.Execute(); // Runs Showcase Mode.
                //}
                else if (Regex.IsMatch(GlobalVariables.userName, @"\W") && Regex.IsMatch(GlobalVariables.userName, @"\d"))
                {
                    CatExpressions.DisplayCat("I would prefer if you didn't give me your gamertag, meow!", CatExpression.Confused);
                    TextFormatter.SetErrorMessageText($"Error: Name may not contain numbers, please try again.");
                    AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Sad"]);
                }
                else if (Regex.IsMatch(GlobalVariables.userName, @"\W"))
                {
                    CatExpressions.DisplayCat("Human names don't have symbols in them silly!", CatExpression.Confused);
                    TextFormatter.SetErrorMessageText($"Error: Name may not contain numbers, please try again.");
                    AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Sad"]);
                }
                else if (Regex.IsMatch(GlobalVariables.userName, @"\d"))
                {
                    CatExpressions.DisplayCat("Human names don't have numbers in them silly!", CatExpression.Confused);
                    TextFormatter.SetErrorMessageText($"Error: Name may not contain numbers, please try again.");
                    AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Sad"]);
                }
            
                else // User FINALLY gives a name.
                {
                    // Step 5: Store the name and move on.
                    // The chatbot acts way too enthusiastic about knowing your name.
                    CatExpressions.DisplayCat($"Nice to meet you, {GlobalVariables.userName}! Let's get started!", CatExpression.Happy);
                    AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Excited"]);
                    gaveName = true; // Finally let them proceed.
                }
            }

            // Step 6: Move on to the main menu
            MainMenu.Execute();
        }
    }
}
