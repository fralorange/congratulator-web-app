using Congratulator.Core.Abstractions;
using Congratulator.Core.Abstractions.Database;
using Congratulator.Core.Services;
using Congratulator.Infrastructure;
using Congratulator.Infrastructure.Database;

namespace Congratulator.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Implement Dependency Injection
            builder.Services.AddScoped<IBirthdayDateRepository, EntityFrameworkRepository>();
            builder.Services.AddScoped<IImageRepository, EntityFrameworkRepository>();
            builder.Services.AddScoped<IBirthdayDateService, BirthdayDateService>();
            builder.Services.AddScoped<IImageService, ImageService>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            } else
            {
                app.UseDefaultFiles();
                app.UseStaticFiles();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}