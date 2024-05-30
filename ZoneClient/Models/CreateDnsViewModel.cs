using System.ComponentModel;

namespace ZoneClient.Models
{
    public class CreateDnsViewModel
    {
        public string Fqdn { get; set; }
        [DisplayName("Record Name")]
        public string RecordName { get; set; }
        public string Type { get; set; }
        [DisplayName("TTL")]
        public int Ttl { get; set; }
        public string Data { get; set; }
        public string Zone { get; set; }
    }
}
