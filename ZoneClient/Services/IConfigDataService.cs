using Microsoft.AspNetCore.Mvc.Rendering;

namespace ZoneClient.Services
{
    public interface IConfigDataService
    {
        List<SelectListItem> DNSRecordType { get; }
    }
}