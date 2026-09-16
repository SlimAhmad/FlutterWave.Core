using Newtonsoft.Json;

namespace FlutterWave.Core.Webhooks
{
    public class WebhookEvent<TData>
    {
        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("event.type")]
        public string EventType { get; set; }

        [JsonProperty("data")]
        public TData Data { get; set; }
    }
}
