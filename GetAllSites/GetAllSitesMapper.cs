using AutoMapper;
using mediatr_consoleapp1.Entities;

namespace mediatr_consoleapp1.GetAllSites;

public class GetAllSitesMapper : Profile
{
    public GetAllSitesMapper()
    {
        CreateMap<Site, GetAllSitesResponse>();
    }

}
