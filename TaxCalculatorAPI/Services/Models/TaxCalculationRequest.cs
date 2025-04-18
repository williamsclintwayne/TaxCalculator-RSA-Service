using System.ComponentModel.DataAnnotations;

namespace TaxCalculatorAPI.Services.Models
{
    public class TaxCalculationRequest
    {
        [Required]
        [Range(0, double.MaxValue)]
        public decimal MonthlySalary { get; set; }

        [Range(0, double.MaxValue)]
        public decimal AnnualBonus { get; set; }

        [Range(0, 3500)]
        public decimal MedicalTaxCredits { get; set; }

        [Range(2020, 2100)]
        public int TaxYear { get; set; } = 2025;
    }
}
