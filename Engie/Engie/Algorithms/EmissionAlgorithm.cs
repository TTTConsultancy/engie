using Engie.Models;

namespace Engie.Algorithms
{
   public class EmissionAlgorithm : IEmissionAlgorithm
   {
      public decimal CalculateCarbonEmissionInTons(decimal powerInMwh, PayloadPowerplant payloadPowerplant)
      {
         decimal carbonEmissionInTons = decimal.Zero;

         if (payloadPowerplant.Type == "gasfired")
         {
            carbonEmissionInTons = Math.Round((decimal)powerInMwh * (decimal)0.3, 1);
         }

         return carbonEmissionInTons;
      }
   }
}
