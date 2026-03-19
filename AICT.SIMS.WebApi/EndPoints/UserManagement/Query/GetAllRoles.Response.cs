using AICT.SIMS.Application.Business.UserManagement.Query;
using AICT.SIMS.Core.Messages;


namespace AICT.SIMS.WebApi.EndPoints.UserManagement.Query
{
    public class GetAllRolesEndPointResponse : BaseResponse
    {
        public GetAllRolesEndPointResponse() { }
        public GetAllRolesEndPointResponse(Guid correlationId) : base(correlationId) { }
        public List<Roleitem> Roles { get; set; }

    }
}
