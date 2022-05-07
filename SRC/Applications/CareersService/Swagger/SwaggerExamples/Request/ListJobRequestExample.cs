using CareersService.Models.RequestModels;
using Swashbuckle.Examples;

namespace CareersService.Swagger.SwaggerExamples.Request
{
    public class ListJobRequestExample: IExamplesProvider
    {
        public object GetExamples()
        {
            return new ListJobsRequest
            {
                JobName = "test",
                PageNo = 1,
                PageSize = 10,
                DepartmentId = 1,
                LocationId = 1
            };
        }
    }
}