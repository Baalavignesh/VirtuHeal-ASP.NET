using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtuHeal.Models
{
	public class PsychiatristpQuestions
    {

        [Key]
		public int id { get; set; }

        [ForeignKey("Psychiatrist")]
        public int psychiatrist_id { get; set; }

        [Required]
        public string question1 { get; set; } = string.Empty;
        [Required]
        public string answer1 { get; set; } = string.Empty;
        [Required]
        public string question2 { get; set; } = string.Empty;
        [Required]
        public string answer2 { get; set; } = string.Empty;

        public virtual Psychiatrist Psychiatrist { get; set; }
		
	}
}

