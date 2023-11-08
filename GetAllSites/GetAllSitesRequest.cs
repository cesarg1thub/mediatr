using MediatR;
using mediatr_consoleapp1.GetAllSites;

namespace mediatr_consoleapp1.GetAllSites;

public class GetAllSitesRequest : IRequest<List<GetAllSitesResponse>> {}
