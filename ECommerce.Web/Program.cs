using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;
using Persistence.Repositories;
using AutoMapper;
using Services.MappingProfiles;
using Microsoft.Data.SqlClient;
using ServiceAbstraction;
using Services;
using ECommerce.Web.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Shared.ErrorModels;
using ECommerce.Web.Factories;



namespace ECommerce.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Services 
            // Add services to the container.
            builder.Services.AddWebApplicationServices();
            builder.Services.AddInfrastructureRegisteration(builder.Configuration);
            builder.Services.AddApplicationServices();
         

            #endregion


            var app = builder.Build();

            await app.InitializeDbAsync();

            #region custom Exception Middelware
            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("Process Request");
            //    await next.Invoke();
            //    Console.WriteLine("Response");
            //    Console.WriteLine(context.Response);
            //}
            //);
            app.UseMiddleware<CustomExceptionHandelrMiddlleware>();
            #endregion

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();

            // app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
       
    }
}
