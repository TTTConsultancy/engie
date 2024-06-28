using Engie.Models;

namespace Engie.Algorithms
{
   public class GasFuelAlgorithm : IFuelAlgorithm
   {
      public decimal GenerateCostPerMwh(PayloadFuel payloadFuel, PayloadPowerplant payloadPowerplant)
      {
         if (payloadFuel != null && payloadPowerplant != null && payloadFuel.Gas != 0 && payloadPowerplant.Efficiency != 0)
         {
            return Math.Round(((decimal)payloadFuel.Gas) / (decimal)payloadPowerplant.Efficiency, 1);
         }
         else
         {
            return 0;
         }
      }
      public decimal GenerateMaximumOfMwh(decimal load, PayloadPowerplant payloadPowerplant)
      {
         if (payloadPowerplant != null)
         {

            if (load > payloadPowerplant.Pmax)
            {
               load = payloadPowerplant.Pmax;
            }
            else if (load < payloadPowerplant.Pmin)
            {
               load = payloadPowerplant.Pmin;
            }

            return load;

         }
         else
         {
            return 0;
         }
      }
   }
}
