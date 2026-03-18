using AICT.SIMS.Application.Business.UserManagement.Command;
using AutoMapper;

namespace AICT.SIMS.WebApi.EndPoints.UserManagement.Command
{
    public class AddRoleMapper : Profile
    {
        public AddRoleMapper()
        {
            CreateMap<AddRoleEndPointRequest, AddRoleHandlerInput>()
                .ConstructUsing(src => new AddRoleHandlerInput(src.CorrelationId()));
            CreateMap<AddRoleHandlerOutput, AddRoleEndPointResponse>()
               .ConstructUsing(src => new AddRoleEndPointResponse(src.CorrelationId()));
        }

    }
}
