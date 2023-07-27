using VirtuHeal.DTOs;
using VirtuHeal.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using VirtuHeal.Data;
using VirtuHeal.DTOs;
using VirtuHeal.Models;

namespace VirtuHeal.Services
{
    public interface ISingleChatService
    {
        Task<ServiceResponse<IEnumerable<SingleChatMessage>>> GetSingleChat(int ChatId);
        Task<ServiceResponse<MyChats>> GetChatId(int studentId, int psychiatristId);
         Task<ServiceResponse<bool>> AddSingleChat(NewSingleChatDto request);
    }
    public class SingleChatService : ISingleChatService
    {
        private readonly ApplicationDbContext _context;

        // object to add a new data to the table
        public SingleChatService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<IEnumerable<SingleChatMessage>>> GetSingleChat(int ChatId)
        {
            var response = new ServiceResponse<IEnumerable<SingleChatMessage>>();

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            response.Data = await _context.SingleChatMessage.Where(sc => sc.ParentChatId == ChatId).ToListAsync();

            return response;
        }



        public async Task<ServiceResponse<MyChats>> GetChatId(int studentId, int psychiatristId)
        {
            var response = new ServiceResponse<MyChats>();

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            response.Data = await _context.MyChats.Where(sc => sc.StudentId == studentId && sc.PsychiatristId == psychiatristId).FirstOrDefaultAsync();

            if (response.Data == null)
            {
                response.Error = "No chat found";
            }

            return response;
        }
        public async Task<ServiceResponse<bool>> AddSingleChat(NewSingleChatDto request)
        {
            var response = new ServiceResponse<bool>();

            var existingSingleChat = await _context.MyChats.FirstOrDefaultAsync(x =>
                (x.StudentId == request.StudentId && x.PsychiatristId == request.PsychiatristId));


            // Check if SingleChat table is having the receiver id if yes, just add data 
            if (existingSingleChat != null)
            {

                var newSingleChatMessage = new SingleChatMessage
                {
                    ParentChatId = existingSingleChat.MyChatId,
                    Message = request.Message,
                    SenderRole = request.SenderRole,
                    Timestamp = DateTime.Now,
                    IsRead = false,
                };
                _context.SingleChatMessage.Add(newSingleChatMessage);
            }
            // New Chat User
            // new message, new user. Add to My Chats. Then SingleChat. Then SingleChatMessage

            else
            {
                var newMyChat = new MyChats
                {
                    StudentId = request.StudentId,
                    PsychiatristId = request.PsychiatristId
                };
                _context.MyChats.Add(newMyChat);

                await _context.SaveChangesAsync();

                var newSingleChatMessage = new SingleChatMessage
                {
                    ParentChatId = newMyChat.MyChatId,
                    Message = request.Message,
                    SenderRole = request.SenderRole,
                    Timestamp = DateTime.Now
                };
                _context.SingleChatMessage.Add(newSingleChatMessage);
                await _context.SaveChangesAsync();
            }

            await _context.SaveChangesAsync();

            return response;

        }
    }
}