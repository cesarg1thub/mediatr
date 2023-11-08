using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using mediatr_consoleapp1.Context;

namespace mediatr_consoleapp1.GetAllSites;

public class GetAllSitesQueryHandler : IRequestHandler<GetAllSitesRequest, List<GetAllSitesResponse>>
{
    private readonly IMyDbContext _myDBContext;
    private readonly IMapper _mapper;

    public GetAllSitesQueryHandler(IMyDbContext myDBContext, IMapper mapper)
    {
        _myDBContext = myDBContext;
        _mapper = mapper;
    }

    public Task<List<GetAllSitesResponse>> Handle(GetAllSitesRequest request, CancellationToken cancellationToken)
    {
        return _myDBContext.Sites.ProjectTo<GetAllSitesResponse>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
