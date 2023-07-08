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

        // GetAllStudents
        [HttpGet("GetMyStudents")]
        public async Task<ActionResult<IEnumerable<Student>>> GetMyStudents(int pyschiatrist_id)
        {
            var response = _psychiatristService.GetMyStudents(pyschiatrist_id);
            return Ok(response);
        }
    }

}


