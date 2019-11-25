using Newtonsoft.Json;

namespace W12_FirebaseWinForms
{
    class Video
    {
        [JsonProperty("id")] public int id { get; set; }
        [JsonProperty("uploader")] public string uploader { get; set; }
        [JsonProperty("title")] public string title { get; set; }
        [JsonProperty("description")] public string description { get; set; }
        [JsonProperty("tags")] public string tags { get; set; }
        [JsonProperty("url")] public string url { get; set; }
        [JsonProperty("timestamp")] public int timestamp { get; set; }
    }
}