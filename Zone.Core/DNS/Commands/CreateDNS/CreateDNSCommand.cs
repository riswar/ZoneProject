using MediatR;

namespace Zone.Core.DNS.Commands.CreateDNS
{
    public class CreateDNSCommand : IRequest<CreateDNSCommandResponse>
    {
        public string Fqdn { get; set; }
        public string RecordName { get; set; }
        public string Type { get; set; }
        public int Ttl { get; set; }
        public string Data { get; set; }
        public int Zone { get; set; }
    }
}
