using Newtonsoft.Json;

namespace PlaceHolderProject.Repositories.Users
{
    /// <summary>
    /// "id": 1,
    /// "name": "Leanne Graham",
    /// "username": "Bret",
    /// "email": "Sincere@april.biz",
    /// "address": {
    /// "street": "Kulas Light",
    /// "suite": "Apt. 556",
    /// "city": "Gwenborough",
    /// "zipcode": "92998-3874",
    /// "geo": {
    ///     "lat": "-37.3159",
    ///     "lng": "81.1496"
    /// }
    /// </summary>
    public class User
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
    }
}