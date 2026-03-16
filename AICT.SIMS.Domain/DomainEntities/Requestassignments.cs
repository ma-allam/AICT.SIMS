using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AICT.SIMS.Domain.DomainEntities;

[Table("requestassignments")]
[Index("Requestid", "Userid", Name = "requestassignments_requestid_userid_key", IsUnique = true)]
public partial class Requestassignments
{
    [Key]
    [Column("assignmentid")]
    public int Assignmentid { get; set; }

    [Column("requestid")]
    public Guid Requestid { get; set; }

    [Column("userid")]
    public int Userid { get; set; }

    [Column("assignedbyuserid")]
    public int? Assignedbyuserid { get; set; }

    [Column("assignedat", TypeName = "timestamp without time zone")]
    public DateTime? Assignedat { get; set; }

    [ForeignKey("Assignedbyuserid")]
    [InverseProperty("RequestassignmentsAssignedbyuser")]
    public virtual Users? Assignedbyuser { get; set; }

    [ForeignKey("Requestid")]
    [InverseProperty("Requestassignments")]
    public virtual Imagerequests Request { get; set; } = null!;

    [ForeignKey("Userid")]
    [InverseProperty("RequestassignmentsUser")]
    public virtual Users User { get; set; } = null!;
}
