using AICT.SIMS.Application.Contract;
using AICT.SIMS.Core.Exceptions;
using AICT.SIMS.Domain.DomainEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AICT.SIMS.Application.Business.UserManagement.Command
{
    public class AssignUserToRoleHandler : IRequestHandler<AssignUserToRoleHandlerInput, AssignUserToRoleHandlerOutput>
    {
        private readonly IDataBaseService _databaseService;
        private readonly ILogger<AssignUserToRoleHandler> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        public AssignUserToRoleHandler(ILogger<AssignUserToRoleHandler> logger, IDataBaseService databaseService,  UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _databaseService = databaseService;
            _userManager = userManager;
        }
        public async Task<AssignUserToRoleHandlerOutput> Handle(AssignUserToRoleHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling AssignUserToRole business logic");
            AssignUserToRoleHandlerOutput output = new AssignUserToRoleHandlerOutput(request.CorrelationId());

            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                throw new WebApiException("User not found");
            }

            var result = await _userManager.AddToRoleAsync(user, request.RoleName);
            if (result.Succeeded)
            {
                output.Message = "Role assigned successfully";
            }
            else
            {
                throw new WebApiException(WebApiExceptionSource.DynamicMessage, result.Errors.ToString());


            }
            return output;
        }
    }
}
