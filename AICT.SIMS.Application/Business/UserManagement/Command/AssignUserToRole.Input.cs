using AICT.SIMS.Core.Messages;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AICT.SIMS.Application.Business.UserManagement.Command
{
    public class AssignUserToRoleHandlerInput : BaseRequest, IRequest<AssignUserToRoleHandlerOutput>
    {
        public AssignUserToRoleHandlerInput() { }
        public AssignUserToRoleHandlerInput(Guid correlationId) : base(correlationId) { }
        [Required]
        public string Username { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
