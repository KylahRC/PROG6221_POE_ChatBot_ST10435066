using System.Text.RegularExpressions;

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
                

                TextFormatter.SetColorText("1. Ask a question", GlobalVariables.MenuOptionColor);
                TextFormatter.SetColorText("2. Pet the cat!", GlobalVariables.MenuOptionColor);
                TextFormatter.SetColorText("3. Mute/Unmute the cat", GlobalVariables.MenuOptionColor);
                TextFormatter.SetColorText("4. Exit", GlobalVariables.MenuOptionColor);

                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Menu"]);

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
                        string muteMessage;

                        if (GlobalVariables.isMuted)
                        {
                            muteMessage = "Oh... alright then, I'll be quiet...";
                            CatExpressions.DisplayCat(muteMessage, CatExpression.Sad);
                        }
                        else
                        {
                            muteMessage = "Yay! I'm so glad you changed your mind!";
                            CatExpressions.DisplayCat(muteMessage, CatExpression.Happy);
                            AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Excited"]);
                        }

                        break;
                    case "4":
                        string goodbyeResponse = ChatbotUtilityFile.ChatbotResponses.GetRandomGoodbyeResponse();
                        CatExpressions.DisplayCat(goodbyeResponse, CatExpression.Happy);
                        AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Bye"]);
                        exit = true;
                        break;
                    default:

                        if (Regex.IsMatch(choice, @"[a-zA-Z]") || Regex.IsMatch(choice, @"\W"))
                        {
                            CatExpressions.DisplayCat("Please type the number of the option you want to chose!", CatExpression.Confused);
                            TextFormatter.SetErrorMessageText($"Error: Input must contail numbers only, please try again.");
                            AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Sad"]);
                        }
                        else
                        {
                            CatExpressions.DisplayCat("That's not one of the options silly!", CatExpression.Confused);
                            TextFormatter.SetErrorMessageText($"Error: Invalid option selected, please try again.");
                            AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Sad"]);
                        }
                        break;
                }
            }
        }
    }
}

//