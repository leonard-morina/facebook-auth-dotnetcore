using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FacebookAuth.Core.Models
{
    public class AuthTokenAccess
    {
        [Required]
        [JsonProperty("token_type")] 
        public string TokenType { get; set; }
        [Required]
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}