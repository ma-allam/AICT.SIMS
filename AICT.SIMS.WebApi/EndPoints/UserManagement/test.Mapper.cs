
using AICT.SIMS.Application.Business.UserManagement;
using AutoMapper;

namespace AICT.SIMS.WebApi.EndPoints.UserManagement
{
    public class testMapper : Profile
    {
        public testMapper()
        {
            CreateMap<testEndPointRequest, testHandlerInput>()
                .ConstructUsing(src => new testHandlerInput(src.CorrelationId()));
            CreateMap<testHandlerOutput, testEndPointResponse>()
               .ConstructUsing(src => new testEndPointResponse(src.CorrelationId()));
        }

    }
}
