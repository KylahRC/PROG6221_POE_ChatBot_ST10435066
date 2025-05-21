namespace CybersecurityAwarenessBot
{
    public static class GlobalVariables
    {
        //a global variable to store the user's name so every method can access it
        public static string userName;

        public static string IntroFilePath;
        public static string ExcitedFilePath;
        public static string SadFilePath;
        public static string CuriousFilePath;
        public static string DialogFilePath;
        public static string TalkFilePath;
        public static string PurrFilePath;
        public static string ByeFilePath;
        public static string GreetingFilePath;
        public static string TipFilePath;
        public static string MenuFilePath;


       

        //global mute variable
        public static bool isMuted = false;

        public static string FollowUpTopic;

        public static string FollowUpAnswerKey;

        // ANSI escape sequences for custom colors
        public static readonly string UserInputColor = "\u001b[38;2;201;73;236m";  // Purple (#C949EC)
        public static readonly string MenuOptionColor = "\u001b[38;2;0;122;204m";  // Blue (#007ACC)
        public static readonly string CybersecurityColor = "\u001b[38;2;250;141;57m";  // Orange (#FA8D39)
        public static readonly string ErrorMessageColor = "\u001b[38;2;244;78;78m";  // Red (#F44E4E)
        public static readonly string DefaultColor = "\u001b[0m";  // Reset to default
    }
}
//