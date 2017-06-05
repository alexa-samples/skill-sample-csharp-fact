using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AlexaAPI.Request
{
    public class Request
    {
        [JsonProperty("type")]
        public string Type {get; set;}

        [JsonProperty("requestId")]
        public string RequestId {get; set;}

        [JsonProperty("timestamp")]
        public DateTime Timestamp {get; set;}

        [JsonProperty("locale")]
        public string Locale {get; set;}

        [JsonProperty("intent")]
        public Intent Intent {get; set;}

        [JsonProperty("updatedintent")]
        public Intent UpdatedIntent { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("dialogState")]
        public string DialogState { get; set; }
    }
}
