Description
Stitch is an interactive chatbot designed to educate users about cybersecurity topics. It provides personalized responses about password safety, phishing, secure browsing, VPNs, and more, while adapting to user moods and interests.

Features

Basic Conversation Handling: Greetings, farewells, and general questions

Cybersecurity Expertise: Answers questions about passwords, phishing, malware, etc.

Personalization: Detects user mood (worried, curious, frustrated) and interests

Context Awareness: Remembers conversation history for follow-up questions

Voice Greeting: Plays an introductory audio clip

How It Works

Startup: The chatbot greets the user, asks for their name, and plays a welcome voice clip.

Input Processing:

Basic questions (e.g., "Hi", "How are you?") go to BasicQuestionsHandler

Security-related queries (e.g., "How to spot phishing?") go to SecurityQuestionsHandler

Sentiment analysis adjusts responses for worried/frustrated users

Response Generation:

Uses predefined answer templates with randomization

Adds personalized touches based on user interests (e.g., privacy, passwords)

Exit: Type "bye", "quit", or "exit" to end the chat

Code Structure

Program.cs: Main entry point, manages chat loop

UserInteraction.cs: Base class for conversation handlers

BasicQuestionsHandler.cs: Handles greetings, farewells, and simple queries

SecurityQuestionsHandler.cs: Provides cybersecurity advice

UserMemory.cs: Stores user data (name, interests, conversation history)

SentimentDetector.cs: Analyzes user mood from text

InterestDetector.cs: Identifies topics of interest

Functions.cs: Helper methods (voice, greetings, input handling)

Requirements

.NET 6.0+

NAudio library (for voice playback)

Usage

Run the program

Enter your name when prompted

Ask cybersecurity questions or chat normally

Type "quit" to exit

Example Queries

"How do I create a strong password?"

"What is phishing?"

"Should I use a VPN?"

"How can I tell if an email is fake?"

Installation
Clone the repository:
git clone https://github.com/your-username/Stitch-Cybersecurity-Chatbot.git  
cd Stitch-Cybersecurity-Chatbot  
