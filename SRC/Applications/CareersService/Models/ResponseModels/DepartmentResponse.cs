using Newtonsoft.Json;

namespace CareersService.Models.ResponseModels
{
    public class DepartmentResponse
    {
        [JsonProperty("id")]
        public int DepartmentId { get; set; }
        [JsonProperty("title")]
        public string DepartmentName { get; set; }
    }
}