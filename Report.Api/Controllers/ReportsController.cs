using Microsoft.AspNetCore.Mvc;
using Report.Application.Services.Report.Interface;
using Report.Application.Services.Report.Models;

namespace Report.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportsController(IReportService reportService)
    {
        _reportService = reportService;
    }


    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create()
    {
        var report = await _reportService.Create();

        return Created("api/reports/", report);
    }


    [HttpGet]
    [ProducesResponseType(typeof(ReportDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<ReportDto>> GetAll(string id)
    {
        var reports = await _reportService.GetAllReport();

        return reports;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ReportDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ReportDto> Get(string id)
    {
        var report = await _reportService.GetReport(id);

        return report;
    }
}
