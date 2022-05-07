using CareersService.Models.RequestModels;
using Swashbuckle.Examples;

namespace CareersService.Swagger.SwaggerExamples.Request
{
    public class JobRequestExample: IExamplesProvider
    {
        public object GetExamples()
        {
            return new JobRequest
            {
                Title="Manager",
                Description = "Test Description",
                LocationId = 1,
                DepartmentId=1,
                ClosingDate= "2022-08-30T18:43:31.877Z"
            };
        }
    }
}