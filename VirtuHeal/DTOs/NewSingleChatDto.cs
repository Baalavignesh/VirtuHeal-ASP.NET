using System.ComponentModel.DataAnnotations.Schema;

namespace VirtuHeal.DTOs
{
    public class NewSingleChatDto
    {
        public int StudentId { get; set; }
        public int PsychiatristId { get; set; }
        public string SenderRole { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
