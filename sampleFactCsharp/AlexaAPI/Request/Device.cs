using System.Collections.Generic;
using Newtonsoft.Json;

namespace AlexaAPI.Request
{
    public class Device
    {
        [JsonProperty("supportedInterfaces")]
        public Dictionary<string, object> SupportedInterfaces {get; set;}

        [JsonProperty("deviceId")]
        public string DeviceID {get; set;}
    }
}
