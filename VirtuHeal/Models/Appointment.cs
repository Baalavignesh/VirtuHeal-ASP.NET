using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtuHeal.Models
{
	public class Appointment
	{
		[Required]
		[Key]
		public int AppointmentId { get; set; }

		[Required]
		public int StudentId { get; set; }

		[Required]
		public int PsychiatristId { get;set; }

		[Required]
		public string InitiatedBy { get; set; } = string.Empty;

		[Required]
		public string Status { get; set; } = string.Empty;

		[Required]
		public DateTime Time { get; set; }

	}
}

