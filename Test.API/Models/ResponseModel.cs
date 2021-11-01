using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.API.Models
{
    public class ResponseModel
    {
        public string Code { get; set; }
        public dynamic Data { get; set; }
        public string Description { get; set; }
    }
}
