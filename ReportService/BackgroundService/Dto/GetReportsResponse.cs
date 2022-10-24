using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundService.Dto
{
    public class GetReportsResponse
    {
        public Dictionary<string,int> peopleCount { get; set; }
        public Dictionary<string, int> gsmCount { get; set; }
    }
}
