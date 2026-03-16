using AICT.SIMS.Core.Messages;
using MediatR;

namespace AICT.SIMS.Application.Business.UserManagement
{
    public class GetAllUsersHandlerInput : BaseRequest, IRequest<GetAllUsersHandlerOutput>
    {
        public GetAllUsersHandlerInput() { }
        public GetAllUsersHandlerInput(Guid correlationId) : base(correlationId) { }
    }
}
