using Congratulator.Core.Abstractions;
using Congratulator.Core.Abstractions.Database;
using Congratulator.Core.Services;
using Congratulator.Infrastructure.Database;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.Configuration;

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
            builder.Services.AddSingleton<IEmailDistributionService>(sp =>
                new EmailDistributionService(
                    builder.Configuration,
                    sp.GetRequiredService<IBirthdayDateService>(),
                    sp.GetRequiredService<IRecurringJobManager>()));
            builder.Services.AddSingleton<IBirthdayDateRepository, EntityFrameworkRepository>();
            builder.Services.AddSingleton<IImageRepository, EntityFrameworkRepository>();
            builder.Services.AddTransient<IBirthdayDateService, BirthdayDateService>();
            builder.Services.AddScoped<IImageService, ImageService>();
            // Add Hangfire
            builder.Services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UsePostgreSqlStorage(builder.Configuration.GetConnectionString("Default")));
            // Start Hangfire server
            builder.Services.AddHangfireServer();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
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