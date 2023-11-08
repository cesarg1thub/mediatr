using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using mediatr_consoleapp1.Context;

namespace mediatr_consoleapp1;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var hostBuilder = CreateHostBuilder(args);
        await hostBuilder.RunConsoleAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostingContext, services) =>
            {
                services.AddDbContext<MyDbContext>(options =>
                {
                    // options.UseSqlServer(configuration.GetConnectionString("SecSiteMailDBContext"));
                    options.UseSqlServer("Server=localhost; Database=SecSiteMailDB; User Id=sa; Password=P@ssw0rd01;TrustServerCertificate=True;");
                });
                services.AddSingleton<IMyDbContext>(provider => provider.GetService<MyDbContext>());
                services.AddMediatR(_ => _.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
                services.AddAutoMapper(Assembly.GetExecutingAssembly());
                services.AddSingleton<IHostedService, ConsoleApp>();
            });
}
