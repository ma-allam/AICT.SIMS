using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AICT.SIMS.Domain.DomainEntities;

[Table("users")]
[Index("Email", Name = "users_email_key", IsUnique = true)]
public partial class Users
{
    [Key]
    [Column("userid")]
    public int Userid { get; set; }

    [Column("fullname")]
    [StringLength(200)]
    public string Fullname { get; set; } = null!;

    [Column("email")]
    [StringLength(200)]
    public string Email { get; set; } = null!;

    [Column("roleid")]
    public int? Roleid { get; set; }

    [Column("isadmin")]
    public bool? Isadmin { get; set; }

    [Column("parentuserid")]
    public int? Parentuserid { get; set; }

    [Column("isactive")]
    public bool? Isactive { get; set; }

    [Column("createdat", TypeName = "timestamp without time zone")]
    public DateTime? Createdat { get; set; }

    [InverseProperty("Createdbyuser")]
    public virtual ICollection<Imagerequests> Imagerequests { get; set; } = new List<Imagerequests>();

    [InverseProperty("Parentuser")]
    public virtual ICollection<Users> InverseParentuser { get; set; } = new List<Users>();

    [InverseProperty("Performedbyuser")]
    public virtual ICollection<Operationslog> Operationslog { get; set; } = new List<Operationslog>();

    [ForeignKey("Parentuserid")]
    [InverseProperty("InverseParentuser")]
    public virtual Users? Parentuser { get; set; }

    [InverseProperty("Assignedbyuser")]
    public virtual ICollection<Requestassignments> RequestassignmentsAssignedbyuser { get; set; } = new List<Requestassignments>();

    [InverseProperty("User")]
    public virtual ICollection<Requestassignments> RequestassignmentsUser { get; set; } = new List<Requestassignments>();

    [ForeignKey("Roleid")]
    [InverseProperty("Users")]
    public virtual Roles? Role { get; set; }
}
