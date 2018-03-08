using System.Collections.Generic;
using Newtonsoft.Json;

namespace AlexaAPI.Request
{
    public class Context
    {
        [JsonProperty("System")]
        public SystemObject System {get; set;}

//   [JsonProperty("AudioPlayer")]
//   public AudioPlayer AudioPlayer {get; set;}
    }
}
