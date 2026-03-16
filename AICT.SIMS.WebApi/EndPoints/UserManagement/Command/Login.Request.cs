using AICT.SIMS.Core.Messages;
using System.ComponentModel.DataAnnotations;

namespace AICT.SIMS.WebApi.EndPoints.UserManagement.Command
{
    public class LoginEndPointRequest : BaseRequest
    {
        public const string Route = "/api/user/v{version:apiVersion}/Login/";

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
