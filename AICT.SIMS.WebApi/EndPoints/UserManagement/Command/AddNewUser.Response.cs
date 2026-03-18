using AICT.SIMS.Core.Messages;


namespace AICT.SIMS.WebApi.EndPoints.UserManagement.Command
{
    public class AddNewUserEndPointResponse : BaseResponse
    {
        public AddNewUserEndPointResponse() { }
        public AddNewUserEndPointResponse(Guid correlationId) : base(correlationId) { }
        public string Message { get; set; }

    }
}
