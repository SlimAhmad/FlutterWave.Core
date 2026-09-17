using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPreauthorization
{
    internal class ExternalCaptureChargeRequest
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
}
