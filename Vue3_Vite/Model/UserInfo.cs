using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Vue3_Vite.Model
{
    public class UserInfo
    {
        [Required]
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}