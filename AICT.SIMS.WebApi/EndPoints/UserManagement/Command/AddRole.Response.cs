using AICT.SIMS.Core.Messages;


namespace AICT.SIMS.WebApi.EndPoints.UserManagement.Command
{
    public class AddRoleEndPointResponse : BaseResponse
    {
        public AddRoleEndPointResponse() { }
        public AddRoleEndPointResponse(Guid correlationId) : base(correlationId) { }
        public string Message { get; set; }

    }
}
