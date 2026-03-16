using AICT.SIMS.Core.Messages;
using MediatR;

namespace AICT.SIMS.Application.Business.UserManagement
{
    public class testHandlerInput : BaseRequest, IRequest<testHandlerOutput>
    {
        public testHandlerInput() { }
        public testHandlerInput(Guid correlationId) : base(correlationId) { }
    }
}
