using AICT.SIMS.Core.Messages;
using System.ComponentModel.DataAnnotations;

namespace AICT.SIMS.WebApi.EndPoints.UserManagement.Command
{
    public class AddNewUserEndPointRequest : BaseRequest
    {
        public const string Route = "/api/user/v{version:apiVersion}/AddNewUser/";


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
