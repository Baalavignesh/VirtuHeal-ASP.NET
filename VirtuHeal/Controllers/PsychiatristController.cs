using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtuHeal.DTOs;
using VirtuHeal.Models;
using VirtuHeal.Services;

namespace VirtuHeal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PsychiatristController : ControllerBase
    {
        private readonly IPsychiatristService _psychiatristService;
        private readonly IAppointmentService _appointmentService;


        public PsychiatristController(IPsychiatristService psychiatristService, IAppointmentService appointmentService)
        {
            _psychiatristService = psychiatristService;
            _appointmentService = appointmentService;
        }

        //GetMyInfo
        [HttpGet("GetMyInfo")]
        public async Task<ActionResult<Student>> GetMyInfo(int psychiatrist_id)
        {
            var db_response = await _psychiatristService.GetMyInfo(psychiatrist_id);

            if (db_response.Data == null)
            {
                return NotFound(new { db_response.Error });
            }
            else
            {
                return Ok(db_response.Data);
            }
        }


        // GetAllStudents
        [HttpGet("GetMyStudents")]
        public async Task<ActionResult<IEnumerable<Student>>> GetMyStudents(int pyschiatrist_id)
        {
            var db_response = await _psychiatristService.GetMyStudents(pyschiatrist_id);
            if (db_response.Data == null)
            {
                return NotFound(new { db_response.Error });
            }
            else
            {
                return Ok(db_response.Data);
            }
        }

        // GetVerified
        [HttpGet("GetVerified")]
        public async Task<ActionResult<Psychiatrist>> GetVerified(int pyschiatrist_id)
        {
            var db_response = await _psychiatristService.UpdateVerifyStatus(pyschiatrist_id);
            if (db_response.Data == null)
            {
                return NotFound(new { db_response.Error });
            }
            else
            {
                return Ok(db_response.Data);
            }
        }

    }

}


