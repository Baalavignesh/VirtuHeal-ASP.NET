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
    public interface IUserService
    {
        Task<ServiceResponse<User>> CheckUser(string input_username);
        Task<ServiceResponse<User>> RegisterUser(string username, byte[] PasswordHash, byte[] passwordSalt, string role);
        Task<ServiceResponse<UserDto>> LoginUser(LoginDto request);
        Task<ServiceResponse<Student>> StudentUser(StudentInfoDto request);
        Task<ServiceResponse<Psychiatrist>> PsychiatristUser(PsychiatristInfoDto request);


    }

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<User>> CheckUser(string input_username)
        {
            var response = new ServiceResponse<User>();
            if (_context.User == null)
            {
                response.Error = "Db Server Error";
            }
            var user = await _context.User.FirstOrDefaultAsync(u => u.username == input_username);
            response.Data = user;
            response.Error = "User Already Exists";

            if (user == null)
            {
                response.Error = "User not found";
            }
            return response;
        }

        public async Task<ServiceResponse<User>> RegisterUser(string username, byte[] PasswordHash, byte[] passwordSalt, string role)
        {
            User NewUser = new User()
            {
                username = username,
                password_hash = PasswordHash,
                password_salt = passwordSalt,
                role = role,
                is_online = false
            };



            var response = new ServiceResponse<User>();
            if (_context.User == null)
            {
                response.Error = "Db Server Error";
            }
            _context.User.Add(NewUser);

            await _context.SaveChangesAsync();
            response.Data = NewUser;
            return response;
        }


        public async Task<ServiceResponse<Student>> StudentUser(StudentInfoDto request)
        {
            Student NewStudent = new Student()
            {
                UserId = request.user_id,
                name = request.name,
                qualification = request.qualification,
                gender = request.gender,
                number = request.number,
                college_id = request.college_id,
                age = request.age,
            };


            var response = new ServiceResponse<Student>();
            if (_context.Students == null)
            {
                response.Error = "Db Server Error";
            }
            _context.Students.Add(NewStudent);

            await _context.SaveChangesAsync();
            response.Data = NewStudent;


            StudentQuestions NewStudentQuestions = new StudentQuestions()
            {
                student_id = response.Data.student_id,
                question1 = request.question1,
                answer1 = request.answer1,
                question2 = request.question2,
                answer2 = request.answer2,
                question3 = request.question3,
                answer3 = request.answer3,
                question4 = request.question4,
                answer4 = request.answer4,
            };

            _context.StudentQuestions.Add(NewStudentQuestions);
            await _context.SaveChangesAsync();


            response.Data = NewStudent;
            return response;
        }


        public async Task<ServiceResponse<Psychiatrist>> PsychiatristUser(PsychiatristInfoDto request)
        {
            Console.WriteLine(request);
            Psychiatrist NewPsychiatrist = new Psychiatrist()
            {
                UserId = request.user_id,
                name = request.name,
                age = request.age,
                qualification = request.qualification,
                gender = request.gender,
                number = request.number,
                college_id = request.college_id,
                is_verified = false,
                resume_url = request.resume_url,
            };


            var response = new ServiceResponse<Psychiatrist>();
            if (_context.Psychiatrists == null)
            {
                response.Error = "Db Server Error";
            }
            _context.Psychiatrists.Add(NewPsychiatrist);

            await _context.SaveChangesAsync();
            response.Data = NewPsychiatrist;


            PsychiatristpQuestions NewPsychiatristQuestions = new PsychiatristpQuestions()
            {
                psychiatrist_id = response.Data.psychiatrist_id,
                question1 = request.question1,
                answer1 = request.answer1,
                question2 = request.question2,
                answer2 = request.answer2,
            };

            _context.PsychiatristpQuestions.Add(NewPsychiatristQuestions);
            await _context.SaveChangesAsync();


            response.Data = NewPsychiatrist;
            return response;
        }


        public async Task<ServiceResponse<UserDto>> LoginUser(LoginDto request)
        {
            var response = new ServiceResponse<UserDto>();

            if (_context.User == null)
            {
                response.Error = "Db Server Error";
            }
            var user = await _context.User.FirstOrDefaultAsync(u => u.username == request.Username);

            System.Diagnostics.Debug.WriteLine(user);

            if (user == null)
            {
                response.Error = "User not found";
            }
            else
            {
                int myId = 0;
                if (user.role == "student")
                {
                    myId = await _context.Students.Where(s => s.UserId == user.user_id)
                                        .Select(s => s.student_id)
                                        .FirstOrDefaultAsync();


                }
                else if (user.role == "psychiatrist")
                {
                    myId = await _context.Psychiatrists.Where(s => s.UserId == user.user_id)
                                        .Select(s => s.psychiatrist_id)
                                        .FirstOrDefaultAsync();
                }

                var userDto = new UserDto
                {
                    UserId = user.user_id,
                    Username = user.username,
                    password_hash = user.password_hash,
                    password_salt = user.password_salt,
                    Role = user.role,
                    MyId = myId
                    // Map other properties from User to UserDto
                };

                response.Data = userDto;

            }
            return response;
        }



    }
}
