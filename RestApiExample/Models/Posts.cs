using Newtonsoft.Json;

namespace RestApiExample.Models
{
    internal class Posts
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("userId")]
        public int UserID { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}