namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions
{
    public class FetchTransactionFeesResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public FetchTransactionFeesDataModel Data { get; set; }

        public class FetchTransactionFeesDataModel
        {
            public decimal ChargeAmount { get; set; }
            public decimal Fee { get; set; }
            public decimal MerchantFee { get; set; }
            public decimal FlutterwaveFee { get; set; }
            public decimal StampDutyFee { get; set; }
            public string Currency { get; set; }
        }





    }
}
