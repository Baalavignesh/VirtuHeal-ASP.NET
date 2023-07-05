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
    }
}

