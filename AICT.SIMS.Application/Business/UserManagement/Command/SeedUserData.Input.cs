using AICT.SIMS.Core.Messages;
using MediatR;

namespace AICT.SIMS.Application.Business.UserManagement.Command
{
    public class SeedUserDataHandlerInput : BaseRequest, IRequest<SeedUserDataHandlerOutput>
    {
        public SeedUserDataHandlerInput() { }
        public SeedUserDataHandlerInput(Guid correlationId) : base(correlationId) { }
    }
}
