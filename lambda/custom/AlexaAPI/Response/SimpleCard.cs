using System.Collections.Generic;
using Newtonsoft.Json;

namespace AlexaAPI.Response
{
    public class SimpleCard : ICard
    {
        [JsonRequired]
        [JsonProperty("type")]
        public string Type {get { return "Simple"; }}

        [JsonProperty("title")]
        public string Title {get; set;}

        [JsonProperty("content")]
        public string Content {get; set;}
    }
}
