using System.Media;

namespace CybersecurityAwarenessBot
{
    public static class AudioHelper
    {
        public static void PlayAudio(string filePath)
        {
            if (GlobalVariables.isMuted) // Check if the audio is muted
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
               TextFormatter.SetErrorMessageText($"Error: The file '{filePath}' was not found. Please ensure the file path is correct."); //notify user of the missing file
            }
            catch (InvalidOperationException) //handle invalid file format or issues with audio playback
            {
                TextFormatter.SetErrorMessageText("Error: The WAV file could not be played. Please check the file format or integrity."); //notify user of file issues
            }
            catch (Exception e) //handle any unexpected errors during audio playback
            {
                TextFormatter.SetErrorMessageText($"An unexpected error occurred: {e.Message}"); //output the error message for debugging purposes
            }
        }
    }
}
