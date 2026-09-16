using Newtonsoft.Json;

namespace FlutterWave.Core.Webhooks.Events
{
    public class VirtualCardDebitWebhookEvent
    {
        [JsonProperty("TransactionId")]
        public string TransactionId { get; set; }

        [JsonProperty("MerchantName")]
        public string MerchantName { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("Balance")]
        public decimal Balance { get; set; }

        [JsonProperty("Amount")]
        public decimal Amount { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("CardId")]
        public string CardId { get; set; }

        [JsonProperty("MaskedPan")]
        public string MaskedPan { get; set; }
    }
}
