using AICT.SIMS.Core.Messages;

namespace AICT.SIMS.Application.Business.UserManagement.Command
{
    public class AddNewUserHandlerOutput : BaseResponse
    {
        public AddNewUserHandlerOutput() { }
        public AddNewUserHandlerOutput(Guid correlationId) : base(correlationId) { }

        public string Message { get;  set; }
    }
}
