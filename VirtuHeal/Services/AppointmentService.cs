using System;
using VirtuHeal.DTOs;
using VirtuHeal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using VirtuHeal.Data;

namespace VirtuHeal.Services
{
    public interface IAppointmentService
    {
        Task<ServiceResponse<Appointment>> SetAppointment(Appointment request);
        Task<ServiceResponse<Appointment>> UpdateAppointmentStatus(int appointmentId, string newStatus);
        Task<ServiceResponse<List<Appointment>>> GetAppointmentsByUserId(int userId, string role);

    }


    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _context;

        public AppointmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task<bool> IsPsychiatristAvailable(int psychiatristId, DateTime startTime)
        {
            DateTime endTime = startTime.AddHours(1);
            bool isAvailable = await _context.Appointments
                    .AnyAsync(a => a.PsychiatristId == psychiatristId && a.Time >= startTime && a.Time < endTime);
            return !isAvailable;
        }


        public async Task<ServiceResponse<Appointment>> SetAppointment(Appointment request)
        {
            var response = new ServiceResponse<Appointment>();
            bool isAvailable = await IsPsychiatristAvailable(request.PsychiatristId, request.Time);

            if (!isAvailable)
            {
                response.Error = "Psychiatrist not available for the given time. Please choose a different time.";
                return response;
            }

            Appointment NewAppointment = new Appointment()
            {
                StudentId = request.StudentId,
                PsychiatristId = request.PsychiatristId,
                InitiatedBy = request.InitiatedBy,
                Time = request.Time,
                Status = request.Status,
            };

            if (_context.Appointments == null)
            {
                response.Error = "Db server error";
            }
            try
            {
                _context.Appointments.Add(NewAppointment);
                await _context.SaveChangesAsync();
                response.Data = NewAppointment;
            }
            catch (Exception e)
            {
                response.Error = "An error occurred while retrieving student's psychiatrist info: " + e.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<Appointment>> UpdateAppointmentStatus(int appointmentId, string newStatus)
        {
            var response = new ServiceResponse<Appointment>();

            try
            {
                Appointment appointmentToUpdate = await _context.Appointments.FindAsync(appointmentId);

                if (appointmentToUpdate == null)
                {
                    response.Error = "Appointment not found";
                    return response;
                }

                appointmentToUpdate.Status = newStatus;
                _context.Update(appointmentToUpdate);
                await _context.SaveChangesAsync();

                response.Data = appointmentToUpdate;
            }
            catch (Exception e)
            {
                response.Error = "An error occurred while updating the appointment status: " + e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Appointment>>> GetAppointmentsByUserId(int userId, string role)
        {
            var response = new ServiceResponse<List<Appointment>>();

            try
            {
                if(role == "student") {
                    List<Appointment> appointments = new List<Appointment>();

                    appointments = await _context.Appointments
                        .Where(a => a.StudentId == userId)
                        .OrderBy(a => a.Time)
                        .ToListAsync();


                    response.Data = appointments;
                }
                else {
                    List<Appointment> appointments = new List<Appointment>();

                    appointments = await _context.Appointments
                        .Where(a => a.PsychiatristId == userId)
                        .OrderBy(a => a.Time)
                        .ToListAsync();


                    response.Data = appointments;
                }

            }
            catch (Exception e)
            {
                response.Error = "An error occurred while retrieving appointments: " + e.Message;
            }

            return response;
        }


    }
}

