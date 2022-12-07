using AutoMapper;
using Core.Contracts;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KudosAPI.Controllers
{
    [ApiController]
    [Route("KudosAPI/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _service;
        private readonly IMapper _mapper;

        public ReportController(IReportService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReportEntity))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(DateTime date)
        {
            var report= await _service.GenerateReport(date);
            return Ok(report);
        }
    }
}