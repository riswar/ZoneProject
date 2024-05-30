using MediatR;

namespace Zone.Core.Zone.Commands.Create
{
    public class CreateZoneCommand : IRequest<CreateZoneCommandResponse>
    {
        public string Name { get; set; }
    }
}
