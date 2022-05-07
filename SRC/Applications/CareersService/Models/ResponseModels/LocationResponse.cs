using Newtonsoft.Json;

namespace CareersService.Models.ResponseModels
{
    public class LocationResponse
    {
        [JsonProperty("id")]
        public int LocationId { get; set; }
        [JsonProperty("title")]
        public string LocationName { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("zip")]
        public int zip { get; set; }
    }
}