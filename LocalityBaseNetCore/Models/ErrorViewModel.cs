using System;

namespace LocalityBaseNetCore.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public string ErrorText { get; set;  }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}