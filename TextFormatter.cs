namespace CybersecurityAwarenessBot
{
    public static class TextFormatter
    {
        public static void SetColorText(string text, string color)
        {
            Console.WriteLine($"{color}{text}{GlobalVariables.DefaultColor}");
        }

        public static string GetUserInput(string prompt)
        {
            Console.Write($"{GlobalVariables.UserInputColor}{prompt}{GlobalVariables.DefaultColor} ");
            return Console.ReadLine()?.Trim();
        }

        public static void SetCybersecurityText(string text)
        {
            Console.WriteLine($"{GlobalVariables.CybersecurityColor}{text}{GlobalVariables.DefaultColor}");
        }

        public static void SetErrorMessageText(string text)
        {
            Console.WriteLine($"{GlobalVariables.ErrorMessageColor}{text}{GlobalVariables.DefaultColor}");
        }
    }
}
