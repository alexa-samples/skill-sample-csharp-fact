using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace AlexaAPI.Request
{
    public class SystemObject
    {
        [JsonProperty("user")]
        public User User {get; set;}

        [JsonProperty("device")]
        public Device Device {get; set;}

        [JsonProperty("apiEndpoint")]
        public string ApiEndpoint {get; set;}
    }
}
