using Newtonsoft.Json;
using System;

namespace FlutterWave.Core.Webhooks.Events
{
    public class SubscriptionCancelledWebhookEventData
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("customer")]
        public SubscriptionCancelledCustomer Customer { get; set; }

        [JsonProperty("plan")]
        public SubscriptionCancelledPlan Plan { get; set; }

        public class SubscriptionCancelledCustomer
        {
            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("full_name")]
            public string FullName { get; set; }
        }

        public class SubscriptionCancelledPlan
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("amount")]
            public decimal Amount { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("interval")]
            public string Interval { get; set; }

            [JsonProperty("duration")]
            public int Duration { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("date_created")]
            public DateTime DateCreated { get; set; }
        }
    }
}
