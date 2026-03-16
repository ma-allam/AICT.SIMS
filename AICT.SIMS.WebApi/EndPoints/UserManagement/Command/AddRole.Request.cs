using AICT.SIMS.Core.Messages;
using System.ComponentModel.DataAnnotations;

namespace AICT.SIMS.WebApi.EndPoints.UserManagement.Command
{
    public class AddRoleEndPointRequest : BaseRequest
    {
        public const string Route = "/api/user/v{version:apiVersion}/AddRole/";

        [Required]
        public string RoleName { get; set; }
    }
}
