using MessageApp.Data;
using MessageApp.DTOs;
using MessageApp.Enetities;
using MessageApp.Hubs;
using MessageApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace MessageApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        public MessageController(IMessageService messageService, IHubContext<MessageHub> hubContext)
        {
            _messageService = messageService;
            _hubContext = hubContext;
        }
        private readonly IMessageService _messageService;
        private readonly IHubContext<MessageHub> _hubContext;


        [HttpGet]
        public IActionResult Get()
        {
            var messages = _messageService.GetAll();
            return Ok(messages);
        }
        [HttpPost]
        public async Task<IActionResult> Create(MessageDTO message)
        {
            var newMessage = await _messageService.SaveMessage(message);
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", newMessage);
            return Ok(newMessage);
        }
    }
}
