using MediatR;
using AICT.SIMS.Core.Messages;
using System.ComponentModel.DataAnnotations;

namespace AICT.SIMS.Application.Business.UserManagement.Command
{
    public class LoginHandlerInput : BaseRequest, IRequest<LoginHandlerOutput>
    {
        public LoginHandlerInput() { }
        public LoginHandlerInput(Guid correlationId) : base(correlationId) { }
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
