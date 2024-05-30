using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Tools.HttpResponse
{
    public class ResponseSuccess<TResponse>
    {

        public ResponseSuccess()
        {

        }
        public ResponseSuccess(HttpEnums code, TResponse data)
        {
            Data = data;
            statusCode = (int)code;
        }
        public TResponse Data { get; set; } = default(TResponse)!;
        public int statusCode { get; set; }
    }
}