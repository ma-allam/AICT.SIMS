using AICT.SIMS.Application.Contract;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AICT.SIMS.Application.Business.UserManagement
{
    public class testHandler : IRequestHandler<testHandlerInput, testHandlerOutput>
    {
        private readonly IDataBaseService _databaseService;
        private readonly ILogger<testHandler> _logger;
        public testHandler(ILogger<testHandler> logger, IDataBaseService databaseService)
        {
            _logger = logger;
            _databaseService = databaseService;
        }
        public async Task<testHandlerOutput> Handle(testHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling test business logic");
            testHandlerOutput output = new testHandlerOutput(request.CorrelationId());
            await Task.CompletedTask;
            return output;
        }
    }
}
