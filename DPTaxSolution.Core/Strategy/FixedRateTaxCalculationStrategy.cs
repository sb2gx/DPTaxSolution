using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPTaxSolution.Core.Interfaces;

namespace DPTaxSolution.Core.Strategy
{
    public class FixedRateTaxCalculationStrategy : ITaxCalculationStrategy
    {
        private const decimal rate = 0.175M;

        public decimal CalculateTax(decimal amount)
        {
            return amount * rate;
        }
    }

}
