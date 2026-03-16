using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AICT.SIMS.Domain.Entities1
{
    [Table("sms_order_status")]
    public partial class SmsOrderStatus
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = null!;

        [InverseProperty("OrderStatus")]
        public virtual ICollection<SmsOrder> SmsOrder { get; set; } = new List<SmsOrder>();
    }
}
