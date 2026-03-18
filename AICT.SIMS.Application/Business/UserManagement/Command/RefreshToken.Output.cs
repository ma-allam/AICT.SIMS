using AICT.SIMS.Core.Auth.JWT;
using AICT.SIMS.Core.Messages;

namespace AICT.SIMS.Application.Business.UserManagement.Command
{
    public class RefreshTokenHandlerOutput : BaseResponse
    {
        public RefreshTokenHandlerOutput() { }
        public RefreshTokenHandlerOutput(Guid correlationId) : base(correlationId) { }
        public TokenContext Context { get; set; }
    }
}
