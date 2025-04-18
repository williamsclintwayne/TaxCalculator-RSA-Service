namespace TaxCalculatorAPI.Services.Models
{
    public class TaxCertificateData
    {
        public string FullName { get; set; }
        public string TaxReferenceNumber { get; set; }
        public int TaxYear { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal AnnualBonus { get; set; }
        public decimal RetirementAnnuityContributions { get; set; }
        public decimal MedicalTaxCredits { get; set; }
        public decimal TaxableIncome { get; set; }
        public decimal TotalTaxPayable { get; set; }
        public decimal MonthlyTax { get; set; }
        public DateTime DateIssued { get; set; } = DateTime.UtcNow;
        public string IssuerName { get; set; } = "CLINT TaxApp";
        public string IssuerContact { get; set; } = "williammsclintwayne@gmail.com";
    }

}
