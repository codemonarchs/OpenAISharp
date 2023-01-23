using System;
using System.Net;

namespace OpenAISharp.Exceptions
{
    public class OpenAIClientException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public OpenAIClientException(HttpStatusCode httpStatusCode, string message) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
