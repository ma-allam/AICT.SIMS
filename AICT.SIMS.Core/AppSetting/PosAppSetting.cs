using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICT.SIMS.Core.AppSetting
{
    public class PosAppSetting
    {
        public static string SectionName { get; set; } = "pos";
        public string? ConnectionString { get; set; }
    }
}
