using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtuHeal.Models
{
    public class Student
    {
        [Key]
        public int student_id { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public string name { get; set; } = string.Empty;

        [Required]
        public int age { get; set; }

        [Required]
        public string qualification { get; set; } = string.Empty;

        [Required]
        public string gender { get; set; } = string.Empty;

        [Required]
        public string number { get; set; } = string.Empty;

        [Required]
        //[ForeignKey("College")]
        public int college_id { get; set;  }

        public int my_psychiatrist { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<MyChats> MyChats { get; set; }
        //public virtual ICollection<College> College { get; set; }
    }
}
