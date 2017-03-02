using System.Web.Http;
using WebActivatorEx;
using VAssistsProject;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace VAssistsProject
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration 
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "VAssistsProject");
                        c.IncludeXmlComments(string.Format(@"{0}\bin\SwaggerDemoApi.XML",
                            System.AppDomain.CurrentDomain.BaseDirectory));
                        c.DescribeAllEnumsAsStrings();
                    })
                .EnableSwaggerUi(c =>
                    {
                      
                    });
        }
    }
}
