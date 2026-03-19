using AICT.SIMS.Application.Contract;
using AICT.SIMS.Domain.DomainEntities;
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
        private readonly RoleManager<Applicationrole> _rolemanager;
        public GetAllRolesHandler(ILogger<GetAllRolesHandler> logger, IDataBaseService databaseService, RoleManager<Applicationrole> rolemanager)
        {
            _logger = logger;
            _databaseService = databaseService;
            _rolemanager = rolemanager;
        }
        public async Task<GetAllRolesHandlerOutput> Handle(GetAllRolesHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling GetAllRoles business logic");
            GetAllRolesHandlerOutput output = new GetAllRolesHandlerOutput(request.CorrelationId());
            output.Roles = await _rolemanager.Roles.Select(r =>
            new Roleitem
            {
                Roleid = r.Id,
                Rolename = r.Name,
                Description = r.Description
            }).ToListAsync(cancellationToken);
            return output;
        }
    }
}
