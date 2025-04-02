using System.Media;
using System.Threading;

namespace CybersecurityAwarenessBot
{
    class Program
    {
        //a global variable to store the user's name so every method can access it
        static string userName;

        //global mute variable
        static bool isMuted = false;

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

        #endregion //end the region

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
            string greeting = ChatbotResponses.GetRandomGreeting(); //gets a random greeting from the dictionary in utility methods region
            DisplayCat(greeting, CatExpression.Happy); //display the cay art with the random greeting
            PlayAudio(AudioFiles["Excited"]); //excited to see you meow

            bool gaveName = false; //to know if they gave the name

            while (!gaveName)
            {
                Console.ForegroundColor = ConsoleColor.Cyan; //change font colour
                Console.Write("USER: "); //so they know when they can type bc meows must play first
                userName = Console.ReadLine()?.Trim(); //enter username and trim off the extra spaces to prevent awkward spacing
                Console.ForegroundColor = ConsoleColor.White; //I keep changing the colour back to see if things go wrong


                if (userName.ToLower() == "testingtesting123") // Check for showcase trigger
                {
                    DisplayCat("Entering showcase mode...", CatExpression.Happy);
                    PlayAudio(AudioFiles["Excited"]);

                    // Call showcase run
                    ShowcaseRun();
                }
                else if (string.IsNullOrWhiteSpace(userName)) //checks if input is blank
                {
                    string noNameResponse = ChatbotResponses.GetRandomNoNameResponse(); //gets and assigns random no name given rsesponse
                    DisplayCat(noNameResponse, CatExpression.Sad); //show cat art and message
                    PlayAudio(AudioFiles["Sad"]); //sad meow
                }
                else //valid input
                {
                    DisplayCat($"Nice to meet you {userName}, let's get started!", CatExpression.Happy); //custom dialog and happy art
                    PlayAudio(AudioFiles["Excited"]); //excited meow
                    gaveName = true; //gave the name, exit the loop
                }
            }

            MainMenu(); //start up the main menu
        }


        /*
        _______________________________________________________________________________________
            Summary of MainMenu():
                Displays the main menu and handles user choices.
        _______________________________________________________________________________________
        */

        static void MainMenu()
        {
            bool exit = false; //tracks whether the user wants to exit the program or not
            while (!exit)
            {
                DisplayCat($"What do you want to do, {userName}?", CatExpression.Curious); //show cat art and ask the user what they want to do
                PlayAudio(AudioFiles["Curious"]); //play curious meow audio

                // options for user actions
                Console.ForegroundColor = ConsoleColor.Blue; //set text color to blue
                Console.WriteLine("1. Ask a question"); //option to ask the chatbot a question
                Console.WriteLine("2. Pet the cat!"); //option to pet the cat
                Console.WriteLine("3. Mute/Unmute the cat"); //option to stop hearing meows
                Console.WriteLine("4. Exit"); //option to exit the program
                Console.Write("Choose an option: "); //show when user can enter
                Console.ForegroundColor = ConsoleColor.White; //reset text color back to white just in case

                Console.ForegroundColor = ConsoleColor.Cyan; //set text color to cyan bc user input is cyan
                string choice = Console.ReadLine()?.Trim(); //read and trim user input to prevent extra spaces
                Console.ForegroundColor = ConsoleColor.White; //reset text color back to white

                switch (choice)
                {
                    case "1": //option 1: user wants to ask a question
                        AskQuestion(); //call the AskQuestion method
                        break;
                    case "2": //option 2: user wants to pet the cat
                        string petResponse = ChatbotResponses.GetRandomPetTheCatResponse(); //get a random pet message
                        DisplayCat(petResponse, CatExpression.Loving); //show loving cat art and message
                        PlayAudio(AudioFiles["Purr"]); //play purring audio
                        break;
                    case "3": // Option 3: mute or unmute the cat
                        if (!isMuted) // Check if audio is currently enabled
                        {
                            isMuted = true; // Set mute to true
                            DisplayCat("Oh... alright then, I'll be quiet...", CatExpression.Sad); // Show sad cat and message
                        }
                        else // Audio is currently muted
                        {
                            isMuted = false; // Set mute to false
                            DisplayCat("Yay! I's so glad you changed your mind!", CatExpression.Happy); // Show happy cat and message
                            PlayAudio(AudioFiles["Excited"]); // Play excited audio
                        }
                        break;
                    case "4": //option 4: user wants to exit
                        string goodbyeResponse = ChatbotResponses.GetRandomGoodbyeResponse(); //get a random goodbye response
                        DisplayCat(goodbyeResponse, CatExpression.Happy); //show happy cat art and message
                        PlayAudio(AudioFiles["Bye"]); //play goodbye audio
                        exit = true; //user wants out, exit switch and quit program
                        break;
                    default: //invalid input
                        DisplayCat(ChatbotResponses.GetRandomInvalidInputResponse(), CatExpression.Confused); //show confused cat art and random invalid input message
                        PlayAudio(AudioFiles["Sad"]); //play sad audio
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
            bool wantsToQuit = false; //tracks whether the user wants to quit the AskQuestion loop

            while (!wantsToQuit) //loop until the user decides to quit
            {
                DisplayCat("Give me a topic and I'll tell you more about it, or type 'quit' to go back to the main menu. You can also type " +
                    "\"keywords\" to see a list of topics I'm familiar with.", CatExpression.Happy); //prompt user to provide a topic
                PlayAudio(AudioFiles["Dialog"]); //play dialog meow audio

                Console.ForegroundColor = ConsoleColor.Cyan; //set text color to cyan for user input
                Console.Write("USER: "); //display prompt for user input
                string question = Console.ReadLine()?.ToLower()?.Trim(); //get and process user input (convert to lowercase and trim spaces for keyword matching)
                Console.ForegroundColor = ConsoleColor.White; //reset text color to white

                if (question == "quit") //user chooses to quit
                {
                    wantsToQuit = true; //exit the loop
                }
                else if (string.IsNullOrWhiteSpace(question)) //check for blank input
                {
                    DisplayCat(ChatbotResponses.GetRandomInvalidInputResponse(), CatExpression.Sad); //show sad cat art and invalid input response
                    PlayAudio(AudioFiles["Sad"]); //play sad meow audio
                }
                else //user provides valid input
                {
                    string personalResponse = ChatbotResponses.GetPersonalResponse(question); //get personal response based on user input
                    string cybersecurityResponse = ChatbotResponses.GetCybersecurityResponse(question); //get cybersecurity response based on user input

                    if (personalResponse != null) //check if input matches a personal question
                    {
                        if (question == "how are you") //special case for "how are you"
                        {
                            string howAreYouResponse = ChatbotResponses.GetRandomHowAreYouResponse(); //get a random "how are you" response
                            DisplayCat(howAreYouResponse, CatExpression.Explain); //show explain cat art and response
                            PlayAudio(AudioFiles["Talk"]); //play talk meow audio
                        }
                        else // other personal questions
                        {
                            DisplayCat(personalResponse, CatExpression.Explain); //show explain cat art and response
                            PlayAudio(AudioFiles["Talk"]); //play talk meow audio
                        }
                    }
                    else if (cybersecurityResponse != null) //check if input matches a cybersecurity question
                    {
                        string funPhrase = ChatbotResponses.GetRandomFunPhrase(question); //get fun phrase for cybersecurity topic
                        DisplayCat(funPhrase, CatExpression.Curious); //show curious cat art and fun phrase

                        Console.ForegroundColor = ConsoleColor.Green; //set text color to green for cybersecurity response
                        Console.WriteLine(cybersecurityResponse); //display the cybersecurity response
                        Console.ForegroundColor = ConsoleColor.White; //reset text color to white
                        PlayAudio(AudioFiles["Talk"]); //play talk meow audio
                    }
                    else // input doesn't match known questions or topics
                    {
                        DisplayCat(ChatbotResponses.GetRandomInvalidInputResponse(), CatExpression.Confused); //show confused cat art and response
                        PlayAudio(AudioFiles["Curious"]); //play curious meow audio
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

        enum CatExpression //array of expression names that corresponds to a cat art
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

            // If mute is enabled, override the expression to always use 'Sad'
            if (isMuted)
            {
                expression = CatExpression.Sad;
            }

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
            Console.ForegroundColor = ConsoleColor.DarkYellow; //its kinds brown
            Console.WriteLine(catArt);
            Console.ForegroundColor = ConsoleColor.Green; //the text must be green
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
            if (isMuted) // Check if the audio is muted
            {
                return; // Do nothing if muted
            }

            try
            {
                //Create an instance of SoundPlayer to handle audio playback
                SoundPlayer player = new SoundPlayer(filePath);

                //Load the WAV file to ensure it's ready for playback
                player.Load();

                //Play the loaded WAV file synchronously (wait until playback completes)
                player.PlaySync();
            }
            catch (FileNotFoundException) //handle case when the specified audio file is not found
            {
                Console.WriteLine($"Error: The file '{filePath}' was not found. Please ensure the file path is correct."); //notify user of the missing file
            }
            catch (InvalidOperationException) //handle invalid file format or issues with audio playback
            {
                Console.WriteLine("Error: The WAV file could not be played. Please check the file format or integrity."); //notify user of file issues
            }
            catch (Exception e) //handle any unexpected errors during audio playback
            {
                Console.WriteLine($"An unexpected error occurred: {e.Message}"); //output the error message for debugging purposes
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
            { "Intro", "C:\\Users\\RC_Student_lab\\source\\repos\\PROG6221_POE_ChatBot_ST10435066\\Audio Files\\Chatbot_voice_greeting.wav" }, //path to the chatbot's introductory voice greeting audio
            { "Excited", "C:\\Users\\RC_Student_lab\\source\\repos\\PROG6221_POE_ChatBot_ST10435066\\Audio Files\\Excited_meow.wav" }, //path to the excited meow audio
            { "Sad", "C:\\Users\\RC_Student_lab\\source\\repos\\PROG6221_POE_ChatBot_ST10435066\\Audio Files\\Sad_meow.wav" }, //path to the sad meow audio
            { "Curious", "C:\\Users\\RC_Student_lab\\source\\repos\\PROG6221_POE_ChatBot_ST10435066\\Audio Files\\Curious_meow.wav" }, //path to the curious meow audio
            { "Dialog", "C:\\Users\\RC_Student_lab\\source\\repos\\PROG6221_POE_ChatBot_ST10435066\\Audio Files\\Dialog_meow.wav" }, //path to the dialog meow audio, used during interaction
            { "Talk", "C:\\Users\\RC_Student_lab\\source\\repos\\PROG6221_POE_ChatBot_ST10435066\\Audio Files\\Talk_meow.wav" }, //path to the talk meow audio, used for explanation responses
            { "Purr", "C:\\Users\\RC_Student_lab\\source\\repos\\PROG6221_POE_ChatBot_ST10435066\\Audio Files\\Purr.wav" }, //path to the purring audio, used for the pet-the-cat option
            { "Bye", "C:\\Users\\RC_Student_lab\\source\\repos\\PROG6221_POE_ChatBot_ST10435066\\Audio Files\\Bye_meow.wav" } //path to the goodbye meow audio
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
                { "malware", "Malware, short for 'malicious software,' refers to any program or file designed to harm a computer, network, or user. " +
                    "It can take many forms, such as viruses, worms, spyware, ransomware, or Trojan horses. Malware can disrupt operations, steal sensitive " +
                    "data, or even render systems unusable. Staying vigilant against unusual activity and keeping your antivirus software updated are critical " +
                    "to protecting against malware." },

                { "password", "Passwords are vital for securing accounts, devices, and sensitive data from unauthorized access. A strong password should " +
                    "be long and include a mix of uppercase letters, lowercase letters, numbers, and special characters. Avoid using easily guessable " +
                    "information, like birthdays or common words. Always keep your passwords private and consider using a password manager for added security." },

                { "virus", "A virus is a type of malware that infects and alters the way your computer operates, often damaging files, data, or software in the " +
                    "process. Viruses spread through malicious email attachments, infected files, or compromised websites. Regularly scanning your system and " +
                    "exercising caution with unknown downloads or links can help prevent viruses from affecting your device." },

                { "phishing", "Phishing is a deceptive tactic used by attackers to trick individuals into revealing sensitive information, such as passwords " +
                    "or credit card details. These scams often come in the form of fake emails, texts, or websites that appear to be trustworthy. " +
                    "Protect yourself by verifying senders, avoiding suspicious links, and never sharing personal information without confirming the source's authenticity." },

                { "safe browsing", "Safe browsing practices ensure your online activities are secure and free from malicious threats. Key tips include: keeping your browser " +
                    "updated, avoiding unsecured websites, using HTTPS whenever possible, being cautious with downloads, and never sharing sensitive information on platforms " +
                    "you don't trust. Employing ad-blockers and enabling browser security settings adds an extra layer of protection." }
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
                Random random = new Random(); // create an instance of the Random class
                return CheerfulGreetings[random.Next(CheerfulGreetings.Length)]; // return a random greeting from the CheerfulGreetings array
            }


            /*
            _______________________________________________________________________________________
                Summary of GetRandomHowAreYouResponse():
                    Gets a random response to "How are you?"
            _______________________________________________________________________________________
            */
            public static string GetRandomHowAreYouResponse()
            {
                Random random = new Random(); // create an instance of the Random class
                return HowAreYouResponses[random.Next(HowAreYouResponses.Length)]; // return a random response from the HowAreYouResponses array
            }


            /*
            _______________________________________________________________________________________
                Summary of GetRandomPetTheCatResponse():
                   Gets a random response for petting the cat.
            _______________________________________________________________________________________
            */
            public static string GetRandomPetTheCatResponse()
            {
                Random random = new Random(); // create an instance of the Random class
                return PetTheCatResponses[random.Next(PetTheCatResponses.Length)]; // return a random response from the PetTheCatResponses array
            }

            /*
            _______________________________________________________________________________________
                Summary of GetRandomGoodbyeResponse():
                   Gets a random memorable goodbye response.
            _______________________________________________________________________________________
            */
            public static string GetRandomGoodbyeResponse()
            {
                Random random = new Random(); // create an instance of the Random class
                return GoodbyeResponses[random.Next(GoodbyeResponses.Length)]; // return a random response from the GoodbyeResponses array
            }

            /*
            _______________________________________________________________________________________
                Summary of GetRandomFunPhrase():
                   Gets a random fun introductory phrase for cybersecurity topics.
            _______________________________________________________________________________________
            */
            public static string GetRandomFunPhrase(string topic)
            {
                Random random = new Random(); // create an instance of the Random class
                string funPhrase = FunPhrases[random.Next(FunPhrases.Length)]; // pick a random fun phrase
                return funPhrase.Replace("{topic}", topic); // replace the placeholder "{topic}" with the actual topic provided
            }

            /*
            _______________________________________________________________________________________
                Summary of GetRandomInvalidInputResponse():
                   Gets a random response for unrecognized inputs.
            _______________________________________________________________________________________
            */
            public static string GetRandomInvalidInputResponse()
            {
                Random random = new Random(); // create an instance of the Random class
                return InvalidInputResponses[random.Next(InvalidInputResponses.Length)]; // return a random response from the InvalidInputResponses array
            }

            /*
            _______________________________________________________________________________________
                Summary of GetPersonalResponse():
                   Gets a response for a recognized personal question.
            _______________________________________________________________________________________
            */
            public static string GetPersonalResponse(string question)
            {
                if (PersonalQuestions.ContainsKey(question)) // check if the question exists in the PersonalQuestions dictionary
                {
                    return PersonalQuestions[question]; // return the corresponding response
                }
                return null; // return null if the question is not found
            }

            /*
            _______________________________________________________________________________________
                Summary of GetCybersecurityResponse():
                   Gets a response for a recognized cybersecurity question.
            _______________________________________________________________________________________
            */
            public static string GetCybersecurityResponse(string question)
            {
                if (CybersecurityQuestions.ContainsKey(question)) // check if the question exists in the CybersecurityQuestions dictionary
                {
                    return CybersecurityQuestions[question]; // return the corresponding response
                }
                return null; // return null if the question is not found
            }

            /*
            _______________________________________________________________________________________
                Summary of GetRandomNoNameResponse():
                   Gets a random response for when the user doesn't provide their name.
            _______________________________________________________________________________________
            */
            public static string GetRandomNoNameResponse()
            {
                Random random = new Random(); // create an instance of the Random class
                return NoNameResponses[random.Next(NoNameResponses.Length)]; // return a random response from the NoNameResponses array
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

        /*==================================================================================================*/

        #region Showcase Mode


        static void ShowcaseRun()
        {
            // Welcome message for showcase mode
            DisplayCat("Showcase started: Watch me interact!", CatExpression.Happy);
            PlayAudio(AudioFiles["Excited"]);

            bool exit = false; // Flag to track whether to exit the showcase mode
            while (!exit)
            {
                // Main menu
                DisplayCat($"What do you want to do, {userName}?", CatExpression.Curious);
                PlayAudio(AudioFiles["Curious"]);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Ask a question");
                Console.WriteLine("2. Pet the cat!");
                Console.WriteLine("3. Mute/Unmute the cat");
                Console.WriteLine("4. Exit");
                Console.ForegroundColor = ConsoleColor.White;

                // Simulated menu choice: Ask a Question
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("USER: 1 (Ask a question)");
                Console.ForegroundColor = ConsoleColor.White;
                DisplayCat("Give me a topic and I'll tell you more about it, or type 'keywords' to see a list of topics I'm familiar with.", CatExpression.Happy);
                PlayAudio(AudioFiles["Dialog"]);

                // 1. Simulate asking all personal questions
                foreach (var question in ChatbotResponses.PersonalQuestions.Keys)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"USER: {question}"); // Simulated user input
                    Console.ForegroundColor = ConsoleColor.White;
                    string response = ChatbotResponses.GetPersonalResponse(question); // Get chatbot response
                    DisplayCat(response, CatExpression.Explain); // Display response
                    PlayAudio(AudioFiles["Talk"]); // Play talk audio
                }

                // Simulated "quit" input to return to main menu
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("USER: quit");
                Console.ForegroundColor = ConsoleColor.White;



                // Main menu
                DisplayCat($"What do you want to do, {userName}?", CatExpression.Curious);
                PlayAudio(AudioFiles["Curious"]);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Ask a question");
                Console.WriteLine("2. Pet the cat!");
                Console.WriteLine("3. Mute/Unmute the cat");
                Console.WriteLine("4. Exit");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("USER: 3 (Mute the cat)"); // Simulated "Mute" input
                Console.ForegroundColor = ConsoleColor.White;

                // 2. Mute the cat
                isMuted = true;
                DisplayCat("Oh... alright then, I'll be quiet...", CatExpression.Sad);
                Console.WriteLine("(We are muting the cat to speed up the showcase and to show what it is like when the cat is muted. Unmuted the audio plays just like it does for the personal questions.");
                Thread.Sleep(2000); // Wait for 2 seconds (2000 milliseconds) before moving to the next question

                // Main menu
                DisplayCat($"What do you want to do, {userName}?", CatExpression.Curious);
                PlayAudio(AudioFiles["Curious"]);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Ask a question");
                Console.WriteLine("2. Pet the cat!");
                Console.WriteLine("3. Mute/Unmute the cat");
                Console.WriteLine("4. Exit");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("USER: 1 (Ask a question)"); // Simulated "Ask a question" input
                Console.ForegroundColor = ConsoleColor.White;

                // 3. Simulate asking all cybersecurity questions
                foreach (var question in ChatbotResponses.CybersecurityQuestions.Keys)
                {
                    Console.WriteLine($"USER: {question}"); // Simulated user input
                    string response = ChatbotResponses.GetCybersecurityResponse(question); // Get chatbot response
                    DisplayCat(response, CatExpression.Explain); // Display response
                    if (!isMuted) PlayAudio(AudioFiles["Talk"]); // Play talk audio if not muted
                    Thread.Sleep(2000); // Wait for 2 seconds (2000 milliseconds) before moving to the next question
                }


                // Simulated "quit" input to return to main menu
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("USER: quit");
                Console.ForegroundColor = ConsoleColor.White;



                // Main menu
                DisplayCat($"What do you want to do, {userName}?", CatExpression.Curious);
                PlayAudio(AudioFiles["Curious"]);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Ask a question");
                Console.WriteLine("2. Pet the cat!");
                Console.WriteLine("3. Mute/Unmute the cat");
                Console.WriteLine("4. Exit");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("USER: 3 (Unmute the cat)"); // Simulated "Unmute" input
                Console.ForegroundColor = ConsoleColor.White;

                // 4. Unmute the cat
                isMuted = false;
                DisplayCat("Yay! I's so glad you changed your mind!", CatExpression.Happy); // Show happy cat and message
                PlayAudio(AudioFiles["Excited"]); // Play excited audio

                // Main menu
                DisplayCat($"What do you want to do, {userName}?", CatExpression.Curious);
                PlayAudio(AudioFiles["Curious"]);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Ask a question");
                Console.WriteLine("2. Pet the cat!");
                Console.WriteLine("3. Mute/Unmute the cat");
                Console.WriteLine("4. Exit");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("USER: 2 (Pet the cat)"); // Simulated "Pet the cat" input
                Console.ForegroundColor = ConsoleColor.White;

                // 5. Pet the cat
                DisplayCat(ChatbotResponses.GetRandomPetTheCatResponse(), CatExpression.Loving);
                PlayAudio(AudioFiles["Purr"]); // Play purring audio

                // Main menu
                DisplayCat($"What do you want to do, {userName}?", CatExpression.Curious);
                PlayAudio(AudioFiles["Curious"]);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Ask a question");
                Console.WriteLine("2. Pet the cat!");
                Console.WriteLine("3. Mute/Unmute the cat");
                Console.WriteLine("4. Exit");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("USER: 4 (Exit)"); // Simulated "Exit" input
                Console.ForegroundColor = ConsoleColor.White;

                // 6. Exit the program
                DisplayCat(ChatbotResponses.GetRandomGoodbyeResponse(), CatExpression.Happy);
                PlayAudio(AudioFiles["Bye"]); // Play goodbye audio

                Console.WriteLine("Please restart the program, you cannot interact with the program normally after the showcase.");
                
                exit = true; // Set exit flag to true
            }
        }
        #endregion

        /*==================================================================================================*/
    }
}


