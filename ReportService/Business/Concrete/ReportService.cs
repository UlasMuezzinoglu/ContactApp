using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ReportService : IReportService
    {
        public string ApplyForMyReport()
        {
            return "SUCCESSSS";
        }
    }
}
