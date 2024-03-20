using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using NSwag;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DigitusCase.Helpers
{
    public class AcceptLanguageHeaderParameter : IOperationFilter
    {

        public void Apply(Microsoft.OpenApi.Models.OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters.Add(new Microsoft.OpenApi.Models.OpenApiParameter()
            {
                Name = "Accept-Language",
                Description = "Language preference for the response.",
                In = ParameterLocation.Header,
                Schema = new Microsoft.OpenApi.Models.OpenApiSchema() { 
                    Type = "String",
                    Enum = Enum.GetNames(typeof(Language)).Select(name => new OpenApiString(name)).ToList<IOpenApiAny>(),
                },
                Required = false,
                Example = new OpenApiString(Language.en.ToString()) // Default language example

            });

        }

        private enum Language
        {
            en,
            tr
        }
    }
}
