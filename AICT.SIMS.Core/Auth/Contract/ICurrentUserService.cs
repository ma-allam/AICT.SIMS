using AICT.SIMS.Core.Auth.User;

namespace AICT.SIMS.Core.Auth.Contract
{
    public interface ICurrentUserService
    {
        void Load();
        ActiveContext activeContext { get; set; }



    }
}
