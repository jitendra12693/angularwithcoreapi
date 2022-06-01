using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace learninganularapi.Models
{
    public class UserMaster
    {   [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("contactNo")]
        public string ContactNo { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("profilePic")]
        public string ProfilePic { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }
}
