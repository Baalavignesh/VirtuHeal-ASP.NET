using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtuHeal.Models
{
    public class SingleChatMessage
    {
        [Key]
        public int MessageId { get; set; }

        [ForeignKey("MyChats")]
        public int ParentChatId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int PsychiatristId { get; set; }

        [Required]
        public string Message { get; set; } = string.Empty;

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        public bool IsRead { get; set; }

        public virtual MyChats MyChats { get; set; }

    }
}
