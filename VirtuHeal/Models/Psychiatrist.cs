using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace VirtuHeal.Models
{
    public class Psychiatrist
    {
        [Key]
        public int psychiatrist_id { get; set; }

        [Required]
        [ForeignKey("User")]
        public int user_id { get; set; }

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
        public int college_id { get; set; }

        [Required]
        public bool is_verified { get; set; }

        [Required]
        public string resume_url { get; set; } = string.Empty;

        public virtual User User { get; set; }

    }
}
