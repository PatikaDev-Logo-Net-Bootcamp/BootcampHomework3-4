using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampHomework3_4.Models
{
    public class BaseResponseModel
    {
        public Object Data { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
    }
}
