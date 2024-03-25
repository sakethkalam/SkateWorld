using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiException : ApiResponses
    {
        public ApiException(int StatusCode, string Message = null , string details = null) : base(StatusCode, Message)
        {
            details = Details; 
        }
        public string Details { get; set; }
    }
}