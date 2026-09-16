
using AutoManager.Application.Interfaces;
using AutoManager.Application.Services;
using AutoManager.Infrastructure.Models;
using AutoManager.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutoManager.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();  // this will open this link
                                            //https://localhost:7010/openapi/v1.json
                                            //http://localhost:5010/openapi/v1.json

            var apiKey = Environment.GetEnvironmentVariable("VEHICLE_PARTNER_API_KEY"); // example of how an 
            // CHECK IF 
            // TAG: DI_Registrations 
            // To allow the entity framework context
            builder.Services.AddDbContext<VehicleManagerContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    sqlOptions => sqlOptions.EnableRetryOnFailure()); // used to tripe check conenctions is alive
            });
            builder.Services.AddScoped<IVehicleRepository, VehicleRepository>(); // THIS REQUIRES THE VehicleManagerContext AS IT IS BEING INJECTED 
            builder.Services.AddScoped<IVehicleService, VehicleService>();

            //==================================
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.MapGet("/health", () => "OK"); // Minimal_api for quick testing, similar like node does
            app.Run();
        }
    }
}
