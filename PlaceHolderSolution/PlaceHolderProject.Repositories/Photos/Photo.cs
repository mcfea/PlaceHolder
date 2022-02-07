using Newtonsoft.Json;

namespace PlaceHolderProject.Repositories.Photos
{
    /// <summary>
    /// "albumId": 1,
    /// "id": 1,
    /// "title": "accusamus beatae ad facilis cum similique qui sunt",
    /// "url": "https://via.placeholder.com/600/92c952",
    /// "thumbnailUrl": "https://via.placeholder.com/150/92c952"
    /// </summary>
    public class Photo
    {
        [JsonProperty("id")] 
        public int Id { get; set; }

        [JsonProperty("albumId")] 
        public int AlbumId { get; set; }
        
        [JsonProperty("title")] 
        public string Title { get; set; }
        
        [JsonProperty("url")] 
        public string Url { get; set; }
        
        [JsonProperty("thumbnailUrl")] 
        public string ThumbnailUrl { get; set; }
    }
}