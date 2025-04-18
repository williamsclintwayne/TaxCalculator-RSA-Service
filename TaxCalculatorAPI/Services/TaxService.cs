using TaxCalculatorAPI.Services.Models;

namespace TaxCalculatorAPI.Services
{
    public class TaxService
    {
        public decimal CalculateAnnualTax(decimal annualIncome, int taxYear)
        {
            if (!TaxConstants.TaxBracketsByYear.TryGetValue(taxYear, out var brackets))
                throw new ArgumentException("Unsupported tax year");

            decimal tax = 0;
            foreach (var bracket in brackets)
            {
                if (annualIncome <= bracket.MinIncome)
                    break;

                var taxableInBracket = Math.Min(annualIncome, bracket.MaxIncome) - bracket.MinIncome;
                tax += taxableInBracket * bracket.Rate;
            }
            return tax;
        }

        public decimal ApplyMedicalCredits(decimal taxAmount, int taxYear, decimal monthlyCredits)
        {
            var maxCredit = TaxConstants.MedicalCreditsByYear.ContainsKey(taxYear) ? TaxConstants.MedicalCreditsByYear[taxYear] : 0;
            var annualCredit = Math.Min(monthlyCredits, maxCredit) * 12;
            return taxAmount - annualCredit;
        }
    }

}
