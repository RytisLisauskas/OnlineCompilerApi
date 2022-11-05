using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDoodleHttpClient.Models
{
    public class JDoodleResponseModel
    {
        public string Output { get; set; }
        public string StatusCode { get; set; }
        public string Memory { get; set; }
        public string CpuTime { get; set; }
    }
}
