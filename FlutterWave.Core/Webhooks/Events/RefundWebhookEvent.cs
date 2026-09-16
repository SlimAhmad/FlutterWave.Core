using Newtonsoft.Json;
using System;

namespace FlutterWave.Core.Webhooks.Events
{
    public class RefundWebhookEvent
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("AmountRefunded")]
        public decimal AmountRefunded { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("FlwRef")]
        public string FlwRef { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }

        [JsonProperty("settlement_id")]
        public string SettlementId { get; set; }

        [JsonProperty("meta")]
        public string Meta { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("deletedAt")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("walletId")]
        public long WalletId { get; set; }

        [JsonProperty("AccountId")]
        public long AccountId { get; set; }

        [JsonProperty("TransactionId")]
        public long TransactionId { get; set; }
    }
}
