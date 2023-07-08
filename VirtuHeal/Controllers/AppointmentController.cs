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
    public class AppointmentController : ControllerBase
    {

        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService) {
            _appointmentService = appointmentService;
        }

        [HttpPost("NewAppointment")]
        public async Task<ActionResult<Appointment>> ScheduleAppointment(Appointment request)
        {
            var response = await _appointmentService.SetAppointment(request);
            return Ok(response);
        }


        [HttpPost("UpdateAppointment")]
        public async Task<ActionResult<Appointment>> UpdateAppointment(int appointment_id, string new_status)
        {
            var response = await _appointmentService.UpdateAppointmentStatus(appointment_id, new_status);
            return Ok(response);
        }

        [HttpGet("GetAppointment")]
        public async Task<ActionResult<Appointment>> GetMyAppointments(int user_id, string role)
        {
            var response = await _appointmentService.GetAppointmentsByUserId(user_id, role);
            return Ok(response);
        }
    }
}
