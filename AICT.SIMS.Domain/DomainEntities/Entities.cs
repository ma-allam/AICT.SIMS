using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AICT.SIMS.Domain.DomainEntities;

[Table("entities")]
public partial class Entities
{
    [Key]
    [Column("entityid")]
    public int Entityid { get; set; }

    [Column("entityname")]
    [StringLength(200)]
    public string Entityname { get; set; } = null!;

    [Column("parententityid")]
    public int? Parententityid { get; set; }

    [Column("createdat", TypeName = "timestamp without time zone")]
    public DateTime? Createdat { get; set; }

    [InverseProperty("Mainentity")]
    public virtual ICollection<Imagerequests> ImagerequestsMainentity { get; set; } = new List<Imagerequests>();

    [InverseProperty("Subentity")]
    public virtual ICollection<Imagerequests> ImagerequestsSubentity { get; set; } = new List<Imagerequests>();

    [InverseProperty("Parententity")]
    public virtual ICollection<Entities> InverseParententity { get; set; } = new List<Entities>();

    [ForeignKey("Parententityid")]
    [InverseProperty("InverseParententity")]
    public virtual Entities? Parententity { get; set; }
}
