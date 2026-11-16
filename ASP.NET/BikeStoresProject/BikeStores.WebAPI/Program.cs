using BikeStores.Data.Models;
using BikeStores.WebAPI.Security;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace BikeStores.WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<BikeStoresContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("BikeStores")));

        builder.Services.AddSingleton<ApiKeyProvider>();
        builder.Services.AddControllers();
        builder.Services.AddOpenApi(o => o.AddDocumentTransformer<ApiKeySecuritySchemeTransformer>());

        var app = builder.Build();

        var key = app.Services.GetRequiredService<ApiKeyProvider>().SecretKey;
        Console.WriteLine("=====================================================");
        Console.WriteLine($" SECRET KEY (header {ApiKeyMiddleware.HeaderName}):");
        Console.WriteLine($" {key}");
        Console.WriteLine("=====================================================");

        app.MapOpenApi();
        app.MapScalarApiReference();   // https://localhost:5002/scalar/v1

        app.UseHttpsRedirection();
        app.UseMiddleware<ApiKeyMiddleware>();
        app.MapControllers();

        app.Run();
    }
}