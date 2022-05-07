using Newtonsoft.Json;

namespace CareersService.Models.RequestModels
{

    public class JobRequest
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("locationId")]
        public int LocationId { get; set; }
        [JsonProperty("departmentId")]
        public int DepartmentId { get; set; }
        [JsonProperty("closingDate")]
        public string ClosingDate { get; set; }
    }

}