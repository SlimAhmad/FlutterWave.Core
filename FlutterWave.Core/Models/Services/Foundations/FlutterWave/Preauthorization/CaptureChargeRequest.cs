using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization
{
    public class CaptureChargeRequest
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
}
