﻿using Newtonsoft.Json;
using System;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge
{
    internal class ExternalTanzaniaMobileMoneyResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ExternalTanzaniaMobileMoneyData Data { get; set; }

        public class Customer
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("phone_number")]
            public string PhoneNumber { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }
        }

        public class ExternalTanzaniaMobileMoneyData
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("tx_ref")]
            public string TxRef { get; set; }

            [JsonProperty("flw_ref")]
            public string FlwRef { get; set; }

            [JsonProperty("device_fingerprint")]
            public string DeviceFingerprint { get; set; }

            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("charged_amount")]
            public int ChargedAmount { get; set; }

            [JsonProperty("app_fee")]
            public int AppFee { get; set; }

            [JsonProperty("merchant_fee")]
            public int MerchantFee { get; set; }

            [JsonProperty("processor_response")]
            public string ProcessorResponse { get; set; }

            [JsonProperty("auth_model")]
            public string AuthModel { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("ip")]
            public string Ip { get; set; }

            [JsonProperty("narration")]
            public string Narration { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("payment_type")]
            public string PaymentType { get; set; }

            [JsonProperty("fraud_status")]
            public string FraudStatus { get; set; }

            [JsonProperty("charge_type")]
            public string ChargeType { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("account_id")]
            public int AccountId { get; set; }

            [JsonProperty("customer")]
            public Customer Customer { get; set; }
        }






    }
}
