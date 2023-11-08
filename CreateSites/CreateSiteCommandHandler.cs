using AutoMapper;
using MediatR;
using mediatr_consoleapp1.Context;
using mediatr_consoleapp1.CreateSites;
using mediatr_consoleapp1.Entities;

namespace mediatr_consoleapp1;

public class CreateSiteCommandHandler : IRequestHandler<CreateSiteRequest, Guid>
{
    private readonly IMyDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateSiteCommandHandler(IMyDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateSiteRequest request, CancellationToken cancellationToken)
    {
        var site = _mapper.Map<Site>(request);
        //site.Id = Guid.NewGuid();
        site.CreatedAt = DateTimeOffset.UtcNow;
        site.CreatedbyUser = Guid.Parse("3b6886a8-db1f-4209-8371-91b49dc4a7f1");
        site.UpdatedAt = DateTimeOffset.UtcNow;
        site.UpdatedbyUser = Guid.Parse("3b6886a8-db1f-4209-8371-91b49dc4a7f1");
        _dbContext.Sites.Add(site);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return site.Id;
    }
}
