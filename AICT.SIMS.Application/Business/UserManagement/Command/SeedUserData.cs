using AICT.SIMS.Application.Contract;
using AICT.SIMS.Domain.DomainEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace AICT.SIMS.Application.Business.UserManagement.Command
{
    public class SeedUserDataHandler : IRequestHandler<SeedUserDataHandlerInput, SeedUserDataHandlerOutput>
    {
        private readonly IDataBaseService _databaseService;
        private readonly ILogger<SeedUserDataHandler> _logger;
        public SeedUserDataHandler(ILogger<SeedUserDataHandler> logger, IDataBaseService databaseService)
        {
            _logger = logger;
            _databaseService = databaseService;
        }
        public async Task<SeedUserDataHandlerOutput> Handle(SeedUserDataHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling SeedUserData business logic");
            SeedUserDataHandlerOutput output = new SeedUserDataHandlerOutput(request.CorrelationId());
            // 1. Check if Roles already exist
            if (!await _databaseService.Roles.AnyAsync(cancellationToken))
            {
                var roles = new List<Roles>
                {
                    new Roles {Rolename  = "Planning" },
                    new Roles { Rolename = "Processing" },
                    new Roles { Rolename = "Management" }
                };
                await _databaseService.Roles.AddRangeAsync(roles);
                await _databaseService.DBSaveChangesAsync(cancellationToken);
            }

            // 2. Check if Admins already exist
            if (!await _databaseService.Users.AnyAsync(u => u.Isadmin, cancellationToken))
            {
                var planningRole = await _databaseService.Roles.FirstAsync(r => r.Rolename == "Planning");
                var processingRole = await _databaseService.Roles.FirstAsync(r => r.Rolename == "Processing");
                var managementRole = await _databaseService.Roles.FirstAsync(r => r.Rolename == "Management");

                var initialAdmins = new List<Users>
                {
                    //new Users { Fullname = "Planning Admin", Email = "planning.admin@sims.com", Roleid = planningRole.Roleid, Isadmin = true },
                    //new Users { Fullname = "Processing Admin", Email = "processing.admin@sims.com", Roleid = processingRole.Roleid, Isadmin = true },
                    //new Users { Fullname = "Management Director", Email = "mgmt.admin@sims.com", Roleid = managementRole.Roleid, Isadmin = true }
                };

                await _databaseService.Users.AddRangeAsync(initialAdmins);
                await _databaseService.DBSaveChangesAsync(cancellationToken);
                output.Message = "Seeding completed successfully.";
            }
            else
            {
                output.Message = "Database already contains seed data.";
            }

            return output;
        }
    }
}
