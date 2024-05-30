using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Zone.Core.DNS.Queries;
using ZoneClient.Models;
using ZoneClient.Services;

namespace ZoneClient.Controllers
{
    public class ZoneController : Controller
    {
        private readonly ILogger<ZoneController> _logger;
        private readonly IZoneService _zoneService;
        private readonly IDnsService _dnsService;

        private readonly IMapper _mapper;
        public ZoneController(ILogger<ZoneController> logger, IZoneService zoneService, IDnsService dnsService, IMapper mapper)
        {
            _logger = logger;
            _zoneService = zoneService;
            _dnsService = dnsService;
            _mapper = mapper;
        }

        public IActionResult DNSList(GetDnsListQuery request)
        {       
            return View();
        }
        public IActionResult CreateZone() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateZone(CreateZoneViewModel request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var response = await _zoneService.CreateZoneRecord(request);
            if (!response.Success)
            {
                ModelState.AddModelError(string.Empty, string.Join("<BR />", response.ValidationErrors.ToArray()));
                return View(request);
            }
            ViewData.Add("Status", true);
            ViewData.Add("Id", response.Zone.Id);
            
            return View();
        }

        public IActionResult CreateDNS(int id) 
        {
            ViewData["Id"] = id;
            return  View(); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDNS(CreateDnsViewModel request)
        {
            if (!ModelState.IsValid)
                return View(request);
            
            var response = await _dnsService.CreateDNSRecord(request);
            if (!response.Success)
            {
                ViewData.Add("Status", false);
                ViewData["Id"] = Convert.ToInt32(request.Zone);
                ModelState.AddModelError("", string.Join("<BR />", response.ValidationErrors.ToArray()));
                return View(request);
            }
            ViewData.Add("Status", true);
            ViewData["Id"] = Convert.ToInt32(response.DNS.Zone);
            return View(request);
        }
        public async Task<IActionResult> UpdateDNS(int id)
        {
            var query = new DNSSearchRequestVM();
            query.Id = id;            
            var lstDns= await _dnsService.GetAllDNSRecords(query);
            return View(_mapper.Map<UpdateDnsViewModel>(lstDns.Data[0]));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateDNS(UpdateDnsViewModel request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var response= await _dnsService.UpdateDNSRecord(request);
            if (!response.Success)
            {
                ViewData.Add("Status", false);
                ModelState.AddModelError("", string.Join("<BR />", response.ValidationErrors.ToArray()));
                return View(request);
            }
            ViewData.Add("Status", true);
            return View(request);
        }
        public async Task<IActionResult> DeleteDNS(int id)
        {
            var query = new DNSSearchRequestVM();
            query.Id = id;
            var lstDns = await _dnsService.GetAllDNSRecords(query);
            return View(lstDns.Data[0]);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDNSConfirm(int id)
        {            
            await _dnsService.DeleteDNSRecord(id);
            ViewData.Add("Status", true);
            return View("DeleteDNS",null);
        }


        public async Task<IActionResult> DeleteZone(int id)
        {
            var query = new DNSSearchRequestVM();
            query.ZoneId = id;
            query.Limit = 100;
            ViewData["Id"] = id;
            var lstZone = await _dnsService.GetAllDNSRecords(query);
            ViewData["Id"] = id;
            return View(lstZone.Data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteZoneConfirm(int id)
        {
            await _zoneService.DeleteZoneRecord(id);
            ViewData.Add("Status", true);
            return View("DeleteZone", null);
        }
        public async Task<GetPaginatedDnsResponseVM> GetDNSRecords(DNSSearchRequestVM request) => await _dnsService.GetAllDNSRecords(request);
        

        public async Task<IActionResult> LoadInitialData()
        {
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    await _zoneService.CreateZoneRecord(new CreateZoneViewModel() { Name = $"microsoft{i+1}.com" });
                    CreateDnsViewModel vm = new CreateDnsViewModel() { Data = "1", Fqdn = $"microsoft{i}.com", RecordName = "A", Ttl = 1221, Type = "A", Zone = i.ToString() };
                    await _dnsService.CreateDNSRecord(vm);
                }
                catch(Exception ex)
                {

                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
