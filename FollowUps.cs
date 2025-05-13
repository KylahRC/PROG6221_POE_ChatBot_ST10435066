namespace CybersecurityAwarenessBot
{
    public class FollowUps
    {

        public static void DisplayFollowUpQuestions()
        {
            // Select the correct follow-up questions dictionary based on the topic.
            Dictionary<string, string> followUpQuestions = null;

            if (GlobalVariables.FollowUpTopic == "password") followUpQuestions = ChatbotUtilityFile.ChatbotResponses.PasswordFollowUpQuestions;
            else if (GlobalVariables.FollowUpTopic == "malware") followUpQuestions = ChatbotUtilityFile.ChatbotResponses.MalwareFollowUpQuestions;
            else if (GlobalVariables.FollowUpTopic == "phishing") followUpQuestions = ChatbotUtilityFile.ChatbotResponses.PhishingFollowUpQuestions;
            else if (GlobalVariables.FollowUpTopic == "safe browsing") followUpQuestions = ChatbotUtilityFile.ChatbotResponses.SafeBrowsingFollowUpQuestions;
            else if (GlobalVariables.FollowUpTopic == "virus") followUpQuestions = ChatbotUtilityFile.ChatbotResponses.VirusFollowUpQuestions;

            // Ensure the dictionary exists before displaying questions.
            if (followUpQuestions != null && followUpQuestions.Count > 0)
            {
                CatExpressions.DisplayCat($"Here are follow-up questions related to {GlobalVariables.FollowUpTopic}:", CatExpression.Curious);
                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Menu"]);

                // Convert the dictionary keys into a list for indexed access.
                List<string> keys = new List<string>(followUpQuestions.Keys);
                List<string> values = new List<string>(followUpQuestions.Values);

                // Loop through the dictionary using a standard for loop.
                for (int i = 0; i < keys.Count; i++)
                {
                    TextFormatter.SetColorText($"{keys[i]}. {values[i]}", GlobalVariables.MenuOptionColor);
                }
            }
            else
            {
                // Handle unknown topics.
                CatExpressions.DisplayCat("I don't have follow-up questions for this topic yet. Try another cybersecurity keyword!", CatExpression.Confused);
                TextFormatter.SetErrorMessageText($"Error: No follow up questions found about {GlobalVariables.FollowUpTopic} in database");
            }
        }

        public static void DisplayFollowUpAnswer()
        {
            // Select the correct follow-up answers dictionary based on the topic.
            Dictionary<string, string> followUpAnswers = null;

            if (GlobalVariables.FollowUpTopic == "password") followUpAnswers = ChatbotUtilityFile.ChatbotResponses.PasswordFollowUpAnswers;
            else if (GlobalVariables.FollowUpTopic == "malware") followUpAnswers = ChatbotUtilityFile.ChatbotResponses.MalwareFollowUpAnswers;
            else if (GlobalVariables.FollowUpTopic == "phishing") followUpAnswers = ChatbotUtilityFile.ChatbotResponses.PhishingFollowUpAnswers;
            else if (GlobalVariables.FollowUpTopic == "safe browsing") followUpAnswers = ChatbotUtilityFile.ChatbotResponses.SafeBrowsingFollowUpAnswers;
            else if (GlobalVariables.FollowUpTopic == "virus") followUpAnswers = ChatbotUtilityFile.ChatbotResponses.VirusFollowUpAnswers;

            // Validate that a correct dictionary exists and that the selected key exists.
            if (followUpAnswers != null && followUpAnswers.ContainsKey(GlobalVariables.FollowUpAnswerKey))
            {
                // Retrieve and display the selected answer.
                string answer = followUpAnswers[GlobalVariables.FollowUpAnswerKey];
                CatExpressions.DisplayCat($"Here's the answer for your follow-up question {GlobalVariables.userName}:", CatExpression.Explain);
                TextFormatter.SetCybersecurityText(answer);
                AudioHelper.PlayAudio(ChatbotUtilityFile.AudioFiles["Tip"]);
            }
            else
            {
                // Handle invalid selections gracefully.
                CatExpressions.DisplayCat("Oops! I couldn't find an answer for that question. Try selecting a valid follow-up number!", CatExpression.Confused);
                TextFormatter.SetErrorMessageText("Invalid follow-up answer selection.");
            }
        }
    }
}
