using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banshee.Customers.Dto
{
    [Serializable]
    public class ErrorResponseDto
    {
        [JsonProperty("error_code")]
        public string Code { get; set; }
        [JsonProperty("error_message")]
        public string Message { get; set; }
        public Exception Exp { get; internal set; }
    }
}
