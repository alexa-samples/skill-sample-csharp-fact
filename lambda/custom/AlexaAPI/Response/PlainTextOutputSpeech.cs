using System.Collections.Generic;
using Newtonsoft.Json;

namespace AlexaAPI.Response
{
    public class PlainTextOutputSpeech:  IOutputSpeech
    {
        [JsonProperty("type")]
        [JsonRequired]
        public string Type {get {return "PlainText";}}

        [JsonRequired]
        [JsonProperty("text")]
        public string Text {get; set;}
    }
}
