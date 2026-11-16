using System.Security.Cryptography;
using System.Text;

namespace BikeStores.WebAPI.Security
{
    public class ApiKeyMiddleware
    {
        public const string HeaderName = "X-Api-Key";
        private readonly RequestDelegate _next;

        public ApiKeyMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context, ApiKeyProvider provider)
        {
            var path = context.Request.Path;

            // Scalar e documento OpenAPI restano accessibili senza chiave
            if (path.StartsWithSegments("/scalar") || path.StartsWithSegments("/openapi"))
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue(HeaderName, out var received) ||
                !IsValid(received.ToString(), provider.SecretKey))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(new { error = "Secret key mancante o non valida." });
                return;
            }

            await _next(context);
        }

        private static bool IsValid(string received, string expected) =>
            CryptographicOperations.FixedTimeEquals(
                Encoding.UTF8.GetBytes(received), Encoding.UTF8.GetBytes(expected));
    }
}
