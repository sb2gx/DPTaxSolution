using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DPTaxSolution.Core.Entities
{
    public enum TaxCalculationType
    {
        [Description("Fixed Rate")]
        FixedRate,
        [Description("Fixed Value")]
        FixedValue,
        [Description("Progessive")]
        Progressive
    }
}
