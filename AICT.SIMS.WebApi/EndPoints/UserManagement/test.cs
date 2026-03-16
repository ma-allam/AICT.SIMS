using AICT.SIMS.Application.Business.UserManagement;
using AICT.SIMS.Core.Exceptions;
using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace AICT.SIMS.WebApi.EndPoints.UserManagement
{
    public class testEndPoint : EndpointBaseAsync
    .WithRequest<testEndPointRequest>
    .WithActionResult<testEndPointResponse>
    {
        private readonly ILogger<testEndPoint> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public testEndPoint(ILogger<testEndPoint> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        [Authorize]
        [ApiVersion("0.0")]
        [HttpGet(testEndPointRequest.Route)]
        [SwaggerOperation(Summary = "test", Description = "test ", OperationId = "AICT.SIMS.WebApi.EndPoints.UserManagement.test", Tags = new[] { "AICT.SIMS.WebApi.EndPoints.UserManagement" })]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(testEndPointResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ExceptionOutput))]
        public override async Task<ActionResult<testEndPointResponse>> HandleAsync([FromQuery] testEndPointRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Information : Starting test handling");
            var Appinput = _mapper.Map<testHandlerInput>(request);
            var result = await _mediator.Send(Appinput, cancellationToken);

            return Ok(_mapper.Map<testEndPointResponse>(result));
        }
    }
}
