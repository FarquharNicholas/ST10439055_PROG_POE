# Stitch - Personal Cybersecurity Chatbot

## Overview
Stitch is a personal cybersecurity chatbot designed to help users understand the basics of cybersecurity, such as password security, phishing scams, and safe browsing. The chatbot provides helpful tips and responses to common questions related to these topics. It offers an interactive experience with voice playback and time-sensitive greetings based on the user's input.

## Features
- **Interactive User Experience**: Users can ask questions related to password security, phishing, and safe browsing.
- **Voice Playback**: Provides an audio greeting to the user and can play a custom voice message.
- **Time-based Greetings**: The chatbot greets users with "Good Morning", "Good Afternoon", "Good Evening", or "Good Night" based on the current time.
- **User Input Handling**: Validates input and provides relevant advice or responses related to cybersecurity topics.
- **Personalized Greetings**: Users are prompted for their name, and the chatbot personalizes the interaction based on this information.

## Requirements
To run the application, you need:
- .NET Core SDK or .NET 5+ installed.
- NAudio library for voice playback (installed via NuGet).
- An MP3 file (e.g., `StitchVoice.mp3`) for voice output. Ensure the file is located in the path specified within the code.

## Installation

### Clone the Repository
```bash
git clone https://github.com/your-username/Stitch-Cybersecurity-Chatbot.git
cd Stitch-Cybersecurity-Chatbot
