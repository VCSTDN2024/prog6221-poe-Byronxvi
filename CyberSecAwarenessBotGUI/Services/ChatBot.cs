using System;
using System.Collections.Generic;
using System.Linq;

namespace CyberSecAwarenessBot.Services
{
    public class ChatBot
    {
        private readonly string userName;
        private string userInterest = string.Empty;
        private string userSentiment = string.Empty;
        private readonly Random random = new();

        private readonly Dictionary<string, List<string>> keywordResponses = new()
        {
            { "password", new List<string> {
                "Use a mix of letters, numbers, and symbols. Make sure it is unique and does not have any relations to your personal information and make sure to not share it with anyone.",
                "Use unique passwords for each account.",
                "Don't include your name or birthdate in passwords.",
                "Try a password manager to create secure passwords."
            }},
            { "phishing", new List<string> {
                "Phishing is an attack that is used to steal user personal data. So be cautious of emails or messages asking for personal information.",
                "Be cautious of emails asking for personal info. Scammers disguise themselves as trusted organisations.",
                "Watch out for fake login pages. Always double-check URLs before entering credentials."
            }},
            { "safe browsing", new List<string> {
                "Always check the URL and look for HTTPS before entering sensitive information.",
                "Avoid using public Wi-Fi for sensitive logins.",
                "Don't click popups that seem too good to be true."
            }}
        };

        private readonly Dictionary<string, string> sentimentResponses = new()
        {
            { "worried", "It's okay to feel worried. Cybersecurity can be overwhelming, but I'm here to help!" },
            { "curious", "Curiosity is great! Learning more about cybersecurity helps you stay safe." },
            { "frustrated", "I get it—some of these topics can be tricky. Let me try to simplify things." }
        };

        public ChatBot(string name)
        {
            userName = name;
        }

        public string ProcessInput(string input)
        {
            input = input.ToLower().Trim();
            if (string.IsNullOrWhiteSpace(input))
                return "Invalid input. Please try again, as I don't understand.";

            if (input == "exit")
                return "Goodbye! Stay safe online!";

            string sentiment = CheckSentiment(input);
            if (!string.IsNullOrEmpty(sentiment))
                return sentiment;

            string memory = HandleMemory(input);
            if (!string.IsNullOrEmpty(memory))
                return memory;

            string keyword = HandleKeyword(input);
            if (!string.IsNullOrEmpty(keyword))
                return keyword;

            string general = HandleGeneral(input);
            if (!string.IsNullOrEmpty(general))
                return general;

            string nlp = HandleNlpCommand(input);
            if (!string.IsNullOrEmpty(nlp))
                return nlp;

            return "I'm not sure how to respond to that. Please try and ask a question about cybersecurity specifics.";
        }

        private string CheckSentiment(string input)
        {
            foreach (var sentiment in sentimentResponses)
            {
                if (input.Contains(sentiment.Key))
                    return sentiment.Value;
            }
            return string.Empty;
        }

        private string HandleMemory(string input)
        {
            if (input.Contains("interested in"))
            {
                int startIndex = input.IndexOf("interested in") + "interested in".Length;
                userInterest = input[startIndex..].Trim();
                return $"Got it! I'll remember you're interested in {userInterest}.";
            }
            else if (!string.IsNullOrEmpty(userInterest) &&
                     (input.Contains("remind me") || input.Contains("what did i say")))
            {
                return $"You mentioned you're interested in {userInterest}. Want to know more?";
            }
            return string.Empty;
        }

        private string HandleKeyword(string input)
        {
            foreach (var keyword in keywordResponses.Keys)
            {
                if (input.Contains(keyword))
                {
                    var responses = keywordResponses[keyword];
                    string randomTip = responses[random.Next(responses.Count)];

                    if (!string.IsNullOrEmpty(userInterest) && input.Contains(userInterest))
                        return $"Since you're interested in {userInterest}, here's a tip: {randomTip}";
                    else
                        return randomTip;
                }
            }
            return string.Empty;
        }

        private string HandleGeneral(string input)
        {
            if (input.Contains("how are you"))
                return "I'm good thank you and always on the alert.";

            if (input.Contains("purpose"))
                return "I'm here to guide you. On how to be safe online.";

            if (input.Contains("ask"))
                return "You can ask me about password safety, safe browsing or about phishing.";

            return string.Empty;
        }

        //  NLP Simulation
        private string HandleNlpCommand(string input)
        {
            if (input.Contains("remind me to"))
            {
                return "Got it! You want a reminder. You can add it using the task assistant panel.";
            }

            if (input.Contains("add a task for") || input.Contains("i need to"))
            {
                return "Sounds like you want to add a task. Please use the task assistant section.";
            }

            if (input.Contains("i want to take the quiz") || input.Contains("start quiz"))
            {
                return "You can start the quiz by clicking the 'Start Quiz' button below.";
            }

            if (input.Contains("can you help me with"))
            {
                var parts = input.Split("with");
                if (parts.Length > 1)
                {
                    string topic = parts[1].Trim();
                    return $"Sure! I can help you with {topic}. Ask me something specific about it!";
                }
                else
                {
                    return "Sure! What topic would you like help with?";
                }
            }

            return string.Empty;
        }
    }
}

