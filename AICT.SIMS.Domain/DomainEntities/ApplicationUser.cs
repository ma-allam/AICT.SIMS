using Microsoft.AspNetCore.Identity;

namespace AICT.SIMS.Domain.DomainEntities
{
    public partial class ApplicationUser : IdentityUser
    {
        public virtual Users User { get; set; } = null!;
    }
}
