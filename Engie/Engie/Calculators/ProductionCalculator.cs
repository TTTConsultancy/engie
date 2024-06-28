using Engie.Algorithms;
using Engie.Factories;
using Engie.Models;

namespace Engie.Calculators
{
   public class ProductionCalculator : IProductionCalculator
   {

      public ProductionCalculator() { }

      public List<ProductionResponse> CalculateProductionForEachPowerplant(Payload payload)
      {
         List<ProductionResponse> productionResponse = new();

         try
         {
            AlgorithmFactory factory = new();

            List<ProductionWorksheet> worksheets = CalculateCostPerMwh(factory, payload);
            worksheets = OrderByCostPerMwh(worksheets);
            worksheets = CalculateLoad(factory, payload, worksheets);
            
            // To-Do - Calculate Emissions for Gas

            productionResponse = PublishResponse(worksheets);
         }
         catch
         {
            // Report to Team
         }

         return productionResponse;
      }

      // Methods
      private static List<ProductionWorksheet> CalculateCostPerMwh(AlgorithmFactory factory, Payload payload)
      {
         List<ProductionWorksheet> worksheets = new();

         foreach (PayloadPowerplant payloadPowerplant in payload.Powerplants)
         {
            IFuelAlgorithm algorithm = factory.GetAlgorithm(payloadPowerplant);

            ProductionWorksheet worksheet = new()
            {
               Name = payloadPowerplant.Name,
               CostPerMwh = algorithm.GenerateCostPerMwh(payload.Fuels, payloadPowerplant),
               payloadPowerplant = payloadPowerplant
            };

            worksheets.Add(worksheet);
         }

         return worksheets;
      }
      private static List<ProductionWorksheet> OrderByCostPerMwh(List<ProductionWorksheet> worksheets)
      {
         if (worksheets != null && worksheets.Count > 0)
         {
            List<ProductionWorksheet> orderedWorksheets = worksheets.OrderBy(w => w.CostPerMwh).ToList();
            return orderedWorksheets;
         }
         else
         {
            return worksheets;
         }
      }
      private List<ProductionWorksheet> CalculateLoad(AlgorithmFactory factory, Payload payload, List<ProductionWorksheet> worksheets)
      {
         decimal load = payload.Load;

         foreach (ProductionWorksheet worksheet in worksheets)
         {
            IFuelAlgorithm algorithm = factory.GetAlgorithm(worksheet.payloadPowerplant);
            
            if (load > 0)
            {
               worksheet.IsSwitchedOn = true;

               worksheet.LoadReceiving = load;
               worksheet.LoadProviding = algorithm.GenerateMaximumOfMwh(load, worksheet.payloadPowerplant);
               worksheet.LoadRemaining = worksheet.LoadReceiving - worksheet.LoadProviding;

               worksheet.P = worksheet.LoadProviding;

               worksheet.CostOfLoad = GenerateCostOfLoad(worksheet.LoadProviding, worksheet.CostPerMwh);

               if (worksheet.LoadRemaining < 0) { worksheet.LoadRemaining = 0; }
               load = worksheet.LoadRemaining;
            }
         }

         return worksheets;
      }
      private static List<ProductionResponse> PublishResponse(List<ProductionWorksheet> worksheets)
      {
         List<ProductionResponse> productionResponses = new();

         if (worksheets != null && worksheets.Count > 0)
         {
            foreach (ProductionWorksheet worksheet in worksheets)
            {
               ProductionResponse productionResponse = new()
               {
                  Name = worksheet.Name,
                  P = worksheet.P
               };

               productionResponses.Add(productionResponse);
            }
         }

         return productionResponses;
      }
      
      // Helpers
      private decimal GenerateCostOfLoad(decimal load, decimal costPerMwh)
      {
         if (load > 0 && costPerMwh > 0)
         {
            return Math.Round((decimal)load * (decimal)costPerMwh, 2);
         }
         else
         {
            return 0;
         }
      }

   }
}
