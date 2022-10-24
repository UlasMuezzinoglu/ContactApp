using Business.Abstract;
using Entity.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public IActionResult Apply([FromQuery] ApplyReportRequest applyReportRequest)
        {
            var result = _reportService.ApplyForMyReport(applyReportRequest);

            return Ok(result.Result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _reportService.GetAll();

            return Ok(result);
        }

        [HttpGet("Get")]
        public IActionResult Get([FromQuery] Guid guid)
        {
            var result = _reportService.Get(guid);

            return Ok(result);
        }

    }
}
