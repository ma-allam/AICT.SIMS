using AICT.SIMS.Core.Messages;

namespace AICT.SIMS.WebApi.EndPoints.UserManagement
{
    public class GetAllUsersEndPointRequest : BaseRequest
    {
        public const string Route = "/api/v{version:apiVersion}/GetAllUsers/";
    }
}
