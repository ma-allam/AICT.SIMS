using AICT.SIMS.Application.Contract;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AICT.SIMS.Application.Business.UserManagement
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersHandlerInput, GetAllUsersHandlerOutput>
    {
        private readonly IDataBaseService _databaseService;
        private readonly ILogger<GetAllUsersHandler> _logger;
        public GetAllUsersHandler(ILogger<GetAllUsersHandler> logger, IDataBaseService databaseService)
        {
            _logger = logger;
            _databaseService = databaseService;
        }
        public async Task<GetAllUsersHandlerOutput> Handle(GetAllUsersHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling GetAllUsers business logic");
            GetAllUsersHandlerOutput output = new GetAllUsersHandlerOutput(request.CorrelationId());
            output.username=(await _databaseService.Users.FirstOrDefaultAsync(cancellationToken)).Fullname;
            return output;
        }
    }
}
