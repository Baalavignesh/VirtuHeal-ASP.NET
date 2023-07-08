using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VirtuHeal.DTOs
{
	public class UserDto
	{
        [Required]
        public int UserId { get; set; }

        [Required]
        public int MyId { get; set; }

        [Required]
        [JsonIgnore]
        public byte[] password_hash { get; set; }

        [Required]
        [JsonIgnore]
        public byte[] password_salt { get; set; }


        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty;
    }
}

