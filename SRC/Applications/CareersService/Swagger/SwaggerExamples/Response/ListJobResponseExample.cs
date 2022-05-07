using CareersService.Models.ResponseModels;
using Swashbuckle.Examples;
using System.Collections.Generic;

namespace CareersService.Swagger.SwaggerExamples.Response
{
    public class ListJobResponseExample: IExamplesProvider
    {
        public object GetExamples()
        {
            return new ListJobsResponse
            {
                Total=2,
                JobDetails=new List<JobResponse>()
                {
                    new JobResponse()
                    {
                        JobId=1,
                        JobCode="JOB-01",
                        JobName="Manager",
                        JobLocation= "Panjim",
                        JobDepartment= "HR",
                        ClosingDate="2022-08-30T18:43:31.877Z",
                        PostedDate="2021-09-30T18:43:31.877Z"
                    }
                }
            };
        }
    }
}