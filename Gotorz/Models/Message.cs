namespace Gotorz.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string SenderEmail { get; set; } // Employee
        public string RecipientEmail { get; set; } // User
        public string Content { get; set; }
        public DateTime TimeSent { get; set; } = DateTime.UtcNow;
    }
}
