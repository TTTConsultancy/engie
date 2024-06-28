namespace Engie.Models
{
   public class Payload
   {
      public decimal Load { get; set; } = decimal.Zero;
      public PayloadFuel Fuels { get; set; } = new();
      public List<PayloadPowerplant> Powerplants { get; set; } = new();
   }
}
