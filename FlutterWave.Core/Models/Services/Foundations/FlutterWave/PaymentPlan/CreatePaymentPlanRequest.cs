namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan
{
    public class CreatePaymentPlanRequest
    {

        public decimal Amount { get; set; }
        public string Name { get; set; }
        public string Interval { get; set; }
        public int Duration { get; set; }

    }
}
