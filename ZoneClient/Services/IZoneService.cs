using Microsoft.AspNetCore.Mvc.Rendering;
using Zone.Core.DNS.Commands.CreateDNS;
using Zone.Core.DNS.Queries;
using Zone.Core.Zone.Commands.Create;
using ZoneClient.Models;

namespace ZoneClient.Services
{
    public interface IZoneService
    {
        Task<CreateZoneCommandResponse> CreateZoneRecord(CreateZoneViewModel createDnsViewModel);
        Task DeleteZoneRecord(int id);
        Task<List<SelectListItem>> GetAllZones();
        Task<ZoneRecordListVM> GetZoneById(int id);
    }
}