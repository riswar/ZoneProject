using MediatR;
using Microsoft.AspNetCore.Mvc;
using Zone.Core.DNS.Commands.CreateDNS;
using Zone.Core.DNS.Commands.DeleteDNS;
using Zone.Core.DNS.Commands.UpdateDNS;
using Zone.Core.DNS.Queries;

namespace ZoneApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DnsController : ControllerBase
    {
        private readonly IMediator _mediator;        
        private readonly ILogger<ZoneController> _logger;
        
        public DnsController(ILogger<ZoneController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        /// <summary>
        /// GetAllZones displays all zone information
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetAllDns")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]        
        public async Task<ActionResult<GetDnsListResponse>> GetAllZones(int offset, int limit, string? orderBy, string? orderByField, string? fqrs, int? id, int? zoneId)
        {
            _logger.LogInformation("Entering to GetAllZones");            
            var dtos = await _mediator.Send(new GetDnsListQuery() { Fqrs= fqrs , Limit=limit,Offset= offset, OrderBy=orderBy, OrderByField=orderByField,Id=id,ZoneId= zoneId });
            _logger.LogInformation("Leaving from GetAllZones");
            return Ok(dtos);
        }      

        [HttpPost(Name = "Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CreateDNSCommandResponse>> Create(CreateDNSCommand createDNSCommand)
        {
            _logger.LogInformation("Entering to Create");
            var id = await _mediator.Send(createDNSCommand);
            _logger.LogInformation($"Leaving from Create{id}");
            return Ok(id);
        }
        [HttpPut(Name = "Update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update(UpdateDNSCommand updateDNSCommand)
        {
            _logger.LogInformation("Entering to Update");
            var result = await _mediator.Send(updateDNSCommand);
            _logger.LogInformation($"Leaving from Update");
            return Ok(result);
        }
        [HttpDelete("{id}", Name = "Delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            _logger.LogInformation("Entering to Delete");
            await _mediator.Send(new DeleteDNSCommand() { Id = id });
            _logger.LogInformation($"Leaving from Delete");
            return NoContent();
        }
    }
}
