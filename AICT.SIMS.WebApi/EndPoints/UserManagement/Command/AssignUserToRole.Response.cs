using AICT.SIMS.Core.Messages;


namespace AICT.SIMS.WebApi.EndPoints.UserManagement.Command
{
    public class AssignUserToRoleEndPointResponse : BaseResponse
    {
        public AssignUserToRoleEndPointResponse() { }
        public AssignUserToRoleEndPointResponse(Guid correlationId) : base(correlationId) { }
        public string Message { get; set; }

    }
}
