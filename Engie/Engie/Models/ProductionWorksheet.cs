namespace Engie.Models
{
   public class ProductionWorksheet
   {
      public string Name { get; set; } = "";
      public decimal P { get; set; } = decimal.Zero;

      public decimal LoadReceiving { get; set; } = decimal.Zero;
      public decimal LoadProviding { get; set; } = decimal.Zero;
      public decimal LoadRemaining { get; set; } = decimal.Zero;

      public bool IsSwitchedOn { get; set; } = false;

      public decimal CostPerMwh = decimal.Zero;
      public decimal CostOfLoad = decimal.Zero;
      public decimal CarbonEmissionInKilogramTons = decimal.Zero;

      public PayloadPowerplant payloadPowerplant { get; set; } = new();
   }
}
