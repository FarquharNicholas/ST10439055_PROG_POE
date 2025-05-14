using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ST10439055_PROG_POE
{
    public class SecurityQuestionsHandler : UserInteraction
    {
        private Dictionary<string, List<string>> securityResponses;

        public SecurityQuestionsHandler(UserMemory memory) : base(memory)
        {
            InitializeSecurityResponses();
        }

        private void InitializeSecurityResponses()
        {
            securityResponses = new Dictionary<string, List<string>>
            {
                { "password_general", new List<string> {
                    "For password security, remember to:\n- Use unique passwords for each account\n- Change them regularly\n- Never share them with anyone",
                    "Your passwords are your first line of defense. Make sure they're unique, complex, and changed regularly.",
                    "Think of passwords like keys to your digital home. You wouldn't use the same key for your front door, car, and office, would you?"
                }},
                { "password_strength", new List<string> {
                    "A strong password should:\n- Be at least 12 characters long\n- Contain a mix of upper and lower case letters, numbers, and symbols\n- Not be based on easily guessed information like names or birthdates",
                    "Strong passwords are like strong locks - they use complexity to keep intruders out. Aim for at least 12 characters with a mix of letters, numbers, and symbols.",
                    "The best passwords are long passphrases that are easy for you to remember but difficult for others to guess. Try combining several random words with numbers and symbols."
                }},
                { "password_manager", new List<string> {
                    "A password manager is a tool that securely stores and helps you generate strong, unique passwords for every account.",
                    "Password managers are like digital vaults that remember all your passwords so you don't have to. They also help generate strong, unique passwords for each site.",
                    "Think of a password manager as your personal security assistant - it remembers your passwords, generates strong new ones, and keeps them all safe behind one master password."
                }},
                { "phishing_general", new List<string> {
                    "Phishing is when attackers pretend to be trustworthy entities to steal your data.",
                    "Phishing attacks trick you into providing sensitive information by pretending to be someone you trust. Always verify before sharing personal data.",
                    "Think of phishing as digital disguises - attackers dress up as trusted organizations to trick you into revealing your secrets."
                }},
                { "phishing_identification", new List<string> {
                    "To spot phishing attempts, look for:\n- Suspicious or generic sender addresses\n- Urgent language or threats\n- Requests for sensitive data (passwords, social security number, etc.)",
                    "Watch for these phishing red flags: unexpected attachments, poor grammar, generic greetings, and URLs that don't match the organization they claim to be from.",
                    "Real organizations rarely ask for sensitive information via email. If you're asked to 'verify your account' by clicking a link, it's often a phishing attempt."
                }},
                { "browsing_general", new List<string> {
                    "For safe browsing:\n- Look for HTTPS in URLs\n- Avoid public Wi-Fi for sensitive activities\n- Keep your browser updated",
                    "When browsing, think of HTTPS as your security guard - it encrypts your connection to websites, protecting your data from prying eyes.",
                    "Safe browsing is about awareness - check for secure connections (HTTPS), be cautious about what you download, and keep your software updated."
                }},
                { "vpn", new List<string> {
                    "A VPN (Virtual Private Network) encrypts your internet connection and helps you stay private online, protecting you from cyber threats.",
                    "VPNs are like secret tunnels for your internet traffic - they hide your data from prying eyes, especially useful on public Wi-Fi.",
                    "Think of a VPN as a privacy shield that masks your online activities and location, making it harder for others to track or target you."
                }},
                { "two_factor", new List<string> {
                    "Two-factor authentication adds an extra layer of security by requiring something you know (password) and something you have (like your phone).",
                    "2FA is like having a deadbolt in addition to your regular lock - even if someone gets your password, they still can't get in without the second factor.",
                    "Always enable two-factor authentication when available. It makes your accounts up to 99% less likely to be compromised."
                }},
                { "updates", new List<string> {
                    "Software updates aren't just about new features - they often include important security patches that protect you from known vulnerabilities.",
                    "Think of updates like vaccines for your devices - they protect against known threats and strengthen your overall security posture.",
                    "Set your devices to update automatically whenever possible. This ensures you're always protected against the latest known threats."
                }},
                { "social_engineering", new List<string> {
                    "Social engineering attacks exploit human psychology rather than technical vulnerabilities. Be cautious of unexpected requests or offers that seem too good to be true.",
                    "Remember that hackers often target people, not just systems. Be suspicious of unexpected communications, even if they appear to come from someone you know.",
                    "Social engineering is like psychological hacking - attackers manipulate you into revealing information or taking actions that compromise your security."
                }},
                { "backup", new List<string> {
                    "Regular backups are your safety net against ransomware and data loss. Follow the 3-2-1 rule: three copies, two different media types, one off-site.",
                    "Think of backups as time machines for your data - if something goes wrong, you can restore from a point before the problem occurred.",
                    "Automated backups are the most reliable since they don't depend on you remembering to do them. Set them up once and let them run in the background."
                }},
                { "malware", new List<string> {
                    "Malware includes viruses, ransomware, spyware, and other malicious software. Protect yourself with updated antivirus software and cautious browsing habits.",
                    "Malware can infect your devices in many ways - suspicious downloads, infected websites, or even physical media. Always scan files before opening them.",
                    "The best protection against malware is a combination of good software (antivirus) and good habits (not downloading from untrusted sources)."
                }}
            };
        }

        public override bool HandleInput(string input)
        {
            string lowerInput = input.ToLower();
            bool handled = true;

            // Handle security topics
            if (MatchesKeyword(lowerInput, new[] { "password", "passwords" }))
            {
                HandlePasswordQuestions(input);
                userMemory.SetLastTopic("password");
            }
            else if (MatchesKeyword(lowerInput, new[] { "phish", "phishing", "scam", "scams" }))
            {
                HandlePhishingQuestions(input);
                userMemory.SetLastTopic("phishing");
            }
            else if (MatchesKeyword(lowerInput, new[] { "browsing", "browser", "internet", "web", "website", "surf" }))
            {
                HandleBrowsingQuestions(input);
                userMemory.SetLastTopic("browsing");
            }
            else if (MatchesKeyword(lowerInput, new[] { "vpn", "virtual private network" }))
            {
                HandleVPNQuestion();
                userMemory.SetLastTopic("vpn");
            }
            else if (MatchesKeyword(lowerInput, new[] { "two factor", "2fa", "mfa", "multi factor", "authentication" }))
            {
                RespondWithTopic("two_factor");
                userMemory.SetLastTopic("two_factor");
            }
            else if (MatchesKeyword(lowerInput, new[] { "update", "updates", "patch", "patches", "software" }))
            {
                RespondWithTopic("updates");
                userMemory.SetLastTopic("updates");
            }
            else if (MatchesKeyword(lowerInput, new[] { "social engineering", "manipulation", "pretend", "pretending" }))
            {
                RespondWithTopic("social_engineering");
                userMemory.SetLastTopic("social_engineering");
            }
            else if (MatchesKeyword(lowerInput, new[] { "backup", "backups", "save", "copy", "data loss" }))
            {
                RespondWithTopic("backup");
                userMemory.SetLastTopic("backup");
            }
            else if (MatchesKeyword(lowerInput, new[] { "malware", "virus", "ransomware", "spyware", "trojan", "worm" }))
            {
                RespondWithTopic("malware");
                userMemory.SetLastTopic("malware");
            }
            else if (MatchesKeyword(lowerInput, new[] { "identify", "spot", "recognize", "detect" }))
            {
                // Context-aware response based on conversation history
                string relevantTopic = DetermineRelevantThreatTopic();
                if (relevantTopic == "phishing")
                {
                    RespondWithTopic("phishing_identification");
                }
                else
                {
                    HandlePhishingIdentification();
                }
                userMemory.SetLastTopic("identification");
            }
            else if (MatchesKeyword(lowerInput, new[] { "manager", "password manager" }))
            {
                HandlePasswordManagerQuestion();
                userMemory.SetLastTopic("password_manager");
            }
            else if (MatchesKeyword(lowerInput, new[] { "strong", "strength", "secure password" }))
            {
                HandlePasswordStrengthQuestion();
                userMemory.SetLastTopic("password_strength");
            }
            else if (MatchesKeyword(lowerInput, new[] { "privacy", "private", "data protection" }))
            {
                // Add interest in privacy
                userMemory.AddInterest("privacy");

                string[] responses = new string[]
                {
                    "Privacy is crucial in the digital age. Be careful what information you share online, and check privacy settings on all your accounts regularly.",
                    "Your digital privacy matters! Regularly review what data you're sharing, use privacy-focused browsers, and consider tools like VPNs for added protection.",
                    "Protecting your privacy means controlling your digital footprint. Limit what you share on social media and be careful about permissions you grant to apps."
                };

                string response = responses[random.Next(responses.Length)];
                AddPersonalizedTouch(ref response);
                Console.WriteLine($"Stitch: {response}");
                userMemory.SetLastTopic("privacy");
            }
            else
            {
                handled = false;
            }

            return handled;
        }

        private bool MatchesKeyword(string input, string[] keywords)
        {
            foreach (var keyword in keywords)
            {
                if (input.Contains(keyword))
                {
                    return true;
                }
            }
            return false;
        }

        private string DetermineRelevantThreatTopic()
        {
            // Look at recent conversation history to determine context
            var history = userMemory.GetConversationHistory();
            foreach (var message in history)
            {
                if (message.Contains("phish") || message.Contains("scam") || message.Contains("email"))
                {
                    return "phishing";
                }
                else if (message.Contains("malware") || message.Contains("virus"))
                {
                    return "malware";
                }
                else if (message.Contains("social engineering"))
                {
                    return "social_engineering";
                }
            }

            // Default to phishing if no context
            return "phishing";
        }

        private void HandlePasswordQuestions(string question)
        {
            question = question.ToLower();

            if (question.Contains("strong") || question.Contains("create"))
            {
                HandlePasswordStrengthQuestion();
            }
            else if (question.Contains("manager"))
            {
                HandlePasswordManagerQuestion();
            }
            else
            {
                RespondWithTopic("password_general");
            }
        }

        private void HandlePhishingQuestions(string question)
        {
            question = question.ToLower();

            if (question.Contains("identify") || question.Contains("spot") ||
                question.Contains("recognize") || question.Contains("detect"))
            {
                HandlePhishingIdentification();
            }
            else
            {
                RespondWithTopic("phishing_general");
            }
        }

        private void HandleBrowsingQuestions(string question)
        {
            question = question.ToLower();

            if (question.Contains("vpn"))
            {
                HandleVPNQuestion();
            }
            else
            {
                RespondWithTopic("browsing_general");
            }
        }

        private void HandleVPNQuestion()
        {
            RespondWithTopic("vpn");
        }

        private void HandlePhishingIdentification()
        {
            RespondWithTopic("phishing_identification");
        }

        private void HandlePasswordManagerQuestion()
        {
            RespondWithTopic("password_manager");
        }

        private void HandlePasswordStrengthQuestion()
        {
            RespondWithTopic("password_strength");
        }

        private void RespondWithTopic(string topicKey)
        {
            if (securityResponses.ContainsKey(topicKey))
            {
                var responses = securityResponses[topicKey];
                string response = responses[random.Next(responses.Count)];

                // Add personalized touch based on user memory
                AddPersonalizedTouch(ref response);

                Console.WriteLine($"Stitch: {response}");
            }
            else
            {
                Console.WriteLine("Stitch: I don't have specific information on that topic yet, but I'm learning!");
            }
        }
    }
}