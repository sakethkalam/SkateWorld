using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiResponses
    {
        public ApiResponses(int StatusCode, string Message=null)
        {
            this.StatusCode = StatusCode;
            this.Message = Message ?? GetDefaulMessageForStatusCode(StatusCode);
        }

        

        public int StatusCode { get; set; }
        public string Message { get; set; }

        public string GetDefaulMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource found, it was not",
                500 => "Server error is made",
                _ => null
            };
        }
    }
}