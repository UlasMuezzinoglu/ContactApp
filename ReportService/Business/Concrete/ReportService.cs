using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ReportService : IReportService
    {

        private readonly IProducerService _producerService;
        private readonly IReportDal _reportDal;

        public ReportService(IProducerService producerService , IReportDal reportDal)
        {
            _producerService = producerService;
            _reportDal = reportDal;
        }

        public async Task<string> ApplyForMyReport(ApplyReportRequest applyReportRequest)
        {
            await WriteToQueue(applyReportRequest.Location);

            await PrepareReportEntity();

            return "Your Report Generation Request has been received. Your report is being prepared now.";
        }


        public async Task WriteToQueue(String location)
        {
            await PrepareQueue();
            _producerService.PushReportApplyToQueue(location);        
        }

        public async Task PrepareQueue()
        {
            _producerService.PushReportApplyToQueue("initalize");
        }

        private async Task PrepareReportEntity()
        {
            Report report = new();

            _reportDal.Add(report);
            
        }

        public List<Report> GetAll()
        {
            return _reportDal.GetAll();
        }

        public Report Get(Guid guid)
        {
            return _reportDal.Get(item => item.Id == guid);
        }
    }
}
