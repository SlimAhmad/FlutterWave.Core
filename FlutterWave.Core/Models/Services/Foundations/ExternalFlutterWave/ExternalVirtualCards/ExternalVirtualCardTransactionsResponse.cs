﻿using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualCards
{
    internal class ExternalVirtualCardTransactionsResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }
    }
}
