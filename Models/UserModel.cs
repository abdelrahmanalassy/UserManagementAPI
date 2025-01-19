using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Identity.Client;

namespace UserManagementAPI.Models
{
    public class UserModel
    {
        [JsonPropertyName("user_id")]
        public Guid UserId { get; set;} = Guid.NewGuid();

        [JsonPropertyName("first_name")]
        public string FirstName { get; set;} = string.Empty;

        [JsonPropertyName("last_name")]
        public string LastName { get; set;} = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set;} = string.Empty;

        [JsonPropertyName("dob")]
        public DateTime Dob { get; set;}

        [JsonPropertyName("country")]
        public string Country { get; set;} = string.Empty;
    }

    public class RandomUserApiResponse
    {
        public List<Result> Results { get; set;} = new();
    }

    public class Result
    {
        public Name Name { get; set;} = new();
        public string Email { get; set; } = string.Empty;
        public Dob Dob { get; set; } = new();
        public Location Location { get; set; } = new();
    }

    public class Name
    {
        public string First { get; set; } = string.Empty;
        public string Last { get; set; } = string.Empty;
    }

    public class Dob
    {
        public string Date { get; set; } = string.Empty;
    }

    public class Location
    {
        public string Country { get; set; } = string.Empty;
    }
}