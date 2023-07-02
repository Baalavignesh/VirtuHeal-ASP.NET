using System;
using System.ComponentModel.DataAnnotations;

namespace VirtuHeal.Models
{
	public class StudentQuestions
	{
		[Key]
		public int id { get; set; }

        [Required]
        public int student_id { get; set; }

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

