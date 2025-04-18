namespace TaxCalculatorAPI.Services.Models
{
    public class TaxCalculationResult
    {
        public decimal AnnualTaxableIncome { get; set; }
        public decimal AnnualTax { get; set; }
        public decimal MonthlyTax { get; set; }
    }
}
