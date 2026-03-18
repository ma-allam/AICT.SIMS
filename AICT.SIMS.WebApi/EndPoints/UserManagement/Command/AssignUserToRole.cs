using AICT.SIMS.Application.Business.UserManagement.Command;
using AICT.SIMS.Core.Exceptions;
using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace AICT.SIMS.WebApi.EndPoints.UserManagement.Command
{
    public class AssignUserToRoleEndPoint : EndpointBaseAsync
    .WithRequest<AssignUserToRoleEndPointRequest>
    .WithActionResult<AssignUserToRoleEndPointResponse>
    {
        private readonly ILogger<AssignUserToRoleEndPoint> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public AssignUserToRoleEndPoint(ILogger<AssignUserToRoleEndPoint> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        [Authorize]
        [ApiVersion("0.0")]
        [HttpPost(AssignUserToRoleEndPointRequest.Route)]
        [SwaggerOperation(Summary = "AssignUserToRole", Description = "AssignUserToRole ", OperationId = "AICT.SIMS.WebApi.EndPoints.UserManagement.AssignUserToRole", Tags = new[] { "AICT.SIMS.WebApi.EndPoints.UserManagement" })]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(AssignUserToRoleEndPointResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ExceptionOutput))]
        public override async Task<ActionResult<AssignUserToRoleEndPointResponse>> HandleAsync([FromBody] AssignUserToRoleEndPointRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Information : Starting AssignUserToRole handling");
            var Appinput = _mapper.Map<AssignUserToRoleHandlerInput>(request);
            var result = await _mediator.Send(Appinput, cancellationToken);

            return Ok(_mapper.Map<AssignUserToRoleEndPointResponse>(result));
        }
    }
}
