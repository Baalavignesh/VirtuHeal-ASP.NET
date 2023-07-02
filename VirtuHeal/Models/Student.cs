using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VirtuHeal.Models
{
    public class Student
    {
        [Key]
        public int student_id { get; set; }

        [Required]
        public int user_id { get; set; }

        [Required]
        public string name { get; set; } = string.Empty;

        [Required]
        public string qualification { get; set; } = string.Empty;

        [Required]
        public string location { get; set; } = string.Empty;

        [Required]
        public int number { get; set; }

        [Required]
        public int college_id { get; set;  }

        public int my_psychiatrist { get; set; }
    }
}
