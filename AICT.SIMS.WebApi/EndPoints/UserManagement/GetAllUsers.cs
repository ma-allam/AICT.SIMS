using Ardalis.ApiEndpoints;
using AutoMapper;
using AICT.SIMS.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using AICT.SIMS.Application.Business.UserManagement;

namespace AICT.SIMS.WebApi.EndPoints.UserManagement
{
    public class GetAllUsersEndPoint : EndpointBaseAsync
    .WithRequest<GetAllUsersEndPointRequest>
    .WithActionResult<GetAllUsersEndPointResponse>
    {
        private readonly ILogger<GetAllUsersEndPoint> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public GetAllUsersEndPoint(ILogger<GetAllUsersEndPoint> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        [Authorize]
        [ApiVersion("0.0")]
        [HttpGet(GetAllUsersEndPointRequest.Route)]
        [SwaggerOperation(Summary = "GetAllUsers", Description = "GetAllUsers ", OperationId = "AICT.SIMS.WebApi.EndPoints.UserManagement.GetAllUsers", Tags = new[] { "AICT.SIMS.WebApi.EndPoints.UserManagement" })]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetAllUsersEndPointResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ExceptionOutput))]
        public override async Task<ActionResult<GetAllUsersEndPointResponse>> HandleAsync([FromQuery] GetAllUsersEndPointRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Information : Starting GetAllUsers handling");
            var Appinput = _mapper.Map<GetAllUsersHandlerInput>(request);
            var result = await _mediator.Send(Appinput, cancellationToken);

            return Ok(_mapper.Map<GetAllUsersEndPointResponse>(result));
        }
    }
}
