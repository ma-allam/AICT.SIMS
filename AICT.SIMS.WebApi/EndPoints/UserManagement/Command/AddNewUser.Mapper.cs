using AICT.SIMS.Application.Business.UserManagement.Command;
using AutoMapper;

namespace AICT.SIMS.WebApi.EndPoints.UserManagement.Command
{
    public class AddNewUserMapper : Profile
    {
        public AddNewUserMapper()
        {
            CreateMap<AddNewUserEndPointRequest, AddNewUserHandlerInput>()
                .ConstructUsing(src => new AddNewUserHandlerInput(src.CorrelationId()));
            CreateMap<AddNewUserHandlerOutput, AddNewUserEndPointResponse>()
               .ConstructUsing(src => new AddNewUserEndPointResponse(src.CorrelationId()));
        }

    }
}
