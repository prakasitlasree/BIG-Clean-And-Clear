using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIG.Clean.Care.MODEL
{
    public class ResponseModel
    {
        public string MESSAGE { get; set; }
        public bool STATUS { get; set; }

        public dynamic RESULT { get; set; }
        public string ERROR_MESSAGE { get; set; }
    }
}
