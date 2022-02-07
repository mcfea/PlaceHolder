using Newtonsoft.Json;

namespace PlaceHolderProject.Repositories.Comments
{
    /// <summary> 
    /// "postId": 1,
    /// "id": 1,
    /// "name": "id labore ex et quam laborum",
    /// "email": "Eliseo@gardner.biz",
    /// "body": "laudantium enim quasi est quidem magnam voluptate ipsam eos\ntempora quo necessitatibus\ndolor quam autem quasi\nreiciendis et nam sapiente accusantium"
    /// }
    /// </summary>
    public class Comment
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("postId")]
        public int PostId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}