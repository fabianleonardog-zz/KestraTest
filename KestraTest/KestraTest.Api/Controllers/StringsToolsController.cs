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
    public class StringsToolsController : ControllerBase
    {

        private readonly IStringsToolsBusiness _stringsToolsBusiness;
        public StringsToolsController(IStringsToolsBusiness stringsToolsBusiness)
        {
            _stringsToolsBusiness = stringsToolsBusiness;
        }

        [HttpGet]
        public IActionResult MergeStrings(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
                return BadRequest("The paramaters a and b must have values");
            else
            {
                string result = _stringsToolsBusiness.MergeStrings(a, b);
                if (string.IsNullOrEmpty(result))
                    return NoContent();
                else
                    return Ok(result);
            }
        }

    }
}