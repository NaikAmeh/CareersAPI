using Newtonsoft.Json;

namespace CareersService.Models.ResponseModels
{
    public class JobResponse
    {
        [JsonProperty("id")]
        public int JobId { get; set; }
        [JsonProperty("code")]
        public string JobCode { get; set; }
        [JsonProperty("title")]
        public string JobName { get; set; }
        [JsonProperty("location")]
        public string JobLocation { get; set; }
        [JsonProperty("department")]
        public string JobDepartment { get; set; }
        [JsonProperty("postedDate")]
        public string PostedDate { get; set; }
        [JsonProperty("closingDate")]
        public string ClosingDate { get; set; }
    }
}