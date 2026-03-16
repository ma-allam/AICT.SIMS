using AICT.SIMS.Domain.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AICT.SIMS.Application.Contract
{
    public interface IDataBaseService
    {
        public  DbSet<Entities> Entities { get; set; }

        public  DbSet<Imagerequests> Imagerequests { get; set; }

        public  DbSet<Operationslog> Operationslog { get; set; }

        public  DbSet<Requestassignments> Requestassignments { get; set; }

        public  DbSet<Requesttargets> Requesttargets { get; set; }

        public  DbSet<Roles> Roles { get; set; }

        public  DbSet<Satellites> Satellites { get; set; }

        public  DbSet<Users> Users { get; set; }

        //public  DbSet<SmsTargets> SmsTargets { get; set; }

        public DbSet<SysParam> SysParam { get; set; }
        int DBSaveChanges();
        Task<int> DBSaveChangesAsync(CancellationToken cancellationToken = default);
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);


    }

}
