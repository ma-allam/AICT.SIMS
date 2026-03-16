using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AICT.SIMS.Domain.Entities1
{
    public partial class ApplicationUser : IdentityUser
    {
        public virtual Client Client { get; set; } = null!;
    }
}
