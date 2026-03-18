using AICT.SIMS.Core.Messages;

namespace AICT.SIMS.Application.Business.UserManagement.Command
{
    public class AddRoleHandlerOutput : BaseResponse
    {
        public AddRoleHandlerOutput() { }
        public AddRoleHandlerOutput(Guid correlationId) : base(correlationId) { }

        public string Message { get;  set; }
    }
}
