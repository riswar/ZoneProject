using MediatR;
using Microsoft.AspNetCore.Mvc;
using Zone.Core.DNS.Queries;
using Zone.Core.Zone.Commands.Create;
using Zone.Core.Zone.Commands.Delete;

namespace ZoneApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZoneController : ControllerBase
    {
        private readonly IMediator _mediator;        
        private readonly ILogger<ZoneController> _logger;
        public ZoneController(ILogger<ZoneController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        /// <summary>
        /// GetAllZones displays all zone information
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id?}",Name = "dns/GetAllZones")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]        
        public async Task<ActionResult<GetDnsListResponse>> GetAllZones(int? Id)
        {
            _logger.LogInformation("Entering to GetAllZones");            
            var dtos = await _mediator.Send(new GetZonesListQuery() { Id= Id });
            _logger.LogInformation("Leaving from GetAllZones");
            return Ok(dtos);
        }      

        [HttpPost(Name = "Dns/Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CreateZoneCommandResponse>> Create(CreateZoneCommand createZoneCommand)
        {
            _logger.LogInformation("Entering to Create");
            var id = await _mediator.Send(createZoneCommand);
            _logger.LogInformation($"Leaving from Create{id}");
            return Ok(id);
        }
       
        [HttpDelete("{id}", Name = "Dns/Delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            _logger.LogInformation("Entering to Delete");
            await _mediator.Send(new DeleteZoneCommand() { Id = id });
            _logger.LogInformation($"Leaving from Delete");
            return NoContent();
        }
    }
}
