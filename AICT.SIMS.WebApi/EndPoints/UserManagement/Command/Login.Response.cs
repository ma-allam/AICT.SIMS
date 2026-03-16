using AICT.SIMS.Core.Auth.JWT;
using AICT.SIMS.Core.Messages;


namespace AICT.SIMS.WebApi.EndPoints.UserManagement.Command
{
    public class LoginEndPointResponse : BaseResponse
    {
        public LoginEndPointResponse() { }
        public LoginEndPointResponse(Guid correlationId) : base(correlationId) { }
        public TokenContext Context { get; set; }

    }
}
