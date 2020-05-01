using System;
using System.Threading.Tasks;
using InfoTrack.Common.Api.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using TodoList.Infrastructure.Persistence;

namespace TodoList.Api
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            try
            {
                var host = CreateHostBuilder(args).Build();
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;

                    try
                    {
                        var context = services.GetRequiredService<AppDbContext>();

                        context.Database.EnsureCreated();

                        await AppDbContextSeed.SeedAsync(context);
                    }
                    catch (Exception ex)
                    {
                        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

                        logger.LogError(ex, "An error occurred while migrating or seeding the database.");
                    }
                }

                await host.RunAsync();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly, check the application's WebHost configuration.");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseSerilog(SerilogConfiguration.ConfigureLogger)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
