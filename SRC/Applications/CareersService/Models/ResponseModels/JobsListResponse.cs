using Newtonsoft.Json;
using System.Collections.Generic;

namespace CareersService.Models.ResponseModels
{
    public class ListJobsResponse
    {
        [JsonProperty("total")]
        public int Total { get; set; }
        [JsonProperty("data")]
        public List<JobResponse> JobDetails { get; set; }
    }
}