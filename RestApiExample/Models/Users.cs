using Newtonsoft.Json;

namespace RestApiExample.Models
{
    internal class Users
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("address")]
        public Address Address { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("website")]
        public string Website { get; set; }
        [JsonProperty("company")]
        public Company Company { get; set; }

        public override bool Equals(object obj)
        {
            var user = obj as Users;
            return this.Id == user.Id &&
                this.Name == user.Name &&
                this.Username == user.Username &&
                this.Email == user.Email &&
                this.Address.City == user.Address.City &&
                this.Address.Geo.Lat == user.Address.Geo.Lat &&
                this.Address.Geo.Lng == user.Address.Geo.Lng &&
                this.Address.Street == user.Address.Street &&
                this.Address.Suite == user.Address.Suite &&
                this.Address.Zipcode == user.Address.Zipcode &&
                this.Phone == user.Phone &&
                this.Website == user.Website &&
                this.Company.Bs == user.Company.Bs &&
                this.Company.CatchPhrase == user.Company.CatchPhrase &&
                this.Company.Name == user.Company.Name;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}