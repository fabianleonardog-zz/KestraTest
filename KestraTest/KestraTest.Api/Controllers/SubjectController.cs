using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KestraTest.Contracts.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KestraTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectBusiness _subjectBusiness;

        public SubjectController(ISubjectBusiness subjectBusiness)
        {
            _subjectBusiness = subjectBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _subjectBusiness.GetAll();
            if (result != null && result.Count > 0)
                return Ok(result);
            else
                return NoContent();
        }
    }
}