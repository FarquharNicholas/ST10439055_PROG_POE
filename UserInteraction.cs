using System;
using System.Text.RegularExpressions;

namespace ST10439055_PROG_POE
{
    // Abstract base class for user interaction
    public abstract class UserInteraction
    {
        protected UserMemory userMemory;
        protected Random random = new Random();

        public UserInteraction(UserMemory memory)
        {
            userMemory = memory;
        }

        public abstract bool HandleInput(string input);

        protected void GreetBasedOnTime()
        {
            int hour = DateTime.Now.Hour;
            string timeGreeting = hour switch
            {
                >= 5 and < 12 => "Stitch: Good morning",
                >= 12 and < 17 => "Stitch: Good afternoon",
                >= 17 and < 22 => "Stitch: Good evening",
                _ => "Stitch: Good night"
            };
            Console.WriteLine($"{timeGreeting}, {userMemory.UserName}. How can I help you with cybersecurity today?");
        }

        protected void AddPersonalizedTouch(ref string response)
        {
            // Add personalization based on mood if detected
            if (!string.IsNullOrEmpty(userMemory.CurrentMood))
            {
                switch (userMemory.CurrentMood.ToLower())
                {
                    case "worried":
                        response = $"I understand you might be feeling concerned. {response}";
                        break;
                    case "curious":
                        response = $"I appreciate your curiosity! {response}";
                        break;
                    case "frustrated":
                        response = $"I can sense this might be frustrating. Let me help clarify. {response}";
                        break;
                    case "confused":
                        response = $"No need to worry if this seems complex. {response}";
                        break;
                }
            }

            // Add reference to interests if applicable
            var interests = userMemory.GetInterests();
            if (interests.Count > 0 && random.Next(10) < 3) // 30% chance to mention interests
            {
                string interest = interests[random.Next(interests.Count)];
                response += $" Since you're interested in {interest}, you might also want to know that good {interest} practices contribute to your overall online security.";
            }
        }
    }
}