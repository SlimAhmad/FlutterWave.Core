using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions
{
    public class FailedTransactionsServiceException : Xeption
    {
        public FailedTransactionsServiceException(Exception innerException)
            : base(message: "Failed Transactions service error occurred, contact support.",
                  innerException)
        { }

        public FailedTransactionsServiceException(string message, Exception innerException)
           : base(message, innerException)
        { }
    }
}