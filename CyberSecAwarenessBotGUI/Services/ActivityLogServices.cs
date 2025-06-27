using System;
using System.Collections.Generic;

namespace CyberSecAwarenessBot.Services
{
    public static class ActivityLogService
    {
        private static readonly Queue<string> activityLog = new();
        private const int MaxEntries = 10;

        public static void Log(string message)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            if (activityLog.Count >= MaxEntries)
                activityLog.Dequeue();

            activityLog.Enqueue($"{timestamp} - {message}");
        }

        public static List<string> GetLog()
        {
            return new List<string>(activityLog);
        }

        public static void Clear()
        {
            activityLog.Clear();
        }
    }
}
