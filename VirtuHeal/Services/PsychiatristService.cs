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
    public interface IPsychiatristService
    {
        Task<ServiceResponse<IEnumerable<Student>>> GetMyStudents(int pyschiatrist_id);
        Task<ServiceResponse<Psychiatrist>> GetMyInfo(int psychiatrist_id);
        Task<ServiceResponse<Psychiatrist>> UpdateVerifyStatus(int psychiatrist_id);
    }

    public class PsychiatristService : IPsychiatristService
    {
        private readonly ApplicationDbContext _context;



        public PsychiatristService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<IEnumerable<Student>>> GetMyStudents(int psychiatrist_id)
        {
            var response = new ServiceResponse<IEnumerable<Student>>();

            if (_context.Students == null)
            {
                response.Error = "Db server error";
            }
            try
            {
                response.Data = await _context.Students.Where(c => c.my_psychiatrist == psychiatrist_id).ToListAsync();
            }
            catch (Exception e)
            {
                response.Error = "An error occurred while retrieving student info: " + e.Message;
            }
            return response;
        }


        public async Task<ServiceResponse<Psychiatrist>> GetMyInfo(int psychiatrist_id)
        {
            var response = new ServiceResponse<Psychiatrist>();

            if (_context.Psychiatrists == null)
            {
                response.Error = "Db server error";
            }
            try
            {
                response.Data = await _context.Psychiatrists.Where(c => c.psychiatrist_id == psychiatrist_id).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                response.Error = "An error occurred while retrieving student's psychiatrist info: " + e.Message;
            }
            return response;

        }


        public async Task<ServiceResponse<Psychiatrist>> UpdateVerifyStatus(int psychiatrist_id)
        {
            var response = new ServiceResponse<Psychiatrist>();

            try
            {
                Psychiatrist psychiatristUpdate = await _context.Psychiatrists.FindAsync(psychiatrist_id);

                if (psychiatristUpdate == null)
                {
                    response.Error = "Appointment not found";
                    return response;
                }

                psychiatristUpdate.is_verified = true;
                _context.Update(psychiatristUpdate);
                await _context.SaveChangesAsync();

                response.Data = psychiatristUpdate;
            }
            catch (Exception e)
            {
                response.Error = "An error occurred while updating the appointment status: " + e.Message;
            }

            return response;

        }
    }
}

