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
        Task<ServiceResponse<Student>> GetMyInfo(int student_id);
        Task<ServiceResponse<Student>> AssignPsychiatrist(int student_id, int psychiatrist_id);

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
                response.Data = await _context.Psychiatrists.Where(c => c.psychiatrist_id == psychiatrist_id && c.is_verified == true).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                response.Error = "An error occurred while retrieving student's psychiatrist info: " + e.Message;
            }
            return response;

        }

        public async Task<ServiceResponse<Student>> GetMyInfo(int student_id)
        {
            var response = new ServiceResponse<Student>();

            if (_context.Students == null)
            {
                response.Error = "Db server error";
            }
            try
            {
                response.Data = await _context.Students.Where(c => c.student_id == student_id).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                response.Error = "An error occurred while retrieving student's info: " + e.Message;
            }
            return response;

        }


        public async Task<ServiceResponse<Student>> AssignPsychiatrist(int student_id, int psychiatrist_id)
        {
            var response = new ServiceResponse<Student>();

            try
            {
                Student studentUpdate = await _context.Students.FindAsync(student_id);

                if (studentUpdate == null)
                {
                    response.Error = "Student not found";
                    return response;
                }

                studentUpdate.my_psychiatrist = psychiatrist_id;
                _context.Update(studentUpdate);
                await _context.SaveChangesAsync();

                response.Data = studentUpdate;
            }
            catch (Exception e)
            {
                response.Error = "An error occurred while assigning psychiatrist to the student: " + e.Message;
            }

            return response;

        }
    }
}

