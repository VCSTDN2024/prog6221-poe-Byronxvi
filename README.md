#  Cybersecurity Awareness Chatbot – Part 3 (GUI)

> PROG6221 POE – Part 3  


---

## Overview  

The completed Cybersecurity Awareness project is this WPF-based chatbot.
 It has a comprehensive graphical user interface that includes:

-  Interactive Chatbot (with NLP + memory)
-  Task Assistant with Reminders
-  Cybersecurity Quiz
- Activity Log
-  GUI Styling using XAML and WPF Controls

---

##  GUI Features Implemented

### ✅ 1. Chatbot with NLP & Memory
- Responds to cybersecurity queries (e.g., passwords, phishing)
- Detects user sentiment (worried, frustrated, curious)
- Remembers your interest (e.g., privacy)
- Understands flexible phrasing like:
  - “Remind me to update my password”
  - “I want to take the quiz”
  - “Add a task to enable 2FA”

---

### ✅ 2. Task Assistant
- Add tasks with title, description, and optional reminder
- View tasks, mark completed, delete tasks
- Tasks are stored in a collection (`CyberTask.cs`)
- Integrated into chatbot flow with conversational prompts

---

### ✅ 3. Quiz System
- 10-question cybersecurity quiz (MCQ and T/F)
- Live feedback after each question
- Final score and result message
- Resettable and fully GUI-driven

---

### ✅ 4. Activity Log
- Logs each user interaction:
  - Tasks added/deleted/completed
  - Quiz activity
  - General chatbot messages
- View up to 10 recent actions
- Handled by `ActivityLogService.cs`

---

### ✅ 5. WPF GUI Design
- Built using **XAML** and **C# code-behind**
- Contains:
  - `TextBlock`, `ScrollViewer`, `Expander`, `ListBox`, `DatePicker`, `Button`
- Organized layout with task sections and collapsible controls

---

##  Setup Instructions
- Open Visual Studios
- Create New project
- Type WPF Application (C#)
- Click Next 
- Start coding 

###  Prerequisites

- Visual Studio 2022+
- .NET 8.0 SDK
- Windows OS

---

###  Clone This Project

**Option 1: Git**
```bash
git clone https://github.com/Byronxvi/cybersecurity-chatbot-part3.git

** option 2: Zip download **

- Go to the GitHub repo
- Click Code > Download ZIP
- Extract the files


##  Run the Application**
1. Open CyberSecAwarenessBot.sln in Visual Studio
2. In Solution Explorer, right-click CyberSecAwarenessBotGUI → Set as Startup Project
3. Press Ctrl + F5 to run

## GitHub CI/CD
✅ Repository includes .github/workflows/dotnet.yml

✅ On every push, the workflow:

- Restores NuGet packages
- Builds the solution using dotnet build

✅ Latest status shown in Actions tab






