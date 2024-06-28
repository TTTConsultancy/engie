using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Engie.Models
{
   public class PayloadFuel
   {
      [Display(Name = "gas(euro/Mwh)")]
      [JsonProperty("gas(euro/Mwh)")]
      public decimal Gas { get; set; } = decimal.Zero;
      [Display(Name = "kerosine(euro/Mwh)")]
      [JsonProperty("kerosine(euro/Mwh)")]
      public decimal Kerosine { get; set; } = decimal.Zero;
      [Display(Name = "c02(euro/ton)")]
      [JsonProperty("c02(euro/ton)")]
      public decimal Co2 { get; set; } = decimal.Zero;
      [Display(Name = "wind(%)")]
      [JsonProperty("wind(%)")]
      public decimal Wind { get; set; } = decimal.Zero;
    }
}
