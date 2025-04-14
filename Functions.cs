using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10439055_PROG_POE
{
    class Functions
    {
        public void WelcomeMessage()
        {
            DateTime now = DateTime.Now;
            int hour = now.Hour;

            if (hour >= 5 && hour < 12)
            {
                Console.WriteLine("Good morning! Welcome to Stitch your personal cyber security chatbot");
            }
            else if (hour >= 12 && hour < 17)
            {
                Console.WriteLine("Good afternoon! Welcome to Stitch your personal cyber security chatbot");
            }
            else if (hour >= 17 && hour < 22)
            {
                Console.WriteLine("Good evening! Welcome to Stitch your personal cyber security chatbot");
            }
            else
            {
                Console.WriteLine("Good night! ");
            }
            Console.WriteLine("");
            Console.WriteLine("\r\n   ▄████████     ███      ▄█      ███      ▄████████    ▄█    █▄    \r\n  ███    ███ ▀█████████▄ ███  ▀█████████▄ ███    ███   ███    ███   \r\n  ███    █▀     ▀███▀▀██ ███▌    ▀███▀▀██ ███    █▀    ███    ███   \r\n  ███            ███   ▀ ███▌     ███   ▀ ███         ▄███▄▄▄▄███▄▄ \r\n▀███████████     ███     ███▌     ███     ███        ▀▀███▀▀▀▀███▀  \r\n         ███     ███     ███      ███     ███    █▄    ███    ███   \r\n   ▄█    ███     ███     ███      ███     ███    ███   ███    ███   \r\n ▄████████▀     ▄████▀   █▀      ▄████▀   ████████▀    ███    █▀    \r\n                                                                    \r\n");
        }


        public void GreetUser()
        {
            Console.WriteLine("");
            Console.WriteLine("What is your name?");
            string sUserName = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Hello " + sUserName + ". You can ask me about password safety, phishing, safe browsing.");

        }

        private bool TryHandleBasicQuestions(string input)
        {
            string lowerInput = input.ToLower();

            switch (lowerInput)
            {
                case string s when s.Contains("how are you") || s.Contains("how you doing"):
                    Console.WriteLine("I'm just a bot, I'm here to help you stay safe online.");
                    return true;

                case string s when s.Contains("purpose") || s.Contains("why do you exist"):
                    Console.WriteLine("I'm here to educate you about cybersecurity and help you avoid online threats.");
                    return true;

                case string s when s.Contains("ask") || s.Contains("questions") || s.Contains("help with"):
                    Console.WriteLine("You can ask me about password safety, phishing, safe browsing, malware protection, and more!");
                    return true; 

                case string s when s.Contains("hello") || s.Contains("hi") || s.Contains("greetings"):

                    int hour = DateTime.Now.Hour;
                    string timeGreeting = hour switch
                    {
                        >= 5 and < 12 => "Good morning!",
                        >= 12 and < 17 => "Good afternoon!",
                        >= 17 and < 22 => "Good evening!",
                        _ => "Good night!"
                    };
                    Console.WriteLine($"{timeGreeting} How can I help you with cybersecurity today?");
                    return true;

                case string s when s.Contains("thank") || s.Contains("appreciate"):
                    Console.WriteLine("You're welcome! Stay safe online!");
                    return true;

                case string s when s.Contains("bye") || s.Contains("goodbye") || s.Contains("see you"):
                    Console.WriteLine("Goodbye! Remember to practice good cybersecurity habits!");
                    return true;



                default:
                    return false;
            }
        }



        public void BasicQuestions(string sInput)
        {
            if (TryHandleBasicQuestions(sInput))
            {
                return;
            }
           
            if (TryHandleSecurityTopics(sInput))
            {
                return;
            }

            Console.WriteLine("I didn't quite understand that. You can ask me about:");
            Console.WriteLine("- Password security\n- Phishing scams\n- Safe browsing");
        }


    }
}
