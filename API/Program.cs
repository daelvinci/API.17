using Data;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using API.Apps.AdminApi.DTOs.BrandDTOs;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;
using API.Profiles;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<ShopDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opt=>
            {
                opt.SwaggerDoc("admin_v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version="v1",
                    Title="Shop API for admin"
                });

                opt.SwaggerDoc("user_v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Shop API for users"
                });
            });
            builder.Services.AddFluentValidationRulesToSwagger();

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<BrandDTOValidator>();
            builder.Services.AddAutoMapper(opt =>
            {
                opt.AddProfile(new MapProfile());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(opt =>
                {
                    opt.SwaggerEndpoint("admin_v1/swagger.json", "admin_v1");
                    opt.SwaggerEndpoint("user_v1/swagger.json", "user_v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}