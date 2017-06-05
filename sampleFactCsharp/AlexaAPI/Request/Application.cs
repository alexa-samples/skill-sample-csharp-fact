using System.Collections.Generic;
using Newtonsoft.Json;

namespace AlexaAPI.Request
{
    public class Application
    {
        [JsonProperty("applicationID")]
        public string ApplicationId {get; set;}
    }
}
