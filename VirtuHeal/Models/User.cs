using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VirtuHeal.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int user_id { get; set; }

        [Required]
        public string username { get; set; } = string.Empty;

        [Required]
        [JsonIgnore]
        public byte[] password_hash { get; set; }

        [Required]
        [JsonIgnore]
        public byte[] password_salt { get; set; }

        [Required]
        public bool is_online { get; set; }

        [Required]
        public string role { get; set; }
    }
}
