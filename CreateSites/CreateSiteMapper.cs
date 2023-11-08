
using AutoMapper;
using mediatr_consoleapp1.CreateSites;
using mediatr_consoleapp1.Entities;

namespace mediatr_consoleapp1;

public class CreateSiteMapper : Profile
{
    public CreateSiteMapper()
    {
        CreateMap<CreateSiteRequest, Site>();
    }
}
