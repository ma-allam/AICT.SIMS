using AICT.SIMS.Core.Messages;

namespace AICT.SIMS.Application.Business.UserManagement
{
    public class GetAllUsersHandlerOutput : BaseResponse
    {
        public GetAllUsersHandlerOutput() { }
        public GetAllUsersHandlerOutput(Guid correlationId) : base(correlationId) { }
        public string username { get; set; }
    }
}
