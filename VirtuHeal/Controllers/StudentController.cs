using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtuHeal.Models;
using VirtuHeal.Services;

namespace VirtuHeal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        //GetMyInfo
        [HttpGet("GetMyInfo")]
        public async Task<ActionResult<Student>> GetMyInfo(int student_id)
        {
            var db_response = await _studentService.GetMyInfo(student_id);

            if (db_response.Data == null)
            {
                return NotFound(new { db_response.Error });
            }
            else
            {
                return Ok(db_response.Data);
            }
        }

        //GetMyPsychiatrist
        [HttpGet("GetMyPsychiatrist")]
        public async Task<ActionResult<Psychiatrist>> GetMyPsychiatrist(int psychiatrist_id)
        {
            var db_response = await _studentService.GetMyPsychiatrist(psychiatrist_id);

            if(db_response.Data == null) {
                return NotFound(new { db_response.Error });
            }
            else {
                return Ok(db_response.Data);
            }
        }

        // GetVerified
        [HttpGet("AssignPsychiatrist")]
        public async Task<ActionResult<Psychiatrist>> AssignPsychiatrist(int student_id, int pyschiatrist_id)
        {
            var db_response = await _studentService.AssignPsychiatrist(student_id, pyschiatrist_id);
            if (db_response.Data == null)
            {
                return NotFound(new { db_response.Error });
            }
            else
            {
                return Ok(db_response.Data);
            }
        }

        //GetMyChats

    }
}
