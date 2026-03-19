using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICT.SIMS.Domain.DomainEntities
{

    public class Applicationrole : IdentityRole
    {
        public string Description { get; set; }

        public Applicationrole() : base() { }

        public Applicationrole(string Rolename) : base(Rolename) { }

        public Applicationrole(string Rolename, string Description) : base(Rolename)
        {
            this.Description = Description;
        }
    }

}
