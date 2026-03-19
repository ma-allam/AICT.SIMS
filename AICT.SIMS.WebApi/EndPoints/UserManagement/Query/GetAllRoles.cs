using AICT.SIMS.Application.Business.UserManagement.Query;
using AICT.SIMS.Core.Exceptions;
using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace AICT.SIMS.WebApi.EndPoints.UserManagement.Query
{
    public class GetAllRolesEndPoint : EndpointBaseAsync
    .WithRequest<GetAllRolesEndPointRequest>
    .WithActionResult<GetAllRolesEndPointResponse>
    {
        private readonly ILogger<GetAllRolesEndPoint> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public GetAllRolesEndPoint(ILogger<GetAllRolesEndPoint> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        [Authorize]
        [ApiVersion("0.0")]
        [HttpGet(GetAllRolesEndPointRequest.Route)]
        [SwaggerOperation(Summary = "GetAllRoles", Description = "GetAllRoles ", OperationId = "AICT.SIMS.WebApi.EndPoints.UserManagement.Query.GetAllRoles", Tags = new[] { "AICT.SIMS.WebApi.EndPoints.UserManagement.Query" })]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetAllRolesEndPointResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ExceptionOutput))]
        public override async Task<ActionResult<GetAllRolesEndPointResponse>> HandleAsync([FromQuery] GetAllRolesEndPointRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Information : Starting GetAllRoles handling");
            var Appinput = _mapper.Map<GetAllRolesHandlerInput>(request);
            var result = await _mediator.Send(Appinput, cancellationToken);

            return Ok(_mapper.Map<GetAllRolesEndPointResponse>(result));
        }
    }
}
