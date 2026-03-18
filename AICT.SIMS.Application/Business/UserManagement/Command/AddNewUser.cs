using AICT.SIMS.Application.Contract;
using AICT.SIMS.Core.Auth.User;
using AICT.SIMS.Domain.DomainEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AICT.SIMS.Application.Business.UserManagement.Command
{
    public class AddNewUserHandler : IRequestHandler<AddNewUserHandlerInput, AddNewUserHandlerOutput>
    {
        private readonly IDataBaseService _databaseService;
        private readonly ILogger<AddNewUserHandler> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public AddNewUserHandler(ILogger<AddNewUserHandler> logger, IDataBaseService databaseService, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _databaseService = databaseService;
            _userManager = userManager;
        }
        public async Task<AddNewUserHandlerOutput> Handle(AddNewUserHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling AddNewUser business logic");
            AddNewUserHandlerOutput output = new AddNewUserHandlerOutput(request.CorrelationId());
            using (var transaction = await _databaseService.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    var user = new ApplicationUser
                    {
                        UserName = request.Username,
                        Email = request.Email,
                    };

                    var result = await _userManager.CreateAsync(user, request.Password);

                    if (!result.Succeeded)
                    {
                        throw new Exception("User creation failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                    }

                    var User = new Users
                    {
                        Fullname = user.UserName,
                        Email = user.Email,
                        AppUserId = user.Id,
                        Isadmin = request.IsAdminUser,
                    };

                    _databaseService.Users.Add(User);
                    await _databaseService.DBSaveChangesAsync(cancellationToken);

                    await transaction.CommitAsync(cancellationToken);
                    output.Message = "User added successfully";

                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    _logger.LogError(ex, "Error occurred during user Add");
                    throw;
                }
            }

            return output;
        }
    }
}
