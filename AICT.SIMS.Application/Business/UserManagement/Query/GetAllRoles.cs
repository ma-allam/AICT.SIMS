using AICT.SIMS.Application.Contract;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AICT.SIMS.Application.Business.UserManagement.Query
{
    public class GetAllRolesHandler : IRequestHandler<GetAllRolesHandlerInput, GetAllRolesHandlerOutput>
    {
        private readonly IDataBaseService _databaseService;
        private readonly ILogger<GetAllRolesHandler> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;

        public GetAllRolesHandler(ILogger<GetAllRolesHandler> logger, IDataBaseService databaseService, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _databaseService = databaseService;
            _roleManager = roleManager;
        }
        public async Task<GetAllRolesHandlerOutput> Handle(GetAllRolesHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling GetAllRoles business logic");
            GetAllRolesHandlerOutput output = new GetAllRolesHandlerOutput(request.CorrelationId());
            output.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync(cancellationToken);
            return output;
        }
    }
}
