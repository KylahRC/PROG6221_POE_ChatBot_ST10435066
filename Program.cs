using System;
using System.Media;


//Still in prototype stages, some functions not working

//Voice Greeting: Implemented
//Logo: Implemented
//Personalization: Almost perfect
//Basic Responses: Almost perfect
//Input Validation: Almost perfect
//Colourfulness: Almost perfect


namespace CybersecurityAwarenessBot
{
    class Program
    {
        // A global variable to store the user's name
        static string userName;

        static void PlayAudio(string filePath)
        {
            try
            {
                // Instance of sound player
                SoundPlayer player = new SoundPlayer(filePath);

                // Load the WAV file
                player.Load();

                // Play the WAV file
                player.PlaySync();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: The file '{filePath}' was not found. Please ensure the file path is correct.");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Error: The WAV file could not be played. Please check the file format or integrity.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An unexpected error occurred: {e.Message}");
            }
        }

        static readonly Dictionary<string, string> AudioFiles = new Dictionary<string, string>
        {
            { "Intro", "C:\\Users\\RC_Student_lab\\source\\repos\\PROG6221_POE_ChatBot_ST10435066\\Chatbot_voice_greeting.wav" },
            { "Excited", "C:\\Users\\RC_Student_lab\\source\\repos\\PROG6221_POE_ChatBot_ST10435066\\Excited_meow.wav" },
            { "Sad", "C:\\Users\\RC_Student_lab\\source\\repos\\PROG6221_POE_ChatBot_ST10435066\\Sad_meow.wav" },
            { "Curious", "C:\\Users\\RC_Student_lab\\source\\repos\\PROG6221_POE_ChatBot_ST10435066\\Curious_meow.wav" },
            { "Dialog", "C:\\Users\\RC_Student_lab\\source\\repos\\PROG6221_POE_ChatBot_ST10435066\\Dialog_meow.wav" },
            { "Talk", "C:\\Users\\RC_Student_lab\\source\\repos\\PROG6221_POE_ChatBot_ST10435066\\Talk_meow.wav" },
            { "Purr", "C:\\Users\\RC_Student_lab\\source\\repos\\PROG6221_POE_ChatBot_ST10435066\\Purr.wav" },
            { "Bye", "C:\\Users\\RC_Student_lab\\source\\repos\\PROG6221_POE_ChatBot_ST10435066\\Bye_meow.wav" }
        };

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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(asciiArt); //outputs the logo string
            Console.ForegroundColor = ConsoleColor.White;
        }

        enum CatExpression //set of constant "values" that I can reliably call linked to a specific cat face, allows for a wide array of expressions to be called easy
        {
            Happy,
            Curious,
            Sad,
            Loving,
            Confused,
            Explain
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

            // Display the cat expression you want and the message together as one entity
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(catArt);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Main(string[] args)
        {
            
            DisplayAsciiArt(); //show the logo
            PlayAudio(AudioFiles["Intro"]); //play the voice greeting
            GreetUser(); //the text greeting to start the program

        }

        
        static void GreetUser()
        {
            
            // Display a greeting with the happy cat
            DisplayCat("Hello! I am the CyberCat, your cybersecurity awareness assistant! What's your name?", CatExpression.Happy);
            PlayAudio(AudioFiles["Excited"]);

            bool gaveName = false;

            while (gaveName == false)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("USER: ");
                userName = Console.ReadLine()?.Trim();
                Console.ForegroundColor = ConsoleColor.White;

                if (string.IsNullOrWhiteSpace(userName)) //checks if its blank
                {
                    DisplayCat("Aw don't be shy, tell me!", CatExpression.Sad);
                    PlayAudio(AudioFiles["Sad"]);

                }
                else  //gave name
                {
                    DisplayCat($"Nice to meet you {userName}, lets get started!", CatExpression.Happy);
                    gaveName = true;
                    PlayAudio(AudioFiles["Excited"]);
                }

            }
            // Main menu call
            MainMenu();

        }

        static void MainMenu() //the main menu display
        {
            bool exit = false;
            while (!exit)
            {
                DisplayCat($"What do you want to do, {userName}?", CatExpression.Curious);
                PlayAudio(AudioFiles["Curious"]);

                //options of what the user can do
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Ask a question");
                Console.WriteLine("2. Pet the cat!");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                Console.ForegroundColor = ConsoleColor.White;

                Console.ForegroundColor = ConsoleColor.Cyan;
                string choice = Console.ReadLine()?.Trim(); //gets the user choice
                Console.ForegroundColor = ConsoleColor.White;

                switch (choice)
                {
                    case "1": //ask a question
                        AskQuestion(); //launch question protocall
                        break;
                    case "2": //give cat pets
                        DisplayCat($"Aw, thanks {userName}! Im glad you like me!", CatExpression.Loving);
                        PlayAudio(AudioFiles["Purr"]);
                        break;
                    case "3": //they want to leave
                        DisplayCat($"Goodbye {userName}! Stay safe online!", CatExpression.Happy);
                        PlayAudio(AudioFiles["Bye"]);

                        exit = true;
                        break;
                    default: //they typed something else
                        DisplayCat("Invalid input. Please choose 1, 2 or 3.", CatExpression.Confused);
                        PlayAudio(AudioFiles["Sad"]);
                        break;
                }
            }
        }

        static void AskQuestion() //ask questions method
        {
            //dictionary of responses each linked to a keyword
            var responses = new System.Collections.Generic.Dictionary<string, string>
            {
                //responses that give life to the mascot
                { "how are you", "I'm feeling great! Im very excited to be teaching you today!" },
                { "what’s your purpose", "My purpose is to help you stay safe online by teaching you about cybersecurity." },
                { "what can i ask you about", "You can ask me about passwords, phishing, safe browsing, malware and more!" },
                { "keywords", "Recognized keywords: malware, password, virus, phishing, safe browsing" },

                //cyber related
                { "malware", "Malware is a program that wants to do bad things to your computer!" },
                { "password", "Passwords secure accounts or devices from unauthorized access. You can make a strong password by using a mix of lower case, " +
                "upper case, symbols and numbers! Never share these passwords with anyone" },
                { "virus", "Viruses are a type of malware. They can damage or delete your files! They can get into your computer via infected emails, files " +
                "and external hardware entering or interacting with your system" },                
                { "phishing", "Phishing scams try to trick you into giving away personal information by pretending to be someone you can trust. " +
                "Always verify the sender and avoid clicking on any suspicious links!" },
                { "safe browsing", "Ensure your browser is updated, use HTTPS websites, and be cautious when entering personal information online." }
            };

            bool wantsToQuit = false;

            while (!wantsToQuit)
            {
                //tell user what to do, may need tweaking
                DisplayCat("Give me a topic and I'll tell you more about it, or type 'quit' to go back to the main menu " +
                    "\nYou can also type \"keywords\" to see a list of topics I'm familiar with", CatExpression.Happy);
                PlayAudio(AudioFiles["Dialog"]);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("USER: ");
                string question = Console.ReadLine()?.ToLower()?.Trim(); //dont consider blank spaces after answer
                Console.ForegroundColor = ConsoleColor.White;

                if (question == "quit") //they want to leave
                {
                    wantsToQuit = true;
                }
                else if (string.IsNullOrWhiteSpace(question)) //checks if its blank OR invalid
                {
                    DisplayCat("Please enter a valid topic or type 'quit' to go back to the main menu!", CatExpression.Sad);
                    PlayAudio(AudioFiles["Sad"]);
                }
                else if (responses.ContainsKey(question)) //if ther answer mathes a keyword in the dictionary, show the info associated with keyword
                {
                    DisplayCat(responses[question], CatExpression.Explain);
                    PlayAudio(AudioFiles["Talk"]);
                }
                else //keyword is not in dictionary
                {
                    DisplayCat("I don’t know about that topic yet. Can you try another?", CatExpression.Confused);
                    PlayAudio(AudioFiles["Curious"]);
                }

            }
        }

    }
}

