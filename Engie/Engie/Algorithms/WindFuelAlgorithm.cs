using Engie.Models;

namespace Engie.Algorithms
{
   public class WindFuelAlgorithm : IFuelAlgorithm
   {
      public decimal GenerateCostPerMwh(PayloadFuel payloadFuel, PayloadPowerplant payloadPowerplant)
      {
         return 0;
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

            return Math.Round(((decimal)load / (decimal)payloadPowerplant.Efficiency), 1);
         }
         else
         {
            return 0;
         }
      }
   }
}
