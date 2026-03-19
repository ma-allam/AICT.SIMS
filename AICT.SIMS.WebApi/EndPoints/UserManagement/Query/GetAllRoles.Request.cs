using AICT.SIMS.Core.Messages;

namespace AICT.SIMS.WebApi.EndPoints.UserManagement.Query
{
    public class GetAllRolesEndPointRequest : BaseRequest
    {
        public const string Route = "/api/user/v{version:apiVersion}/GetAllRoles/";

    }
}
