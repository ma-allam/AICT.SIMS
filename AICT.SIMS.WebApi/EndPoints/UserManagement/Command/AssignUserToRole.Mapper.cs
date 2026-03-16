using AICT.SIMS.Application.Business.UserManagement.Command;
using AutoMapper;

namespace AICT.SIMS.WebApi.EndPoints.UserManagement.Command
{
    public class AssignUserToRoleMapper : Profile
    {
        public AssignUserToRoleMapper()
        {
            CreateMap<AssignUserToRoleEndPointRequest, AssignUserToRoleHandlerInput>()
                .ConstructUsing(src => new AssignUserToRoleHandlerInput(src.CorrelationId()));
            CreateMap<AssignUserToRoleHandlerOutput, AssignUserToRoleEndPointResponse>()
               .ConstructUsing(src => new AssignUserToRoleEndPointResponse(src.CorrelationId()));
        }

    }
}
