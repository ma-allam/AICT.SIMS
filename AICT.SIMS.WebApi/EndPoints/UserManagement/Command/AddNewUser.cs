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
    public class AddNewUserEndPoint : EndpointBaseAsync
    .WithRequest<AddNewUserEndPointRequest>
    .WithActionResult<AddNewUserEndPointResponse>
    {
        private readonly ILogger<AddNewUserEndPoint> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public AddNewUserEndPoint(ILogger<AddNewUserEndPoint> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        [Authorize]
        [ApiVersion("0.0")]
        [HttpPost(AddNewUserEndPointRequest.Route)]
        [SwaggerOperation(Summary = "AddNewUser", Description = "AddNewUser ", OperationId = "AICT.SIMS.WebApi.EndPoints.UserManagement.AddNewUser", Tags = new[] { "AICT.SIMS.WebApi.EndPoints.UserManagement" })]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(AddNewUserEndPointResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ExceptionOutput))]
        public override async Task<ActionResult<AddNewUserEndPointResponse>> HandleAsync([FromBody] AddNewUserEndPointRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Information : Starting AddNewUser handling");
            var Appinput = _mapper.Map<AddNewUserHandlerInput>(request);
            var result = await _mediator.Send(Appinput, cancellationToken);

            return Ok(_mapper.Map<AddNewUserEndPointResponse>(result));
        }
    }
}
