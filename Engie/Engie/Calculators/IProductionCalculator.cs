using Engie.Models;

namespace Engie.Calculators
{
   public interface IProductionCalculator
   {
      List<ProductionResponse> CalculateProductionForEachPowerplant(Payload payload);
   }
}