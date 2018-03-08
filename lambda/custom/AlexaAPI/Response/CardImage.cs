using System.Collections.Generic;
using Newtonsoft.Json;

namespace AlexaAPI.Response
{
    public class CardImage
    {
        [JsonProperty("smallImageUrl")]
        public string SmallImageUrl {get; set;}

        [JsonProperty("largeImageUrl")]
        public string LargeImageUrl {get; set;}
    }
}
