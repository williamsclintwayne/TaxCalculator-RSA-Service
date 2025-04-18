using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxCalculatorAPI.Services.Models;
using TaxCalculatorAPI.Services;

namespace TaxCalculatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxCalculatorController : ControllerBase
    {
        private readonly TaxService _taxService;

        public TaxCalculatorController()
        {
            _taxService = new TaxService();
        }

        [HttpPost("calculate")]
        public ActionResult<TaxCalculationResult> CalculateTax([FromBody] TaxCalculationRequest request)
        {
            var annualIncome = request.MonthlySalary * 12 + request.AnnualBonus;
            var taxBeforeCredits = _taxService.CalculateAnnualTax(annualIncome, request.TaxYear);
            var taxAfterCredits = _taxService.ApplyMedicalCredits(taxBeforeCredits, request.TaxYear, request.MedicalTaxCredits);

            var result = new TaxCalculationResult
            {
                AnnualTaxableIncome = annualIncome,
                AnnualTax = Math.Max(0, taxAfterCredits),
                MonthlyTax = Math.Max(0, taxAfterCredits) / 12
            };

            return Ok(result);
        }
    }
}
