
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtuHeal.Models
{
    public class MyChats
    {
        [Key]
        public int MyChatId { get; set; }

        [ForeignKey("Student")]
        public int? StudentId { get; set; }

        [ForeignKey("Psychiatrist")]
        public int? PsychiatristId { get; set; }


        public virtual Student Student { get; set; }
        public virtual Psychiatrist Psychiatrist { get; set; }
        public virtual ICollection<SingleChatMessage> SingleChatMessages { get; set; }
    }
}
