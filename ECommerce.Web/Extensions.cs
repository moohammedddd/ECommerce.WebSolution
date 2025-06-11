using Domain.Contracts;
using ECommerce.Web.Factories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web
{
    public static class Extensions
    {
        public static IServiceCollection AddWebApplicationServices(this  IServiceCollection services)
        {


            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwaggerServices();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                //Func<ActionContext , IActionResult> 
                options.InvalidModelStateResponseFactory = ApIResponseFactory.GenerateApiValidationResponse;

            });
            return services;
        }

        private static void AddSwaggerServices( this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }


        public static async Task InitializeDbAsync( this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitialiizer>();
            await dbInitializer.InitialiizeAsync();
        }
    }
}
