using Newtonsoft.Json;

namespace PlaceHolderProject.Repositories.Albums
{
    /// <summary>
    ///     "userId": 1,
    ///     "id": 2,
    ///     "title": "sunt qui excepturi placeat culpa"
    /// </summary>
    public class Album
    {
        [JsonProperty("id")] 
        public int Id { get; set; }

        [JsonProperty("userId")] 
        public int UserId { get; set; }
        
        [JsonProperty("title")] 
        public string Title { get; set; }
    }
}