namespace CybersecurityAwarenessBot
{
    public enum CatExpression
    {
        Happy,
        Curious,
        Sad,
        Loving,
        Confused,
        Explain,
        Depressed
    }

    public static class CatExpressions
    {
        public static void DisplayCat(string message, CatExpression expression)
        {
            // If mute is enabled, override the expression to always use 'Sad'
            if (GlobalVariables.isMuted)
            {
                expression = CatExpression.Depressed;
            }

            string catArt = expression switch
            {
                CatExpression.Happy =>    "\n  /\\_____/\\" +
                                        "\r\n /  ^   ^  \\" +
                                        "\r\n( ==  ^  == ) ,--." +
                                        "\r\n )         ( / ,-'" +
                                        "\r\n /         `. \\" +
                                        "\r\n |        _  \\ |" +
                                        "\r\n \\ \\ ,  /      |" +
                                        "\r\n  || |-_\\__   /" +
                                        "\r\n ((_/`(____,-'",

                                      
                CatExpression.Curious =>  "\n  /\\_____/\\" +
                                        "\r\n /  O   O  \\" +
                                        "\r\n( ==  ^  == ) ,--." +
                                        "\r\n )         ( / ,-'" +
                                        "\r\n /         `. \\" +
                                        "\r\n |        _  \\ |" +
                                        "\r\n \\ \\ ,  /      |" +
                                        "\r\n  || |-_\\__   /" +
                                        "\r\n ((_/`(____,-'",


                CatExpression.Sad =>  "\n_____________" +
                                    "\r\n\\   -   -   /" +
                                    "\r\n( ==  ^  == ) " +
                                    "\r\n )         (  \t" +
                                    "\r\n /         `.  " +
                                    "\r\n|         _  \\  \t" +
                                    "\r\n \\ \\ ,  /     \\._____.'; " +
                                    "\r\n  || |-_\\__   '......../" +
                                    "\r\n ((_/`(____,-'" +
                                    "\r\n",


                CatExpression.Loving =>   "\n  /\\_____/\\" +
                                        "\r\n /  u   u  \\" +
                                        "\r\n( ==  W  == ) ,--." +
                                        "\r\n )         ( / ,-'" +
                                        "\r\n /         `. \\" +
                                        "\r\n |        _  \\ |" +
                                        "\r\n \\ \\ ,  /      |" +
                                        "\r\n  || |-_\\__   /" +
                                        "\r\n ((_/`(____,-'",


                CatExpression.Confused =>     "\n  /\\_________" +
                                            "\r\n /  O   o   /" +
                                            "\r\n( ==  ?  == ) " +
                                            "\r\n )         (  \t____" +
                                            "\r\n /         `.  /  __)" +
                                            "\r\n|         _  \\/  /\t" +
                                            "\r\n \\ \\ ,  /       /" +
                                            "\r\n  || |-_\\__   /" +
                                            "\r\n ((_/`(____,-'" +
                                            "\r\n" ,
                                        


                CatExpression.Explain =>  "\n  /\\_____/\\" +
                                        "\r\n /  ^   ^  \\" +
                                        "\r\n( ==  0  == ) ,--." +
                                        "\r\n )         ( / ,-'" +
                                        "\r\n /         `. \\" +
                                        "\r\n |        _  \\ |" +
                                        "\r\n \\ \\ ,  /      |" +
                                        "\r\n  || |-_\\__   /" +
                                        "\r\n ((_/`(____,-'",

                CatExpression.Depressed =>    "\n   _______" +
                                            "\r\n  /_ ,_, _\\" +
                                            "\r\n    \\_^_/-..----." +
                                            "\r\n ___/ `   ' ,\"\"+ \\  " +
                                            "\r\n(__...'   __\\    |`.___.';" +
                                            "\r\n  (_,...'(_,.`__)/'.....+",

                _ => "\n  /\\      /\\     " +
                     "\r\n /  \\____/  \\    " +
                     "\r\n<            >\t " +
                     "\r\n<   ?    ?   >   " +
                     "\r\n \\    ?     /    " +
                     "\r\n  ~~~~~~~~~~"
            };

            // Display the cat expression and the message together as one entity
            Console.WriteLine("\u001b[38;2;196;138;116m" + catArt + "\u001b[0m");  // Custom ANSI color for cat art (#C48A74)
            Console.WriteLine("\u001b[38;2;125;218;88m" + message + "\u001b[0m");  // Custom ANSI color for message (#7DDA58)
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

//