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

        static void DisplayAsciiArt()
        {
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
            Console.WriteLine(asciiArt);
        }



        static void GreetUser()
        {
            Console.WriteLine("\n  /\\      /\\     \r\n /  \\____/  \\    \r\n<            >\t | Hello! I am the CyberCat,          |\r\n<   O    O   >   | Let me tell you about CyberSecurity|\r\n \\    v     /\r\n  ~~~~~~~~~~\r\n");
            Console.Write("Are you ready to learn about CyberSecurity?: ");
            string greetingAnswer = Console.ReadLine().ToLower();

            if (greetingAnswer == "yes")
            {
                Console.WriteLine("\n  /\\      /\\     \r\n /  \\____/  \\    \r\n<            >\t \r\n<   >    <   >   | Great! Lets get started! |\r\n \\    v     /\r\n  ~~~~~~~~~~\r\n");
                MainMenu(); //this will start up the menu (question or leave)
            }
            else
            {
                Console.WriteLine("\n  /\\      /\\     \r\n /  \\____/  \\    \r\n<            >\t \r\n<   O    O   >   | Ok, see you next time!|\r\n \\    v     /\r\n  ~~~~~~~~~~\r\n");
                Console.WriteLine("Press any key to close the program!");
            }
        }

        static void MainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n  /\\      /\\     \r\n /  \\____/  \\    \r\n<            >\t \r\n<   O    O   >   | What do you want to do?|\r\n \\    v     /\r\n  ~~~~~~~~~~");
                Console.WriteLine("1. Ask a question");
                Console.WriteLine("2. Pet the cat!");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AskQuestion();
                        break;
                    case "2":
                        Console.WriteLine("\n  /\\  <3  /\\     \r\n /  \\____/  \\    \r\n<            >\t \r\n<   O    <   >   | Aw, thanks!|\r\n \\    w     /\r\n  ~~~~~~~~~~\r\n");
                        break;
                    case "3":
                        exit = true;
                        Console.WriteLine("\n  /\\      /\\     \r\n /  \\____/  \\    \r\n<            >\t \r\n<   O    O   >   | Goodbye! Stay safe online!|\r\n \\    v     /\r\n  ~~~~~~~~~~\r\n");
                        break;
                    case "":
                        Console.WriteLine("\n  /\\      /\\\r\n /  \\____/  \\   | No input detected,                  |\r\n<            >  | Please do not leave the input blank |\r\n<   Ò    Ó   >\r\n \\    ^     /\r\n  ~~~~~~~~~~\r\n");
                        break;
                    default:
                        Console.WriteLine("\n  /\\      /\\\r\n /  \\____/  \\    | I don't understand your input... |\r\n<            >   | Can you try again?               |\r\n<   Ô    ó   >\r\n \\    0     /\r\n  ~~~~~~~~~~\r\n");
                        break;
                }
            }
        }

        static void AskQuestion()
        {
            Console.WriteLine("\n  /\\      /\\     \r\n /  \\____/  \\    \r\n<            >\t | Great! I love teaching people how to be safe online! |\r\n<   ^    ^   >   | Just type the topic you want to learn about,        |\r\n \\    v     /    | and I'll look for a keyword I have knowledge on!    |\r\n  ~~~~~~~~~~\r\n");
            string question = Console.ReadLine().ToLower();

            bool wantsToQuit = false;

            while (!wantsToQuit)
            {
                // dictionary of keywords and responses
                if (question.Contains("malware"))
                {
                    Console.WriteLine("\n  /\\      /\\     \r\n /  \\____/  \\    \r\n<            >\t | Malware is a program that wants to  |\r\n<   O    O   >   | do bad things to your computer!     |\r\n \\    0     /    \r\n  ~~~~~~~~~~\r\n");
                    Console.WriteLine("\n  /\\      /\\     \r\n /  \\____/  \\    \r\n<            >\t | Would you like to learn about anything else? |\r\n<   O    O   >   | Type \"quit\" to go back to the main menu.     |\r\n \\    v     /    \r\n  ~~~~~~~~~~\r\n");
                    question = Console.ReadLine().ToLower();
                }
                else if (question.Contains("password"))
                {
                    Console.WriteLine("\n  /\\      /\\     \r\n /  \\____/  \\    \r\n<            >\t | A password is used to secure accounts and    |\r\n<   O    O   >   | devices. Make sure to use strong, complex    |\r\n \\    0     /    | passwords and don't give them out to anyone! |\r\n  ~~~~~~~~~~\r\n");
                    Console.WriteLine("\n  /\\      /\\     \r\n /  \\____/  \\    \r\n<            >\t | Would you like to learn about anything else? |\r\n<   O    O   >   | Type \"quit\" to go back to the main menu.     |\r\n \\    v     /    \r\n  ~~~~~~~~~~\r\n");
                    question = Console.ReadLine().ToLower();
                }
                else if (question.Contains("virus"))
                {
                    Console.WriteLine("  /\\      /\\     \r\n /  \\____/  \\    \r\n<            >\t | That's a type of malware! They can do many     |\r\n<   O    O   >   | bad things to your computer like delete things |\r\n \\    0     /    \r\n  ~~~~~~~~~~\r\n");
                    Console.WriteLine("\n  /\\      /\\     \r\n /  \\____/  \\    \r\n<            >\t | Would you like to learn about anything else? |\r\n<   O    O   >   | Type \"quit\" to go back to the main menu.     |\r\n \\    v     /    \r\n  ~~~~~~~~~~\r\n");
                    question = Console.ReadLine().ToLower();
                }
                else if (string.IsNullOrWhiteSpace(question))
                {
                    Console.WriteLine("\n  /\\      /\\\r\n /  \\____/  \\   | No input detected,                  |\r\n<            >  | Please do not leave the input blank |\r\n<   Ò    Ó   >\r\n \\    ^     /\r\n  ~~~~~~~~~~\r\n");
                    Console.WriteLine("\n  /\\      /\\     \r\n /  \\____/  \\    \r\n<            >\t | Would you like to learn about anything else? |\r\n<   O    O   >   | Type \"quit\" to go back to the main menu.     |\r\n \\    v     /    \r\n  ~~~~~~~~~~\r\n");
                    question = Console.ReadLine().ToLower();
                }
                else if (question.Contains("quit"))
                {
                    wantsToQuit = true;
                }
                else
                {
                    Console.WriteLine("\n  /\\      /\\\r\n /  \\____/  \\    | I don't understand your input... |\r\n<            >   | Can you try again?               |\r\n<   Ô    ó   >\r\n \\    0     /\r\n  ~~~~~~~~~~\r\n");
                    question = Console.ReadLine().ToLower();
                }


            }

            Console.WriteLine("\n  /\\      /\\     \r\n /  \\____/  \\    \r\n<            >\t \r\n<   O    O   >   | Hope you learned something today!|\r\n \\    v     /\r\n  ~~~~~~~~~~\r\n");

        }

    }
}

