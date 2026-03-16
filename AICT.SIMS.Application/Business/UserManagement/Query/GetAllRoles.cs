using AICT.SIMS.Application.Contract;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AICT.SIMS.Application.Business.UserManagement.Query
{
    public class GetAllRolesHandler : IRequestHandler<GetAllRolesHandlerInput, GetAllRolesHandlerOutput>
    {
        private readonly IDataBaseService _databaseService;
        private readonly ILogger<GetAllRolesHandler> _logger;
        public GetAllRolesHandler(ILogger<GetAllRolesHandler> logger, IDataBaseService databaseService)
        {
            _logger = logger;
            _databaseService = databaseService;
        }
        public async Task<GetAllRolesHandlerOutput> Handle(GetAllRolesHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling GetAllRoles business logic");
            GetAllRolesHandlerOutput output = new GetAllRolesHandlerOutput(request.CorrelationId());
            await Task.CompletedTask;
            return output;
        }
    }
}
