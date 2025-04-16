using NAudio.Wave;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ST10439055_PROG_POE
{
    // Abstract base class for user interaction
    public abstract class UserInteraction
    {
        public abstract void HandleInput(string input);
    }

    // Derived class for handling basic questions
    public class BasicQuestionsHandler : UserInteraction
    {
        public override void HandleInput(string input)
        {
            string lowerInput = input.ToLower();

            if (lowerInput.Contains("how are you") || lowerInput.Contains("how you doing"))
            {
                Console.WriteLine("Stitch: I'm just a bot, I'm here to help you stay safe online.");
            }
            else if (lowerInput.Contains("purpose") || lowerInput.Contains("why do you exist"))
            {
                Console.WriteLine("Stitch: I'm here to educate you about cybersecurity and help you avoid online threats.");
            }
            else if (lowerInput.Contains("ask") || lowerInput.Contains("questions") || lowerInput.Contains("help with"))
            {
                Console.WriteLine("Stitch: You can ask me about password safety, phishing, and safe browsing.");
            }
            else if (Regex.IsMatch(lowerInput, @"\b(hello|hi|greetings)\b"))
            {
                GreetBasedOnTime();
            }
            else if (lowerInput.Contains("thank") || lowerInput.Contains("appreciate"))
            {
                Console.WriteLine("Stitch: You're welcome. Stay safe online.");
            }
            else if (lowerInput.Contains("bye") || lowerInput.Contains("goodbye") || lowerInput.Contains("see you"))
            {
                Console.WriteLine("Stitch: Goodbye. Remember to practice good cybersecurity habits.");
            }
            else
            {
                Console.WriteLine("Stitch: I don't understand that. You can ask me about:" +
                    "\n- Password security" +
                    "\n- Phishing scams" +
                    "\n- Safe browsing");
            }
        }

        private void GreetBasedOnTime()
        {
            int hour = DateTime.Now.Hour;
            string timeGreeting = hour switch
            {
                >= 5 and < 12 => "Stitch: Good morning.",
                >= 12 and < 17 => "Stitch: Good afternoon.",
                >= 17 and < 22 => "Stitch: Good evening.",
                _ => "Stitch: Good night."
            };
            Console.WriteLine($"{timeGreeting} How can I help you with cybersecurity today?");
        }
    }

    
    public class SecurityQuestionsHandler : UserInteraction
    {
        public override void HandleInput(string input)
        {
            string lowerInput = input.ToLower();

            if (lowerInput.Contains("password"))
            {
                HandlePasswordQuestions(input);
            }
            else if (lowerInput.Contains("phishing"))
            {
                HandlePhishingQuestions(input);
            }
            else if (lowerInput.Contains("browsing") || lowerInput.Contains("internet"))
            {
                HandleBrowsingQuestions(input);
            }
            else if (lowerInput.Contains("vpn"))
            {
                HandleVPNQuestion();
            }
            else if (lowerInput.Contains("identify") || lowerInput.Contains("spot"))
            {
                HandlePhishingIdentification();
            }
            else if (lowerInput.Contains("manager"))
            {
                HandlePasswordManagerQuestion();
            }
            else if (lowerInput.Contains("strong"))
            {
                HandlePasswordStrengthQuestion();
            }
            else
            {
                Console.WriteLine("Stitch: I don't have an answer for that. Ask me about password security, phishing, or safe browsing.");
            }
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
                HandlePhishingIdentification();
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
                HandleVPNQuestion();
            }
            else
            {
                Console.WriteLine("Stitch: For safe browsing:" +
                    "\n- Look for HTTPS in URLs" +
                    "\n- Avoid public Wi-Fi for sensitive activities" +
                    "\n- Keep your browser updated");
            }
        }

        private void HandleVPNQuestion()
        {
            Console.WriteLine("Stitch: A VPN (Virtual Private Network) encrypts your internet connection and helps you stay private online, protecting you from cyber threats.");
        }

        private void HandlePhishingIdentification()
        {
            Console.WriteLine("Stitch: To spot phishing attempts, look for:" +
                "\n- Suspicious or generic sender addresses" +
                "\n- Urgent language or threats" +
                "\n- Requests for sensitive data (passwords, social security number, etc.)");
        }

        private void HandlePasswordManagerQuestion()
        {
            Console.WriteLine("Stitch: A password manager is a tool that securely stores and helps you generate strong, unique passwords for every account.");
        }

        private void HandlePasswordStrengthQuestion()
        {
            Console.WriteLine("Stitch: A strong password should:" +
                "\n- Be at least 12 characters long" +
                "\n- Contain a mix of upper and lower case letters, numbers, and symbols" +
                "\n- Not be based on easily guessed information like names or birthdates");
        }
    }
}