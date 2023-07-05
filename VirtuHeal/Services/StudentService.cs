using System;
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

	public interface IStudentService
	{
		Task<ServiceResponse<Psychiatrist>> GetMyPsychiatrist(int psychiatrist_id);
	}

	public class StudentService:IStudentService
	{
		private readonly ApplicationDbContext _context;

		public StudentService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<ServiceResponse<Psychiatrist>> GetMyPsychiatrist(int psychiatrist_id) {
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
	}
}

