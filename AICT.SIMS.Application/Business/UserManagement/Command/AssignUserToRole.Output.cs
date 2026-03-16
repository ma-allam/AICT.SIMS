using AICT.SIMS.Core.Messages;

namespace AICT.SIMS.Application.Business.UserManagement.Command
{
    public class AssignUserToRoleHandlerOutput : BaseResponse
    {
        public AssignUserToRoleHandlerOutput() { }
        public AssignUserToRoleHandlerOutput(Guid correlationId) : base(correlationId) { }
        public string Message { get; set; }

    }
}
