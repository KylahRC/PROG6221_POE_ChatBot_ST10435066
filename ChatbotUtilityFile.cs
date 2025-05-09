namespace CybersecurityAwarenessBot
{
    public static class ChatbotUtilityFile
    {
        #region Utility Methods

        /*
        _______________________________________________________________________________________
            Summary of AudioFiles:
                Centralizes all known audio file paths for the chatbot.
        _______________________________________________________________________________________
        */

        public static readonly Dictionary<string, string> AudioFiles = new Dictionary<string, string>
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

    }
}
