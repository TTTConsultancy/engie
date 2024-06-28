using Engie.Algorithms;
using Engie.Models;

namespace Engie.Factories
{
   public class AlgorithmFactory
   {
      public IFuelAlgorithm GetAlgorithm(PayloadPowerplant payloadPowerplant)
      {
         switch (payloadPowerplant.Type)
         {
            case "gasfired":
               return new GasFuelAlgorithm();
            case "turbojet":
               return new KerosineFuelAlgorithm();
            case "windturbine":
               return new WindFuelAlgorithm();
            default:
               return new UnKnownFuelAlgorithm();
         }
      }
   }
}
