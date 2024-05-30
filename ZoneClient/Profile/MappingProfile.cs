using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Zone.Core.DNS.Queries;
using ZoneClient.Models;

namespace ZoneClient
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<GetDnsListResponse, GetPaginatedDnsResponseVM>()
                .ForMember("RecordsTotal", p=>p.MapFrom("TotalRecords"))
                .ForMember("Data", p => p.MapFrom("Data"))
                .ForMember("RecordsFiltered", p => p.MapFrom("TotalRecords"))
                .ForMember("Draw", p => p.Ignore())
                .ForMember("Offset", p => p.Ignore());

            CreateMap<DnsRecordListViewModel, DnsRecordListVM>().ReverseMap();
            CreateMap<UpdateDnsViewModel, DnsRecordListViewModel>().ReverseMap();
            CreateMap<ZoneRecordListVM,SelectListItem>()
              .ForMember("Value", p => p.MapFrom("Id"))
              .ForMember("Text", p => p.MapFrom("Name"));

        }
    }
}
