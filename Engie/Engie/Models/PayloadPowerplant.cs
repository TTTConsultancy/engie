namespace Engie.Models
{
   public class PayloadPowerplant
   {
      public string Name { get; set; } = "";
      public string Type { get; set; } = "";
      public decimal Efficiency { get; set; } = decimal.Zero;
      public uint Pmin { get; set; } = uint.MinValue;
      public uint Pmax { get; set; } = uint.MinValue;
    }
}
