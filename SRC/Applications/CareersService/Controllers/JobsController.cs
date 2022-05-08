using CareerService.Services;
using CareersService.Models.RequestModels;
using CareersService.Models.ResponseModels;
using CareersService.Swagger.SwaggerExamples.Request;
using CareersService.Swagger.SwaggerExamples.Response;
using Swashbuckle.Examples;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CareerService.Controllers
{
    public class JobsController : ApiController
    {
        JobService _jobService = new JobService();

        [SwaggerRequestExample(typeof(JobRequest), typeof(JobRequestExample))]
        [HttpPost]
        public HttpResponseMessage CreateJob(JobRequest model)
        {
            try
            {
                if(!ModelState.IsValid)
                     return new HttpResponseMessage(HttpStatusCode.BadRequest);

                _jobService.SaveJobDetails(model);
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        [SwaggerRequestExample(typeof(ListJobsRequest), typeof(ListJobRequestExample))]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ListJobsResponse))]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(ListJobResponseExample))]
        [HttpPost]
        public HttpResponseMessage List(ListJobsRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);

                ListJobsResponse response = _jobService.ListJobs(model);
                if (response == null)
                    return new HttpResponseMessage(HttpStatusCode.NoContent);
                return HTTPResponse(response, HttpStatusCode.OK);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public HttpResponseMessage UpdateJobDetails(int id, JobRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);

                bool isUpdateSuccess = _jobService.UpdateJobDetails(id, model);
                if (isUpdateSuccess)
                    return new HttpResponseMessage(HttpStatusCode.OK);
                else
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

        }

        public HttpResponseMessage GetJobDetails(int id)
        {
            try
            {
                JobDetailsRespnse response = _jobService.GetJobDetails(id);
                return HTTPResponse(response, HttpStatusCode.OK);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        public static HttpResponseMessage HTTPResponse<T>(T response, HttpStatusCode httpStatusCode)
        {
            return new HttpResponseMessage(httpStatusCode)
            {
                Content = new ObjectContent<T>(response, GlobalConfiguration.Configuration.Formatters.JsonFormatter)
            };
        }
    }
}