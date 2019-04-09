using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MobileCodeChallenge.Model
{
    public class StarshipList
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("next")]
        public string Next { get; set; }
        [JsonProperty("previous")]
        public string Previous { get; set; }
        [JsonProperty("results")]
        public List<Starship> Results { get; set; }
    }
}
