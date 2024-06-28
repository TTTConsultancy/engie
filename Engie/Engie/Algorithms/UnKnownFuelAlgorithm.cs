using Engie.Models;

namespace Engie.Algorithms
{
   public class UnKnownFuelAlgorithm : IFuelAlgorithm
   {
      public decimal GenerateCostPerMwh(PayloadFuel payloadFuel, PayloadPowerplant payloadPowerplant)
      {
         return 0;
      }
      public decimal GenerateMaximumOfMwh(decimal load, PayloadPowerplant payloadPowerplant)
      {
         return 0;
      }
   }
}
