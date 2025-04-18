namespace TaxCalculatorAPI.Services.Models
{
    public record TaxBracket(decimal MinIncome, decimal MaxIncome, decimal Rate);

    public static class TaxConstants
    {
        public static readonly Dictionary<int, List<TaxBracket>> TaxBracketsByYear = new()
    {
        {
            2025, new List<TaxBracket>
            {
                new(0, 237_100, 0.18m),
                new(237_101, 370_500, 0.26m),
                new(370_501, 512_800, 0.31m),
                new(512_801, 673_000, 0.36m),
                new(673_001, 857_900, 0.39m),
                new(857_901, 1_817_000, 0.41m),
                new(1_817_001, decimal.MaxValue, 0.45m)
            }
        }
    };

        public static readonly Dictionary<int, decimal> MedicalCreditsByYear = new()
    {
        { 2025, 3500m }
    };
    }

}
