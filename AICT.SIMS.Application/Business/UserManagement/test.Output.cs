using AICT.SIMS.Core.Messages;

namespace AICT.SIMS.Application.Business.UserManagement
{
    public class testHandlerOutput : BaseResponse
    {
        public testHandlerOutput() { }
        public testHandlerOutput(Guid correlationId) : base(correlationId) { }

    }
}
