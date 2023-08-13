﻿using System;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers
{
    public class RetryTransferResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Datum Data { get; set; }
        public class Datum
        {
            public int Id { get; set; }
            public string AccountNumber { get; set; }
            public string BankCode { get; set; }
            public string FullName { get; set; }
            public DateTime CreatedAt { get; set; }
            public string Currency { get; set; }
            public string DebitCurrency { get; set; }
            public int Amount { get; set; }
            public double Fee { get; set; }
            public string Status { get; set; }
            public string Reference { get; set; }
            public object Meta { get; set; }
            public string CompleteMessage { get; set; }
            public int RequiresApproval { get; set; }
            public int IsApproved { get; set; }
            public string BankName { get; set; }
        }
    }
}
