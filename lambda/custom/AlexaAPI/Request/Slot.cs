using System.Collections.Generic;
using Newtonsoft.Json;

namespace AlexaAPI.Request
{
    public class Slot
    {
        [JsonProperty("name")]
        public string Name {get; set;}

        [JsonProperty("value")]
        public string Value {get; set;}
    }
}
