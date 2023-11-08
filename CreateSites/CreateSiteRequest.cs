using MediatR;

namespace mediatr_consoleapp1.CreateSites;
public class CreateSiteRequest : IRequest<Guid>
{
    public string? Title { get; set; }
    public string? Domain { get; set; }
    public string? Url { get; set; }
}
