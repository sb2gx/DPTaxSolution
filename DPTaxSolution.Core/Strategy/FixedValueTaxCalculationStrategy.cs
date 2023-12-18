using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPTaxSolution.Core.Interfaces;

namespace DPTaxSolution.Core.Strategy
{
    public class FixedValueTaxCalculationStrategy : ITaxCalculationStrategy
    {
        private readonly decimal maxValue = 200000;
        private const decimal fixedValue = 10000;
        private const decimal fixedValueRate = 0.05M;

        public decimal CalculateTax(decimal amount)
        {
            if (amount < maxValue) return amount * fixedValueRate;
            else return fixedValue;
        }
    }

}
