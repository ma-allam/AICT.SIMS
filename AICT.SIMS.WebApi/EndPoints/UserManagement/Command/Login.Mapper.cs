using AICT.SIMS.Application.Business.UserManagement.Command;
using AutoMapper;

namespace AICT.SIMS.WebApi.EndPoints.UserManagement.Command
{
    public class LoginMapper : Profile
    {
        public LoginMapper()
        {
            CreateMap<LoginEndPointRequest, LoginHandlerInput>()
                .ConstructUsing(src => new LoginHandlerInput(src.CorrelationId()));
            CreateMap<LoginHandlerOutput, LoginEndPointResponse>()
               .ConstructUsing(src => new LoginEndPointResponse(src.CorrelationId()));
        }

    }
}
