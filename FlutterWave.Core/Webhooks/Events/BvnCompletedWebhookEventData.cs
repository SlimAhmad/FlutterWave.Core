using Newtonsoft.Json;
using System;

namespace FlutterWave.Core.Webhooks.Events
{
    public class BvnCompletedWebhookEventData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("callback_url")]
        public string CallbackUrl { get; set; }

        [JsonProperty("AccountId")]
        public long AccountId { get; set; }

        [JsonProperty("bvn_data")]
        public BvnCompletedBvnData BvnData { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("deletedAt")]
        public DateTime? DeletedAt { get; set; }

        public class BvnCompletedBvnData
        {
            [JsonProperty("dateOfBirth")]
            public string DateOfBirth { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("enrollUserName")]
            public string EnrollUserName { get; set; }

            [JsonProperty("firstName")]
            public string FirstName { get; set; }

            [JsonProperty("gender")]
            public string Gender { get; set; }

            [JsonProperty("lgaOfOrigin")]
            public string LgaOfOrigin { get; set; }

            [JsonProperty("lgaOfResidence")]
            public string LgaOfResidence { get; set; }

            [JsonProperty("maritalStatus")]
            public string MaritalStatus { get; set; }

            [JsonProperty("middleName")]
            public string MiddleName { get; set; }

            [JsonProperty("nin")]
            public string Nin { get; set; }

            [JsonProperty("phoneNumber1")]
            public string PhoneNumber1 { get; set; }

            [JsonProperty("phoneNumber2")]
            public string PhoneNumber2 { get; set; }

            [JsonProperty("productReference")]
            public string ProductReference { get; set; }

            [JsonProperty("stateOfCapture")]
            public string StateOfCapture { get; set; }

            [JsonProperty("stateOfOrigin")]
            public string StateOfOrigin { get; set; }

            [JsonProperty("stateOfResidence")]
            public string StateOfResidence { get; set; }

            [JsonProperty("surname")]
            public string Surname { get; set; }

            [JsonProperty("watchlisted")]
            public string Watchlisted { get; set; }
        }
    }
}
