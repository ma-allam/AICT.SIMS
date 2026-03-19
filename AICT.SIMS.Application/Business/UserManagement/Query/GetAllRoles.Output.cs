using AICT.SIMS.Core.Messages;

namespace AICT.SIMS.Application.Business.UserManagement.Query
{
    public class GetAllRolesHandlerOutput : BaseResponse
    {
        public GetAllRolesHandlerOutput() { }
        public GetAllRolesHandlerOutput(Guid correlationId) : base(correlationId) { }
        public List<Roleitem>  Roles { get; set; }
    }
    public class Roleitem
    {
        public string Roleid { get; set; }
        public string Rolename { get; set; }
        public string Description { get; set; }
    }
}
