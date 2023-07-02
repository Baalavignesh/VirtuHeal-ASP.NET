using System.ComponentModel.DataAnnotations;

namespace VirtuHeal.DTOs
{
	public class PsychiatristInfoDto
	{

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

            [Required]
            public string question1 { get; set; } = string.Empty;

            [Required]
            public string answer1 { get; set; } = string.Empty;

            [Required]
            public string question2 { get; set; } = string.Empty;

            [Required]
            public string answer2 { get; set; } = string.Empty;

        }
	
}

