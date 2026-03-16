
using AICT.SIMS.Application.Business.UserManagement;
using AutoMapper;

namespace AICT.SIMS.WebApi.EndPoints.UserManagement
{
    public class GetAllUsersMapper : Profile
    {
        public GetAllUsersMapper()
        {
            CreateMap<GetAllUsersEndPointRequest, GetAllUsersHandlerInput>()
                .ConstructUsing(src => new GetAllUsersHandlerInput(src.CorrelationId()));
            CreateMap<GetAllUsersHandlerOutput, GetAllUsersEndPointResponse>()
               .ConstructUsing(src => new GetAllUsersEndPointResponse(src.CorrelationId()));
        }

    }
}
