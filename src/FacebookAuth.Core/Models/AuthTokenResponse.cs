using Newtonsoft.Json;

namespace FacebookAuth.Core.Models
{
    public class AuthTokenResponse
    {
        [JsonProperty("app_id")]
        public long AppId { get; set; }
        public string Type { get; set; }
        public string Application { get; set; }
        [JsonProperty("expires_at")] 
        public long ExpiresAt { get; set; }
        [JsonProperty("user_id")]
        public long UserId { get; set; }
    }
}