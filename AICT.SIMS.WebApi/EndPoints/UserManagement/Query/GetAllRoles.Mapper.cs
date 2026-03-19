
using AICT.SIMS.Application.Business.UserManagement.Query;
using AutoMapper;

namespace AICT.SIMS.WebApi.EndPoints.UserManagement.Query
{
    public class GetAllRolesMapper : Profile
    {
        public GetAllRolesMapper()
        {
            CreateMap<GetAllRolesEndPointRequest, GetAllRolesHandlerInput>()
                .ConstructUsing(src => new GetAllRolesHandlerInput(src.CorrelationId()));
            CreateMap<GetAllRolesHandlerOutput, GetAllRolesEndPointResponse>()
               .ConstructUsing(src => new GetAllRolesEndPointResponse(src.CorrelationId()));
        }

    }
}
