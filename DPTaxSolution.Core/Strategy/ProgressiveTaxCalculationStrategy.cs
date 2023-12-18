using DPTaxSolution.Core.Interfaces;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPTaxSolution.Core.Strategy
{
    public class ProgressiveTaxCalculationStrategy : ITaxCalculationStrategy
    {
        static class Constants
        {
            public const decimal FIRST_BAND_UPPER = 8350;
            public const decimal SECOND_BAND_UPPER = 33950;
            public const decimal THIRD_BAND_UPPER = 82250;
            public const decimal FOURTH_BAND_UPPER = 171550;
            public const decimal FIFTH_BAND_UPPER = 372950;
            public const decimal LAST_BAND = 372951;

            public const decimal FIRST_BAND_RATE = 0.10M;
            public const decimal SECOND_BAND_RATE = 0.15M;
            public const decimal THIRD_BAND_RATE = 0.25M;
            public const decimal FOURTH_BAND_RATE = 0.28M;
            public const decimal FIFTH_BAND_RATE = 0.33M;
            public const decimal LAST_RATE = 0.35M;
        }

        public static decimal calculatedTax = 0;

        public decimal CalculateTax(decimal amount)
        {
            if (amount <= Constants.FIRST_BAND_UPPER)
            {
                calculatedTax += amount * Constants.FIRST_BAND_RATE;
            }
            
            if(amount > Constants.FIRST_BAND_UPPER && amount <= Constants.SECOND_BAND_UPPER)
            {
                calculatedTax += (amount - Constants.FIRST_BAND_UPPER + 1) * Constants.SECOND_BAND_RATE;
            }

            if (amount > Constants.SECOND_BAND_UPPER)
            {
                calculatedTax += (Constants.SECOND_BAND_UPPER - Constants.FIRST_BAND_UPPER + 1) * Constants.SECOND_BAND_RATE;
            }

            if (amount > Constants.SECOND_BAND_UPPER && amount <= Constants.THIRD_BAND_UPPER)
            {
                calculatedTax += (amount - Constants.SECOND_BAND_UPPER + 1) * Constants.SECOND_BAND_RATE;
            }

            if (amount > Constants.THIRD_BAND_UPPER)
            {
                calculatedTax += (Constants.THIRD_BAND_UPPER - Constants.SECOND_BAND_UPPER + 1) * Constants.SECOND_BAND_RATE;
            }

            if (amount > Constants.THIRD_BAND_UPPER && amount <= Constants.FOURTH_BAND_UPPER)
            {
                calculatedTax += (amount - Constants.THIRD_BAND_UPPER + 1) * Constants.THIRD_BAND_RATE;
            }

            if (amount > Constants.FOURTH_BAND_UPPER)
            {
                calculatedTax += (Constants.FOURTH_BAND_UPPER - Constants.THIRD_BAND_UPPER + 1) * Constants.THIRD_BAND_RATE;
            }

            if (amount > Constants.FOURTH_BAND_UPPER && amount <= Constants.FIFTH_BAND_UPPER)
            {
                calculatedTax += (amount - Constants.FOURTH_BAND_UPPER) * Constants.FIFTH_BAND_RATE;
            }

            if (amount > Constants.FIFTH_BAND_UPPER)
            {
                calculatedTax += (Constants.FIFTH_BAND_UPPER - Constants.FOURTH_BAND_UPPER) * Constants.FIFTH_BAND_RATE;
            }

            if (amount > Constants.LAST_BAND)
            {
                calculatedTax += (amount - Constants.LAST_BAND) * Constants.LAST_RATE;
            }

            return calculatedTax;
        }
    }
}
