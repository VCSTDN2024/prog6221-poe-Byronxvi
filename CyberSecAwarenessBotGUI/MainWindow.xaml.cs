using System;
using System.Windows;
using CyberSecAwarenessBot.Models;
using CyberSecAwarenessBot.Services;
using CyberSecAwarenessBotGUI.Models;

namespace CyberSecAwarenessBotGUI
{
    public partial class MainWindow : Window
    {
        private ChatBot bot;
        private QuizService quiz = new QuizService();
        private QuizQuestion currentQuizQuestion;

        public MainWindow()
        {
            InitializeComponent();
            bot = new ChatBot("User");
            AddBotMessage("Hello! I'm your cybersecurity assistant. How can I help you today?");
        }

        //  CHATBOT INPUT
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userInput = UserInputBox.Text.Trim();

            if (!string.IsNullOrEmpty(userInput))
            {
                AddUserMessage(userInput);
                string botResponse = bot.ProcessInput(userInput);
                AddBotMessage(botResponse);
                UserInputBox.Clear();

                ActivityLogService.Log($"User asked: {userInput}");
            }
        }

        private void AddUserMessage(string message)
        {
            ChatDisplay.Text += $"\n👤 You: {message}";
        }

        private void AddBotMessage(string message)
        {
            ChatDisplay.Text += $"\n🤖 Bot: {message}";
        }

        //  ADD TASK
        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string title = TaskTitleBox.Text.Trim();
            string description = TaskDescriptionBox.Text.Trim();
            DateTime? reminder = TaskReminderDate.SelectedDate;

            if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(description))
            {
                var task = new CyberTask
                {
                    Title = title,
                    Description = description,
                    ReminderDate = reminder,
                    IsCompleted = false
                };

                TaskManager.AddTask(task);
                AddBotMessage($"Task added: {task.Title}. Would you like a reminder?");
                ActivityLogService.Log($"Task added: {task.Title}");

                TaskTitleBox.Clear();
                TaskDescriptionBox.Clear();
                TaskReminderDate.SelectedDate = null;
            }
            else
            {
                AddBotMessage("Please enter both a task title and description.");
            }
        }

        //  VIEW TASKS
        private void ViewTasks_Click(object sender, RoutedEventArgs e)
        {
            TaskListBox.Items.Clear();
            var tasks = TaskManager.GetTasks();

            if (tasks.Count == 0)
            {
                TaskListBox.Items.Add("No tasks added yet.");
                return;
            }

            foreach (var task in tasks)
            {
                TaskListBox.Items.Add(task);
            }

            ActivityLogService.Log("Viewed task list");
        }

        //  DELETE SELECTED TASK
        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListBox.SelectedItem is CyberTask task)
            {
                TaskManager.DeleteTask(task);
                ViewTasks_Click(sender, e);
                AddBotMessage($"Deleted task: {task.Title}");
                ActivityLogService.Log($"Task deleted: {task.Title}");
            }
            else
            {
                AddBotMessage("Please select a task to delete.");
            }
        }

        //  MARK TASK AS COMPLETED
        private void CompleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListBox.SelectedItem is CyberTask task)
            {
                TaskManager.MarkAsCompleted(task);
                ViewTasks_Click(sender, e);
                AddBotMessage($"Marked '{task.Title}' as completed.");
                ActivityLogService.Log($"Task completed: {task.Title}");
            }
            else
            {
                AddBotMessage("Please select a task to mark as completed.");
            }
        }

        // START QUIZ
        private void StartQuiz_Click(object sender, RoutedEventArgs e)
        {
            quiz.Reset();
            QuizScoreText.Text = "";
            QuizFeedbackText.Text = "";
            ActivityLogService.Log("Started cybersecurity quiz");
            ShowNextQuizQuestion();
        }

        private void ShowNextQuizQuestion()
        {
            if (quiz.HasNextQuestion())
            {
                currentQuizQuestion = quiz.GetNextQuestion();
                QuizQuestionText.Text = currentQuizQuestion.QuestionText;
                QuizOptionsBox.Items.Clear();

                foreach (var option in currentQuizQuestion.Options)
                    QuizOptionsBox.Items.Add(option);
            }
            else
            {
                QuizQuestionText.Text = "Quiz complete!";
                QuizOptionsBox.Items.Clear();
                QuizFeedbackText.Text = "";
                QuizScoreText.Text = $"Final Score: {quiz.Score} / 10";
                AddBotMessage($"🎉 You completed the quiz! Score: {quiz.Score}/10.");
                ActivityLogService.Log($"Quiz completed with score: {quiz.Score}/10");
            }
        }

        //  SUBMIT QUIZ ANSWER
        private void SubmitQuizAnswer_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = QuizOptionsBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                QuizFeedbackText.Text = "Please select an answer.";
                return;
            }

            quiz.SubmitAnswer(selectedIndex);
            QuizFeedbackText.Text = currentQuizQuestion.Explanation;
            ActivityLogService.Log($"Answered quiz question: {currentQuizQuestion.QuestionText}");
            ShowNextQuizQuestion();
        }

        // SHOW ACTIVITY LOG
        private void ShowLog_Click(object sender, RoutedEventArgs e)
        {
            ActivityLogBox.Items.Clear();
            var logs = ActivityLogService.GetLog();

            if (logs.Count == 0)
            {
                ActivityLogBox.Items.Add("No activity logged yet.");
                return;
            }

            foreach (var entry in logs)
            {
                ActivityLogBox.Items.Add(entry);
            }
        }
    }
}

