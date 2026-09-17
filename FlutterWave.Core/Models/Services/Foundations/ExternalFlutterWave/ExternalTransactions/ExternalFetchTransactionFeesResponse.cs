using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransactions
{
    internal class ExternalFetchTransactionFeesResponse
    {


        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ExternalFetchTransactionFeesDataModel Data { get; set; }

        internal class ExternalFetchTransactionFeesDataModel
        {
            [JsonProperty("charge_amount")]
            public decimal ChargeAmount { get; set; }

            [JsonProperty("fee")]
            public decimal Fee { get; set; }

            [JsonProperty("merchant_fee")]
            public decimal MerchantFee { get; set; }

            [JsonProperty("flutterwave_fee")]
            public decimal FlutterwaveFee { get; set; }

            [JsonProperty("stamp_duty_fee")]
            public decimal StampDutyFee { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }
        }





    }
}
