﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts
{
    public class UpdateSubaccountResponse
    {

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public UpdateSubaccountData Data { get; set; }

        public class UpdateSubaccountData
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("account_number")]
            public string AccountNumber { get; set; }

            [JsonProperty("account_bank")]
            public string AccountBank { get; set; }

            [JsonProperty("business_name")]
            public string BusinessName { get; set; }

            [JsonProperty("full_name")]
            public string FullName { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("meta")]
            public List<Metum> Meta { get; set; }

            [JsonProperty("account_id")]
            public int AccountId { get; set; }

            [JsonProperty("split_ratio")]
            public int SplitRatio { get; set; }

            [JsonProperty("split_type")]
            public string SplitType { get; set; }

            [JsonProperty("split_value")]
            public double SplitValue { get; set; }

            [JsonProperty("subaccount_id")]
            public string SubaccountId { get; set; }

            [JsonProperty("bank_name")]
            public string BankName { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }
        }

        public class Metum
        {
            [JsonProperty("meta_name")]
            public string MetaName { get; set; }

            [JsonProperty("meta_value")]
            public string MetaValue { get; set; }
        }





    }
}
