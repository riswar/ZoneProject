using Zone.Core.Response;

namespace Zone.Core.DNS.Commands.CreateDNS
{
    public class UpdateDNSCommandResponse : BaseResponse
    {
        public UpdateDNSDto DNS { get; set; } = default!;
    }
}
