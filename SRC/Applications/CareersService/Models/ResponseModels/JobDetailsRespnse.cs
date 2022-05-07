using Newtonsoft.Json;

namespace CareersService.Models.ResponseModels
{
    public class JobDetailsRespnse
    {
        [JsonProperty("id")]
        public int JobId { get; set; }
        [JsonProperty("code")]
        public string JobCode { get; set; }
        [JsonProperty("title")]
        public string JobName { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("location")]
        public LocationResponse Location { get; set; }
        [JsonProperty("department")]
        public DepartmentResponse Department { get; set; }
        [JsonProperty("postedDate")]
        public string PostedDate { get; set; }
        [JsonProperty("closingDate")]
        public string ClosingDate { get; set; }
    }
}