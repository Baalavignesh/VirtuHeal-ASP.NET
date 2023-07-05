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

        //GetMyPsychiatrist
        [HttpGet("getmypsychiatrist")]
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


        //AcceptorDenySchedule
        //SheduleAppointment
        //GetMyChats

    }
}
