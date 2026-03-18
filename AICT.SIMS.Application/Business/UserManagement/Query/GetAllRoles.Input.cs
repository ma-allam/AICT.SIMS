using AICT.SIMS.Core.Messages;
using MediatR;

namespace AICT.SIMS.Application.Business.UserManagement.Query
{
    public class GetAllRolesHandlerInput : BaseRequest, IRequest<GetAllRolesHandlerOutput>
    {
        public GetAllRolesHandlerInput() { }
        public GetAllRolesHandlerInput(Guid correlationId) : base(correlationId) { }
    }
}
