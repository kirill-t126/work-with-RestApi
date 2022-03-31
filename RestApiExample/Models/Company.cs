using Newtonsoft.Json;

namespace RestApiExample.Models
{
    internal class Company
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("catchPhrase")]
        public string CatchPhrase { get; set; }
        [JsonProperty("bs")]
        public string Bs { get; set; }
    }
}