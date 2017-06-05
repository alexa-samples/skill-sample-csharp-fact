using System.Collections.Generic;
using Newtonsoft.Json;

namespace AlexaAPI.Request
{
    public class Session
    {
        [JsonProperty("new")]
        public bool New {get; set;}

        [JsonProperty("user")]
        public User User {get; set;}

        [JsonProperty("sessionId")]
        public string SessionId {get; set;}

        [JsonProperty("attributes")]
        public Dictionary<string, object> Attributes {get; set;}

        [JsonProperty("application")]
        public Application Application {get; set;}

    }
}
