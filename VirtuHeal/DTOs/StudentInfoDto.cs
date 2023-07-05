using System.ComponentModel.DataAnnotations;

namespace VirtuHeal.DTOs
{
	public class StudentInfoDto
	{
        public int student_id { get; set; }

        public int my_pyschiatrist { get; set; }

        [Required]
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

        [Required]
        public string question3 { get; set; } = string.Empty;

        [Required]
        public string answer3 { get; set; } = string.Empty;

        [Required]
        public string question4 { get; set; } = string.Empty;

        [Required]
        public string answer4 { get; set; } = string.Empty;
    }
}

