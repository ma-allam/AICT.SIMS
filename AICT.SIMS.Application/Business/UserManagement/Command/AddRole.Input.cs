using MediatR;
using AICT.SIMS.Core.Messages;
using System.ComponentModel.DataAnnotations;

namespace AICT.SIMS.Application.Business.UserManagement.Command
{
    public class AddRoleHandlerInput : BaseRequest, IRequest<AddRoleHandlerOutput>
    {
        public AddRoleHandlerInput() { }
        public AddRoleHandlerInput(Guid correlationId) : base(correlationId) { }
        [Required]
        public string RoleName { get; set; }
        [Required]
        public string Descr { get; set; }
    }
}
