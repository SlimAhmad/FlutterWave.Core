﻿using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge
{
    internal class ExternalUgandaMobileMoneyRequest
    {
        [JsonProperty("tx_ref")]
        public string TxRef { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("voucher")]
        public int Voucher { get; set; }

        [JsonProperty("network")]
        public string Network { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("fullname")]
        public string Fullname { get; set; }

        [JsonProperty("client_ip")]
        public string ClientIp { get; set; }

        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }

        [JsonProperty("device_fingerprint")]
        public string DeviceFingerprint { get; set; }

        [JsonProperty("meta")]
        public ExternalUgandaMobileMoneyMeta Meta { get; set; }

        public class ExternalUgandaMobileMoneyMeta
        {
            [JsonProperty("flightID")]
            public string FlightID { get; set; }

            [JsonProperty("sideNote")]
            public string SideNote { get; set; }
        }






    }
}
