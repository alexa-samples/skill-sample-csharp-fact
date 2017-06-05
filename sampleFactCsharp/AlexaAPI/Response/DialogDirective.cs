using System;
using Newtonsoft.Json;

namespace AlexaAPI.Response
{
    public class DialogDirective : IDirective
    {
        [JsonProperty("type")]
        public string Type {get; set;}
    }
}
