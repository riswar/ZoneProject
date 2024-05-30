namespace Zone.ViewModel
{
    public class DnsRecordListVM
    {
        public int Id { get; set; }
        public string Fqdn { get; set; }
        public string RecordName { get; set; }
        public string Type { get; set; }
        public int Ttl { get; set; }
        public string Data { get; set; }
        public string Zone { get; set; }

    }
}
