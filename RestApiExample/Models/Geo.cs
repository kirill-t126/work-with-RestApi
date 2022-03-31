using Newtonsoft.Json;

namespace RestApiExample.Models
{
    internal class Geo
    {
        [JsonProperty("lat")]
        public string Lat { get; set; }
        [JsonProperty("lng")]
        public string Lng { get; set; }
    }
}