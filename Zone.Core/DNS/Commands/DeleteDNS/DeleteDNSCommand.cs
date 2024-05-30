using MediatR;

namespace Zone.Core.DNS.Commands.DeleteDNS
{
    public class DeleteDNSCommand : IRequest
    {
        public int Id { get; set; }
    }
}
