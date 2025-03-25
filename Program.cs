using System.Media;


namespace CybersecurityAwarenessBot
{
    class Program
    {
        //a global variable to store the user's name
        static string userName;

        #region Setup and Initialization

        /*
        ________________________________________________________________________ 
            Summary of DisplayAsciiArt():
                Displays the ASCII art logo for the chatbot in green text.
        ________________________________________________________________________
        */

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
            Console.ForegroundColor = ConsoleColor.Green; //changes the font colour
            Console.WriteLine(asciiArt); //outputs the logo string
            Console.ForegroundColor = ConsoleColor.White;
        }

        #endregion

        /*==================================================================================================*/

        #region User Interaction

        /*
        _______________________________________________________________________________________
            Summary of GreetUser():
                Greets the user, asks for their name, and personalizes responses based on it.
        _______________________________________________________________________________________
        */

        static void GreetUser()
        {
            string greeting = ChatbotResponses.GetRandomGreeting();
            DisplayCat(greeting, CatExpression.Happy);
            PlayAudio(AudioFiles["Excited"]);

            bool gaveName = false;

            while (!gaveName)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("USER: ");
                userName = Console.ReadLine()?.Trim();
                Console.ForegroundColor = ConsoleColor.White;

                if (string.IsNullOrWhiteSpace(userName)) // checks if input is blank
                {
                    string noNameResponse = ChatbotResponses.GetRandomNoNameResponse();
                    DisplayCat(noNameResponse, CatExpression.Sad);
                    PlayAudio(AudioFiles["Sad"]);
                }
                else // valid input
                {
                    DisplayCat($"Nice to meet you {userName}, let's get started!", CatExpression.Happy);
                    PlayAudio(AudioFiles["Excited"]);
                    gaveName = true;
                }
            }

            MainMenu();
        }


        /*
        _______________________________________________________________________________________
            Summary of MainMenu():
                Displays the main menu and handles user choices.
        _______________________________________________________________________________________
        */

        static void MainMenu()
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
                    case "1": // ask a question
                        AskQuestion(); // launch question protocol
                        break;
                    case "2": // pet the cat
                        string petResponse = ChatbotResponses.GetRandomPetTheCatResponse();
                        DisplayCat(petResponse, CatExpression.Loving);
                        PlayAudio(AudioFiles["Purr"]);
                        break;
                    case "3": // exit
                        string goodbyeResponse = ChatbotResponses.GetRandomGoodbyeResponse();
                        DisplayCat(goodbyeResponse, CatExpression.Happy);
                        PlayAudio(AudioFiles["Bye"]);
                        exit = true;
                        break;
                    default: // invalid input
                        DisplayCat(ChatbotResponses.GetRandomInvalidInputResponse(), CatExpression.Confused);
                        PlayAudio(AudioFiles["Sad"]);
                        break;
                }

            }
        }


        /*
        _______________________________________________________________________________________
            Summary of AskQuestion():
                Handles user questions and provides responses based on recognized keywords.
        _______________________________________________________________________________________
        */

        static void AskQuestion()
        {
            bool wantsToQuit = false;

            while (!wantsToQuit)
            {
                DisplayCat("Give me a topic and I'll tell you more about it, or type 'quit' to go back to the main menu. You can also type \"keywords\" to see a list of topics I'm familiar with.", CatExpression.Happy);
                PlayAudio(AudioFiles["Dialog"]);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("USER: ");
                string question = Console.ReadLine()?.ToLower()?.Trim();
                Console.ForegroundColor = ConsoleColor.White;

                if (question == "quit")
                {
                    wantsToQuit = true;
                }
                else if (string.IsNullOrWhiteSpace(question)) // checks for blank input
                {
                    DisplayCat(ChatbotResponses.GetRandomInvalidInputResponse(), CatExpression.Sad);
                    PlayAudio(AudioFiles["Sad"]);
                }
                else
                {
                    string personalResponse = ChatbotResponses.GetPersonalResponse(question);
                    string cybersecurityResponse = ChatbotResponses.GetCybersecurityResponse(question);

                    if (personalResponse != null)
                    {
                        if (question == "how are you")
                        {
                            // Use the random "How are you?" response
                            string howAreYouResponse = ChatbotResponses.GetRandomHowAreYouResponse();
                            DisplayCat(howAreYouResponse, CatExpression.Explain);
                            PlayAudio(AudioFiles["Talk"]);
                        }
                        else
                        {
                            DisplayCat(personalResponse, CatExpression.Explain);
                            PlayAudio(AudioFiles["Talk"]);
                        }
                    }
                    else if (cybersecurityResponse != null)
                    {
                        // Use the fun phrase from ChatbotResponses
                        string funPhrase = ChatbotResponses.GetRandomFunPhrase(question);

                        // Display cat art with the fun phrase
                        DisplayCat(funPhrase, CatExpression.Curious);
                        

                        // Display only the cybersecurity response without the cat art
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(cybersecurityResponse);
                        Console.ForegroundColor = ConsoleColor.White;
                        PlayAudio(AudioFiles["Talk"]);
                    }
                    else
                    {
                        DisplayCat(ChatbotResponses.GetRandomInvalidInputResponse(), CatExpression.Confused);
                        PlayAudio(AudioFiles["Curious"]);
                    }
                }
            }
        }


        #endregion

        /*==================================================================================================*/

        #region Chatbot Expressions

        /*
        _______________________________________________________________________________________ 
            Summary of CatExpression:
                Enum to represent the different cat expressions for the chatbot.
        _______________________________________________________________________________________
        */

        enum CatExpression
        {
            Happy,
            Curious,
            Sad,
            Loving,
            Confused,
            Explain
        }


        /*
        _______________________________________________________________________________________ 
            Summary of DisplayCat():
                Displays the cat ASCII art and a corresponding message in color.
                <param name="message">The message to display below the cat art.</param>
                <param name="expression">The cat's expression (e.g., happy, sad).</param>
        _______________________________________________________________________________________
        */

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

        #endregion

        /*==================================================================================================*/

        #region Audio Playback Helper

        /*
        _______________________________________________________________________________________
            Summary of PlayAudio():
                Plays an audio file from the specified path.
                <param name="filePath">The file path of the audio file to play.</param>
        _______________________________________________________________________________________
        */

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

        #endregion

        /*==================================================================================================*/

        #region Utility Methods

        /*
        _______________________________________________________________________________________
            Summary of AudioFiles:
                Centralizes all known audio file paths for the chatbot.
        _______________________________________________________________________________________
        */

        static readonly Dictionary<string, string> AudioFiles = new Dictionary<string, string>
        {
            { "Intro", "C:\\Users\\RC_Student_lab\\source\\repos\\PROG6221_POE_ChatBot_ST10435066\\Audio Files\\Chatbot_voice_greeting.wav" },
            { "Excited", "C:\\Users\\RC_Student_lab\\source\\repos\\PROG6221_POE_ChatBot_ST10435066\\Audio Files\\Excited_meow.wav" },
            { "Sad", "C:\\Users\\RC_Student_lab\\source\\repos\\PROG6221_POE_ChatBot_ST10435066\\Audio Files\\Sad_meow.wav" },
            { "Curious", "C:\\Users\\RC_Student_lab\\source\\repos\\PROG6221_POE_ChatBot_ST10435066\\Audio Files\\Curious_meow.wav" },
            { "Dialog", "C:\\Users\\RC_Student_lab\\source\\repos\\PROG6221_POE_ChatBot_ST10435066\\Audio Files\\Dialog_meow.wav" },
            { "Talk", "C:\\Users\\RC_Student_lab\\source\\repos\\PROG6221_POE_ChatBot_ST10435066\\Audio Files\\Talk_meow.wav" },
            { "Purr", "C:\\Users\\RC_Student_lab\\source\\repos\\PROG6221_POE_ChatBot_ST10435066\\Audio Files\\Purr.wav" },
            { "Bye", "C:\\Users\\RC_Student_lab\\source\\repos\\PROG6221_POE_ChatBot_ST10435066\\Audio Files\\Bye_meow.wav" }
        };


        /*
        _______________________________________________________________________________________
            Summary of ChatbotResponses:
                Contains all the dialog that can be said by the chatbot.
        _______________________________________________________________________________________
        */

        public static class ChatbotResponses
        {
            /*====================================================
            ================ Predefined Responses ================
            ====================================================*/

            /*
            _______________________________________________________________________________________
                Summary of CheerfulGreetings:
                    Contains dynamic greetings to welcome the user in a cheerful and engaging way.
            _______________________________________________________________________________________
            */
            public static readonly string[] CheerfulGreetings =
            {
                "Meowdy! I’m CyberCat, your paw-some cybersecurity guide! What should I call you?",
                "Hello there! CyberCat reporting for duty—I’ll help keep you safe online. What’s your name?",
                "Purr-fect day to chat about cybersecurity! What’s your name, friend?",
                "Meow! Let’s dive into the world of cybersecurity together. I’d love to know your name!"
            };

            /*
            _______________________________________________________________________________________
                Summary of HowAreYouResponses:
                    Contains playful responses for when the user asks how the chatbot is doing.
            _______________________________________________________________________________________
            */
            public static readonly string[] HowAreYouResponses =
            {
                "Meowvelous! I’m here to help you stay safe online today!",
                "I’m paws-itively great, thanks for asking!",
                "Feeling claw-some and ready to teach you about cybersecurity!",
                "Purring happily, because I love helping with cybersecurity!"
            };

            /*
            _______________________________________________________________________________________
                Summary of PetTheCatResponses:
                    Contains appreciation responses for when the user selects the "Pet the Cat" option.
            _______________________________________________________________________________________
            */
            public static readonly string[] PetTheCatResponses =
            {
                "Purr, purr, purr… you’re the best! Thanks for petting me!",
                "Oh, I feel so loved! Let me give you some cybersecurity wisdom in return!",
                "Thank you for the pets—you're so sweet!",
                "Aw, I needed that! Now, let’s keep learning about cybersecurity!"
            };

            /*
           _______________________________________________________________________________________
               Summary of GoodbyeResponses:
                   Contains memorable goodbye phrases when the user exits the chatbot.
           _______________________________________________________________________________________
           */
            public static readonly string[] GoodbyeResponses =
            {
                "Goodbye, human! Stay safe online and don’t forget to use strong passwords!",
                "Meow-bye! Don’t fall for phishing scams, okay?",
                "See you next time! I’ll be here to purr whenever you need cybersecurity advice.",
                "Farewell, friend! Remember, safe browsing is the cat’s meow!"
            };

            /*
            _______________________________________________________________________________________
                Summary of FunPhrases:
                    Contains fun introductory phrases for cybersecurity-related responses.
            _______________________________________________________________________________________
            */
            public static readonly string[] FunPhrases =
            {
                "Meow! Here’s what I know about {topic}:",
                "Purr-fect question! Let me tell you about {topic}:",
                "You’re curious, I love that! Let’s explore {topic}:",
                "That’s a great topic—here’s what I know about {topic}:",
                "Oh that's easy! Here’s what you need to know about {topic}:"
            };

            /*
            _______________________________________________________________________________________
                Summary of PersonalQuestions:
                    Stores responses for personal questions about the chatbot's personality or purpose.
            _______________________________________________________________________________________
            */
            public static readonly Dictionary<string, string> PersonalQuestions = new Dictionary<string, string>
            {
                { "how are you", "I'm feeling great! I'm very excited to be teaching you today!" },
                { "what can you do", "I can answer your questions about cybersecurity, teach you about online safety, and make sure you're ready to avoid digital threats!" },
                { "who are you", "I am CyberCat, your cybersecurity awareness assistant. Meow!" },
                { "what’s your purpose", "My purpose is to help you stay safe online by teaching you about cybersecurity and answering your questions." },
                { "what can i ask you about", "You can ask me about topics like passwords, phishing, safe browsing, malware, and more!" },
                { "keywords", "Recognized keywords include: malware, password, virus, phishing, safe browsing." }
            };

            /*
            _______________________________________________________________________________________
                Summary of CybersecurityQuestions:
                    Stores cybersecurity-related questions and their corresponding responses.
            _______________________________________________________________________________________
            */
            public static readonly Dictionary<string, string> CybersecurityQuestions = new Dictionary<string, string>
            {
                { "malware", "Malware is a program that wants to do bad things to your computer!" },
                { "password", "Passwords secure accounts or devices from unauthorized access. Use a mix of lower case, upper case, symbols, and numbers to make strong passwords. Never share them with anyone!" },
                { "virus", "Viruses are a type of malware that can damage or delete your files! They often spread through infected emails or files." },
                { "phishing", "Phishing scams try to trick you into giving away personal information by pretending to be someone trustworthy. Always verify the sender and avoid suspicious links!" },
                { "safe browsing", "Ensure your browser is updated, use HTTPS websites, and be cautious when entering personal information online." }
            };

            /*
            _______________________________________________________________________________________
                Summary of InvalidInputResponses:
                    Contains responses for unrecognized user inputs.
            _______________________________________________________________________________________
            */
            public static readonly string[] InvalidInputResponses =
            {
                "Hmm, I don’t quite understand that. Could you try rephrasing or asking about cybersecurity topics like passwords or phishing?",
                "Oops! That doesn’t ring a bell. Maybe you can try keywords like ‘safe browsing’ or ‘virus’?",
                "Oh no, that topic isn’t in my kitty brain yet! Let me grow smarter, but for now, try asking about passwords, malware, or phishing!"
            };

            /*
            _______________________________________________________________________________________
                Summary of NoNameResponses:
                    Contains responses for when the user does not provide their name.
            _______________________________________________________________________________________
            */
            public static readonly string[] NoNameResponses =
            {
                "Aw, don’t be shy! I’d love to know your name!",
                "Meow! It’s okay if you don’t want to share your real name, but I’d love to call you something!",
                "Hmm… if I were a guessing cat, I’d guess your name is Human. Am I right?",
                "Purr-fectly fine if you're cautious to share your real name, you can give me a nickname of yours instead!"
            };

            /*=========================================================
            ================= Response Retrieval =====================
            =========================================================*/


            /*
            _______________________________________________________________________________________
                Summary of GetRandomGreeting():
                    Gets a random cheerful greeting.
            _______________________________________________________________________________________
            */
            public static string GetRandomGreeting()
            {
                Random random = new Random();
                return CheerfulGreetings[random.Next(CheerfulGreetings.Length)];
            }


            /*
            _______________________________________________________________________________________
                Summary of GetRandomHowAreYouResponse():
                    Gets a random response to "How are you?"
            _______________________________________________________________________________________
            */
            public static string GetRandomHowAreYouResponse()
            {
                Random random = new Random();
                return HowAreYouResponses[random.Next(HowAreYouResponses.Length)];
            }


            /*
            _______________________________________________________________________________________
                Summary of GetRandomPetTheCatResponse():
                   Gets a random response for petting the cat.
            _______________________________________________________________________________________
            */            
            public static string GetRandomPetTheCatResponse()
            {
                Random random = new Random();
                return PetTheCatResponses[random.Next(PetTheCatResponses.Length)];
            }

            /*
            _______________________________________________________________________________________
                Summary of GetRandomGoodbyeResponse():
                   Gets a random memorable goodbye response.
            _______________________________________________________________________________________
            */
            public static string GetRandomGoodbyeResponse()
            {
                Random random = new Random();
                return GoodbyeResponses[random.Next(GoodbyeResponses.Length)];
            }

            /*
            _______________________________________________________________________________________
                Summary of GetRandomFunPhrase():
                   Gets a random fun introductory phrase for cybersecurity topics.
            _______________________________________________________________________________________
            */
            public static string GetRandomFunPhrase(string topic)
            {
                Random random = new Random();
                string funPhrase = FunPhrases[random.Next(FunPhrases.Length)];
                return funPhrase.Replace("{topic}", topic);
            }

            /*
            _______________________________________________________________________________________
                Summary of GetRandomInvalidInputResponse():
                   Gets a random response for unrecognized inputs.
            _______________________________________________________________________________________
            */
            public static string GetRandomInvalidInputResponse()
            {
                Random random = new Random();
                return InvalidInputResponses[random.Next(InvalidInputResponses.Length)];
            }

            /*
            _______________________________________________________________________________________
                Summary of GetPersonalResponse():
                   Gets a response for a recognized personal question.
            _______________________________________________________________________________________
            */
            public static string GetPersonalResponse(string question)
            {
                if (PersonalQuestions.ContainsKey(question))
                {
                    return PersonalQuestions[question];
                }
                return null;
            }

            /*
            _______________________________________________________________________________________
                Summary of GetCybersecurityResponse():
                   Gets a response for a recognized cybersecurity question.
            _______________________________________________________________________________________
            */
            public static string GetCybersecurityResponse(string question)
            {
                if (CybersecurityQuestions.ContainsKey(question))
                {
                    return CybersecurityQuestions[question];
                }
                return null;
            }

            /*
            _______________________________________________________________________________________
                Summary of GetRandomNoNameResponse():
                   Gets a random response for when the user doesn't provide their name.
            _______________________________________________________________________________________
            */
            public static string GetRandomNoNameResponse()
            {
                Random random = new Random();
                return NoNameResponses[random.Next(NoNameResponses.Length)];
            }
        }

        #endregion

        /*==================================================================================================*/

        #region Program Entry Point

        /* 
        _______________________________________________________________________________________
            Summary of Main():
                The main entry point for the chatbot program.
        _______________________________________________________________________________________
        */

        static void Main(string[] args)
        {

            DisplayAsciiArt(); //show the logo
            PlayAudio(AudioFiles["Intro"]); //play the voice greeting
            GreetUser(); //the text greeting to start the program

        }

        #endregion
    }
}


