using Business.Abstract;
using Entity.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {

        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost("Apply")]
        public IActionResult Apply(ApplyReportRequest applyReportRequest)
        {
            var result = _reportService.ApplyForMyReport(applyReportRequest);

            return Ok(result.Result);
        }

    }
}
