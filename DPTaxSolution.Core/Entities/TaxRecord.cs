using DPTaxSolution.Core.Interfaces;
using DPTaxSolution.Core.Strategy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPTaxSolution.Core.Entities
{
    public class TaxRecord
    {
        
        public int Id { get; set; }

        public TaxCalculationType CalculationType { get; set; }

        public decimal Amount { get; set; }

        public decimal Tax { get; set; } 

        public  DateTime RecordDate { get; set; } = DateTime.Now;

        private ITaxCalculationStrategy _taxCalculationStrategy { get; set; }

        public void SetStrategy()
        {
            if(CalculationType == TaxCalculationType.Progressive)
                _taxCalculationStrategy = new ProgressiveTaxCalculationStrategy(); 
            
            if (CalculationType == TaxCalculationType.FixedRate)
                _taxCalculationStrategy = new FixedRateTaxCalculationStrategy(); 
            
            if (CalculationType == TaxCalculationType.FixedValue)
                _taxCalculationStrategy = new FixedValueTaxCalculationStrategy(); 
            
            Tax = _taxCalculationStrategy.CalculateTax(Amount);
        }

    }
}
