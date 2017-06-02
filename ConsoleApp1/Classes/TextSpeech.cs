using ConsoleApp1.Interfaces;
using System.Speech.Synthesis;

namespace ConsoleApp1.Classes
{
    /// <summary>
    /// Text to speech should reference System.Speech
    /// </summary>
    public class TextSpeech : IEntrance
    {
        public void Run()
        {
            SpeechSynthesizer ss = new SpeechSynthesizer();
            ss.Speak("你好");
        }
    }
}
