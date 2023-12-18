using DPTaxSolution.Core.Entities;
using DPTaxSolution.Core.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPTaxSolution.Core.Interfaces
{
    public interface ITaxCalculatorService
    {
        decimal CalculateTax(decimal amount);
    }
}
