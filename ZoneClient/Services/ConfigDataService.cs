using Microsoft.AspNetCore.Mvc.Rendering;

namespace ZoneClient.Services
{
    public class ConfigDataService : IConfigDataService
    {
        public List<SelectListItem> DNSRecordType { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "", Text = "Select" },
            new SelectListItem { Value = "A", Text = "A" },
            new SelectListItem { Value = "AAAA", Text = "AAAA" },
            new SelectListItem { Value = "CNAME", Text = "CNAME"  },
            new SelectListItem { Value = "NS", Text = "NS"  },
            new SelectListItem { Value = "TXT", Text = "TXT"  }
        };
    }
}
