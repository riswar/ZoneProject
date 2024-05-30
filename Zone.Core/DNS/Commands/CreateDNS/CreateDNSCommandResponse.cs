using Zone.Core.Response;

namespace Zone.Core.DNS.Commands.CreateDNS
{
    public class CreateDNSCommandResponse : BaseResponse
    {
        public CreateDNSDto DNS { get; set; } = default!;
    }
}
