using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AICT.SIMS.Domain.DomainEntities;

[Table("imagerequests")]
[Index("Status", Name = "idx_req_status")]
public partial class Imagerequests
{
    [Key]
    [Column("requestid")]
    public Guid Requestid { get; set; }

    [Column("mainentityid")]
    public int Mainentityid { get; set; }

    [Column("subentityid")]
    public int Subentityid { get; set; }

    [Column("createdbyuserid")]
    public int Createdbyuserid { get; set; }

    [Column("requestformimage")]
    public byte[]? Requestformimage { get; set; }

    [Column("requestformfilename")]
    [StringLength(255)]
    public string? Requestformfilename { get; set; }

    [Column("priority")]
    public int? Priority { get; set; }

    [Column("status")]
    [StringLength(30)]
    public string? Status { get; set; }

    [Column("feasibilitydetails", TypeName = "jsonb")]
    public string? Feasibilitydetails { get; set; }

    [Column("completionpercentage")]
    [Precision(5, 2)]
    public decimal? Completionpercentage { get; set; }

    [Column("createdat", TypeName = "timestamp without time zone")]
    public DateTime? Createdat { get; set; }

    [Column("updatedat", TypeName = "timestamp without time zone")]
    public DateTime? Updatedat { get; set; }

    [ForeignKey("Createdbyuserid")]
    [InverseProperty("Imagerequests")]
    public virtual Users Createdbyuser { get; set; } = null!;

    [ForeignKey("Mainentityid")]
    [InverseProperty("ImagerequestsMainentity")]
    public virtual Entities Mainentity { get; set; } = null!;

    [InverseProperty("Request")]
    public virtual ICollection<Operationslog> Operationslog { get; set; } = new List<Operationslog>();

    [InverseProperty("Request")]
    public virtual ICollection<Requestassignments> Requestassignments { get; set; } = new List<Requestassignments>();

    [InverseProperty("Request")]
    public virtual ICollection<Requesttargets> Requesttargets { get; set; } = new List<Requesttargets>();

    [ForeignKey("Subentityid")]
    [InverseProperty("ImagerequestsSubentity")]
    public virtual Entities Subentity { get; set; } = null!;
}
