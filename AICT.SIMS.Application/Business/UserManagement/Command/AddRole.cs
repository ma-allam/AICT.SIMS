using AICT.SIMS.Application.Contract;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AICT.SIMS.Application.Contract;
using AICT.SIMS.Core.Exceptions;
using System.Security.Permissions;

namespace AICT.SIMS.Application.Business.UserManagement.Command
{
    public class AddRoleHandler : IRequestHandler<AddRoleHandlerInput, AddRoleHandlerOutput>
    {
        private readonly IDataBaseService _databaseService;
        private readonly ILogger<AddRoleHandler> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AddRoleHandler(ILogger<AddRoleHandler> logger, IDataBaseService databaseService, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _databaseService = databaseService;
            _roleManager = roleManager;
        }
        public async Task<AddRoleHandlerOutput> Handle(AddRoleHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling AddRole business logic");
            AddRoleHandlerOutput output = new AddRoleHandlerOutput(request.CorrelationId());

          
                var role = new IdentityRole { Name = request.RoleName };
                var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                output.Message = "Role created successfully";
            }
            else
            {
                throw new WebApiException(WebApiExceptionSource.DynamicMessage, result.Errors.ToString());
            }
            
            return output;
        }
    }
}
