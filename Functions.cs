using NAudio.Wave;
using ST10439055_PROG_POE;
using System.Text.RegularExpressions;

class Functions
{
    //play voice message
    public void PlayVoice()
    {
        string filePath = @"C:\Users\nicho\Desktop\PROG_POE\ST10439055_PROG_POE\StitchVoice.mp3";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Error: Voice file not found.");
            return;
        }

        try
        {
            using (var reader = new AudioFileReader(filePath))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(reader);
                outputDevice.Play();
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    // Wait for sound
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error playing voice file: {ex.Message}");
        }
    }

    // display welcome message
    public void WelcomeMessage()
    {
        DateTime now = DateTime.Now;
        int hour = now.Hour;

        if (hour >= 5 && hour < 12)
        {
            Console.WriteLine("Good morning. Welcome to Stitch your personal cyber security chatbot.");
        }
        else if (hour >= 12 && hour < 17)
        {
            Console.WriteLine("Good afternoon. Welcome to Stitch your personal cyber security chatbot.");
        }
        else if (hour >= 17 && hour < 22)
        {
            Console.WriteLine("Good evening. Welcome to Stitch your personal cyber security chatbot.");
        }
        else
        {
            Console.WriteLine("Good night. Welcome to Stitch your personal cyber security chatbot.");
        }
        Console.WriteLine("\r\n   ▄████████     ███      ▄█      ███      ▄████████    ▄█    █▄    \r\n  ███    ███ ▀█████████▄ ███  ▀█████████▄ ███    ███   ███    ███   \r\n  ███    █▀     ▀███▀▀██ ███▌    ▀███▀▀██ ███    █▀    ███    ███   \r\n  ███            ███   ▀ ███▌     ███   ▀ ███         ▄███▄▄▄▄███▄▄ \r\n▀███████████     ███     ███▌     ███     ███        ▀▀███▀▀▀▀███▀  \r\n         ███     ███     ███      ███     ███    █▄    ███    ███   \r\n   ▄█    ███     ███     ███      ███     ███    ███   ███    ███   \r\n ▄████████▀     ▄████▀   █▀      ▄████▀   ████████▀    ███    █▀    \r\n                                                                    \r\n");
    }

    // greet the user and store their name
    public void GreetUser()
    {
        Console.WriteLine("");
        Console.WriteLine("What is your name?");
        string sUserName = Console.ReadLine();

        
        while (string.IsNullOrWhiteSpace(sUserName))
        {
            Console.WriteLine("Please enter a valid name.");
            sUserName = Console.ReadLine();
        }

        Console.WriteLine("");
        Console.WriteLine($"Hello {sUserName}, I am Stitch. You can ask me about password safety, phishing, and safe browsing.");
    }

    // user input
    public void HandleUserInput(string input)
    {
        UserInteraction basicHandler = new BasicQuestionsHandler();
        UserInteraction securityHandler = new SecurityQuestionsHandler();

        // basic questions first
        bool handledBasic = TryHandleBasicQuestions(input, basicHandler);

        // If not , security questions
        if (!handledBasic)
        {
            securityHandler.HandleInput(input);
        }
    }

    private bool TryHandleBasicQuestions(string input, UserInteraction handler)
    {
        string lowerInput = input.ToLower();
        if (lowerInput.Contains("how are you") || lowerInput.Contains("how you doing") ||
            lowerInput.Contains("purpose") || lowerInput.Contains("why do you exist") ||
            lowerInput.Contains("ask") || lowerInput.Contains("questions") ||
            lowerInput.Contains("thank") || lowerInput.Contains("appreciate") ||
            Regex.IsMatch(lowerInput, @"\b(hello|hi|greetings)\b") ||
            lowerInput.Contains("bye") || lowerInput.Contains("goodbye"))
        {
            handler.HandleInput(input);
            return true;
        }
        return false;
    }
}