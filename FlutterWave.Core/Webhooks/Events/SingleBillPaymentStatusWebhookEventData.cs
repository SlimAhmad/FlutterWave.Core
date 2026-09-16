using Newtonsoft.Json;

namespace FlutterWave.Core.Webhooks.Events
{
    public class SingleBillPaymentStatusWebhookEventData
    {
        [JsonProperty("customer")]
        public string Customer { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("network")]
        public string Network { get; set; }

        [JsonProperty("tx_ref")]
        public string TxRef { get; set; }

        [JsonProperty("flw_ref")]
        public string FlwRef { get; set; }

        [JsonProperty("batch_reference")]
        public string BatchReference { get; set; }

        [JsonProperty("customer_reference")]
        public string CustomerReference { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }
    }
}
