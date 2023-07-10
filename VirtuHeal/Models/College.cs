using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VirtuHeal.Models
{
	public class College
	{
		[Key]
		public int college_id { get; set; }

		[Required]
		public string college_name { get; set; } = string.Empty;

		[Required]
		public bool is_partner { get; set; } = false;

		//public virtual Student Student { get; set; }
		//public virtual Psychiatrist Psychiatrist { get; set; }

    }
}

