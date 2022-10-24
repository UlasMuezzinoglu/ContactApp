using Entity.Concrete;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IReportService
    {
        Task<string> ApplyForMyReport(ApplyReportRequest applyReportRequest);

        List<Report> GetAll();

        Report Get(Guid guid);
    }
}
