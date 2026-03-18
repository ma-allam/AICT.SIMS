using MediatR;
using AICT.SIMS.Core.Messages;

namespace AICT.SIMS.Application.Business.UserManagement.Command
{
    public class RefreshTokenHandlerInput : BaseRequest, IRequest<RefreshTokenHandlerOutput>
    {
        public RefreshTokenHandlerInput() { }
        public RefreshTokenHandlerInput(Guid correlationId) : base(correlationId) { }
        public string? Token { get; set; }

    }
}
