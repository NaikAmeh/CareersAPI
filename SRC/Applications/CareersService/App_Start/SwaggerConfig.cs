using CareersService;
using Swashbuckle.Application;
using Swashbuckle.Examples;
using System.Web.Http;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace CareersService
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "CareersService");
                        c.IncludeXmlComments(string.Format(@"{0}\bin\CareersService.xml", System.AppDomain.CurrentDomain.BaseDirectory));
                        c.OperationFilter<ExamplesOperationFilter>();
                    })
                .EnableSwaggerUi(c =>
                    {
                        
                    });
        }
    }
}
