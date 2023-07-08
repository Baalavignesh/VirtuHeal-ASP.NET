using Microsoft.AspNetCore.Mvc;
using VirtuHeal.Services;
using VirtuHeal.Models;
using VirtuHeal.DTOs;

namespace VirtuHeal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ISingleChatService _ChatService;


        public ChatController(ISingleChatService ChatService)
        {
            _ChatService = ChatService;
        }


        [HttpGet("GetChat/{chatId}")]
        public async Task<ActionResult<MyChats>> GetChat(int chatId)
        {
            var response = await _ChatService.GetSingleChat(chatId);

            return Ok(response);
        }


        [HttpPost("AddChatMessage")]
        public async Task<ActionResult<bool>> AddChatMessage(NewSingleChatDto request)
        {
            await _ChatService.AddSingleChat(request);

            return Ok(true);
        }


    }
}
