using System.ComponentModel.DataAnnotations;

namespace VirtuHeal.Models
{
    public class Psychiatrist
    {

        [Key]
        public int psychiatrist_id { get; set; }

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
        public int college_id { get; set; }
    }
}
