using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AICT.SIMS.Domain.Entities1
{
    [Table("currency")]
    public partial class Currency
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("currency_name")]
        public string CurrencyName { get; set; } = null!;

        [InverseProperty("Currency")]
        public virtual ICollection<Contracts> Contracts { get; set; } = new List<Contracts>();
    }
}
