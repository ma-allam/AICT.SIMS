using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace AICT.SIMS.Domain.DomainEntities;

[Table("requesttargets")]
public partial class Requesttargets
{
    [Key]
    [Column("targetid")]
    public int Targetid { get; set; }

    [Column("requestid")]
    public Guid Requestid { get; set; }

    [Column("targetlabel")]
    [StringLength(100)]
    public string? Targetlabel { get; set; }

    [Column("targetgeometry", TypeName = "geometry(Geometry,4326)")]
    public Geometry Targetgeometry { get; set; } = null!;

    [Column("iscaptured")]
    public bool? Iscaptured { get; set; }

    [Column("capturedate", TypeName = "timestamp without time zone")]
    public DateTime? Capturedate { get; set; }

    [ForeignKey("Requestid")]
    [InverseProperty("Requesttargets")]
    public virtual Imagerequests Request { get; set; } = null!;
}
