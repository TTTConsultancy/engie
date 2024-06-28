using Engie.Models;

namespace Engie.Algorithms
{
   public interface IEmissionAlgorithm
   {
      decimal CalculateCarbonEmissionInTons(decimal powerInMwh, PayloadPowerplant payloadPowerplant);
   }
}