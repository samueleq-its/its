using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;

namespace BikeStores.WebAPI.Security
{
    internal sealed class ApiKeySecuritySchemeTransformer : IOpenApiDocumentTransformer
    {
        public Task TransformAsync(OpenApiDocument document,
            OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
        {
            document.Components ??= new OpenApiComponents();
            document.Components!.SecuritySchemes ??= new Dictionary<string, IOpenApiSecurityScheme>();
            document.Components.SecuritySchemes["ApiKey"] = new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.ApiKey,
                In = ParameterLocation.Header,
                Name = ApiKeyMiddleware.HeaderName,
                Description = "Secret key generata all'avvio (vedi console)."
            };

            document.Security ??= new List<OpenApiSecurityRequirement>();
            document.Security.Add(new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference("ApiKey", document, null)] = new List<string>()
            });

            return Task.CompletedTask;
        }
    }
}
