using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OA.Repo.Errors
{
    public class RestException : Exception
    {
        public RestException(HttpStatusCode code, Object errors = null)
        {
            Code = code;
            Errors = errors;
        }
        public HttpStatusCode Code { get; }
        public object Errors { get; }
    }
}
