using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_API.Models
{
    public class Response
    {
        public int statuscode { get; set; }
        public string message { get; set; }

        public Response(int code, string msg)
        {
            statuscode = code;
            message = msg;
        }
    }
}
