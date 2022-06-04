using System.Text.Json.Serialization;
namespace WikiPosition.Data.Model
{
    public class WikipediaPagePosition
    {
        [JsonPropertyName("pageid")]
        public int PageId { get; set; }

        [JsonPropertyName("ns")]
        public int Ns { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        [JsonPropertyName("dist")]
        public float Distance { get; set; }
        
        [JsonPropertyName("primary")]
        public string Primary { get; set; }
    
    }    
}