using System;
using System.Net;

namespace OpenAISharp.Client.Exceptions
{
    /// <summary>
    /// Generic exception throw from calls made to OpenAI API via the OpenAIClient.
    /// </summary>
    public class OpenAIClientException : Exception
    {
        /// <summary>
        /// The HTTP status code returned from the request.
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// The almighty OpenAIClientExceptionconstructor.
        /// </summary>
        /// <param name="httpStatusCode">The HTTP status code returned from the request.</param>
        /// <param name="message">The respone object from an unsuccesful request as a string.</param>
        public OpenAIClientException(HttpStatusCode httpStatusCode, string message) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
