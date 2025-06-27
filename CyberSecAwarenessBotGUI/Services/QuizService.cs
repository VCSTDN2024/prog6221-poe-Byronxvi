using System.Collections.Generic;
using CyberSecAwarenessBot.Models;
using CyberSecAwarenessBotGUI.Models;

namespace CyberSecAwarenessBot.Services
{
    public class QuizService
    {
        private readonly List<QuizQuestion> questions;
        private int currentQuestionIndex = 0;
        public int Score { get; private set; } = 0;

        public QuizService()
        {
            questions = new List<QuizQuestion>
            {
                new QuizQuestion {
                    QuestionText = "What should you do if you receive an email asking for your password?",
                    Options = new[] { "A) Reply with your password", "B) Delete the email", "C) Report the email as phishing", "D) Ignore it" },
                    CorrectOptionIndex = 2,
                    Explanation = "Correct! Reporting phishing emails helps prevent scams."
                },
                new QuizQuestion {
                    QuestionText = "True or False: You should reuse your passwords across sites.",
                    Options = new[] { "True", "False" },
                    CorrectOptionIndex = 1,
                    Explanation = "False! Always use unique passwords for each account."
                },
                
                new QuizQuestion {
                    QuestionText = "Which of these is a strong password?",
                    Options = new[] { "123456", "password", "Byron@2025!", "qwerty" },
                    CorrectOptionIndex = 2,
                    Explanation = "Strong passwords use letters, numbers, and symbols."
                },
                new QuizQuestion {
                    QuestionText = "What is two-factor authentication?",
                    Options = new[] { "A security software", "A second password", "An extra verification step", "A firewall" },
                    CorrectOptionIndex = 2,
                    Explanation = "It's an extra step beyond the password to verify your identity."
                },
                new QuizQuestion {
                    QuestionText = "True or False: HTTPS is more secure than HTTP.",
                    Options = new[] { "True", "False" },
                    CorrectOptionIndex = 0,
                    Explanation = "True! HTTPS encrypts your data for safety."
                },
                new QuizQuestion {
                    QuestionText = "Phishing attacks usually try to:",
                    Options = new[] { "Steal your personal info", "Fix your device", "Speed up your PC", "Clean your cache" },
                    CorrectOptionIndex = 0,
                    Explanation = "They trick users into giving personal or login info."
                },
                new QuizQuestion {
                    QuestionText = "Which of the following is NOT a cyber threat?",
                    Options = new[] { "Malware", "Ransomware", "Phishing", "Backpacking" },
                    CorrectOptionIndex = 3,
                    Explanation = "Backpacking is not a cyber threat!"
                },
                new QuizQuestion {
                    QuestionText = "True or False: Public Wi-Fi is always safe for online banking.",
                    Options = new[] { "True", "False" },
                    CorrectOptionIndex = 1,
                    Explanation = "False. Public Wi-Fi is risky without protection."
                },
                new QuizQuestion {
                    QuestionText = "What is a firewall?",
                    Options = new[] { "A password tool", "A virus", "A security system", "An app" },
                    CorrectOptionIndex = 2,
                    Explanation = "A firewall blocks unauthorized access to your network."
                },
                new QuizQuestion {
                    QuestionText = "What is social engineering?",
                    Options = new[] { "Programming", "Tricking people to give info", "AI behavior", "Building secure apps" },
                    CorrectOptionIndex = 1,
                    Explanation = "It's manipulating people into giving sensitive data."
                }
            };
        }

        public bool HasNextQuestion()
        {
            return currentQuestionIndex < questions.Count;
        }

        public QuizQuestion GetNextQuestion()
        {
            return questions[currentQuestionIndex++];
        }

        public void SubmitAnswer(int selectedIndex)
        {
            var question = questions[currentQuestionIndex - 1];
            if (selectedIndex == question.CorrectOptionIndex)
                Score++;
        }

        public void Reset()
        {
            currentQuestionIndex = 0;
            Score = 0;
        }
    }
}
