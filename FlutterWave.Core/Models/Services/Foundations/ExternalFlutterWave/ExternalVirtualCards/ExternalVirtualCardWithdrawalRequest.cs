using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualCards
{
    internal class ExternalVirtualCardWithdrawalRequest
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
}
