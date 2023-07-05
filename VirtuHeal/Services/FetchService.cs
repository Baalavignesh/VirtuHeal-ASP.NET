using System;
using VirtuHeal.DTOs;
using VirtuHeal.Models;
using VirtuHeal.Data;
using Microsoft.EntityFrameworkCore;

namespace VirtuHeal.Services
{
    public interface IFetchService
    {

        Task<ServiceResponse<IEnumerable<College>>> GetColleges();
        //Task<ServiceResponse<StudentInfoDto>> GetStudentInfo(int student_id);
    }

    public class FetchService : IFetchService
    {

        private readonly ApplicationDbContext _context;

        public FetchService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<IEnumerable<College>>> GetColleges()
        {
            var response = new ServiceResponse<IEnumerable<College>>();

            if (_context.Colleges == null)
            {
                response.Error = "Db Server Error";
            }
            // Fill this line below
            var colleges = await _context.Colleges.ToListAsync();
            response.Data = colleges;

            return response;
        }

        //    public async Task<ServiceResponse<StudentInfoDto>> GetStudentInfo(int student_id)
        //    {
        //        var response = new ServiceResponse<StudentInfoDto>();

        //        if (_context.Students == null)
        //        {
        //            response.Error = "Db Server Error";
        //        }

        //        try
        //        {
        //            var student = await _context.Students.FirstOrDefaultAsync(s => s.student_id == student_id);

        //            if (student == null)
        //            {
        //                response.Error = "Student not found";
        //                return response;
        //            }

        //            var studentInfoDto = new StudentInfoDto
        //            {
        //                student_id = student.student_id,
        //                name = student.name,
        //                age = student.age,
        //                qualification = student.qualification,
        //                gender = student.gender,
        //                number = student.number,
        //                college_id = student.college_id,
        //                my_pyschiatrist = student.my_psychiatrist,

        //                question1 = student.StudentQuestions.question1,
        //                answer1 = student.StudentQuestions.answer1,
        //                question2 = student.StudentQuestions.question2,
        //                answer2 = student.StudentQuestions.answer2,
        //                question3 = student.StudentQuestions.question3,
        //                answer3 = student.StudentQuestions.answer3,
        //                question4 = student.StudentQuestions.question4,
        //                answer4 = student.StudentQuestions.answer4
        //            };

        //            response.Data = studentInfoDto;

        //        }



        //        catch (Exception ex)
        //        {
        //            response.Error = "An error occurred while retrieving student info: " + ex.Message;
        //        }

        //        return response;
        //    }
        //}
    }
}

