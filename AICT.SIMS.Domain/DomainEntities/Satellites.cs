using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AICT.SIMS.Domain.DomainEntities;

[Table("satellites")]
[Index("Noradid", Name = "satellites_noradid_key", IsUnique = true)]
public partial class Satellites
{
    [Key]
    [Column("satelliteid")]
    public int Satelliteid { get; set; }

    [Column("satellitename")]
    [StringLength(100)]
    public string Satellitename { get; set; } = null!;

    [Column("noradid")]
    public int? Noradid { get; set; }

    [Column("swathwidthkm")]
    public double Swathwidthkm { get; set; }

    [Column("tleline1")]
    public string? Tleline1 { get; set; }

    [Column("tleline2")]
    public string? Tleline2 { get; set; }

    [Column("lastupdate", TypeName = "timestamp without time zone")]
    public DateTime? Lastupdate { get; set; }
}
