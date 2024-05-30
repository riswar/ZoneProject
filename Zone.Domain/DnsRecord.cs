namespace Zone.Domain
{
    public class DnsRecord :BaseEntity
    {
        public string Fqdn { get; set; }
        public string RecordName { get; set; }
        public string Type { get; set; }
        public int Ttl { get; set; }
        public string Data { get; set; }
        public int Zone { get; set; } //Make a relationship with Zone record
    }
}
