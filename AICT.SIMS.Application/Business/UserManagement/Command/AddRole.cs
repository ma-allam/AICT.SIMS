using AICT.SIMS.Application.Contract;
using AICT.SIMS.Application.Contract;
using AICT.SIMS.Core.Exceptions;
using AICT.SIMS.Domain.DomainEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Permissions;

namespace AICT.SIMS.Application.Business.UserManagement.Command
{
    public class AddRoleHandler : IRequestHandler<AddRoleHandlerInput, AddRoleHandlerOutput>
    {
        private readonly IDataBaseService _databaseService;
        private readonly ILogger<AddRoleHandler> _logger;
        private readonly RoleManager<Applicationrole> _rolemanager;
        public AddRoleHandler(ILogger<AddRoleHandler> logger, IDataBaseService databaseService, RoleManager<Applicationrole> rolemanager)
        {
            _logger = logger;
            _databaseService = databaseService;
            _rolemanager = rolemanager;
        }
        public async Task<AddRoleHandlerOutput> Handle(AddRoleHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling AddRole business logic");
            AddRoleHandlerOutput output = new AddRoleHandlerOutput(request.CorrelationId());

          
                var role = new Applicationrole { Name = request.RoleName ,Description=request.Descr};
                var result = await _rolemanager.CreateAsync(role);
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
