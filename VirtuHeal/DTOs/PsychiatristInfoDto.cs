using System.ComponentModel.DataAnnotations;

namespace VirtuHeal.DTOs
{
    public class PsychiatristInfoDto
    {

        public int pyschiatrist_id { get; set; }

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
        public string number { get; set; } = string.Empty;

        [Required]
        public int college_id { get; set; }

        [Required]
        public string resume_url { get; set; } = string.Empty;

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

