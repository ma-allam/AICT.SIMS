using AICT.SIMS.Core.Messages;

namespace AICT.SIMS.Application.Business.UserManagement.Query
{
    public class GetAllRolesHandlerOutput : BaseResponse
    {
        public GetAllRolesHandlerOutput() { }
        public GetAllRolesHandlerOutput(Guid correlationId) : base(correlationId) { }

    }
}
