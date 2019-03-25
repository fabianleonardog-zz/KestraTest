using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KestraTest.Contracts.Business;
using Microsoft.AspNetCore.Mvc;

namespace KestraTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentResportController : Controller
    {
        private readonly IStudentReportBusiness _studentReportBusiness;
        public StudentResportController(IStudentReportBusiness studentReportBusiness)
        {
            _studentReportBusiness = studentReportBusiness;
        }

        [HttpGet]
        public IActionResult GetStudentReport(string studentName, int? gradeGreatherThan, string subjectName)
        {
            var report = _studentReportBusiness.GetStudentReport(studentName, gradeGreatherThan, subjectName);
            if (report != null && report.Count > 0)
                return Ok(report);
            else
                return NoContent();
        }
    }
}