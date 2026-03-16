using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AICT.SIMS.Domain.Entities1
{
    public partial class SysParam
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        public string ParamName { get; set; } = null!;

        public bool ParamValue { get; set; }
    }
}
