using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AICT.SIMS.Domain.Entities1
{
    [Table("client_type")]
    public partial class ClientType
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("type")]
        public string Type { get; set; } = null!;

        [InverseProperty("ClientTypeNavigation")]
        public virtual ICollection<Client> Client { get; set; } = new List<Client>();
    }
}
