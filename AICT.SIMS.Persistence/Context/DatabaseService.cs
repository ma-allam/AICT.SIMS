using AICT.SIMS.Application.Contract;
using AICT.SIMS.Domain.DomainEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AICT.SIMS.Persistence.Context;

public partial class DatabaseService : IdentityDbContext<ApplicationUser>, IDataBaseService
{
    public DatabaseService()
    {
    }

    public DatabaseService(DbContextOptions<DatabaseService> options)
        : base(options)
    {
        Database.EnsureCreated();

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>()
            .HasOne(a => a.User)
            .WithOne(c => c.AppUser)
            .HasForeignKey<Users>(c => c.AppUserId)
            .OnDelete(DeleteBehavior.Cascade); // Or another delete behavior as appropriate

    }
    public virtual DbSet<Entities> Entities { get; set; }

    public virtual DbSet<Imagerequests> Imagerequests { get; set; }

    public virtual DbSet<Operationslog> Operationslog { get; set; }

    public virtual DbSet<Requestassignments> Requestassignments { get; set; }

    public virtual DbSet<Requesttargets> Requesttargets { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Satellites> Satellites { get; set; }

    public virtual DbSet<Users> Users { get; set; }
    public DbSet<SysParam> SysParam { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=AICT;Username=postgres;Password=p@ssw0rd", x => x.UseNetTopologySuite());

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.HasPostgresExtension("postgis");

    //    modelBuilder.Entity<Entities>(entity =>
    //    {
    //        entity.HasKey(e => e.Entityid).HasName("entities_pkey");

    //        entity.Property(e => e.Entityid).UseIdentityAlwaysColumn();
    //        entity.Property(e => e.Createdat).HasDefaultValueSql("CURRENT_TIMESTAMP");

    //        entity.HasOne(d => d.Parententity).WithMany(p => p.InverseParententity).HasConstraintName("entities_parententityid_fkey");
    //    });

    //    modelBuilder.Entity<Imagerequests>(entity =>
    //    {
    //        entity.HasKey(e => e.Requestid).HasName("imagerequests_pkey");

    //        entity.Property(e => e.Requestid).HasDefaultValueSql("gen_random_uuid()");
    //        entity.Property(e => e.Completionpercentage).HasDefaultValueSql("0.00");
    //        entity.Property(e => e.Createdat).HasDefaultValueSql("CURRENT_TIMESTAMP");
    //        entity.Property(e => e.Priority).HasDefaultValue(1);
    //        entity.Property(e => e.Status).HasDefaultValueSql("'New'::character varying");
    //        entity.Property(e => e.Updatedat).HasDefaultValueSql("CURRENT_TIMESTAMP");

    //        entity.HasOne(d => d.Createdbyuser).WithMany(p => p.Imagerequests)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("imagerequests_createdbyuserid_fkey");

    //        entity.HasOne(d => d.Mainentity).WithMany(p => p.ImagerequestsMainentity)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("imagerequests_mainentityid_fkey");

    //        entity.HasOne(d => d.Subentity).WithMany(p => p.ImagerequestsSubentity)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("imagerequests_subentityid_fkey");
    //    });

    //    modelBuilder.Entity<Operationslog>(entity =>
    //    {
    //        entity.HasKey(e => e.Logid).HasName("operationslog_pkey");

    //        entity.Property(e => e.Logid).UseIdentityAlwaysColumn();
    //        entity.Property(e => e.Logtimestamp).HasDefaultValueSql("CURRENT_TIMESTAMP");

    //        entity.HasOne(d => d.Performedbyuser).WithMany(p => p.Operationslog).HasConstraintName("operationslog_performedbyuserid_fkey");

    //        entity.HasOne(d => d.Request).WithMany(p => p.Operationslog)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("operationslog_requestid_fkey");
    //    });

    //    modelBuilder.Entity<Requestassignments>(entity =>
    //    {
    //        entity.HasKey(e => e.Assignmentid).HasName("requestassignments_pkey");

    //        entity.Property(e => e.Assignmentid).UseIdentityAlwaysColumn();
    //        entity.Property(e => e.Assignedat).HasDefaultValueSql("CURRENT_TIMESTAMP");

    //        entity.HasOne(d => d.Assignedbyuser).WithMany(p => p.RequestassignmentsAssignedbyuser).HasConstraintName("requestassignments_assignedbyuserid_fkey");

    //        entity.HasOne(d => d.Request).WithMany(p => p.Requestassignments).HasConstraintName("requestassignments_requestid_fkey");

    //        entity.HasOne(d => d.User).WithMany(p => p.RequestassignmentsUser)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("requestassignments_userid_fkey");
    //    });

    //    modelBuilder.Entity<Requesttargets>(entity =>
    //    {
    //        entity.HasKey(e => e.Targetid).HasName("requesttargets_pkey");

    //        entity.HasIndex(e => e.Targetgeometry, "idx_rt_spatial").HasMethod("gist");

    //        entity.Property(e => e.Targetid).UseIdentityAlwaysColumn();
    //        entity.Property(e => e.Iscaptured).HasDefaultValue(false);

    //        entity.HasOne(d => d.Request).WithMany(p => p.Requesttargets).HasConstraintName("requesttargets_requestid_fkey");
    //    });

    //    modelBuilder.Entity<Roles>(entity =>
    //    {
    //        entity.HasKey(e => e.Roleid).HasName("roles_pkey");

    //        entity.Property(e => e.Roleid).UseIdentityAlwaysColumn();
    //    });

    //    modelBuilder.Entity<Satellites>(entity =>
    //    {
    //        entity.HasKey(e => e.Satelliteid).HasName("satellites_pkey");

    //        entity.Property(e => e.Satelliteid).UseIdentityAlwaysColumn();
    //        entity.Property(e => e.Lastupdate).HasDefaultValueSql("CURRENT_TIMESTAMP");
    //        entity.Property(e => e.Swathwidthkm).HasDefaultValueSql("20.0");
    //    });

    //    modelBuilder.Entity<Users>(entity =>
    //    {
    //        entity.HasKey(e => e.Userid).HasName("users_pkey");

    //        entity.Property(e => e.Userid).UseIdentityAlwaysColumn();
    //        entity.Property(e => e.Createdat).HasDefaultValueSql("CURRENT_TIMESTAMP");
    //        entity.Property(e => e.Isactive).HasDefaultValue(true);
    //        entity.Property(e => e.Isadmin).HasDefaultValue(false);

    //        entity.HasOne(d => d.Parentuser).WithMany(p => p.InverseParentuser).HasConstraintName("users_parentuserid_fkey");

    //        entity.HasOne(d => d.Role).WithMany(p => p.Users).HasConstraintName("users_roleid_fkey");
    //    });

    //    OnModelCreatingPartial(modelBuilder);
    //}

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
