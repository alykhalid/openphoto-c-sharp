using System;
using System.Linq;

namespace OpenPhoto.Model
{
    /// <summary>
    /// This class represents a typed response envelope, which is returned in JSON by the API.
    /// </summary>
    /// <typeparam name="T">The type of actual response that is expected. This will be the type of the Result property</typeparam>
    /// <remarks>
    /// For more information on the structure of the response envelope, please visit http://theopenphotoproject.org/documentation/api/Envelope
    /// </remarks>
    public class ResponseEnvelope<T>
    {
        /// <summary>
        /// The message returned by the API
        /// </summary>
        public string Message { get; set; }
        
        /// <summary>
        /// The return code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// The actual response from the API. This will be different depending on the endpoint.
        /// </summary>
        public T Result { get; set; }
    }
}
