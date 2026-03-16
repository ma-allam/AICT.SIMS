using AICT.SIMS.Core.Messages;


namespace AICT.SIMS.WebApi.EndPoints.UserManagement
{
    public class GetAllUsersEndPointResponse : BaseResponse
    {
        public GetAllUsersEndPointResponse() { }
        public GetAllUsersEndPointResponse(Guid correlationId) : base(correlationId) { }
        public string username { get; set; }

    }
}
