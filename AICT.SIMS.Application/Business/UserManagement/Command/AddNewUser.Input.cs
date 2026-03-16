using AICT.SIMS.Core.Messages;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AICT.SIMS.Application.Business.UserManagement.Command
{
    public class AddNewUserHandlerInput : BaseRequest, IRequest<AddNewUserHandlerOutput>
    {
        public AddNewUserHandlerInput() { }
        public AddNewUserHandlerInput(Guid correlationId) : base(correlationId) { }
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public bool IsAdminUser { get; set; } = false;

    }
}
