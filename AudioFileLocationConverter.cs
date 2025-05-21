using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersecurityAwarenessBot
{
    public class AudioFileLocationConverter
    {
        public static void AudioFileFinder()
        {
            // Move up from 'bin\Debug\net8.0' to your project root
            string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;

            GlobalVariables.IntroFilePath = Path.Combine(projectRoot, "Audio Files", "Chatbot_voice_greeting.wav");
            
            GlobalVariables.ExcitedFilePath = Path.Combine(projectRoot, "Audio Files", "Excited_meow.wav");

            GlobalVariables.SadFilePath = Path.Combine(projectRoot, "Audio Files", "Sad_meow.wav");
            
            GlobalVariables.CuriousFilePath = Path.Combine(projectRoot, "Audio Files", "Curious_meow.wav");
            
            GlobalVariables.DialogFilePath = Path.Combine(projectRoot, "Audio Files", "Dialog_meow.wav");
            
            GlobalVariables.TalkFilePath = Path.Combine(projectRoot, "Audio Files", "Talk_meow.wav");

            GlobalVariables.PurrFilePath = Path.Combine(projectRoot, "Audio Files", "Purr_meow.wav");
            
            GlobalVariables.ByeFilePath = Path.Combine(projectRoot, "Audio Files", "Bye_meow.wav");
            
            GlobalVariables.GreetingFilePath = Path.Combine(projectRoot, "Audio Files", "Greeting_meow.wav");
            
            GlobalVariables.TipFilePath = Path.Combine(projectRoot, "Audio Files", "Tip_meow.wav");
            
            GlobalVariables.MenuFilePath = Path.Combine(projectRoot, "Audio Files", "Menu_meow.wav");

        }
    }
}
//