using DPTaxSolution.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace DPTaxSolution.Core.DTO
{
    public class TaxCalculationRequest
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a non-negative value.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "CalculationType is required.")]
        public TaxCalculationType CalculationType { get; set; }
    }

}
