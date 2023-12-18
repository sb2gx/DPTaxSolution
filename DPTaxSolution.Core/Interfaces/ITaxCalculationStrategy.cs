using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPTaxSolution.Core.Interfaces
{
    public interface ITaxCalculationStrategy
    {
        decimal CalculateTax(decimal amount);
    }
}
