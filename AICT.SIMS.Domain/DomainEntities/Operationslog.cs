using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AICT.SIMS.Domain.DomainEntities;

[Table("operationslog")]
public partial class Operationslog
{
    [Key]
    [Column("logid")]
    public long Logid { get; set; }

    [Column("requestid")]
    public Guid Requestid { get; set; }

    [Column("actiontaken")]
    [StringLength(100)]
    public string? Actiontaken { get; set; }

    [Column("performedbyuserid")]
    public int? Performedbyuserid { get; set; }

    [Column("logtimestamp", TypeName = "timestamp without time zone")]
    public DateTime? Logtimestamp { get; set; }

    [Column("details")]
    public string? Details { get; set; }

    [ForeignKey("Performedbyuserid")]
    [InverseProperty("Operationslog")]
    public virtual Users? Performedbyuser { get; set; }

    [ForeignKey("Requestid")]
    [InverseProperty("Operationslog")]
    public virtual Imagerequests Request { get; set; } = null!;
}
