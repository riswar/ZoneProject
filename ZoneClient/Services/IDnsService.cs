using Zone.Core.DNS.Commands.CreateDNS;
using Zone.Core.Response;
using ZoneClient.Models;

namespace ZoneClient.Services
{
    public interface IDnsService
    {
        Task<CreateDNSCommandResponse> CreateDNSRecord(CreateDnsViewModel createDnsViewModel);
        Task DeleteDNSRecord(int id);
        Task<GetPaginatedDnsResponseVM> GetAllDNSRecords(DNSSearchRequestVM query);
        Task<BaseResponse> UpdateDNSRecord(UpdateDnsViewModel updateDnsRequest);
    }
}