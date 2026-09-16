using Newtonsoft.Json;
using System;

namespace FlutterWave.Core.Webhooks.Events
{
    public class TransferCompletedWebhookEventData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("bank_name")]
        public string BankName { get; set; }

        [JsonProperty("bank_code")]
        public string BankCode { get; set; }

        [JsonProperty("fullname")]
        public string Fullname { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("debit_currency")]
        public string DebitCurrency { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("fee")]
        public string Fee { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("meta")]
        public object Meta { get; set; }

        [JsonProperty("narration")]
        public string Narration { get; set; }

        [JsonProperty("approver")]
        public string Approver { get; set; }

        [JsonProperty("complete_message")]
        public string CompleteMessage { get; set; }

        [JsonProperty("requires_approval")]
        public int RequiresApproval { get; set; }

        [JsonProperty("is_approved")]
        public int IsApproved { get; set; }
    }
}
