using Engie.Calculators;
using Engie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Engie.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class ProductionPlanController : ControllerBase
   {

      private readonly IProductionCalculator _productionCalculator;
      private readonly IWebHostEnvironment _environment;
      public ProductionPlanController(IProductionCalculator productionCalculator, IWebHostEnvironment environment)
      {
         _productionCalculator = productionCalculator;
         _environment = environment;
      }

      [HttpGet]
      [AllowAnonymous]
      public IActionResult Get()
      {

         var serverPath = _environment.WebRootPath + "\\" + "request.json";
         StreamReader reader = new(serverPath);
         var json = reader.ReadToEnd();
         Payload view = JsonConvert.DeserializeObject<Payload>(json);

         return Ok(_productionCalculator.CalculateProductionForEachPowerplant(view));

      }

      [HttpPost]
      [AllowAnonymous]
      public List<ProductionResponse> ProductionPlan([FromBody] Payload view)
      {
         return _productionCalculator.CalculateProductionForEachPowerplant(view);
      }

   }
}
