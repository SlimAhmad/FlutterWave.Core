using Newtonsoft.Json;
using System;

namespace FlutterWave.Core.Webhooks.Events
{
    public class ChargeCompletedWebhookEventData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("tx_ref")]
        public string TxRef { get; set; }

        [JsonProperty("flw_ref")]
        public string FlwRef { get; set; }

        [JsonProperty("device_fingerprint")]
        public string DeviceFingerprint { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("charged_amount")]
        public decimal ChargedAmount { get; set; }

        [JsonProperty("app_fee")]
        public decimal AppFee { get; set; }

        [JsonProperty("merchant_fee")]
        public decimal MerchantFee { get; set; }

        [JsonProperty("processor_response")]
        public string ProcessorResponse { get; set; }

        [JsonProperty("auth_model")]
        public string AuthModel { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("narration")]
        public string Narration { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("payment_type")]
        public string PaymentType { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("customer")]
        public ChargeCompletedCustomer Customer { get; set; }

        [JsonProperty("card")]
        public ChargeCompletedCard Card { get; set; }

        public class ChargeCompletedCustomer
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("phone_number")]
            public string PhoneNumber { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }
        }

        public class ChargeCompletedCard
        {
            [JsonProperty("first_6digits")]
            public string First6digits { get; set; }

            [JsonProperty("last_4digits")]
            public string Last4digits { get; set; }

            [JsonProperty("issuer")]
            public string Issuer { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("expiry")]
            public string Expiry { get; set; }
        }
    }
}
