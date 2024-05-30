using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Zone.Core.DNS.Queries;
using Zone.Core.Zone.Commands.Create;
using ZoneClient.Models;

namespace ZoneClient.Services
{
    public class ZoneService : IZoneService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private const string endPoint = "zone";
        public ZoneService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }
        public async Task<List<SelectListItem>> GetAllZones()
        {
            var response = await _httpClient.GetAsync(endPoint);
            var allDNSRecord = response.Content.ReadFromJsonAsync<GetZonesListResponse>();

            var result = _mapper.Map<List<SelectListItem>>(allDNSRecord.Result.Data);
            result.Insert(0, new SelectListItem("Select Zone", string.Empty));
            return result;
        }
        public async Task<ZoneRecordListVM> GetZoneById(int id)
        {
            
            var response = await _httpClient.GetAsync($"{endPoint}/{id}");
            var allDNSRecord = response.Content.ReadFromJsonAsync<GetZonesListResponse>();
            return allDNSRecord.Result.Data[0];
        }
        public async Task<CreateZoneCommandResponse> CreateZoneRecord(CreateZoneViewModel createDnsViewModel)
        {
            var allDNSRecord = await _httpClient.PostAsJsonAsync<CreateZoneViewModel>(endPoint, createDnsViewModel);
            allDNSRecord.EnsureSuccessStatusCode();
            return await allDNSRecord.Content.ReadFromJsonAsync<CreateZoneCommandResponse>();
        }

        public async Task DeleteZoneRecord(int id)
        {
            var allDNSRecord = await _httpClient.DeleteAsync($"{endPoint}/{id}");
            allDNSRecord.EnsureSuccessStatusCode();
        }
    }
}
