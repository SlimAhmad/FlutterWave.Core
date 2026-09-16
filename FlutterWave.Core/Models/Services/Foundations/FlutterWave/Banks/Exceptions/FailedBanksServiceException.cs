using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks
{
    public class FailedBanksServiceException : Xeption
    {
        public FailedBanksServiceException(Exception innerException)
            : base(message: "Failed Banks service error occurred, contact support.",
                  innerException)
        { }

        public FailedBanksServiceException(string message, Exception innerException)
          : base(message: message,
                innerException)
        { }
    }
}