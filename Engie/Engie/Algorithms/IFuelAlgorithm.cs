using Engie.Models;

namespace Engie.Algorithms
{
   public interface IFuelAlgorithm
   {
      decimal GenerateCostPerMwh(PayloadFuel payloadFuel, PayloadPowerplant payloadPowerplant);
      decimal GenerateMaximumOfMwh(decimal load, PayloadPowerplant payloadPowerplant);
   }
}
