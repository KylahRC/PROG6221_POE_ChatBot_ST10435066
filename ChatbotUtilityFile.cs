namespace CybersecurityAwarenessBot
{
    public static class ChatbotUtilityFile
    {

        public static class ChatbotResponses
        {

            #region CheerfulGreetings
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
                Summary of GetRandomGreeting():
                    Gets a random cheerful greeting.
            _______________________________________________________________________________________
            */
            public static string GetRandomGreeting()
            {
                Random random = new Random(); // create an instance of the Random class
                return CheerfulGreetings[random.Next(CheerfulGreetings.Length)]; // return a random greeting from the CheerfulGreetings array
            }

            #endregion

            /*============================================================*/

            #region HowAreYouResponses
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
                Summary of GetRandomHowAreYouResponse():
                    Gets a random response to "How are you?"
            _______________________________________________________________________________________
            */
            public static string GetRandomHowAreYouResponse()
            {
                Random random = new Random(); // create an instance of the Random class
                return HowAreYouResponses[random.Next(HowAreYouResponses.Length)]; // return a random response from the HowAreYouResponses array
            }

            #endregion

            /*============================================================*/

            #region PetTheCatResponses
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
                Summary of GetRandomPetTheCatResponse():
                   Gets a random response for petting the cat.
            _______________________________________________________________________________________
            */
            public static string GetRandomPetTheCatResponse()
            {
                Random random = new Random(); // create an instance of the Random class
                return PetTheCatResponses[random.Next(PetTheCatResponses.Length)]; // return a random response from the PetTheCatResponses array
            }

            #endregion

            /*============================================================*/

            #region GoodbyeResponses

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
                Summary of GetRandomGoodbyeResponse():
                   Gets a random memorable goodbye response.
            _______________________________________________________________________________________
            */
            public static string GetRandomGoodbyeResponse()
            {
                Random random = new Random(); // create an instance of the Random class
                return GoodbyeResponses[random.Next(GoodbyeResponses.Length)]; // return a random response from the GoodbyeResponses array
            }

            #endregion

            /*============================================================*/

            #region FunPhrases

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

            #endregion

            /*============================================================*/

            #region PersonalQuestions

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

            #endregion

            /*============================================================*/

            #region CybersecurityQuestions
            /*
            _______________________________________________________________________________________
                Summary of CybersecurityQuestions:
                    Stores cybersecurity-related questions and their corresponding responses.
            _______________________________________________________________________________________
            */


            public static readonly Dictionary<string, List<string>> ShortCybersecurityTips = new Dictionary<string, List<string>>
            {
                { "password", new List<string>
                    {
                        "Use a mix of uppercase, lowercase, numbers, and symbols!",
                        "Never reuse the same password across accounts.",
                        "Try using a password manager to store secure passwords.",
                        "Avoid using personal details like birthdays or pet names!"
                    }
                },
                { "malware", new List<string>
                    {
                        "Always keep your antivirus software updated.",
                        "Never download attachments from unknown emails.",
                        "Be cautious of free software—it might contain hidden malware!",
                        "Use a firewall to help block suspicious activity."
                    }
                },
                { "phishing", new List<string>
                    {
                        "Look for misspelled URLs—scammers imitate real websites!",
                        "Never click suspicious links in emails or messages.",
                        "If an email asks for sensitive info, always verify first.",
                        "Use multi-factor authentication (MFA) to protect accounts!"
                    }
                },
                { "safe browsing", new List<string>
                    {
                        "Check for HTTPS before entering personal info!",
                        "Use an ad blocker to prevent malicious pop-ups.",
                        "Don’t download software from untrusted sources!",
                        "Regularly clear your cookies and browsing history."
                    }
                },
                { "virus", new List<string>
                    {
                        "Run regular virus scans to catch threats early.",
                        "Don’t ignore security warnings on websites!",
                        "Always verify the source before opening an attachment.",
                        "If a computer slows down randomly, check for malware!"
                    }
                }
            };

            public static string GetRandomShortTip(string keyword)
            {
                if (ShortCybersecurityTips.ContainsKey(keyword))
                {
                    List<string> tips = ShortCybersecurityTips[keyword];
                    return tips[new Random().Next(tips.Count)];
                }
                return "I don't have a tip for that yet!";
            }


            public static readonly Dictionary<string, string> DetailedCybersecurityResponses = new Dictionary<string, string>
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

            public static string GetDetailedResponse(string keyword)
            {
                if (DetailedCybersecurityResponses.ContainsKey(keyword))
                {
                    return DetailedCybersecurityResponses[keyword]; // If the keyword exists in the dictionary, return its response.
                }
                else
                {
                    return "I don't have details on that yet!"; // If the keyword isn't found, return a default message.
                }
            }

            public static readonly Dictionary<string, Dictionary<string, string>> FeelingResponses = new Dictionary<string, Dictionary<string, string>>
            {
                { "password", new Dictionary<string, string>
                    {
                        { "worried", "It's understandable to be concerned about password security. The good news is that strong passwords and password managers can keep you safe!" },
                        { "curious", "Great! Understanding how passwords work is key to cybersecurity. Did you know a strong password is at least 12 characters long?" },
                        { "confident", "That's awesome! Having good password habits makes you significantly safer online. Keep using unique passwords for every account!" }
                    }
                },
                { "malware", new Dictionary<string, string>
                    {
                        { "worried", "You're right to be cautious—malware can be dangerous. Keeping antivirus software updated is a great step toward protection." },
                        { "curious", "Awesome! Learning about malware helps you stay safe. Malware can spread through emails, fake downloads, and malicious ads." },
                        { "confident", "You're already ahead of the game! Safe browsing and using a firewall can help you avoid malware altogether." }
                    }
                },
                { "phishing", new Dictionary<string, string>
                    {
                        { "worried", "Phishing scams are tricky, but knowing how to spot suspicious links makes you much safer!" },
                        { "curious", "Glad you're interested! Phishing relies on deception—scammers impersonate trusted sources to steal information." },
                        { "confident", "Awesome! Being able to recognize phishing scams is crucial for cybersecurity. Stay vigilant!" }
                    }
                },
                { "safe browsing", new Dictionary<string, string>
                    {
                        { "worried", "It’s understandable—privacy and security online are major concerns. Avoid clicking random links and always check for HTTPS!" },
                        { "curious", "That's a great mindset! Safe browsing means making sure your personal data is protected at all times." },
                        { "confident", "Love that confidence! Using an ad-blocker and browser security settings puts you ahead in cybersecurity." }
                    }
                },
                { "virus", new Dictionary<string, string>
                    {
                        { "worried", "Viruses can harm your system, but regular security scans and safe downloads will protect you!" },
                        { "curious", "Viruses spread through attachments, downloads, and infected websites. Knowing this helps you avoid them!" },
                        { "confident", "Nice! Being cautious with downloads and keeping software updated puts you ahead in virus protection." }
                    }
                }
            };

            // Getter method for FeelingResponses
            public static string GetFeelingResponse(string topic, string feeling)
            {
                if (FeelingResponses.ContainsKey(topic) && FeelingResponses[topic].ContainsKey(feeling))
                {
                    return FeelingResponses[topic][feeling];
                }
                return "I'm not sure how to respond to that feeling, but cybersecurity is important for everyone!";
            }


            public static readonly Dictionary<string, string> PasswordFollowUpQuestions = new Dictionary<string, string>
            {
                { "1", "What makes a password strong?" },
                { "2", "Why shouldn't I reuse passwords?" },
                { "3", "What is a password manager?" },
                { "4", "Move to a new topic" }
            };

            public static readonly Dictionary<string, string> MalwareFollowUpQuestions = new Dictionary<string, string>
            {
                { "1", "How does malware spread?" },
                { "2", "What is ransomware?" },
                { "3", "How can I check if my device has malware?" },
                { "4", "Move to a new topic" }
            };

            public static readonly Dictionary<string, string> PhishingFollowUpQuestions = new Dictionary<string, string>
            {
                { "1", "How to spot phishing scams?" },
                { "2", "What should I do if I see one?" },
                { "3", "How to recover if I fell for a phishing scam?" },
                { "4", "Move to a new topic" }
            };

            public static readonly Dictionary<string, string> SafeBrowsingFollowUpQuestions = new Dictionary<string, string>
            {
                { "1", "What is HTTPS?" },
                { "2", "Why should I use an ad blocker?" },
                { "3", "How does browser security protect me?" },
                { "4", "Move to a new topic" }
            };

            public static readonly Dictionary<string, string> VirusFollowUpQuestions = new Dictionary<string, string>
            {
                { "1", "What types of viruses exist?" },
                { "2", "How can I prevent virus infections?" },
                { "3", "What should I do if I suspect a virus?" },
                { "4", "Move to a new topic" }
            };


            

            public static readonly Dictionary<string, string> PasswordFollowUpAnswers = new Dictionary<string, string>
            {
                { "1", "A strong password is at least 12 characters long and includes uppercase, lowercase, numbers, and symbols. Avoid personal details!" },
                { "2", "Reusing passwords makes all your accounts vulnerable! If one gets breached, hackers can access everything else." },
                { "3", "A password manager securely stores and generates unique passwords for each of your accounts." }
            };

            public static readonly Dictionary<string, string> MalwareFollowUpAnswers = new Dictionary<string, string>
            {
                { "1", "Malware spreads through email attachments, fake downloads, and malicious ads. Never open suspicious links or files!" },
                { "2", "Ransomware encrypts files and demands a ransom payment to unlock them. Always back up important data!" },
                { "3", "Run an antivirus scan, check for unusual slowdowns, and monitor network activity for unknown connections." }
            };

            public static readonly Dictionary<string, string> PhishingFollowUpAnswers = new Dictionary<string, string>
            {
                { "1", "Phishing scams use fake emails, urgent language, and links to fraudulent websites. Always verify sender details!" },
                { "2", "Report the email, don’t click any links, and educate others to prevent phishing attacks!" },
                { "3", "Immediately change your passwords, enable two-factor authentication, and check for fraudulent charges on your accounts." }
            };

            public static readonly Dictionary<string, string> SafeBrowsingFollowUpAnswers = new Dictionary<string, string>
            {
                { "1", "HTTPS encrypts your browsing data to keep it safe from attackers. Always check for 'https://' before entering sensitive info!" },
                { "2", "Ad blockers prevent malicious ads from tracking you or infecting your device." },
                { "3", "Browsers have built-in security features like anti-phishing warnings and sandboxing to prevent exploits." }
            };

            public static readonly Dictionary<string, string> VirusFollowUpAnswers = new Dictionary<string, string>
            {
                { "1", "Viruses come in many forms, such as Trojans, worms, spyware, and ransomware, each with different attack methods." },
                { "2", "Always keep software updated, avoid unknown downloads, and use trusted antivirus tools!" },
                { "3", "Run a full system scan, disconnect from the internet, and delete any unknown or suspicious files immediately." }
            };



            #endregion

            /*============================================================*/

            #region InvalidInputResponses
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
                Summary of GetRandomInvalidInputResponse():
                   Gets a random response for unrecognized inputs.
            _______________________________________________________________________________________
            */
            public static string GetRandomInvalidInputResponse()
            {
                Random random = new Random(); // create an instance of the Random class
                return InvalidInputResponses[random.Next(InvalidInputResponses.Length)]; // return a random response from the InvalidInputResponses array
            }

            #endregion

            /*============================================================*/

            #region NoNameResponses

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

            #endregion

            /*============================================================*/

        }

        /*============================================================*/

        #region AudioFileLocations

        /*
        _______________________________________________________________________________________
            Summary of AudioFiles:
                Centralizes all known audio file paths for the chatbot.
        _______________________________________________________________________________________
        */

        

        public static readonly Dictionary<string, string> AudioFiles = new Dictionary<string, string>
        {
            { "Intro", GlobalVariables.IntroFilePath }, //path to the chatbot's introductory voice greeting audio
            { "Excited", GlobalVariables.ExcitedFilePath }, //path to the excited meow audio
            { "Sad", GlobalVariables.SadFilePath }, //path to the sad meow audio
            { "Curious", GlobalVariables.CuriousFilePath }, //path to the curious meow audio
            { "Dialog",  GlobalVariables.DialogFilePath }, //path to the dialog meow audio, used during interaction
            { "Talk", GlobalVariables.TalkFilePath }, //path to the talk meow audio, used for explanation responses
            { "Purr",  GlobalVariables.PurrFilePath}, //path to the purring audio, used for the pet-the-cat option
            { "Bye", GlobalVariables.ByeFilePath }, //path to the goodbye meow audio
            { "Greeting",  GlobalVariables.GreetingFilePath },
            { "Tip", GlobalVariables.TipFilePath },
            { "Menu", GlobalVariables.MenuFilePath }

        };

        #endregion

        /*============================================================*/
    }
}
