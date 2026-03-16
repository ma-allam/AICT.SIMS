using AICT.SIMS.Core.Messages;
using System.ComponentModel.DataAnnotations;

namespace AICT.SIMS.WebApi.EndPoints.UserManagement.Command
{
    public class AssignUserToRoleEndPointRequest : BaseRequest
    {
        public const string Route = "/api/user/v{version:apiVersion}/AssignUserToRole/";

        [Required]
        public string Username { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
