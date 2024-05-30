using AutoMapper;
using Zone.Core.DNS.Commands.CreateDNS;
using Zone.Core.DNS.Commands.UpdateDNS;
using Zone.Core.DNS.Queries;
using Zone.Core.Response;
using Zone.Core.Zone.Commands.Create;
using Zone.Domain;
namespace Zone.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DnsRecord, DnsRecordListVM>().ReverseMap();
            CreateMap<CreateDNSCommand, DnsRecord>().ReverseMap();
            CreateMap( typeof(PaginatedList<>), typeof(PaginatedList<>)).ConvertUsing(typeof(PaginatedListConverter<,>));
            CreateMap<CreateDNSDto, DnsRecord>().ReverseMap();
            CreateMap<UpdateDNSCommand, DnsRecord>().ReverseMap();

            CreateMap<ZoneRecord, ZoneRecordListVM>().ReverseMap();
            CreateMap<CreateZoneCommand, ZoneRecord>().ReverseMap();
            CreateMap<ZoneRecord, CreateZoneDto>().ReverseMap();
        }
    }
}
