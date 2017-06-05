using System.Collections.Generic;
using Newtonsoft.Json;

namespace AlexaAPI.Request
{
    public class User
    {
        [JsonProperty ("userId")]
        public string UserId {get; set;}

//    [JsonProperty("permissions")]
  //      public Permissions Permissions {get; set;}

        [JsonProperty("accessToken")]
        public string AccessToken {get; set;}
    }
}
