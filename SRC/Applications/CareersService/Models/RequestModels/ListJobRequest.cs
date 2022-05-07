using Newtonsoft.Json;

namespace CareersService.Models.RequestModels
{
    public class ListJobsRequest
    {
        [JsonProperty("q")]
        public string JobName { get; set; }
        [JsonProperty("pageNo")]
        public int PageNo { get; set; }
        [JsonProperty("pageSize")]
        public int PageSize { get; set; }
        [JsonProperty("locationId")]
        public int LocationId { get; set; }
        [JsonProperty("departmentId")]
        public int DepartmentId { get; set; }


    }
}