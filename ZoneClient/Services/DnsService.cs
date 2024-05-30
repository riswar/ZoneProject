using AutoMapper;
using Zone.Core.DNS.Commands.CreateDNS;
using Zone.Core.DNS.Queries;
using Zone.Core.Response;
using ZoneClient.Extensions;
using ZoneClient.Models;

namespace ZoneClient.Services
{
    public class DnsService : IDnsService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private const string endPoint = "Dns";
        public DnsService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }
        public async Task<GetPaginatedDnsResponseVM> GetAllDNSRecords(DNSSearchRequestVM query)
        {
            //Replace Datatable column identifier to appropriate name before sending to API
            query.OrderByField = query.OrderByField switch
            {
                "1" => "Zone",
                "3" => "RecordName",
                "4" => "Zone",
                "5" => "Type",
                "6" => "Ttl",
                _ => "Fqdn"

            };
            var response = await _httpClient.GetAsync(endPoint, query);
            var allDNSRecord = response.Content.ReadFromJsonAsync<GetDnsListResponse>();
            var result = _mapper.Map<GetPaginatedDnsResponseVM>(allDNSRecord.Result);
            result.Draw = query.Draw;
            return result;
        }
        public async Task<CreateDNSCommandResponse> CreateDNSRecord(CreateDnsViewModel createDnsViewModel)
        {
            var allDNSRecord = await _httpClient.PostAsJsonAsync<CreateDnsViewModel>(endPoint, createDnsViewModel);
            allDNSRecord.EnsureSuccessStatusCode();
            return await allDNSRecord.Content.ReadFromJsonAsync<CreateDNSCommandResponse>();
        }
        public async Task<BaseResponse> UpdateDNSRecord(UpdateDnsViewModel updateDnsRequest)
        {
            var allDNSRecord = await _httpClient.PutAsJsonAsync<UpdateDnsViewModel>(endPoint, updateDnsRequest);
            allDNSRecord.EnsureSuccessStatusCode();
            return await allDNSRecord.Content.ReadFromJsonAsync<BaseResponse>();

        }
        public async Task DeleteDNSRecord(int id)
        {
            var allDNSRecord = await _httpClient.DeleteAsync($"{endPoint}/{id}");
            allDNSRecord.EnsureSuccessStatusCode();
        }
    }
}
