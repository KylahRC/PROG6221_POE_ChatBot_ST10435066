namespace CybersecurityAwarenessBot
{
    public enum CatExpression
    {
        Happy,
        Curious,
        Sad,
        Loving,
        Confused,
        Explain
    }

    public static class CatExpressions
    {
        public static void DisplayCat(string message, CatExpression expression)
        {
            // If mute is enabled, override the expression to always use 'Sad'
            if (GlobalVariables.isMuted)
            {
                expression = CatExpression.Sad;
            }

            string catArt = expression switch
            {
                CatExpression.Happy => "\n  /\\      /\\     " +
                                       "\r\n /  \\____/  \\    " +
                                       "\r\n<            >\t " +
                                       "\r\n<   ^    ^   >   " +
                                       "\r\n \\    v     /    " +
                                       "\r\n  ~~~~~~~~~~",
                CatExpression.Curious => "\n  /\\      /\\     " +
                                         "\r\n /  \\____/  \\    " +
                                         "\r\n<            >\t " +
                                         "\r\n<   O    o   >   " +
                                         "\r\n \\    ?     /    " +
                                         "\r\n  ~~~~~~~~~~",
                CatExpression.Sad => "\n  /\\      /\\     " +
                                     "\r\n /  \\____/  \\    " +
                                     "\r\n<            >\t " +
                                     "\r\n<   T    T   >   " +
                                     "\r\n \\    ^     /    " +
                                     "\r\n  ~~~~~~~~~~",
                CatExpression.Loving => "\n  /\\      /\\     " +
                                         "\r\n /  \\____/  \\    " +
                                         "\r\n<            >\t " +
                                         "\r\n<   O    <3  >   " +
                                         "\r\n \\    w     /    " +
                                         "\r\n  ~~~~~~~~~~",
                CatExpression.Confused => "\n  /\\      /\\     " +
                                           "\r\n /  \\____/  \\    " +
                                           "\r\n<            >\t " +
                                           "\r\n<   Ò    ó   >   " +
                                           "\r\n \\    ?     /    " +
                                           "\r\n  ~~~~~~~~~~",
                CatExpression.Explain => "\n  /\\      /\\     " +
                                          "\r\n /  \\____/  \\    " +
                                          "\r\n<            >\t " +
                                          "\r\n<   O    O   >   " +
                                          "\r\n \\    0     /    " +
                                          "\r\n  ~~~~~~~~~~",
                _ => "\n  /\\      /\\     " +
                     "\r\n /  \\____/  \\    " +
                     "\r\n<            >\t " +
                     "\r\n<   ?    ?   >   " +
                     "\r\n \\    ?     /    " +
                     "\r\n  ~~~~~~~~~~"
            };

            // Display the cat expression and the message together as one entity
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(catArt);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

