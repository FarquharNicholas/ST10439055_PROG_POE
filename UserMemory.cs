using System;
using System.Collections.Generic;

namespace ST10439055_PROG_POE
{
    // Class to store user information and interests
    public class UserMemory
    {
        public string UserName { get; set; }
        public string CurrentMood { get; set; }
        private List<string> interests = new List<string>();
        private List<string> conversationHistory = new List<string>();
        private string lastTopic = string.Empty;
        private const int MaxHistoryItems = 10;

        public UserMemory()
        {
            UserName = "User";
            CurrentMood = string.Empty;
        }

        public void AddInterest(string interest)
        {
            if (!string.IsNullOrEmpty(interest) && !interests.Contains(interest))
            {
                interests.Add(interest);
            }
        }

        public List<string> GetInterests()
        {
            return interests;
        }

        public void AddToConversationHistory(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                conversationHistory.Add(message);

                // Keep history at a manageable size
                if (conversationHistory.Count > MaxHistoryItems)
                {
                    conversationHistory.RemoveAt(0);
                }
            }
        }

        public List<string> GetConversationHistory()
        {
            return conversationHistory;
        }

        public void SetLastTopic(string topic)
        {
            lastTopic = topic;
        }

        public string GetLastTopic()
        {
            return lastTopic;
        }
    }
}