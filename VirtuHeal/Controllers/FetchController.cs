using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtuHeal.Models;
using VirtuHeal.Services;

namespace VirtuHeal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FetchController : ControllerBase
    {
        private readonly IFetchService _fetchService;

        public FetchController(IFetchService fetchService) {
            _fetchService = fetchService;
                }

        [HttpGet("GetAllCollege")]
        public async Task<ActionResult<IEnumerable<College>>> GetColleges()
        {
            var response = await _fetchService.GetColleges();
            return Ok(response);
        }

        [HttpGet("GetStudentInfo")]
        public async Task<ActionResult<IEnumerable<College>>> GetStudentInfo(int student_id)
        {
            //var response = await _fetchService.GetStudentInfo(student_id);
            return Ok(true);
        }



    }
}
