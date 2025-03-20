using System;

//Still in prototype stages, some functions not working

//Voice Greeting: Not implemented
//Logo: Implemented
//Personalization: Not implemented
//Basic Responses: Prototyped
//Input Validation: Prototyped

namespace CybersecurityAwarenessBot
{
    class Program
    {
        static void DisplayAsciiArt() //displays the logo
        {
            //assigns the art to a string
            string asciiArt = @" 
     
                              ___           ___     
                  ___        /\  \         /\  \    
                 /\  \      /::\  \       /::\  \   
                 \:\  \    /:/\:\  \     /:/\ \  \  
                 /::\__\  /:/  \:\  \   _\:\~\ \  \ 
              __/:/\/__/ /:/__/ \:\__\ /\ \:\ \ \__\
             /\/:/  /    \:\  \  \/__/ \:\ \:\ \/__/
             \::/__/      \:\  \        \:\ \:\__\  
              \:\__\       \:\  \        \:\/:/  /  
               \/__/        \:\__\        \::/  /   
                             \/__/         \/__/    
              Irvine        Cyber        Security
                                
            ";
            Console.WriteLine(asciiArt); //outputs the logo string
        }

        enum CatExpression //set of contant "values" that I can reliably call linked to a specific cat face, allows for a wide array of expressions to be called easy
        {
            Happy,
            Curious,
            Sad,
            Loving,
            Confused
        }

        static void DisplayCat(string message, CatExpression expression) //method using the constants for expression and whatever needs to be said by the cat
        {
            string catArt = expression switch //using switch statement
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
                _ => "\n  /\\      /\\     " +
                     "\r\n /  \\____/  \\    " +
                     "\r\n<            >\t " +
                     "\r\n<   ?    ?   >   " +
                     "\r\n \\    ?     /    " +
                     "\r\n  ~~~~~~~~~~"
            };

            // Display the cat expression you want and the message together as one entity
            Console.WriteLine(catArt);
            Console.WriteLine($"| {message} |");
        }

        static void Main(string[] args)
        {
            //PlayVoiceGreeting(); //the method to play the greeting
            DisplayAsciiArt(); //show the logo
            GreetUser(); //the text greeting to start the program

        }

        /*static void PlayVoiceGreeting()
        {
            // Path to the WAV file
            string path = "path_to_your_greeting.wav";
            try
            {
                using (SoundPlayer player = new SoundPlayer(path))
                {
                    player.PlaySync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error playing audio: " + e.Message);
            }
        }*/

        static void GreetUser()
        {
            // Display a greeting with the happy cat
            DisplayCat("Hello! I am the CyberCat, your cybersecurity awareness assistant!", CatExpression.Happy);

            //need to add the name asks still

            // Main menu call
            MainMenu();
        }

        static void MainMenu() //the main menu display
        {
            bool exit = false;
            while (!exit)
            {
                DisplayCat("What do you want to do?", CatExpression.Curious);
                
                //options of what the user can do
                Console.WriteLine("1. Ask a question");
                Console.WriteLine("2. Pet the cat!");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine()?.Trim(); //gets the user choice

                switch (choice)
                {
                    case "1": //ask a question
                        AskQuestion(); //launch question protocall
                        break;
                    case "2": //give cat pets
                        DisplayCat("Aw, thanks! Im glad you like me!", CatExpression.Loving);
                        break;
                    case "3": //they want to leave
                        DisplayCat("Goodbye! Stay safe online!", CatExpression.Happy);
                        exit = true;
                        break;
                    default: //they typed something else
                        DisplayCat("Invalid input. Please choose 1, 2 or 3.", CatExpression.Confused);
                        break;
                }
            }
        }

        static void AskQuestion() //ask questions method
        {
            //dictionary of responses each linked to a keyword
            var responses = new System.Collections.Generic.Dictionary<string, string>
            {
                { "malware", "Malware is a program that wants to do bad things to your computer!" },
                { "password", "Passwords secure accounts. Use strong, unique ones, and never share them!" },
                { "virus", "Viruses are a type of malware. They can damage or delete your files!" }
            };

            bool wantsToQuit = false;

            while (!wantsToQuit)
            {
                //tell user what to do, may need tweaking
                DisplayCat("Type a topic to learn about (e.g., malware, password, virus), or type 'quit' to exit:", CatExpression.Curious);
                string question = Console.ReadLine()?.ToLower()?.Trim(); //dont consider blank spaces after answer

                if (question == "quit") //they want to leave
                {
                    wantsToQuit = true;
                }
                else if (string.IsNullOrWhiteSpace(question)) //checks if its blank OR invalid
                {
                    DisplayCat("Please enter a valid topic or type 'quit' to exit!", CatExpression.Sad);
                }
                else if (responses.ContainsKey(question)) //if ther answer mathes a keyword in the dictionary, show the info associated with keyword
                {
                    DisplayCat(responses[question], CatExpression.Happy);
                }
                else //keyword is not in dictionary
                {
                    DisplayCat("I don’t know about that topic yet. Can you try another?", CatExpression.Confused);
                }

            }
        }

    }
}

