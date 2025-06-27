namespace CyberSecAwarenessBot.Models
{
    public class CyberTask
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReminderDate { get; set; }
        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            string status = IsCompleted ? "✅" : "🕗";
            string reminder = ReminderDate.HasValue ? $" (Remind: {ReminderDate.Value.ToShortDateString()})" : "";
            return $"{status} {Title} - {Description}{reminder}";
        }
    }
}
