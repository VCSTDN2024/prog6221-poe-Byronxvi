using System;
using System.Collections.Generic;
using CyberSecAwarenessBot.Models;

namespace CyberSecAwarenessBot.Services
{
    public static class TaskManager
    {
        private static readonly List<CyberTask> tasks = new();

        public static void AddTask(CyberTask task)
        {
            tasks.Add(task);
        }

        public static List<CyberTask> GetTasks()
        {
            return new List<CyberTask>(tasks);
        }

        public static void DeleteTask(CyberTask task)
        {
            tasks.Remove(task);
        }

        public static void MarkAsCompleted(CyberTask task)
        {
            task.IsCompleted = true;
        }
    }
}
