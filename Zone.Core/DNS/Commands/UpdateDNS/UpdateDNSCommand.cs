using MediatR;
using Zone.Core.Response;

namespace Zone.Core.DNS.Commands.UpdateDNS
{
    public class UpdateDNSCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public string Fqdn { get; set; }
        public string RecordName { get; set; }
        public string Type { get; set; }
        public int Ttl { get; set; }
        public string Data { get; set; }
        public int Zone { get; set; }
    }
}
