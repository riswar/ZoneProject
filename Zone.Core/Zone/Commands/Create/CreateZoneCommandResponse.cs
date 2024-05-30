using Zone.Core.Response;

namespace Zone.Core.Zone.Commands.Create
{
    public class CreateZoneCommandResponse : BaseResponse
    {
        public CreateZoneDto Zone { get; set; } = default!;
    }
}
