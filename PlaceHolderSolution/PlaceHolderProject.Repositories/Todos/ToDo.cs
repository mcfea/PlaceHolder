using Newtonsoft.Json;

namespace PlaceHolderProject.Repositories.Todos
{
    /// <summary>
    /// "userId": 1,
    /// "id": 2,
    /// "title": "quis ut nam facilis et officia qui",
    /// "completed": false
    /// </summary>
    public class ToDo
    {
        [JsonProperty("id")] 
        public int Id { get; set; }

        [JsonProperty("userId")] 
        public int UserId { get; set; }
        
        [JsonProperty("title")] 
        public string Title { get; set; }
        
        [JsonProperty("completed")] 
        public bool Completed { get; set; }
    }
}