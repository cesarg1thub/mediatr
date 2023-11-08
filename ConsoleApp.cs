using MediatR;
using mediatr_consoleapp1.CreateSites;
using mediatr_consoleapp1.GetAllSites;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class ConsoleApp : IHostedService
{
    private readonly ILogger _logger;
    private readonly IMediator _mediator;
    public ConsoleApp(IMediator mediator, ILogger<ConsoleApp> logger)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting application");

        int choice = -1;
        while (choice != 0)
        {
            Console.WriteLine("Please choose one of the following options:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Create Site");
            Console.WriteLine("2. Get All Sites");

            try
            {
                string input = Console.ReadLine();
                choice = int.Parse(input ?? "-1");
            }
            catch (FormatException)
            {
                choice = -1;
            }

            switch (choice)
            {
                case 0:
                    Console.WriteLine("Bye...");
                    break;
                case 1:

                    var id = await _mediator.Send(new CreateSiteRequest { Title = "New Site", Domain = "newsite.com", Url = "https://newsite.com" }, cancellationToken);
                    break;
                 case 2:
                    var sites = await _mediator.Send(new GetAllSitesRequest(), cancellationToken);
                    foreach (var site in sites)
                    {
                        Console.WriteLine($"Id: {site.Id}, Title: {site.Title}, Domain: {site.Domain}, Url: {site.Url}");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }
        }

        await Task.CompletedTask;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Stopping application");

        await Task.CompletedTask;
    }
}
