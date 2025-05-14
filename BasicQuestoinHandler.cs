using System;
using System.Text.RegularExpressions;

namespace ST10439055_PROG_POE
{
    //handles basic chatbot questions
    public class BasicQuestionsHandler : UserInteraction
    {
        
        public BasicQuestionsHandler(UserMemory memory) : base(memory) { }


        public override bool HandleInput(string input)
        {
            string lowerInput = input.ToLower(); 
            bool handled = true; 

            // Respond to "how are you" or similar
            if (lowerInput.Contains("how are you") || lowerInput.Contains("how you doing"))
            {
                string[] responses = new string[]
                {
                    $"I'm functioning optimally! How can I help you with cybersecurity today, {userMemory.UserName}?",
                    $"I'm just a bot, but I'm here and ready to help you stay safe online, {userMemory.UserName}.",
                    $"I'm always ready to discuss cybersecurity with you, {userMemory.UserName}! What would you like to know?"
                };
                Console.WriteLine($"Stitch: {responses[random.Next(responses.Length)]}");
            }
            // Respond to questions about the bot's purpose
            else if (lowerInput.Contains("purpose") || lowerInput.Contains("why do you exist"))
            {
                string[] responses = new string[]
                {
                    "I'm here to educate you about cybersecurity and help you avoid online threats.",
                    $"My purpose is to make cybersecurity accessible and understandable for you, {userMemory.UserName}.",
                    "I exist to help people like you navigate the complex world of online security with confidence!"
                };
                Console.WriteLine($"Stitch: {responses[random.Next(responses.Length)]}");
                userMemory.SetLastTopic("purpose");
            }
            // Respond to requests for help or topics
            else if (lowerInput.Contains("ask") || lowerInput.Contains("questions") || lowerInput.Contains("help with"))
            {
                string response = $"You can ask me about password safety, phishing and safe browsing." +
                    $"\nI also know about VPNs, password managers, and how to identify cyber threats.";
                AddPersonalizedTouch(ref response);
                Console.WriteLine($"Stitch: {response}");
                userMemory.SetLastTopic("topics"); 
            }
            
            else if (Regex.IsMatch(lowerInput, @"\b(hello|hi|greetings)\b"))
            {
                GreetBasedOnTime();  // greet the user based on current time
            }
            // Respond to expressions of thanks
            else if (lowerInput.Contains("thank") || lowerInput.Contains("appreciate"))
            {
                string[] responses = new string[]
                {
                    $"You're welcome, {userMemory.UserName}. I'm glad I could help!",
                    "You're welcome. Stay safe online!",
                    "No problem at all! Cybersecurity is important, and I'm here to help."
                };
                Console.WriteLine($"Stitch: {responses[random.Next(responses.Length)]}");
            }
            // Respond to goodbyes
            else if (lowerInput.Contains("quit") || lowerInput.Contains("goodbye") || lowerInput.Contains("end"))
            {
                string[] responses = new string[]
                {
                    $"Goodbye, {userMemory.UserName}. Remember to practice good cybersecurity habits!",
                    $"Take care, {userMemory.UserName}! Stay secure out there.",
                    $"Until next time, {userMemory.UserName}. Keep your digital life safe!"
                };
                Console.WriteLine($"Stitch: {responses[random.Next(responses.Length)]}");
            }
            else
            {
                handled = false;  // If none of the conditions matched, return false so another handler can try
            }

            return handled;  // Return whether the input was handled
        }
    }
}
