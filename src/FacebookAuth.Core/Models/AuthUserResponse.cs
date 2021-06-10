using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FacebookAuth.Core.Models
{
    public class AuthUserResponse
    {
        public string Id { get; set; }
        [JsonProperty("age_range")]
        public string AgeRange { get; set; }

        public string Birthday { get; set; }
        public string Email { get; set; }
        [JsonProperty("favorite_athletes")]
        public List<Experience> FavoriteAthletes { get; set; }
        [JsonProperty("favorite_teams")]
        public List<Experience> FavoriteTeams { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        //returns either `male` or `female`
        public string Gender { get; set; }
        [JsonProperty("inspirational_people")]
        public List<Experience> InspirationalPeople { get; set; }
        public List<Experience> Languages { get; set; }
        public string Link { get; set; }
        [JsonProperty("meeting_for")]
        public List<string> MeetingFor { get; set; }
        [JsonProperty("name")]
        public string FullName { get; set; }
        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        [JsonProperty("profile_pic")]
        public string ProfilePicture { get; set; }

        public string Quotes { get; set; }
        public List<Experience> Sports { get; set; }
    }
}