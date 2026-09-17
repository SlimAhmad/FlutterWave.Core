namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments
{
    public class ValidateBillServiceResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Datum Data { get; set; }

        public class Datum
        {

            public string ResponseCode { get; set; }
            public object Address { get; set; }
            public string ResponseMessage { get; set; }
            public string Name { get; set; }
            public string BillerCode { get; set; }
            public string Customer { get; set; }
            public string ProductCode { get; set; }
            public object Email { get; set; }
            public decimal Fee { get; set; }
            public decimal Maximum { get; set; }
            public decimal Minimum { get; set; }
        }

    }
}
