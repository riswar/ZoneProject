using MediatR;

namespace Zone.Core.Zone.Commands.Delete
{
    public class DeleteZoneCommand : IRequest
    {
        public int Id { get; set; }
    }
}
