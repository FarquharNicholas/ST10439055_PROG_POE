using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            Console.WriteLine("");
            Console.WriteLine("\r\n   ▄████████     ███      ▄█      ███      ▄████████    ▄█    █▄    \r\n  ███    ███ ▀█████████▄ ███  ▀█████████▄ ███    ███   ███    ███   \r\n  ███    █▀     ▀███▀▀██ ███▌    ▀███▀▀██ ███    █▀    ███    ███   \r\n  ███            ███   ▀ ███▌     ███   ▀ ███         ▄███▄▄▄▄███▄▄ \r\n▀███████████     ███     ███▌     ███     ███        ▀▀███▀▀▀▀███▀  \r\n         ███     ███     ███      ███     ███    █▄    ███    ███   \r\n   ▄█    ███     ███     ███      ███     ███    ███   ███    ███   \r\n ▄████████▀     ▄████▀   █▀      ▄████▀   ████████▀    ███    █▀    \r\n                                                                    \r\n");
        }


        public void GreetUser()
        {
            Console.WriteLine("");
            Console.WriteLine("What is your name?");
            string sUserName = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Hello " + sUserName + " i am Stitch. You can ask me about password safety, phishing, safe browsing.");

        }

        private bool TryHandleBasicQuestions(string input)
        {
            string lowerInput = input.ToLower();

            switch (lowerInput)
            {
                case string s when s.Contains("how are you") || s.Contains("how you doing"):
                    Console.WriteLine("Stitch: I'm just a bot, I'm here to help you stay safe online.");
                    return true;

                case string s when s.Contains("purpose") || s.Contains("why do you exist"):
                    Console.WriteLine("Stitch: I'm here to educate you about cybersecurity and help you avoid online threats.");
                    return true;

                case string s when s.Contains("ask") || s.Contains("questions") || s.Contains("help with"):
                    Console.WriteLine("Stitch: You can ask me about password safety, phishing, safe browsing.");
                    return true;

                case string s when Regex.IsMatch(s, @"\b(hello|hi|greetings)\b"):
                    //Whole words, (had conflicts when trying to ask about phishing)
                    int hour = DateTime.Now.Hour;
                    string timeGreeting = hour switch
                    {
                        >= 5 and < 12 => "Stitch: Good morning.",
                        >= 12 and < 17 => "Stitch: Good afternoon.",
                        >= 17 and < 22 => "Stitch: Good evening.",
                        _ => "Stitch: Good night."
                    };
                    Console.WriteLine($"{timeGreeting} How can I help you with cybersecurity today?");
                    return true;

                case string s when s.Contains("thank") || s.Contains("appreciate"):
                    Console.WriteLine("Stitch: You're welcome. Stay safe online.");
                    return true;

                case string s when s.Contains("bye") || s.Contains("goodbye") || s.Contains("see you"):
                    Console.WriteLine("Stitch: Goodbye. Remember to practice good cybersecurity habits.");
                    return true;

                default:
                    return false;
            }
        }

        private bool TryHandleSecurityTopics(string input)
        {
            string lowerInput = input.ToLower();

            if (lowerInput.Contains("password"))
            {
                HandlePasswordQuestions(input);
                return true;
            }

            if (lowerInput.Contains("phishing"))
            {
                HandlePhishingQuestions(input);
                return true;
            }

            if (lowerInput.Contains("browsing") || lowerInput.Contains("internet"))
            {
                HandleBrowsingQuestions(input);
                return true;
            }

            return false;
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

            Console.WriteLine("Stitch: I don't understand that. You can ask me about:");
            Console.WriteLine("- Password security" +
                "\n- Phishing scams" +
                "\n- Safe browsing");
        }

        private void HandlePasswordQuestions(string question)
        {
            if (question.Contains("strong") || question.Contains("create"))
            {
                Console.WriteLine("Stitch: A strong password should:" +
                    "\n- Be at least 12 characters long" +
                    "\n- Include numbers, symbols, and mixed case" +
                    "\n- Not contain personal information");
            }
            else if (question.Contains("manager"))
            {
                Console.WriteLine("Stitch: Password managers are secure tools that help you generate and store complex passwords.");
            }
            else
            {
                Console.WriteLine("Stitch: For password security, remember to:" +
                    "\n- Use unique passwords for each account" +
                    "\n- Change them regularly" +
                    "\n- Never share them with anyone");
            }
        }

        private void HandlePhishingQuestions(string question)
        {
            if (question.Contains("identify") || question.Contains("spot"))
            {
                Console.WriteLine("Stitch: Watch for:" +
                    "\n- Urgent or threatening language" +
                    "\n- Suspicious sender addresses" +
                    "\n- Requests for personal information");
            }
            else
            {
                Console.WriteLine("Stitch: Phishing is when attackers pretend to be trustworthy entities to steal your data.");
            }
        }

        private void HandleBrowsingQuestions(string question)
        {
            if (question.Contains("vpn"))
            {
                Console.WriteLine("Stitch: VPNs encrypt your internet connection, making your browsing more secure.");
            }
            else
            {
                Console.WriteLine("Stitch: For safe browsing:" +
                    "\n- Look for HTTPS in URLs" +
                    "\n- Avoid public Wi-Fi for sensitive activities" +
                    "\n- Keep your browser updated");
            }
        }
    }

}

